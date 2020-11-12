namespace RetirementStudio._UIMaps.FundingInformation_PYR_SummaryViewClasses
{
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;

    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Accessibility;
    using RetirementStudio._ThridParty;
    using System.Threading;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;

    public partial class FundingInformation_PYR_SummaryView
    {
        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();



        /// <summary>
        /// 2018-Sep-06 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("TargetNormalCost", "");
        ///    dic.Add("ShortfallAmortizationCharge", "");
        ///    dic.Add("FullFundingLimit", "");
        ///    dic.Add("MinimumBeforeUseOfCreditBalance", "");
        ///    dic.Add("EffectiveInterestRateLastYear", "");
        ///    dic.Add("EffectiveInterestRate2YearsAgo", "");
        ///    dic.Add("EffectiveInterestRate3YearsAgo", "");
        ///    pFundingInformation_PYR_SummaryView._PopVerify_MinimumContribution(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_MinimumContribution(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_MinimumContribution";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("TargetNormalCost", this.wRetirementStudio.wMinContrib_TargetNormalCost.txtTargetMormalCost, dic["TargetNormalCost"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ShortfallAmortizationCharge", this.wRetirementStudio.wMinContrib_ShortfallAmortizationCharge.txtShortfallAmortizationCharge, dic["ShortfallAmortizationCharge"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FullFundingLimit", this.wRetirementStudio.wMinContrib_FullFundingLimit.txtFullFundingLimit, dic["FullFundingLimit"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MinimumBeforeUseOfCreditBalance", this.wRetirementStudio.wMinContrib_MinimumBeforeUseOf.txtMinimumBeforeUseOf, dic["MinimumBeforeUseOfCreditBalance"], 0);
                _gLib._SetSyncUDWin_ByClipboard("EffectiveInterestRateLastYear", this.wRetirementStudio.wMinContrib_EIRLY.txtEIRLY, dic["EffectiveInterestRateLastYear"], 0);
                _gLib._SetSyncUDWin_ByClipboard("EffectiveInterestRate2YearsAgo", this.wRetirementStudio.wMinContrib_EIR2YrsAgo.txtEIR2YrsAgo, dic["EffectiveInterestRate2YearsAgo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("EffectiveInterestRate3YearsAgo", this.wRetirementStudio.wMinContrib_EIR3YrsAgo.txtEIR3YrsAgo, dic["EffectiveInterestRate3YearsAgo"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("TargetNormalCost", this.wRetirementStudio.wMinContrib_TargetNormalCost.txtTargetMormalCost, dic["TargetNormalCost"], 0);
                _gLib._VerifySyncUDWin("ShortfallAmortizationCharge", this.wRetirementStudio.wMinContrib_ShortfallAmortizationCharge.txtShortfallAmortizationCharge, dic["ShortfallAmortizationCharge"], 0);
                _gLib._VerifySyncUDWin("FullFundingLimit", this.wRetirementStudio.wMinContrib_FullFundingLimit.txtFullFundingLimit, dic["FullFundingLimit"], 0);
                _gLib._VerifySyncUDWin("MinimumBeforeUseOfCreditBalance", this.wRetirementStudio.wMinContrib_MinimumBeforeUseOf.txtMinimumBeforeUseOf, dic["MinimumBeforeUseOfCreditBalance"], 0);
                _gLib._VerifySyncUDWin("EffectiveInterestRateLastYear", this.wRetirementStudio.wMinContrib_EIRLY.txtEIRLY, dic["EffectiveInterestRateLastYear"], 0);
                _gLib._VerifySyncUDWin("EffectiveInterestRate2YearsAgo", this.wRetirementStudio.wMinContrib_EIR2YrsAgo.txtEIR2YrsAgo, dic["EffectiveInterestRate2YearsAgo"], 0);
                _gLib._VerifySyncUDWin("EffectiveInterestRate3YearsAgo", this.wRetirementStudio.wMinContrib_EIR3YrsAgo.txtEIR3YrsAgo, dic["EffectiveInterestRate3YearsAgo"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2018-Sep-06 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AtRiskProng1", "");
        ///    dic.Add("AtRiskProng2", "");
        ///    dic.Add("AdjustedFTAP", "");
        ///    dic.Add("ConsecutiveYearsAtRisk", "");
        ///    dic.Add("AtRiskPercentageReflectedInMinimumFunidng", "");
        ///    dic.Add("AtRiskIn2OfPrior4Years", "Yes");
        ///    pFundingInformation_PYR_SummaryView._PopVerify_FTAP(dic);
        ///    
        /// </summary>
       /// 
        
        /// <param name="dic"></param>
        public void _PopVerify_FTAP(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FTAP";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("AtRiskProng1", this.wRetirementStudio.wFTAP_AtRiskProng1.txtAtRiskProng1, dic["AtRiskProng1"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AtRiskProng2", this.wRetirementStudio.wFTAP_AtRiskProng2.txtAtRiskProng2, dic["AtRiskProng2"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AdjustedFTAP", this.wRetirementStudio.wFTAP_AdjFTAP.txtAdjFTAP, dic["AdjustedFTAP"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ConsecutiveYearsAtRisk", this.wRetirementStudio.wFTAP_ConsecutiveYrs.txtConsecutiveYrs, dic["ConsecutiveYearsAtRisk"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AtRiskPercentageReflectedInMinimumFunidng", this.wRetirementStudio.wFTAP_AtRiskPercentage.txtAtRiskPercentage, dic["AtRiskPercentageReflectedInMinimumFunidng"], 0);
                _gLib._SetSyncUDWin("AtRiskIn2OfPrior4Years", this.wRetirementStudio.wFTAP_AtRiskIn2Of.cboAtRiskIn2Of, dic["AtRiskIn2OfPrior4Years"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("AtRiskProng1", this.wRetirementStudio.wFTAP_AtRiskProng1.txtAtRiskProng1, dic["AtRiskProng1"], 0);
                _gLib._VerifySyncUDWin("AtRiskProng2", this.wRetirementStudio.wFTAP_AtRiskProng2.txtAtRiskProng2, dic["AtRiskProng2"], 0);
                _gLib._VerifySyncUDWin("AdjustedFTAP", this.wRetirementStudio.wMinContrib_FullFundingLimit.txtFullFundingLimit, dic["AdjustedFTAP"], 0);
                _gLib._VerifySyncUDWin("ConsecutiveYearsAtRisk", this.wRetirementStudio.wFTAP_ConsecutiveYrs.txtConsecutiveYrs, dic["ConsecutiveYearsAtRisk"], 0);
                _gLib._VerifySyncUDWin("AtRiskPercentageReflectedInMinimumFunidng", this.wRetirementStudio.wFTAP_AtRiskPercentage.txtAtRiskPercentage, dic["AtRiskPercentageReflectedInMinimumFunidng"], 0);
                _gLib._VerifySyncUDWin("AtRiskIn2OfPrior4Years", this.wRetirementStudio.wFTAP_AtRiskIn2Of.cboAtRiskIn2Of, dic["AtRiskIn2OfPrior4Years"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2018-Sep-06 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("MarketValue", "");
        ///    dic.Add("ActuarialValue", "");
        ///    pFundingInformation_PYR_SummaryView._PopVerify_Assets(dic);
        ///    
        /// </summary>
        /// 

        /// <param name="dic"></param>
        public void _PopVerify_Assets(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Assets";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("MarketValue", this.wRetirementStudio.wAssets_MarketValue.txtMarketValue, dic["MarketValue"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ActuarialValue", this.wRetirementStudio.wAssets_ActuarialValue.txtActuarialValue, dic["ActuarialValue"], 0);
             }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("MarketValue", this.wRetirementStudio.wAssets_MarketValue.txtMarketValue, dic["MarketValue"], 0);
                _gLib._VerifySyncUDWin("ActuarialValue", this.wRetirementStudio.wAssets_ActuarialValue.txtActuarialValue, dic["ActuarialValue"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2018-Sep-06 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("COBAfterWaiver", "");
        ///    dic.Add("PFBAfterWaiver", "");
        ///    dic.Add("NetAssetsForFundingShortfall", "");
        ///    dic.Add("FundingShortfallAmount", "");
        ///    dic.Add("TransitionPercentage", "");
        ///    dic.Add("TransitionFundingTargetLiability", "");    
        ///    dic.Add("TransitionFundingShortfall", "");       ///    
        ///    pFundingInformation_PYR_SummaryView._PopVerify_NetAssets(dic);
        ///    
        /// </summary>
        /// 

        /// <param name="dic"></param>
        public void _PopVerify_NetAssets(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_NetAssets";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("COBAfterWaiver", this.wRetirementStudio.wNetAssets_COBAfter.txtCOBAfter, dic["COBAfterWaiver"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PFBAfterWaiver", this.wRetirementStudio.wNetAssets_PFBAfter.txtPFBAfter, dic["PFBAfterWaiver"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NetAssetsForFundingShortfall", this.wRetirementStudio.wNetAssets_NetAssetsFor.txtNetAssetsFor, dic["NetAssetsForFundingShortfall"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FundingShortfallAmount", this.wRetirementStudio.wNetAssets_FundingShortfallAmount.txtFundingShortfallAmount, dic["FundingShortfallAmount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TransitionPercentage", this.wRetirementStudio.wNetAssets_TransitionPercentage.txtTransitionPercentage, dic["TransitionPercentage"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TransitionFundingTargetLiability", this.wRetirementStudio.wNetAssets_TransitionFundingTargetLiab.txtTransitionFundingTargetLiab, dic["TransitionFundingTargetLiability"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TransitionFundingShortfall", this.wRetirementStudio.wNetAssets_TransitionFundingShortfall.txtTransitionFundingShortfall, dic["TransitionFundingShortfall"], 0);
            
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("COBAfterWaiver", this.wRetirementStudio.wNetAssets_COBAfter.txtCOBAfter, dic["COBAfterWaiver"], 0);
                _gLib._VerifySyncUDWin("PFBAfterWaiver", this.wRetirementStudio.wNetAssets_PFBAfter.txtPFBAfter, dic["PFBAfterWaiver"], 0);
                _gLib._VerifySyncUDWin("NetAssetsForFundingShortfall", this.wRetirementStudio.wNetAssets_NetAssetsFor.txtNetAssetsFor, dic["NetAssetsForFundingShortfall"], 0);
                _gLib._VerifySyncUDWin("FundingShortfallAmount", this.wRetirementStudio.wNetAssets_FundingShortfallAmount.txtFundingShortfallAmount, dic["FundingShortfallAmount"], 0);
                _gLib._VerifySyncUDWin("TransitionPercentage", this.wRetirementStudio.wNetAssets_TransitionPercentage.txtTransitionPercentage, dic["TransitionPercentage"], 0);
                _gLib._VerifySyncUDWin("TransitionFundingTargetLiability", this.wRetirementStudio.wNetAssets_TransitionFundingTargetLiab.txtTransitionFundingTargetLiab, dic["TransitionFundingTargetLiability"], 0);
                _gLib._VerifySyncUDWin("TransitionFundingShortfall", this.wRetirementStudio.wNetAssets_TransitionFundingShortfall.txtTransitionFundingShortfall, dic["TransitionFundingShortfall"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2018-Sep-06 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("BeginningOfTheYearBalance", "");
        ///    pFundingInformation_PYR_SummaryView._PopVerify_PrefundingBalance(dic);
        ///    
        /// </summary>
        /// 

        /// <param name="dic"></param>
        public void _PopVerify_PrefundingBalance(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PrefundingBalance";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("BeginningOfTheYearBalance", this.wRetirementStudio.wPreFundingBalance_BeginningOf.txtBeginningOf, dic["BeginningOfTheYearBalance"], 0);
            }
         
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("BeginningOfTheYearBalance", this.wRetirementStudio.wPreFundingBalance_BeginningOf.txtBeginningOf, dic["BeginningOfTheYearBalance"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2018-Sep-06 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FundingTarget", "");
        ///    dic.Add("CushionAmount", "");
        ///    dic.Add("PreliminaryDeductibleAmount", "");
        ///    dic.Add("MaximumDeductibleAmount", "");
        ///    pFundingInformation_PYR_SummaryView._PopVerify_MaximumDeductibleContribution(dic);
        ///    
        /// </summary>
        /// 

        /// <param name="dic"></param>
        public void _PopVerify_MaximumDeductibleContribution(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_MaximumDeductibleContribution";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("FundingTarget", this.wRetirementStudio.wMaxDeductibleContrib_FundingTarget.txtFundingTarget, dic["FundingTarget"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CushionAmount", this.wRetirementStudio.wMaxDeductibleContrib_CushionAmount.txtCushionAmount, dic["CushionAmount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PreliminaryDeductibleAmount", this.wRetirementStudio.wMaxDeductibleContrib_PreliminaryDeductibleAmount.txtPreliminaryDeductibleAmount, dic["PreliminaryDeductibleAmount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MaximumDeductibleAmount", this.wRetirementStudio.wMaxDeductibleContrib_MaxDeductibleAmount.txtMaxDeductibleAmount, dic["MaximumDeductibleAmount"], 0);
 
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("FundingTarget", this.wRetirementStudio.wMaxDeductibleContrib_FundingTarget.txtFundingTarget, dic["FundingTarget"], 0);
                _gLib._VerifySyncUDWin("CushionAmount", this.wRetirementStudio.wMaxDeductibleContrib_CushionAmount.txtCushionAmount, dic["CushionAmount"], 0);
                _gLib._VerifySyncUDWin("PreliminaryDeductibleAmount", this.wRetirementStudio.wMaxDeductibleContrib_PreliminaryDeductibleAmount.txtPreliminaryDeductibleAmount, dic["PreliminaryDeductibleAmount"], 0);
                _gLib._VerifySyncUDWin("MaximumDeductibleAmount", this.wRetirementStudio.wMaxDeductibleContrib_MaxDeductibleAmount.txtMaxDeductibleAmount, dic["MaximumDeductibleAmount"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2018-Sep-06 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("InactivesInPayStatus", "");
        ///    dic.Add("InactivesInDefStatus", "");
        ///    dic.Add("VestedActives", "");
        ///    dic.Add("Total", "");
        ///    dic.Add("OfParticipantsInAllControlledGroupPlans", ""); 
        ///    pFundingInformation_PYR_SummaryView._PopVerify_ParticipantData(dic);
        ///    
        /// </summary>
        /// 

        /// <param name="dic"></param>
        public void _PopVerify_ParticipantData(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ParticipantData";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("InactivesInPayStatus", this.wRetirementStudio.wParticipantData_InactivesInPayStatus.txtInactivesInPayStatus, dic["InactivesInPayStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InactivesInDefStatus", this.wRetirementStudio.wParticipantData_InactivesInDefStatus.txtInactivesInDefStatus, dic["InactivesInDefStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("VestedActives", this.wRetirementStudio.wParticipantData_VestedActives.txtVestedActives, dic["VestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Total", this.wRetirementStudio.wParticipantData_Total.txtTotal, dic["Total"], 0);
                _gLib._SetSyncUDWin_ByClipboard("OfParticipantsInAllControlledGroupPlans", this.wRetirementStudio.wParticipantData_OfPartcipantsInAll.txtOfPartcipantsInAll, dic["OfParticipantsInAllControlledGroupPlans"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("InactivesInPayStatus", this.wRetirementStudio.wParticipantData_InactivesInPayStatus.txtInactivesInPayStatus, dic["InactivesInPayStatus"], 0);
                _gLib._VerifySyncUDWin("InactivesInDefStatus", this.wRetirementStudio.wParticipantData_InactivesInDefStatus.txtInactivesInDefStatus, dic["InactivesInDefStatus"], 0);
                _gLib._VerifySyncUDWin("VestedActives", this.wRetirementStudio.wParticipantData_VestedActives.txtVestedActives, dic["VestedActives"], 0);
                _gLib._VerifySyncUDWin("Total", this.wRetirementStudio.wParticipantData_Total.txtTotal, dic["Total"], 0);
                _gLib._VerifySyncUDWin("OfParticipantsInAllControlledGroupPlans", this.wRetirementStudio.wParticipantData_OfPartcipantsInAll.txtOfPartcipantsInAll, dic["OfParticipantsInAllControlledGroupPlans"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2018-Sep-06 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PBGCParticipantCount", "");
        ///    dic.Add("PBGCFlatRatePremiumPerParticipant", "");
        ///    dic.Add("PBGCFlatRatePremium", "");
        ///    dic.Add("PBGCTargetLiability", "");
        ///    dic.Add("UnfundedPBGCTargetLiability", ""); 
        ///    dic.Add("VariableRatePremium", ""); 
        ///    dic.Add("CombinedPBGCPremium", ""); 
        ///    pFundingInformation_PYR_SummaryView._PopVerify_PBGCPremiumsAndFillingRequirements(dic);
        ///    
        /// </summary>
        /// 

        /// <param name="dic"></param>
        public void _PopVerify_PBGCPremiumsAndFillingRequirements(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PBGCPremiumsAndFillingRequirements";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("PBGCParticipantCount", this.wRetirementStudio.wPBGCPremium_PBGCParticipantCount.txtPBGCParticipantCount, dic["PBGCParticipantCount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCFlatRatePremiumPerParticipant", this.wRetirementStudio.wPBGCPremium_PBGCFlatRatePremiumPerParticipant.txtPBGCFlatRatePremiumPerParticipant, dic["PBGCFlatRatePremiumPerParticipant"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCFlatRatePremium", this.wRetirementStudio.wPBGCPremium_PBGCFlatRatePremium.txtPBGCFlatRatePremium, dic["PBGCFlatRatePremium"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCTargetLiability", this.wRetirementStudio.wPBGCPremium_PBGCTargetLiab.txtPBGCTargetLiab, dic["PBGCTargetLiability"], 0);
                _gLib._SetSyncUDWin_ByClipboard("UnfundedPBGCTargetLiability", this.wRetirementStudio.wPBGCPremium_UnfundedPBGC.txtUnfundedPBGC, dic["UnfundedPBGCTargetLiability"], 0);
                _gLib._SetSyncUDWin_ByClipboard("VariableRatePremium", this.wRetirementStudio.wPBGCPremium_VariableRatePremium.txtVariableRatePremium, dic["VariableRatePremium"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CombinedPBGCPremium", this.wRetirementStudio.wPBGCPremium_CombinedPBGCPremium.txtCombinedPBGCPremium, dic["CombinedPBGCPremium"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("PBGCParticipantCount", this.wRetirementStudio.wParticipantData_InactivesInPayStatus.txtInactivesInPayStatus, dic["PBGCParticipantCount"], 0);
                _gLib._VerifySyncUDWin("PBGCFlatRatePremiumPerParticipant", this.wRetirementStudio.wParticipantData_InactivesInDefStatus.txtInactivesInDefStatus, dic["PBGCFlatRatePremiumPerParticipant"], 0);
                _gLib._VerifySyncUDWin("PBGCFlatRatePremium", this.wRetirementStudio.wParticipantData_VestedActives.txtVestedActives, dic["PBGCFlatRatePremium"], 0);
                _gLib._VerifySyncUDWin("PBGCTargetLiability", this.wRetirementStudio.wParticipantData_Total.txtTotal, dic["PBGCTargetLiability"], 0);
                _gLib._VerifySyncUDWin("UnfundedPBGCTargetLiability", this.wRetirementStudio.wParticipantData_OfPartcipantsInAll.txtOfPartcipantsInAll, dic["UnfundedPBGCTargetLiability"], 0);
                _gLib._VerifySyncUDWin("VariableRatePremium", this.wRetirementStudio.wParticipantData_OfPartcipantsInAll.txtOfPartcipantsInAll, dic["VariableRatePremium"], 0);
                _gLib._VerifySyncUDWin("CombinedPBGCPremium", this.wRetirementStudio.wParticipantData_OfPartcipantsInAll.txtOfPartcipantsInAll, dic["CombinedPBGCPremium"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

    }
}
