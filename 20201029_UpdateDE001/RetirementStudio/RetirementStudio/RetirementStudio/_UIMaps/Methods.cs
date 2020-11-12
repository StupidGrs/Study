namespace RetirementStudio._UIMaps.MethodsClasses
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;

    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Accessibility;
    using RetirementStudio._ThridParty;
    using System.Threading;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;


    public partial class Methods
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();


        public void _Debugging()
        {

            var a = _fp._ReturnSelectRowContent(this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid);
            var b = 1;
        }

        /// <summary>
        /// 2013-May-13
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Funding", "");
        ///    dic.Add("PBGCTermLiability", "");
        ///    dic.Add("NondiscriminationTesting", "");
        ///    dic.Add("BenefitExclusions_DthLiab", "");
        ///    dic.Add("BenefitExclusions_InacLiab", "");
        ///    dic.Add("BenefitExclusions_InactDIDLiab", "");
        ///    dic.Add("BenefitExclusions_RetLiab", "");
        ///    dic.Add("BenefitExclusions_WthDIDLiab", "");
        ///    dic.Add("BenefitExclusions_WthLiab", "");
        ///    dic.Add("CostMethod", "");
        ///    dic.Add("PBGC4044Calculation", "");
        ///    dic.Add("UseRetirementDecrements", "");
        ///    dic.Add("ServiceForServiceProrate", "");
        ///    dic.Add("CompareToAccrue", "");
        ///    dic.Add("AllowNegativeNormalCost", "");
        ///    dic.Add("btnStartAge_V", "");
        ///    dic.Add("StartAge_cbo", "");
        ///    dic.Add("btnStartAge_C", "");
        ///    dic.Add("StartAge_txt", "");
        ///    dic.Add("UsePresentValueOfFutureSalary", "");
        ///    dic.Add("UsePresentValueOfFutureService", "");
        ///    dic.Add("ProjectedPayToUseForCoveredPay", "");
        ///    dic.Add("AccumulationToUseForExpected", "");
        ///    dic.Add("IncludePVFutureSalaryService", "");
        ///    dic.Add("btnStopPVFuture_V", "");
        ///    dic.Add("StopPVFuture_cbo", "");
        ///    dic.Add("btnStopPVFuture_C", "");
        ///    dic.Add("StopPVFuture_txt", "");
        ///    dic.Add("BeginningOfTheYearPVFuture", "");
        ///    dic.Add("CalculatePresentValueOfFuture", "");
        ///    dic.Add("CalculatePresentValueOfFuture_txt", "");
        ///    pMethods._PopVerify_Methods(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Methods(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_Methods";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iStartAge_txt = 0;
            int iStopPVFuture_txt = 0;

            int iStartAge_cbo = 0;
            int iStopPVFuture_cbo = 0;

            int iIncrease_cbo = 0;
            int iTxtIncrease_txt = 0;


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Funding", this.wRetirementStudio.wFunding.rdFunding, dic["Funding"], 0);
                _gLib._SetSyncUDWin("PBGCTermLiability", this.wRetirementStudio.wPBGCTermLiability.rdPBGCTermLiability, dic["PBGCTermLiability"], 0);
                _gLib._SetSyncUDWin("NondiscriminationTesting", this.wRetirementStudio.wNondiscriminationTesting.rdNondiscriminationTesting, dic["NondiscriminationTesting"], 0);
                _gLib._SetSyncUDWin("BenefitExclusions_DthLiab", this.wRetirementStudio.wBenefitExclusions.listBenefitExclusions.chkDthLiab, dic["BenefitExclusions_DthLiab"], 0);
                _gLib._SetSyncUDWin("BenefitExclusions_InacLiab", this.wRetirementStudio.wBenefitExclusions.listBenefitExclusions.chkInacLiab, dic["BenefitExclusions_InacLiab"], 0);
                _gLib._SetSyncUDWin("BenefitExclusions_InactDIDLiab", this.wRetirementStudio.wBenefitExclusions.listBenefitExclusions.chkInactDIDLiab, dic["BenefitExclusions_InactDIDLiab"], 0);
                _gLib._SetSyncUDWin("BenefitExclusions_RetLiab", this.wRetirementStudio.wBenefitExclusions.listBenefitExclusions.chkRetLiab, dic["BenefitExclusions_RetLiab"], 0);
                _gLib._SetSyncUDWin("BenefitExclusions_WthDIDLiab", this.wRetirementStudio.wBenefitExclusions.listBenefitExclusions.chkWthDIDLiab, dic["BenefitExclusions_WthDIDLiab"], 0);
                _gLib._SetSyncUDWin("BenefitExclusions_WthLiab", this.wRetirementStudio.wBenefitExclusions.listBenefitExclusions.chkWthLiab, dic["BenefitExclusions_WthLiab"], 0);


                _gLib._SetSyncUDWin("CostMethod", this.wRetirementStudio.wCostMethod.cboCostMethod, dic["CostMethod"], 0);
                _gLib._SetSyncUDWin("PBGC4044Calculation", this.wRetirementStudio.wPBGC4044Calculation.chk, dic["PBGC4044Calculation"], 0);
                _gLib._SetSyncUDWin("UseRetirementDecrements", this.wRetirementStudio.wUseRetirementDecrements.chk, dic["UseRetirementDecrements"], 0);
                _gLib._SetSyncUDWin("ServiceForServiceProrate", this.wRetirementStudio.wServiceForServiceProrate.cboServiceForServiceProrate, dic["ServiceForServiceProrate"], 0);
                _gLib._SetSyncUDWin("CompareToAccrue", this.wRetirementStudio.wCompareToAccrued.chkCompareToAccrued, dic["CompareToAccrue"], 0);
                _gLib._SetSyncUDWin("AllowNegativeNormalCost", this.wRetirementStudio.wAllowNegativeNormalCost.chkAllowNegativeNormalCost, dic["AllowNegativeNormalCost"], 0);



                _gLib._SetSyncUDWin("btnStartAge_V", this.wRetirementStudio.wStartAge_VIcon.btnStartAge_V, dic["btnStartAge_V"], 0);
                _gLib._SetSyncUDWin("btnStartAge_C", this.wRetirementStudio.wStartAge_CIcon.btnStartAge_C, dic["btnStartAge_C"], 0);
                if (dic["btnStartAge_V"] != "")
                {
                    iStartAge_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iStartAge_cbo.ToString());
                    _gLib._SetSyncUDWin("StartAge_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["StartAge_cbo"], 0);
                }
                if (dic["btnStartAge_C"] != "")
                {
                    iStartAge_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iStartAge_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("StartAge_txt", this.wRetirementStudio.wCommonTXT.txt, dic["StartAge_txt"], true, 0);
                }


                _gLib._SetSyncUDWin("UsePresentValueOfFutureSalary", this.wRetirementStudio.wUsePresentValueOfFutureSalary.rdUsePresentValueOfFutureSalary, dic["UsePresentValueOfFutureSalary"], 0);
                _gLib._SetSyncUDWin("UsePresentValueOfFutureService", this.wRetirementStudio.wUsePresentValueOfFutureService.rdUsePresentValueOfFutureService, dic["UsePresentValueOfFutureService"], 0);
                _gLib._SetSyncUDWin("ProjectedPayToUseForCoveredPay", this.wRetirementStudio.wProjectedPayToUseForCoveredPay.cboProjectedPayToUseForCoveredPay, dic["ProjectedPayToUseForCoveredPay"], 0);
                _gLib._SetSyncUDWin("AccumulationToUseForExpected", this.wRetirementStudio.wAccumulationToUseForExpected.cboAccumulationToUseForExpected, dic["AccumulationToUseForExpected"], 0);
                _gLib._SetSyncUDWin("IncludePVFutureSalaryService", this.wRetirementStudio.wIncludePVFutureSalaryService.chkIncludePVFutureSalaryService, dic["IncludePVFutureSalaryService"], 0);


                _gLib._SetSyncUDWin("btnStopPVFuture_V", this.wRetirementStudio.wStopPVFuture_VIcon.btnStopPVFuture_V, dic["btnStopPVFuture_V"], 0);
                _gLib._SetSyncUDWin("btnStopPVFuture_C", this.wRetirementStudio.wStopPVFuture_CIcon.btnStopPVFuture_C, dic["btnStopPVFuture_C"], 0);
                if (dic["btnStopPVFuture_V"] != "")
                {
                    iStopPVFuture_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iStopPVFuture_cbo.ToString());
                    _gLib._SetSyncUDWin("StopPVFuture_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["StopPVFuture_cbo"], 0);
                }
                if (dic["btnStopPVFuture_C"] != "")
                {
                    iStopPVFuture_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iStopPVFuture_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("StopPVFuture_txt", this.wRetirementStudio.wCommonTXT.txt, dic["StopPVFuture_txt"], true, 0);
                }


                _gLib._SetSyncUDWin("BeginningOfTheYearPVFuture", this.wRetirementStudio.wBeginningOfTheYearPVFuture.chkBeginningOfTheYearPVFuture, dic["BeginningOfTheYearPVFuture"], 0);
                _gLib._SetSyncUDWin("CalculatePresentValueOfFuture", this.wRetirementStudio.wCalculatePresentValueOfFuture.chkCalculatePresentValueOfFuture, dic["CalculatePresentValueOfFuture"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CalculatePresentValueOfFuture_txt", this.wRetirementStudio.wCalculatePresentValueOfFuture_txt.txtCalculatePresentValueOfFuture, dic["CalculatePresentValueOfFuture_txt"], true, 0);





            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Jan-21
        /// ruiyang.song@mercer.com
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("NormalRetirementAge_V", "");
        ///    dic.Add("NormalRetirementAge_cbo", "");
        ///    dic.Add("NormalRetirementAge_C", "");
        ///    dic.Add("NormalRetirementAge_txt", "");
        ///    dic.Add("TestingAge_V", "");
        ///    dic.Add("TestingAge_cbo", "");
        ///    dic.Add("TestingAge_C", "");
        ///    dic.Add("TestingAge_txt", "");
        ///    dic.Add("ValuationDateAccrued_TheBeginingOf", "");
        ///    dic.Add("ValuationDateAccrued_TheEndof", "");
        ///    dic.Add("Testing_AveragePayDefinition", "PayAverage3");
        ///    dic.Add("Testing_UseCurrentPay", "false");
        ///    dic.Add("DBTestingService_Service", "BenefitService");
        ///    dic.Add("PermittedDisparity_SocialSecurityConvered", "CoveredComp");
        ///    dic.Add("PermittedDisparity_FreshStartService", "ServiceEquals1");
        ///    dic.Add("PermittedDisparity_UseFixedPercentage_rd", "true");
        ///    dic.Add("PermittedDisparity_UseFixedPercentage_txt", "1");
        ///    dic.Add("IncludedefinedContribution_401kmAnnualAddition", "");
        ///    dic.Add("IncludedefinedContribution_401kmBalance", "");
        ///    dic.Add("IncludedefinedContribution_401kmService", "");
        ///    dic.Add("IncludedefinedContribution_Non401kmAnnualAddition", "");
        ///    dic.Add("IncludedefinedContribution_Non401kmBalance", "");
        ///    dic.Add("IncludedefinedContribution_Non401kmService", "");
        ///    dic.Add("TestingBasis_BenefitBasis", "");
        ///    dic.Add("TestingBasis_ContributionBasis", "");
        ///    dic.Add("ForRatioPercentageTest_IncludeDB", "");
        ///    dic.Add("ForRatioPercentageTest_IncludeDC", "");
        ///    pMethods._Method_NonDiscriminationTesting(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Method_NonDiscriminationTesting(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_Methods";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                    
                _gLib._SetSyncUDWin("NormalRetirementAge_V", this.wRetirementStudio.wStartAge_VIcon.btnStartAge_V, dic["NormalRetirementAge_V"], 0);
                _gLib._SetSyncUDWin("NormalRetirementAge_C", this.wRetirementStudio.wStartAge_CIcon.btnStartAge_C, dic["NormalRetirementAge_C"], 0);

                _gLib._SetSyncUDWin("TestingAge_V", this.wRetirementStudio.wStopPVFuture_VIcon.btnStopPVFuture_V, dic["TestingAge_V"], 0);
                _gLib._SetSyncUDWin("TestingAge_C", this.wRetirementStudio.wStopPVFuture_CIcon.btnStopPVFuture_C, dic["TestingAge_C"], 0);


                int iNormalRetirementAge_V = 1;
                int iNormalRetirementAge_C = 1;

                int TestingAge_V = 1;
                int TestingAge_C = 1;

           
                if (dic["NormalRetirementAge_V"] != "" && dic["TestingAge_V"] != "")
                    iNormalRetirementAge_V = 2;
                if (dic["NormalRetirementAge_C"] != "" && dic["TestingAge_C"] != "")
                    iNormalRetirementAge_C = 2;
            

                if (dic["NormalRetirementAge_V"] != "")
                {
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iNormalRetirementAge_V.ToString());
                    _gLib._SetSyncUDWin("NormalRetirementAge_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["NormalRetirementAge_cbo"], 0);
                }
                if (dic["NormalRetirementAge_C"] != "")
                {
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iNormalRetirementAge_C.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("NormalRetirementAge_txt", this.wRetirementStudio.wCommonTXT.txt, dic["NormalRetirementAge_txt"], true, 0);
                }


                if (dic["TestingAge_V"] != "")
                {
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, TestingAge_V.ToString());
                    _gLib._SetSyncUDWin("TestingAge_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["TestingAge_cbo"], 0);
                }
                if (dic["TestingAge_C"] != "")
                {
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, TestingAge_C.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("TestingAge_txt", this.wRetirementStudio.wCommonTXT.txt, dic["TestingAge_txt"], true, 0);
                }

                _gLib._SetSyncUDWin("ValuationDateAccrued_TheBeginingOf", this.wRetirementStudio.wTheBeginningOfThetTestingYear.rd, dic["ValuationDateAccrued_TheBeginingOf"], 0);
                _gLib._SetSyncUDWin("ValuationDateAccrued_TheEndof", this.wRetirementStudio.wValuation_TheEndof.rd, dic["ValuationDateAccrued_TheEndof"], 0);
                _gLib._SetSyncUDWin("Testing_AveragePayDefinition", this.wRetirementStudio.wTesting_AveragePay.cbo, dic["Testing_AveragePayDefinition"], 0);
                _gLib._SetSyncUDWin("Testing_UseCurrentPay", this.wRetirementStudio.wTesting_Usecurrentpayforcurr.chx, dic["Testing_UseCurrentPay"], 0);
                _gLib._SetSyncUDWin("DBTestingService_Service", this.wRetirementStudio.wDB_Service.cbo, dic["DBTestingService_Service"], 0);
                _gLib._SetSyncUDWin("PermittedDisparity_SocialSecurityConvered", this.wRetirementStudio.wPermitted_SocialSecurityCovered.cbo, dic["PermittedDisparity_SocialSecurityConvered"], 0);
                _gLib._SetSyncUDWin("PermittedDisparity_FreshStartService", this.wRetirementStudio.wPermitted_FreshStartServ.cbo, dic["PermittedDisparity_FreshStartService"], 0);
                _gLib._SetSyncUDWin("PermittedDisparity_UseFixedPercentage_rd", this.wRetirementStudio.wPermittedDis_UseFixedPer_rd.rd, dic["PermittedDisparity_UseFixedPercentage_rd"], 0);
                _gLib._SendKeysUDWin("PermittedDisparity_UseFixedPercentage_txt", this.wRetirementStudio.wPermittedDis_UseFixedPer_txt.wTxt, dic["PermittedDisparity_UseFixedPercentage_txt"], 0);
                ////////_gLib._SetSyncUDWin_ByClipboard("PermittedDisparity_UseFixedPercentage_txt", this.wRetirementStudio.wPermittedDis_UseFixedPer_txt.UINudUseFixedPercentagEdit.UINudUseFixedPercentagEdit1, dic["PermittedDisparity_UseFixedPercentage_txt"], 0);
               _gLib._SetSyncUDWin("IncludedefinedContribution_401kmAnnualAddition", this.wRetirementStudio.wInclude_401KAnnualAddition.cbo, dic["IncludedefinedContribution_401kmAnnualAddition"], 0);
                _gLib._SetSyncUDWin("IncludedefinedContribution_401kmBalance", this.wRetirementStudio.wInclude_401KBalance.cbo, dic["IncludedefinedContribution_401kmBalance"], 0);
                _gLib._SetSyncUDWin("IncludedefinedContribution_401kmService", this.wRetirementStudio.wInclude_401KService.cbo, dic["IncludedefinedContribution_401kmService"], 0);
                _gLib._SetSyncUDWin("IncludedefinedContribution_Non401kmAnnualAddition", this.wRetirementStudio.wInclude_Non401KAnnualAddintion.cbo, dic["IncludedefinedContribution_Non401kmAnnualAddition"], 0);
                _gLib._SetSyncUDWin("IncludedefinedContribution_Non401kmBalance", this.wRetirementStudio.wInclude_Non401KBalance.cbo, dic["IncludedefinedContribution_Non401kmBalance"], 0);
                _gLib._SetSyncUDWin("IncludedefinedContribution_Non401kmService", this.wRetirementStudio.wInclude_Non401KService.cbo, dic["IncludedefinedContribution_Non401kmService"], 0);

                _gLib._SetSyncUDWin("TestingBasis_BenefitBasis", this.wRetirementStudio.wTestingBasis_BenefitBasis.rd, dic["TestingBasis_BenefitBasis"], 0);
                _gLib._SetSyncUDWin("TestingBasis_ContributionBasis", this.wRetirementStudio.wTestingBasis_ContributionBasis.rd, dic["TestingBasis_ContributionBasis"], 0);
                _gLib._SetSyncUDWin("ForRatioPercentageTest_IncludeDB", this.wRetirementStudio.wIncludeDBBenefits.chk, dic["ForRatioPercentageTest_IncludeDB"], 0);
                _gLib._SetSyncUDWin("ForRatioPercentageTest_IncludeDC", this.wRetirementStudio.wIncludeDCBenefits.chk, dic["ForRatioPercentageTest_IncludeDC"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-June-2
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// pMethods._ResultsForStatisticsForExpected_Grid(1, "AccruedBenefit", true);
        /// pMethods._ResultsForStatisticsForExpected_Grid(2, "PayAverage1", true);
        /// pMethods._ResultsForStatisticsForExpected_Grid(3, "VestingService", true);
        ///
        /// pMethods._ResultsForStatisticsForExpected_Grid(1, "AccruedBenefit", false);
        /// pMethods._ResultsForStatisticsForExpected_Grid(2, "PayAverage1", false);
        /// pMethods._ResultsForStatisticsForExpected_Grid(3, "VestingService", false);
        /// </summary>
        /// <param name=""></param>
        public void _ResultsForStatisticsForExpected_Grid(int iRow, string sItemName, Boolean bFunding)
        {
            string sFunctionName = "_ResultsForStatisticsForExpected_Grid";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            // initialize the grid
            try
            {
                this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid.SetFocus();
            }
            catch (Exception ex)
            {
                _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set focus on <ResultsForStatisticsForExpected_Grid> Because exception threw out: " + Environment.NewLine + ex.Message);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set focus on <ResultsForStatisticsForExpected_Grid>. Because exception threw out: " + Environment.NewLine + ex.Message);

            }
            Rectangle rect = this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid.BoundingRectangle;

            int iClickX = rect.Width / 2;
            int iClickY = (iRow - 1) * rect.Height / 3 + rect.Height / 6;

            ////////////Mouse.Click(this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid, new Point(iClickX, iClickY));
            _gLib._SetSyncUDWin("ResultsForStatisticsForExpected_Grid", this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid, "Click", 0, false, iClickX, iClickY);


            string sCharToSend = sItemName.Substring(0, 1);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid, sCharToSend);
            _gLib._SendKeysUDWin("ResultsForStatisticsForExpected_Grid", this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid, sCharToSend);

            this.wRetirementStudio.wCommonComboBox_FPGrid.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            if (bFunding)
                this.wRetirementStudio.wCommonComboBox_FPGrid.SearchProperties.Add(WinWindow.PropertyNames.Instance, "3");
            else
                this.wRetirementStudio.wCommonComboBox_FPGrid.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");

            //Mouse.Click(this.wRetirementStudio.wCommonComboBox.cbo, new Point(20, 5));
            _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommonComboBox_FPGrid.cbo, sItemName, 0);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid, "{Enter}");
            _gLib._SendKeysUDWin("ResultsForStatisticsForExpected_Grid", this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid, "{Enter}");



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-June-2
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// pMethods._ResultsForStatisticsForExpected_Grid_IR(1, "AverageSalary");
        /// pMethods._ResultsForStatisticsForExpected_Grid_IR(2, "TotalService");
        /// </summary>
        /// <param name=""></param>
        public void _ResultsForStatisticsForExpected_Grid_IR(int iRow, string sItemName)
        {
            string sFunctionName = "_ResultsForStatisticsForExpected_Grid_IR";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            // initialize the grid
            this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid_IR.SetFocus();

            Rectangle rect = this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid_IR.BoundingRectangle;

            int iClickX = rect.Width / 2;
            int iClickY = (iRow - 1) * rect.Height / 3 + rect.Height / 6;

            _gLib._SetSyncUDWin("ResultsForStatisticsForExpected_Grid", this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid_IR, "Click", 0, false, iClickX, iClickY);


            string sCharToSend = sItemName.Substring(0, 1);
            _gLib._SendKeysUDWin("ResultsForStatisticsForExpected_Grid", this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid_IR, sCharToSend);

            this.wRetirementStudio.wCommonComboBox_FPGrid.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);

            this.wRetirementStudio.wCommonComboBox_FPGrid.SearchProperties.Add(WinWindow.PropertyNames.Instance, "5");



            //Mouse.Click(this.wRetirementStudio.wCommonComboBox.cbo, new Point(20, 5));
            _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommonComboBox_FPGrid.cbo, sItemName, 0);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid, "{Enter}");
            _gLib._SendKeysUDWin("ResultsForStatisticsForExpected_Grid", this.wRetirementStudio.wResultsForStatisticsForExpected_Grid.grid_IR, "{Enter}");



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-29
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("Description", "Accrued Benefit");
        ///    dic.Add("Variable", "AccruedBenefit");
        ///    dic.Add("Age_cbo", "$ValAge");
        ///    dic.Add("Age_txt", "");
        ///    dic.Add("bFunding", "True");
        ///    pMethods._AdditionalValuesToOutput_Grid(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("iRow", "3");
        ///    dic.Add("Description", "Accrued Benefit");
        ///    dic.Add("Variable", "AccruedBenefit");
        ///    dic.Add("Age_cbo", "");
        ///    dic.Add("Age_txt", "65");
        ///    dic.Add("bFunding", "False");
        ///    pMethods._AdditionalValuesToOutput_Grid(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _AdditionalValuesToOutput_Grid(MyDictionary dic)
        {
            string sFunctionName = "_AdditionalValuesToOutput_Grid";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Boolean bFunding = true;

            if (dic["bFunding"].ToUpper() == "FALSE")
                bFunding = false;



            // initialize the grid
            ////////////Mouse.Click(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, new Point(85, 29));
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{PageUp}");
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Home}");
            _gLib._SetSyncUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "Click", 0, false, 85, 29);
            _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{PageUp}{Home}");

            int iRow = Convert.ToInt32(dic["iRow"]);

            string sKeys = "";
            for (int i = 1; i < iRow; i++)
                sKeys = sKeys + "{Down}";
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, sKeys);
            _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, sKeys);


            if (dic["Description"] != "")
            {
                string sCharToSend = dic["Description"].Substring(0, 1);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, dic["Description"]);
                _gLib._SendKeysUDWin("Description", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, dic["Description"]);
                _gLib._VerifySyncUDWin("Description", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["Description"], 0);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Enter}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Home}");
                _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Enter}{Home}");
            }
            if (dic["Variable"] != "")
            {

                string sCharToSend = dic["Variable"].Substring(0, 1);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Home}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Right}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, sCharToSend);
                _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Home}{Right}");
                _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, sCharToSend);

                //try
                //{
                if (bFunding)
                    this.wRetirementStudio.wCommonComboBox_FPGrid.SearchProperties.Add(WinWindow.PropertyNames.Instance, "1");
                else
                    this.wRetirementStudio.wCommonComboBox_FPGrid.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");

                _gLib._SetSyncUDWin("Variable", this.wRetirementStudio.wCommonComboBox_FPGrid.cbo, dic["Variable"], 0);
                //}
                //catch (Exception ex)
                //{
                //    _gLib._MsgBoxYesNo("VSTS Sucks?", "Please check 'Variable' column at row <" + dic["iRow"] + ">, it should be <" + dic["Variable"] + "> !" + Environment.NewLine + Environment.NewLine + "Click OK to keep testing if the value is correct or Manually correct it and click OK to keep testing.");
                //}

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Enter}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Home}");
                ////////////_gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Enter}{Home}");
            }

            if (dic["Age_cbo"] != "")
            {
                string sCharToSend = dic["Age_cbo"].Substring(0, 1);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{End}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, sCharToSend);
                _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{End}");
                _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, sCharToSend);

                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wCommonVIcon.btnV, "Click", 0);
                _gLib._SetSyncUDWin("Age_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["Age_cbo"], 0);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Tab}{Tab}{Tab}{Tab}");
            }
            if (dic["Age_txt"] != "")
            {
                string sCharToSend = dic["Age_txt"].Substring(0, 1);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{End}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, sCharToSend);
                _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{End}");
                _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, sCharToSend);

                _gLib._SetSyncUDWin("C", this.wRetirementStudio.wCommonCIcon.btnC, "Click", 0);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, dic["Age_txt"]);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Tab}", ModifierKeys.Shift);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Tab}");
                _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, dic["Age_txt"]);
                _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                _gLib._SendKeysUDWin("AdditionalValuesToBeOutput_Grid", this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid, "{Tab}");

                string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wAdditionalValuesToBeOutput_Grid.grid);

                if (sAct != dic["Age_txt"] + "/0")
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  set Age value <" + dic["Age_txt"] + ">. Actual value: <" + sAct.Substring(0, sAct.Length - 2) + ">");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  set Age value <" + dic["Age_txt"] + ">. Actual value: <" + sAct.Substring(0, sAct.Length - 2) + ">");
                }
                //_gLib._VerifySyncUDWin("Age_txt", this.wRetirementStudio.wCommonTXT.txt, dic["Age_txt"], 0);
                //Keyboard.SendKeys(this.wRetirementStudio.wMethods_AdditionalValuesToBeOutput_Grid.grid, "{Tab}{Tab}{Tab}{Tab}");
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-June-1
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CostMethod", "");
        ///    dic.Add("ServiceForServiceProrate", "");
        ///    dic.Add("CompareToAccrue", "");
        ///    dic.Add("AllowNegativeNormalCost", "");
        ///    dic.Add("ProjectedpayToUse", "");
        ///    dic.Add("ProjectedpayToUse_CA", "");
        ///    dic.Add("AccumulationToUse", "");
        ///    dic.Add("IncludeExitYearValue", "");
        ///    dic.Add("CalculatePresentValueOfFuture", "");
        ///    dic.Add("CalculatePresentValueOfFuture_txt", "");
        ///    dic.Add("VestingToUseForAgeFirstVested", "");
        ///    dic.Add("AverageWorkingLifeTime", "");
        ///    dic.Add("AverageLifeTime", "");
        ///    dic.Add("AverageWorkingLifeTimeToVesting", "");
        ///    dic.Add("AverageWorkingLifeTimeForBenefitingEE", "");
        ///    pMethods._PopVerify_Methods_Accounting(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Methods_Accounting(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_Methods_Accounting";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("CostMethod", this.wRetirementStudio.wCostMethod.cboCostMethod, dic["CostMethod"], 0);
                _gLib._SetSyncUDWin("ServiceForServiceProrate", this.wRetirementStudio.wServiceForServiceProrate.cboServiceForServiceProrate, dic["ServiceForServiceProrate"], 0);
                _gLib._SetSyncUDWin("CompareToAccrue", this.wRetirementStudio.wCompareToAccrued.chkCompareToAccrued, dic["CompareToAccrue"], 0);
                _gLib._SetSyncUDWin("AllowNegativeNormalCost", this.wRetirementStudio.wAllowNegativeNormalCost.chkAllowNegativeNormalCost, dic["AllowNegativeNormalCost"], 0);

                _gLib._SetSyncUDWin("ProjectedpayToUse", this.wRetirementStudio.wAcc_AdditionalCalRequest_ProjectedPayToUse.cboProjectedpayToUse, dic["ProjectedpayToUse"], 0);
                _gLib._SetSyncUDWin("ProjectedpayToUse_CA", this.wRetirementStudio.wProjectedPayToUseForCoveredPay.cboCA, dic["ProjectedpayToUse_CA"], 0);
                _gLib._SetSyncUDWin("AccumulationToUse", this.wRetirementStudio.wAcc_AdditionalCalRequest_AccumulationToUse.cboAccumulationToUse, dic["AccumulationToUse"], 0);
                _gLib._SetSyncUDWin("IncludeExitYearValue", this.wRetirementStudio.wAcc_AdditionalCalRequest_IncludeExitYearValue.chkIncludeExitYearValue, dic["IncludeExitYearValue"], 0);
                _gLib._SetSyncUDWin("CalculatePresentValueOfFuture", this.wRetirementStudio.wCalculatePresentValueOfFuture.chkCalculatePresentValueOfFuture, dic["CalculatePresentValueOfFuture"], 0);
                _gLib._SetSyncUDWin("CalculatePresentValueOfFuture_txt", this.wRetirementStudio.wCalculatePresentValueOfFuture_txt.txtCalculatePresentValueOfFuture, dic["CalculatePresentValueOfFuture_txt"], 0);
                _gLib._SetSyncUDWin("VestingToUseForAgeFirstVested", this.wRetirementStudio.wAcc_VestingToUseForAgeFirstVested.cboAcc_VestingToUseForAgeFirstVested, dic["VestingToUseForAgeFirstVested"], 0);
                _gLib._SetSyncUDWin("AverageWorkingLifeTime", this.wRetirementStudio.wAcc_AverageWorkingLifeTime.chkAcc_AverageWorkingLifeTime, dic["AverageWorkingLifeTime"], 0);
                _gLib._SetSyncUDWin("AverageLifeTime", this.wRetirementStudio.wAcc_AverageLifeTime.chkAcc_AverageLifeTime, dic["AverageLifeTime"], 0);
                _gLib._SetSyncUDWin("AverageWorkingLifeTimeToVesting", this.wRetirementStudio.wAcc_AverageWorkingLifeTimeToVesting.chkAcc_AverageWorkingLifeTimeToVesting, dic["AverageWorkingLifeTimeToVesting"], 0);
                _gLib._SetSyncUDWin("AverageWorkingLifeTimeForBenefitingEE", this.wRetirementStudio.wAcc_AverageWorkingLifeTimeForBenefitingEE.chkAcc_AverageWorkingLifeTimeForBenefitingEE, dic["AverageWorkingLifeTimeForBenefitingEE"], 0);


            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("CostMethod", this.wRetirementStudio.wCostMethod.cboCostMethod, dic["CostMethod"], 0);
                _gLib._VerifySyncUDWin("ServiceForServiceProrate", this.wRetirementStudio.wServiceForServiceProrate.cboServiceForServiceProrate, dic["ServiceForServiceProrate"], 0);
                _gLib._VerifySyncUDWin("CompareToAccrue", this.wRetirementStudio.wCompareToAccrued.chkCompareToAccrued, dic["CompareToAccrue"], 0);
                _gLib._VerifySyncUDWin("AllowNegativeNormalCost", this.wRetirementStudio.wAllowNegativeNormalCost.chkAllowNegativeNormalCost, dic["AllowNegativeNormalCost"], 0);

                _gLib._VerifySyncUDWin("ProjectedpayToUse", this.wRetirementStudio.wAcc_AdditionalCalRequest_ProjectedPayToUse.cboProjectedpayToUse, dic["ProjectedpayToUse"], 0);
                _gLib._VerifySyncUDWin("AccumulationToUse", this.wRetirementStudio.wAcc_AdditionalCalRequest_AccumulationToUse.cboAccumulationToUse, dic["AccumulationToUse"], 0);
                _gLib._VerifySyncUDWin("IncludeExitYearValue", this.wRetirementStudio.wAcc_AdditionalCalRequest_IncludeExitYearValue.chkIncludeExitYearValue, dic["IncludeExitYearValue"], 0);
                _gLib._VerifySyncUDWin("CalculatePresentValueOfFuture", this.wRetirementStudio.wCalculatePresentValueOfFuture.chkCalculatePresentValueOfFuture, dic["CalculatePresentValueOfFuture"], 0);
                _gLib._VerifySyncUDWin("CalculatePresentValueOfFuture_txt", this.wRetirementStudio.wCalculatePresentValueOfFuture_txt.txtCalculatePresentValueOfFuture, dic["CalculatePresentValueOfFuture_txt"], 0);
                _gLib._VerifySyncUDWin("VestingToUseForAgeFirstVested", this.wRetirementStudio.wAcc_VestingToUseForAgeFirstVested.cboAcc_VestingToUseForAgeFirstVested, dic["VestingToUseForAgeFirstVested"], 0);
                _gLib._VerifySyncUDWin("AverageWorkingLifeTime", this.wRetirementStudio.wAcc_AverageWorkingLifeTime.chkAcc_AverageWorkingLifeTime, dic["AverageWorkingLifeTime"], 0);
                _gLib._VerifySyncUDWin("AverageLifeTime", this.wRetirementStudio.wAcc_AverageLifeTime.chkAcc_AverageLifeTime, dic["AverageLifeTime"], 0);
                _gLib._VerifySyncUDWin("AverageWorkingLifeTimeToVesting", this.wRetirementStudio.wAcc_AverageWorkingLifeTimeToVesting.chkAcc_AverageWorkingLifeTimeToVesting, dic["AverageWorkingLifeTimeToVesting"], 0);
                _gLib._VerifySyncUDWin("AverageWorkingLifeTimeForBenefitingEE", this.wRetirementStudio.wAcc_AverageWorkingLifeTimeForBenefitingEE.chkAcc_AverageWorkingLifeTimeForBenefitingEE, dic["AverageWorkingLifeTimeForBenefitingEE"], 0);


            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }
        

        /// <summary>
        /// 2013-June-1
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AllMeasurements", "");
        ///    dic.Add("Current", "");
        ///    dic.Add("CurrentAndPrior", "");
        ///    dic.Add("CurrentPriorAndFuture", "");
        ///    pMethods._PopVerify_Methods_Measurement(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Methods_Measurement(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_Methods_Accounting";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("AllMeasurements", this.wRetirementStudio.wMeasurement_Allmeasurements.UIAllmeasurementsCheckBox, dic["AllMeasurements"], 0);
                _gLib._SetSyncUDWin("Current", this.wRetirementStudio.wMeasurement_Current.UICurrentCheckBox, dic["Current"], 0);
                _gLib._SetSyncUDWin("CurrentAndPrior", this.wRetirementStudio.wMeasurement_Currentandprio.UICurrentandpriorCheckBox, dic["CurrentAndPrior"], 0);
                _gLib._SetSyncUDWin("CurrentPriorAndFuture", this.wRetirementStudio.wMeasurement_Currentpriorandfutu.UICurrentpriorandfuturCheckBox, dic["CurrentPriorAndFuture"], 0);
           
            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("CostMethod", this.wRetirementStudio.wCostMethod.cboCostMethod, dic["CostMethod"], 0);
              
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        
        public void _SelectTab(string sTabName)
        {
            string sFunctionName = "_SelectTab";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TabPageSelectWin(sTabName, this.wRetirementStudio.wTab, 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Apr-13
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CostMethod", "");
        ///    dic.Add("ServiceForServiceProrate", "");
        ///    dic.Add("CompareToAccrue", "");
        ///    dic.Add("AllowNegativeNormalCost", "");
        ///    dic.Add("NormalCostForCYTermination", "");
        ///    dic.Add("GrowIn_Age", "");
        ///    dic.Add("GrowIn_Service", "");
        ///    dic.Add("MaxValue_StartAge", "");
        ///    dic.Add("MaxValue_StopAge", "");
        ///    pMethods._PopVerify_Methods_CA(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Methods_CA(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_Methods_CA";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("CostMethod", this.wRetirementStudio.wCostMethod.cboCostMethod, dic["CostMethod"], 0);
                _gLib._SetSyncUDWin("ServiceForServiceProrate", this.wRetirementStudio.wServiceForServiceProrate.cboServiceForServiceProrate, dic["ServiceForServiceProrate"], 0);
                _gLib._SetSyncUDWin("CompareToAccrue", this.wRetirementStudio.wCompareToAccrued.chkCompareToAccrued, dic["CompareToAccrue"], 0);
                _gLib._SetSyncUDWin("AllowNegativeNormalCost", this.wRetirementStudio.wAllowNegativeNormalCost.chkAllowNegativeNormalCost, dic["AllowNegativeNormalCost"], 0);
                _gLib._SetSyncUDWin("NormalCostForCYTermination", this.wRetirementStudio.wNormalCostForCYTermination_CA.cbo, dic["NormalCostForCYTermination"], 0);
                _gLib._SetSyncUDWin("GrowIn_Age", this.wRetirementStudio.wGrowIn_Age_CA.cbo, dic["GrowIn_Age"], 0);
                _gLib._SetSyncUDWin("GrowIn_Service", this.wRetirementStudio.wGrowIn_Service_CA.cbo, dic["GrowIn_Service"], 0);
                _gLib._SetSyncUDWin("MaxValue_StartAge", this.wRetirementStudio.wMaxValue_StartAge_CA.cbo, dic["MaxValue_StartAge"], 0);
                _gLib._SetSyncUDWin("MaxValue_StopAge", this.wRetirementStudio.wMaxValue_StopAge_CA.cbo, dic["MaxValue_StopAge"], 0);

                _gLib._SetSyncUDWin("ProjectedPayToUseForCoveredPay", this.wRetirementStudio.wProjectedPayToUseForCoveredPay.cboProjectedPayToUseForCoveredPay, dic["ProjectedPayToUseForCoveredPay"], 0);
                _gLib._SetSyncUDWin("AccumulationToUseForExepctedPVOfEmployee", this.wRetirementStudio.wAccumulationToUseForExpected.cboAccumulationToUseForExpected, dic["AccumulationToUseForExepctedPVOfEmployee"], 0);
                _gLib._SetSyncUDWin("IncludeChangesInPVFutureEEGainLoss", this.wRetirementStudio.wIncludeChangesInPVFutureEEGainLoss_CA.chk, dic["IncludeChangesInPVFutureEEGainLoss"], 0);
                _gLib._SetSyncUDWin("AccumulationToUseForExepctedPVOfEmployer", this.wRetirementStudio.wAccumulationToUseForExepctedPVOfEmployer_CA.cbo, dic["AccumulationToUseForExepctedPVOfEmployer"], 0);
                _gLib._SetSyncUDWin("BeginningOfTheYearPVFuture", this.wRetirementStudio.wBeginningOfTheYearPVFuture.chkBeginningOfTheYearPVFuture, dic["BeginningOfTheYearPVFuture"], 0);


            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-May-29
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("sName", "PV87to99Ret");
        ///    dic.Add("sStatus", "False");
        ///    pMethods._BenefitsToInclude_GoingConcern(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _BenefitsToInclude_GoingConcern(MyDictionary dic)
        {

            string sFunctionName = "_BenefitsToInclude_GoingConcern";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");
            //_fp._ClickFirstRow(this.wRetirementStudio.wBenefitsToInclude_FPGrid_GoingConcern.grid, 126, 55);
            _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wBenefitsToInclude_FPGrid_GoingConcern.grid, "Click", 0, false, 126, 55);
            _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToInclude_FPGrid_GoingConcern.grid, "{tab}{down}{PgUp}{PgUp}{PgUp}{PgUp}{PgUp}");

            string sDown = "";
            string sActStatus = "";
            for (int i = 1; i < Convert.ToInt32(dic["iRow"]); i++)
                sDown = sDown + "{Down}";

            _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToInclude_FPGrid_GoingConcern.grid, sDown);

            sActStatus = _fp._ReturnSelectRowContent(this.wRetirementStudio.wBenefitsToInclude_FPGrid_GoingConcern.grid);
            if (!sActStatus.ToLower().Equals(dic["sStatus"].ToLower()))
            {
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToInclude_FPGrid_GoingConcern.grid, "{Space}{Space}");
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToInclude_FPGrid_GoingConcern.grid, "{Right}");
                sActStatus = _fp._ReturnSelectRowContent(this.wRetirementStudio.wBenefitsToInclude_FPGrid_GoingConcern.grid);
              
                ////////// check and do it again, to make sure it's setting correct.
                if (!sActStatus.ToLower().Equals(dic["sStatus"].ToLower()))
                {
                    _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToInclude_FPGrid_GoingConcern.grid, "{Space}{Space}{Space}");
                    _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToInclude_FPGrid_GoingConcern.grid, "{Right}");
                    sActStatus = _fp._ReturnSelectRowContent(this.wRetirementStudio.wBenefitsToInclude_FPGrid_GoingConcern.grid);
                }
              
                if (!sActStatus.ToLower().Equals(dic["sStatus"].ToLower()))
                {
                    _gLib._MsgBoxYesNo("Continue Testing?", "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sStatus"] + ">.");
                    _gLib._Report(_PassFailStep.Fail, "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sStatus"] + ">.");
                }

            }
            else
                _gLib._Report(_PassFailStep.Pass, "Successfully  set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sStatus"] + ">.");

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }
        

        /// <summary>
        /// 2015-May-29
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CostMethod", "");
        ///    dic.Add("ServiceForServiceProrate", "");
        ///    dic.Add("CompareToAccrue", "");
        ///    dic.Add("AllowNegativeNormalCost", "");
        ///    dic.Add("NormalCostForCYTermination", "");
        ///    dic.Add("NormalCostForCYTermination_UK", "");
        ///    dic.Add("ProjectedPayToUseForCoveredPay", "");
        ///    dic.Add("AccumulationToUseForExepctedPVOfEmployee", "");
        ///    dic.Add("IncludeChangesInPVFutureEEGainLoss", "");
        ///    dic.Add("AccumulationToUseForExepctedPVOfEmployer", "");
        ///    dic.Add("BeginningOfTheYearPVFuture", "");
        ///    dic.Add("StopPVFuture_V", "");
        ///    dic.Add("StopPVFuture_cbo", "");
        ///    pMethods._PopVerify_Methods_Funding_GoningConcern(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Methods_Funding_GoningConcern(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_Methods_Funding_GoningConcern";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("CostMethod", this.wRetirementStudio.wCostMethod.cboCostMethod, dic["CostMethod"], 0);
                _gLib._SetSyncUDWin("ServiceForServiceProrate", this.wRetirementStudio.wServiceForServiceProrate.cboServiceForServiceProrate, dic["ServiceForServiceProrate"], 0);
                _gLib._SetSyncUDWin("CompareToAccrue", this.wRetirementStudio.wCompareToAccrued.chkCompareToAccrued, dic["CompareToAccrue"], 0);
                _gLib._SetSyncUDWin("AllowNegativeNormalCost", this.wRetirementStudio.wAllowNegativeNormalCost.chkAllowNegativeNormalCost, dic["AllowNegativeNormalCost"], 0);
                _gLib._SetSyncUDWin("NormalCostForCYTermination", this.wRetirementStudio.wNormalCostForCYTermination_CA.cbo, dic["NormalCostForCYTermination"], 0);
                _gLib._SetSyncUDWin("NormalCostForCYTermination_UK", this.wRetirementStudio.wNormalCostforCY_UK.chk, dic["NormalCostForCYTermination_UK"], 0);


                ////////_gLib._SetSyncUDWin("VerticalScrollBar", this.wRetirementStudio.wScrollBar_CA.wVerticalScrollBar.btnDown, "Click", 0);
                _gLib._SetSyncUDWin("ProjectedPayToUseForCoveredPay", this.wRetirementStudio.wProjectedPayToUseForCoveredPay.cboCA, dic["ProjectedPayToUseForCoveredPay"], 0);
                _gLib._SetSyncUDWin("AccumulationToUseForExepctedPVOfEmployee", this.wRetirementStudio.wAccumulationToUseForExpected.cboAccumulationToUseForExpected, dic["AccumulationToUseForExepctedPVOfEmployee"], 0);
                _gLib._SetSyncUDWin("IncludeChangesInPVFutureEEGainLoss", this.wRetirementStudio.wIncludeChangesInPVFutureEEGainLoss_CA.chk, dic["IncludeChangesInPVFutureEEGainLoss"], 0);
                _gLib._SetSyncUDWin("AccumulationToUseForExepctedPVOfEmployer", this.wRetirementStudio.wAccumulationToUseForExepctedPVOfEmployer_CA.cbo, dic["AccumulationToUseForExepctedPVOfEmployer"], 0);
                _gLib._SetSyncUDWin("BeginningOfTheYearPVFuture", this.wRetirementStudio.wBeginningOfTheYearPVFuture.chkBeginningOfTheYearPVFuture, dic["BeginningOfTheYearPVFuture"], 0);

                _gLib._SetSyncUDWin("StopPVFuture_V", this.wRetirementStudio.wStopPVFuture_VIcon.btnStopPVFuture_V, dic["StopPVFuture_V"], 0);
                _gLib._SetSyncUDWin("StopPVFuture_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["StopPVFuture_cbo"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-May-29
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CalculateGrowInAndMax", "");
        ///    dic.Add("CalculateMax", "");
        ///    dic.Add("NoGrowInOrMax", "");
        ///    dic.Add("Age", "");
        ///    dic.Add("Service", "");
        ///    dic.Add("AddtionalEligibilityCondition", "");
        ///    dic.Add("StartAge", "");
        ///    dic.Add("StopAge", "");
        ///    dic.Add("PerformMaximumValueTest", "");
        ///    dic.Add("AdditionalOptionForExcessContribution", "");
        ///    dic.Add("NumOfYearsIncrementalCost", "");
        ///    dic.Add("AdditionalElibilityFor10Years", "");
        ///    pMethods._PopVerify_Methods_Funding_SolvencyWindUp(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Methods_Funding_SolvencyWindUp(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_Methods_Funding_SolvencyWindUp";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("CalculateGrowInAndMax", this.wRetirementStudio.wCalculateGrowInAndMax_CA.rd, dic["CalculateGrowInAndMax"], 0);
                _gLib._SetSyncUDWin("CalculateMax", this.wRetirementStudio.wCalculateMax_CA.rd, dic["CalculateMax"], 0);
                _gLib._SetSyncUDWin("NoGrowInOrMax", this.wRetirementStudio.wNoGrowInOrMax_CA.rd, dic["NoGrowInOrMax"], 0);

                _gLib._SetSyncUDWin("Age", this.wRetirementStudio.wGrowIn_Age_CA.cbo, dic["Age"], 0);
                _gLib._SetSyncUDWin("Service", this.wRetirementStudio.wGrowIn_Service_CA.cbo, dic["Service"], 0);
                _gLib._SetSyncUDWin("AddtionalEligibilityCondition", this.wRetirementStudio.wSolvency_AddtionalEligibilityCondition.cbo, dic["AddtionalEligibilityCondition"], 0);
                _gLib._SetSyncUDWin("StartAge", this.wRetirementStudio.wMaxValue_StartAge_CA.cbo, dic["StartAge"], 0);
                _gLib._SetSyncUDWin("StopAge", this.wRetirementStudio.wMaxValue_StopAge_CA.cbo, dic["StopAge"], 0);

                _gLib._SetSyncUDWin("PerformMaximumValueTest", this.wRetirementStudio.wSolvency_PerformMaximumValueTest.chk, dic["PerformMaximumValueTest"], 0);
                _gLib._SetSyncUDWin("AdditionalOptionForExcessContribution", this.wRetirementStudio.wSolvency_AdditionalOptionForExcessContribution.cbo, dic["AdditionalOptionForExcessContribution"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NumOfYearsIncrementalCost", this.wRetirementStudio.wSolvency_NumOfYearsIncrementalCost.txt, dic["NumOfYearsIncrementalCost"], true, 0);
                _gLib._SetSyncUDWin("AdditionalElibilityFor10Years", this.wRetirementStudio.wAdditional_EliigibilityWithin10Years.cbo, dic["AdditionalElibilityFor10Years"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }
        

        /// <summary>
        /// 2015-May-29
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("sName", "PV87to99Ret");
        ///    dic.Add("sBenefitForCalculation", "False");
        ///    dic.Add("sImmediateVesting", "False");
        ///    dic.Add("sCOLA", "False");
        ///    pMethods._BenefitsToValueForSolvency(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _BenefitsToValueForSolvency(MyDictionary dic)
        {

            string sFunctionName = "_BenefitsToValueForSolvency";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _fp._ClickFirstRow(this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid, 126, 55);
            _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid, "{Home}{PgUp}{PgUp}{PgUp}{PgUp}{PgUp}{PgUp}");

            string sDown = "";

            string sActStatus = "";
            for (int i = 1; i < Convert.ToInt32(dic["iRow"]); i++)
                sDown = sDown + "{Down}";

            _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid, sDown);

            if (dic["sBenefitForCalculation"] != "")
            {
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid, "{Home}");

                sActStatus = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid);
                if (!sActStatus.ToLower().Contains(dic["sBenefitForCalculation"].ToLower()))
                {
                    _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid, "{Space}{Space}");
                    //////////////_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid, "{Right}");
                    sActStatus = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid);
                    if (!sActStatus.ToLower().Contains(dic["sBenefitForCalculation"].ToLower()))
                    {
                        _gLib._MsgBoxYesNo("Continue Testing?", "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sBenefitForCalculation"] + ">.");
                        _gLib._Report(_PassFailStep.Fail, "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sBenefitForCalculation"] + ">.");
                    }

                }
                else
                    _gLib._Report(_PassFailStep.Pass, "Successfully  set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sBenefitForCalculation"] + ">.");
            }
            if (dic["sImmediateVesting"] != "")
            {
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid, "{Home}{Right}");

                sActStatus = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid);
                if (!sActStatus.ToLower().Contains(dic["sImmediateVesting"].ToLower()))
                {
                    _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid, "{Space}{Space}");
                    sActStatus = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid);
                    if (!sActStatus.ToLower().Contains(dic["sImmediateVesting"].ToLower()))
                    {
                        _gLib._MsgBoxYesNo("Continue Testing?", "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sImmediateVesting"] + ">.");
                        _gLib._Report(_PassFailStep.Fail, "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sImmediateVesting"] + ">.");
                    }

                }
                else
                    _gLib._Report(_PassFailStep.Pass, "Successfully  set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sImmediateVesting"] + ">.");
            }

            if (dic["sCOLA"] != "")
            {
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid, "{End}");

                sActStatus = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid);
                if (!sActStatus.ToLower().Contains(dic["sCOLA"].ToLower()))
                {
                    _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid, "{Space}{Space}");
                    sActStatus = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid);
                    if (!sActStatus.ToLower().Contains(dic["sCOLA"].ToLower()))
                    {
                        _gLib._MsgBoxYesNo("Continue Testing?", "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sCOLA"] + ">.");
                        _gLib._Report(_PassFailStep.Fail, "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sCOLA"] + ">.");
                    }

                }
                else
                    _gLib._Report(_PassFailStep.Pass, "Successfully  set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sCOLA"] + ">.");
            }
            _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForSolvency_FPGrid.grid, "{Home}");
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }
        

        /// <summary>
        /// 2015-May-29
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("sName", "PV87to99Ret");
        ///    dic.Add("sBenefitForCalculation", "False");
        ///    dic.Add("sImmediateVesting", "False");
        ///    dic.Add("sCOLA", "False");
        ///    pMethods._BenefitsToValueForWindUp(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _BenefitsToValueForWindUp(MyDictionary dic)
        {

            string sFunctionName = "_BenefitsToValueForWindUp";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _fp._ClickFirstRow(this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid, 126, 55);
            _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid, "{Home}{PgUp}{PgUp}{PgUp}{PgUp}{PgUp}{PgUp}");

            string sDown = "";

            string sActStatus = "";
            for (int i = 1; i < Convert.ToInt32(dic["iRow"]); i++)
                sDown = sDown + "{Down}";

            _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid, sDown);

            if (dic["sBenefitForCalculation"] != "")
            {
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid, "{Home}");

                sActStatus = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid);
                if (!sActStatus.ToLower().Contains(dic["sBenefitForCalculation"].ToLower()))
                {
                    _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid, "{Space}{Space}");
                    //////////////_gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid, "{Right}");
                    sActStatus = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid);
                    if (!sActStatus.ToLower().Contains(dic["sBenefitForCalculation"].ToLower()))
                    {
                        _gLib._MsgBoxYesNo("Continue Testing?", "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sBenefitForCalculation"] + ">.");
                        _gLib._Report(_PassFailStep.Fail, "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sBenefitForCalculation"] + ">.");
                    }

                }
                else
                    _gLib._Report(_PassFailStep.Pass, "Successfully  set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sBenefitForCalculation"] + ">.");
            }
            if (dic["sImmediateVesting"] != "")
            {
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid, "{Home}{Right}");

                sActStatus = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid);
                if (!sActStatus.ToLower().Contains(dic["sImmediateVesting"].ToLower()))
                {
                    _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid, "{Space}{Space}");
                    sActStatus = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid);
                    if (!sActStatus.ToLower().Contains(dic["sImmediateVesting"].ToLower()))
                    {
                        _gLib._MsgBoxYesNo("Continue Testing?", "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sImmediateVesting"] + ">.");
                        _gLib._Report(_PassFailStep.Fail, "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sImmediateVesting"] + ">.");
                    }

                }
                else
                    _gLib._Report(_PassFailStep.Pass, "Successfully  set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sImmediateVesting"] + ">.");
            }

            if (dic["sCOLA"] != "")
            {
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid, "{End}");

                sActStatus = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid);
                if (!sActStatus.ToLower().Contains(dic["sCOLA"].ToLower()))
                {
                    _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid, "{Space}{Space}");
                    sActStatus = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid);
                    if (!sActStatus.ToLower().Contains(dic["sCOLA"].ToLower()))
                    {
                        _gLib._MsgBoxYesNo("Continue Testing?", "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sCOLA"] + ">.");
                        _gLib._Report(_PassFailStep.Fail, "Failed to set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sCOLA"] + ">.");
                    }

                }
                else
                    _gLib._Report(_PassFailStep.Pass, "Successfully  set <" + dic["sName"] + "> at row <" + dic["iRow"] + "> to <" + dic["sCOLA"] + ">.");
            }
            _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wBenefitsToValueForWindup_FPGrid.grid, "{Home}");
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }
        

        /// <summary>
        /// 2015-Dec-31
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AddRow", "click");
        ///    dic.Add("iRow", "");
        ///    dic.Add("BenefitDefinition", "");
        ///    dic.Add("PUCOverrides", "");
        ///    dic.Add("TUCOverrides", "");
        ///    dic.Add("ServiceForProrate", "True");
        ///    dic.Add("SpecialAttribute", "");
        ///    dic.Add("TransitionBalance", "");
        ///    dic.Add("WithInterest", "");
        ///    pMethods._MethodOverrieds_BenefitDefinition(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _MethodOverrieds_BenefitDefinition(MyDictionary dic)
        {
            string sFunctionName = "_MethodOverrieds_BenefitDefinition";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iRow = Convert.ToInt32(dic["iRow"]);
                string sBackTabs = "";

                for (int i = 1; i <= 50; i++)
                    sBackTabs = sBackTabs + "{tab}";
                    
                if (dic["AddRow"] != "")
                    _gLib._SetSyncUDWin("add row", this.wRetirementStudio.wAddRow_BenefitDefinition.btn, dic["AddRow"], 0);
             
                
                _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, sBackTabs, 0, ModifierKeys.Shift, false);
                _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "Click", 0, false, 50, 30);
                _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");
                _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}", 0, ModifierKeys.Shift, false);


                if (dic["BenefitDefinition"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");
                    }

                    string sChar = dic["BenefitDefinition"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, sChar);

                    _gLib._SetSyncUDWin("BenefitDefinition", this.wRetirementStudio.wItemCbo.cbo, dic["BenefitDefinition"], 0);
                }

                        
                if (dic["PUCOverrides"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");
                    } 
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");

                    string sChar = dic["PUCOverrides"].Substring(0, 1);
                    String sAct = "";

                    _gLib._SetSyncUDWin("PUCOverrides", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);


                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();
                       
                        if (dic["PUCOverrides"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set PUCOverrides to " + dic["PUCOverrides"]);
                    }
                }


                if (dic["TUCOverrides"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");
                    }
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}{Tab}");


                    string sChar = dic["TUCOverrides"].Substring(0, 1);
                    String sAct = "";


                    _gLib._SetSyncUDWin("TUCOverrides", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);

                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();

                        if (dic["TUCOverrides"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set TUCOverrides to " + dic["TUCOverrides"]);
                    }
                }


                if (dic["ServiceForProrate"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");
                    }
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}{Tab}{Tab}");

                    string sChar = dic["ServiceForProrate"].Substring(0, 1);
                    String sAct = "";


                    _gLib._SetSyncUDWin("TUCOverrides", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);

                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();

                        if (dic["ServiceForProrate"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set ServiceForProrate to " + dic["ServiceForProrate"]);
                    }
                }


                if (dic["SpecialAttribute"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");
                    }
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}{Tab}{Tab}{Tab}");

                    string sChar = dic["SpecialAttribute"].Substring(0, 1);
                    String sAct = "";


                    _gLib._SetSyncUDWin("SpecialAttribute", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);

                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();

                        if (dic["SpecialAttribute"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set SpecialAttribute to " + dic["SpecialAttribute"]);
                    }
                }

                if (dic["TransitionBalance"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");
                    }
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}");

                    string sChar = dic["TransitionBalance"].Substring(0, 1);
                    String sAct = "";


                    _gLib._SetSyncUDWin("TransitionBalance", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);

                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();

                        if (dic["TransitionBalance"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set TransitionBalance to " + dic["TransitionBalance"]);
                    }
                }

                if (dic["WithInterest"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");
                    }
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");

                    string sChar = dic["WithInterest"].Substring(0, 1);
                    String sAct = "";


                    _gLib._SetSyncUDWin("WithInterest", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);

                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();

                        if (dic["WithInterest"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set WithInterest to " + dic["WithInterest"]);
                    }
                }

                _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
            }

        }


        /// <summary>
        /// 2016-Jan-28
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AddRow", "click");
        ///    dic.Add("iRow", "");
        ///    dic.Add("BenefitDefinition", "");
        ///    dic.Add("PUCOverrides", "");
        ///    dic.Add("TUCOverrides", "");
        ///    dic.Add("ServiceForProrate", "True");
        ///    dic.Add("SpecialAttribute", "");
        ///    pMethods._MethodOverrieds_BenefitDefinition_NL(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _MethodOverrieds_BenefitDefinition_NL(MyDictionary dic)
        {
            string sFunctionName = "_MethodOverrieds_BenefitDefinition";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iRow = Convert.ToInt32(dic["iRow"]);
                string sBackTabs = "";

                for (int i = 1; i <= 50; i++)
                    sBackTabs = sBackTabs + "{tab}";

                if (dic["AddRow"] != "")
                    _gLib._SetSyncUDWin("add row", this.wRetirementStudio.wAddRow_BenefitDefinition.btn, dic["AddRow"], 0);


                _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, sBackTabs, 0, ModifierKeys.Shift, false);
                _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "Click", 0, false, 50, 30);
                _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}", 0, ModifierKeys.Shift, false);


                if (dic["BenefitDefinition"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}", 0 );
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");
                    }

                    string sChar = dic["BenefitDefinition"].Substring(0, 1);

                    if (sChar != "#")
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, sChar);
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, "A");   //// active the box when the value is first index.

                    _gLib._SetSyncUDWin("BenefitDefinition", this.wRetirementStudio.wCom_cbo_NL.cbo, dic["BenefitDefinition"], 0);
                }


                if (dic["PUCOverrides"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");
                    }
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");

                    string sChar = dic["PUCOverrides"].Substring(0, 1);

                    if (sChar != "#")
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, sChar);
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, "p");   //// active the box when the value is first index.

                    _gLib._SetSyncUDWin("PUCOverrides", this.wRetirementStudio.wCom_cbo_NL.cbo, dic["PUCOverrides"], 0);
                }


                if (dic["TUCOverrides"] != "")
                {
                    _gLib._MsgBox("", "function is not complete");

                }


                if (dic["ServiceForProrate"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid)) + 1)
                            break;
                      _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}");
                    }
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_BenefitDefinition.grid, "{Tab}{Tab}{Tab}");

                    string sChar = dic["ServiceForProrate"].Substring(0, 1);

                    if (sChar != "#")
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, sChar);
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, "p");   //// active the box when the value is first index.

                    _gLib._SetSyncUDWin("ServiceForProrate", this.wRetirementStudio.wCom_cbo_NL.cbo, dic["ServiceForProrate"], 0);

                }


                if (dic["SpecialAttribute"] != "")
                {
                    _gLib._MsgBox("", "function is not complete");
                    
                }

                if (dic["TransitionBalance"] != "")
                {
                    _gLib._MsgBox("", "function is not complete");

                }

                _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
            }

        }
  

        /// <summary>
        /// 2015-Dec-31
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AddRow", "click");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Formula", "");
        ///    dic.Add("PUCOverrides", "");
        ///    dic.Add("TUCOverrides", "");
        ///    dic.Add("ServiceForProrate", "");
        ///    dic.Add("SpecialAttribute", "");
        ///    dic.Add("TransitionBalance", "");
        ///    dic.Add("WithInterest", "");
        ///    pMethods._MethodOverrieds_Formula(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _MethodOverrieds_Formula(MyDictionary dic)
        {
            string sFunctionName = "_Table_InternationalAccounting";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iRow = Convert.ToInt32(dic["iRow"]);
                string sBackTabs = "";

                for (int i = 1; i <= 50; i++)
                    sBackTabs = sBackTabs + "{tab}";

               
                if (dic["AddRow"] != "")
                    _gLib._SetSyncUDWin("add row", this.wRetirementStudio.wAddRow_Formula.btn, dic["AddRow"], 0);

                _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");

                if (dic["Formula"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    }

                    string sChar = dic["Formula"].Substring(0, 1);
                    String sAct = "";

                    _gLib._SetSyncUDWin("Formula", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);

                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("Formula", this.wRetirementStudio.wMethodOverrides_Formula.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();

                        if (dic["Formula"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set Formula to " + dic["Formula"]);
                    }
                }

                        
                if (dic["PUCOverrides"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);

                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    } 
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");

                    string sChar = dic["PUCOverrides"].Substring(0, 1);
                    String sAct = "";

                    _gLib._SetSyncUDWin("PUCOverrides", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);

                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_Formula.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();

                        if (dic["PUCOverrides"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set PUCOverrides to " + dic["PUCOverrides"]);
                    }
                }


                if (dic["TUCOverrides"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);

                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    } 
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}");


                    string sChar = dic["TUCOverrides"].Substring(0, 1);
                    String sAct = "";


                    _gLib._SetSyncUDWin("TUCOverrides", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);

                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_Formula.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();

                        if (dic["TUCOverrides"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set TUCOverrides to " + dic["TUCOverrides"]);
                    }
                }


                if (dic["ServiceForProrate"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);

                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    } 
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}{Tab}");

                    string sChar = dic["ServiceForProrate"].Substring(0, 1);
                    String sAct = "";


                    _gLib._SetSyncUDWin("TUCOverrides", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);

                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_Formula.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();

                        if (dic["ServiceForProrate"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set ServiceForProrate to " + dic["ServiceForProrate"]);
                    }
                }


                if (dic["SpecialAttribute"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);

                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    } 
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}{Tab}{Tab}");

                    string sChar = dic["SpecialAttribute"].Substring(0, 1);
                    String sAct = "";


                    _gLib._SetSyncUDWin("SpecialAttribute", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);

                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_Formula.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();

                        if (dic["SpecialAttribute"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set SpecialAttribute to " + dic["SpecialAttribute"]);
                    }
                }

                if (dic["TransitionBalance"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);

                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    } 
                    
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}");

                    string sChar = dic["TransitionBalance"].Substring(0, 1);
                    String sAct = "";


                    _gLib._SetSyncUDWin("TransitionBalance", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);

                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_Formula.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();

                        if (dic["TransitionBalance"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set TransitionBalance to " + dic["TransitionBalance"]);
                    }
                }

                if (dic["WithInterest"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);

                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    }

                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");

                    string sChar = dic["WithInterest"].Substring(0, 1);
                    String sAct = "";


                    _gLib._SetSyncUDWin("WithInterest", this.wRetirementStudio.wItemCbo.cbo.item, "click", 0);

                    for (int i = 1; i <= 10; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides_Formula.grid, sChar);

                        sAct = this.wRetirementStudio.wItemCbo.cbo.item.DisplayText.Trim();

                        if (dic["WithInterest"] == sAct)
                            break;
                        if (i == 10)
                            _gLib._MsgBoxYesNo("", "cannot set TransitionBalance to " + dic["WithInterest"]);
                    }
                }

                _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
            }

        }


        /// <summary>
        /// 2015-Dec-31
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AddRow", "click");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Formula", "");
        ///    dic.Add("PUCOverrides", "");
        ///    dic.Add("TUCOverrides", "");
        ///    dic.Add("ServiceForProrate", "");
        ///    dic.Add("SpecialAttribute", "");
        ///    dic.Add("TransitionBalance", "");
        ///    dic.Add("WithInterest", "");
        ///    pMethods._MethodOverrieds_Formula_NL(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _MethodOverrieds_Formula_NL(MyDictionary dic)
        {
            string sFunctionName = "_MethodOverrieds_Formula_NL";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iRow = Convert.ToInt32(dic["iRow"]);
                string sBackTabs = "";

                for (int i = 1; i <= 50; i++)
                    sBackTabs = sBackTabs + "{tab}";


                if (dic["AddRow"] != "")
                    _gLib._SetSyncUDWin("add row", this.wRetirementStudio.wAddRow_Formula.btn, dic["AddRow"], 0);


                if (dic["Formula"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}", 0);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    }

                    string sChar = dic["Formula"].Substring(0, 1);

                    if (sChar != "#")
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, sChar);
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, "A");   //// active the box when the value is first index.

                    _gLib._SetSyncUDWin("Formula", this.wRetirementStudio.wCom_cbo_NL.cbo, dic["Formula"], 0);
                }


                if (dic["PUCOverrides"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    }
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");

                    string sChar = dic["PUCOverrides"].Substring(0, 1);

                    if (sChar != "#")
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, sChar);
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, "p");   //// active the box when the value is first index.

                    _gLib._SetSyncUDWin("PUCOverrides", this.wRetirementStudio.wCom_cbo_NL.cbo, dic["PUCOverrides"], 0);
                }


                if (dic["TUCOverrides"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    }
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}");

                    string sChar = dic["TUCOverrides"].Substring(0, 1);

                    if (sChar != "#")
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, sChar);
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, "p");   //// active the box when the value is first index.

                    _gLib._SetSyncUDWin("TUCOverrides", this.wRetirementStudio.wCom_cbo_NL.cbo, dic["TUCOverrides"], 0);
                }


                if (dic["ServiceForProrate"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    }

                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}{Tab}");


                    string sChar = dic["ServiceForProrate"].Substring(0, 1);

                    if (sChar != "#")
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, sChar);
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, "p");   //// active the box when the value is first index.

                    _gLib._SetSyncUDWin("ServiceForProrate", this.wRetirementStudio.wCom_cbo_NL.cbo, dic["ServiceForProrate"], 0);
                }

                if (dic["SpecialAttribute"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    }

                    if (dic["TUCOverrides"] != "")   // if TUCOverrides is not empty,  ServiceForProrate will be disable..
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}{Tab}{Tab}");
                    else
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}{Tab}");

                    string sChar = dic["SpecialAttribute"].Substring(0, 1);

                    if (sChar != "#")
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, sChar);
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, "p");   //// active the box when the value is first index.

                    _gLib._SetSyncUDWin("SpecialAttribute", this.wRetirementStudio.wCom_cbo_NL.cbo, dic["SpecialAttribute"], 0);
                }

                if (dic["TransitionBalance"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    }

                    if (dic["TUCOverrides"] != "")   // if TUCOverrides is not empty,  ServiceForProrate will be disable..
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}");
                    else
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}{Tab}{Tab}");

                    string sChar = dic["TransitionBalance"].Substring(0, 1);

                    if (sChar != "#")
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, sChar);
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, "p");   //// active the box when the value is first index.

                    _gLib._SetSyncUDWin("TransitionBalance", this.wRetirementStudio.wCom_cbo_NL.cbo, dic["TransitionBalance"], 0);
                }

                if (dic["WithInterest"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Home}", 0, ModifierKeys.Control, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides_Formula.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}");
                    }

                    if (dic["TUCOverrides"] != "")   // if TUCOverrides is not empty,  ServiceForProrate will be disable..
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                    else
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides_Formula.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}");


                    string sChar = dic["WithInterest"].Substring(0, 1);

                    if (sChar != "#")
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, sChar);
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCom_cbo_NL.cbo, "p");   //// active the box when the value is first index.

                    _gLib._SetSyncUDWin("WithInterest", this.wRetirementStudio.wCom_cbo_NL.cbo, dic["WithInterest"], 0);
                }

                _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
            }

        }

    }

  }


