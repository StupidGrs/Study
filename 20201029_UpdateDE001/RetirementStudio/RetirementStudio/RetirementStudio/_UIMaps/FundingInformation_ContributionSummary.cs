namespace RetirementStudio._UIMaps.FundingInformation_ContributionSummaryClasses
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


    public partial class FundingInformation_ContributionSummary
    {
        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2013-May-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("TargetNormalCost", "");
        ///    dic.Add("FullFundingLimit", "");
        ///    dic.Add("MininumBefore", "");
        ///    dic.Add("PriorYearFunded", "");
        ///    dic.Add("COBUsed", "");
        ///    dic.Add("PFBUsed", "");
        ///    dic.Add("MinimumAfter", "");
        ///    dic.Add("MinimumAtEOY", "");
        ///    dic.Add("MinimumAtLast", "");
        ///    pFundingInformation_ContributionSummary._PopVerify_MinimumRequiredContribution(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_MinimumRequiredContribution(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_MinimumRequiredContribution";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("TargetNormalCost", this.wRetirementStudio.wMinimumRequied_TargetNormalCost.txtTargetNormalCost, dic["TargetNormalCost"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FullFundingLimit", this.wRetirementStudio.wMinimumRequied_FulFundingLimit.txtFullFundingLimit, dic["FullFundingLimit"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MininumBefore", this.wRetirementStudio.wMinimumRequied_MininumBefore.txtMininumBefore, dic["MininumBefore"], 0);
                _gLib._SetSyncUDWin("PriorYearFunded", this.wRetirementStudio.wMininumRequired_PriorYearFunded.cboPriorYearFunded, dic["PriorYearFunded"], 0);
                _gLib._SetSyncUDWin_ByClipboard("COBUsed", this.wRetirementStudio.wMininumRequired_COBUsed.txtCOBUsed, dic["COBUsed"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PFBUsed", this.wRetirementStudio.wMininumRequired_PFBUsed.txtPFBUsed, dic["PFBUsed"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MinimumAfter", this.wRetirementStudio.wMininumRequired_MinimumAfter.txtMinimumAfter, dic["MinimumAfter"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MinimumAtEOY", this.wRetirementStudio.wMininumRequired_MinimumAtEOY.txtMinimumAtEOY, dic["MinimumAtEOY"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MinimumAtLast", this.wRetirementStudio.wMininumRequired_MinimumAtLast.txtMinimumAtLast, dic["MinimumAtLast"], 0);



            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("TargetNormalCost", this.wRetirementStudio.wMinimumRequied_TargetNormalCost.txtTargetNormalCost, dic["TargetNormalCost"], 0);
                _gLib._VerifySyncUDWin("FullFundingLimit", this.wRetirementStudio.wMinimumRequied_FulFundingLimit.txtFullFundingLimit, dic["FullFundingLimit"], 0);
                _gLib._VerifySyncUDWin("MininumBefore", this.wRetirementStudio.wMinimumRequied_MininumBefore.txtMininumBefore, dic["MininumBefore"], 0);
                _gLib._VerifySyncUDWin("PriorYearFunded", this.wRetirementStudio.wMininumRequired_PriorYearFunded.cboPriorYearFunded, dic["PriorYearFunded"], 0);
                _gLib._VerifySyncUDWin("COBUsed", this.wRetirementStudio.wMininumRequired_COBUsed.txtCOBUsed, dic["COBUsed"], 0);
                _gLib._VerifySyncUDWin("PFBUsed", this.wRetirementStudio.wMininumRequired_PFBUsed.txtPFBUsed, dic["PFBUsed"], 0);
                _gLib._VerifySyncUDWin("MinimumAfter", this.wRetirementStudio.wMininumRequired_MinimumAfter.txtMinimumAfter, dic["MinimumAfter"], 0);
                _gLib._VerifySyncUDWin("MinimumAtEOY", this.wRetirementStudio.wMininumRequired_MinimumAtEOY.txtMinimumAtEOY, dic["MinimumAtEOY"], 0);
                _gLib._VerifySyncUDWin("MinimumAtLast", this.wRetirementStudio.wMininumRequired_MinimumAtLast.txtMinimumAtLast, dic["MinimumAtLast"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Cushion_50ofFunding", "");
        ///    dic.Add("Cushion_FTIncrease", "");
        ///    dic.Add("Cushion_DeductionLimit", "");
        ///    dic.Add("Alternate_DeductionLimit", "");
        ///    dic.Add("Alternate_MaximumDeductible", "");
        ///    dic.Add("Interest_EarlierOf", "");
        ///    dic.Add("Interest_Fractional", "");
        ///    dic.Add("Interest_InterestTo", "");
        ///    dic.Add("Interest_MaximumDeductible", "");
        ///    pFundingInformation_ContributionSummary._PopVerify_MaximumDeductibleContribution(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_MaximumDeductibleContribution(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_MaximumDeductibleContribution";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("Cushion_50ofFunding", this.wRetirementStudio.wMaximumDeductible_Cushion_50ofFunding.txtCushion_50ofFunding, dic["Cushion_50ofFunding"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Cushion_FTIncrease", this.wRetirementStudio.wMaximumDeductible_Cushion_FTIncrease.txtCushion_FTIncrease, dic["Cushion_FTIncrease"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Cushion_DeductionLimit", this.wRetirementStudio.wMaximumDeductible_Cushion_DeductionLimit.txtCushion_DeductionLimit, dic["Cushion_DeductionLimit"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Alternate_DeductionLimit", this.wRetirementStudio.wMaximumDeductible_Alternate_DeductionLimit.txtAlternate_DeductionLimit, dic["Alternate_DeductionLimit"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Alternate_MaximumDeductible", this.wRetirementStudio.wMaximumDeductible_Alternate_MaximumDeductible.txtAlternate_MaximumDeductible, dic["Alternate_MaximumDeductible"], 0);
                _gLib._SendKeysUDWin("Interest_EarlierOf", this.wRetirementStudio.wMaximumDeductible_Interest_EarlierOf.cbo.txtInterest_EarlierOf, dic["Interest_EarlierOf"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Interest_Fractional", this.wRetirementStudio.wMaximumDeductible_Interest_Fractional.txtInterest_Fractional, dic["Interest_Fractional"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Interest_InterestTo", this.wRetirementStudio.wMaximumDeductible_Interest_InterestTo.txtInterest_InterestTo, dic["Interest_InterestTo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Interest_MaximumDeductible", this.wRetirementStudio.wMaximumDeductible_Interest_MaximumDeductible.txtInterest_MaximumDeductible, dic["Interest_MaximumDeductible"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
                
                _gLib._VerifySyncUDWin("Cushion_50ofFunding", this.wRetirementStudio.wMaximumDeductible_Cushion_50ofFunding.txtCushion_50ofFunding, dic["Cushion_50ofFunding"], 0);
                _gLib._VerifySyncUDWin("Cushion_FTIncrease", this.wRetirementStudio.wMaximumDeductible_Cushion_FTIncrease.txtCushion_FTIncrease, dic["Cushion_FTIncrease"], 0);
                _gLib._VerifySyncUDWin("Cushion_DeductionLimit", this.wRetirementStudio.wMaximumDeductible_Cushion_DeductionLimit.txtCushion_DeductionLimit, dic["Cushion_DeductionLimit"], 0);
                _gLib._VerifySyncUDWin("Alternate_DeductionLimit", this.wRetirementStudio.wMaximumDeductible_Alternate_DeductionLimit.txtAlternate_DeductionLimit, dic["Alternate_DeductionLimit"], 0);
                _gLib._VerifySyncUDWin("Alternate_MaximumDeductible", this.wRetirementStudio.wMaximumDeductible_Alternate_MaximumDeductible.txtAlternate_MaximumDeductible, dic["Alternate_MaximumDeductible"], 0);
                _gLib._VerifySyncUDWin("Interest_EarlierOf", this.wRetirementStudio.wMaximumDeductible_Interest_EarlierOf.cbo.txtInterest_EarlierOf, dic["Interest_EarlierOf"], 0);
                _gLib._VerifySyncUDWin("Interest_Fractional", this.wRetirementStudio.wMaximumDeductible_Interest_Fractional.txtInterest_Fractional, dic["Interest_Fractional"], 0);
                _gLib._VerifySyncUDWin("Interest_InterestTo", this.wRetirementStudio.wMaximumDeductible_Interest_InterestTo.txtInterest_InterestTo, dic["Interest_InterestTo"], 0);
                _gLib._VerifySyncUDWin("Interest_MaximumDeductible", this.wRetirementStudio.wMaximumDeductible_Interest_MaximumDeductible.txtInterest_MaximumDeductible, dic["Interest_MaximumDeductible"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FundingShortfall", "");
        ///    dic.Add("AmountPriorMRC", "");
        ///    dic.Add("AmountCurrentMRC", "");
        ///    dic.Add("QuaterlyAmount", "");
        ///    dic.Add("ShortfallCurrentYear", "");
        ///    dic.Add("QuaterlyAmountNextYear", "");
        ///    dic.Add("ContribtionDates_FirstQuarterly", "");
        ///    dic.Add("ContribtionDates_SecondQuarterly", "");
        ///    dic.Add("ContribtionDates_ThirdQuarterly", "");
        ///    dic.Add("ContribtionDates_FourthQuarterly", "");
        ///    dic.Add("ContribtionDates_FinalPayment", "");
        ///    dic.Add("YearAndDaysFourthQuterly_Years", "");
        ///    dic.Add("YearAndDaysFinalPayment_Years", "");
        ///    dic.Add("YearAndDaysFirstQuaterly_Days", "");
        ///    dic.Add("YearAndDaysSecondQuaterly_Days", "");
        ///    dic.Add("YearAndDaysThirdQuaterly_Days", "");
        ///    dic.Add("YearAndDaysFourthQuaterly_Days", "");
        ///    dic.Add("YearAndDaysFinalPayment_Days", "");
        ///    dic.Add("YearAndDaysRemainingAmount", "");
        ///    dic.Add("DiscountedContributionFirstQuaterly", "");
        ///    dic.Add("DiscountedContributionSecondQuaterly", "");
        ///    dic.Add("DiscountedContributionThirdQuaterly", "");
        ///    dic.Add("DiscountedContributionFourthQuaterly", "");
        ///    dic.Add("DiscountedContributionFinalPayment", "");
        ///    dic.Add("DiscountedContributionAvailableCredits", "");
        ///    dic.Add("CYContributionsFirstQuaterly", "");
        ///    dic.Add("CYContributionsSecondQuaterly", "");
        ///    dic.Add("CYContributionsThirdQuaterly", "");
        ///    dic.Add("CYContributionsFourthQuaterly", "");
        ///    dic.Add("CYContributionsFinalPayment", "");
        ///    dic.Add("BeginningOf_FirstQuarterly", "");
        ///    dic.Add("BeginningOf_SecondQuarterly", "");
        ///    dic.Add("BeginningOf_ThirdQuarterly", "");
        ///    dic.Add("BeginningOf_FourthQuarterly", "");
        ///    dic.Add("BeginningOf_FinalPayment", "");
        ///    pFundingInformation_ContributionSummary._PopVerify_QuaterlyContributionRequirement(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_QuaterlyContributionRequirement(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_QuaterlyContributionRequirement";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("FundingShortfall", this.wRetirementStudio.wQuarterlyContribtion_FundingShortfall.txtFundingShortfall, dic["FundingShortfall"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AmountPriorMRC", this.wRetirementStudio.wQuarterlyContribtion_AmountPriorMRC.txtAmountPriorMRC, dic["AmountPriorMRC"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AmountCurrentMRC", this.wRetirementStudio.wQuarterlyContribtion_AmountCurrentMRC.txtAmountCurrentMRC, dic["AmountCurrentMRC"], 0);
                _gLib._SetSyncUDWin_ByClipboard("QuaterlyAmount", this.wRetirementStudio.wQuarterlyContribtion_QuaterlyAmount.txtQuaterlyAmount, dic["QuaterlyAmount"], 0);
                _gLib._SetSyncUDWin("ShortfallCurrentYear", this.wRetirementStudio.wQuarterlyContribtion_ShortfallCurrentYear.cboShortfallCurrentYear, dic["ShortfallCurrentYear"], 0);
                _gLib._SetSyncUDWin_ByClipboard("QuaterlyAmountNextYear", this.wRetirementStudio.wQuarterlyContribtion_QuarterlyAmountNextYear.txtQuaterlyAmountNextYear, dic["QuaterlyAmountNextYear"], 0);
                _gLib._SendKeysUDWin("ContribtionDates_FirstQuarterly", this.wRetirementStudio.wContributionDates_FirstQuarterly.txtFirstQuarterly, dic["ContribtionDates_FirstQuarterly"], 0);
                _gLib._SendKeysUDWin("ContribtionDates_SecondQuarterly", this.wRetirementStudio.wContributionDates_SecondQuarterly.txtSecondQuarterly, dic["ContribtionDates_SecondQuarterly"], 0);
                _gLib._SendKeysUDWin("ContribtionDates_ThirdQuarterly", this.wRetirementStudio.wContributionDates_ThirdQuarterly.txtThirdQuarterly, dic["ContribtionDates_ThirdQuarterly"], 0);
                _gLib._SendKeysUDWin("ContribtionDates_FourthQuarterly", this.wRetirementStudio.wContributionDates_FourthQuarterly.txtFourthQuarterly, dic["ContribtionDates_FourthQuarterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ContribtionDates_FinalPayment", this.wRetirementStudio.wContribtionDates_FinalPayment.cbo.txtContribtionDates_FinalPayment, dic["ContribtionDates_FinalPayment"], 0);

                _gLib._SetSyncUDWin_ByClipboard("YearAndDaysFourthQuterly_Years", this.wRetirementStudio.wYearAndDaysFourthQuterly_Years.txt, dic["YearAndDaysFourthQuterly_Years"], 0);
                _gLib._SetSyncUDWin_ByClipboard("YearAndDaysFinalPayment_Years", this.wRetirementStudio.wYearAndDaysFinalPayment_Years.txt, dic["YearAndDaysFinalPayment_Years"], 0);
                _gLib._SetSyncUDWin_ByClipboard("YearAndDaysFirstQuaterly_Days", this.wRetirementStudio.wYearAndDaysFirstQuaterly_Days.txt, dic["YearAndDaysFirstQuaterly_Days"], 0);
                _gLib._SetSyncUDWin_ByClipboard("YearAndDaysSecondQuaterly_Days", this.wRetirementStudio.wYearAndDaysSecondQuaterly_Days.txt, dic["YearAndDaysSecondQuaterly_Days"], 0);
                _gLib._SetSyncUDWin_ByClipboard("YearAndDaysThirdQuaterly_Days", this.wRetirementStudio.wYearAndDaysThirdQuaterly_Days.txt, dic["YearAndDaysThirdQuaterly_Days"], 0);
                _gLib._SetSyncUDWin_ByClipboard("YearAndDaysFourthQuaterly_Days", this.wRetirementStudio.wYearAndDaysFourthQuaterly_Days.txt, dic["YearAndDaysFourthQuaterly_Days"], 0);
                _gLib._SetSyncUDWin_ByClipboard("YearAndDaysFinalPayment_Days", this.wRetirementStudio.wYearAndDaysFinalPayment_Days.txt, dic["YearAndDaysFinalPayment_Days"], 0);
                _gLib._SetSyncUDWin_ByClipboard("YearAndDaysRemainingAmount", this.wRetirementStudio.wYearAndDaysRemainingAmount.txt.UINumEditorEdit1, dic["YearAndDaysRemainingAmount"], 0);

                _gLib._SetSyncUDWin_ByClipboard("DiscountedContributionFirstQuaterly", this.wRetirementStudio.wDiscountedContributionFirstQuaterly.txt, dic["DiscountedContributionFirstQuaterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DiscountedContributionSecondQuaterly", this.wRetirementStudio.wDiscountedContributionSecondQuaterly.txt, dic["DiscountedContributionSecondQuaterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DiscountedContributionThirdQuaterly", this.wRetirementStudio.wDiscountedContributionThirdQuaterly.txt, dic["DiscountedContributionThirdQuaterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DiscountedContributionFourthQuaterly", this.wRetirementStudio.wDiscountedContributionFourthQuaterly.txt, dic["DiscountedContributionFourthQuaterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DiscountedContributionFinalPayment", this.wRetirementStudio.wDiscountedContributionFinalPayment.txt, dic["DiscountedContributionFinalPayment"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DiscountedContributionAvailableCredits", this.wRetirementStudio.wDiscountedContribution_AvailableCredits.txtAvailableCredits, dic["DiscountedContributionAvailableCredits"], 0);

                _gLib._SetSyncUDWin_ByClipboard("CYContributionsFirstQuaterly", this.wRetirementStudio.wCYContributionsFirstQuaterly.txt, dic["CYContributionsFirstQuaterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CYContributionsSecondQuaterly", this.wRetirementStudio.wCYContributionsSecondQuaterly.txt.UINumEditorEdit1, dic["CYContributionsSecondQuaterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CYContributionsThirdQuaterly", this.wRetirementStudio.wCYContributionsThirdQuaterly.txt, dic["CYContributionsThirdQuaterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CYContributionsFourthQuaterly", this.wRetirementStudio.wCYContributionsForthQuaterly.txt, dic["CYContributionsFourthQuaterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CYContributionsFinalPayment", this.wRetirementStudio.wCYContributionsFinalPayment.txt, dic["CYContributionsFinalPayment"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BeginningOf_FirstQuarterly", this.wRetirementStudio.wBeginningOf_FirstQuarterly.txtFirstQuarterly, dic["BeginningOf_FirstQuarterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BeginningOf_SecondQuarterly", this.wRetirementStudio.wBeginningOf_SecondQuarterly.txtSecondQuarterly, dic["BeginningOf_SecondQuarterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BeginningOf_ThirdQuarterly", this.wRetirementStudio.wBeginningOf_ThirdQuarterly.txtThirdQuarterly, dic["BeginningOf_ThirdQuarterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BeginningOf_FourthQuarterly", this.wRetirementStudio.wBeginningOf_FouthQuarterly.txtFouthQuarterly, dic["BeginningOf_FourthQuarterly"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BeginningOf_FinalPayment", this.wRetirementStudio.wBeginningOf_FinalPayment.txtFinalPayment, dic["BeginningOf_FinalPayment"], 0);

           
            
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("FundingShortfall", this.wRetirementStudio.wQuarterlyContribtion_FundingShortfall.txtFundingShortfall, dic["FundingShortfall"], 0);
                _gLib._VerifySyncUDWin("AmountPriorMRC", this.wRetirementStudio.wQuarterlyContribtion_AmountPriorMRC.txtAmountPriorMRC, dic["AmountPriorMRC"], 0);
                _gLib._VerifySyncUDWin("AmountCurrentMRC", this.wRetirementStudio.wQuarterlyContribtion_AmountCurrentMRC.txtAmountCurrentMRC, dic["AmountCurrentMRC"], 0);
                _gLib._VerifySyncUDWin("QuaterlyAmount", this.wRetirementStudio.wQuarterlyContribtion_QuaterlyAmount.txtQuaterlyAmount, dic["QuaterlyAmount"], 0);
                _gLib._VerifySyncUDWin("ShortfallCurrentYear", this.wRetirementStudio.wQuarterlyContribtion_ShortfallCurrentYear.cboShortfallCurrentYear, dic["ShortfallCurrentYear"], 0);
                _gLib._VerifySyncUDWin("QuaterlyAmountNextYear", this.wRetirementStudio.wQuarterlyContribtion_QuarterlyAmountNextYear.txtQuaterlyAmountNextYear, dic["QuaterlyAmountNextYear"], 0);
                _gLib._VerifySyncUDWin("ContribtionDates_FirstQuarterly", this.wRetirementStudio.wContributionDates_FirstQuarterly.txtFirstQuarterly, dic["ContribtionDates_FirstQuarterly"], 0);
                _gLib._VerifySyncUDWin("ContribtionDates_SecondQuarterly", this.wRetirementStudio.wContributionDates_SecondQuarterly.txtSecondQuarterly, dic["ContribtionDates_SecondQuarterly"], 0);
                _gLib._VerifySyncUDWin("ContribtionDates_ThirdQuarterly", this.wRetirementStudio.wContributionDates_ThirdQuarterly.txtThirdQuarterly, dic["ContribtionDates_ThirdQuarterly"], 0);
                _gLib._VerifySyncUDWin("ContribtionDates_FourthQuarterly", this.wRetirementStudio.wContributionDates_FourthQuarterly.txtFourthQuarterly, dic["ContribtionDates_FourthQuarterly"], 0);
                _gLib._VerifySyncUDWin("ContribtionDates_FinalPayment", this.wRetirementStudio.wContribtionDates_FinalPayment.cbo.txtContribtionDates_FinalPayment, dic["ContribtionDates_FinalPayment"], 0);

                _gLib._VerifySyncUDWin("YearAndDaysFourthQuterly_Years", this.wRetirementStudio.wYearAndDaysFourthQuterly_Years.txt, dic["YearAndDaysFourthQuterly_Years"], 0);
                _gLib._VerifySyncUDWin("YearAndDaysFinalPayment_Years", this.wRetirementStudio.wYearAndDaysFinalPayment_Years.txt, dic["YearAndDaysFinalPayment_Years"], 0);
                _gLib._VerifySyncUDWin("YearAndDaysFirstQuaterly_Days", this.wRetirementStudio.wYearAndDaysFirstQuaterly_Days.txt, dic["YearAndDaysFirstQuaterly_Days"], 0);
                _gLib._VerifySyncUDWin("YearAndDaysSecondQuaterly_Days", this.wRetirementStudio.wYearAndDaysSecondQuaterly_Days.txt, dic["YearAndDaysSecondQuaterly_Days"], 0);
                _gLib._VerifySyncUDWin("YearAndDaysThirdQuaterly_Days", this.wRetirementStudio.wYearAndDaysThirdQuaterly_Days.txt, dic["YearAndDaysThirdQuaterly_Days"], 0);
                _gLib._VerifySyncUDWin("YearAndDaysFourthQuaterly_Days", this.wRetirementStudio.wYearAndDaysFourthQuaterly_Days.txt, dic["YearAndDaysFourthQuaterly_Days"], 0);
                _gLib._VerifySyncUDWin("YearAndDaysFinalPayment_Days", this.wRetirementStudio.wYearAndDaysFinalPayment_Days.txt, dic["YearAndDaysFinalPayment_Days"], 0);
                _gLib._VerifySyncUDWin("YearAndDaysRemainingAmount", this.wRetirementStudio.wYearAndDaysRemainingAmount.txt.UINumEditorEdit1, dic["YearAndDaysRemainingAmount"], 0);

                _gLib._VerifySyncUDWin("DiscountedContributionFirstQuaterly", this.wRetirementStudio.wDiscountedContributionFirstQuaterly.txt, dic["DiscountedContributionFirstQuaterly"], 0);
                _gLib._VerifySyncUDWin("DiscountedContributionSecondQuaterly", this.wRetirementStudio.wDiscountedContributionSecondQuaterly.txt, dic["DiscountedContributionSecondQuaterly"], 0);
                _gLib._VerifySyncUDWin("DiscountedContributionThirdQuaterly", this.wRetirementStudio.wDiscountedContributionThirdQuaterly.txt, dic["DiscountedContributionThirdQuaterly"], 0);
                _gLib._VerifySyncUDWin("DiscountedContributionFourthQuaterly", this.wRetirementStudio.wDiscountedContributionFourthQuaterly.txt, dic["DiscountedContributionFourthQuaterly"], 0);
                _gLib._VerifySyncUDWin("DiscountedContributionFinalPayment", this.wRetirementStudio.wDiscountedContributionFinalPayment.txt, dic["DiscountedContributionFinalPayment"], 0);
                _gLib._VerifySyncUDWin("DiscountedContributionAvailableCredits", this.wRetirementStudio.wDiscountedContribution_AvailableCredits.txtAvailableCredits, dic["DiscountedContributionAvailableCredits"], 0);

                _gLib._VerifySyncUDWin("CYContributionsFirstQuaterly", this.wRetirementStudio.wCYContributionsFirstQuaterly.txt, dic["CYContributionsFirstQuaterly"], 0);
                _gLib._VerifySyncUDWin("CYContributionsSecondQuaterly", this.wRetirementStudio.wCYContributionsSecondQuaterly.txt.UINumEditorEdit1, dic["CYContributionsSecondQuaterly"], 0);
                _gLib._VerifySyncUDWin("CYContributionsThirdQuaterly", this.wRetirementStudio.wCYContributionsThirdQuaterly.txt, dic["CYContributionsThirdQuaterly"], 0);
                _gLib._VerifySyncUDWin("CYContributionsFourthQuaterly", this.wRetirementStudio.wCYContributionsForthQuaterly.txt, dic["CYContributionsFourthQuaterly"], 0);
                _gLib._VerifySyncUDWin("CYContributionsFinalPayment", this.wRetirementStudio.wCYContributionsFinalPayment.txt, dic["CYContributionsFinalPayment"], 0);
                _gLib._VerifySyncUDWin("BeginningOf_FirstQuarterly", this.wRetirementStudio.wBeginningOf_FirstQuarterly.txtFirstQuarterly, dic["BeginningOf_FirstQuarterly"], 0);
                _gLib._VerifySyncUDWin("BeginningOf_SecondQuarterly", this.wRetirementStudio.wBeginningOf_SecondQuarterly.txtSecondQuarterly, dic["BeginningOf_SecondQuarterly"], 0);
                _gLib._VerifySyncUDWin("BeginningOf_ThirdQuarterly", this.wRetirementStudio.wBeginningOf_ThirdQuarterly.txtThirdQuarterly, dic["BeginningOf_ThirdQuarterly"], 0);
                _gLib._VerifySyncUDWin("BeginningOf_FourthQuarterly", this.wRetirementStudio.wBeginningOf_FouthQuarterly.txtFouthQuarterly, dic["BeginningOf_FourthQuarterly"], 0);
                _gLib._VerifySyncUDWin("BeginningOf_FinalPayment", this.wRetirementStudio.wBeginningOf_FinalPayment.txtFinalPayment, dic["BeginningOf_FinalPayment"], 0);

           
            
     
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }





    }
}
