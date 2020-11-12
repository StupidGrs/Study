namespace RetirementStudio._UIMaps.PBGCPlanTerminationDefinitionClasses
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
    using Accessibility;
    using RetirementStudio._ThridParty;
    using System.Threading;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;


    public partial class PBGCPlanTerminationDefinition
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        /// <summary>
        /// 2016-Jan-4
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SetToEarlistRetirementAge", "True");
        ///    dic.Add("UseHighMediumLowRetirement", "");
        ///    dic.Add("UseHighRetirement", "");
        ///    dic.Add("IgnoreForDeferredInactives", "");
        ///    pPBGCPlanTerminationDefinition._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("SetToEarlistRetirementAge", this.wRetirementStudio.wSetToEarliestRetirement.rd, dic["SetToEarlistRetirementAge"], 0);
                _gLib._SetSyncUDWin("UseHighMediumLowRetirement", this.wRetirementStudio.wUseHighMediumLowReti.rd, dic["UseHighMediumLowRetirement"], 0);
                _gLib._SetSyncUDWin("UseHighRetirement", this.wRetirementStudio.wUsehighRetirementrat.rd, dic["UseHighRetirement"], 0);
                _gLib._SetSyncUDWin("IgnoreForDeferredInactives", this.wRetirementStudio.wIgnorefordeferredina.chx, dic["IgnoreForDeferredInactives"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "Function is not complete");
            }

        }


        /// <summary>
        /// 2016-Jan-4
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("EarlistRetirementAge", "");
        ///    dic.Add("EarlistUnreducedRetirementAge", "");
        ///    dic.Add("ExpectedRetirementBenefit", "");
        ///    pPBGCPlanTerminationDefinition._UseHighMediumLowRetirement(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _UseHighMediumLowRetirement(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("EarlistRetirementAge", this.wRetirementStudio.wEarliestRetiremen.cbo, dic["EarlistRetirementAge"], 0);
                _gLib._SetSyncUDWin("EarlistUnreducedRetirementAge", this.wRetirementStudio.wEarliestUnreduced.cbo, dic["EarlistUnreducedRetirementAge"], 0);
                _gLib._SetSyncUDWin("ExpectedRetirementBenefit", this.wRetirementStudio.wExpectedRetiremen.cbo, dic["ExpectedRetirementBenefit"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "Function is not complete");
            }

        }

    }
}
