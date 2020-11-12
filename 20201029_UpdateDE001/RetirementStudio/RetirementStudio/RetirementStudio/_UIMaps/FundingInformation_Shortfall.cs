namespace RetirementStudio._UIMaps.FundingInformation_ShortfallClasses
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


    public partial class FundingInformation_Shortfall
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
        ///    dic.Add("COBAfter", "");
        ///    dic.Add("PFBAfter", "");
        ///    dic.Add("NetAssets", "");
        ///    dic.Add("FundingShortfall", "");
        ///    dic.Add("TransitionPercent", "");
        ///    dic.Add("TransitionFundingTarget", "");
        ///    dic.Add("TransitionFundingShortfall", "");
        ///    pFundingInformation_Shortfall._PopVerify_NetAssets(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_NetAssets(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_NetAssets";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("COBAfter", this.wRetirementStudio.wNetAssets_COBAfter.txtCOBAfter, dic["COBAfter"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PFBAfter", this.wRetirementStudio.wNetAssets_PFBAfter.txtPFBAfter, dic["PFBAfter"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NetAssets", this.wRetirementStudio.wNetAssets_NetAssets.txtNetAssets, dic["NetAssets"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FundingShortfall", this.wRetirementStudio.wNetAssets_FundingShortfall.txtFundingShortfall, dic["FundingShortfall"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TransitionPercent", this.wRetirementStudio.wNetAssets_TransitionPercent.txtTransitionPercent, dic["TransitionPercent"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TransitionFundingTarget", this.wRetirementStudio.wNetAssets_TransitionFundingTarget.txtTransitionFundingTarget, dic["TransitionFundingTarget"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TransitionFundingShortfall", this.wRetirementStudio.wNetAssets_TransitionFundingShortfall.txtTransitionFundingShortfall, dic["TransitionFundingShortfall"], 0);
            
            }

            if (dic["PopVerify"] == "Verify")
            {
 
                _gLib._VerifySyncUDWin("COBAfter", this.wRetirementStudio.wNetAssets_COBAfter.txtCOBAfter, dic["COBAfter"], 0);
                _gLib._VerifySyncUDWin("PFBAfter", this.wRetirementStudio.wNetAssets_PFBAfter.txtPFBAfter, dic["PFBAfter"], 0);
                _gLib._VerifySyncUDWin("NetAssets", this.wRetirementStudio.wNetAssets_NetAssets.txtNetAssets, dic["NetAssets"], 0);
                _gLib._VerifySyncUDWin("FundingShortfall", this.wRetirementStudio.wNetAssets_FundingShortfall.txtFundingShortfall, dic["FundingShortfall"], 0);
                _gLib._VerifySyncUDWin("TransitionPercent", this.wRetirementStudio.wNetAssets_TransitionPercent.txtTransitionPercent, dic["TransitionPercent"], 0);
                _gLib._VerifySyncUDWin("TransitionFundingTarget", this.wRetirementStudio.wNetAssets_TransitionFundingTarget.txtTransitionFundingTarget, dic["TransitionFundingTarget"], 0);
                _gLib._VerifySyncUDWin("TransitionFundingShortfall", this.wRetirementStudio.wNetAssets_TransitionFundingShortfall.txtTransitionFundingShortfall, dic["TransitionFundingShortfall"], 0);
            
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2018-Sep-10 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PY5Base", "");
        ///    dic.Add("PY4Base", "");
        ///    dic.Add("PY3Base", "");
        ///    dic.Add("PY2Base", "");
        ///    dic.Add("PY1Base", "");
        ///    dic.Add("PYBase", "");
        ///     dic.Add("Total", "");
        ///    pFundingInformation_Shortfall._PopVerify_PVOfPriorYearsShortfallBases(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PVOfPriorYearsShortfallBases(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PVOfPriorYearsShortfallBases";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("PY5Base", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_PY5.txtPY5, dic["PY5Base"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY4Base", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_PY4.txtPY4, dic["PY4Base"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY3Base", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_PY3.txtPY3, dic["PY3Base"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY2Base", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_PY2.txtPY2, dic["PY2Base"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY1Base", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_PY1.txtPY1, dic["PY1Base"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PYBase", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_PYBase.txtPYBase, dic["PYBase"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Total", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_Total.txtTotal, dic["Total"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("PY5Base", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_PY5.txtPY5, dic["PY5Base"], 0);
                _gLib._VerifySyncUDWin("PY4Base", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_PY4.txtPY4, dic["PY4Base"], 0);
                _gLib._VerifySyncUDWin("PY3Base", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_PY3.txtPY3, dic["PY3Base"], 0);
                _gLib._VerifySyncUDWin("PY2Base", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_PY2.txtPY2, dic["PY2Base"], 0);
                _gLib._VerifySyncUDWin("PY1Base", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_PY1.txtPY1, dic["PY1Base"], 0);
                _gLib._VerifySyncUDWin("PYBase", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_PYBase.txtPYBase, dic["PYBase"], 0);
                _gLib._VerifySyncUDWin("Total", this.wRetirementStudio.wPVOfPriorYrsShortfallBases_Total.txtTotal, dic["Total"], 0);

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
        ///    dic.Add("NewBaseAmount", "");
        ///    dic.Add("YearsForShortfall", "");
        ///    dic.Add("AmortizationFactor", "");
        ///    dic.Add("ShortfallAmortizationInstallment", "");
        ///    dic.Add("TotalSAI", "");
        ///    dic.Add("ShortfallAmortizationCharge", "");
        ///    pFundingInformation_Shortfall._PopVerify_PVOfPriorYearsFundingWaiverBases(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PVOfPriorYearsFundingWaiverBases(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PVOfPriorYearsFundingWaiverBases";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("NewBaseAmount", this.wRetirementStudio.wPVOfPirorYearWaiver_NewBaseAmount.txtNewBaseAmount, dic["NewBaseAmount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("YearsForShortfall", this.wRetirementStudio.wPVOfPirorYearWaiver_YearsForShortfall.txtYearsForShortfall, dic["YearsForShortfall"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AmortizationFactor", this.wRetirementStudio.wPVOfPirorYearWaiver_AmortizationFactor.txtAmortizationFactor, dic["AmortizationFactor"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ShortfallAmortizationInstallment", this.wRetirementStudio.wPVOfPirorYearWaiver_ShortfallAmortizationInstallment.txtShortfallAmortizationInstallment, dic["ShortfallAmortizationInstallment"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TotalSAI", this.wRetirementStudio.wPVOfPirorYearWaiver_TotalSAI.txtTotalSAI, dic["TotalSAI"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ShortfallAmortizationCharge", this.wRetirementStudio.wPVOfPirorYearWaiver_ShortfallAmortizationCharge.txtShortfallAmortizationCharge, dic["ShortfallAmortizationCharge"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {

                
                _gLib._VerifySyncUDWin("NewBaseAmount", this.wRetirementStudio.wPVOfPirorYearWaiver_NewBaseAmount.txtNewBaseAmount, dic["NewBaseAmount"], 0);
                _gLib._VerifySyncUDWin("YearsForShortfall", this.wRetirementStudio.wPVOfPirorYearWaiver_YearsForShortfall.txtYearsForShortfall, dic["YearsForShortfall"], 0);
                _gLib._VerifySyncUDWin("AmortizationFactor", this.wRetirementStudio.wPVOfPirorYearWaiver_AmortizationFactor.txtAmortizationFactor, dic["AmortizationFactor"], 0);
                _gLib._VerifySyncUDWin("ShortfallAmortizationInstallment", this.wRetirementStudio.wPVOfPirorYearWaiver_ShortfallAmortizationInstallment.txtShortfallAmortizationInstallment, dic["ShortfallAmortizationInstallment"], 0);
                _gLib._VerifySyncUDWin("TotalSAI", this.wRetirementStudio.wPVOfPirorYearWaiver_TotalSAI.txtTotalSAI, dic["TotalSAI"], 0);
                _gLib._VerifySyncUDWin("ShortfallAmortizationCharge", this.wRetirementStudio.wPVOfPirorYearWaiver_ShortfallAmortizationCharge.txtShortfallAmortizationCharge, dic["ShortfallAmortizationCharge"], 0);

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
        ///    dic.Add("CY", "");
        ///    dic.Add("CY1", "");
        ///    dic.Add("CY2", "");
        ///    dic.Add("CY3", "");
        ///    dic.Add("CY4", "");
        ///    dic.Add("CY5", "");
        ///    dic.Add("CY6", "");
        ///    dic.Add("CY7", "");
        ///    dic.Add("CY8", "");
        ///    dic.Add("CY9", "");
        ///    pFundingInformation_Shortfall._PopVerify_InterestRatesByYear(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_InterestRatesByYear(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_InterestRatesByYear";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("CY", this.wRetirementStudio.wInterestRates_CY.txtCY, dic["CY"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY1", this.wRetirementStudio.wInterestRates_CY1.txtCY1, dic["CY1"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY2", this.wRetirementStudio.wInterestRates_CY2.txtCY2, dic["CY2"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY3", this.wRetirementStudio.wInterestRates_CY3.txtCY3, dic["CY3"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY4", this.wRetirementStudio.wInterestRates_CY4.txtCY4, dic["CY4"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY5", this.wRetirementStudio.wInterestRates_CY5.txtCY5, dic["CY5"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY6", this.wRetirementStudio.wInterestRates_CY6.txtCY6, dic["CY6"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY7", this.wRetirementStudio.wInterestRates_CY7.txtCY7, dic["CY7"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY8", this.wRetirementStudio.wInterestRates_CY8.txtCY8, dic["CY8"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY9", this.wRetirementStudio.wInterestRates_CY9.txtCY9, dic["CY9"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {


                
                _gLib._VerifySyncUDWin("CY", this.wRetirementStudio.wInterestRates_CY.txtCY, dic["CY"], 0);
                _gLib._VerifySyncUDWin("CY1", this.wRetirementStudio.wInterestRates_CY1.txtCY1, dic["CY1"], 0);
                _gLib._VerifySyncUDWin("CY2", this.wRetirementStudio.wInterestRates_CY2.txtCY2, dic["CY2"], 0);
                _gLib._VerifySyncUDWin("CY3", this.wRetirementStudio.wInterestRates_CY3.txtCY3, dic["CY3"], 0);
                _gLib._VerifySyncUDWin("CY4", this.wRetirementStudio.wInterestRates_CY4.txtCY4, dic["CY4"], 0);
                _gLib._VerifySyncUDWin("CY5", this.wRetirementStudio.wInterestRates_CY5.txtCY5, dic["CY5"], 0);
                _gLib._VerifySyncUDWin("CY6", this.wRetirementStudio.wInterestRates_CY6.txtCY6, dic["CY6"], 0);
                _gLib._VerifySyncUDWin("CY7", this.wRetirementStudio.wInterestRates_CY7.txtCY7, dic["CY7"], 0);
                _gLib._VerifySyncUDWin("CY8", this.wRetirementStudio.wInterestRates_CY8.txtCY8, dic["CY8"], 0);
                _gLib._VerifySyncUDWin("CY9", this.wRetirementStudio.wInterestRates_CY9.txtCY9, dic["CY9"], 0);
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
        ///    dic.Add("CY", "");
        ///    dic.Add("CY1", "");
        ///    dic.Add("CY2", "");
        ///    dic.Add("CY3", "");
        ///    dic.Add("CY4", "");
        ///    dic.Add("CY5", "");
        ///    dic.Add("CY6", "");
        ///    dic.Add("CY7", "");
        ///    dic.Add("CY8", "");
        ///    dic.Add("CY9", "");
        ///    pFundingInformation_Shortfall._PopVerify_DiscountFactors(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DiscountFactors(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_DiscountFactors";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("CY", this.wRetirementStudio.wDiscountFactors_CY.txtCY, dic["CY"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY1", this.wRetirementStudio.wDiscountFactors_CY1.txtCY1, dic["CY1"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY2", this.wRetirementStudio.wDiscountFactors_CY2.txtCY2, dic["CY2"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY3", this.wRetirementStudio.wDiscountFactors_CY3.txtCY3, dic["CY3"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY4", this.wRetirementStudio.wDiscountFactors_CY4.txtCY4, dic["CY4"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY5", this.wRetirementStudio.wDiscountFactors_CY5.txtCY5, dic["CY5"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY6", this.wRetirementStudio.wDiscountFactors_CY6.txtCY6, dic["CY6"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY7", this.wRetirementStudio.wDiscountFactors_CY7.txtCY7, dic["CY7"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY8", this.wRetirementStudio.wDiscountFactors_CY8.txtCY8, dic["CY8"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CY9", this.wRetirementStudio.wDiscountFactors_CY9.txtCY9, dic["CY9"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {



                _gLib._VerifySyncUDWin("CY", this.wRetirementStudio.wDiscountFactors_CY.txtCY, dic["CY"], 0);
                _gLib._VerifySyncUDWin("CY1", this.wRetirementStudio.wDiscountFactors_CY1.txtCY1, dic["CY1"], 0);
                _gLib._VerifySyncUDWin("CY2", this.wRetirementStudio.wDiscountFactors_CY2.txtCY2, dic["CY2"], 0);
                _gLib._VerifySyncUDWin("CY3", this.wRetirementStudio.wDiscountFactors_CY3.txtCY3, dic["CY3"], 0);
                _gLib._VerifySyncUDWin("CY4", this.wRetirementStudio.wDiscountFactors_CY4.txtCY4, dic["CY4"], 0);
                _gLib._VerifySyncUDWin("CY5", this.wRetirementStudio.wDiscountFactors_CY5.txtCY5, dic["CY5"], 0);
                _gLib._VerifySyncUDWin("CY6", this.wRetirementStudio.wDiscountFactors_CY6.txtCY6, dic["CY6"], 0);
                _gLib._VerifySyncUDWin("CY7", this.wRetirementStudio.wDiscountFactors_CY7.txtCY7, dic["CY7"], 0);
                _gLib._VerifySyncUDWin("CY8", this.wRetirementStudio.wDiscountFactors_CY8.txtCY8, dic["CY8"], 0);
                _gLib._VerifySyncUDWin("CY9", this.wRetirementStudio.wDiscountFactors_CY9.txtCY9, dic["CY9"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2018-Sep-10 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PY5_Amount", "");
        ///    dic.Add("PY4_Amount", "");
        ///    dic.Add("PY3_Amount", "");
        ///    dic.Add("PY2_Amount", "");
        ///    dic.Add("PY1_Amount", "");
        ///    dic.Add("PY_Amount", "");
        ///    dic.Add("PY5_RemainingYrs", "");
        ///    dic.Add("PY4_RemainingYrs", "");
        ///    dic.Add("PY3_RemainingYrs", "");
        ///    dic.Add("PY2_RemainingYrs", "");
        ///    dic.Add("PY1_RemainingYrs", "");
        ///    dic.Add("PY_RemainingYrs", "");
        ///    pFundingInformation_Shortfall._PopVerify_PriorYrsShortfallAmortizationInstallments(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PriorYrsShortfallAmortizationInstallments(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PriorYrsShortfallAmortizationInstallments";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("PY5_Amount", this.wRetirementStudio.wPriorYrsShortfall_PY5Amount.txtPY5Amount, dic["PY5_Amount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY4_Amount", this.wRetirementStudio.wPriorYrsShortfall_PY4Amount.txtPY4Amount, dic["PY4_Amount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY3_Amount", this.wRetirementStudio.wPriorYrsShortfall_PY3Amount.txtPY3Amount, dic["PY3_Amount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY2_Amount", this.wRetirementStudio.wPriorYrsShortfall_PY2Amount.txtPY2Amount, dic["PY2_Amount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY1_Amount", this.wRetirementStudio.wPriorYrsShortfall_PY1Amount.txtPY1Amount, dic["PY1_Amount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY_Amount", this.wRetirementStudio.wPriorYrsShortfall_PYAmount.txtPYAmount, dic["PY_Amount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY5_RemainingYrs", this.wRetirementStudio.wPriorYrsShortfall_PY5RemainingYrs.txtPY5RemainingYrs, dic["PY5_RemainingYrs"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY4_RemainingYrs", this.wRetirementStudio.wPriorYrsShortfall_PY4RemainingYrs.PY4RemainingYrs, dic["PY4_RemainingYrs"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY3_RemainingYrs", this.wRetirementStudio.wPriorYrsShortfall_PY3RemainingYrs.txtPY3RemainingYrs, dic["PY3_RemainingYrs"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY2_RemainingYrs", this.wRetirementStudio.wPriorYrsShortfall_PY2RemainingYrs.PY2RemainingYrs, dic["PY2_RemainingYrs"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY1_RemainingYrs", this.wRetirementStudio.wPriorYrsShortfall_PY1RemainingYrs.txtPY1RemainingYrs, dic["PY1_RemainingYrs"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY_RemainingYrs", this.wRetirementStudio.wPriorYrsShortfall_PYRemainingYrs.txtPYRemainingYrs, dic["PY_RemainingYrs"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._SetSyncUDWin_ByClipboard("PY5_Amount", this.wRetirementStudio.wPriorYrsShortfall_PY5Amount.txtPY5Amount, dic["PY5_Amount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY4_Amount", this.wRetirementStudio.wPriorYrsShortfall_PY4Amount.txtPY4Amount, dic["PY4_Amount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY3_Amount", this.wRetirementStudio.wPriorYrsShortfall_PY3Amount.txtPY3Amount, dic["PY3_Amount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY2_Amount", this.wRetirementStudio.wPriorYrsShortfall_PY2Amount.txtPY2Amount, dic["PY2_Amount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY1_Amount", this.wRetirementStudio.wPriorYrsShortfall_PY1Amount.txtPY1Amount, dic["PY1_Amount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY_Amount", this.wRetirementStudio.wPriorYrsShortfall_PYAmount.txtPYAmount, dic["PY_Amount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY5_RemainingYrs", this.wRetirementStudio.wPriorYrsShortfall_PY5RemainingYrs.txtPY5RemainingYrs, dic["PY5_RemainingYrs"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY4_RemainingYrs", this.wRetirementStudio.wPriorYrsShortfall_PY4RemainingYrs.PY4RemainingYrs, dic["PY4_RemainingYrs"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY3_RemainingYrs", this.wRetirementStudio.wPriorYrsShortfall_PY3RemainingYrs.txtPY3RemainingYrs, dic["PY3_RemainingYrs"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY2_RemainingYrs", this.wRetirementStudio.wPriorYrsShortfall_PY2RemainingYrs.PY2RemainingYrs, dic["PY2_RemainingYrs"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY1_RemainingYrs", this.wRetirementStudio.wPriorYrsShortfall_PY1RemainingYrs.txtPY1RemainingYrs, dic["PY1_RemainingYrs"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PY_RemainingYrs", this.wRetirementStudio.wPriorYrsShortfall_PYRemainingYrs.txtPYRemainingYrs, dic["PY_RemainingYrs"], 0);

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
        ///    dic.Add("Year1", "");
        ///    dic.Add("Year2", "");
        ///    dic.Add("Year3", "");
        ///    dic.Add("Year4", "");
        ///    dic.Add("Year5", "");
        ///    dic.Add("Year6", "");
        ///    dic.Add("Year7", "");
        ///    dic.Add("Year8", "");
        ///    dic.Add("Year9", "");
        ///    dic.Add("Year10", "");
        ///    pFundingInformation_Shortfall._PopVerify_AmortizationFactors(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_AmortizationFactors(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_AmortizationFactors";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("Year1", this.wRetirementStudio.wAmortizationFactors_Year1.txtYear1, dic["Year1"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Year2", this.wRetirementStudio.wAmortizationFactors_Year2.txtYear2, dic["Year2"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Year3", this.wRetirementStudio.wAmortizationFactors_Year3.txtYear3, dic["Year3"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Year4", this.wRetirementStudio.wAmortizationFactors_Year4.txtYear4, dic["Year4"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Year5", this.wRetirementStudio.wAmortizationFactors_Year5.txtYear5, dic["Year5"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Year6", this.wRetirementStudio.wAmortizationFactors_Year6.txtYear6, dic["Year6"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Year7", this.wRetirementStudio.wAmortizationFactors_Year7.txtYear7, dic["Year7"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Year8", this.wRetirementStudio.wAmortizationFactors_Year8.txtYear8, dic["Year8"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Year9", this.wRetirementStudio.wAmortizationFactors_Year9.txtYear9, dic["Year9"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Year10", this.wRetirementStudio.wAmortizationFactors_Year10.txtYear10, dic["Year10"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {


                _gLib._VerifySyncUDWin("Year1", this.wRetirementStudio.wAmortizationFactors_Year1.txtYear1, dic["Year1"], 0);
                _gLib._VerifySyncUDWin("Year2", this.wRetirementStudio.wAmortizationFactors_Year2.txtYear2, dic["Year2"], 0);
                _gLib._VerifySyncUDWin("Year3", this.wRetirementStudio.wAmortizationFactors_Year3.txtYear3, dic["Year3"], 0);
                _gLib._VerifySyncUDWin("Year4", this.wRetirementStudio.wAmortizationFactors_Year4.txtYear4, dic["Year4"], 0);
                _gLib._VerifySyncUDWin("Year5", this.wRetirementStudio.wAmortizationFactors_Year5.txtYear5, dic["Year5"], 0);
                _gLib._VerifySyncUDWin("Year6", this.wRetirementStudio.wAmortizationFactors_Year6.txtYear6, dic["Year6"], 0);
                _gLib._VerifySyncUDWin("Year7", this.wRetirementStudio.wAmortizationFactors_Year7.txtYear7, dic["Year7"], 0);
                _gLib._VerifySyncUDWin("Year8", this.wRetirementStudio.wAmortizationFactors_Year8.txtYear8, dic["Year8"], 0);
                _gLib._VerifySyncUDWin("Year9", this.wRetirementStudio.wAmortizationFactors_Year9.txtYear9, dic["Year9"], 0);
                _gLib._VerifySyncUDWin("Year10", this.wRetirementStudio.wAmortizationFactors_Year10.txtYear10, dic["Year10"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
