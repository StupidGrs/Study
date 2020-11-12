namespace RetirementStudio._UIMaps.SpecialEligibilitiesClasses
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
    

    
    public partial class SpecialEligibilities
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();



        /// <summary>
        /// 2013-Dec-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Simple", "");
        ///    dic.Add("Advanced", "True");
        ///    dic.Add("Simple_PreDefinedEligibility", "");
        ///    dic.Add("Advance_txtBox", "");
        ///    dic.Add("Advance_Validate", "");
        ///    pSpecialEligibilities._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Simple", this.wRetirementStudio.wSimple.rdSimple, dic["Simple"], 0);
                _gLib._SetSyncUDWin("Advanced", this.wRetirementStudio.wAdvanced.rdAdvanced, dic["Advanced"], 0);
                _gLib._SetSyncUDWin("Simple_PreDefinedEligibility", this.wRetirementStudio.wPreDef_Elig.cbo, dic["Simple_PreDefinedEligibility"], 0);
                _gLib._SetSyncUDWin("Advance_txtBox", this.wRetirementStudio.wAdvance_TextBox.txt, dic["Advance_txtBox"], 0);
                _gLib._SetSyncUDWin("Advance_Validate", this.wRetirementStudio.wValidate.btn, dic["Advance_Validate"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Simple", this.wRetirementStudio.wSimple.rdSimple, dic["Simple"], 0);
                _gLib._VerifySyncUDWin("Advanced", this.wRetirementStudio.wAdvanced.rdAdvanced, dic["Advanced"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }



}
