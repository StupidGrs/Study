namespace RetirementStudio._UIMaps.CostOfLivingAdjustmentsClasses
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
    
    
    public partial class CostOfLivingAdjustments
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
        ///    dic.Add("MinandMaxCOLAPerAnnum", "");
        ///    dic.Add("COLA_Begins_LatestOf", "true");
        ///    dic.Add("COLA_Begins_Age_V", "Click");
        ///    dic.Add("COLA_Begins_Age_cbo", "");
        ///    dic.Add("COLA_After_V", "");
        ///    dic.Add("COLA_After_Percent", "");
        ///    dic.Add("COLA_After_T", "Click");
        ///    dic.Add("Rate_cbo_V", "");
        ///    dic.Add("Rate_cbo", "GROWIN08")
        ///    pCostOfLivingAdjustments._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ServiceAtValuationDate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("MinandMaxCOLAPerAnnum", this.wRetirementStudio.wMinAndMaxCOLAperannu.chx, dic["MinandMaxCOLAPerAnnum"], 0);
                _gLib._SetSyncUDWin("COLA_Begins_LatestOf", this.wRetirementStudio.wCOLABegains_LatestOf.rdLatestOf, dic["COLA_Begins_LatestOf"], 0);
                _gLib._SetSyncUDWin("COLA_Begins_Age_V", this.wRetirementStudio.wCOLABegins_Age_V.btnV, dic["COLA_Begins_Age_V"], 0);
                _gLib._SetSyncUDWin("COLA_Begins_Age_cbo", this.wRetirementStudio.wCOLABegins_Age_cbo.cboAge, dic["COLA_Begins_Age_cbo"], 0);

                _gLib._SetSyncUDWin("COLA_After_V", this.wRetirementStudio.wCOLA_After_V.btnV, dic["COLA_After_V"], 0);
                _gLib._SetSyncUDWin("COLA_After_Percent", this.wRetirementStudio.wCOLA_After_Percent.btnPercent, dic["COLA_After_Percent"], 0);
                _gLib._SetSyncUDWin("COLA_After_T", this.wRetirementStudio.wCOLA_After_T.btnT, dic["COLA_After_T"], 0);
                _gLib._SetSyncUDWin("Rate_cbo_V", this.wRetirementStudio.wCOLADuringAfter_Rate_cbo.cbo, dic["Rate_cbo_V"], 0);
                _gLib._SetSyncUDWin("Rate_cbo", this.wRetirementStudio.wCOLA_After_Rate_cbo.cboRate, dic["Rate_cbo"], 0);

                if (dic["COLA_Begins_Age_V"] != "" && dic["COLA_After_V"] != "")
                    this.wRetirementStudio.wCOLA_After_Rate_cbo.SearchProperties.Add(WinComboBox.PropertyNames.Instance, "2");
                _gLib._SetSyncUDWin("Rate_cbo", this.wRetirementStudio.wCOLA_After_Rate_cbo.cboRate, dic["Rate_cbo"], 0);


               

            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("MinandMaxCOLAPerAnnum", this.wRetirementStudio.wMinAndMaxCOLAperannu.chx, dic["MinandMaxCOLAPerAnnum"], 0);
                _gLib._VerifySyncUDWin("COLA_Begins_LatestOf", this.wRetirementStudio.wCOLABegains_LatestOf.rdLatestOf, dic["COLA_Begins_LatestOf"], 0);
                _gLib._VerifySyncUDWin("COLA_Begins_Age_V", this.wRetirementStudio.wCOLABegins_Age_V.btnV, dic["COLA_Begins_Age_V"], 0);
                _gLib._VerifySyncUDWin("COLA_Begins_Age_cbo", this.wRetirementStudio.wCOLABegins_Age_cbo.cboAge, dic["COLA_Begins_Age_cbo"], 0);

                _gLib._VerifySyncUDWin("COLA_After_V", this.wRetirementStudio.wCOLA_After_V.btnV, dic["COLA_After_V"], 0);
                _gLib._VerifySyncUDWin("COLA_After_Percent", this.wRetirementStudio.wCOLA_After_Percent.btnPercent, dic["COLA_After_Percent"], 0);
                _gLib._VerifySyncUDWin("COLA_After_T", this.wRetirementStudio.wCOLA_After_T.btnT, dic["COLA_After_T"], 0);
               _gLib._VerifySyncUDWin("Rate_cbo_V", this.wRetirementStudio.wCOLADuringAfter_Rate_cbo.cbo, dic["Rate_cbo_V"], 0);
               _gLib._VerifySyncUDWin("Rate_cbo", this.wRetirementStudio.wCOLA_After_Rate_cbo.cboRate, dic["Rate_cbo"], 0);
 
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("COLABegin_Active_PaymentsFrom", "");
        ///    dic.Add("COLABegin_Active_PaymentsFrom_txt", "0");
        ///    dic.Add("COLABegin_Active_Age", "");
        ///    dic.Add("COLABegin_Active_Date", "");
        ///    dic.Add("COLADuring_V", "");
        ///    dic.Add("COLADuring_P", "");
        ///    dic.Add("COLADuring_T", "");
        ///    dic.Add("COLADuring_Rate_cbo", "");
        ///    dic.Add("COLADuring_Rate_txt", "");
        ///    dic.Add("COLAAfter_V", "");
        ///    dic.Add("COLAAfter_P", "");
        ///    dic.Add("COLAAfter_T", "");
        ///    dic.Add("COLAAfter_Rate_cbo", "");
        ///    dic.Add("COLAAfter_Rate_C", "");
        ///    dic.Add("COLAAfter_Rate_txt", "");
        ///    dic.Add("COLAAfter_Minimum_Percent", "");
        ///    pCostOfLivingAdjustments._PopVerify_CostOfLivingAdjustments_DE(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CostOfLivingAdjustments_DE(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_CostOfLivingAdjustments_DE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("COLABegin_Active_PaymentsFrom", this.wRetirementStudio.wCOLABegin_Active_PaymentsFrom_DE.cbo, dic["COLABegin_Active_PaymentsFrom"], 0);
              
                if (dic["COLABegin_Active_PaymentsFrom_txt"] != "")
                {
                    _gLib._SendKeysUDWin("COLABegin_Active_PaymentsFrom_txt", this.wRetirementStudio.wCOLABegin_Active_PaymentsFrom_txt_DE.Edit.txt, "{left}{left}{left}{left}{Delete}{Delete}{Delete}{Delete}", 0);
                    _gLib._SetSyncUDWin_ByClipboard("COLABegin_Active_PaymentsFrom_txt", this.wRetirementStudio.wCOLABegin_Active_PaymentsFrom_txt_DE.Edit.txt, dic["COLABegin_Active_PaymentsFrom_txt"], 0);
                }
                 
                _gLib._SetSyncUDWin_ByClipboard("COLABegin_Active_Age", this.wRetirementStudio.wCOLABegin_Active_Age_DE.txt, dic["COLABegin_Active_Age"], 0);
                _gLib._SetSyncUDWin_ByClipboard("COLABegin_Active_Date", this.wRetirementStudio.wCOLABegin_Active_Date_DE.cbo.txt, dic["COLABegin_Active_Date"], 0);

                _gLib._SetSyncUDWin("COLADuring_V", this.wRetirementStudio.wCOLADuring_V_DE.btn, dic["COLADuring_V"], 0);
                _gLib._SetSyncUDWin("COLADuring_P", this.wRetirementStudio.wCOLADuring_P_DE.btn, dic["COLADuring_P"], 0);
                _gLib._SetSyncUDWin("COLADuring_T", this.wRetirementStudio.wCOLADuring_T_DE.btn, dic["COLADuring_T"], 0);
                _gLib._SetSyncUDWin("COLADuring_Rate_cbo", this.wRetirementStudio.wCOLADuringAfter_Rate_cbo.cbo, dic["COLADuring_Rate_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("COLADuring_Rate_txt", this.wRetirementStudio.wCOLADuringAfter_Rate_txt.txt, dic["COLADuring_Rate_txt"], 0);

                _gLib._SetSyncUDWin("COLAAfter_V", this.wRetirementStudio.wCOLAAfter_V_DE.btn, dic["COLAAfter_V"], 0);
                _gLib._SetSyncUDWin("COLAAfter_P", this.wRetirementStudio.wCOLAAfter_P_DE.btn, dic["COLAAfter_P"], 0);
                _gLib._SetSyncUDWin("COLAAfter_T", this.wRetirementStudio.wCOLAAfter_T_DE.btn, dic["COLAAfter_T"], 0);

                if (dic["COLADuring_V"]!="")
                    this.wRetirementStudio.wCOLADuringAfter_Rate_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                if (dic["COLADuring_P"] != "")
                    this.wRetirementStudio.wCOLADuringAfter_Rate_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
              
                _gLib._SetSyncUDWin("COLAAfter_Rate_cbo", this.wRetirementStudio.wCOLADuringAfter_Rate_cbo.cbo, dic["COLAAfter_Rate_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("COLAAfter_Rate_txt", this.wRetirementStudio.wCOLADuringAfter_Rate_txt.txt, dic["COLAAfter_Rate_txt"], 0);

              
                    _gLib._SetSyncUDWin_ByClipboard("COLAAfter_Minimum_Percent", this.wRetirementStudio.wCOLAAfterBenefitCom_Minmum.txt.UI_numEditRateEdit1, dic["COLAAfter_Minimum_Percent"], 0);


            }


            if (dic["PopVerify"] == "Verify")
            {

                _gLib._MsgBox("Warning!", "No Verify!");

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("COLA_After_V", "Click");
        ///    dic.Add("COLA_After_Percent", "");
        ///    dic.Add("COLA_After_T", "");
        ///    dic.Add("AfterRate_cbo_V", "CostOfLivingIncreaseAssumption");
        ///    dic.Add("AfterRate_cbo_T", "");
        ///    dic.Add("COLA_During_V", "Click");
        ///    dic.Add("COLA_During_Percent", "");
        ///    dic.Add("COLA_During_T", "");
        ///    dic.Add("DuringRate_cbo_V", "RevaluationRate");
        ///    dic.Add("DuringRate_cbo_T", ""); 
        ///    pCostOfLivingAdjustments._PopVerify_COLADuringDeferral_IR(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_COLADuringDeferral_IR(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_COLADuringDeferral_IR";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("DuringDeferral", this.wRetirementStudio.wCOLAduringDeferral.chk, "True", 0);

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("COLA_After_V", this.wRetirementStudio.wCOLA_After_V.btnV, dic["COLA_After_V"], 0);
                _gLib._SetSyncUDWin("COLA_After_Percent", this.wRetirementStudio.wCOLA_After_Percent.btnPercent, dic["COLA_After_Percent"], 0);
                _gLib._SetSyncUDWin("COLA_After_T", this.wRetirementStudio.wCOLA_After_T.btnT, dic["COLA_After_T"], 0);

                _gLib._SetSyncUDWin("AfterRate_cbo_V", this.wRetirementStudio.wCOLADuringAfter_Rate_cbo.cbo, dic["AfterRate_cbo_V"], 0);
                _gLib._SetSyncUDWin("AfterRate_cbo_T", this.wRetirementStudio.wCOLA_After_Rate_cbo.cboRate, dic["AfterRate_cbo_T"], 0);


                this.wRetirementStudio.wCOLA_After_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, "4");
                this.wRetirementStudio.wCOLA_After_Percent.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                this.wRetirementStudio.wCOLA_After_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");

                _gLib._SetSyncUDWin("COLA_During_V", this.wRetirementStudio.wCOLA_After_V.btnV, dic["COLA_During_V"], 0);
                _gLib._SetSyncUDWin("COLA_During_Percent", this.wRetirementStudio.wCOLA_After_Percent.btnPercent, dic["COLA_During_Percent"], 0);
                _gLib._SetSyncUDWin("COLA_During_T", this.wRetirementStudio.wCOLA_After_T.btnT, dic["COLA_During_T"], 0);

                if (dic["COLA_After_V"] != "")
                    this.wRetirementStudio.wCOLADuringAfter_Rate_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                _gLib._SetSyncUDWin("DuringRate_cbo_V", this.wRetirementStudio.wCOLADuringAfter_Rate_cbo.cbo, dic["DuringRate_cbo_V"], 0);
                if (dic["COLA_After_T"] != "")
                    this.wRetirementStudio.wCOLA_After_Rate_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                _gLib._SetSyncUDWin("DuringRate_cbo_T", this.wRetirementStudio.wCOLA_After_Rate_cbo.cboRate, dic["DuringRate_cbo_T"], 0);
           
            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("Warning", "No Verification codes!");

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Jan-25
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("COLA_End", "true");
        ///    dic.Add("COLA_DuringDeferral", "true");
        ///    dic.Add("COLA_End_Age", "true");
        ///    dic.Add("COLA_End_Age_txt", "");
        ///    dic.Add("COLA_During_V", "Click");
        ///    dic.Add("COLA_During_Rate_cbo_V", "");
        ///    dic.Add("COLA_During_LoadingFactor", "");
        ///    pCostOfLivingAdjustments._COLAEnd_And_COLADuringDeferral_CA(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _COLAEnd_And_COLADuringDeferral_CA(MyDictionary dic)
        {
            string sFunctionName = "_COLAEnd_And_COLADuringDeferral_CA";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("COLA_After_V", this.wRetirementStudio.wCOLAduringDeferral.chk, "True", 0);

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("COLA_End", this.wRetirementStudio.wCOLAends.UICOLAendsCheckBox , dic["COLA_End"], 0);
                _gLib._SetSyncUDWin("COLA_DuringDeferral", this.wRetirementStudio.wCOLAduringDeferral.chk, dic["COLA_DuringDeferral"], 0);
                
                _gLib._SetSyncUDWin("COLA_End_Age", this.wRetirementStudio.wCOLAEnd_Age.rd, dic["COLA_End_Age"], 0);
                _gLib._SetSyncUDWin_ByClipboard("COLA_End_Age_txt", this.wRetirementStudio.wCOLAEnd_Age_txt.Edit.txt, dic["COLA_End_Age_txt"], 0);

                _gLib._SetSyncUDWin("COLA_During_V", this.wRetirementStudio.wCOLADuring_Rate_V_CA.UIVButton, dic["COLA_During_V"], 0);
                _gLib._SetSyncUDWin("COLA_During_Rate_cbo_V", this.wRetirementStudio.wCOLADuring_Rate_cbo_v_CA.cbo, dic["COLA_During_Rate_cbo_V"], 0);

                if (dic["COLA_During_LoadingFactor"] != "")
                {
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wCOLADuring_Rate_cbo_v_CA.cbo, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Back}{Left}");

                    //// set value by clipboard
                    Clipboard.Clear();
                    Clipboard.SetText(dic["COLA_During_LoadingFactor"]);
                    Keyboard.SendKeys("V", ModifierKeys.Control);

                    _gLib._VerifySyncUDWin("DateField", this.wRetirementStudio.wCOLADuringDeferral_LoadingFactor.Edit, dic["COLA_During_LoadingFactor"], 0);


                    //////////// verify value by clipboard.
                    ////////////_gLib._SendKeysUDWin("", this.wRetirementStudio.wCOLADuring_Rate_cbo_v_CA.cbo, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                    ////////////Clipboard.Clear();
                    ////////////Keyboard.SendKeys("c", ModifierKeys.Control);

                    ////////////string sAct = Clipboard.GetText().Trim();

                    ////////////if (sAct != dic["COLA_During_LoadingFactor"])
                    ////////////    _gLib._MsgBoxYesNo("", "Fail Function!!" + Environment.NewLine + "the expection value is <" + dic["COLA_During_LoadingFactor"]  + ">, but the actuarial value is <" + sAct + ">");
                }
            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("Warning", "No Verification codes!");

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Feb-15
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("COLA_End", "");
        ///    dic.Add("COLA_DuringDeferral", "true");
        ///    dic.Add("COLA_End_Age", "true");
        ///    dic.Add("COLA_AfterBenefit_Rate_V", "Click");
        ///    dic.Add("COLA_AfterBenefit_Rate_cbo_V", "");
        ///    dic.Add("COLA_AfterBenefit_Rate_C", "");
        ///    dic.Add("COLA_AfterBenefit_Rate_txt", "");
        ///    dic.Add("COLA_During_Rate_V", "Click");
        ///    dic.Add("COLA_During_Rate_cbo_V", "");
        ///    dic.Add("COLA_During_Rate_C", "click");
        ///    dic.Add("COLA_During_Rate_txt", "");
        ///    pCostOfLivingAdjustments._COLADuringDeferral_NL(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _COLADuringDeferral_NL(MyDictionary dic)
        {
            string sFunctionName = "_COLADuringDeferral_NL";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("COLA_End", this.wRetirementStudio.wCOLAends.UICOLAendsCheckBox, dic["COLA_End"], 0);
                _gLib._SetSyncUDWin("COLA_DuringDeferral", this.wRetirementStudio.wCOLAduringDeferral.chk, dic["COLA_DuringDeferral"], 0);

                _gLib._SetSyncUDWin("COLA_AfterBenefit_Rate_V", this.wRetirementStudio.wCOLAAfterBenefit_Rate_V.btn, dic["COLA_AfterBenefit_Rate_V"], 0);
                _gLib._SetSyncUDWin("COLA_AfterBenefit_Rate_C", this.wRetirementStudio.wCOLAAfterBenefit_Rate_C.UIItemButton, dic["COLA_AfterBenefit_Rate_C"], 0);
                _gLib._SetSyncUDWin("COLA_During_Rate_V", this.wRetirementStudio.wCOLADuringDeferral_Rate_V.btn, dic["COLA_During_Rate_V"], 0);
                _gLib._SetSyncUDWin("COLA_During_Rate_C", this.wRetirementStudio.wCOLADuringDeferral_Rate_C.UIItemButton, dic["COLA_During_Rate_C"], 0);


                _gLib._SetSyncUDWin("COLA_AfterBenefit_Rate_cbo_V", this.wRetirementStudio.wCOLADuringAfter_Rate_cbo.cbo, dic["COLA_AfterBenefit_Rate_cbo_V"], 0);
                _gLib._SetSyncUDWin_ByClipboard("COLA_AfterBenefit_Rate_txt", this.wRetirementStudio.wCOLADuringAfter_Rate_txt.txt, dic["COLA_AfterBenefit_Rate_txt"], 0);
           

                if (  dic["COLA_AfterBenefit_Rate_V"] != "" && dic["COLA_During_Rate_V"] != "")
                    this.wRetirementStudio.wCOLADuringAfter_Rate_cbo.SearchProperties.Add(WinComboBox.PropertyNames.Instance, "2");
                _gLib._SetSyncUDWin("COLA_During_Rate_cbo_V", this.wRetirementStudio.wCOLADuringAfter_Rate_cbo.cbo, dic["COLA_During_Rate_cbo_V"], 0);

               
                if (dic["COLA_AfterBenefit_Rate_C"] != "" && dic["COLA_During_Rate_C"] != "")
                    this.wRetirementStudio.wCOLADuringAfter_Rate_txt.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2");
                _gLib._SetSyncUDWin_ByClipboard("COLA_During_Rate_txt", this.wRetirementStudio.wCOLADuringAfter_Rate_txt.txt, dic["COLA_During_Rate_txt"], 0);
            
            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("Warning", "No Verification codes!");

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
