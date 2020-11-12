namespace RetirementStudio._UIMaps.CommunicationFactorsClasses
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
    
    public partial class CommunicationFactors
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();



        /// <summary>
        /// 2015-June-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Male_C", "");
        ///    dic.Add("Male_T", "");
        ///    dic.Add("Male_C_txt", "");
        ///    dic.Add("Male_T_cbo", "");
        ///    dic.Add("Female_C", "");
        ///    dic.Add("Female_T", "");
        ///    dic.Add("Female_C_txt", "");
        ///    dic.Add("Female_T_cbo", "");
        ///    pCommunicationFactors._PopVerify_CommunicationFactors(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CommunicationFactors(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_CommunicationFactors";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iTxt_C = 0;
            int iCbo_T = 0;



            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Male_C", this.wRetirementStudio.wMale_C.btn, dic["Male_C"], 0);
                _gLib._SetSyncUDWin("Male_T", this.wRetirementStudio.wMale_T.btn, dic["Male_T"], 0);

                if (dic["Male_C"] != "") iTxt_C++;
                this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_C.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Male_C_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["Male_C_txt"], 0);

                if (dic["Male_T"] != "") iCbo_T++;
                this.wRetirementStudio.wCommon_cbo_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_T.ToString());
                _gLib._SetSyncUDWin("Male_T_cbo", this.wRetirementStudio.wCommon_cbo_T.cbo, dic["Male_T_cbo"], 0);


                _gLib._SetSyncUDWin("Female_C", this.wRetirementStudio.wFemale_C.btn, dic["Female_C"], 0);
                _gLib._SetSyncUDWin("Female_T", this.wRetirementStudio.wFemale_T.btn, dic["Female_T"], 0);

                if (dic["Female_C"] != "") iTxt_C++;
                this.wRetirementStudio.wCommon_txt_C.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_C.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Female_C_txt", this.wRetirementStudio.wCommon_txt_C.txt, dic["Female_C_txt"], 0);

                if (dic["Female_T"] != "") iCbo_T++;
                this.wRetirementStudio.wCommon_cbo_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_T.ToString());
                _gLib._SetSyncUDWin("Female_T_cbo", this.wRetirementStudio.wCommon_cbo_T.cbo, dic["Female_T_cbo"], 0);




            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._MsgBox("", "No Verify functin here!");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
