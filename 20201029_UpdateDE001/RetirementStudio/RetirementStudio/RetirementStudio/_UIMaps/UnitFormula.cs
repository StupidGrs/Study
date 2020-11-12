namespace RetirementStudio._UIMaps.UnitFormulaClasses
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
    using System.Threading;
    using System.Diagnostics;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    
    
    public partial class UnitFormula
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        /// <summary>
        /// 2013-Dec-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "True");
        ///    dic.Add("CustomCode", "");
        ///    pUnitFormula._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Dec-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Service", "CreditedService");
        ///    dic.Add("LimitServiceTo", "15");
        ///    dic.Add("StopAccrualAt_V", "");
        ///    dic.Add("StopAccuralAt_C", "");
        ///    dic.Add("StopAccuralAt_cbo", "");
        ///    dic.Add("StopAccuralAt_txt", "");
        ///    dic.Add("RateTiersBasedOn", "Plan Year");
        ///    dic.Add("NumberOfRateTiers", "3");
        ///    dic.Add("ToServiceInSameTier", "");
        ///    dic.Add("AtExitAgeToAllService", "");
        ///    pUnitFormula._PopVerify_Standard(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Service", this.wRetirementStudio.wService.cboService, dic["Service"], 0);
                _gLib._SetSyncUDWin_ByClipboard("LimitServiceTo", this.wRetirementStudio.wLimitServiceTo.txtEdit, dic["LimitServiceTo"], 0);
                _gLib._SetSyncUDWin("StopAccrualAt_V", this.wRetirementStudio.wStopAccrualAt_V.btnV, dic["StopAccrualAt_V"], 0);
                _gLib._SetSyncUDWin("StopAccuralAt_C", this.wRetirementStudio.wStopAccuralAt_C.btnC, dic["StopAccuralAt_C"], 0);
                _gLib._SetSyncUDWin("StopAccuralAt_cbo", this.wRetirementStudio.wStopAccuralAt_cbo.cbo, dic["StopAccuralAt_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("StopAccuralAt_txt", this.wRetirementStudio.wStopAccuralAt_txt.txtEdit, dic["StopAccuralAt_txt"], 0);
                _gLib._SetSyncUDWin("RateTiersBasedOn", this.wRetirementStudio.wRateTiersBasedOn.cboRateTiersBasedOn, dic["RateTiersBasedOn"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NumberOfRateTiers", this.wRetirementStudio.wNumberOfRateTiers.txtEdit, dic["NumberOfRateTiers"], 0);
                _gLib._SetSyncUDWin("ToServiceInSameTier", this.wRetirementStudio.wToServiceInSameTier.rd, dic["ToServiceInSameTier"], 0);
                _gLib._SetSyncUDWin("AtExitAgeToAllService", this.wRetirementStudio.wAtexitagetoallservic.rd, dic["AtExitAgeToAllService"], 0);
           
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Service", this.wRetirementStudio.wService.cboService, dic["Service"], 0);
                _gLib._VerifySyncUDWin("LimitServiceTo", this.wRetirementStudio.wLimitServiceTo.txtEdit, dic["LimitServiceTo"], 0);
                _gLib._VerifySyncUDWin("StopAccrualAt_V", this.wRetirementStudio.wStopAccrualAt_V.btnV, dic["StopAccrualAt_V"], 0);
                _gLib._VerifySyncUDWin("StopAccuralAt_C", this.wRetirementStudio.wStopAccuralAt_C.btnC, dic["StopAccuralAt_C"], 0);
                _gLib._VerifySyncUDWin("StopAccuralAt_cbo", this.wRetirementStudio.wStopAccuralAt_cbo.cbo, dic["StopAccuralAt_cbo"], 0);
                _gLib._VerifySyncUDWin("StopAccuralAt_txt", this.wRetirementStudio.wStopAccuralAt_txt.txtEdit, dic["StopAccuralAt_txt"], 0);
                _gLib._VerifySyncUDWin("RateTiersBasedOn", this.wRetirementStudio.wRateTiersBasedOn.cboRateTiersBasedOn, dic["RateTiersBasedOn"], 0);
                _gLib._VerifySyncUDWin("NumberOfRateTiers", this.wRetirementStudio.wNumberOfRateTiers.txtEdit, dic["NumberOfRateTiers"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-Dec-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("iCol", "2");
        ///    dic.Add("iRowMax", "2");
        ///    dic.Add("iColMax", "3");
        ///    dic.Add("sData", "2007");
        ///    dic.Add("bPayCredit", "");
        ///    pUnitFormula._FormulaTable(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _FormulaTable(MyDictionary dic)
        {
            string sFunctionName = "_FormulaTable";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRow = Convert.ToInt32(dic["iRow"]);
            int iCol = Convert.ToInt32(dic["iCol"]);
            int iRowMax = Convert.ToInt32(dic["iRowMax"]);
            int iColMax = Convert.ToInt32(dic["iColMax"]);

            if (dic["bPayCredit"].ToUpper().Equals("TRUE"))
            {
                _gLib._SetSyncUDWin("Formula Table", this.wRetirementStudio.FPGrid.grid, "Click", 0, false, 20, 30);
                _gLib._SendKeysUDWin("", this.wRetirementStudio.FPGrid.grid, "{Tab}", 0, ModifierKeys.None, false);
            }
            else
                _gLib._SetSyncUDWin("Formula Table", this.wRetirementStudio.FPGrid.grid, "Click", 0, false, 20, 10);

            int iBackKeys = iRowMax * iColMax;
            string sBackKeys = "";
            for (int i = 0; i < iBackKeys; i++)
                sBackKeys = sBackKeys + "{Tab}";
            ////////////Keyboard.SendKeys(this.wRetirementStudio.FPGrid.grid, sBackKeys, ModifierKeys.Shift);
            _gLib._SendKeysUDWin("", this.wRetirementStudio.FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);

            int iKeys = iCol + (iRow - 1) * iColMax - 1;

            if (dic["bPayCredit"].ToUpper().Equals("TRUE") && iKeys >= iColMax)
                iKeys = iKeys + 1;

            string sKeys = "";
            for (int i = 0; i < iKeys; i++)
                sKeys = sKeys + "{Tab}";
            if (sKeys != "")
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.FPGrid.grid, sKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.FPGrid.grid, sKeys, ModifierKeys.None);
            

            _gLib._SetSyncUDWin_ByClipboard("Formula Table", this.wRetirementStudio.wFormulaTable_txt.txtEdit, dic["sData"], 0);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
