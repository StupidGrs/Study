namespace RetirementStudio._UIMaps.CareerAverageEarmingsFormulaClasses
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
    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

    public partial class CareerAverageEarmingsFormula
    {
        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        /// <summary>
        /// 2016-Jan-28
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Revaluation_Rate_V_NL", "");
        ///    dic.Add("Revaluation_Rate_cbo_NL", "");
        ///    dic.Add("Revaluation_Rate_cbo", "");
        ///    dic.Add("Revaluation_Rate_txt", "");
        ///    dic.Add("StartingAmountAsOfAmount", "");
        ///    dic.Add("StrartingAccruedAmount_V", "click");
        ///    dic.Add("StrartingAccruedAmount_C", "");
        ///    dic.Add("StrartingAccruedAmount_cbo", "");
        ///    dic.Add("StrartingAccruedAmount_txt", "");
        ///    dic.Add("StopAccrualAt_V", "");
        ///    dic.Add("StopAccrualAt_C", "");
        ///    dic.Add("StopAccrualAt_cbo", "");
        ///    dic.Add("StopAccrualAt_txt", "");
        ///    dic.Add("RateTiersBaseOn", "");
        ///    pCareerAverageEarmingsFormula._Formula(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Formula(MyDictionary dic)
        {
            string sFunctionName = "_Formula";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int itxt = 1, icbo = 1;

                _gLib._SetSyncUDWin("Revaluation_Rate_cbo", this.wRetirementStudio.wRevaluation_Rate.cbo, dic["Revaluation_Rate_cbo"], 0);

                if (dic["Revaluation_Rate_txt"] != "")
                    _gLib._SetSyncUDWin("Revaluation_Rate_C", this.wRetirementStudio.wRevaluation_Rate_C.btn, "click", 0);
                _gLib._SetSyncUDWin_ByClipboard("Revaluation_Rate_txt", this.wRetirementStudio.wRevaluation_Rate_txt.txt.UI_numEditRateEdit1, dic["Revaluation_Rate_txt"], 0);


                _gLib._SetSyncUDWin("StartingAmountAsOfAmount", this.wRetirementStudio.wStartAmountAsOfYearBefore.chx, dic["StartingAmountAsOfAmount"], 0);

                _gLib._SetSyncUDWin("Revaluation_Rate_V_NL", this.wRetirementStudio.wRevaluation_Rate_V.btn, dic["Revaluation_Rate_V_NL"], 0);
                _gLib._SetSyncUDWin("StrartingAccruedAmount_V", this.wRetirementStudio.wStrartingAccruedAmount_V.btn, dic["StrartingAccruedAmount_V"], 0);
                _gLib._SetSyncUDWin("StrartingAccruedAmount_C", this.wRetirementStudio.wStrartingAccruedAmount_C.btn, dic["StrartingAccruedAmount_C"], 0);
                _gLib._SetSyncUDWin("StopAccrualAt_V", this.wRetirementStudio.wStop_V.btn, dic["StopAccrualAt_V"], 0);
                _gLib._SetSyncUDWin("StopAccrualAt_C", this.wRetirementStudio.wStop_C.btn, dic["StopAccrualAt_C"], 0);



                if (dic["StrartingAccruedAmount_V"] != "")
                {
                    this.wRetirementStudio.wCom_cbo.SearchProperties.Add(WinComboBox.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("StrartingAccruedAmount_cbo", this.wRetirementStudio.wCom_cbo.cbo, dic["StrartingAccruedAmount_cbo"], 0);
                    icbo++;
                }

                if (dic["StrartingAccruedAmount_C"] != "")
                {
                    this.wRetirementStudio.wCom_txt.SearchProperties.Add(WinComboBox.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("StrartingAccruedAmount_txt", this.wRetirementStudio.wCom_txt.txt.UI_numEditConstantEdit1, dic["StrartingAccruedAmount_txt"], 0);
                    itxt++;
                }



                if (dic["StopAccrualAt_V"] != "")
                {
                    this.wRetirementStudio.wCom_cbo.SearchProperties.Add(WinComboBox.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("StopAccrualAt_cbo", this.wRetirementStudio.wCom_cbo.cbo, dic["StopAccrualAt_cbo"], 0);
                    icbo++;
                }

                if (dic["StopAccrualAt_C"] != "")
                {
                    this.wRetirementStudio.wCom_txt.SearchProperties.Add(WinComboBox.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("StopAccrualAt_txt", this.wRetirementStudio.wCom_txt.txt.UI_numEditConstantEdit1, dic["StopAccrualAt_txt"], 0);
                    itxt++;
                }


                if (dic["Revaluation_Rate_cbo_NL"] != "")
                {
                    this.wRetirementStudio.wCom_cbo.SearchProperties.Add(WinComboBox.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("Revaluation_Rate_cbo_NL", this.wRetirementStudio.wCom_cbo.cbo, dic["Revaluation_Rate_cbo_NL"], 0);
                }


                _gLib._SetSyncUDWin("RateTiersBaseOn", this.wRetirementStudio.wRateTiersBasis.cbo, dic["RateTiersBaseOn"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "Function is not complete");

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
