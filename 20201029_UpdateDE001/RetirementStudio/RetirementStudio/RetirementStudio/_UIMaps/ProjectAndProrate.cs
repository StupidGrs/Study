namespace RetirementStudio._UIMaps.ProjectAndProrateClasses
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
    
    
    public partial class ProjectAndProrate
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
        ///    dic.Add("ServiceForProration", "");
        ///    dic.Add("ServiceSelectionForProration", "");
        ///    pProjectAndProrate._PopVerify_ProjectAndProrate(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ProjectAndProrate(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ProjectAndProrate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("ServiceForProration", this.wRetirementStudio.wServiceForProration.cbo, dic["ServiceForProration"], 0);
                _gLib._SetSyncUDWin("ServiceSelectionForProration", this.wRetirementStudio.wServiceSelectionForProration.cbo, dic["ServiceSelectionForProration"], 0);
           
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("ServiceForProration", this.wRetirementStudio.wServiceForProration.cbo, dic["ServiceForProration"], 0);
                _gLib._VerifySyncUDWin("ServiceSelectionForProration", this.wRetirementStudio.wServiceSelectionForProration.cbo, dic["ServiceSelectionForProration"], 0);
           
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
