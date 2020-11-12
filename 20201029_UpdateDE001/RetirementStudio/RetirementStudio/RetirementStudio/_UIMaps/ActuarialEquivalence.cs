namespace RetirementStudio._UIMaps.ActuarialEquivalenceClasses
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

    using Accessibility;
    using RetirementStudio._ThridParty;
    using System.Threading;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

    public partial class ActuarialEquivalence
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        /// <summary>
        /// 2013-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("cboInterestRate", "");
        ///    dic.Add("txtInterestRate", "7.5");
        ///    dic.Add("AsOfDate", "");
        ///    dic.Add("Mortality", "PPA2010CMF");
        ///    dic.Add("Mortality_cbo_3", "EmployeeIDNumber");
        ///    dic.Add("ProjectionScale", "MMP2016");
        ///    pActuarialEquivalence._PopVerify_SameStructureForAllPeriods(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SameStructureForAllPeriods(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_SameStructureForAllPeriods";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                if (dic["cboInterestRate"].ToLower() != "")
                    //////_gLib._SetSyncUDWin("", this.wRetirementStudio.wInterestRate_V.btn, "click", 0);
                _gLib._SetSyncUDWin("cboInterestRate", this.wRetirementStudio.wInterestRate_cbo.cbo, dic["cboInterestRate"], 0);
                //////_gLib._SetSyncUDWin_ByClipboard("txtInterestRate", this.wRetirementStudio.wInterestRate_txt.txtInterestRate, dic["txtInterestRate"], true, 0);
              
                if (dic["AsOfDate"] != "")
                {
                    _gLib._SendKeysUDWin("AsOfDate", this.wRetirementStudio.wInterest_AsOfDate.cboAsOfDate.txt, "{Home}");
                    _gLib._SendKeysUDWin("AsOfDate", this.wRetirementStudio.wInterest_AsOfDate.cboAsOfDate.txt, "{End}", 0, ModifierKeys.Shift, false);
                    _gLib._SetSyncUDWin_ByClipboard("AsOfDate", this.wRetirementStudio.wInterest_AsOfDate.cboAsOfDate.txt, dic["AsOfDate"], 0, false, false);
                    _gLib._VerifySyncUDWin("AsOfDate", this.wRetirementStudio.wInterest_AsOfDate.cboAsOfDate.txt, dic["AsOfDate"], 0);
                }
                
                _gLib._SetSyncUDWin("Mortality", this.wRetirementStudio.wMortality.cboMortality, dic["Mortality"], 0);

                _gLib._SetSyncUDWin("Mortality_cbo_3", this.wRetirementStudio.wMortality_cbo_3.cbo, dic["Mortality_cbo_3"], 0);
                _gLib._SetSyncUDWin("ProjectionScale", this.wRetirementStudio.wProjectionScale.cbo, dic["ProjectionScale"], 0);
 
            }
            
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("cboInterestRate", this.wRetirementStudio.wInterestRate_cbo.cbo, dic["cboInterestRate"], 0);
                _gLib._VerifySyncUDWin("txtInterestRate", this.wRetirementStudio.wInterestRate_txt.txtInterestRate, dic["txtInterestRate"], 0);
                _gLib._VerifySyncUDWin("Mortality", this.wRetirementStudio.wMortality.cboMortality, dic["Mortality"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Mar-04
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("InterestRate_P_txt", "7.5");
        ///    dic.Add("CostOfLivingIncrease_P_txt", "PPA2010CMF");
        ///    dic.Add("PercentMarried_T_cbo", "PPA2010CMF");
        ///    dic.Add("DifferenceInSpousesAge_T_cbo", "PPA2010CMF");
        ///    pActuarialEquivalence._SameStructureForAllPeriods_WithValuationMortality(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _SameStructureForAllPeriods_WithValuationMortality(MyDictionary dic)
        {
            string sFunctionName = "_SameStructureForAllPeriods_WithValuationMortality";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                int iT = 1, iP = 1;
                
                if (dic["InterestRate_P_txt"] != "")
                {
                    _gLib._SetSyncUDWin("InterestRate_P", this.wRetirementStudio.wInterestRate_P.UIItemButton, "click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("InterestRate_P_txt", this.wRetirementStudio.wComm_P_txt.txt.UI_numEditRateEdit1, dic["InterestRate_P_txt"], 0);
                    iP ++;
                }


                if (dic["CostOfLivingIncrease_P_txt"] != "")
                {
                    _gLib._SetSyncUDWin("", this.wRetirementStudio.wCostOfLivingIncrease_P.UIItemButton, "click", 0);

                    this.wRetirementStudio.wComm_P_txt.SearchProperties.Add(WinEdit.PropertyNames.Instance, iP.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("CostOfLivingIncrease_P_txt", this.wRetirementStudio.wComm_P_txt.txt.UI_numEditRateEdit1, dic["CostOfLivingIncrease_P_txt"], 0);
                    iP++;
                }


                if (dic["PercentMarried_T_cbo"] != "")
                {
                    _gLib._SetSyncUDWin("", this.wRetirementStudio.wPercentMarried_T.UITButton, "click", 0);

                    this.wRetirementStudio.wComm_T_cbo.SearchProperties.Add(WinComboBox.PropertyNames.Instance, iT.ToString());
                    _gLib._SetSyncUDWin("", this.wRetirementStudio.wComm_T_cbo.cbo, dic["PercentMarried_T_cbo"], 0);
                    iT++;
                }


                if (dic["DifferenceInSpousesAge_T_cbo"] != "")
                {
                    _gLib._SetSyncUDWin("", this.wRetirementStudio.wDifferenceInSpousesAge_T.UITButton, "click", 0);

                    this.wRetirementStudio.wComm_T_cbo.SearchProperties.Add(WinComboBox.PropertyNames.Instance, iT.ToString());
                    _gLib._SetSyncUDWin("DifferenceInSpousesAge_T_cbo", this.wRetirementStudio.wComm_T_cbo.cbo, dic["DifferenceInSpousesAge_T_cbo"], 0);
                }
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete yet");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }
      
        
        /// <summary>
        /// 2013-Sep-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ValuationInterest", "True");
        ///    dic.Add("ValuationMortality", "");
        ///    dic.Add("ValuationCOLA", "");
        ///    dic.Add("ValuationSpouseAgeDiff", "");
        ///    dic.Add("ValuationPercentMarried", "");
        ///    dic.Add("InterestRate_PrescribedRates", "");
        ///    dic.Add("Mortality_PrescribedRates", "");
        ///    dic.Add("Mortality_DisabledvsHealty", "");
        ///    pActuarialEquivalence._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ValuationInterest", this.wRetirementStudio.wValuationInterest.chkValuationInterest, dic["ValuationInterest"], 0);
                _gLib._SetSyncUDWin("ValuationMortality", this.wRetirementStudio.wValuationMortality.chkValuationMortality, dic["ValuationMortality"], 0);
                _gLib._SetSyncUDWin("ValuationCOLA", this.wRetirementStudio.wValuationCOLA.chkValuationCOLA, dic["ValuationCOLA"], 0);
                _gLib._SetSyncUDWin("ValuationSpouseAgeDiff", this.wRetirementStudio.wValuationSpouseAgeDiff.chkValuationSpouseAgeDiff, dic["ValuationSpouseAgeDiff"], 0);
                _gLib._SetSyncUDWin("ValuationPercentMarried", this.wRetirementStudio.wValuationPercentMarried.chk, dic["ValuationPercentMarried"], 0);
                _gLib._SetSyncUDWin("InterestRate_PrescribedRates", this.wRetirementStudio.wInterestRate_PrescribedRates.rdPrescribedRates, dic["InterestRate_PrescribedRates"], 0);
                _gLib._SetSyncUDWin("Mortality_PrescribedRates", this.wRetirementStudio.wMortality_PrescribedRates.rdPrescribedRates, dic["Mortality_PrescribedRates"], 0);
                _gLib._SetSyncUDWin("Mortality_DisabledvsHealty", this.wRetirementStudio.wMortality_DisabledvsHealthy.chkDisabledvsHealthy, dic["Mortality_DisabledvsHealty"], 0);
 
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("ValuationInterest", this.wRetirementStudio.wValuationInterest.chkValuationInterest, dic["ValuationInterest"], 0);
                _gLib._VerifySyncUDWin("ValuationMortality", this.wRetirementStudio.wValuationMortality.chkValuationMortality, dic["ValuationMortality"], 0);
                _gLib._VerifySyncUDWin("ValuationCOLA", this.wRetirementStudio.wValuationCOLA.chkValuationCOLA, dic["ValuationCOLA"], 0);
                _gLib._VerifySyncUDWin("ValuationSpouseAgeDiff", this.wRetirementStudio.wValuationSpouseAgeDiff.chkValuationSpouseAgeDiff, dic["ValuationSpouseAgeDiff"], 0);
                _gLib._VerifySyncUDWin("InterestRate_PrescribedRates", this.wRetirementStudio.wInterestRate_PrescribedRates.rdPrescribedRates, dic["InterestRate_PrescribedRates"], 0);
                _gLib._VerifySyncUDWin("Mortality_PrescribedRates", this.wRetirementStudio.wMortality_PrescribedRates.rdPrescribedRates, dic["Mortality_PrescribedRates"], 0);
                _gLib._VerifySyncUDWin("Mortality_DisabledvsHealty", this.wRetirementStudio.wMortality_DisabledvsHealthy.chkDisabledvsHealthy, dic["Mortality_DisabledvsHealty"], 0);
 
                
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2016-Mar-04
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PreCommencement_V", "");
        ///    dic.Add("PreCommencement_P", "");
        ///    dic.Add("PostCommencement_V", "");
        ///    dic.Add("PostCommencement_P", "");
        ///    dic.Add("CostOfLivingIncrease_V", "");
        ///    dic.Add("CostOfLivingIncrease_P", "");
        ///    pActuarialEquivalence._PrePostCommencement_ValuationMortality_SpouseAgeDif(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PrePostCommencement_ValuationMortality_SpouseAgeDif(MyDictionary dic)
        {
            string sFunctionName = "_PrePostCommencement_ValuationMortality_SpouseAgeDif";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                int iV = 1, iP = 1;
                _gLib._SetSyncUDWin("Prepostcommencement", this.wRetirementStudio.wPrepostcommencement.rd, "true", 0);

                if (dic["PreCommencement_V"] != "")
                {
                    _gLib._SetSyncUDWin("PreCommencement_V", this.wRetirementStudio.wPre_V.btn, "click", 0);
                    _gLib._SetSyncUDWin("PreCommencement_V", this.wRetirementStudio.wComm_V.cbo, dic["PreCommencement_V"], 0);
                    iV++;
                }
                if (dic["PreCommencement_P"] != "")
                {
                    _gLib._SetSyncUDWin("", this.wRetirementStudio.wPre_P.btn, "click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("PreCommencement_P", this.wRetirementStudio.wComm_P_txt.txt.UI_numEditRateEdit1, dic["PreCommencement_P"], 0);
                    iP++;
                }



                if (dic["PostCommencement_V"] != "")
                {
                    _gLib._SetSyncUDWin("PreCommencement_V", this.wRetirementStudio.wPost_V.btn, "click", 0);
                    this.wRetirementStudio.wComm_V.SearchProperties.Add(WinComboBox.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("PostCommencement_V", this.wRetirementStudio.wComm_V.cbo, dic["PostCommencement_V"], 0);
                    iV++;
                }
                if (dic["PostCommencement_P"] != "")
                {
                    _gLib._SetSyncUDWin("", this.wRetirementStudio.wPost_P.btn, "click", 0);
                    this.wRetirementStudio.wComm_P_txt.SearchProperties.Add(WinEdit.PropertyNames.Instance, iP.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("PostCommencement_P", this.wRetirementStudio.wComm_P_txt.txt.UI_numEditRateEdit1, dic["PostCommencement_P"], 0);
                    iP++;
                }


                if (dic["CostOfLivingIncrease_V"] != "")
                {
                    _gLib._SetSyncUDWin("CostOfLivingIncrease_V", this.wRetirementStudio.wCost_V.btn, "click", 0);
                    this.wRetirementStudio.wComm_V.SearchProperties.Add(WinComboBox.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("CostOfLivingIncrease_V", this.wRetirementStudio.wComm_V.cbo, dic["CostOfLivingIncrease_V"], 0);
                }
                if (dic["CostOfLivingIncrease_P"] != "")
                {
                    _gLib._SetSyncUDWin("", this.wRetirementStudio.wCost_P.btn, "click", 0);
                    this.wRetirementStudio.wComm_P_txt.SearchProperties.Add(WinEdit.PropertyNames.Instance, iP.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("CostOfLivingIncrease_P", this.wRetirementStudio.wComm_P_txt.txt.UI_numEditRateEdit1, dic["CostOfLivingIncrease_P"], 0);
                }

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete yet");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        

        /// <summary>
        /// 2020-Jun-05
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ValuationSpouseAgeDiff", "True");
        ///    dic.Add("InterestRate_SameStructureForAllPeriod", "True");
        ///    dic.Add("Mortality_SameStructureForAllPeriod", "True");
        ///    dic.Add("InterestRate_P", "Click");
        ///    dic.Add("txtInterestRate", "5.5");
        ///    dic.Add("Mortality", "GATT2003");
        ///    pActuarialEquivalence._ValuationSpouseAgeDif_SameStructureForAllPeriods(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _ValuationSpouseAgeDif_SameStructureForAllPeriods(MyDictionary dic)
        {
            string sFunctionName = "_ValuationSpouseAgeDif_SameStructureForAllPeriods";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                
                _gLib._SetSyncUDWin("ValuationSpouseAgeDiff", this.wRetirementStudio.wValuationSpouseAgeDiff.chkValuationSpouseAgeDiff, dic["ValuationSpouseAgeDiff"], 0);

                _gLib._SetSyncUDWin("InterestRate_SameStructureForAllPeriod", this.wRetirementStudio.wInterestRate_SameStructureForAllPeriod.rdSameStructureForAllPeriod, dic["InterestRate_SameStructureForAllPeriod"], 0);
                
                _gLib._SetSyncUDWin("Mortality_SameStructureForAllPeriod", this.wRetirementStudio.wMortalitySameStructureForAllPeriod.rdSameStructureForAllPeriod, dic["Mortality_SameStructureForAllPeriod"], 0);

                if (dic["InterestRate_P"] != "")
                {
                    _gLib._SetSyncUDWin("InterestRate_P", this.wRetirementStudio.wInterestRate_P.UIItemButton, dic["InterestRate_P"], 0);
                    _gLib._SetSyncUDWin_ByClipboard("txtInterestRate", this.wRetirementStudio.wInterestRate_txt.txtInterestRate.UI_numEditRateEdit1, dic["txtInterestRate"], true, 0);

                }

                _gLib._SetSyncUDWin("Mortality", this.wRetirementStudio.wMortality.cboMortality, dic["Mortality"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete yet");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    



        /// <summary>
        /// 2019-Mar-08
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SpotRateApplication", "Shifted rates");
        ///    pActuarialEquivalence._PopVerify_ValuationInterest(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ValuationInterest(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ValuationInterest";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("SpotRateApplication", this.wRetirementStudio.wSpotRateApplication.cboSpotRateApplication, dic["SpotRateApplication"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("SpotRateApplication", this.wRetirementStudio.wSpotRateApplication.cboSpotRateApplication, dic["SpotRateApplication"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2019-July-02
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SpotRateApplication", "Shifted rates");
        ///    pActuarialEquivalence._PopVerify_Mortality(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Mortality(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ValuationInterest";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("SpotRateApplication", this.wRetirementStudio.wSpotRateApplication.cboSpotRateApplication, dic["SpotRateApplication"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("SpotRateApplication", this.wRetirementStudio.wSpotRateApplication.cboSpotRateApplication, dic["SpotRateApplication"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
