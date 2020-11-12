namespace RetirementStudio._UIMaps.CustomRateClasses
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

    
    public partial class CustomRate
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();

        /// <summary>
        /// 2016-Mar-11
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Adjustments", "true");
        ///    dic.Add("Rate_cbo", "");
        ///    dic.Add("Rate_txt", "");
        ///    dic.Add("Rate_cbo_T", "");
        ///    dic.Add("Rate_T_Age", "");
        ///    dic.Add("Adjustment1Operator_cbo", "");
        ///    dic.Add("Adjustment1_v", "");
        ///    dic.Add("Adjustment1_c", "");
        ///    dic.Add("Adjustment1_p", "");
        ///    dic.Add("Adjustment1_t", "");
        ///    dic.Add("Adjustment1_t_age", "");
        ///    dic.Add("Adjustment2Operator_cbo", "");
        ///    dic.Add("Adjustment2_v", "");
        ///    dic.Add("Adjustment2_c", "");
        ///    dic.Add("Adjustment2_p", "");
        ///    dic.Add("Adjustment3Operator_cbo", "");
        ///    dic.Add("Adjustment3_v", "");
        ///    dic.Add("Adjustment3_c", "");
        ///    dic.Add("Adjustment3_p", "");
        ///    pCustomRate._Adjustments_BR(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Adjustments_BR(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Yield_NL";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                int iV = 1, iC = 1, iP = 1, iT = 1, iT_age = 1;

                _gLib._SetSyncUDWin("Adjustments", this.wRetirementStudio.wAdjustments.chk, dic["Adjustments"], 0);

                ////// Rate
                if (dic["Rate_cbo"] != "")
                {
                    _gLib._SetSyncUDWin("Rate_cbo", this.wRetirementStudio.wRate_V.btn, "click", 0);
                    _gLib._SetSyncUDWin("Rate_cbo", this.wRetirementStudio.wComm_V.cbo, dic["Rate_cbo"], 0);
                    iV++;
                }
                if (dic["Rate_txt"] != "")
                {
                    _gLib._SetSyncUDWin("Rate_txt", this.wRetirementStudio.wRate_P.btn, "click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("Rate_txt", this.wRetirementStudio.wComm_P.txt.UI_numEditRateEdit1, dic["Rate_txt"], 0);
                    iP++;
                }
                if (dic["Rate_cbo_T"] != "")
                {
                    _gLib._SetSyncUDWin("Rate_cbo_T", this.wRetirementStudio.wRate_T.btn, "click", 0);
                    _gLib._SetSyncUDWin("Rate_cbo_T", this.wRetirementStudio.wComm_T.cbo, dic["Rate_cbo_T"], 0);
                    iT++;
                }
                 if (dic["Rate_T_Age"] != "")
                {
                     _gLib._SetSyncUDWin("Rate_T_Age", this.wRetirementStudio.wRate_Age.cbo, dic["Rate_T_Age"], 0);
                    iT_age++;
                }

                 
                //// Operator
                _gLib._SetSyncUDWin("Adjustment1Operator_cbo", this.wRetirementStudio.wAdjustment1_O.cbo, dic["Adjustment1Operator_cbo"], 0);
                _gLib._SetSyncUDWin("Adjustment2Operator_cbo", this.wRetirementStudio.wAdjustment2_O.cbo, dic["Adjustment2Operator_cbo"], 0);
                _gLib._SetSyncUDWin("Adjustment3Operator_cbo", this.wRetirementStudio.wAdjustment3_O.cbo, dic["Adjustment3Operator_cbo"], 0);


                ///// Adjustment1
                if (dic["Adjustment1_v"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment1_v", this.wRetirementStudio.wAdjustment1_V.btn, "click", 0);
                    this.wRetirementStudio.wComm_V.SearchProperties.Add(WinEdit.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("Adjustment1_v", this.wRetirementStudio.wComm_V.cbo, dic["Adjustment1_v"], 0);
                    iV++;
                }
                if (dic["Adjustment1_c"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment1_c", this.wRetirementStudio.wAdjustment1_C.btn, "click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("Adjustment3_c", this.wRetirementStudio.wComm_C.txt.UI_numEditConstantEdit1, dic["Adjustment1_c"], 0);
                    iC++;
                }
                if (dic["Adjustment1_p"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment1_p", this.wRetirementStudio.wAdjustment1_P.btn, "click", 0);
                    this.wRetirementStudio.wComm_P.SearchProperties.Add(WinEdit.PropertyNames.Instance, iP.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("Adjustment1_p", this.wRetirementStudio.wComm_P.txt.UI_numEditRateEdit1, dic["Adjustment1_p"], 0);
                    iP++;
                }
                if (dic["Adjustment1_t"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment1_t", this.wRetirementStudio.wAdjustment1_T.btn, "click", 0);
                    this.wRetirementStudio.wComm_T.SearchProperties.Add(WinEdit.PropertyNames.Instance, iP.ToString());
                    _gLib._SetSyncUDWin("Adjustment1_t", this.wRetirementStudio.wComm_T.cbo, dic["Adjustment1_t"], 0);
                    iT++;
                }
                if (dic["Adjustment1_t_age"] != "")
                {                    
                    this.wRetirementStudio.wRate_Age.SearchProperties.Add(WinEdit.PropertyNames.Instance, iP.ToString());
                    _gLib._SetSyncUDWin("Adjustment1_t_age", this.wRetirementStudio.wRate_Age.cbo, dic["Adjustment1_t_age"], 0);
                    iT_age++;
                }

                ///// Adjustment 2
                if (dic["Adjustment2_v"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment2_v", this.wRetirementStudio.wAdjustment2_V.btn, "click", 0);
                    this.wRetirementStudio.wComm_V.SearchProperties.Add(WinEdit.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("Adjustment2_v", this.wRetirementStudio.wComm_V.cbo, dic["Adjustment2_v"], 0);
                    iV++;
                }
                if (dic["Adjustment2_c"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment2_c", this.wRetirementStudio.wAdjustment2_C.btn, "click", 0);
                    this.wRetirementStudio.wComm_C.SearchProperties.Add(WinEdit.PropertyNames.Instance, iC.ToString() );
                    _gLib._SetSyncUDWin_ByClipboard("Adjustment2_c", this.wRetirementStudio.wComm_C.txt.UI_numEditConstantEdit1, dic["Adjustment2_c"], 0);
                    iC++;
                }

                if (dic["Adjustment2_p"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment2_p", this.wRetirementStudio.wAdjustment2_P.btn, "click", 0);
                    this.wRetirementStudio.wComm_P.SearchProperties.Add(WinEdit.PropertyNames.Instance, iP.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("Adjustment2_p", this.wRetirementStudio.wComm_P.txt.UI_numEditRateEdit1, dic["Adjustment2_p"], 0);
                    iP++;
                }

                ///// Adjustment3
                if (dic["Adjustment3_v"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment3_v", this.wRetirementStudio.wAdjustment3_V.btn, "click", 0);
                    this.wRetirementStudio.wComm_V.SearchProperties.Add(WinEdit.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("Adjustment3_v", this.wRetirementStudio.wComm_V.cbo, dic["Adjustment3_v"], 0);
                }
                if (dic["Adjustment3_c"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment3_c", this.wRetirementStudio.wAdjustment3_C.btn, "click", 0);
                    this.wRetirementStudio.wComm_C.SearchProperties.Add(WinEdit.PropertyNames.Instance, iC.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("Adjustment3_c", this.wRetirementStudio.wComm_C.txt.UI_numEditConstantEdit1, dic["Adjustment3_c"], 0);
                }
                if (dic["Adjustment3_p"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment3_p", this.wRetirementStudio.wAdjustment3_P.btn, "click", 0);
                    this.wRetirementStudio.wComm_P.SearchProperties.Add(WinEdit.PropertyNames.Instance, iP.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("Adjustment3_p", this.wRetirementStudio.wComm_P.txt.UI_numEditRateEdit1, dic["Adjustment3_p"], 0);
                }
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete yet");
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}




