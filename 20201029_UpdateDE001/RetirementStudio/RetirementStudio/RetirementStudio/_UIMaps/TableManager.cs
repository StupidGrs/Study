namespace RetirementStudio._UIMaps.TableManagerClasses
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
    
    
    public partial class TableManager
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();

        
        /// <summary>
        /// 2015-Apr-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Name", "");
        ///    dic.Add("Type", "");
        ///    dic.Add("Description", "");
        ///    dic.Add("EffectiveDate", "");
        ///    dic.Add("Ultimate", "");
        ///    dic.Add("SelectAndUltimate", "");
        ///    dic.Add("SelectPeriods", "");
        ///    dic.Add("Generational", "");
        ///    dic.Add("TwoDimensional", "");
        ///    dic.Add("Index1", "");
        ///    dic.Add("From1", "");
        ///    dic.Add("To1", "");
        ///    dic.Add("Index2", "");
        ///    dic.Add("From2", "");
        ///    dic.Add("To2", "");
        ///    dic.Add("Extend", "");
        ///    dic.Add("Zero", "");
        ///    dic.Add("SameRatesUsed", "");
        ///    dic.Add("Format", "");
        ///    dic.Add("DecimalPlaces", "");
        ///    dic.Add("Use1000Separator", "");
        ///    pTableManager._ts_AddTable(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _ts_AddTable(MyDictionary dic)
        {
            string sFunctionName = "_ts_AddTable";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                #region Right select
                try
                {
                    Mouse.Click(this.wRetirementStudio.wTableSetup.grid, MouseButtons.Right, ModifierKeys.None, new Point(80, 50));
                }
                catch (Exception ex)
                {
                    _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to Right click on Table Setup grid. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right click on Table Setup grid. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                }


                WinWindow wWin = new WinWindow();
                wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "DropDown");
                wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains);
                wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

                if (_gLib._Exists("DropDown Menu Parent Win", wWin, 0))
                {
                    MyDictionary dicTmp = new MyDictionary();
                    dicTmp.Clear();
                    dicTmp.Add("Level_1", "Add");
                    _gLib._MenuSelectWin(0, wWin, dicTmp);

                }

                #endregion

                _gLib._SetSyncUDWin("Name", this.wParameters.wName.txt, dic["Name"], 0);
                _gLib._SetSyncUDWin("Type", this.wParameters.wType.cbo, dic["Type"], 0);
                _gLib._SetSyncUDWin("Description", this.wParameters.wDescription.txt, dic["Description"], 0);
                _gLib._SetSyncUDWin("Ultimate", this.wParameters.wUltimate.rd, dic["Ultimate"], 0);
                _gLib._SetSyncUDWin("SelectAndUltimate", this.wParameters.wSelectAndUltimate.rd, dic["SelectAndUltimate"], 0);
                //_gLib._SetSyncUDWin("SelectPeriods", this.wParameters.wSelectPeriods.txtSelectPeriods, dic["SelectPeriods"], 0);
                if (dic["SelectPeriods"] != "")
                {
                    string sActVal = ((WinEdit)this.wParameters.wSelectPeriods.txtSelectPeriods).Text;
                    if (sActVal != dic["SelectPeriods"])
                    {
                        try
                        {
                            this.wParameters.wSelectAndUltimate.rd.SetFocus();
                        }
                        catch (Exception ex)
                        {
                            _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set focus on <SelectAndUltimate> Because exception threw out: " + Environment.NewLine + ex.Message);
                            _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set focus on <SelectAndUltimate>. Because exception threw out: " + Environment.NewLine + ex.Message);
                        }
                        Keyboard.SendKeys("{Tab}" + dic["SelectPeriods"]);
                        try
                        {
                            this.wParameters.wSelectAndUltimate.rd.SetFocus();
                        }
                        catch (Exception ex)
                        {
                            _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set focus on <SelectAndUltimate> Because exception threw out: " + Environment.NewLine + ex.Message);
                            _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set focus on <SelectAndUltimate>. Because exception threw out: " + Environment.NewLine + ex.Message);
                        }
                        sActVal = this.wParameters.wSelectPeriods.txtSelectPeriods.Text;
                        if (sActVal == dic["SelectPeriods"])
                        {
                            _gLib._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> successfully set <" + dic["SelectPeriods"] + "> to object <SelectPeriods>.");
                        }
                        else
                        {
                            _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + dic["SelectPeriods"] + "> to object <SelectPeriods>. Actual Value: <" + sActVal + "> ");
                            _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Verify Object: <SelectPeriods> with expected value: <" + dic["SelectPeriods"] + ">. Actual Value: <" + sActVal + "> ");
                        }
                    }
                }

                _gLib._SetSyncUDWin("Generational", this.wParameters.wGenerational.rd, dic["Generational"], 0);
                _gLib._SetSyncUDWin("TwoDimensional", this.wParameters.wTwoDimensional.rd, dic["TwoDimensional"], 0);
                _gLib._SetSyncUDWin("Index1", this.wParameters.wIndex1.cbo, dic["Index1"], 0);
             
                if (dic["From1"]!="")
                {
                    this.wParameters.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "4");
                    _gLib._SetSyncUDWin_ByClipboard("From1", this.wParameters.wCommon_txt, dic["From1"], 0);
                    _gLib._SendKeysUDWin("", this.wParameters.wCommon_txt, "{Tab}");
                }
                if (dic["To1"] != "")
                {
                    this.wParameters.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "5");
                    _gLib._SetSyncUDWin_ByClipboard("To1", this.wParameters.wCommon_txt, dic["To1"], 0);
                }
              
                
                _gLib._SetSyncUDWin("Index2", this.wParameters.wIndex2.cbo, dic["Index2"], 0);

                if (dic["From2"] != "")
                {
                    if (dic["Index2"].Contains("Range"))
                        _gLib._MsgBoxYesNo("", "Please verify the value of From2, this field should be blank");
                    else
                    {
                        _gLib._SendKeysUDWin("", this.wParameters.wIndex2.cbo, "{Tab}");
                        Clipboard.SetText(dic["From2"]);
                        Keyboard.SendKeys("v", ModifierKeys.Control);
                    }
                }

                if (dic["To2"] != "")
                {
                    string sKeys = "{Tab}{Tab}";
                    if(dic["Index2"].Contains("Range"))
                        sKeys = "{Tab}";
                                       
                    _gLib._SendKeysUDWin("", this.wParameters.wIndex2.cbo, sKeys);
                   
                    Clipboard.SetText(dic["To2"]);
                    Keyboard.SendKeys("v", ModifierKeys.Control);
          
                }
                              
                _gLib._SetSyncUDWin_ByClipboard("EffectiveDate", this.wParameters.wEffectiveDate.txt, dic["EffectiveDate"], 0);_gLib._SetSyncUDWin("Extend", this.wParameters.wExtend.rd, dic["Extend"], 0);
                _gLib._SetSyncUDWin("Zero", this.wParameters.wZero.rd, dic["Zero"], 0);
                _gLib._SetSyncUDWin("SameRatesUsed", this.wParameters.wSameRatesUsed.chk, dic["SameRatesUsed"], 0);
                _gLib._SetSyncUDWin("Format", this.wParameters.wFormat.cbo, dic["Format"], 0);
                if (dic["DecimalPlaces"] != "")
                {
                    _gLib._SendKeysUDWin("", this.wParameters.wFormat.cbo, "{Tab}");
                    //////this.wParameters.wCommon_txt.txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "9");
                    //////_gLib._SetSyncUDWin_ByClipboard("DecimalPlaces", this.wParameters.wCommon_txt.txt, dic["DecimalPlaces"], 0);

                    _gLib._SetSyncUDWin_ByClipboard("DecimalPlaces", this.wParameters.wDecimalPlace.txt, dic["DecimalPlaces"], 0);
                }
                _gLib._SetSyncUDWin("Use1000Separator", this.wParameters.wUse1000Separator.chk, dic["Use1000Separator"], 0);
                _gLib._SetSyncUDWin("OK", this.wParameters.wOK.btn, "Click", 0);


                //// verify from2 and to2
                if(dic["From2"]!="" || dic["To2"]!= "")
                    this._VerifyYears(dic["From2"], dic["To2"]);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("Warning", "No Verify Function here!");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        public void _ts_PasteValue(string sValue, Boolean bFrom2Row = false)
        {
            string sFunctionName = "_ts_PasteValue";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SendKeysUDWin("", this.wRetirementStudio.wEntrySetup.grid, "{Home}{Home}", 0, ModifierKeys.Control, false);
            _gLib._SendKeysUDWin("", this.wRetirementStudio.wEntrySetup.grid, "{PageUp}{PageUp}{PageUp}{PageUp}", 0);
            _gLib._SendKeysUDWin("", this.wRetirementStudio.wEntrySetup.grid, "{PageUp}", 0);
            _gLib._SendKeysUDWin("", this.wRetirementStudio.wEntrySetup.grid, "{PageUp}", 0);

            if(bFrom2Row)
                _gLib._SetSyncUDWin("Entry Setup", this.wRetirementStudio.wEntrySetup.grid, "Click", 0, false, 108, 50);
            else
                _gLib._SetSyncUDWin("Entry Setup", this.wRetirementStudio.wEntrySetup.grid, "Click", 0, false, 108, 30);

         
            if (!_gLib._Exists("Table Field", this.wRetirementStudio.wTableField.txt, 3, false))
            {
                _gLib._MsgBox("Warning", "Table field is NOT activated, please manually activate the first cell can type Ctrl-V to paste value");
            }
            else
            {
                Clipboard.Clear();
                Clipboard.SetText(sValue);
                try
                {
                    Keyboard.SendKeys(this.wRetirementStudio.wTableField.txt, "v", ModifierKeys.Control);
                }
                catch (Exception ex)
                {
                    _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to send Keys. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to send Keys. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                }

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2015-Apr-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pTableManager._SelectTab("Male Rates");
        ///    pTableManager._SelectTab("Female Rates");
        /// </summary>
        /// <param name="dic"></param>
        public void _SelectTab(string sTabName)
        {
            string sFunctionName = "_SelectTab";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TabPageSelectWin(sTabName, this.wRetirementStudio.wTab, 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        private void _VerifyYears(string from, string to)
        {
            _gLib._SendKeysUDWin("", this.wRetirementStudio.wEntrySetup.grid, "{End}", 0, ModifierKeys.Control, false);
            _gLib._SendKeysUDWin("", this.wRetirementStudio.wEntrySetup.grid, "{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}", 0);

            int col = _fp._ReturnSelectColIndex(this.wRetirementStudio.wEntrySetup.grid);

            if (from == "")
                from = "0";

            int expected =  Convert.ToInt32(to) -  Convert.ToInt32(from) +1;

            if (expected != col)
                _gLib._MsgBoxYesNo("", "please check the number of this table, from2 is: < " + from + " >, and to2 is < " + to + " >");

            _gLib._SendKeysUDWin("", this.wRetirementStudio.wEntrySetup.grid, "{Home}", 0, ModifierKeys.Control, false);

        }

    }
}
