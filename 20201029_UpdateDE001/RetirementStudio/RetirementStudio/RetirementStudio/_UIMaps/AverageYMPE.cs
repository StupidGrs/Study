namespace RetirementStudio._UIMaps.AverageYMPEClasses
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
    
    public partial class AverageYMPE
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "True");
        ///    dic.Add("ReadAverageYMPEFromData", "");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("YMPEDefinitionToAverage", "");
        ///    dic.Add("DataFieldContainAverageYMPE", "");
        ///    dic.Add("AveragingPeriod", "5");
        ///    dic.Add("IncludeExitYearInAverage", "True");
        ///    pAverageYMPE._PopVerify_AverageYMPE(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_AverageYMPE(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_AverageYMPE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._SetSyncUDWin("ReadAverageYMPEFromData", this.wRetirementStudio.wReadAverageYMPEFromData.rd, dic["ReadAverageYMPEFromData"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("YMPEDefinitionToAverage", this.wRetirementStudio.wYMPEDefinitionToAverage.cbo, dic["YMPEDefinitionToAverage"], 0);
                _gLib._SetSyncUDWin("DataFieldContainAverageYMPE", this.wRetirementStudio.wDataFieldContainAverageYMPE.cbo, dic["DataFieldContainAverageYMPE"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AveragingPeriod", this.wRetirementStudio.wAveragingPeriod.txt, dic["AveragingPeriod"], 0);
                _gLib._SetSyncUDWin("IncludeExitYearInAverage", this.wRetirementStudio.wIncludeExitYearInAverage.chk, dic["IncludeExitYearInAverage"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("ReadAverageYMPEFromData", this.wRetirementStudio.wReadAverageYMPEFromData.rd, dic["ReadAverageYMPEFromData"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("YMPEDefinitionToAverage", this.wRetirementStudio.wYMPEDefinitionToAverage.cbo, dic["YMPEDefinitionToAverage"], 0);
                _gLib._VerifySyncUDWin("DataFieldContainAverageYMPE", this.wRetirementStudio.wDataFieldContainAverageYMPE.cbo, dic["DataFieldContainAverageYMPE"], 0);
                _gLib._VerifySyncUDWin("AveragingPeriod", this.wRetirementStudio.wAveragingPeriod.txt, dic["AveragingPeriod"], 0);
                _gLib._VerifySyncUDWin("IncludeExitYearInAverage", this.wRetirementStudio.wIncludeExitYearInAverage.chk, dic["IncludeExitYearInAverage"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
