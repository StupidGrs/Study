namespace RetirementStudio._UIMaps.PlanDefinitionClasses
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


    public partial class PlanDefinition
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        /// <summary>
        /// 2013-May-13
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SingleFormulaOrBenefit", "");
        ///    dic.Add("FunctionOfOtherFormulasOrBenefitDefinitions", "");
        ///    dic.Add("NondiscriminationTestingBenefit", "");
        ///    dic.Add("ForTestingAccrualRate", "");
        ///    dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
        ///    dic.Add("FormOfPaymentDiffersByMaritalStatus", "");
        ///    dic.Add("PBGC4044Calculations", "");
        ///    dic.Add("NormalFormofPayment", "");
        ///    dic.Add("ParticipantType", "");
        ///    dic.Add("SingleFormulaBenefit", "");
        ///    dic.Add("Function", "");
        ///    dic.Add("Validate", "");
        ///    dic.Add("btnBenefitCommenceAge_V", "");
        ///    dic.Add("BenefitCommenceAge_cbo", "");
        ///    dic.Add("btnBenefitCommenceAge_C", "");
        ///    dic.Add("BenefitCommenceAge_txt", "");
        ///    dic.Add("btnBenefitStopAge_V", "");
        ///    dic.Add("BenefitStopAge_cbo", "");
        ///    dic.Add("btnBenefitStopAge_C", "");
        ///    dic.Add("BenefitStopAge_txt", "");
        ///    dic.Add("VestingDefinition", "");
        ///    dic.Add("CostOfLivingAdjustmentFactor", "");
        ///    dic.Add("EarlyRetirementFactor", "");
        ///    dic.Add("LateRetirementFactor", "");
        ///    dic.Add("AdjustmentFactor", "");
        ///    dic.Add("ConversionFactor", "");
        ///    dic.Add("ConversionFactor_Married", "");
        ///    dic.Add("ConversionFactor_Single", "");
        ///    dic.Add("FormOfPayment", ""); 
        ///    dic.Add("FormOfPayment_Married", "");
        ///    dic.Add("FormOfPayment_Single", "");
        ///    dic.Add("BenefitElectionPercentage", "");
        ///    dic.Add("BenefitElectionPercentage_Married", "");   
        ///    dic.Add("BenefitElectionPercentage_Single", "");
        ///    dic.Add("MaximumBenefitLimitation", "");   
        ///    dic.Add("MaximumBenefitLimitation_Married", "");
        ///    dic.Add("MaximumBenefitLimitation_Single", "");   
        ///    dic.Add("Decrement", ""); 
        ///    dic.Add("ExcludePercentMarried", ""); 
        ///    dic.Add("ApplyDifferentStartAge", ""); 
        ///    dic.Add("PostDecrementMortality", ""); 
        ///    dic.Add("MostValuableForm", "");   
        ///    dic.Add("MaximumBenefitLimitation_CA", "");   
        ///    dic.Add("LumpSumCommutedValue", "");   
        ///    dic.Add("ActuarialEquivalenceForLump", "");   
        ///    dic.Add("SpecialWithdrawalBenefit", "");   
        ///    pPlanDefinition._PopVerify_PlanDefinition(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PlanDefinition(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PlanDefinition";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

  
            int iBenefitCommenceAge_txt = 0;
            int iBenefitStopAge_txt = 0;
            int iBenefitCommenceAge_cbo = 0;
            int iBenefitStopAge_cbo = 0;
  
            int iIncrease_cbo = 0;
            int iTxtIncrease_txt = 0;


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("SingleFormulaOrBenefit", this.wRetirementStudio.wSingleFormulaOrBenefit.rdSingleFormulaOrBenefit, dic["SingleFormulaOrBenefit"], 0);
                _gLib._SetSyncUDWin("FunctionOfOtherFormulasOrBenefitDefinitions", this.wRetirementStudio.wFunctionOfOtherFormulasOrBenefitDefinitions.rdFunctionOfOtherFormulasOrBenefitDefinitions, dic["FunctionOfOtherFormulasOrBenefitDefinitions"], 0);
                _gLib._SetSyncUDWin("NondiscriminationTestingBenefit", this.wRetirementStudio.wNonDiscrimination.chx, dic["NondiscriminationTestingBenefit"], 0);
                _gLib._SetSyncUDWin("ForTestingAccrualRate", this.wRetirementStudio.wForTestingAccrualRate.cbo, dic["ForTestingAccrualRate"], 0);
                _gLib._SetSyncUDWin("IncludeThisBenefitInPresentValueCalculations", this.wRetirementStudio.wIncludeThisBenefitInPresentValueCalculations.chkIncludeThisBenefitInPresentValueCalculations, dic["IncludeThisBenefitInPresentValueCalculations"], 0);
                _gLib._SetSyncUDWin("FormOfPaymentDiffersByMaritalStatus", this.wRetirementStudio.wFormOfPaymentDiffersByMaritalStatus.chkFormOfPaymentDiffersByMaritalStatus, dic["FormOfPaymentDiffersByMaritalStatus"], 0);
                _gLib._SetSyncUDWin("PBGC4044Calculations", this.wRetirementStudio.wPBGC4044Calculations.chk, dic["PBGC4044Calculations"], 0);
                _gLib._SetSyncUDWin("NormalFormofPayment", this.wRetirementStudio.wNormalFormOfPayme.cbo, dic["NormalFormofPayment"], 0);
                _gLib._SetSyncUDWin("ParticipantType", this.wRetirementStudio.wParticipantType.cboParticipantType, dic["ParticipantType"], 0);
                _gLib._SetSyncUDWin("SingleFormulaBenefit", this.wRetirementStudio.wSingleFormulaBenefit.cboSingleFormulaBenefit, dic["SingleFormulaBenefit"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Function", this.wRetirementStudio.wFunction.txtFunction, dic["Function"], 0);
                _gLib._SetSyncUDWin("Validate", this.wRetirementStudio.wValidate.btnValidate, dic["Validate"], 0);


                //  BenefitCommenceAge
                _gLib._SetSyncUDWin("btnBenefitCommenceAge_V", this.wRetirementStudio.wBenefitCommenceAge_VIcon.btnBenefitCommenceAge_V, dic["btnBenefitCommenceAge_V"], 0);
                _gLib._SetSyncUDWin("btnBenefitCommenceAge_C", this.wRetirementStudio.wBenefitCommenceAge_CIcon.btnBenefitCommenceAge_C, dic["btnBenefitCommenceAge_C"], 0);
                if (dic["btnBenefitCommenceAge_V"] != "")
                {
                    iBenefitCommenceAge_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitCommenceAge_cbo.ToString());
                    _gLib._SetSyncUDWin("BenefitCommenceAge_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["BenefitCommenceAge_cbo"], 0);
                }
                if (dic["btnBenefitCommenceAge_C"] != "")
                {
                    iBenefitCommenceAge_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitCommenceAge_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("BenefitCommenceAge_txt", this.wRetirementStudio.wCommonTXT.txt, dic["BenefitCommenceAge_txt"], true, 0);
                }


                //  BenefitStopAge
                _gLib._SetSyncUDWin("btnBenefitStopAge_V", this.wRetirementStudio.wBenefitStopAge_VIcon.btnBenefitStopAge_V, dic["btnBenefitStopAge_V"], 0);
                _gLib._SetSyncUDWin("btnBenefitStopAge_C", this.wRetirementStudio.wBenefitStopAge_CIcon.btnBenefitStopAge_C, dic["btnBenefitStopAge_C"], 0);
                if (dic["btnBenefitStopAge_V"] != "")
                {
                    iBenefitStopAge_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitStopAge_cbo.ToString());
                    _gLib._SetSyncUDWin("BenefitStopAge_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["BenefitStopAge_cbo"], 0);
                }
                if (dic["btnBenefitStopAge_C"] != "")
                {
                    iBenefitStopAge_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitStopAge_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("BenefitStopAge_txt", this.wRetirementStudio.wCommonTXT.txt, dic["BenefitStopAge_txt"], true, 0);
                }

                _gLib._SetSyncUDWin("VestingDefinition", this.wRetirementStudio.wVestingDefinition.cboVestingDefinition, dic["VestingDefinition"], 0);
                _gLib._SetSyncUDWin("CostOfLivingAdjustmentFactor", this.wRetirementStudio.wCostOfLivingAdjustmentFactor.cboCostOfLivingAdjustmentFactor, dic["CostOfLivingAdjustmentFactor"], 0);
                _gLib._SetSyncUDWin("EarlyRetirementFactor", this.wRetirementStudio.wEarlyRetirementFactor.cboEarlyRetirementFactor, dic["EarlyRetirementFactor"], 0);
                _gLib._SetSyncUDWin("LateRetirementFactor", this.wRetirementStudio.wLateRetirementFactor.cboLateRetirementFactor, dic["LateRetirementFactor"], 0);
                _gLib._SetSyncUDWin("AdjustmentFactor", this.wRetirementStudio.wAdjustmentFactor.cboAdjustmentFactor, dic["AdjustmentFactor"], 0);
                _gLib._SetSyncUDWin("ConversionFactor", this.wRetirementStudio.wConversionFactor.cboConversionFactor, dic["ConversionFactor"], 0);
                _gLib._SetSyncUDWin("ConversionFactor_Married", this.wRetirementStudio.wConversionFactor_Married.cboConversionFactor_Married, dic["ConversionFactor_Married"], 0);
                _gLib._SetSyncUDWin("ConversionFactor_Single", this.wRetirementStudio.wConversionFactor_Single.cboConversionFactor_Single, dic["ConversionFactor_Single"], 0);
                _gLib._SetSyncUDWin("FormOfPayment", this.wRetirementStudio.wFormOfPayment.cboFormOfPayment, dic["FormOfPayment"], 0);
                _gLib._SetSyncUDWin("FormOfPayment_Married", this.wRetirementStudio.wFormOfPayment_Married.cboFormOfPayment_Married, dic["FormOfPayment_Married"], 0);
                _gLib._SetSyncUDWin("FormOfPayment_Single", this.wRetirementStudio.wFormOfPayment_Single.cboFormOfPayment_Single, dic["FormOfPayment_Single"], 0);
                _gLib._SetSyncUDWin("BenefitElectionPercentage", this.wRetirementStudio.wBenefitElectionPercentage.cboBenefitElectionPercentage, dic["BenefitElectionPercentage"], 0);
                _gLib._SetSyncUDWin("BenefitElectionPercentage_Married", this.wRetirementStudio.wBenefitElectionPercentage_Married.cboBenefitElectionPercentage_Married, dic["BenefitElectionPercentage_Married"], 0);

               

                if (dic["BenefitElectionPercentage_Single_CA"] != "")
                {
                    if (dic["BenefitElectionPercentage_Single_CA"] == "#1#")
                    {
                        //// instance start from 1
                        String instance = dic["BenefitElectionPercentage_Single_CA"].Replace("#", "");
                        this.wRS.wBenefitElectionPercentage_Single.wList.wListItems.SearchProperties.Add(WinListItem.PropertyNames.Instance, instance);

                        ///// set
                        Mouse.Click(this.wRetirementStudio.wBenefitElectionPercentage_Single.cboBenefitElectionPercentage_Single, new Point(5, 5));
                        Mouse.Click(this.wRS.wBenefitElectionPercentage_Single.wList.wListItems, new Point(5, 5));

                        //// verify
                        Mouse.Click(this.wRetirementStudio.wBenefitElectionPercentage_Single.cboBenefitElectionPercentage_Single, new Point(5, 5));
                        if (this.wRS.wBenefitElectionPercentage_Single.wList.wListItems.Selected != true)
                            _gLib._MsgBoxYesNo("", "Please set <BenefitElectionPercentage_Single_CA> as: " + dic["BenefitElectionPercentage_Single_CA"]);
                    }
                    else
                    {

                        try
                        {
                            ///// set
                            Mouse.Click(this.wRetirementStudio.wBenefitElectionPercentage_Single.cboBenefitElectionPercentage_Single, new Point(5, 5));
                            Mouse.Click(this.wRS.wBenefitElectionPercentage_Single.wList.wListItems, new Point(5, 5));

                            //// verify
                            Mouse.Click(this.wRetirementStudio.wBenefitElectionPercentage_Single.cboBenefitElectionPercentage_Single, new Point(5, 5));
                            if (this.wRS.wBenefitElectionPercentage_Single.wList.wListItems.Selected != true)
                                _gLib._MsgBoxYesNo("", "Please set <BenefitElectionPercentage_Single_CA> as: " + dic["BenefitElectionPercentage_Single_CA"]);
                        }
                        catch (Exception ex)
                        {
                            _gLib._MsgBoxYesNo("", "Please set <BenefitElectionPercentage_Single_CA> as: " + dic["BenefitElectionPercentage_Single_CA"]);
                        }
                    }
                }

                
                _gLib._SetSyncUDWin("BenefitElectionPercentage_Single", this.wRetirementStudio.wBenefitElectionPercentage_Single.cboBenefitElectionPercentage_Single, dic["BenefitElectionPercentage_Single"], 0);
                _gLib._SetSyncUDWin("MaximumBenefitLimitation", this.wRetirementStudio.wMaximumBenefitLimitation.cboMaximumBenefitLimitation, dic["MaximumBenefitLimitation"], 0);
                _gLib._SetSyncUDWin("MaximumBenefitLimitation_Married", this.wRetirementStudio.wMaximumBenefitLimitation_Married.cboMaximumBenefitLimitation_Married, dic["MaximumBenefitLimitation_Married"], 0);
                _gLib._SetSyncUDWin("MaximumBenefitLimitation_Single", this.wRetirementStudio.wMaximumBenefitLimitation_Single.cboMaximumBenefitLimitation_Single, dic["MaximumBenefitLimitation_Single"], 0);
                _gLib._SetSyncUDWin("Decrement", this.wRetirementStudio.wDecrement.cboDecrement, dic["Decrement"], 0);
                _gLib._SetSyncUDWin("ExcludePercentMarried", this.wRetirementStudio.wExcludePercentMarried.chkExcludePercentMarried, dic["ExcludePercentMarried"], 0);
                _gLib._SetSyncUDWin("ApplyDifferentStartAge", this.wRetirementStudio.wApplyDifferentStartAge.chkApplyDifferentStartAge, dic["ApplyDifferentStartAge"], 0);
                _gLib._SetSyncUDWin("PostDecrementMortality", this.wRetirementStudio.wPostDecrementMortality.cboPostDecrementMortality, dic["PostDecrementMortality"], 0);
                _gLib._SetSyncUDWin("MostValuableForm", this.wRetirementStudio.wMostValuableFormOfPayment.cbo, dic["MostValuableForm"], 0);
                _gLib._SetSyncUDWin("MaximumBenefitLimitation_CA", this.wRetirementStudio.wMaximumBenefitLimitation_CA.cbo, dic["MaximumBenefitLimitation_CA"], 0);
                _gLib._SetSyncUDWin("LumpSumCommutedValue", this.wRetirementStudio.wLumpSumCommutedValue.chx, dic["LumpSumCommutedValue"], 0);
                _gLib._SetSyncUDWin("ActuarialEquivalenceForLump", this.wRetirementStudio.wActuarialEquivale.cbo, dic["ActuarialEquivalenceForLump"], 0);
                _gLib._SetSyncUDWin("SpecialWithdrawalBenefit", this.wRetirementStudio.wSpecialWithdrawalBenefit.chk, dic["SpecialWithdrawalBenefit"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2017-May-16 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("IncludeThisBenefitInPresentValueCalculations", "");
        ///    dic.Add("PBGC4044Calculations", "True");
        ///    dic.Add("PBGC4044_BenefitBelongsInPBGC", "");
        ///    dic.Add("PBGC4044_PriorityCategory", "");
        ///    dic.Add("PBGC4044_BenefitCommenceAge", "");
        ///    dic.Add("PBGC4044_AgeAtValYear3", "");
        ///    dic.Add("PBGC4044_ApplyPBGCMaxBenefit", "");
        ///    dic.Add("PBGC4044_PBGCMaxBenefit", "");
        ///    dic.Add("PBGC4044_ApplyMinBenefit", "");
        ///    dic.Add("PBGC4044_MinBenefit", "");
        ///    dic.Add("PBGC4044_ApplyPhaseIn", "");
        ///    dic.Add("PBGC4044_BenefitValYear1", "");
        ///    dic.Add("PBGC4044_BenefitValYear2", "");
        ///    dic.Add("PBGC4044_BenefitValYear3", "");
        ///    dic.Add("PBGC4044_BenefitValYear4", "");
        ///    dic.Add("PBGC4044_BenefitValYear5", "");
        ///    pPlanDefinition._PopVerify_PBGC4044Parameters(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PBGC4044Parameters(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PBGC4044Parameters";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("IncludeThisBenefitInPresentValueCalculations", this.wRetirementStudio.wIncludeThisBenefitInPresentValueCalculations.chkIncludeThisBenefitInPresentValueCalculations, dic["IncludeThisBenefitInPresentValueCalculations"], 0);
                _gLib._SetSyncUDWin("PBGC4044Calculations", this.wRetirementStudio.wPBGC4044Calculations.chk, dic["PBGC4044Calculations"], 0);
                _gLib._SetSyncUDWin("PBGC4044_BenefitBelongsInPBGC", this.wRetirementStudio.wPBGC4044_BenefitBelongsInPBGC.chk, dic["PBGC4044_BenefitBelongsInPBGC"], 0);
                _gLib._SetSyncUDWin("PBGC4044_PriorityCategory", this.wRetirementStudio.wPBGC4044_PriorityCategory.cbo, dic["PBGC4044_PriorityCategory"], 0);
                _gLib._SetSyncUDWin("PBGC4044_BenefitCommenceAge", this.wRetirementStudio.wPBGC4044_BenefitCommenceAge.rd, dic["PBGC4044_BenefitCommenceAge"], 0);
                _gLib._SetSyncUDWin("PBGC4044_AgeAtValYear3", this.wRetirementStudio.wPBGC4044_AgeAtValYear3.rd, dic["PBGC4044_AgeAtValYear3"], 0);
                _gLib._SetSyncUDWin("PBGC4044_ApplyPBGCMaxBenefit", this.wRetirementStudio.wPBGC4044_ApplyPBGCMaxBenefit.chk, dic["PBGC4044_ApplyPBGCMaxBenefit"], 0);
                _gLib._SetSyncUDWin("PBGC4044_PBGCMaxBenefit", this.wRetirementStudio.wPBGC4044_PBGCMaxBenefit.cbo, dic["PBGC4044_PBGCMaxBenefit"], 0);
                _gLib._SetSyncUDWin("PBGC4044_ApplyMinBenefit", this.wRetirementStudio.wPBGC4044_ApplyMinBenefit.chk, dic["PBGC4044_ApplyMinBenefit"], 0);
                _gLib._SetSyncUDWin("PBGC4044_MinBenefit", this.wRetirementStudio.wPBGC4044_MinBenefit.cbo, dic["PBGC4044_MinBenefit"], 0);

                _gLib._SetSyncUDWin("PBGC4044_ApplyPhaseIn", this.wRetirementStudio.wPBGC4044_ApplyPhaseIn.chk, dic["PBGC4044_ApplyPhaseIn"], 0);
                _gLib._SetSyncUDWin("PBGC4044_BenefitValYear1", this.wRetirementStudio.wPBGC4044_BenefitValYear1.cbo, dic["PBGC4044_BenefitValYear1"], 0);
                _gLib._SetSyncUDWin("PBGC4044_BenefitValYear2", this.wRetirementStudio.wPBGC4044_BenefitValYear2.cbo, dic["PBGC4044_BenefitValYear2"], 0);
                _gLib._SetSyncUDWin("PBGC4044_BenefitValYear3", this.wRetirementStudio.wPBGC4044_BenefitValYear3.cbo, dic["PBGC4044_BenefitValYear3"], 0);
                _gLib._SetSyncUDWin("PBGC4044_BenefitValYear4", this.wRetirementStudio.wPBGC4044_BenefitValYear4.cbo, dic["PBGC4044_BenefitValYear4"], 0);
                _gLib._SetSyncUDWin("PBGC4044_BenefitValYear5", this.wRetirementStudio.wPBGC4044_BenefitValYear5.cbo, dic["PBGC4044_BenefitValYear5"], 0);
            
            
            
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("IncludeThisBenefitInPresentValueCalculations", this.wRetirementStudio.wIncludeThisBenefitInPresentValueCalculations.chkIncludeThisBenefitInPresentValueCalculations, dic["IncludeThisBenefitInPresentValueCalculations"], 0);
                _gLib._VerifySyncUDWin("PBGC4044Calculations", this.wRetirementStudio.wPBGC4044Calculations.chk, dic["PBGC4044Calculations"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_BenefitBelongsInPBGC", this.wRetirementStudio.wPBGC4044_BenefitBelongsInPBGC.chk, dic["PBGC4044_BenefitBelongsInPBGC"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_PriorityCategory", this.wRetirementStudio.wPBGC4044_PriorityCategory.cbo, dic["PBGC4044_PriorityCategory"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_BenefitCommenceAge", this.wRetirementStudio.wPBGC4044_BenefitCommenceAge.rd, dic["PBGC4044_BenefitCommenceAge"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_AgeAtValYear3", this.wRetirementStudio.wPBGC4044_AgeAtValYear3.rd, dic["PBGC4044_AgeAtValYear3"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_ApplyPBGCMaxBenefit", this.wRetirementStudio.wPBGC4044_ApplyPBGCMaxBenefit.chk, dic["PBGC4044_ApplyPBGCMaxBenefit"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_PBGCMaxBenefit", this.wRetirementStudio.wPBGC4044_PBGCMaxBenefit.cbo, dic["PBGC4044_PBGCMaxBenefit"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_ApplyMinBenefit", this.wRetirementStudio.wPBGC4044_ApplyMinBenefit.chk, dic["PBGC4044_ApplyMinBenefit"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_MinBenefit", this.wRetirementStudio.wPBGC4044_MinBenefit.cbo, dic["PBGC4044_MinBenefit"], 0);

                _gLib._VerifySyncUDWin("PBGC4044_ApplyPhaseIn", this.wRetirementStudio.wPBGC4044_ApplyPhaseIn.chk, dic["PBGC4044_ApplyPhaseIn"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_BenefitValYear1", this.wRetirementStudio.wPBGC4044_BenefitValYear1.cbo, dic["PBGC4044_BenefitValYear1"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_BenefitValYear2", this.wRetirementStudio.wPBGC4044_BenefitValYear2.cbo, dic["PBGC4044_BenefitValYear2"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_BenefitValYear3", this.wRetirementStudio.wPBGC4044_BenefitValYear3.cbo, dic["PBGC4044_BenefitValYear3"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_BenefitValYear4", this.wRetirementStudio.wPBGC4044_BenefitValYear4.cbo, dic["PBGC4044_BenefitValYear4"], 0);
                _gLib._VerifySyncUDWin("PBGC4044_BenefitValYear5", this.wRetirementStudio.wPBGC4044_BenefitValYear5.cbo, dic["PBGC4044_BenefitValYear5"], 0);
            
            
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
