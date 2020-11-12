namespace RetirementStudio._UIMaps.FundingInformation_ASOP51Classes
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



    public partial class FundingInformation_ASOP51
    {
        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();



        /// <summary>
        /// 2019-Jun-28 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("NumberOfYears", "5");
        ///    dic.Add("LoadHistory", "click");
        ///    pFundingInformation_ASOP51._ASOP51_History(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _ASOP51_History(MyDictionary dic)
        {

            string sFunctionName = "_ASOP51_History";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("NumberOfYears", this.wRetirementStudio.wNumberOfYears.txt, dic["NumberOfYears"], 0);
                _gLib._SetSyncUDWin("LoadHistory", this.wRetirementStudio.wLoadHistory.btn, dic["LoadHistory"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                // not complete yet
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2019-Jun-28 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("USGovernmentSecurities_label", "");
        ///    dic.Add("USGovernmentSecurities_txt", "");
        ///    dic.Add("CorporateDebt_label", "");
        ///    dic.Add("CorporateDebt_txt", "");
        ///    dic.Add("CorporateStocks_label", "");
        ///    dic.Add("CorporateStocks_txt", "");
        ///    dic.Add("HedgeFunds_label", "");
        ///    dic.Add("HedgeFunds_txt", "");
        ///    dic.Add("RealEstate_label", "");
        ///    dic.Add("RealEstate_txt", "");
        ///    dic.Add("Cash_label", "");
        ///    dic.Add("Cash_txt", "");
        ///    dic.Add("Other_label", "");
        ///    dic.Add("Other_txt", "");
        ///    dic.Add("UserDefined1_label", "");
        ///    dic.Add("UserDefined1_txt", "");
        ///    dic.Add("UserDefined2_label", "");
        ///    dic.Add("UserDefined2_txt", "");
        ///    dic.Add("UserDefined3_label", "");
        ///    dic.Add("UserDefined3_txt", "");
        ///    dic.Add("UserDefined4_label", "");
        ///    dic.Add("UserDefined4_txt", "");
        ///    dic.Add("UserDefined5_label", "");
        ///    dic.Add("UserDefined5_txt", "");
        ///    dic.Add("AnnuityBenefitPayments_label", "");
        ///    dic.Add("AnnuityBenefitPayments_txt", "");
        ///    dic.Add("LumpSumBenefitPayments_label", "");
        ///    dic.Add("LumpSumBenefitPayments_txt", "");
        ///    dic.Add("AnnuityBuyouts_label", "");
        ///    dic.Add("AnnuityBuyouts_txt", ""); 
        ///    pFundingInformation_ASOP51._ASOP51_currentYear(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _ASOP51_currentYear(MyDictionary dic)
        {

            string sFunctionName = "_ASOP51_currentYear";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("USGovernmentSecurities_label", this.wRetirementStudio.wUSGovernmentsecurit.txt, dic["USGovernmentSecurities_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("USGovernmentSecurities_txt", this.wRetirementStudio.wEditUSGovernment.txt.UINumEditorEdit1, dic["USGovernmentSecurities_txt"], 0);
               
                _gLib._SetSyncUDWin("CorporateDebt_label", this.wRetirementStudio.wCorporatedeb.txt, dic["CorporateDebt_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CorporateDebt_txt", this.wRetirementStudio.wEditCorporateDebt.txt.UINumEditorEdit1, dic["CorporateDebt_txt"], 0);
                
                _gLib._SetSyncUDWin("CorporateStocks_label", this.wRetirementStudio.wCorporatestocks.txt, dic["CorporateStocks_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CorporateStocks_txt", this.wRetirementStudio.wEditCorporateStocks.txt.UINumEditorEdit1, dic["CorporateStocks_txt"], 0);
                
                _gLib._SetSyncUDWin("HedgeFunds_label", this.wRetirementStudio.wHedgefundsWindow.txt, dic["HedgeFunds_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("HedgeFunds_txt", this.wRetirementStudio.wEditHedgeFunds.txt.UINumEditorEdit1, dic["HedgeFunds_txt"], 0);
                
                _gLib._SetSyncUDWin("RealEstate_label", this.wRetirementStudio.wRealestateWindow.txt, dic["RealEstate_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("RealEstate_txt", this.wRetirementStudio.wEditRealEstate.txt.UINumEditorEdit1, dic["RealEstate_txt"], 0);
                
                _gLib._SetSyncUDWin("Cash_label", this.wRetirementStudio.wCashWindow.txt, dic["Cash_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Cash_txt", this.wRetirementStudio.wEditCash.txt.UINumEditorEdit1, dic["Cash_txt"], 0);
                
                _gLib._SetSyncUDWin("Other_label", this.wRetirementStudio.wOtherWindow.txt, dic["Other_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Other_txt", this.wRetirementStudio.wEditOther.txt.UINumEditorEdit1, dic["Other_txt"], 0);

                _gLib._SetSyncUDWin("UserDefined1_label", this.wRetirementStudio.wUserdefined1Window.txt, dic["UserDefined1_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("UserDefined1_txt", this.wRetirementStudio.wEditUserDefined1.txt.UINumEditorEdit1, dic["UserDefined1_txt"], 0);

                _gLib._SetSyncUDWin("UserDefined2_label", this.wRetirementStudio.wUserdefined2Window.txt, dic["UserDefined2_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("UserDefined2_txt", this.wRetirementStudio.wEditDefined2.txt.UINumEditorEdit1, dic["UserDefined2_txt"], 0);

                _gLib._SetSyncUDWin("UserDefined3_label", this.wRetirementStudio.wUserdefined3Window.txt, dic["UserDefined3_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("UserDefined3_txt", this.wRetirementStudio.wEditDefined3.txt.UINumEditorEdit1, dic["UserDefined3_txt"], 0);

                _gLib._SetSyncUDWin("UserDefined4_label", this.wRetirementStudio.wUserdefined4Window.txt, dic["UserDefined4_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("UserDefined4_txt", this.wRetirementStudio.wEditDefined4.txt.UINumEditorEdit1, dic["UserDefined4_txt"], 0);

                _gLib._SetSyncUDWin("UserDefined5_label", this.wRetirementStudio.wIUserdefined5Window.txt, dic["UserDefined5_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("UserDefined5_txt", this.wRetirementStudio.wEditDefined5.txt.UINumEditorEdit1, dic["UserDefined5_txt"], 0);

                _gLib._SetSyncUDWin("AnnuityBenefitPayments_label", this.wRetirementStudio.wAnnuitybenefitpaymenWindow.txt, dic["AnnuityBenefitPayments_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AnnuityBenefitPayments_txt", this.wRetirementStudio.wEditAnnuityBenefitPayment.txt.UINumEditorEdit1, dic["AnnuityBenefitPayments_txt"], 0);

                _gLib._SetSyncUDWin("LumpSumBenefitPayments_label", this.wRetirementStudio.wLumpsumbenefitpaymenWindow.txt, dic["LumpSumBenefitPayments_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("LumpSumBenefitPayments_txt", this.wRetirementStudio.wEditLumpSumBenefitPayment.txt.UINumEditorEdit1, dic["LumpSumBenefitPayments_txt"], 0);

                _gLib._SetSyncUDWin("AnnuityBuyouts_label", this.wRetirementStudio.wAnnuitybuyoutsduringWindow.txt, dic["AnnuityBuyouts_label"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AnnuityBuyouts_txt", this.wRetirementStudio.wEditAnnuityBuyoutsDuring.txt.UINumEditorEdit1, dic["AnnuityBuyouts_txt"], 0); 
            }

            if (dic["PopVerify"] == "Verify")
            {
                // not complete yet
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2019-Jun-28 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("RiskAccessments", "");
        ///    dic.Add("InvestmentRisk", "");
        ///    dic.Add("InterestRateRisk", "");
        ///    dic.Add("AssetLiabilityMismatchRisk", "");
        ///    dic.Add("LumpSumRisk", "");
        ///    dic.Add("OtherEconomicRisk_label", "");
        ///    dic.Add("OtherEconomicRisk", "");
        ///    dic.Add("LongevityRisk", "");
        ///    dic.Add("RetirementRisk", "");
        ///    dic.Add("OtherDemographicRisk_label", "");
        ///    dic.Add("OtherDemographicRisk", "");
        ///    dic.Add("MaturityMeasures_1_label", "");
        ///    dic.Add("MaturityMeasures_1", "");
        ///    dic.Add("MaturityMeasures_2_label", "");
        ///    dic.Add("MaturityMeasures_2", "");
        ///    dic.Add("MaturityMeasures_3_label", "");
        ///    dic.Add("MaturityMeasures_3", "");
        ///    pFundingInformation_ASOP51._ASOP51_riskAssessments(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _ASOP51_riskAssessments(MyDictionary dic)
        {

            string sFunctionName = "_ASOP51_riskAssessments";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("RiskAccessments", this.wRetirementStudio.wRishAssessments.txt, dic["RiskAccessments"], 0);
                _gLib._SetSyncUDWin("InvestmentRisk", this.wRetirementStudio.wInvestmentRisk.txt, dic[ "InvestmentRisk"], 0);
                _gLib._SetSyncUDWin("InterestRateRisk", this.wRetirementStudio.wInterestRateRiskWindow.txt, dic[ "InterestRateRisk"], 0);
                _gLib._SetSyncUDWin("AssetLiabilityMismatchRisk", this.wRetirementStudio.wAssetLiabilityMisWindow.txt, dic[ "AssetLiabilityMismatchRisk"], 0);
                _gLib._SetSyncUDWin("LumpSumRisk", this.wRetirementStudio.wLumpSumRisk.txt, dic["LumpSumRisk"], 0);
                _gLib._SetSyncUDWin("OtherEconomicRisk_label", this.wRetirementStudio.wOtherEconomicRisk_label.txt, dic[ "OtherEconomicRisk_label"], 0);
                _gLib._SetSyncUDWin("OtherEconomicRisk", this.wRetirementStudio.wOtherEconomicRiskWindow.txt, dic[ "OtherEconomicRisk"], 0);
                _gLib._SetSyncUDWin("LongevityRisk", this.wRetirementStudio.wLongevityRiskWindow.txt, dic[ "LongevityRisk"], 0);
                _gLib._SetSyncUDWin("RetirementRisk", this.wRetirementStudio.wRetirementRiskWindow.txt, dic[ "RetirementRisk"], 0);
                _gLib._SetSyncUDWin("OtherDemographicRisk_label", this.wRetirementStudio.wOtherDemographicR_label.txt, dic["OtherDemographicRisk_label"], 0);
                _gLib._SetSyncUDWin("OtherDemographicRisk", this.wRetirementStudio.wOtherDemographicRWindow.txt, dic[ "OtherDemographicRisk"], 0);
                _gLib._SetSyncUDWin("MaturityMeasures_1_label", this.wRetirementStudio.wMaturityMeasure1LWindow.txt, dic[ "MaturityMeasures_1_label"], 0);
                _gLib._SetSyncUDWin("MaturityMeasures_1", this.wRetirementStudio.wMaturityMeasure1Window.txt, dic[ "MaturityMeasures_1"], 0);
                _gLib._SetSyncUDWin("MaturityMeasures_2_label", this.wRetirementStudio.wMaturityMeasure2LWindow.txt, dic[ "MaturityMeasures_2_label"], 0);
                _gLib._SetSyncUDWin("MaturityMeasures_2", this.wRetirementStudio.wMaturityMeasure2Window.txt, dic[ "MaturityMeasures_2"], 0);
                _gLib._SetSyncUDWin("MaturityMeasures_3_label", this.wRetirementStudio.wMaturityMeasure3LWindow.txt, dic[ "MaturityMeasures_3_label"], 0);
                _gLib._SetSyncUDWin("MaturityMeasures_3", this.wRetirementStudio.wMaturityMeasure3Window.txt, dic[ "MaturityMeasures_3"], 0);     
            }

            if (dic["PopVerify"] == "Verify")
            {
                // not complete yet
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }
    }
}
