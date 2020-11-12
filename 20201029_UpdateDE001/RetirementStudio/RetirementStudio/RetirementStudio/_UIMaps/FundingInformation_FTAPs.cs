namespace RetirementStudio._UIMaps.FundingInformation_FTAPsClasses
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


    public partial class FundingInformation_FTAPs
    {
        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2013-May-20 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("MVOfAssets", "");
        ///    dic.Add("90ofMarketValue", "");
        ///    dic.Add("110ofMarketValue", "");
        ///    dic.Add("PreliminaryActuarial", "");
        ///    dic.Add("ActuarialValue", "");
        ///    dic.Add("AVAPFB", "");
        ///    dic.Add("AVACOBPFB", "");
        ///    dic.Add("Prior2YearsNHC", "");
        ///    dic.Add("AVANHCPurchase", "");
        ///    dic.Add("AVACOBPFBNHCPurchase", "");
        ///    dic.Add("NARFundLiabNHCPurchase", "");
        ///    pFundingInformation_FTAPs._PopVerify_AssetNumbers(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_AssetNumbers(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_AssetNumbers";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("MVOfAssets", this.wRetirementStudio.wAssetNumbers_MVOfAssets.txtMVOfAssets, dic["MVOfAssets"], 0);
                _gLib._SetSyncUDWin_ByClipboard("90ofMarketValue", this.wRetirementStudio.wAssetNumbers_90ofMarketValue.txt90ofMarketValue, dic["90ofMarketValue"], 0);
                _gLib._SetSyncUDWin_ByClipboard("110ofMarketValue", this.wRetirementStudio.wAssetNumbers_110ofMarketValue.txt110ofMarketValue, dic["110ofMarketValue"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PreliminaryActuarial", this.wRetirementStudio.wAssetNumbers_PreliminaryActuarial.txtPreliminaryActuarial, dic["PreliminaryActuarial"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ActuarialValue", this.wRetirementStudio.wAssetNumbers_ActuarialValue.txtActuarialValue, dic["ActuarialValue"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AVAPFB", this.wRetirementStudio.wAssetNumbers_AVAPFB.txtAVAPFB, dic["AVAPFB"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AVACOBPFB", this.wRetirementStudio.wAssetNumbers_AVACOBPFB.txtAVACOBPFB, dic["AVACOBPFB"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Prior2YearsNHC", this.wRetirementStudio.wAssetNumbers_Prior2YearsNHC.txtPrior2YearsNHC, dic["Prior2YearsNHC"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AVANHCPurchase", this.wRetirementStudio.wAssetNumbers_AVANHCPurchase.txtAVANHCPurchase, dic["AVANHCPurchase"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AVACOBPFBNHCPurchase", this.wRetirementStudio.wAssetNumbers_AVACOBPFBNHCPurchase.txtAVACOBPFBNHCPurchase, dic["AVACOBPFBNHCPurchase"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NARFundLiabNHCPurchase", this.wRetirementStudio.wAssetNumbers_NARFundLiabNHCPurchase.txtNARFundLiabNHCPurchase, dic["NARFundLiabNHCPurchase"], 0);

            
            }

            if (dic["PopVerify"] == "Verify")
            {
                
                _gLib._VerifySyncUDWin("MVOfAssets", this.wRetirementStudio.wAssetNumbers_MVOfAssets.txtMVOfAssets, dic["MVOfAssets"], 0);
                _gLib._VerifySyncUDWin("90ofMarketValue", this.wRetirementStudio.wAssetNumbers_90ofMarketValue.txt90ofMarketValue, dic["90ofMarketValue"], 0);
                _gLib._VerifySyncUDWin("110ofMarketValue", this.wRetirementStudio.wAssetNumbers_110ofMarketValue.txt110ofMarketValue, dic["110ofMarketValue"], 0);
                _gLib._VerifySyncUDWin("PreliminaryActuarial", this.wRetirementStudio.wAssetNumbers_PreliminaryActuarial.txtPreliminaryActuarial, dic["PreliminaryActuarial"], 0);
                _gLib._VerifySyncUDWin("ActuarialValue", this.wRetirementStudio.wAssetNumbers_ActuarialValue.txtActuarialValue, dic["ActuarialValue"], 0);
                _gLib._VerifySyncUDWin("AVAPFB", this.wRetirementStudio.wAssetNumbers_AVAPFB.txtAVAPFB, dic["AVAPFB"], 0);
                _gLib._VerifySyncUDWin("AVACOBPFB", this.wRetirementStudio.wAssetNumbers_AVACOBPFB.txtAVACOBPFB, dic["AVACOBPFB"], 0);
                _gLib._VerifySyncUDWin("Prior2YearsNHC", this.wRetirementStudio.wAssetNumbers_Prior2YearsNHC.txtPrior2YearsNHC, dic["Prior2YearsNHC"], 0);
                _gLib._VerifySyncUDWin("AVANHCPurchase", this.wRetirementStudio.wAssetNumbers_AVANHCPurchase.txtAVANHCPurchase, dic["AVANHCPurchase"], 0);
                _gLib._VerifySyncUDWin("AVACOBPFBNHCPurchase", this.wRetirementStudio.wAssetNumbers_AVACOBPFBNHCPurchase.txtAVACOBPFBNHCPurchase, dic["AVACOBPFBNHCPurchase"], 0);
                _gLib._VerifySyncUDWin("NARFundLiabNHCPurchase", this.wRetirementStudio.wAssetNumbers_NARFundLiabNHCPurchase.txtNARFundLiabNHCPurchase, dic["NARFundLiabNHCPurchase"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-20 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FTAP", "");
        ///    dic.Add("FTAP_PFB", "");
        ///    dic.Add("FTAP_Exempt", "");
        ///    dic.Add("FTAP_AtRisk", "");
        ///    dic.Add("FTAP_SB_PFB", "");
        ///    dic.Add("FTAP_SB_NoPFB", "");
        ///    pFundingInformation_FTAPs._PopVerify_FTAPs(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_FTAPs(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FTAPs";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("FTAP", this.wRetirementStudio.wFTAPs_FTAP.txtFTAP, dic["FTAP"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FTAP_PFB", this.wRetirementStudio.wFTAPs_FTAP_PFB.txtFTAP_PFB, dic["FTAP_PFB"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FTAP_Exempt", this.wRetirementStudio.wFTAPs_FTAP_Exempt.txtFTAP_Exempt, dic["FTAP_Exempt"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FTAP_AtRisk", this.wRetirementStudio.wFTAPs_FTAP_AtRisk.txtFTAP_AtRisk, dic["FTAP_AtRisk"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FTAP_SB_PFB", this.wRetirementStudio.wFTAPs_FTAP_SB_PFB.txtFTAP_SB_PFB, dic["FTAP_SB_PFB"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FTAP_SB_NoPFB", this.wRetirementStudio.wFTAPs_FTAP_SB_NoPFB.txtFTAP_SB_NoPFB, dic["FTAP_SB_NoPFB"], 0);
    
            }

            if (dic["PopVerify"] == "Verify")
            {

                
                _gLib._VerifySyncUDWin("FTAP", this.wRetirementStudio.wFTAPs_FTAP.txtFTAP, dic["FTAP"], 0);
                _gLib._VerifySyncUDWin("FTAP_PFB", this.wRetirementStudio.wFTAPs_FTAP_PFB.txtFTAP_PFB, dic["FTAP_PFB"], 0);
                _gLib._VerifySyncUDWin("FTAP_Exempt", this.wRetirementStudio.wFTAPs_FTAP_Exempt.txtFTAP_Exempt, dic["FTAP_Exempt"], 0);
                _gLib._VerifySyncUDWin("FTAP_AtRisk", this.wRetirementStudio.wFTAPs_FTAP_AtRisk.txtFTAP_AtRisk, dic["FTAP_AtRisk"], 0);
                _gLib._VerifySyncUDWin("FTAP_SB_PFB", this.wRetirementStudio.wFTAPs_FTAP_SB_PFB.txtFTAP_SB_PFB, dic["FTAP_SB_PFB"], 0);
                _gLib._VerifySyncUDWin("FTAP_SB_NoPFB", this.wRetirementStudio.wFTAPs_FTAP_SB_NoPFB.txtFTAP_SB_NoPFB, dic["FTAP_SB_NoPFB"], 0);
    
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-20 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ElectionToUse", "");
        ///    dic.Add("ShortfallFunded", "");
        ///    dic.Add("EligibleForTransition", "");
        ///    dic.Add("ExemptFrom2007AFC", "");
        ///    dic.Add("2008", "");
        ///    dic.Add("2009", "");
        ///    dic.Add("2010", "");
        ///    dic.Add("IsPlanExempt", "");
        ///    pFundingInformation_FTAPs._PopVerify_ShortfallBaseExemption(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ShortfallBaseExemption(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ShortfallBaseExemption";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ElectionToUse", this.wRetirementStudio.wShortfall_ElectionToUse.cbpElectionToUse, dic["ElectionToUse"], 0);
                _gLib._SetSyncUDWin("ShortfallFunded", this.wRetirementStudio.wShortfall_ShortfallFunded.cboShortfallFunded, dic["ShortfallFunded"], 0);
                _gLib._SetSyncUDWin("EligibleForTransition", this.wRetirementStudio.wShortfall_EligibileForTransition.cboEligibleForTransition, dic["EligibleForTransition"], 0);
                _gLib._SetSyncUDWin("ExemptFrom2007AFC", this.wRetirementStudio.wShortfall_ExemptFrom2007AFC.cboExemptFrom2007AFC, dic["ExemptFrom2007AFC"], 0);
                _gLib._SetSyncUDWin_ByClipboard("2008", this.wRetirementStudio.wShortfall_2008.txt2008, dic["2008"], 0);
                _gLib._SetSyncUDWin_ByClipboard("2009", this.wRetirementStudio.wShortfall_2009.txt2009, dic["2009"], 0);
                _gLib._SetSyncUDWin_ByClipboard("2010", this.wRetirementStudio.wShortfall_2010.txt2010, dic["2010"], 0);
                _gLib._SetSyncUDWin("IsPlanExempt", this.wRetirementStudio.wShortfall_IsPlanExempt.cboIsPlanExempt, dic["IsPlanExempt"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("ElectionToUse", this.wRetirementStudio.wShortfall_ElectionToUse.cbpElectionToUse, dic["ElectionToUse"], 0);
                _gLib._VerifySyncUDWin("ShortfallFunded", this.wRetirementStudio.wShortfall_ShortfallFunded.cboShortfallFunded, dic["ShortfallFunded"], 0);
                _gLib._VerifySyncUDWin("EligibleForTransition", this.wRetirementStudio.wShortfall_EligibileForTransition.cboEligibleForTransition, dic["EligibleForTransition"], 0);
                _gLib._VerifySyncUDWin("ExemptFrom2007AFC", this.wRetirementStudio.wShortfall_ExemptFrom2007AFC.cboExemptFrom2007AFC, dic["ExemptFrom2007AFC"], 0);
                _gLib._VerifySyncUDWin("2008", this.wRetirementStudio.wShortfall_2008.txt2008, dic["2008"], 0);
                _gLib._VerifySyncUDWin("2009", this.wRetirementStudio.wShortfall_2009.txt2009, dic["2009"], 0);
                _gLib._VerifySyncUDWin("2010", this.wRetirementStudio.wShortfall_2010.txt2010, dic["2010"], 0);
                _gLib._VerifySyncUDWin("IsPlanExempt", this.wRetirementStudio.wShortfall_IsPlanExempt.cboIsPlanExempt, dic["IsPlanExempt"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-20 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CurrentYearTop25", "");
        ///    dic.Add("CurrentYear401", "");
        ///    dic.Add("CanUseCOB", "");
        ///    dic.Add("QuarterlyContrib", "");
        ///    dic.Add("PBGC4010", "");
        ///    pFundingInformation_FTAPs._PopVerify_OtherFTAPChecks(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_OtherFTAPChecks(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_OtherFTAPChecks";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("CurrentYearTop25", this.wRetirementStudio.wOtherFTAP_CurrentYearTop25.txtCurrentYearTop25, dic["CurrentYearTop25"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CurrentYear401", this.wRetirementStudio.wOtherFTAP_CurrentYear401.txtCurrentYear401, dic["CurrentYear401"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CanUseCOB", this.wRetirementStudio.wOtherFTAP_CanUseCOB.txtCanUseCOB, dic["CanUseCOB"], 0);
                _gLib._SetSyncUDWin_ByClipboard("QuarterlyContrib", this.wRetirementStudio.wOtherFTAP_QuarterlyContrib.txtQuarterlyContrib, dic["QuarterlyContrib"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGC4010", this.wRetirementStudio.wOtherFTAP_PBGC4010.txtPBGC4010, dic["PBGC4010"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
  

                _gLib._VerifySyncUDWin("CurrentYearTop25", this.wRetirementStudio.wOtherFTAP_CurrentYearTop25.txtCurrentYearTop25, dic["CurrentYearTop25"], 0);
                _gLib._VerifySyncUDWin("CurrentYear401", this.wRetirementStudio.wOtherFTAP_CurrentYear401.txtCurrentYear401, dic["CurrentYear401"], 0);
                _gLib._VerifySyncUDWin("CanUseCOB", this.wRetirementStudio.wOtherFTAP_CanUseCOB.txtCanUseCOB, dic["CanUseCOB"], 0);
                _gLib._VerifySyncUDWin("QuarterlyContrib", this.wRetirementStudio.wOtherFTAP_QuarterlyContrib.txtQuarterlyContrib, dic["QuarterlyContrib"], 0);
                _gLib._VerifySyncUDWin("PBGC4010", this.wRetirementStudio.wOtherFTAP_PBGC4010.txtPBGC4010, dic["PBGC4010"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-20 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Prong1", "");
        ///    dic.Add("Prong2", "");
        ///    dic.Add("PlanIsAtRiskNextYear", "");
        ///    dic.Add("PlanAtRiskPriorYear1", "");
        ///    dic.Add("PlanAtRiskPriorYear2", "");
        ///    dic.Add("NumOfYears", "");
        ///    dic.Add("ExpenseLoad", "");
        ///    dic.Add("NextYearConsecutive", "");
        ///    dic.Add("FTNextYear", "");
        ///    pFundingInformation_FTAPs._PopVerify_AtRiskDeterminatinForFollowingYear(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_AtRiskDeterminatinForFollowingYear(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_AtRiskDeterminatinForFollowingYear";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("Prong1", this.wRetirementStudio.wAtRiskDetermination_Prong1.txtProng1, dic["Prong1"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Prong2", this.wRetirementStudio.wAtRiskDetermination_Prong2.txtProng2, dic["Prong2"], 0);
                _gLib._SetSyncUDWin("PlanIsAtRiskNextYear", this.wRetirementStudio.wAtRiskDetermination_PlanIsAtRiskNextYear.cboPlanIsAtRiskNextYear, dic["PlanIsAtRiskNextYear"], 0);
                _gLib._SetSyncUDWin("PlanAtRiskPriorYear1", this.wRetirementStudio.wAtRiskDetermination_PlanAtRiskPriorYear1.cobPlanAtRiskPriorYear1, dic["PlanAtRiskPriorYear1"], 0);
                _gLib._SetSyncUDWin("PlanAtRiskPriorYear2", this.wRetirementStudio.wAtRiskDetermination_PlanAtRiskPriorYear2.cboPlanAtRiskPriorYear2, dic["PlanAtRiskPriorYear2"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NumOfYears", this.wRetirementStudio.wAtRiskDetermination_NumOfYears.txtNumOfYears, dic["NumOfYears"], 0);
                _gLib._SetSyncUDWin("ExpenseLoad", this.wRetirementStudio.wAtRiskDetermination_ExpenseLoad.cboExpenseLoad, dic["ExpenseLoad"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NextYearConsecutive", this.wRetirementStudio.wAtRiskDetermination_NextYearConsecutive.txtNextYearConsecutive, dic["NextYearConsecutive"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FTNextYear", this.wRetirementStudio.wAtRiskDetermination_FTNextYear.txtFTNextYear, dic["FTNextYear"], 0);



            }

            if (dic["PopVerify"] == "Verify")
            {


                
                _gLib._VerifySyncUDWin("Prong1", this.wRetirementStudio.wAtRiskDetermination_Prong1.txtProng1, dic["Prong1"], 0);
                _gLib._VerifySyncUDWin("Prong2", this.wRetirementStudio.wAtRiskDetermination_Prong2.txtProng2, dic["Prong2"], 0);
                _gLib._VerifySyncUDWin("PlanIsAtRiskNextYear", this.wRetirementStudio.wAtRiskDetermination_PlanIsAtRiskNextYear.cboPlanIsAtRiskNextYear, dic["PlanIsAtRiskNextYear"], 0);
                _gLib._VerifySyncUDWin("PlanAtRiskPriorYear1", this.wRetirementStudio.wAtRiskDetermination_PlanAtRiskPriorYear1.cobPlanAtRiskPriorYear1, dic["PlanAtRiskPriorYear1"], 0);
                _gLib._VerifySyncUDWin("PlanAtRiskPriorYear2", this.wRetirementStudio.wAtRiskDetermination_PlanAtRiskPriorYear2.cboPlanAtRiskPriorYear2, dic["PlanAtRiskPriorYear2"], 0);
                _gLib._VerifySyncUDWin("NumOfYears", this.wRetirementStudio.wAtRiskDetermination_NumOfYears.txtNumOfYears, dic["NumOfYears"], 0);
                _gLib._VerifySyncUDWin("ExpenseLoad", this.wRetirementStudio.wAtRiskDetermination_ExpenseLoad.cboExpenseLoad, dic["ExpenseLoad"], 0);
                _gLib._VerifySyncUDWin("NextYearConsecutive", this.wRetirementStudio.wAtRiskDetermination_NextYearConsecutive.txtNextYearConsecutive, dic["NextYearConsecutive"], 0);
                _gLib._VerifySyncUDWin("FTNextYear", this.wRetirementStudio.wAtRiskDetermination_FTNextYear.txtFTNextYear, dic["FTNextYear"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-20 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AFTAPBefore", "");
        ///    dic.Add("IncreaseTo60", "");
        ///    dic.Add("IncreaseTo80", "");
        ///    dic.Add("RequiredCredit", "");
        ///    dic.Add("FinalAFTAP_TotalWaiver", "");
        ///    dic.Add("FinalAFTAP_FinalAFTAP", "");
        ///    pFundingInformation_FTAPs._PopVerify_PreliminaryAFTAPCalcuations(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PreliminaryAFTAPCalcuations(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PreliminaryAFTAPCalcuations";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin_ByClipboard("AFTAPBefore", this.wRetirementStudio.wPreliminaryAFTAP_AFTAPBefore.txtAFTAPBefore, dic["AFTAPBefore"], 0);
                _gLib._SetSyncUDWin_ByClipboard("IncreaseTo60", this.wRetirementStudio.wPreliminaryAFTAP_IncreaseTo60.txtIncreaseTo60, dic["IncreaseTo60"], 0);
                _gLib._SetSyncUDWin_ByClipboard("IncreaseTo80", this.wRetirementStudio.wPreliminaryAFTAP_IncreaseTo80.txtIncreaseTo80, dic["IncreaseTo80"], 0);
                _gLib._SetSyncUDWin_ByClipboard("RequiredCredit", this.wRetirementStudio.wPreliminaryAFTAP_ReqiredCredit.txtRequiredCredit, dic["RequiredCredit"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FinalAFTAP_TotalWaiver", this.wRetirementStudio.wFinalAFTAP_TotalWaiver.txtFinalAFTAP_TotalWaiver, dic["FinalAFTAP_TotalWaiver"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FinalAFTAP_FinalAFTAP", this.wRetirementStudio.wFinalAFTAP_FinalAFTAP.txtFinalAFTAP_FinalAFTAP, dic["FinalAFTAP_FinalAFTAP"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("AFTAPBefore", this.wRetirementStudio.wPreliminaryAFTAP_AFTAPBefore.txtAFTAPBefore, dic["AFTAPBefore"], 0);
                _gLib._VerifySyncUDWin("IncreaseTo60", this.wRetirementStudio.wPreliminaryAFTAP_IncreaseTo60.txtIncreaseTo60, dic["IncreaseTo60"], 0);
                _gLib._VerifySyncUDWin("IncreaseTo80", this.wRetirementStudio.wPreliminaryAFTAP_IncreaseTo80.txtIncreaseTo80, dic["IncreaseTo80"], 0);
                _gLib._VerifySyncUDWin("RequiredCredit", this.wRetirementStudio.wPreliminaryAFTAP_ReqiredCredit.txtRequiredCredit, dic["RequiredCredit"], 0);
                _gLib._VerifySyncUDWin("FinalAFTAP_TotalWaiver", this.wRetirementStudio.wFinalAFTAP_TotalWaiver.txtFinalAFTAP_TotalWaiver, dic["FinalAFTAP_TotalWaiver"], 0);
                _gLib._VerifySyncUDWin("FinalAFTAP_FinalAFTAP", this.wRetirementStudio.wFinalAFTAP_FinalAFTAP.txtFinalAFTAP_FinalAFTAP, dic["FinalAFTAP_FinalAFTAP"], 0);


            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-20 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CurrentYear_TreatPlan", "");
        ///    dic.Add("CurrentYear_In3Months", "");
        ///    dic.Add("CurrentYear_In6Months", "");
        ///    dic.Add("CurrentYear_After9Months", "");
        ///    dic.Add("NextYear_In3Months", "");
        ///    dic.Add("NextYear_In6Months", "");
        ///    dic.Add("NextYear_After9Months", "");
        ///    pFundingInformation_FTAPs._PopVerify_PresumedCurrentNextYear(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PresumedCurrentNextYear(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PresumedCurrentNextYear";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("CurrentYear_TreatPlan", this.wRetirementStudio.wPresumedCurrentYear_TreatPlan.cboTreatPlan, dic["CurrentYear_TreatPlan"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CurrentYear_In3Months", this.wRetirementStudio.wPresumedCurrentYear_In3Months.txtIn3Months, dic["CurrentYear_In3Months"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CurrentYear_In6Months", this.wRetirementStudio.wPresumedCurrentYear_In6Months.txtIn6Months, dic["CurrentYear_In6Months"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CurrentYear_After9Months", this.wRetirementStudio.wPresumedCurrentYear_After9Months.txtAfter9Months, dic["CurrentYear_After9Months"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NextYear_In3Months", this.wRetirementStudio.wPresumedNextYear_In3Months.txtIn3Months, dic["NextYear_In3Months"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NextYear_In6Months", this.wRetirementStudio.wPresumedNextYear_In6Months.txtIn6Months, dic["NextYear_In6Months"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NextYear_After9Months", this.wRetirementStudio.wPresumedNextYear_After9Months.txtAfter9Months, dic["NextYear_After9Months"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("CurrentYear_TreatPlan", this.wRetirementStudio.wPresumedCurrentYear_TreatPlan.cboTreatPlan, dic["CurrentYear_TreatPlan"], 0);
                _gLib._VerifySyncUDWin("CurrentYear_In3Months", this.wRetirementStudio.wPresumedCurrentYear_In3Months.txtIn3Months, dic["CurrentYear_In3Months"], 0);
                _gLib._VerifySyncUDWin("CurrentYear_In6Months", this.wRetirementStudio.wPresumedCurrentYear_In6Months.txtIn6Months, dic["CurrentYear_In6Months"], 0);
                _gLib._VerifySyncUDWin("CurrentYear_After9Months", this.wRetirementStudio.wPresumedCurrentYear_After9Months.txtAfter9Months, dic["CurrentYear_After9Months"], 0);
                _gLib._VerifySyncUDWin("NextYear_In3Months", this.wRetirementStudio.wPresumedNextYear_In3Months.txtIn3Months, dic["NextYear_In3Months"], 0);
                _gLib._VerifySyncUDWin("NextYear_In6Months", this.wRetirementStudio.wPresumedNextYear_In6Months.txtIn6Months, dic["NextYear_In6Months"], 0);
                _gLib._VerifySyncUDWin("NextYear_After9Months", this.wRetirementStudio.wPresumedNextYear_After9Months.txtAfter9Months, dic["NextYear_After9Months"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Feb-18 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FullyFundedPriorYear2009FTAP", "");
        ///    dic.Add("FullyFundedPriorYear2010FTAP", "");
        ///    dic.Add("FullyFundedCYExemption", "");
        ///    dic.Add("FullyFundedFTAPCYFTAP_Exempt", "");
        ///    dic.Add("FinalAFTAPCalculationFinalAFTAP", "");
        ///    dic.Add("ShutDownAmountNeededTo60Percent", "");
        ///    dic.Add("PlanAmendmentNeededTo80Percent", "");
        ///    dic.Add("AcceleratedBenefitDistriAllowed", "");
        ///    dic.Add("LimitationFundingCharge", "");
        ///    dic.Add("AddtitionalFundingToAvoid", "");
        ///    dic.Add("PresumedCurrentYrsTreatPlan", "");
        ///    dic.Add("PresumedCurrentYrsIn3Months", "");
        ///    dic.Add("PresumedCurrentYrsIn6Months", "");  
        ///    dic.Add("PresumedCurrentYrsAfter9Months", "");  
        ///    dic.Add("PresumedNextYrsIn3Months", "");
        ///    dic.Add("PresumedNextYrsIn6Months", "");  
        ///    dic.Add("PresumedNextYrsAfter9Months", ""); 
        ///    pFundingInformation_FTAPs._PopVerify_BenefitRestributionsDeterminations(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_BenefitRestributionsDeterminations(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_BenefitRestributionsDeterminations";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("FullyFundedPriorYear2009FTAP", this.wRetirementStudio.wFullyFundedPriorYear2009FTAP.UITxtPriorYear2009FTAPEdit, dic["FullyFundedPriorYear2009FTAP"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FullyFundedPriorYear2010FTAP", this.wRetirementStudio.wFullyFundedtPriorYear2010FTAP.UITxtPriorYear2010FTAPEdit, dic["FullyFundedPriorYear2010FTAP"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FullyFundedCYExemption", this.wRetirementStudio.wFullyFundedCYExemption.txt.UINumEditorEdit1, dic["FullyFundedCYExemption"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FullyFundedFTAPCYFTAP_Exempt", this.wRetirementStudio.wFullyFundedFTAPCYFTAP_Exempt.txt.UINumEditorEdit1, dic["FullyFundedFTAPCYFTAP_Exempt"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FinalAFTAPCalculationFinalAFTAP", this.wRetirementStudio.wFinalAFTAP_FinalAFTAP.txtFinalAFTAP_FinalAFTAP, dic["FinalAFTAPCalculationFinalAFTAP"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ShutDownAmountNeededTo60Percent", this.wRetirementStudio.wShutDownAmountNeededTo60Percent.txt.UINumEditorEdit1, dic["ShutDownAmountNeededTo60Percent"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PlanAmendmentNeededTo80Percent", this.wRetirementStudio.wPlanAmendmentNeededTo80Percent.txt.UINumEditorEdit1, dic["PlanAmendmentNeededTo80Percent"], 0);
                _gLib._SetSyncUDWin("AcceleratedBenefitDistriAllowed", this.wRetirementStudio.wAcceleratedBenefitDistri.cboAcceleratedDistriAllowed, dic["AcceleratedBenefitDistriAllowed"], 0);
                _gLib._SetSyncUDWin_ByClipboard("LimitationFundingCharge", this.wRetirementStudio.wLimitationFundingCharge.txt.UINumEditorEdit1, dic["LimitationFundingCharge"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AddtitionalFundingToAvoid", this.wRetirementStudio.wAddtitionalFundingToAvoid.txt.UINumEditorEdit1, dic["AddtitionalFundingToAvoid"], 0);
                _gLib._SetSyncUDWin("PresumedCurrentYrsTreatPlan", this.wRetirementStudio.wPresumedCurrentYear_TreatPlan.cboTreatPlan, dic["PresumedCurrentYrsTreatPlan"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PresumedCurrentYrsIn3Months", this.wRetirementStudio.wPresumedCurrentYear_In3Months.txtIn3Months, dic["PresumedCurrentYrsIn3Months"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PresumedCurrentYrsIn6Months", this.wRetirementStudio.wPresumedCurrentYear_In6Months.txtIn6Months, dic["PresumedCurrentYrsIn6Months"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PresumedCurrentYrsAfter9Months", this.wRetirementStudio.wPresumedCurrentYear_After9Months.txtAfter9Months, dic["PresumedCurrentYrsAfter9Months"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PresumedNextYrsIn3Months", this.wRetirementStudio.wPresumedNextYear_In3Months.txtIn3Months, dic["PresumedNextYrsIn3Months"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PresumedNextYrsIn6Months", this.wRetirementStudio.wPresumedNextYear_In6Months.txtIn6Months, dic["PresumedNextYrsIn6Months"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PresumedNextYrsAfter9Months", this.wRetirementStudio.wPresumedNextYear_After9Months.txtAfter9Months, dic["PresumedNextYrsAfter9Months"], 0);
        
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("FullyFundedPriorYear2009FTAP", this.wRetirementStudio.wFullyFundedPriorYear2009FTAP.UITxtPriorYear2009FTAPEdit, dic["FullyFundedPriorYear2009FTAP"], 0);
                _gLib._VerifySyncUDWin("FullyFundedPriorYear2010FTAP", this.wRetirementStudio.wFullyFundedtPriorYear2010FTAP.UITxtPriorYear2010FTAPEdit, dic["FullyFundedPriorYear2010FTAP"], 0);
                _gLib._VerifySyncUDWin("FullyFundedCYExemption", this.wRetirementStudio.wFullyFundedCYExemption.txt.UINumEditorEdit1, dic["FullyFundedCYExemption"], 0);
                _gLib._VerifySyncUDWin("FullyFundedFTAPCYFTAP_Exempt", this.wRetirementStudio.wFullyFundedFTAPCYFTAP_Exempt.txt.UINumEditorEdit1, dic["FullyFundedFTAPCYFTAP_Exempt"], 0);
                _gLib._VerifySyncUDWin("FinalAFTAPCalculationFinalAFTAP", this.wRetirementStudio.wFinalAFTAP_FinalAFTAP.txtFinalAFTAP_FinalAFTAP, dic["FinalAFTAPCalculationFinalAFTAP"], 0);
                _gLib._VerifySyncUDWin("ShutDownAmountNeededTo60Percent", this.wRetirementStudio.wShutDownAmountNeededTo60Percent.txt.UINumEditorEdit1, dic["ShutDownAmountNeededTo60Percent"], 0);
                _gLib._VerifySyncUDWin("PlanAmendmentNeededTo80Percent", this.wRetirementStudio.wPlanAmendmentNeededTo80Percent.txt.UINumEditorEdit1, dic["PlanAmendmentNeededTo80Percent"], 0);
                _gLib._VerifySyncUDWin("AcceleratedBenefitDistriAllowed", this.wRetirementStudio.wAcceleratedBenefitDistri.cboAcceleratedDistriAllowed, dic["AcceleratedBenefitDistriAllowed"], 0);
                _gLib._VerifySyncUDWin("LimitationFundingCharge", this.wRetirementStudio.wLimitationFundingCharge.txt.UINumEditorEdit1, dic["LimitationFundingCharge"], 0);
                _gLib._VerifySyncUDWin("AddtitionalFundingToAvoid", this.wRetirementStudio.wAddtitionalFundingToAvoid.txt.UINumEditorEdit1, dic["AddtitionalFundingToAvoid"], 0);
                _gLib._VerifySyncUDWin("PresumedCurrentYrsTreatPlan", this.wRetirementStudio.wPresumedCurrentYear_TreatPlan.cboTreatPlan, dic["PresumedCurrentYrsTreatPlan"], 0);
                _gLib._VerifySyncUDWin("PresumedCurrentYrsIn3Months", this.wRetirementStudio.wPresumedCurrentYear_In3Months.txtIn3Months, dic["PresumedCurrentYrsIn3Months"], 0);
                _gLib._VerifySyncUDWin("PresumedCurrentYrsIn6Months", this.wRetirementStudio.wPresumedCurrentYear_In6Months.txtIn6Months, dic["PresumedCurrentYrsIn6Months"], 0);
                _gLib._VerifySyncUDWin("PresumedCurrentYrsAfter9Months", this.wRetirementStudio.wPresumedCurrentYear_After9Months.txtAfter9Months, dic["PresumedCurrentYrsAfter9Months"], 0);
                _gLib._VerifySyncUDWin("PresumedNextYrsIn3Months", this.wRetirementStudio.wPresumedNextYear_In3Months.txtIn3Months, dic["PresumedNextYrsIn3Months"], 0);
                _gLib._VerifySyncUDWin("PresumedNextYrsIn6Months", this.wRetirementStudio.wPresumedNextYear_In6Months.txtIn6Months, dic["PresumedNextYrsIn6Months"], 0);
                _gLib._VerifySyncUDWin("PresumedNextYrsAfter9Months", this.wRetirementStudio.wPresumedNextYear_After9Months.txtAfter9Months, dic["PresumedNextYrsAfter9Months"], 0);
   
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
