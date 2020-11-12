namespace RetirementStudio._UIMaps.FarPointClasses
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
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;

    using Accessibility;
    using System.Threading;
    using System.Windows.Forms;
    using RetirementStudio._Libraries;
    using RetirementStudio._Config;
    
    public partial class FarPoint
    {
        private int iClick_X_Offset = 5;
        private int iClick_Y_Offset = 5;
        private GenericLib_Win _gLib = new GenericLib_Win();


        public void _Debugging()
        {

            var b = 1;
        }

        public void _ClickFirstRow(object fpObj, int xPos, int yPos)
        {
            string sFunctionName = "_ClickFirstRow";

            if (xPos == 0)
                xPos = iClick_X_Offset;
            if (yPos == 0)
                yPos = iClick_Y_Offset;

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts by clicking position: x=" + xPos + ", y=" + yPos);

            _gLib._SetSyncUDWin("FP Grid", (WinClient)fpObj, "Click", 0, false, xPos, yPos);
            ////Mouse.Click((WinClient)fpObj, new Point(xPos, yPos));

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        public string _ReturnSelectRowContent(object fpObj)
        {

            string sFunctionName = "_ReturnSelectRowContent";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            string sContent = "";

            try
            {
                string[] sl = this._ReturnAccDesp(fpObj).Split(",".ToCharArray(), System.StringSplitOptions.None);

                sContent = sl[4].TrimStart(' ').TrimEnd(' ');
            }
            catch (Exception ex)
            {
                _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to get Text info from FarPoint object, Because exception threw out: " + Environment.NewLine + ex.Message);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to get Text info from FarPoint object, Because exception threw out: " + Environment.NewLine + ex.Message);

            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends by returning:" + sContent);

            return sContent;

        }


        public string _ReturnSelectRowContentByClipboard(object fpObj)
        {

            string sFunctionName = "_ReturnSelectRowContent";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            string sContent = "";
            Clipboard.Clear();
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "C", ModifierKeys.Control);
            _gLib._SendKeysUDWin("FPGrid", fpObj, "C", 0, ModifierKeys.Control, false);
            sContent = Clipboard.GetText();

            return sContent;

        }


        public int _ReturnSelectRowIndex(object fpObj)
        {
            string sFunctionName = "_ReturnSelectRowIndex";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int index = 0;
            try
            {
                string[] sl = this._ReturnAccDesp(fpObj).Split(",".ToCharArray(), System.StringSplitOptions.None);

                //index = Convert.ToInt32(sl[2].Substring(sl[2].Length - 1, 1));
                index = Convert.ToInt32(sl[2].Split(" ".ToCharArray(), System.StringSplitOptions.None)[2]);
            }
            catch (Exception ex)
            {
                _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to get Selected Row Index  from FarPoint object, Because exception threw out: " + Environment.NewLine + ex.Message);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to get Selected Row Index  from FarPoint object, Because exception threw out: " + Environment.NewLine + ex.Message);

            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends by returning row index:" + index);

            return index;

        }


        public int _ReturnSelectColIndex(object fpObj)
        {
            string sFunctionName = "_ReturnSelectColIndex";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int index = 0;
            try
            {
                string[] sl = this._ReturnAccDesp(fpObj).Split(",".ToCharArray(), System.StringSplitOptions.None);

                //index = Convert.ToInt32(sl[3].Substring(sl[3].Length - 1, 1));
                index = Convert.ToInt32(sl[3].Split(" ".ToCharArray(), System.StringSplitOptions.None)[2]);
            }
            catch (Exception ex)
            {
                _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to get Selected Column Index  from FarPoint object, Because exception threw out: " + Environment.NewLine + ex.Message);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to get Selected Column Index  from FarPoint object, Because exception threw out: " + Environment.NewLine + ex.Message);
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends by returning col index:" + index);

            return index;

        }


        public Boolean _Navigate(object fpObj, string sLabelName, int iSearchMax)
        {
            string sFunctionName = "_Navigate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Boolean bFind = false;
            string sCurrentLabel = "";

            if (iSearchMax == 0)
                iSearchMax = 100;

            for (int i = 1; i <= iSearchMax; i++)
            {
                sCurrentLabel = this._ReturnSelectRowContent(fpObj);
                if (sCurrentLabel == sLabelName)
                {
                    bFind = true;
                    break;
                }
                else
                    Keyboard.SendKeys((WinClient)fpObj, "{Down}");
            }

            if (bFind)
                _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully navigate to :" + sLabelName);
            else
            {
                _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> Failed to navigate to :" + sLabelName + "or reach to Maximum search range: " + iSearchMax);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Failed to navigate to :" + sLabelName + "  or reach to Maximum search range: " + iSearchMax);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends");

            return bFind;

        }


        private string _ReturnAccDesp(object fpObj)
        {
            string sFunctionName = "_Navigate";

            try
            {
                object[] native = ((WinClient)fpObj).NativeElement as object[];

                IAccessible a = native[0] as IAccessible;
                return a.accDescription;
            }
            catch (Exception ex)
            {
                _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to get Selected Column Index  from FarPoint object, Because exception threw out: " + Environment.NewLine + ex.Message);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to get Selected Column Index  from FarPoint object, Because exception threw out: " + Environment.NewLine + ex.Message);
            }

            return "#Error";
        }










    }

    


}
