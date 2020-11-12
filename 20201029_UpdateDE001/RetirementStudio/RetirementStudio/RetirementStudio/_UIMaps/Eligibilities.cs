namespace RetirementStudio._UIMaps.EligibilitiesClasses
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


    public partial class Eligibilities
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FreezeAtValuationAge", "");
        ///    dic.Add("Formula", "$Age>= 65");
        ///    dic.Add("Validate", "Click");
        ///    pEligibilities._PopVerify_Eligibilities(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Eligibilities(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PayIncrease";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            
            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("FreezeAtValuationAge", this.wRetirementStudio.wFreezeAtValuationAge.chk, dic["FreezeAtValuationAge"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Formula", this.wRetirementStudio.wFormula.txtFormula, dic["Formula"], 0);
                _gLib._SetSyncUDWin("Validate", this.wRetirementStudio.wValidate.btnValidate, dic["Validate"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("FreezeAtValuationAge", this.wRetirementStudio.wFreezeAtValuationAge.chk, dic["FreezeAtValuationAge"], 0);
                _gLib._VerifySyncUDWin("Formula", this.wRetirementStudio.wFormula.txtFormula, dic["Formula"], 0);
                _gLib._VerifySyncUDWin("Validate", this.wRetirementStudio.wValidate.btnValidate, dic["Validate"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
