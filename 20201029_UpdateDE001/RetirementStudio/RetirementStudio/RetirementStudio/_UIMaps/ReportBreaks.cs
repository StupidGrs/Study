namespace RetirementStudio._UIMaps.ReportBreaksClasses
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
    
    
    public partial class ReportBreaks
    {


        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2013-May-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("BreakFields", "TPlan");
        ///    dic.Add("TextSubstitution", "Click");
        ///    dic.Add("Remove", "Click");
        ///    dic.Add("OK", "");
        ///    pReportBreaks._PopVerify_ReportBreaks(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ReportBreaks(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ReportBreaks";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                int iRow = 1;
                int End_Y = 5;

                if (dic["iRow"] != "")
                    iRow = Convert.ToInt32(dic["iRow"]);

                End_Y = (iRow - 1) * (this.wReportBreaks.wBreakField_FPGrid.grid.Height / 6) + 8;

                   
                if (dic["BreakFields"] != "")
                {
                    _gLib._SetSyncUDWin("FPGrid", this.wReportBreaks.wBreakField_FPGrid.grid, "Click", 0, false, 80, End_Y );
                    string sChar = dic["BreakFields"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wReportBreaks.wBreakField_FPGrid.grid, sChar);
                    _gLib._SetSyncUDWin("BreakFields", this.wReportBreaks.wBreakField.cbo, dic["BreakFields"], 0);

                }


                if (dic["Remove"] != "")
                {
                                
                    try
                    {
                        _gLib._SetSyncUDWin("FPGrid", this.wReportBreaks.wBreakField_FPGrid.grid, "Click", 0, false, 80, End_Y);
                        _gLib._SetSyncUDWin("FPGrid", this.wReportBreaks.wBreakField_FPGrid.grid, "Click", 0, false, 80, End_Y);
                        Mouse.Click(this.wReportBreaks.wBreakField_FPGrid.grid, MouseButtons.Right, ModifierKeys.None, new Point(80, End_Y));
                    }
                    catch (Exception ex)
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to Right Click on Node Flow Tree. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right Click on Node Flow Tree. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    }
            
                    WinWindow wWin = new WinWindow();
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "DropDown");
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains);
                    wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);
          
                    MyDictionary dicTmp = new MyDictionary();
                    dicTmp.Clear();
                    dicTmp.Add("Level_1", "Remove");
                    _gLib._MenuSelectWin(0, wWin, dicTmp);

                }
               

                _gLib._SetSyncUDWin("TextSubstitution", this.wReportBreaks.wTextSubstitution.btn, dic["TextSubstitution"], 0);
                _gLib._SetSyncUDWin("OK", this.wReportBreaks.wOK.btn, dic["OK"], 0);


            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Dec-4
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("Reomve", "click");
        ///    pReportBreaks._BreakFieldTextSubstitution_SelectBreakFields(dic); 
        /// </summary>
        /// <param name="dic"></param>
        /// 
        public void _BreakFieldTextSubstitution_SelectBreakFields(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_ReportBreaks";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                int iRow = 1;

                if (dic["iRow"] != "")
                    iRow = Convert.ToInt32(dic["iRow"]);

                int End_Y = (iRow - 1) * (this.wBreakfieldtextsubstitution.wBreakFields.grid.Height / 6) + 8;


                _gLib._SetSyncUDWin("FPGrid", this.wBreakfieldtextsubstitution.wBreakFields.grid, "Click", 0, false, 80, End_Y);

                if (dic["Remove"] != "")
                {

                    try
                    {
                        Mouse.Click(this.wBreakfieldtextsubstitution.wBreakFields.grid, MouseButtons.Right, ModifierKeys.None, new Point(80, End_Y));
                    }
                    catch (Exception ex)
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to Right Click on Node Flow Tree. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right Click on Node Flow Tree. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    }

                    WinWindow wWin = new WinWindow();
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "DropDown");
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains);
                    wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

                    MyDictionary dicTmp = new MyDictionary();
                    dicTmp.Clear();
                    dicTmp.Add("Level_1", "Remove");
                    _gLib._MenuSelectWin(0, wWin, dicTmp);


                    if(_gLib._Exists("",this.wRemove.wOK.btn,0))
                       _gLib._SetSyncUDWin("wRemove", this.wRemove.wOK.btn, "Click", 0);

                }
               
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        
        
        }



        /// <summary>
        /// 2015-Dec-4
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("BreakFieldValue", "");
        ///    dic.Add("SubstitutionText", "");
        ///    dic.Add("Remove", "Click");
        ///    dic.Add("OK", "");
        ///    pReportBreaks._BreakFieldTextSubstitution_TextSubstitution(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _BreakFieldTextSubstitution_TextSubstitution(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ReportBreaks";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                int iRow = 1;
                string sRow = "";

                if (dic["iRow"] != "")
                    iRow = Convert.ToInt32(dic["iRow"]);

                for (int i = 2; i <= iRow; i ++ )
                    sRow = sRow + "{Down}";

                           
                if (dic["BreakFieldValue"] != "")
                {
               
                    _gLib._SetSyncUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution.grid, "Click", 0, false, 20, 25);
                    _gLib._SendKeysUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution.grid, "{PageUp}{PageUp}" + sRow, 0);

                    _gLib._SendKeysUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution.grid, dic["BreakFieldValue"], 0);
                    
                    _gLib._SendKeysUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution.grid, "{Enter}{PageUp}{PageUp}{Home}" + sRow, 0);

                    if(this._fp._ReturnSelectRowContent( this.wBreakfieldtextsubstitution.wTextSubstitution.grid) != dic["BreakFieldValue"])
                        _gLib._MsgBoxYesNo("","Function failed: The exception value is:  " + dic["BreakFieldValue"] + "but the actual value is: " + this._fp._ReturnSelectRowContent( this.wBreakfieldtextsubstitution.wTextSubstitution.grid));
                }


                if (dic["SubstitutionText"] != "")
                {
                    _gLib._SetSyncUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution.grid, "Click", 0, false, 20, 25);
                    _gLib._SendKeysUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution.grid, "{PageUp}{PageUp}{Home}" + sRow + "{Tab}", 0);

                    _gLib._SendKeysUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution.grid, dic["SubstitutionText"], 0);
                    
                    _gLib._SendKeysUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution.grid, "{Enter}{PageUp}{PageUp}{Home}" + sRow + "{Tab}", 0);

                    if (this._fp._ReturnSelectRowContent(this.wBreakfieldtextsubstitution.wTextSubstitution.grid) != dic["SubstitutionText"])
                        _gLib._MsgBoxYesNo("", "Function failed: The exception value is:  " + dic["SubstitutionText"] + "but the actual value is: " + this._fp._ReturnSelectRowContent(this.wBreakfieldtextsubstitution.wTextSubstitution.grid));
                }

                if (dic["Remove"] != "")
                {

                    _gLib._SetSyncUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution.grid, "Click", 0, false, 20, 25);
                    _gLib._SendKeysUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution.grid, "{PageUp}{PageUp}{Home}" + sRow , 0);
                   
                    try
                    {
                        Mouse.Click(this.wBreakfieldtextsubstitution.wTextSubstitution.grid, MouseButtons.Right, ModifierKeys.None, new Point(30, 30));
                    }
                    catch (Exception ex)
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to Right Click on Node Flow Tree. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right Click on Node Flow Tree. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    }

                    WinWindow wWin = new WinWindow();
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "DropDown");
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains);
                    wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

                    MyDictionary dicTmp = new MyDictionary();
                    dicTmp.Clear();
                    dicTmp.Add("Level_1", "Remove");
                    _gLib._MenuSelectWin(0, wWin, dicTmp);

                }

                _gLib._SetSyncUDWin("OK", this.wBreakfieldtextsubstitution.wOK.btn, dic["OK"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

    }
}
