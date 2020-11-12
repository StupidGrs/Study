namespace RetirementStudio._UIMaps.ContractualRetirementAgeClasses
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
    
    public partial class ContractualRetirementAge
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2015-Apr-1
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("FixedAge_V", "Click");
        ///    dic.Add("FixedAge_C", "");
        ///    dic.Add("FixedAge_cbo", "ContractualRetAge");
        ///    dic.Add("FixedAge_txt", "");
        ///    dic.Add("Regelaltersgrenze", "");
        ///    pContractualRetirementAge._PopVerify_ContractualRetirementAge(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ContractualRetirementAge(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ContractualRetirementAge";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("FixedAge_V", this.wRetirementStudio.wFixedAge_V.btn, dic["FixedAge_V"], 0);
                _gLib._SetSyncUDWin("FixedAge_C", this.wRetirementStudio.wFixedAge_C.btn, dic["FixedAge_C"], 0);
                _gLib._SetSyncUDWin("FixedAge_cbo", this.wRetirementStudio.wFixedAge_cbo.cbo, dic["FixedAge_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FixedAge_txt", this.wRetirementStudio.wFixedAge_txt.txt, dic["FixedAge_txt"], 0);
                _gLib._SetSyncUDWin("Regelaltersgrenze", this.wRetirementStudio.wRegelaltersgrenzeno.rd, dic["Regelaltersgrenze"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("FixedAge_V", this.wRetirementStudio.wFixedAge_V.btn, dic["FixedAge_V"], 0);
                _gLib._VerifySyncUDWin("FixedAge_C", this.wRetirementStudio.wFixedAge_C, dic["FixedAge_C"], 0);
                _gLib._VerifySyncUDWin("FixedAge_cbo", this.wRetirementStudio.wFixedAge_cbo.cbo, dic["FixedAge_cbo"], 0);
                _gLib._VerifySyncUDWin("FixedAge_txt", this.wRetirementStudio.wFixedAge_txt.txt, dic["FixedAge_txt"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
