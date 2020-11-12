namespace RetirementStudio._UIMaps.VestingClasses
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


    public partial class Vesting
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        public void _Debugging()
        {

            var sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wStandard_FPGrid.grid);
            var c = 1;
        }


        /// <summary>
        /// 2013-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "Click");
        ///    dic.Add("Table", "");
        ///    dic.Add("CustomCode", "");
        ///    pVesting._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wTable.rdTable, dic["Table"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("Table", this.wRetirementStudio.wTable.rdTable, dic["Table"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
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
        ///    dic.Add("VestingServiceDefinition", "VestingService");
        ///    dic.Add("AddRow", "");
        ///    pVesting._PopVerify_Standard(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ServiceAtValuationDate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("VestingServiceDefinition", this.wRetirementStudio.wStandard_VestingServiceDefinition.cboVestingServiceDefinition, dic["VestingServiceDefinition"], 0);
                _gLib._SetSyncUDWin("AddRow", this.wRetirementStudio.wStandard_AddRow.btnAddRow, dic["AddRow"], 0);
            }   


            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("VestingServiceDefinition", this.wRetirementStudio.wStandard_VestingServiceDefinition.cboVestingServiceDefinition, dic["VestingServiceDefinition"], 0);
                _gLib._VerifySyncUDWin("AddRow", this.wRetirementStudio.wStandard_AddRow.btnAddRow, dic["AddRow"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("YearsOfService", "5");
        ///    dic.Add("VestingPercentage", "100.0");
        ///    pVesting._ServiceTable(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _ServiceTable(MyDictionary dic)
        {
            string sFunctionName = "_ServiceTable";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            ////////////Mouse.Click(this.wRetirementStudio.wStandard_FPGrid.grid, new Point(94, 28));
            ////////////Mouse.Click(this.wRetirementStudio.wStandard_FPGrid.grid, new Point(94, 28));
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wStandard_FPGrid.grid, "Click", 0, false, 94, 28);
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wStandard_FPGrid.grid, "Click", 0, false, 94, 28);

            if(_gLib._Exists("Vesting Table Grid", this.wRetirementStudio.wStandard_TBL_YearsOfService.txtYearsOfService, 0))
            {
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wStandard_FPGrid.grid, "{PageUp}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wStandard_FPGrid.grid, "{PageUp}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wStandard_FPGrid.grid, "{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}");

                _gLib._Wait(1);
                ////////////Mouse.Click(this.wRetirementStudio.wStandard_FPGrid.grid, new Point(94, 10));
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wStandard_FPGrid.grid, "Click", 0, false, 94, 10);
            }

            int iRow = Convert.ToInt32(dic["iRow"]);

            if(dic["YearsOfService"]!="")
            {
                for(int i=0;i<(iRow-1);i++)
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wStandard_FPGrid.grid, "{Tab}{Tab}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wStandard_FPGrid.grid, "{Tab}{Tab}");

                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": YearsOfService", this.wRetirementStudio.wStandard_TBL_YearsOfService.txtYearsOfService, dic["YearsOfService"], 0);
            }

            if (dic["VestingPercentage"] != "")
            {
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wStandard_FPGrid.grid, "{Tab}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wStandard_FPGrid.grid, "{Tab}");

                //_gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": VestingPercentage", this.wRetirementStudio.wStandard_TBL_VestingPercentage.txtVestingPercentage, dic["VestingPercentage"], 0, false, false);

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wStandard_TBL_VestingPercentage.txtVestingPercentage, dic["VestingPercentage"]);
                _gLib._SendKeysUDWin("VestingPercentage", this.wRetirementStudio.wStandard_TBL_VestingPercentage.txtVestingPercentage, dic["VestingPercentage"]);

                ////////////Mouse.Click(this.wRetirementStudio.wStandard_BlankArea.clientBlankArea, new Point(534, 120));
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wStandard_BlankArea.clientBlankArea, "Click", 0, false, 534, 120);

                string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wStandard_FPGrid.grid);
                if (sAct != dic["VestingPercentage"])
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set <" + dic["VestingPercentage"] + "> to object <Vesting Standard Table>. Actual Value: <" + sAct + "> ");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Verify Object: <Vesting Standard Table> with expected value: <" + dic["VestingPercentage"] + ">. Actual Value: <" + sAct + "> "); 
                }
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
        ///    dic.Add("VestingRule", "");
        ///    dic.Add("VestingRatio", "");
        ///    pVesting._PopVerify_Standard_DE(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard_DE(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard_DE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("VestingRule", this.wRetirementStudio.wVestingRule.cbo, dic["VestingRule"], 0);
                _gLib._SetSyncUDWin("VestingRatio", this.wRetirementStudio.wVestingRadio.cbo, dic["VestingRatio"], 0);
            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete yet.");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Mar-22
        ///  ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Table", "");
        ///    dic.Add("Index1", "");
        ///    dic.Add("Setback", "");
        ///    dic.Add("Index2", "");
        ///    pVesting._PopVerify_Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Table(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wTable_Table.cbo, dic["Table"], 0);
                _gLib._SetSyncUDWin("Index1", this.wRetirementStudio.wTable_Index1.cbo, dic["Index1"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Setback", this.wRetirementStudio.wTable_Setback.txt, dic["Setback"], 0);
                _gLib._SetSyncUDWin("Index2", this.wRetirementStudio.wTable_Index2.cbo, dic["Index2"], 0);
            }


            if (dic["PopVerify"] == "Verify")
            {

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
