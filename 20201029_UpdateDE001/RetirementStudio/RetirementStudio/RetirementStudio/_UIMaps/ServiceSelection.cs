namespace RetirementStudio._UIMaps.ServiceSelectionClasses
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
    
    
    public partial class ServiceSelection
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2015-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("BaseServiceProjection", "");
        ///    dic.Add("V", "");
        ///    dic.Add("C", "");
        ///    dic.Add("SelectServiceAtAge_cbo", "");
        ///    dic.Add("SelectServiceAtAge_txt", "");
        ///    pServiceSelection._PopVerify_ServiceSelection(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ServiceSelection(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ServiceSelection";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("BaseServiceProjection", this.wRetirementStudio.wBaseServiceProjection.cbo, dic["BaseServiceProjection"], 0);
                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wV.btn, dic["V"], 0);
                _gLib._SetSyncUDWin("C", this.wRetirementStudio.wC.btn, dic["C"], 0);
                _gLib._SetSyncUDWin("SelectServiceAtAge_cbo", this.wRetirementStudio.wSelectServiceAtAge_cbo.cbo, dic["SelectServiceAtAge_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SelectServiceAtAge_txt", this.wRetirementStudio.wSelectServiceAtAge_txt.txt, dic["SelectServiceAtAge_txt"], 0);
           
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("BaseServiceProjection", this.wRetirementStudio.wBaseServiceProjection.cbo, dic["BaseServiceProjection"], 0);
                _gLib._VerifySyncUDWin("V", this.wRetirementStudio.wV.btn, dic["V"], 0);
                _gLib._VerifySyncUDWin("C", this.wRetirementStudio.wC.btn, dic["C"], 0);
                _gLib._VerifySyncUDWin("SelectServiceAtAge_cbo", this.wRetirementStudio.wSelectServiceAtAge_cbo.cbo, dic["SelectServiceAtAge_cbo"], 0);
                _gLib._VerifySyncUDWin("SelectServiceAtAge_txt", this.wRetirementStudio.wSelectServiceAtAge_txt.txt, dic["SelectServiceAtAge_txt"], 0);
           
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
