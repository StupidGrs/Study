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


namespace RetirementStudio._TestScripts_2019_Oct._SpecialPurpose
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class US015_CN_CompareRpt
    {
        public US015_CN_CompareRpt()
        {
            Config.bCompareReports = true;
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


        public string sOutputFunding_Converson2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Conversion 2010\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Baseline\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_FVclosedgroup_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\FV closed group\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_Countsonlyretirementdec_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Counts only retirement dec\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_Projectwithgroup_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Project with group\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_Groupsforreportsnotpop_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Groups for reports not pop\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_Secondoptiongroups_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Second option groups\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_LevelpopulationandMultipleDx_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Level population and Multiple Dx\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_ClosedGroupregulardecrements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Closed Group regular decrements\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_Countsregrlardecrements_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Counts regrlar decrements\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_Groupprojections_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Group projections\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_Reportgroupsnotpop_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Report groups not pop\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_SecondOptionforgroups_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Second Option for groups\6.8_20160303_Franklin\";
        public string sOutputFunding_Valuation2011_ChangeprovisionsforFV_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Funding\Valuation 2011\Change provisions for FV\6.8_20160303_Franklin\";
        public string sOutputAccounting_Conversion2010_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Conversion 2010\6.8_20160303_Franklin\";
        public string sOutputAccounting_Accounting2011_Baseline_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Accounting 2011\Baseline\6.8_20160303_Franklin\";
        public string sOutputAccounting_Accounting2011_FVwithSVCamtCG_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Accounting 2011\FV with SVC amt CG\6.8_20160303_Franklin\";
        public string sOutputAccounting_Accounting2011_Projandvalassmptsdiff_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Accounting 2011\Proj and val assmpts diff\6.8_20160303_Franklin\";
        public string sOutputAccounting_Accounting2011_AddNewEntrants_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Accounting 2011\Add New Entrants\6.8_20160303_Franklin\";
        public string sOutputAccounting_Accounting2011_NEswithtestcriteria_Prod = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Production\Accounting\Accounting 2011\NEs with test criteria\6.8_20160303_Franklin\";

        public void GenerateReportOuputDir()
        {


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
                    string sMainDir = @"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\QA_BM_015_FutVal\Existing\";
                    string sPostFix = _gLib._ReturnDateStampYYYYMMDD() + "_" + Config.eEnv.ToString();

                    //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);


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

                string sMainDir = sDir + "US015_" + _gLib._ReturnDateStampYYYYMMDD();

                //////_gLib._MsgBoxYesNo("Are you sure to create folders under below directory ?", sMainDir);


                _gLib._CreateDirectory(sMainDir);
                sOutputFunding_Converson2010 = _gLib._CreateDirectory(sMainDir + "\\Funding_Converson2010\\");
                sOutputFunding_Valuation2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_Baseline\\");
                sOutputFunding_Valuation2011_FVclosedgroup = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_FVclosedgroup\\");
                sOutputFunding_Valuation2011_Countsonlyretirementdec = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_Countsonlyretirementdec\\");
                sOutputFunding_Valuation2011_Projectwithgroup = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_Projectwithgroup\\");
                sOutputFunding_Valuation2011_Groupsforreportsnotpop = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_Groupsforreportsnotpop\\");
                sOutputFunding_Valuation2011_Secondoptiongroups = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_Secondoptiongroups\\");
                sOutputFunding_Valuation2011_LevelpopulationandMultipleDx = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_LevelpopulationandMultipleDx\\");
                sOutputFunding_Valuation2011_ClosedGroupregulardecrements = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_ClosedGroupregulardecrements\\");
                sOutputFunding_Valuation2011_Countsregrlardecrements = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_Countsregrlardecrements\\");
                sOutputFunding_Valuation2011_Groupprojections = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_Groupprojections\\");
                sOutputFunding_Valuation2011_Reportgroupsnotpop = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_Reportgroupsnotpop\\");
                sOutputFunding_Valuation2011_SecondOptionforgroups = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_SecondOptionforgroups\\");
                sOutputFunding_Valuation2011_ChangeprovisionsforFV = _gLib._CreateDirectory(sMainDir + "\\Funding_Valuation2011_ChangeprovisionsforFV\\");
                sOutputAccounting_Conversion2010 = _gLib._CreateDirectory(sMainDir + "\\Accounting_Conversion2010\\");
                sOutputAccounting_Accounting2011_Baseline = _gLib._CreateDirectory(sMainDir + "\\Accounting_Accounting2011_Baseline\\");
                sOutputAccounting_Accounting2011_FVwithSVCamtCG = _gLib._CreateDirectory(sMainDir + "\\Accounting_Accounting2011_FVwithSVCamtCG\\");
                sOutputAccounting_Accounting2011_Projandvalassmptsdiff = _gLib._CreateDirectory(sMainDir + "\\Accounting_Accounting2011_Projandvalassmptsdiff\\");
                sOutputAccounting_Accounting2011_AddNewEntrants = _gLib._CreateDirectory(sMainDir + "\\Accounting_Accounting2011_AddNewEntrants\\");
                sOutputAccounting_Accounting2011_NEswithtestcriteria = _gLib._CreateDirectory(sMainDir + "\\Accounting_Accounting2011_NEswithtestcriteria\\");

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
        public GenericLib_Win _gLib = new GenericLib_Win();



        #endregion



        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_US015_CN_CompareRpt()
        {





            #region sOutputFunding_Converson2010
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Converson2010_Prod, sOutputFunding_Converson2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Converson2010");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2010.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
            }
            #endregion


            #region sOutputFunding_Valuation2011_Baseline
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Baseline_Prod, sOutputFunding_Valuation2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Baseline");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);

            }
            #endregion


            #region sOutputFunding_Valuation2011_FVclosedgroup
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_FVclosedgroup_Prod, sOutputFunding_Valuation2011_FVclosedgroup);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_FVclosedgroup");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);

            }
            #endregion


            #region sOutputFunding_Valuation2011_Countsonlyretirementdec
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Countsonlyretirementdec_Prod, sOutputFunding_Valuation2011_Countsonlyretirementdec);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Countsonlyretirementdec");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);

            }
            #endregion



            #region sOutputFunding_Valuation2011_Projectwithgroup
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Projectwithgroup_Prod, sOutputFunding_Valuation2011_Projectwithgroup);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Projectwithgroup");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);

            }
            #endregion



            #region sOutputFunding_Valuation2011_Groupsforreportsnotpop
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Groupsforreportsnotpop_Prod, sOutputFunding_Valuation2011_Groupsforreportsnotpop);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Groupsforreportsnotpop");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);

            }
            #endregion


            #region sOutputFunding_Valuation2011_Secondoptiongroups
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Secondoptiongroups_Prod, sOutputFunding_Valuation2011_Secondoptiongroups);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Secondoptiongroups");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);

            }
            #endregion




            #region sOutputFunding_Valuation2011_LevelpopulationandMultipleDx
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_LevelpopulationandMultipleDx_Prod, sOutputFunding_Valuation2011_LevelpopulationandMultipleDx);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_LevelpopulationandMultipleDx");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
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
            }
            #endregion


            #region sOutputFunding_Valuation2011_ClosedGroupregulardecrements
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_ClosedGroupregulardecrements_Prod, sOutputFunding_Valuation2011_ClosedGroupregulardecrements);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_ClosedGroupregulardecrements");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
            }
            #endregion


            #region sOutputFunding_Valuation2011_Countsregrlardecrements
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Countsregrlardecrements_Prod, sOutputFunding_Valuation2011_Countsregrlardecrements);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Countsregrlardecrements");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
            }
            #endregion


            #region sOutputFunding_Valuation2011_Groupprojections
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Groupprojections_Prod, sOutputFunding_Valuation2011_Groupprojections);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Groupprojections");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
            }
            #endregion


            #region sOutputFunding_Valuation2011_Reportgroupsnotpop
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_Reportgroupsnotpop_Prod, sOutputFunding_Valuation2011_Reportgroupsnotpop);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_Reportgroupsnotpop");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
            }
            #endregion


            #region sOutputFunding_Valuation2011_SecondOptionforgroups
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_SecondOptionforgroups_Prod, sOutputFunding_Valuation2011_SecondOptionforgroups);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_SecondOptionforgroups");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
            }
            #endregion


            #region sOutputFunding_Valuation2011_ChangeprovisionsforFV
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputFunding_Valuation2011_ChangeprovisionsforFV_Prod, sOutputFunding_Valuation2011_ChangeprovisionsforFV);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputFunding_Valuation2011_ChangeprovisionsforFV");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
            }

            #endregion




            #region sOutputAccounting_Conversion2010
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputAccounting_Conversion2010_Prod, sOutputAccounting_Conversion2010);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Conversion2010");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2010.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2020.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2030.xlsx", 4, 0, 0, 0);
            }
            #endregion


            #region sOutputAccounting_Accounting2011_Baseline
            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputAccounting_Accounting2011_Baseline_Prod, sOutputAccounting_Accounting2011_Baseline);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_Baseline");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
            }
            #endregion




            #region sOutputAccounting_Accounting2011_FVwithSVCamtCG

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputAccounting_Accounting2011_FVwithSVCamtCG_Prod, sOutputAccounting_Accounting2011_FVwithSVCamtCG);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_FVwithSVCamtCG");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
            }
            #endregion


            #region sOutputAccounting_Accounting2011_Projandvalassmptsdiff

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputAccounting_Accounting2011_Projandvalassmptsdiff_Prod, sOutputAccounting_Accounting2011_Projandvalassmptsdiff);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_Projandvalassmptsdiff");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
            }
            #endregion


            #region sOutputAccounting_Accounting2011_AddNewEntrants


            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputAccounting_Accounting2011_AddNewEntrants_Prod, sOutputAccounting_Accounting2011_AddNewEntrants);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_AddNewEntrants");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2011.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2012.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2013.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2014.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2015.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2016.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2021.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationPayouts_2031.xlsx", 4, 0, 0, 0);
            }
            #endregion




            #region sOutputAccounting_Accounting2011_NEswithtestcriteria

            if (Config.bCompareReports)
            {
                CompareReportsLib _compareReportsLib = new CompareReportsLib("US015CN", sOutputAccounting_Accounting2011_NEswithtestcriteria_Prod, sOutputAccounting_Accounting2011_NEswithtestcriteria);
                _compareReportsLib._Report(_PassFailStep.Description, "", "sOutputAccounting_Accounting2011_NEswithtestcriteria");
                _compareReportsLib.CompareExcel_Exact("FutureValuationPopulationProjection.xlsx", 4, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationSummary.xlsx", 4, new string[1] { "Sheet1" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyGroup.xlsx", 12, 0, 0, 0);
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 12, new string[1] { "Sheet2" });
                _compareReportsLib.CompareExcel_Exact("FutureValuationLiabilitiesbyYear.xlsx", 4, new string[1] { "Sheet1" });
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
            }

            #endregion


            _gLib._MsgBox("Congratulations!", "Finished!");

            Environment.Exit(0);



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
