namespace RetirementStudio._UIMaps.FlatAmountAccumulationClasses
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
    using System.Threading;
    using System.Diagnostics;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    
    public partial class FlatAmountAccumulation
    {
        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2015-Dec-31 
        /// ruiyang.song@mercer.com
        /// 
        /// sample: 
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ServiceBasedOn", "");
        ///    dic.Add("LimitServiceTo", "");
        ///    dic.Add("StartingAccruedAmount", "");
        ///    dic.Add("AccrualRateTiersBasedOn", "");
        ///    dic.Add("NumberOfAccrualRateTiers", "");
        ///    pFlatAmountAccumulation._Standard(dic); 
        /// </summary>
        /// <param name="sExcelFile"></param>
        public void _Standard(MyDictionary dic)
        {
            string sFunctionName = "_CV_AddMultipleLabels";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ServiceBasedOn", this.wRetirementStudio.wServiceBasedOn.cbo, dic["ServiceBasedOn"], 0);
                _gLib._SetSyncUDWin_ByClipboard("LimitServiceTo", this.wRetirementStudio.wLimitServiceTo.Edit.txt, dic["LimitServiceTo"], 0);
                _gLib._SetSyncUDWin("StartingAccruedAmount", this.wRetirementStudio.wStartingAccruedAmount_cbo.cbo, dic["StartingAccruedAmount"], 0);
                _gLib._SetSyncUDWin("AccrualRateTiersBasedOn", this.wRetirementStudio.wAccrualRateTiersBasedOn.cbo, dic["AccrualRateTiersBasedOn"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NumberOfAccrualRateTiers", this.wRetirementStudio.wNumberOfAccrualRate.Edit.txt, dic["NumberOfAccrualRateTiers"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "this function is not complete yet");
            }


        }


        /// <summary>
        /// 2015-Dec-31 
        /// ruiyang.song@mercer.com
        /// 
        /// sample: 
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("AccrualRatePerYearOfService", "");
        ///    dic.Add("UpToAgeAndService", "");
        ///    pFlatAmountAccumulation._Standard_Table(dic); 
        /// </summary>
        /// <param name="sExcelFile"></param>
        public void _Standard_Table(MyDictionary dic)
        {
            string sFunctionName = "_CV_AddMultipleLabels";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRow = Convert.ToInt32(dic["iRow"]);
                string sBackTabs = "";
                string sRow = "";

              
                for (int i = 1; i < 20 ; i++)
                    sBackTabs = sBackTabs + "{Tab}";

                for (int i = 1; i < iRow; i++)
                    sRow = sRow + "{Tab}{Tab}{Tab}{Tab}";

                _gLib._SetSyncUDWin("", this.wRetirementStudio.wAccrualRateTiers.grid, "click", 0);
                _gLib._SendKeysUDWin("", this.wRetirementStudio.wAccrualRateTiers.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("", this.wRetirementStudio.wAccrualRateTiers.grid, sBackTabs, 0, ModifierKeys.Shift, false);

                _gLib._SendKeysUDWin("", this.wRetirementStudio.wAccrualRateTiers.grid, sRow, 0);
                if (iRow != this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wAccrualRateTiers.grid) + 1)
                    _gLib._MsgBoxYesNo("", "failed locate row, the expression row is :" + iRow + " , but the actuarial row is ：" + this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wAccrualRateTiers.grid) + 1);
                               
                _gLib._SetSyncUDWin_ByClipboard("AccrualRatePerYearOfService", this.wRetirementStudio.wEditConstant.Edit.txt, dic["AccrualRatePerYearOfService"], 0);
              
                _gLib._SendKeysUDWin("UpToAgeAndService", this.wRetirementStudio.wEditConstant.Edit.txt, "{Tab}{Tab}{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("UpToAgeAndService", this.wRetirementStudio.wNumEditor.Edit.txt, dic["UpToAgeAndService"], 0);
             

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "this function is not complete yet");
            }
        }


        /// <summary>
        /// 2015-Dec-31 
        /// ruiyang.song@mercer.com
        /// 
        /// sample: 
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("AccrualRatePerYearOfService_txt", "");
        ///    dic.Add("AccrualRatePerYearOfService_cbo", "");
        ///    pFlatAmountAccumulation._Only_AccrualRate(dic); 
        /// </summary>
        /// <param name="sExcelFile"></param>
        public void _Only_AccrualRate(MyDictionary dic)
        {
            string sFunctionName = "_Only_AccrualRate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRow = Convert.ToInt32(dic["iRow"]);
                string sRow = "";
                for (int i = 1; i < iRow; i++)
                    sRow = sRow + "{Tab}{Tab}{Tab}";

                string sBackTabs = "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}";
                                          

                _gLib._SetSyncUDWin("", this.wRetirementStudio.wAccrualRateTiers.grid, "click", 0);
                _gLib._SendKeysUDWin("", this.wRetirementStudio.wAccrualRateTiers.grid, sBackTabs, 0, ModifierKeys.Shift, false);

                _gLib._SendKeysUDWin("", this.wRetirementStudio.wAccrualRateTiers.grid, sRow, 0);
                

                if (dic["AccrualRatePerYearOfService_txt"] != "")
                    _gLib._SetSyncUDWin("AccrualRatePerYearOfService_txt", this.wRetirementStudio.wButton_C.btn, "click", 0);
                _gLib._SetSyncUDWin_ByClipboard("AccrualRatePerYearOfService_txt", this.wRetirementStudio.wEditConstant.Edit.txt, dic["AccrualRatePerYearOfService_txt"], 0);


                if (dic["AccrualRatePerYearOfService_cbo"] != "")
                    _gLib._SetSyncUDWin("AccrualRatePerYearOfService_cbo", this.wRetirementStudio.wButton_V.btn, "click", 0);
                _gLib._SetSyncUDWin("AccrualRatePerYearOfService_cbo", this.wRetirementStudio.wAccrualRatePerYear_cbo.cbo, dic["AccrualRatePerYearOfService_cbo"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "this function is not complete yet");
            }
        }



        /// <summary>
        /// 2016-Jan-5
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AccountBalance", "");
        ///    dic.Add("StartAgeForLinearization", "");
        ///    dic.Add("BreakPoint_V", "");
        ///    dic.Add("BreakPoint_cbo", "");
        ///    dic.Add("BreakPointAge", "");
        ///    dic.Add("ServiceBasedOn", "");
        ///    pFlatAmountAccumulation._LinearizationWithBreakpoint(dic); 

        /// </summary>
        /// <param name="dic"></param>
        public void _LinearizationWithBreakpoint(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("AccountBalance", this.wRetirementStudio.wAccountBalance.cbo, dic["AccountBalance"], 0);
                _gLib._SetSyncUDWin("StartAgeForLinearization", this.wRetirementStudio.wStartAge.cbo, dic["StartAgeForLinearization"], 0);
                _gLib._SetSyncUDWin("BreakPoint_V", this.wRetirementStudio.wBreakPoint_V.btn, dic["BreakPoint_V"], 0);
                _gLib._SetSyncUDWin("BreakPoint_cbo", this.wRetirementStudio.wBreakPoint_cbo.cbo, dic["BreakPoint_cbo"], 0);
                _gLib._SetSyncUDWin("BreakPointAge", this.wRetirementStudio.wBreakpointAge.cbo, dic["BreakPointAge"], 0);
                _gLib._SetSyncUDWin("ServiceBasedOn", this.wRetirementStudio.wService_ServiceBasedOn.cbo, dic["ServiceBasedOn"], 0);
            
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "Function is not completed");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
