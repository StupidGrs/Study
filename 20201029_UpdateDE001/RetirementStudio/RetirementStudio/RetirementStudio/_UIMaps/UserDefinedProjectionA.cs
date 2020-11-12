namespace RetirementStudio._UIMaps.UserDefinedProjectionAClasses
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
    
    
    public partial class UserDefinedProjectionA
    {
        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2015-July-01
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "True");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("Amount_V", "");
        ///    dic.Add("Amount_C", "");
        ///    dic.Add("Amount_cbo", "");
        ///    dic.Add("Amount_txt", "");
        ///    dic.Add("Rate_V", "");
        ///    dic.Add("Rate_P", "");
        ///    dic.Add("Rate_cbo", "");
        ///    dic.Add("Rate_txt", "");
        ///    dic.Add("ProjectValuesForPastAges", "");
        ///    pUserDefinedProjectionA._PopVerify_Standard(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FromData";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._SetSyncUDWin("FromData", this.wRetirementStudio.wCustomCode.rd, dic["FromData"], 0);

                _gLib._SetSyncUDWin("Amount_V", this.wRetirementStudio.wAmount_V.btn, dic["Amount_V"], 0);
                _gLib._SetSyncUDWin("Amount_C", this.wRetirementStudio.wAmount_C.btn, dic["Amount_C"], 0);

                _gLib._SetSyncUDWin("Rate_V", this.wRetirementStudio.wRate_V.btn, dic["Rate_V"], 0);
                _gLib._SetSyncUDWin("Rate_P", this.wRetirementStudio.wRate_P.btn, dic["Rate_P"], 0);


                if (dic["Amount_V"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                    _gLib._SetSyncUDWin("Amount_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Amount_cbo"], 0);
                }
                _gLib._SetSyncUDWin_ByClipboard("Amount_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["Amount_txt"], 0);


                if (dic["Rate_V"] != "")
                {
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, "1");
                    _gLib._SetSyncUDWin("Rate_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Rate_cbo"], 0);
                }
                _gLib._SetSyncUDWin_ByClipboard("Rate_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["Rate_txt"], 0);

                _gLib._SetSyncUDWin("ProjectValuesForPastAges", this.wRetirementStudio.wProjectValuesForPastAges.chk, dic["ProjectValuesForPastAges"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("Warning", "No Verify function here!");


            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
