namespace RetirementStudio._UIMaps.FundingInformation_PYR_PreliminaryResultsClasses
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


    public partial class FundingInformation_PYR_PreliminaryResults
    {
        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OriginalPlanEffectDate", "01/01/1978");
        ///    dic.Add("BeginningOfPlanYear", "01/01/2011");
        ///    dic.Add("EndOfPlanYear", "12/31/2011");
        ///    dic.Add("ValuationDate", "01/01/2011");
        ///    dic.Add("ValuationYear", "2012");
        ///    dic.Add("PlanTotallyFrozen", "");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_PlanDates(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PlanDates(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PlanDates";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("OriginalPlanEffectDate", this.wRetirementStudio.wPlanDates_OriginalPlanEffectDate.cbo.txtOriginalPlanEffectDate, dic["OriginalPlanEffectDate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BeginningOfPlanYear", this.wRetirementStudio.wPlanDates_BeginningOfPlanYear.cbo.txtBeginningOfPlanYear, dic["BeginningOfPlanYear"], 0);
                _gLib._SetSyncUDWin_ByClipboard("EndOfPlanYear", this.wRetirementStudio.wPlanDates_EndOfPlanYear.cbo.txtEndOfPlanYear, dic["EndOfPlanYear"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ValuationDate", this.wRetirementStudio.wPlanDates_ValuationDate.cbo.txtValuationDate, dic["ValuationDate"], 0);
                _gLib._SetSyncUDWin("ValuationYear", this.wRetirementStudio.wPlanDates_ValuationYear.cboValuationYear, dic["ValuationYear"], 0);
                _gLib._SetSyncUDWin("PlanTotallyFrozen", this.wRetirementStudio.wPlanDates_PlanTotallyFrozen.cboPlanTotallyFrozen, dic["PlanTotallyFrozen"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("OriginalPlanEffectDate", this.wRetirementStudio.wPlanDates_OriginalPlanEffectDate.cbo.txtOriginalPlanEffectDate, dic["OriginalPlanEffectDate"], 0);
                _gLib._VerifySyncUDWin("BeginningOfPlanYear", this.wRetirementStudio.wPlanDates_BeginningOfPlanYear.cbo.txtBeginningOfPlanYear, dic["BeginningOfPlanYear"], 0);
                _gLib._VerifySyncUDWin("EndOfPlanYear", this.wRetirementStudio.wPlanDates_EndOfPlanYear.cbo.txtEndOfPlanYear, dic["EndOfPlanYear"], 0);
                _gLib._VerifySyncUDWin("ValuationDate", this.wRetirementStudio.wPlanDates_ValuationDate.cbo.txtValuationDate, dic["ValuationDate"], 0);
                _gLib._VerifySyncUDWin("ValuationYear", this.wRetirementStudio.wPlanDates_ValuationYear.cboValuationYear, dic["ValuationYear"], 0);
                _gLib._VerifySyncUDWin("PlanTotallyFrozen", this.wRetirementStudio.wPlanDates_PlanTotallyFrozen.cboPlanTotallyFrozen, dic["PlanTotallyFrozen"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FullyFundedFTAPExempt92Percent", "");
        ///    dic.Add("FullyFundedFTAPExempt94Percent", "");
        ///    dic.Add("FullyFundedFTAPExempt96Percent", "");
        ///    dic.Add("AcceleratedDistributionAllowed", "");
        ///    dic.Add("AddtitionalFundingDoRestrictions", "");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_FullyFunded(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_FullyFunded(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PlanDates";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("FullyFundedFTAPExempt92Percent", this.wRetirementStudio.wFully_PriorYear2008FTAP.txt, dic["FullyFundedFTAPExempt92Percent"], 0);
                _gLib._SetSyncUDWin("FullyFundedFTAPExempt94Percent", this.wRetirementStudio.wFully_PriorYear2009FTAP.txt, dic["FullyFundedFTAPExempt94Percent"], 0);
                _gLib._SetSyncUDWin("FullyFundedFTAPExempt96Percent", this.wRetirementStudio.wFully_PriorYear2010FTAP.txt, dic["FullyFundedFTAPExempt96Percent"], 0);
                _gLib._SetSyncUDWin("AcceleratedDistributionAllowed", this.wRetirementStudio.wAccelerated_Allowed.cbo, dic["AcceleratedDistributionAllowed"], 0);
                _gLib._SetSyncUDWin("AddtitionalFundingDoRestrictions", this.wRetirementStudio.wAddtitionalFunding_DoRestrictions.cbo, dic["AddtitionalFundingDoRestrictions"], 0);
            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("FullyFundedFTAPExempt92Percent", this.wRetirementStudio.wFully_PriorYear2008FTAP.txt, dic["FullyFundedFTAPExempt92Percent"], 0);
                _gLib._VerifySyncUDWin("FullyFundedFTAPExempt94Percent", this.wRetirementStudio.wFully_PriorYear2009FTAP.txt, dic["FullyFundedFTAPExempt94Percent"], 0);
                _gLib._VerifySyncUDWin("FullyFundedFTAPExempt96Percent", this.wRetirementStudio.wFully_PriorYear2010FTAP.txt, dic["FullyFundedFTAPExempt96Percent"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PBGCFlatRate_ParticipantCount", "125");
        ///    dic.Add("PBGCFlatRate_PerParticipant", "33");
        ///    dic.Add("PBGCFlatRate_FlatRatePremium", "4,125");
        ///    dic.Add("NotAtRisk_InPayStatus", "2,193,447");
        ///    dic.Add("NotAtRisk_DeferredStatus", "3,418,800");
        ///    dic.Add("NotAtRisk_VestedActives", "3,381,352");
        ///    dic.Add("NotAtRisk_Total", "8,993,599");
        ///    dic.Add("ExpenseLoad_InPayStatus", "");
        ///    dic.Add("ExpenseLoad_DeferredStatus", "");
        ///    dic.Add("ExpenseLoad_VestedActives", "");
        ///    dic.Add("ExpenseLoad_Total", "");
        ///    dic.Add("AtRiskNoExpense_InPayStatus", "");
        ///    dic.Add("AtRiskNoExpense_DeferredStatus", "");
        ///    dic.Add("AtRiskNoExpense_VestedActives", "");
        ///    dic.Add("AtRiskNoExpense_Total", "");
        ///    dic.Add("AtRiskWithExpense_InPayStatus", "");
        ///    dic.Add("AtRiskWithExpense_DeferredStatus", "");
        ///    dic.Add("AtRiskWithExpense_VestedActives", "");
        ///    dic.Add("AtRiskWithExpense_Total", "");
        ///    dic.Add("FinalAtRisk_InPayStatus", "");
        ///    dic.Add("FinalAtRisk_DeferredStatus", "");
        ///    dic.Add("FinalAtRisk_VestedActives", "");
        ///    dic.Add("FinalAtRisk_Total", "");
        ///    dic.Add("PBGCTarget_InpayStatus", "2,193,447");
        ///    dic.Add("PBGCTarget_DeferredStatus", "3,418,800");
        ///    dic.Add("PBGCTarget_VestedActives", "3,381,352");
        ///    dic.Add("PBGCTarget_Total", "8,993,599");
        ///    dic.Add("PBGCTarget_MVofAssets", "6,449,268");
        ///    dic.Add("PBGCVariable_Unfunded", "1,811,000");
        ///    dic.Add("PBGCVariable_9Per1000", "16,299");
        ///    dic.Add("PBGCVariable_NumOfEE", "125");
        ///    dic.Add("PBGCVariable_ParticipantCount", "125");
        ///    dic.Add("PBGCVariable_PerParticipant", "");
        ///    dic.Add("PBGCVariable_PBGCVariable", "16,299");
        ///    dic.Add("PBGCVariable_CombinedPBGC", "20,424");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_PGBCPremiums(dic);
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PGBCPremiums(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PGBCPremiums";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin_ByClipboard("PBGCFlatRate_ParticipantCount", this.wRetirementStudio.wPBGC_PBGCFlatRate_ParticipantCount.txtPBGCFlatRate_ParticipantCount, dic["PBGCFlatRate_ParticipantCount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCFlatRate_PerParticipant", this.wRetirementStudio.wPBGC_PBGCFlatRate_PerParticipant.txtPBGCFlatRate_PerParticipant, dic["PBGCFlatRate_PerParticipant"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCFlatRate_FlatRatePremium", this.wRetirementStudio.wPBGC_PBGCFlatRate_FlatRatePremium.txtPBGCFlatRate_FlatRatePremium, dic["PBGCFlatRate_FlatRatePremium"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NotAtRisk_InPayStatus", this.wRetirementStudio.wPBGC_NotAtRisk_InPayStatus.txtNotAtRisk_InPayStatus, dic["NotAtRisk_InPayStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NotAtRisk_DeferredStatus", this.wRetirementStudio.wPBGC_NotAtRisk_DeferredStatus.txtNotAtRisk_DeferredStatus, dic["NotAtRisk_DeferredStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NotAtRisk_VestedActives", this.wRetirementStudio.wPBGC_NotAtRisk_VestedActives.txtNotAtRisk_VestedActives, dic["NotAtRisk_VestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NotAtRisk_Total", this.wRetirementStudio.wPBGC_NotAtRisk_Total.txtNotAtRisk_Total, dic["NotAtRisk_Total"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ExpenseLoad_InPayStatus", this.wRetirementStudio.wPBGC_ExpenseLoad_InPayStatus.txtExpenseLoad_InPayStatus, dic["ExpenseLoad_InPayStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ExpenseLoad_DeferredStatus", this.wRetirementStudio.wPBGC_ExpenseLoad_DeferredStatus.txtExpenseLoad_DeferredStatus, dic["ExpenseLoad_DeferredStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ExpenseLoad_VestedActives", this.wRetirementStudio.wPBGC_ExpenseLoad_VestedActives.txtExpenseLoad_VestedActives, dic["ExpenseLoad_VestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ExpenseLoad_Total", this.wRetirementStudio.wPBGC_ExpenseLoad_Total.txtExpenseLoad_Total, dic["ExpenseLoad_Total"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AtRiskNoExpense_InPayStatus", this.wRetirementStudio.wPBGC_AtRiskNoExpense_InPayStatus.txtAtRiskNoExpense_InPayStatus, dic["AtRiskNoExpense_InPayStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AtRiskNoExpense_DeferredStatus", this.wRetirementStudio.wPBGC_AtRiskNoExpense_DeferredStatus.txtAtRiskNoExpense_DeferredStatus, dic["AtRiskNoExpense_DeferredStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AtRiskNoExpense_VestedActives", this.wRetirementStudio.wPBGC_AtRiskNoExpense_VestedActives.txtAtRiskNoExpense_VestedActives, dic["AtRiskNoExpense_VestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AtRiskNoExpense_Total", this.wRetirementStudio.wPBGC_AtRiskNoExpense_Total.txtAtRiskNoExpense_Total, dic["AtRiskNoExpense_Total"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AtRiskWithExpense_InPayStatus", this.wRetirementStudio.wPBGC_AtRiskWithExpense_InPayStatus.txtAtRiskWithExpense_InPayStatus, dic["AtRiskWithExpense_InPayStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AtRiskWithExpense_DeferredStatus", this.wRetirementStudio.wPBGC_AtRiskWithExpense_DeferredStatus.txtAtRiskWithExpense_DeferredStatus, dic["AtRiskWithExpense_DeferredStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AtRiskWithExpense_VestedActives", this.wRetirementStudio.wPBGC_AtRiskWithExpense_VestedActives.txtAtRiskWithExpense_VestedActives, dic["AtRiskWithExpense_VestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AtRiskWithExpense_Total", this.wRetirementStudio.wPBGC_AtRiskWithExpense_Total.txtAtRiskWithExpense_Total, dic["AtRiskWithExpense_Total"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FinalAtRisk_InPayStatus", this.wRetirementStudio.wPBGC_FinalAtRisk_InPayStatus.txtFinalAtRisk_InPayStatus, dic["FinalAtRisk_InPayStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FinalAtRisk_DeferredStatus", this.wRetirementStudio.wPBGC_FinalAtRisk_DeferredStatus.txtFinalAtRisk_DeferredStatus, dic["FinalAtRisk_DeferredStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FinalAtRisk_VestedActives", this.wRetirementStudio.wPBGC_FinalAtRisk_VestedActives.txtFinalAtRisk_VestedActives, dic["FinalAtRisk_VestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FinalAtRisk_Total", this.wRetirementStudio.wPBGC_FinalAtRisk_Total.txtFinalAtRisk_Total, dic["FinalAtRisk_Total"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCTarget_InpayStatus", this.wRetirementStudio.wPBGC_PBGCTarget_InpayStatus.txtPBGCTarget_InpayStatus, dic["PBGCTarget_InpayStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCTarget_DeferredStatus", this.wRetirementStudio.wPBGC_PBGCTarget_DeferredStatus.txtPBGCTarget_DeferredStatus, dic["PBGCTarget_DeferredStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCTarget_VestedActives", this.wRetirementStudio.wPBGC_PBGCTarget_VestedActives.txtPBGCTarget_VestedActives, dic["PBGCTarget_VestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCTarget_Total", this.wRetirementStudio.wPBGC_PBGCTarget_Total.txtPBGCTarget_Total, dic["PBGCTarget_Total"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCTarget_MVofAssets", this.wRetirementStudio.wPBGC_PBGCTarget_MVofAssets.txtPBGCTarget_MVofAssets, dic["PBGCTarget_MVofAssets"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCVariable_Unfunded", this.wRetirementStudio.wPBGC_PBGCVariable_Unfunded.txtPBGCVariable_Unfunded, dic["PBGCVariable_Unfunded"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCVariable_9Per1000", this.wRetirementStudio.wPBGC_PBGCVariable_9Per1000.txtPBGCVariable_9Per1000, dic["PBGCVariable_9Per1000"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCVariable_NumOfEE", this.wRetirementStudio.wPBGC_PBGCVariable_NumOfEE.txtPBGCVariable_NumOfEE, dic["PBGCVariable_NumOfEE"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCVariable_ParticipantCount", this.wRetirementStudio.wPBGC_PBGCVariable_ParticipantCount.txtPBGCVariable_ParticipantCount, dic["PBGCVariable_ParticipantCount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCVariable_PerParticipant", this.wRetirementStudio.wPBGC_PBGCVariable_PerParticipant.txtPBGCVariable_PerParticipant, dic["PBGCVariable_PerParticipant"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCVariable_PBGCVariable", this.wRetirementStudio.wPBGC_PBGCVariable_PBGCVariable.txtPBGCVariable_PBGCVariable, dic["PBGCVariable_PBGCVariable"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PBGCVariable_CombinedPBGC", this.wRetirementStudio.wPBGC_PBGCVariable_CombinedPBGC.txtPBGCVariable_CombinedPBGC, dic["PBGCVariable_CombinedPBGC"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("PBGCFlatRate_ParticipantCount", this.wRetirementStudio.wPBGC_PBGCFlatRate_ParticipantCount.txtPBGCFlatRate_ParticipantCount, dic["PBGCFlatRate_ParticipantCount"], 0);
                _gLib._VerifySyncUDWin("PBGCFlatRate_PerParticipant", this.wRetirementStudio.wPBGC_PBGCFlatRate_PerParticipant.txtPBGCFlatRate_PerParticipant, dic["PBGCFlatRate_PerParticipant"], 0);
                _gLib._VerifySyncUDWin("PBGCFlatRate_FlatRatePremium", this.wRetirementStudio.wPBGC_PBGCFlatRate_FlatRatePremium.txtPBGCFlatRate_FlatRatePremium, dic["PBGCFlatRate_FlatRatePremium"], 0);
                _gLib._VerifySyncUDWin("NotAtRisk_InPayStatus", this.wRetirementStudio.wPBGC_NotAtRisk_InPayStatus.txtNotAtRisk_InPayStatus, dic["NotAtRisk_InPayStatus"], 0);
                _gLib._VerifySyncUDWin("NotAtRisk_DeferredStatus", this.wRetirementStudio.wPBGC_NotAtRisk_DeferredStatus.txtNotAtRisk_DeferredStatus, dic["NotAtRisk_DeferredStatus"], 0);
                _gLib._VerifySyncUDWin("NotAtRisk_VestedActives", this.wRetirementStudio.wPBGC_NotAtRisk_VestedActives.txtNotAtRisk_VestedActives, dic["NotAtRisk_VestedActives"], 0);
                _gLib._VerifySyncUDWin("NotAtRisk_Total", this.wRetirementStudio.wPBGC_NotAtRisk_Total.txtNotAtRisk_Total, dic["NotAtRisk_Total"], 0);
                _gLib._VerifySyncUDWin("ExpenseLoad_InPayStatus", this.wRetirementStudio.wPBGC_ExpenseLoad_InPayStatus.txtExpenseLoad_InPayStatus, dic["ExpenseLoad_InPayStatus"], 0);
                _gLib._VerifySyncUDWin("ExpenseLoad_DeferredStatus", this.wRetirementStudio.wPBGC_ExpenseLoad_DeferredStatus.txtExpenseLoad_DeferredStatus, dic["ExpenseLoad_DeferredStatus"], 0);
                _gLib._VerifySyncUDWin("ExpenseLoad_VestedActives", this.wRetirementStudio.wPBGC_ExpenseLoad_VestedActives.txtExpenseLoad_VestedActives, dic["ExpenseLoad_VestedActives"], 0);
                _gLib._VerifySyncUDWin("ExpenseLoad_Total", this.wRetirementStudio.wPBGC_ExpenseLoad_Total.txtExpenseLoad_Total, dic["ExpenseLoad_Total"], 0);
                _gLib._VerifySyncUDWin("AtRiskNoExpense_InPayStatus", this.wRetirementStudio.wPBGC_AtRiskNoExpense_InPayStatus.txtAtRiskNoExpense_InPayStatus, dic["AtRiskNoExpense_InPayStatus"], 0);
                _gLib._VerifySyncUDWin("AtRiskNoExpense_DeferredStatus", this.wRetirementStudio.wPBGC_AtRiskNoExpense_DeferredStatus.txtAtRiskNoExpense_DeferredStatus, dic["AtRiskNoExpense_DeferredStatus"], 0);
                _gLib._VerifySyncUDWin("AtRiskNoExpense_VestedActives", this.wRetirementStudio.wPBGC_AtRiskNoExpense_VestedActives.txtAtRiskNoExpense_VestedActives, dic["AtRiskNoExpense_VestedActives"], 0);
                _gLib._VerifySyncUDWin("AtRiskNoExpense_Total", this.wRetirementStudio.wPBGC_AtRiskNoExpense_Total.txtAtRiskNoExpense_Total, dic["AtRiskNoExpense_Total"], 0);
                _gLib._VerifySyncUDWin("AtRiskWithExpense_InPayStatus", this.wRetirementStudio.wPBGC_AtRiskWithExpense_InPayStatus.txtAtRiskWithExpense_InPayStatus, dic["AtRiskWithExpense_InPayStatus"], 0);
                _gLib._VerifySyncUDWin("AtRiskWithExpense_DeferredStatus", this.wRetirementStudio.wPBGC_AtRiskWithExpense_DeferredStatus.txtAtRiskWithExpense_DeferredStatus, dic["AtRiskWithExpense_DeferredStatus"], 0);
                _gLib._VerifySyncUDWin("AtRiskWithExpense_VestedActives", this.wRetirementStudio.wPBGC_AtRiskWithExpense_VestedActives.txtAtRiskWithExpense_VestedActives, dic["AtRiskWithExpense_VestedActives"], 0);
                _gLib._VerifySyncUDWin("AtRiskWithExpense_Total", this.wRetirementStudio.wPBGC_AtRiskWithExpense_Total.txtAtRiskWithExpense_Total, dic["AtRiskWithExpense_Total"], 0);
                _gLib._VerifySyncUDWin("FinalAtRisk_InPayStatus", this.wRetirementStudio.wPBGC_FinalAtRisk_InPayStatus.txtFinalAtRisk_InPayStatus, dic["FinalAtRisk_InPayStatus"], 0);
                _gLib._VerifySyncUDWin("FinalAtRisk_DeferredStatus", this.wRetirementStudio.wPBGC_FinalAtRisk_DeferredStatus.txtFinalAtRisk_DeferredStatus, dic["FinalAtRisk_DeferredStatus"], 0);
                _gLib._VerifySyncUDWin("FinalAtRisk_VestedActives", this.wRetirementStudio.wPBGC_FinalAtRisk_VestedActives.txtFinalAtRisk_VestedActives, dic["FinalAtRisk_VestedActives"], 0);
                _gLib._VerifySyncUDWin("FinalAtRisk_Total", this.wRetirementStudio.wPBGC_FinalAtRisk_Total.txtFinalAtRisk_Total, dic["FinalAtRisk_Total"], 0);
                _gLib._VerifySyncUDWin("PBGCTarget_InpayStatus", this.wRetirementStudio.wPBGC_PBGCTarget_InpayStatus.txtPBGCTarget_InpayStatus, dic["PBGCTarget_InpayStatus"], 0);
                _gLib._VerifySyncUDWin("PBGCTarget_DeferredStatus", this.wRetirementStudio.wPBGC_PBGCTarget_DeferredStatus.txtPBGCTarget_DeferredStatus, dic["PBGCTarget_DeferredStatus"], 0);
                _gLib._VerifySyncUDWin("PBGCTarget_VestedActives", this.wRetirementStudio.wPBGC_PBGCTarget_VestedActives.txtPBGCTarget_VestedActives, dic["PBGCTarget_VestedActives"], 0);
                _gLib._VerifySyncUDWin("PBGCTarget_Total", this.wRetirementStudio.wPBGC_PBGCTarget_Total.txtPBGCTarget_Total, dic["PBGCTarget_Total"], 0);
                _gLib._VerifySyncUDWin("PBGCTarget_MVofAssets", this.wRetirementStudio.wPBGC_PBGCTarget_MVofAssets.txtPBGCTarget_MVofAssets, dic["PBGCTarget_MVofAssets"], 0);
                _gLib._VerifySyncUDWin("PBGCVariable_Unfunded", this.wRetirementStudio.wPBGC_PBGCVariable_Unfunded.txtPBGCVariable_Unfunded, dic["PBGCVariable_Unfunded"], 0);
                _gLib._VerifySyncUDWin("PBGCVariable_9Per1000", this.wRetirementStudio.wPBGC_PBGCVariable_9Per1000.txtPBGCVariable_9Per1000, dic["PBGCVariable_9Per1000"], 0);
                _gLib._VerifySyncUDWin("PBGCVariable_NumOfEE", this.wRetirementStudio.wPBGC_PBGCVariable_NumOfEE.txtPBGCVariable_NumOfEE, dic["PBGCVariable_NumOfEE"], 0);
                _gLib._VerifySyncUDWin("PBGCVariable_ParticipantCount", this.wRetirementStudio.wPBGC_PBGCVariable_ParticipantCount.txtPBGCVariable_ParticipantCount, dic["PBGCVariable_ParticipantCount"], 0);
                _gLib._VerifySyncUDWin("PBGCVariable_PerParticipant", this.wRetirementStudio.wPBGC_PBGCVariable_PerParticipant.txtPBGCVariable_PerParticipant, dic["PBGCVariable_PerParticipant"], 0);
                _gLib._VerifySyncUDWin("PBGCVariable_PBGCVariable", this.wRetirementStudio.wPBGC_PBGCVariable_PBGCVariable.txtPBGCVariable_PBGCVariable, dic["PBGCVariable_PBGCVariable"], 0);
                _gLib._VerifySyncUDWin("PBGCVariable_CombinedPBGC", this.wRetirementStudio.wPBGC_PBGCVariable_CombinedPBGC.txtPBGCVariable_CombinedPBGC, dic["PBGCVariable_CombinedPBGC"], 0);

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
        ///    dic.Add("InactivesInPayStatus", "10");
        ///    dic.Add("InactivesDeferredStatus", "62");
        ///    dic.Add("VestedStatus", "35");
        ///    dic.Add("NonVestedStatus", "18");
        ///    dic.Add("Total", "125");
        ///    dic.Add("TotalPlanParticipants", "125");
        ///    dic.Add("NumOfParticipants", "125");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_Data(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Data(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Data";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("InactivesInPayStatus", this.wRetirementStudio.wData_InactivesInPayStatus.txtInactivesInPayStatus, dic["InactivesInPayStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InactivesDeferredStatus", this.wRetirementStudio.wData_InactivesDeferredStatus.txtInactivesDeferredStatus, dic["InactivesDeferredStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("VestedStatus", this.wRetirementStudio.wData_VestedStatus.txtVestedStatus, dic["VestedStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NonVestedStatus", this.wRetirementStudio.wData_NonVestedStatus.txtNonVestedStatus, dic["NonVestedStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Total", this.wRetirementStudio.wData_Total.txtTotal, dic["Total"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TotalPlanParticipants", this.wRetirementStudio.wData_TotalPlanParticipants.txtTotalPlanParticipants, dic["TotalPlanParticipants"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NumOfParticipants", this.wRetirementStudio.wData_NumOfParticipants.txtNumOfParticipants, dic["NumOfParticipants"], 0);


            }
            if (dic["PopVerify"] == "Verify")
            {


                _gLib._VerifySyncUDWin("InactivesInPayStatus", this.wRetirementStudio.wData_InactivesInPayStatus.txtInactivesInPayStatus, dic["InactivesInPayStatus"], 0);
                _gLib._VerifySyncUDWin("InactivesDeferredStatus", this.wRetirementStudio.wData_InactivesDeferredStatus.txtInactivesDeferredStatus, dic["InactivesDeferredStatus"], 0);
                _gLib._VerifySyncUDWin("VestedStatus", this.wRetirementStudio.wData_VestedStatus.txtVestedStatus, dic["VestedStatus"], 0);
                _gLib._VerifySyncUDWin("NonVestedStatus", this.wRetirementStudio.wData_NonVestedStatus.txtNonVestedStatus, dic["NonVestedStatus"], 0);
                _gLib._VerifySyncUDWin("Total", this.wRetirementStudio.wData_Total.txtTotal, dic["Total"], 0);
                _gLib._VerifySyncUDWin("TotalPlanParticipants", this.wRetirementStudio.wData_TotalPlanParticipants.txtTotalPlanParticipants, dic["TotalPlanParticipants"], 0);
                _gLib._VerifySyncUDWin("NumOfParticipants", this.wRetirementStudio.wData_NumOfParticipants.txtNumOfParticipants, dic["NumOfParticipants"], 0);


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
        ///    dic.Add("PirorYearNum", "130");
        ///    dic.Add("Prong1Determination", "75.16");
        ///    dic.Add("Prong1Threshold", "65.00");
        ///    dic.Add("Prong2Determination", "75.16");
        ///    dic.Add("Prong2Threshold", "70.00");
        ///    dic.Add("PlanIsAtRisk", "");
        ///    dic.Add("IncludesExpenseLoad", "");
        ///    dic.Add("ConsecutiveYears", "");
        ///    dic.Add("FTReflects", "");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_AtRiskDetermination(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_AtRiskDetermination(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_AtRiskDetermination";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("PirorYearNum", this.wRetirementStudio.wAtRiskDetermination_PirorYearNum.txtPirorYearNum, dic["PirorYearNum"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Prong1Determination", this.wRetirementStudio.wAtRiskDetermination_Prong1Determination.txtProng1Determination, dic["Prong1Determination"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Prong1Threshold", this.wRetirementStudio.wAtRiskDetermination_Prong1Threshold.txtProng1Threshold, dic["Prong1Threshold"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Prong2Determination", this.wRetirementStudio.wAtRiskDetermination_Prong2Determination.txtProng2Determination, dic["Prong2Determination"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Prong2Threshold", this.wRetirementStudio.wAtRiskDetermination_Prong2Threshold.txtProng2Threshold, dic["Prong2Threshold"], 0);
                _gLib._SetSyncUDWin("PlanIsAtRisk", this.wRetirementStudio.wAtRiskDetermination_PlanIsAtRisk.cboPlanIsAtRisk, dic["PlanIsAtRisk"], 0);
                _gLib._SetSyncUDWin("IncludesExpenseLoad", this.wRetirementStudio.wAtRiskDetermination_IncludesExpenseLoad.cboIncludesExpenseLoad, dic["IncludesExpenseLoad"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ConsecutiveYears", this.wRetirementStudio.wAtRiskDetermination_ConsecutiveYears.txtConsecutiveYears, dic["ConsecutiveYears"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FTReflects", this.wRetirementStudio.wAtRiskDetermination_FTReflects.txtFTReflects, dic["FTReflects"], 0);


            }
            if (dic["PopVerify"] == "Verify")
            {


                _gLib._VerifySyncUDWin("PirorYearNum", this.wRetirementStudio.wAtRiskDetermination_PirorYearNum.txtPirorYearNum, dic["PirorYearNum"], 0);
                _gLib._VerifySyncUDWin("Prong1Determination", this.wRetirementStudio.wAtRiskDetermination_Prong1Determination.txtProng1Determination, dic["Prong1Determination"], 0);
                _gLib._VerifySyncUDWin("Prong1Threshold", this.wRetirementStudio.wAtRiskDetermination_Prong1Threshold.txtProng1Threshold, dic["Prong1Threshold"], 0);
                _gLib._VerifySyncUDWin("Prong2Determination", this.wRetirementStudio.wAtRiskDetermination_Prong2Determination.txtProng2Determination, dic["Prong2Determination"], 0);
                _gLib._VerifySyncUDWin("Prong2Threshold", this.wRetirementStudio.wAtRiskDetermination_Prong2Threshold.txtProng2Threshold, dic["Prong2Threshold"], 0);
                _gLib._VerifySyncUDWin("PlanIsAtRisk", this.wRetirementStudio.wAtRiskDetermination_PlanIsAtRisk.cboPlanIsAtRisk, dic["PlanIsAtRisk"], 0);
                _gLib._VerifySyncUDWin("IncludesExpenseLoad", this.wRetirementStudio.wAtRiskDetermination_IncludesExpenseLoad.cboIncludesExpenseLoad, dic["IncludesExpenseLoad"], 0);
                _gLib._VerifySyncUDWin("ConsecutiveYears", this.wRetirementStudio.wAtRiskDetermination_ConsecutiveYears.txtConsecutiveYears, dic["ConsecutiveYears"], 0);
                _gLib._VerifySyncUDWin("FTReflects", this.wRetirementStudio.wAtRiskDetermination_FTReflects.txtFTReflects, dic["FTReflects"], 0);

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
        ///    dic.Add("InPayStatus", "1,968,365");
        ///    dic.Add("DeferredStatus", "2,831,941");
        ///    dic.Add("VestedActives", "2,789,008");
        ///    dic.Add("NonVestedActives", "16,512");
        ///    dic.Add("Total", "7,605,826");
        ///    dic.Add("NormalCost", "353,826");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_NotAtRisk(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_LiabilityMeasures_FTD_NotAtRisk(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_LiabilityMeasures_FTD_NotAtRisk";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("InPayStatus", this.wRetirementStudio.wLiabilityMeasuresFTD_NAR_InPayStatus.txtInPayStatus, dic["InPayStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DeferredStatus", this.wRetirementStudio.wLiabilityMeasuresFTD_NAR_DeferredStatus.txtDeferredStatus, dic["DeferredStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("VestedActives", this.wRetirementStudio.wLiabilityMeasuresFTD_NAR_VestedActives.txtVestedActives, dic["VestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NonVestedActives", this.wRetirementStudio.wLiabilityMeasuresFTD_NAR_NonVestedActvies.txtNonVestedActives, dic["NonVestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Total", this.wRetirementStudio.wLiabilityMeasuresFTD_NAR_Total.txtTotal, dic["Total"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NormalCost", this.wRetirementStudio.wLiabilityMeasuresFTD_NAR_NormalCost.txtNormalCost, dic["NormalCost"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("InPayStatus", this.wRetirementStudio.wLiabilityMeasuresFTD_NAR_InPayStatus.txtInPayStatus, dic["InPayStatus"], 0);
                _gLib._VerifySyncUDWin("DeferredStatus", this.wRetirementStudio.wLiabilityMeasuresFTD_NAR_DeferredStatus.txtDeferredStatus, dic["DeferredStatus"], 0);
                _gLib._VerifySyncUDWin("VestedActives", this.wRetirementStudio.wLiabilityMeasuresFTD_NAR_VestedActives.txtVestedActives, dic["VestedActives"], 0);
                _gLib._VerifySyncUDWin("NonVestedActives", this.wRetirementStudio.wLiabilityMeasuresFTD_NAR_NonVestedActvies.txtNonVestedActives, dic["NonVestedActives"], 0);
                _gLib._VerifySyncUDWin("Total", this.wRetirementStudio.wLiabilityMeasuresFTD_NAR_Total.txtTotal, dic["Total"], 0);
                _gLib._VerifySyncUDWin("NormalCost", this.wRetirementStudio.wLiabilityMeasuresFTD_NAR_NormalCost.txtNormalCost, dic["NormalCost"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }



        /// <summary>
        /// 2016-Jan-22
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ARNoExpenseRetiredAndBeneficiries", "");
        ///    dic.Add("ARNoExpenseTermVested", "");
        ///    dic.Add("ARNoExpenseVestedActives", "");
        ///    dic.Add("ARNoExpenseNonVestedActives", "");
        ///    dic.Add("ARNoExpenseTotal", "");
        ///    dic.Add("ARNoExpenseFundingNC", "");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_AtRiskNoexpenseLoad(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_LiabilityMeasures_FTD_AtRiskNoexpenseLoad(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_LiabilityMeasures_FTD_NotAtRisk";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("ARNoExpenseRetiredAndBeneficiries", this.wRetirementStudio.wAR_NoExpenseLoad_RetiredAndBeneficiaries.Edit.UINumEditorEdit1, dic["ARNoExpenseRetiredAndBeneficiries"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ARNoExpenseTermVested", this.wRetirementStudio.wAR_NoExpense_TermVested.Edit.UINumEditorEdit1, dic["ARNoExpenseTermVested"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ARNoExpenseVestedActives", this.wRetirementStudio.wAR_NoExpense_VestedActives.Edit.UINumEditorEdit1, dic["ARNoExpenseVestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ARNoExpenseNonVestedActives", this.wRetirementStudio.wAR_NoExpense_NonVestedActives.Edit.UINumEditorEdit1, dic["ARNoExpenseNonVestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ARNoExpenseTotal", this.wRetirementStudio.wAR_NoExpense_Total.Edit.UINumEditorEdit1, dic["ARNoExpenseTotal"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ARNoExpenseFundingNC", this.wRetirementStudio.wAR_NoExpense_FundingNC.Edit.UINumEditorEdit1, dic["ARNoExpenseFundingNC"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2016-Jan-22
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ARApplicableRetiredAndBeneficiries", "");
        ///    dic.Add("ARApplicableTermVested", "");
        ///    dic.Add("ARApplicableVestedActives", "");
        ///    dic.Add("ARApplicableNonVestedActives", "");
        ///    dic.Add("ARApplicableTotal", "");
        ///    dic.Add("ARApplicableFundingNC", "");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_AtRiskApplicable(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_LiabilityMeasures_FTD_AtRiskApplicable(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_LiabilityMeasures_FTD_NotAtRisk";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("ARApplicableRetiredAndBeneficiries", this.wRetirementStudio.wAR_Applicable_RetiredAndBeneficiries.Edit.UINumEditorEdit1, dic["ARApplicableRetiredAndBeneficiries"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ARApplicableTermVested", this.wRetirementStudio.wAR_Applicable_TermVested.Edit.UINumEditorEdit1, dic["ARApplicableTermVested"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ARApplicableVestedActives", this.wRetirementStudio.wAR_Applicable_VestedActives.Edit.UINumEditorEdit1, dic["ARApplicableVestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ARApplicableNonVestedActives", this.wRetirementStudio.wAR_Applicable_NonVestedActives.Edit.UINumEditorEdit1, dic["ARApplicableNonVestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ARApplicableTotal", this.wRetirementStudio.wAR_Applicable_Total.Edit.UINumEditorEdit1, dic["ARApplicableTotal"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ARApplicableFundingNC", this.wRetirementStudio.wAR_Applicable_FundingNC.Edit.UINumEditorEdit1, dic["ARApplicableFundingNC"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
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
        ///    dic.Add("InPayStatus", "");
        ///    dic.Add("DeferredStatus", "");
        ///    dic.Add("VestedActives", "");
        ///    dic.Add("NonVestedActives", "");
        ///    dic.Add("Total", "");
        ///    dic.Add("NormalCost", "353,826");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_Final(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_LiabilityMeasures_FTD_Final(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_LiabilityMeasures_FTD_Final";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("InPayStatus", this.wRetirementStudio.wLiabilityMeasuresFTD_Final_InPayStatus.txtInPayStatus, dic["InPayStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DeferredStatus", this.wRetirementStudio.wLiabilityMeasuresFTD_Final_DeferredStatus.txtDeferredStatus, dic["DeferredStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("VestedActives", this.wRetirementStudio.wLiabilityMeasuresFTD_Final_VestedActives.txtVestedActives, dic["VestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NonVestedActives", this.wRetirementStudio.wLiabilityMeasuresFTD_Final_NonVestedActives.txtNonVestedActives, dic["NonVestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Total", this.wRetirementStudio.wLiabilityMeasuresFTD_Final_Total.txtTotal, dic["Total"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NormalCost", this.wRetirementStudio.wLiabilityMeasuresFTD_Final_NormalCost.txtNormalCost, dic["NormalCost"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("InPayStatus", this.wRetirementStudio.wLiabilityMeasuresFTD_Final_InPayStatus.txtInPayStatus, dic["InPayStatus"], 0);
                _gLib._VerifySyncUDWin("DeferredStatus", this.wRetirementStudio.wLiabilityMeasuresFTD_Final_DeferredStatus.txtDeferredStatus, dic["DeferredStatus"], 0);
                _gLib._VerifySyncUDWin("VestedActives", this.wRetirementStudio.wLiabilityMeasuresFTD_Final_VestedActives.txtVestedActives, dic["VestedActives"], 0);
                _gLib._VerifySyncUDWin("NonVestedActives", this.wRetirementStudio.wLiabilityMeasuresFTD_Final_NonVestedActives.txtNonVestedActives, dic["NonVestedActives"], 0);
                _gLib._VerifySyncUDWin("Total", this.wRetirementStudio.wLiabilityMeasuresFTD_Final_Total.txtTotal, dic["Total"], 0);
                _gLib._VerifySyncUDWin("NormalCost", this.wRetirementStudio.wLiabilityMeasuresFTD_Final_NormalCost.txtNormalCost, dic["NormalCost"], 0);

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
        ///    dic.Add("InPayStatus", "1,968,365");
        ///    dic.Add("DeferredStatus", "2,831,941");
        ///    dic.Add("VestedActives", "2,789,008");
        ///    dic.Add("NonVestedActives", "16,512");
        ///    dic.Add("Total", "7,605,826");
        ///    dic.Add("Discounted", "");
        ///    dic.Add("Expected", "");
        ///    dic.Add("DiscountedExpected", "");
        ///    dic.Add("NormalCost", "353,826");
        ///    dic.Add("TotalNormalCost", "");
        ///    dic.Add("EffectiveInterestRate", "6.44");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_FTD_FundingTarget(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_LiabilityMeasures_FTD_FundingTarget(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_LiabilityMeasures_FTD_FundingTarget";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("InPayStatus", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_InPayStatus.txtInPayStatus, dic["InPayStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DeferredStatus", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_DeferredStatus.txtDeferredStatus, dic["DeferredStatus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("VestedActives", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_VestedActives.txtVestedActives, dic["VestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NonVestedActives", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_NonVestedActives.txtNonVestedActives, dic["NonVestedActives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Total", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_Total.txtTotal, dic["Total"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Discounted", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_Discounted.txtDiscounted, dic["Discounted"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Expected", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_Expected.txtExpected, dic["Expected"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DiscountedExpected", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_DiscountedExpected.txtDiscountedExpected, dic["DiscountedExpected"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NormalCost", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_NormalCost.txtNormalCost, dic["NormalCost"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TotalNormalCost", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_TotalNormalCost.txtTotalNormalCost, dic["TotalNormalCost"], 0);
                _gLib._SetSyncUDWin_ByClipboard("EffectiveInterestRate", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_EffectiveInterestRate.txtEffectiveInterestRate, dic["EffectiveInterestRate"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("InPayStatus", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_InPayStatus.txtInPayStatus, dic["InPayStatus"], 0);
                _gLib._VerifySyncUDWin("DeferredStatus", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_DeferredStatus.txtDeferredStatus, dic["DeferredStatus"], 0);
                _gLib._VerifySyncUDWin("VestedActives", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_VestedActives.txtVestedActives, dic["VestedActives"], 0);
                _gLib._VerifySyncUDWin("NonVestedActives", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_NonVestedActives.txtNonVestedActives, dic["NonVestedActives"], 0);
                _gLib._VerifySyncUDWin("Total", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_Total.txtTotal, dic["Total"], 0);
                _gLib._VerifySyncUDWin("Discounted", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_Discounted.txtDiscounted, dic["Discounted"], 0);
                _gLib._VerifySyncUDWin("Expected", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_Expected.txtExpected, dic["Expected"], 0);
                _gLib._VerifySyncUDWin("DiscountedExpected", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_DiscountedExpected.txtDiscountedExpected, dic["DiscountedExpected"], 0);
                _gLib._VerifySyncUDWin("NormalCost", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_NormalCost.txtNormalCost, dic["NormalCost"], 0);
                _gLib._VerifySyncUDWin("TotalNormalCost", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_TotalNormalCost.txtTotalNormalCost, dic["TotalNormalCost"], 0);
                _gLib._VerifySyncUDWin("EffectiveInterestRate", this.wRetirementStudio.wLiabilityMeasuresFTD_FundingTarget_EffectiveInterestRate.txtEffectiveInterestRate, dic["EffectiveInterestRate"], 0);

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
        ///    dic.Add("NotAtRiskLiability", "9,516,552");
        ///    dic.Add("ExpenseLoad", "");
        ///    dic.Add("AtRiskLiabilityNoExpense", "");
        ///    dic.Add("AtRiskLiabilityWithExpense", "");
        ///    dic.Add("FinalAtRisk", "");
        ///    dic.Add("FundingTarget", "9,516,552");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_LiabilityMeasures_MDC(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_LiabilityMeasures_MDC(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_LiabilityMeasures_MDC";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("NotAtRiskLiability", this.wRetirementStudio.wLiabilityMeasuresMDC_NotAtRiskLiability.txtNotAtRiskLiability, dic["NotAtRiskLiability"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ExpenseLoad", this.wRetirementStudio.wLiabilityMeasuresMDC_ExpenseLoad.txtExpenseLoad, dic["ExpenseLoad"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AtRiskLiabilityNoExpense", this.wRetirementStudio.wLiabilityMeasuresMDC_AtRiskLiabilityNoExpense.txtAtRiskLiabilityNoExpense, dic["AtRiskLiabilityNoExpense"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AtRiskLiabilityWithExpense", this.wRetirementStudio.wLiabilityMeasuresMDC_AtRiskLiabilityWithExpense.txtAtRiskLiabilityWithExpense, dic["AtRiskLiabilityWithExpense"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FinalAtRisk", this.wRetirementStudio.wLiabilityMeasuresMDC_FinalAtRisk.txtFinalAtRisk, dic["FinalAtRisk"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FundingTarget", this.wRetirementStudio.wLiabilityMeasuresMDC_FundingTarget.txtFundingTarget, dic["FundingTarget"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {


                _gLib._VerifySyncUDWin("NotAtRiskLiability", this.wRetirementStudio.wLiabilityMeasuresMDC_NotAtRiskLiability.txtNotAtRiskLiability, dic["NotAtRiskLiability"], 0);
                _gLib._VerifySyncUDWin("ExpenseLoad", this.wRetirementStudio.wLiabilityMeasuresMDC_ExpenseLoad.txtExpenseLoad, dic["ExpenseLoad"], 0);
                _gLib._VerifySyncUDWin("AtRiskLiabilityNoExpense", this.wRetirementStudio.wLiabilityMeasuresMDC_AtRiskLiabilityNoExpense.txtAtRiskLiabilityNoExpense, dic["AtRiskLiabilityNoExpense"], 0);
                _gLib._VerifySyncUDWin("AtRiskLiabilityWithExpense", this.wRetirementStudio.wLiabilityMeasuresMDC_AtRiskLiabilityWithExpense.txtAtRiskLiabilityWithExpense, dic["AtRiskLiabilityWithExpense"], 0);
                _gLib._VerifySyncUDWin("FinalAtRisk", this.wRetirementStudio.wLiabilityMeasuresMDC_FinalAtRisk.txtFinalAtRisk, dic["FinalAtRisk"], 0);
                _gLib._VerifySyncUDWin("FundingTarget", this.wRetirementStudio.wLiabilityMeasuresMDC_FundingTarget.txtFundingTarget, dic["FundingTarget"], 0);

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
        ///    dic.Add("BalanceAtBegining", "");
        ///    dic.Add("PortionUsed", "");
        ///    dic.Add("InterestUsing", "");
        ///    dic.Add("BalanceAtBOY", "");
        ///    dic.Add("VoluntaryReduction", "");
        ///    dic.Add("DeemedWaivers", "");
        ///    dic.Add("BOYBalance", "");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_CarryoverBalance(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CarryoverBalance(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_CarryoverBalance";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("BalanceAtBegining", this.wRetirementStudio.wCarryoverBalance_BalanceAtBegining.txtBalanceAtBegining, dic["BalanceAtBegining"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PortionUsed", this.wRetirementStudio.wCarryoverBalance_PortionUsed.txtPortionUsed, dic["PortionUsed"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InterestUsing", this.wRetirementStudio.wCarryoverBalance_InterestUsing.txtInterestUsing, dic["InterestUsing"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BalanceAtBOY", this.wRetirementStudio.wCarryoverBalance_BalanceAtBOY.txtBalanceAtBOY, dic["BalanceAtBOY"], 0);
                _gLib._SetSyncUDWin_ByClipboard("VoluntaryReduction", this.wRetirementStudio.wCarryoverBalance_VoluntaryReduction.txtVoluntaryReduction, dic["VoluntaryReduction"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DeemedWaivers", this.wRetirementStudio.wCarryoverBalance_DeemedWaivers.txtDeemedWaivers, dic["DeemedWaivers"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BOYBalance", this.wRetirementStudio.wCarryoverBalance_BOYBalance.txtBOYBalance, dic["BOYBalance"], 0);


            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("BalanceAtBegining", this.wRetirementStudio.wCarryoverBalance_BalanceAtBegining.txtBalanceAtBegining, dic["BalanceAtBegining"], 0);
                _gLib._VerifySyncUDWin("PortionUsed", this.wRetirementStudio.wCarryoverBalance_PortionUsed.txtPortionUsed, dic["PortionUsed"], 0);
                _gLib._VerifySyncUDWin("InterestUsing", this.wRetirementStudio.wCarryoverBalance_InterestUsing.txtInterestUsing, dic["InterestUsing"], 0);
                _gLib._VerifySyncUDWin("BalanceAtBOY", this.wRetirementStudio.wCarryoverBalance_BalanceAtBOY.txtBalanceAtBOY, dic["BalanceAtBOY"], 0);
                _gLib._VerifySyncUDWin("VoluntaryReduction", this.wRetirementStudio.wCarryoverBalance_VoluntaryReduction.txtVoluntaryReduction, dic["VoluntaryReduction"], 0);
                _gLib._VerifySyncUDWin("DeemedWaivers", this.wRetirementStudio.wCarryoverBalance_DeemedWaivers.txtDeemedWaivers, dic["DeemedWaivers"], 0);
                _gLib._VerifySyncUDWin("BOYBalance", this.wRetirementStudio.wCarryoverBalance_BOYBalance.txtBOYBalance, dic["BOYBalance"], 0);

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
        ///    dic.Add("BalanceAtBegining", "");
        ///    dic.Add("PortionUsed", "");
        ///    dic.Add("InterestUsingPriorYrsActualReturn", "");
        ///     dic.Add("AmountRemaining", "");
        ///     dic.Add("PriorYrsExcess", "");
        ///     dic.Add("InterestOnAmount", "");      
        ///     dic.Add("InterestUsingPriorYrsEffectiveRate", "");   
        ///     dic.Add("TotalAvailableAtBegin", "");            
        ///     dic.Add("PortionToBeAdded", "");      
        ///    dic.Add("BalanceAtBOY", "");
        ///    dic.Add("VoluntaryReduction", "");
        ///    dic.Add("DeemedWaivers", "");
        ///    dic.Add("BOYBalance", "");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_PrefundingBalance(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PrefundingBalance(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PrefundingBalance";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("BalanceAtBegining", this.wRetirementStudio.wPrefundingBalance_BalanceAtBegin.txtBalanceAtBegin, dic["BalanceAtBegining"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PortionUsed", this.wRetirementStudio.wPrefundingBalance_PortionUsed.txtPortionUsed, dic["PortionUsed"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InterestUsingPriorYrsActualReturn", this.wRetirementStudio.wPrefundingBalance_InterestUsingPriorYrsActual.txtInterestUsingPriorYrsActual, dic["InterestUsingPriorYrsActualReturn"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AmountRemaining", this.wRetirementStudio.wPrefundingBalance_AmountRemaining.txtAmountRemaining, dic["AmountRemaining"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PriorYrsExcess", this.wRetirementStudio.wPrefundingBalance_PriorYrsExcessContrib.txtPriorYrsExcessContrib, dic["PriorYrsExcess"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InterestOnAmount", this.wRetirementStudio.wPrefundingBalance_InterestOnAmount.txtInterestOnAmount, dic["InterestOnAmount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InterestUsingPriorYrsEffectiveRate", this.wRetirementStudio.wPrefundingBalance_InterestUsingPriorYrsEffective.txtInterestUsingPriorYrsEffective, dic["InterestUsingPriorYrsEffectiveRate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TotalAvailableAtBegin", this.wRetirementStudio.wPrefundingBalance_TotalAvailable.txtTotalAvailable, dic["TotalAvailableAtBegin"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PortionToBeAdded", this.wRetirementStudio.wPrefundingBalance_PortionToBeAdded.txtPortionToBeAdded, dic["PortionToBeAdded"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BalanceAtBOY", this.wRetirementStudio.wPrefundingBalance_BalanceAtBOY.txtBalanceAtBOY, dic["BalanceAtBOY"], 0);
                _gLib._SetSyncUDWin_ByClipboard("VoluntaryReduction", this.wRetirementStudio.wPrefundingBalance_VoluntaryReduction.txtVoluntaryReduction, dic["VoluntaryReduction"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DeemedWaivers", this.wRetirementStudio.wPrefundingBalance_DeemedWaivers.txtDeemedWaivers, dic["DeemedWaivers"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BOYBalance", this.wRetirementStudio.wPrefundingBalance_BOYBalance.txtBOYBalance, dic["BOYBalance"], 0);


            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("BalanceAtBegining", this.wRetirementStudio.wPrefundingBalance_BalanceAtBegin.txtBalanceAtBegin, dic["BalanceAtBegining"], 0);
                _gLib._VerifySyncUDWin("PortionUsed", this.wRetirementStudio.wPrefundingBalance_PortionUsed.txtPortionUsed, dic["PortionUsed"], 0);
                _gLib._VerifySyncUDWin("InterestUsingPriorYrsActualReturn", this.wRetirementStudio.wPrefundingBalance_InterestUsingPriorYrsActual.txtInterestUsingPriorYrsActual, dic["InterestUsingPriorYrsActualReturn"], 0);
                _gLib._VerifySyncUDWin("AmountRemaining", this.wRetirementStudio.wPrefundingBalance_AmountRemaining.txtAmountRemaining, dic["AmountRemaining"], 0);
                _gLib._VerifySyncUDWin("PriorYrsExcess", this.wRetirementStudio.wPrefundingBalance_PriorYrsExcessContrib.txtPriorYrsExcessContrib, dic["PriorYrsExcess"], 0);
                _gLib._VerifySyncUDWin("InterestOnAmount", this.wRetirementStudio.wPrefundingBalance_InterestOnAmount.txtInterestOnAmount, dic["InterestOnAmount"], 0);
                _gLib._VerifySyncUDWin("InterestUsingPriorYrsEffectiveRate", this.wRetirementStudio.wPrefundingBalance_InterestUsingPriorYrsEffective.txtInterestUsingPriorYrsEffective, dic["InterestUsingPriorYrsEffectiveRate"], 0);
                _gLib._VerifySyncUDWin("TotalAvailableAtBegin", this.wRetirementStudio.wPrefundingBalance_TotalAvailable.txtTotalAvailable, dic["TotalAvailableAtBegin"], 0);
                _gLib._VerifySyncUDWin("PortionToBeAdded", this.wRetirementStudio.wPrefundingBalance_PortionToBeAdded.txtPortionToBeAdded, dic["PortionToBeAdded"], 0);
                _gLib._VerifySyncUDWin("BalanceAtBOY", this.wRetirementStudio.wPrefundingBalance_BalanceAtBOY.txtBalanceAtBOY, dic["BalanceAtBOY"], 0);
                _gLib._VerifySyncUDWin("VoluntaryReduction", this.wRetirementStudio.wPrefundingBalance_VoluntaryReduction.txtVoluntaryReduction, dic["VoluntaryReduction"], 0);
                _gLib._VerifySyncUDWin("DeemedWaivers", this.wRetirementStudio.wPrefundingBalance_DeemedWaivers.txtDeemedWaivers, dic["DeemedWaivers"], 0);
                _gLib._VerifySyncUDWin("BOYBalance", this.wRetirementStudio.wPrefundingBalance_BOYBalance.txtBOYBalance, dic["BOYBalance"], 0);

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
        ///    dic.Add("Liability_Actuarial", "");
        ///    dic.Add("Liability_NormalCost", "");
        ///    dic.Add("Liability_Interest", "");
        ///    dic.Add("Benefits_BenefitPayments", "");
        ///    dic.Add("Benefits_Administrative", "");
        ///    dic.Add("Benefits_EmployeeContrib", "");
        ///    dic.Add("Benefits_Total", "");
        ///    dic.Add("Benefits_ExpectedActuarial", "");
        ///    dic.Add("Benefits_LiabilityGL", "");
        ///    dic.Add("Asset_ActuarialAsset", "");
        ///    dic.Add("Asset_InterestOnActuarial", "");
        ///    dic.Add("Asset_ContributionsMade", "");
        ///    dic.Add("Asset_InterestOnContrib", "");
        ///    dic.Add("Asset_ExpectedActuarial", "");
        ///    dic.Add("Asset_ActuarialAssetGL", "");
        ///    dic.Add("Asset_ActuarialGL", "");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_DevelopmentOfExperienceGL(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DevelopmentOfExperienceGL(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_DevelopmentOfExperienceGL";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("Liability_Actuarial", this.wRetirementStudio.wDevelopmentGL_Liability_Actuarial.txtActuarial, dic["Liability_Actuarial"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Liability_NormalCost", this.wRetirementStudio.wDevelopmentGL_Liability_NormalCost.txtNormalCost, dic["Liability_NormalCost"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Liability_Interest", this.wRetirementStudio.wDevelopmentGL_Liability_Interest.txtInterest, dic["Liability_Interest"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Benefits_BenefitPayments", this.wRetirementStudio.wDevelopmentGL_Benefits_BenefitPayments.txtBenefitPayments, dic["Benefits_BenefitPayments"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Benefits_Administrative", this.wRetirementStudio.wDevelopmentGL_Benefits_Administrative.txtAdministrative, dic["Benefits_Administrative"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Benefits_EmployeeContrib", this.wRetirementStudio.wDevelopmentGL_Benefits_EmployeeContrib.txtEmployeeContrib, dic["Benefits_EmployeeContrib"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Benefits_Total", this.wRetirementStudio.wDevelopmentGL_Benefits_Total.txtTotal, dic["Benefits_Total"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Benefits_ExpectedActuarial", this.wRetirementStudio.wDevelopmentGL_Benefits_ExpectedActuarial.txtExpectedActuarial, dic["Benefits_ExpectedActuarial"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Benefits_LiabilityGL", this.wRetirementStudio.wDevelopmentGL_Benefits_LiabilityGL.txtLiabilityGL, dic["Benefits_LiabilityGL"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Asset_ActuarialAsset", this.wRetirementStudio.wDevelopmentGL_Asset_ActuarialAsset.txtActuarialAsset, dic["Asset_ActuarialAsset"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Asset_InterestOnActuarial", this.wRetirementStudio.wDevelopmentGL_Asset_InterestOnActuarial.txtInterestOnActuarial, dic["Asset_InterestOnActuarial"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Asset_ContributionsMade", this.wRetirementStudio.wDevelopmentGL_Asset_ContributionsMade.txtContributionsMade, dic["Asset_ContributionsMade"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Asset_InterestOnContrib", this.wRetirementStudio.wDevelopmentGL_Asset_InterestOnContrib.txtInterestOnContrib, dic["Asset_InterestOnContrib"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Asset_ExpectedActuarial", this.wRetirementStudio.wDevelopmentGL_Asset_ExpectedActuarial.txtExpectedActuarial, dic["Asset_ExpectedActuarial"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Asset_ActuarialAssetGL", this.wRetirementStudio.wDevelopmentGL_Asset_ActuarialAssetGL.txtActuarialAssetGL, dic["Asset_ActuarialAssetGL"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Asset_ActuarialGL", this.wRetirementStudio.wDevelopmentGL_Asset_ActuarialGL.txtActuarialGL, dic["Asset_ActuarialGL"], 0);



            }
            if (dic["PopVerify"] == "Verify")
            {




                _gLib._VerifySyncUDWin("Liability_Actuarial", this.wRetirementStudio.wDevelopmentGL_Liability_Actuarial.txtActuarial, dic["Liability_Actuarial"], 0);
                _gLib._VerifySyncUDWin("Liability_NormalCost", this.wRetirementStudio.wDevelopmentGL_Liability_NormalCost.txtNormalCost, dic["Liability_NormalCost"], 0);
                _gLib._VerifySyncUDWin("Liability_Interest", this.wRetirementStudio.wDevelopmentGL_Liability_Interest.txtInterest, dic["Liability_Interest"], 0);
                _gLib._VerifySyncUDWin("Benefits_BenefitPayments", this.wRetirementStudio.wDevelopmentGL_Benefits_BenefitPayments.txtBenefitPayments, dic["Benefits_BenefitPayments"], 0);
                _gLib._VerifySyncUDWin("Benefits_Administrative", this.wRetirementStudio.wDevelopmentGL_Benefits_Administrative.txtAdministrative, dic["Benefits_Administrative"], 0);
                _gLib._VerifySyncUDWin("Benefits_EmployeeContrib", this.wRetirementStudio.wDevelopmentGL_Benefits_EmployeeContrib.txtEmployeeContrib, dic["Benefits_EmployeeContrib"], 0);
                _gLib._VerifySyncUDWin("Benefits_Total", this.wRetirementStudio.wDevelopmentGL_Benefits_Total.txtTotal, dic["Benefits_Total"], 0);
                _gLib._VerifySyncUDWin("Benefits_ExpectedActuarial", this.wRetirementStudio.wDevelopmentGL_Benefits_ExpectedActuarial.txtExpectedActuarial, dic["Benefits_ExpectedActuarial"], 0);
                _gLib._VerifySyncUDWin("Benefits_LiabilityGL", this.wRetirementStudio.wDevelopmentGL_Benefits_LiabilityGL.txtLiabilityGL, dic["Benefits_LiabilityGL"], 0);
                _gLib._VerifySyncUDWin("Asset_ActuarialAsset", this.wRetirementStudio.wDevelopmentGL_Asset_ActuarialAsset.txtActuarialAsset, dic["Asset_ActuarialAsset"], 0);
                _gLib._VerifySyncUDWin("Asset_InterestOnActuarial", this.wRetirementStudio.wDevelopmentGL_Asset_InterestOnActuarial.txtInterestOnActuarial, dic["Asset_InterestOnActuarial"], 0);
                _gLib._VerifySyncUDWin("Asset_ContributionsMade", this.wRetirementStudio.wDevelopmentGL_Asset_ContributionsMade.txtContributionsMade, dic["Asset_ContributionsMade"], 0);
                _gLib._VerifySyncUDWin("Asset_InterestOnContrib", this.wRetirementStudio.wDevelopmentGL_Asset_InterestOnContrib.txtInterestOnContrib, dic["Asset_InterestOnContrib"], 0);
                _gLib._VerifySyncUDWin("Asset_ExpectedActuarial", this.wRetirementStudio.wDevelopmentGL_Asset_ExpectedActuarial.txtExpectedActuarial, dic["Asset_ExpectedActuarial"], 0);
                _gLib._VerifySyncUDWin("Asset_ActuarialAssetGL", this.wRetirementStudio.wDevelopmentGL_Asset_ActuarialAssetGL.txtActuarialAssetGL, dic["Asset_ActuarialAssetGL"], 0);
                _gLib._VerifySyncUDWin("Asset_ActuarialGL", this.wRetirementStudio.wDevelopmentGL_Asset_ActuarialGL.txtActuarialGL, dic["Asset_ActuarialGL"], 0);


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
        ///    dic.Add("FirstQuaterly", "");
        ///    dic.Add("SecondQuaterly", "");
        ///    dic.Add("ThirdQuaterly", "");
        ///    dic.Add("FourthQuaterly", "");
        ///    dic.Add("FinalPaymeny", "");
        ///    pFundingInformation_PYR_PreliminaryResults._PopVerify_ContributionDates(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ContributionDates(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ContributionDates";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("FirstQuaterly", this.wRetirementStudio.wCD_FirstQuarterly.cbo.UIDtFirstQuarterlyContEdit, dic["FirstQuaterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SecondQuaterly", this.wRetirementStudio.wCD_SecondQuarterly.cbo.UIDtSecondQuarterlyConEdit, dic["SecondQuaterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ThirdQuaterly", this.wRetirementStudio.wCD_ThirdQuarterly.cbo.UIDtThirdQuarterlyContEdit, dic["ThirdQuaterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FourthQuaterly", this.wRetirementStudio.wCD_FourthQuarterly.cbo.UIDtFourthQuarterlyConEdit, dic["FourthQuaterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FinalPaymeny", this.wRetirementStudio.wCD_FinalContribution.cbo.UIDtFinalContributionPEdit, dic["FinalPaymeny"], 0);



            }
            if (dic["PopVerify"] == "Verify")
            {

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


          //////////dic.Clear();
          //////////  dic.Add("PopVerify", "Pop");
          //////////  dic.Add("EIR2YearsAge", "5.05");   
          //////////  dic.Add("EIR3YearsAge", "5.75");    
          //////////  pFundingInformation_PYR_PreliminaryResults._PopVerify_MiniumnContribution(dic);
        public void _PopVerify_MiniumnContribution(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_MiniumnContribution";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("EIR2YearsAge", this.wRetirementStudio.wPBGC_PBGCVariable_PBGCVariable.txtPBGCVariable_PBGCVariable, dic["EIR2YearsAge"], 0);
                _gLib._SetSyncUDWin_ByClipboard("EIR3YearsAge", this.wRetirementStudio.wPBGC_PBGCVariable_CombinedPBGC.txtPBGCVariable_CombinedPBGC, dic["EIR3YearsAge"], 0);
            }
        }
    }
}