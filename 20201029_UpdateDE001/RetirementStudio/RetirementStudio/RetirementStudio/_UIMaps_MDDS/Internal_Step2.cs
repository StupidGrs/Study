namespace RetirementStudio._UIMaps_MDDS.Internal_Step2Classes
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
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System.Threading;
    using System.Windows.Forms;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;

    public partial class Internal_Step2
    {

        public MyDictionary dic = new MyDictionary();
        public GenericLib_Win _gLib = new GenericLib_Win();
        public GenericLib_Web _gLibWeb = new GenericLib_Web();


        public void _Debugging()
        {
            /////_gLibWeb._SetSyncUDWeb("", _gLibWeb._ReturnElement(_SearchType.HyperLink, _SearchBy.InnerText, "Administratio", 1, false), "", 0);
        }

        /// <summary>
        /// 2013-June-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("TeamAssignment", "Client Solutions");
        ///    dic.Add("Check", "True");
        ///    dic.Add("Submit", "");
        ///    pInternal_Step2._PopVerify_Internal_Step2(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Internal_Step2(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Internal_Step2";
            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            this.wInternal_Step2.pInternal_Step2.WaitForControlReady();
            _gLib._CaptureScreen_PopVerify(sFunctionName);

            if (dic["PopVerify"] == "Pop")
            {
                if (dic["TeamAssignment"]!="")
                    _gLibWeb._SetSyncUDWeb(dic["TeamAssignment"], _gLibWeb._ReturnElement(_SearchType.CheckBox, _SearchBy.LabeledBy, dic["TeamAssignment"], 1, true), dic["Check"], 0);
                _gLibWeb._SetSyncUDWeb("Submit", this.wInternal_Step2.pInternal_Step2.btnSubmit, dic["Submit"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLibWeb._VerifySyncUDWeb("Submit", this.wInternal_Step2.pInternal_Step2.btnSubmit, dic["Submit"], 0);

            }


            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
