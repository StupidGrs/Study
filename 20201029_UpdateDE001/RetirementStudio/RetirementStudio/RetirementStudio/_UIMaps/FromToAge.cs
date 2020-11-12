namespace RetirementStudio._UIMaps.FromToAgeClasses
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
    
    public partial class FromToAge
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        /// <summary>
        /// 2015-Apr-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "");
        ///    dic.Add("CustomCode", "True");
        ///    dic.Add("NoServiceGrowIn", "True");
        ///    dic.Add("FreezeServiceAtValuation", "True");
        ///    pFromToAge._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("ServiceAsAFunction", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);

                _gLib._SetSyncUDWin("NoServiceGrowIn", this.wRetirementStudio.wNoservicegrowin.chx, dic["NoServiceGrowIn"], 0);
                _gLib._SetSyncUDWin("FreezeServiceAtValuation", this.wRetirementStudio.wFreezeServiceAtValuation.chx, dic["FreezeServiceAtValuation"], 0);
                

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("ServiceAsAFunction", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Sep-20
        /// webber.ling@mercer.com
        ///    dic.Clear();
        ///    dic.Add("InsertRow", "");
        ///    dic.Add("Is_DE", "");
        ///    dic.Add("AddRow", "");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("SSNRA_Exists", "False");
        ///    dic.Add("SSNRA", "");
        ///    dic.Add("FixedAge", "55");
        ///    dic.Add("YearOfService", "5");
        ///    dic.Add("RuleOf", "");
        ///    dic.Add("DateConstant", "");
        ///    dic.Add("DateField", "$ValDate");
        ///    dic.Add("ServiceBasedOn", "$Service");
        ///    dic.Add("AgeBasedOn", "$Age");
        ///    dic.Add("Comparison", "Later of");
        ///    pFromToAge._StandardTable_NotUS(dic);
        /// </summary>
        /// <param name="dic"></param>
        public void _StandardTable_NotUS(MyDictionary dic)
        {
            string sFunctionName = "_StandardTable_NotUS";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("InsertRow", this.wRetirementStudio.wInsertRow.btnInsertRow, dic["InsertRow"], 0);
            _gLib._SetSyncUDWin("AddRow", this.wRetirementStudio.wAddRow.btnAddRow, dic["AddRow"], 0);

            _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Space}{Space}");
            _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Space}{Space}");

            ////if (dic["iRow"] != "1")
            ////{
            ////    _gLib._MsgBoxYesNo("Warning?", "Function <" + sFunctionName + "> only support Row index =1, currenly row index <" + dic["iRow"] + "> is NOT supported. Please contact webber.ling@mercer.com if you need more options");
            ////    return;
            ////}

            string sRowKeys = "";
            int iRow = Convert.ToInt32(dic["iRow"]);
            ////////for (int i = 1; i < iRow; i++)
            ////////    sRowKeys = sRowKeys + "{Down}";

            ////////if (iRow > 1)
            ////////{
            ////////    _gLib._MsgBoxYesNo("Please manual input values in this function call and click OK to keep testing.", "Warning: Function <" + sFunctionName + "> Only support iRow = 1 for now, please contact Webber.ling for further improvements.");
            ////////    return;
            ////////}

            int iRowPos_Y = 68 + (iRow - 1) * 20;

            _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);

            if (dic["SSNRA_Exists"].ToUpper().Equals("FALSE"))
            {
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);
                _gLib._Wait(1);
            }
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
            ////_gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);


            if (dic["SSNRA_Exists"].Equals(""))
                dic.Add("SSNRA_Exists", "True");

            if (dic["SSNRA"] != "")
            {
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);

                if (dic["SSNRA"].ToUpper() != sAct.ToUpper())
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Space}");
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Space}");
                    _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                    sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                    if (dic["SSNRA"].ToUpper() != sAct.ToUpper())
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  set SSNRA value <" + dic["SSNRA"] + "> at Row <" + dic["iRow"] + ">. Actual value: <" + sAct + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  set SSNRA value <" + dic["SSNRA"] + "> at Row <" + dic["iRow"] + ">. Actual value: <" + sAct + ">");
                    }
                }
            }
            if (dic["FixedAge"] != "")
            {
                ////_gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, dic["FixedAge"]);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                if (dic["SSNRA_Exists"].ToUpper().Equals("FALSE"))
                    _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                if (dic["SSNRA_Exists"].ToUpper().Equals("TRUE")) 
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}");

                _gLib._SetSyncUDWin_ByClipboard("FixedAge", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["FixedAge"],0);

                _gLib._VerifySyncUDWin("FixedAge", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["FixedAge"], 0);
             }
            if (dic["YearOfService"] != "")
            {
                ////_gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, dic["YearOfService"]);

                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                if (dic["SSNRA_Exists"].ToUpper().Equals("FALSE")) 
                    _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);

                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                if (dic["SSNRA_Exists"].ToUpper().Equals("TRUE")) 
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}");
                else
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}");

                _gLib._SetSyncUDWin_ByClipboard("YearOfService", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["YearOfService"], 0);

                _gLib._VerifySyncUDWin("YearOfService", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["YearOfService"], 0);
            }
            if (dic["RuleOf"] != "")
            {
                ////_gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, dic["RuleOf"]);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                if (dic["SSNRA_Exists"].ToUpper().Equals("FALSE"))
                    _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                if (dic["SSNRA_Exists"].ToUpper().Equals("TRUE")) 
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}");
                else
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}");

                _gLib._SendKeysUDWin("RuleOf", this.wRetirementStudio.wFPGrid.grid, dic["RuleOf"]);

                _gLib._VerifySyncUDWin("RuleOf", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["RuleOf"], 0);
            }

            if (dic["DateConstant"] != "")
            {
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
             
                if (dic["SSNRA_Exists"].ToUpper().Equals("FALSE"))
                    _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);
                if (dic["SSNRA_Exists"].ToUpper().Equals("TRUE"))
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                else
                {
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                    _gLib._SendKeysUDWin("DateConstant", this.wRetirementStudio.wFPGrid.grid, dic["DateConstant"]);

                    //_gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                    //_gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");

                    _gLib._VerifySyncUDWin("DateConstant", this.wRetirementStudio.wDateConstant.txt, dic["DateConstant"], 0);
                }
            }


            if (dic["DateField"] != "")
            {
                ////_gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                if (dic["SSNRA_Exists"].ToUpper().Equals("FALSE"))
                    _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);
                if (dic["SSNRA_Exists"].ToUpper().Equals("TRUE")) 
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                else
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                ////////////_gLib._SetSyncUDWin("DateField", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["DateField"], 0);
                try
                {
                    this.wRetirementStudio.wCommonCombo_FPGrid.cbo.SelectedItem = dic["DateField"];
                    //////_gLib._SetSyncUDWin("ServiceBasedOn", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["ServiceBasedOn"], 0);
                }
                catch (Exception ex)
                {
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SetSyncUDWin("DateField", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["DateField"], 0);
                }
            
            }

            if (dic["ServiceBasedOn"] != "")
            {
                ////_gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

                if (dic["SSNRA_Exists"].ToUpper().Equals("FALSE"))
                    _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);


                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                if (dic["SSNRA_Exists"].ToUpper().Equals("FALSE"))
                    _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);

                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                if (dic["SSNRA_Exists"].ToUpper().Equals("TRUE"))
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                else
                {
                    if (dic["iRow"] == "1")
                        _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                    else
                        _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                }


                ////////{
                ////////    for (int i = 0; i < 9;i++ )
                ////////        _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}");
                ////////}
                ////////////

                try
                {
                    this.wRetirementStudio.wCommonCombo_FPGrid.cbo.SelectedItem = dic["ServiceBasedOn"];
                    //////_gLib._SetSyncUDWin("ServiceBasedOn", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["ServiceBasedOn"], 0);
                }
                catch (Exception ex)
                {
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SetSyncUDWin("ServiceBasedOn", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["ServiceBasedOn"], 0);
                }
            }
            if (dic["AgeBasedOn"] != "")
            {
                ////_gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                if (dic["SSNRA_Exists"].ToUpper().Equals("FALSE"))
                    _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);


                if (dic["SSNRA_Exists"].ToUpper().Equals("TRUE"))
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                else
                {
                    if (dic["iRow"] == "1")
                        _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                    else
                        _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                }
                 

                try
                {
                    this.wRetirementStudio.wCommonCombo_FPGrid.cbo.SelectedItem = dic["AgeBasedOn"];
                    //////_gLib._SetSyncUDWin("ServiceBasedOn", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["ServiceBasedOn"], 0);
                }
                catch (Exception ex)
                {
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SetSyncUDWin("AgeBasedOn", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["AgeBasedOn"], 0);
                }
            }
            if (dic["Comparison"] != "")
            {
                ////_gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                if (dic["SSNRA_Exists"].ToUpper().Equals("FALSE"))
                    _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                if (dic["SSNRA_Exists"].ToUpper().Equals("TRUE")) 
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                else
                {
                    if (dic["iRow"] == "1")
                        _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                    else
                        _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                }
                    ////////_gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");

                _gLib._SetSyncUDWin("Comparison", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["Comparison"], 0);
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }


        /// <summary>
        /// 2013-Sep-20
        /// webber.ling@mercer.com
        ///    dic.Clear();
        ///    dic.Add("InsertRow", "");
        ///    dic.Add("AddRow", "");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("SSNRA", "");
        ///    dic.Add("FixedAge", "55");
        ///    dic.Add("YearOfService", "5");
        ///    dic.Add("RuleOf", "");
        ///    dic.Add("DateConstant", "");
        ///    dic.Add("DateField", "$ValDate");
        ///    dic.Add("ServiceBasedOn", "$Service");
        ///    dic.Add("AgeBasedOn", "$Age");
        ///    dic.Add("Comparison", "Later of");
        ///    pFromToAge._StandardTable(dic);
        /// </summary>
        /// <param name="dic"></param>
        public void _StandardTable(MyDictionary dic)
        {
            string sFunctionName = "_StandardTable";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("InsertRow", this.wRetirementStudio.wInsertRow.btnInsertRow, dic["InsertRow"], 0);
            _gLib._SetSyncUDWin("AddRow", this.wRetirementStudio.wAddRow.btnAddRow, dic["AddRow"], 0);

            _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
          
            _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Space}{Space}{Space}");

            ////if (dic["iRow"] != "1")
            ////{
            ////    _gLib._MsgBoxYesNo("Warning?", "Function <" + sFunctionName + "> only support Row index =1, currenly row index <" + dic["iRow"] + "> is NOT supported. Please contact webber.ling@mercer.com if you need more options");
            ////    return;
            ////}

            string sRowKeys = "{Up}{Up}{Up}";
            int iRow = Convert.ToInt32(dic["iRow"]);
            for (int i = 1; i < iRow; i++)
                sRowKeys = sRowKeys + "{Down}";

            _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
            _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);


            if (dic["SSNRA"] != "")
            {
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);

                if (dic["SSNRA"].ToUpper() != sAct.ToUpper())
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Space}");
                    _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Space}");
                    _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                    sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                    if (dic["SSNRA"].ToUpper() != sAct.ToUpper())
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  set SSNRA value <" + dic["SSNRA"] + "> at Row <" + dic["iRow"] + ">. Actual value: <" + sAct + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  set SSNRA value <" + dic["SSNRA"] + "> at Row <" + dic["iRow"] + ">. Actual value: <" + sAct + ">");
                    }
                }
            }
            if (dic["FixedAge"] != "")
            {
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, dic["FixedAge"]);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}");
                _gLib._SendKeysUDWin("FixedAge", this.wRetirementStudio.wFPGrid.grid, dic["FixedAge"]);

                _gLib._VerifySyncUDWin("FixedAge", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["FixedAge"], 0);
            }
            if (dic["YearOfService"] != "")
            {
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, dic["YearOfService"]);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("YearOfService", this.wRetirementStudio.wFPGrid.grid, dic["YearOfService"]);

                _gLib._VerifySyncUDWin("YearOfService", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["YearOfService"], 0);
            }
            if (dic["RuleOf"] != "")
            {
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, dic["RuleOf"]);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("RuleOf", this.wRetirementStudio.wFPGrid.grid, dic["RuleOf"]);

                _gLib._VerifySyncUDWin("RuleOf", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["RuleOf"], 0);
            }
            if (dic["DateConstant"] != "")
            {
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, dic["RuleOf"]);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");

                _gLib._SetSyncUDWin_ByClipboard("DateConstant", this.wRetirementStudio.wCommonDate_FPGrid.txt, dic["DateConstant"], 0);
            }
            if (dic["DateField"] != "")
            {
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SetSyncUDWin("DateField", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["DateField"], 0);
            }
            if (dic["ServiceBasedOn"] != "")
            {
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");

                _gLib._SetSyncUDWin("ServiceBasedOn", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["ServiceBasedOn"], 0);
            }
            if (dic["AgeBasedOn"] != "")
            {
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");

                _gLib._SetSyncUDWin("AgeBasedOn", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["AgeBasedOn"], 0);
            }
            if (dic["Comparison"] != "")
            {
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, sRowKeys);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");

                _gLib._SetSyncUDWin("Comparison", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["Comparison"], 0);
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }



        /// <summary>
        /// 2013-Sep-20
        /// webber.ling@mercer.com
        ///    dic.Clear();
        ///    dic.Add("Comparison", "Earlier of");
        ///    dic.Add("FromToAge", "UnreducedRetAge");
        ///    pFromToAge._Standard_CompareAboveResultsTable(dic);
        /// </summary>
        /// <param name="dic"></param>
        public void _Standard_CompareAboveResultsTable(MyDictionary dic)
        {
            string sFunctionName = "_Standard_CompareAboveResultsTable";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("CompareAboveResults - Comparison", this.wRetirementStudio.wCompareAbove_Comparison.cboComparison, dic["Comparison"], 0);
            _gLib._SetSyncUDWin("CompareAboveResults - FromToAge", this.wRetirementStudio.wCompareAbove_FromToAge.cboFromToAge, dic["FromToAge"], 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-Sep-20
        /// webber.ling@mercer.com
        ///    dic.Clear();
        ///    dic.Add("AddRow", "");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("ServiceBasedOn", "$Service");
        ///    dic.Add("AgeBasedOn", "$Age");
        ///    pFromToAge._StandardTable_DE(dic);
        /// </summary>
        /// <param name="dic"></param>
        public void _StandardTable_DE(MyDictionary dic)
        {
            string sFunctionName = "_StandardTable_DE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("AddRow", this.wRetirementStudio.wAddRow.btnAddRow, dic["AddRow"], 0);


            int iRow = Convert.ToInt32(dic["iRow"]); 


            _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
            _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{End}{End}", 0, ModifierKeys.Control, false);


            if (dic["ServiceBasedOn"] != "")
            {
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{End}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}", 0, ModifierKeys.Shift, false);
               
                int iActual = _fp._ReturnSelectRowIndex(this.wRetirementStudio.wFPGrid.grid);
                if (iActual + 1 != iRow)
                    _gLib._MsgBox("", "Fail to locate the assigned row, please set <ServiceBasedOn> as <" + dic["ServiceBasedOn"] + "> in line; " + iRow);
                else 
                    _gLib._SetSyncUDWin("ServiceBasedOn", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["ServiceBasedOn"], 0);
                
            }

            if (dic["AgeBasedOn"] != "")
            {
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{End}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}", 0, ModifierKeys.Shift, false);

                int iActual = _fp._ReturnSelectRowIndex(this.wRetirementStudio.wFPGrid.grid);
                if (iActual+1 != iRow )
                    _gLib._MsgBox("", "Fail to locate the assigned row, please set <AgeBasedOn> as <" + dic["AgeBasedOn"] + "> in line; " + iRow);
                else 
                    _gLib._SetSyncUDWin("AgeBasedOn", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["AgeBasedOn"], 0);
               
            }
            if (dic["Comparison"] != "")
            {
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{End}", 0, ModifierKeys.Control, false);

                int iActual = _fp._ReturnSelectRowIndex(this.wRetirementStudio.wFPGrid.grid);
                if (iActual + 1 != iRow)
                    _gLib._MsgBox("", "Fail to locate the assigned row, please set <Comparison> as <" + dic["Comparison"] + "> in line; " + iRow);
                else
                    _gLib._SetSyncUDWin("Comparison", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["Comparison"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
            
        }


        /// <summary>
        /// 2013-Sep-20
        /// webber.ling@mercer.com
        ///    dic.Clear();
        ///    dic.Add("InsertRow", "");
        ///    dic.Add("AddRow", "");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("ServiceBasedOn", "$Service");
        ///    dic.Add("AgeBasedOn", "$Age");
        ///    pFromToAge._StandardTable_ANZ(dic);
        /// </summary>
        /// <param name="dic"></param>
        public void _StandardTable_ANZ(MyDictionary dic)
        {
            string sFunctionName = "_StandardTable_ANZ";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("InsertRow", this.wRetirementStudio.wInsertRow.btnInsertRow, dic["InsertRow"], 0);
            _gLib._SetSyncUDWin("AddRow", this.wRetirementStudio.wAddRow.btnAddRow, dic["AddRow"], 0);

            _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
            _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Space}{Space}");

            string sRowKeys = "{Up}{Up}{Up}";
            int iRow = Convert.ToInt32(dic["iRow"]);
            for (int i = 1; i < iRow; i++)
                sRowKeys = sRowKeys + "{Down}";

            int iRowPos_Y = 68 + (iRow - 1) * 20;

            _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 40, 38);
            _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);


            if (dic["ServiceBasedOn"] != "")
            {
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);

                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");

                _gLib._SetSyncUDWin("ServiceBasedOn", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["ServiceBasedOn"], 0);

            }

            if (dic["AgeBasedOn"] != "")
            {
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);

                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SetSyncUDWin("AgeBasedOn", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["AgeBasedOn"], 0);

            }


            if (dic["Comparison"] != "")
            {
                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SetSyncUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, iRowPos_Y);

                _gLib._SendKeysUDWin("Standard Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}");
                _gLib._SetSyncUDWin("Comparison", this.wRetirementStudio.wCommonCombo_FPGrid.cbo, dic["Comparison"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


    }
}
