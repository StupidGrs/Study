namespace RetirementStudio._UIMaps.AdjustmentsClasses
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
    
    
    public partial class Adjustments
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2013-Dec-23
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("LoadingFactor_V", "");
        ///    dic.Add("LoadingFactor_C", "Click");
        ///    dic.Add("LoadingFactor_T", "");
        ///    dic.Add("LoadingFactor_cboV", "");
        ///    dic.Add("LoadingFactor_txt", "1.05");
        ///    dic.Add("LoadingFactor_cboT", "");
        ///    dic.Add("ApplyTo", "Benefit after 415 application");
        ///    pAdjustments._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("LoadingFactor_V", this.wRetirementStudio.wLoadingFactor_V.btnV, dic["LoadingFactor_V"], 0);
                _gLib._SetSyncUDWin("LoadingFactor_C", this.wRetirementStudio.wLoadingFactor_C.btnC, dic["LoadingFactor_C"], 0);
                _gLib._SetSyncUDWin("LoadingFactor_T", this.wRetirementStudio.wLoadingFactor_T.btnT, dic["LoadingFactor_T"], 0);
                _gLib._SetSyncUDWin("LoadingFactor_cboV", this.wRetirementStudio.wLoadingFactor_cboV.cbo, dic["LoadingFactor_cboV"], 0);
                _gLib._SetSyncUDWin_ByClipboard("LoadingFactor_txt", this.wRetirementStudio.wLoadingFactor_txt.txtEdit.txt, dic["LoadingFactor_txt"], 0);
                _gLib._SetSyncUDWin("LoadingFactor_cboT", this.wRetirementStudio.wLoadingFactor_cboT.cbo, dic["LoadingFactor_cboT"], 0);
                _gLib._SetSyncUDWin("ApplyTo", this.wRetirementStudio.wApplyTo.cboApplyTo, dic["ApplyTo"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("LoadingFactor_V", this.wRetirementStudio.wLoadingFactor_V.btnV, dic["LoadingFactor_V"], 0);
                _gLib._VerifySyncUDWin("LoadingFactor_C", this.wRetirementStudio.wLoadingFactor_C.btnC, dic["LoadingFactor_C"], 0);
                _gLib._VerifySyncUDWin("LoadingFactor_T", this.wRetirementStudio.wLoadingFactor_T.btnT, dic["LoadingFactor_T"], 0);
                _gLib._VerifySyncUDWin("LoadingFactor_cboV", this.wRetirementStudio.wLoadingFactor_cboV.cbo, dic["LoadingFactor_cboV"], 0);
                _gLib._VerifySyncUDWin("LoadingFactor_txt", this.wRetirementStudio.wLoadingFactor_txt.txtEdit.txt, dic["LoadingFactor_txt"], 0);
                _gLib._VerifySyncUDWin("LoadingFactor_cboT", this.wRetirementStudio.wLoadingFactor_cboT.cbo, dic["LoadingFactor_cboT"], 0);
                _gLib._SetSyncUDWin("ApplyTo", this.wRetirementStudio.wApplyTo.cboApplyTo, dic["ApplyTo"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




    }
}
