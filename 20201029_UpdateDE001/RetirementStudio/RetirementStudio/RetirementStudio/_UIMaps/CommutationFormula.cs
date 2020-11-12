namespace RetirementStudio._UIMaps.CommutationFormulaClasses
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

    public partial class CommutationFormula
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2016-Jan-28 
        ///   ruiyang.song@mercer.com
        /// 
        /// sample:
        ///   
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PercnetOfPension", "");
        ///    dic.Add("LumpSumIs", "");
        ///    pCommutationFormula._Main(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _Main(MyDictionary dic)
        {
            string sFunctionName = "_TreeView_SelectTab";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("PercnetOfPension", this.wRetirementStudio.wPOfpension.rd, dic["PercnetOfPension"], 0);
                _gLib._SetSyncUDWin_ByClipboard("LumpSumIs", this.wRetirementStudio.wLumpSumIs.txt.UINudPercentAmountEdit1, dic["LumpSumIs"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
