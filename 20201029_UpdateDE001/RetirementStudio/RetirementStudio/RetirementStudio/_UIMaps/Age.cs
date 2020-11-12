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


namespace RetirementStudio._UIMaps.AgeClasses
{
  
        public partial class Age
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        /// <summary>
        /// 2016-Jan-19
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ValuationMonthAndDay", "");
        ///    dic.Add("OtherDate", "");
        ///    dic.Add("AgeRoundingRule", "");
        ///    pAge._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ValuationMonthAndDay", this.wRetirementStudio.wValuationmonthandday.rd, dic["ValuationMonthAndDay"], 0);
                _gLib._SetSyncUDWin("OtherDate", this.wRetirementStudio.wOtherdate.rd, dic["OtherDate"], 0);
                _gLib._SetSyncUDWin("AgeRoundingRule", this.wRetirementStudio.wAgeRoundingRule.cbo, dic["AgeRoundingRule"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", " function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
