namespace RetirementStudio._UIMaps.DefinedBenefitLimitIncreaseClasses
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
    
    public partial class DefinedBenefitLimitIncrease
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2014-Feb-15
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("V", "");
        ///    dic.Add("Percent", "");
        ///    dic.Add("T", "");
        ///    dic.Add("txtRate", "");
        ///    pDefinedBenefitLimitIncrease._PopVerify_DefinedBenefitLimitIncrease(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DefinedBenefitLimitIncrease(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_DefinedBenefitLimitIncrease";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                 _gLib._SetSyncUDWin("V", this.wRetirementStudio.wV.btn, dic["V"], 0);
                 _gLib._SetSyncUDWin("Percent", this.wRetirementStudio.wPercent.btn, dic["Percent"], 0);
                _gLib._SetSyncUDWin("T", this.wRetirementStudio.wT.btn, dic["T"], 0);
                _gLib._SetSyncUDWin_ByClipboard("txtRate", this.wRetirementStudio.wRate_txt.txt, dic["txtRate"], true, 0);
                
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("V", this.wRetirementStudio.wV.btn, dic["V"], 0);
                _gLib._VerifySyncUDWin("Percent", this.wRetirementStudio.wPercent.btn, dic["Percent"], 0);
                _gLib._VerifySyncUDWin("T", this.wRetirementStudio.wT.btn, dic["T"], 0);
                _gLib._VerifySyncUDWin("txtRate", this.wRetirementStudio.wRate_txt.txt, dic["txtRate"],  0);
                
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }


}
