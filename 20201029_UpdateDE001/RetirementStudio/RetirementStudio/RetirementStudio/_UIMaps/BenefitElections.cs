namespace RetirementStudio._UIMaps.BenefitElectionsClasses
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

    
    
    public partial class BenefitElections
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        /// <summary>
        /// 2013-Sep-21
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Button_V", "");
        ///    dic.Add("Button_Percent", "");
        ///    dic.Add("Button_T", "");
        ///    dic.Add("ElectionPercentage_cbo", "");
        ///    dic.Add("ElectionPercentage_txt", "70.0");
        ///    dic.Add("ElectionTable_cbo", "");
        ///    dic.Add("Adjustment", "true");
        ///    dic.Add("Adjustment1_cbo", "");
        ///    dic.Add("Adjustment_P", "");
        ///    dic.Add("Adjustment_P_txt", "");
        ///    pBenefitElections._PopVerify_BenefitElections(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_BenefitElections(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_BenefitElections";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Button_V", this.wRetirementStudio.wButton_V.btnV, dic["Button_V"], 0);
                _gLib._SetSyncUDWin("Button_Percent", this.wRetirementStudio.wButton_Percent.btnPercent, dic["Button_Percent"], 0);
                _gLib._SetSyncUDWin("Button_T", this.wRetirementStudio.wButton_T.btnT, dic["Button_T"], 0);
                _gLib._SetSyncUDWin("ElectionPercentage_cbo", this.wRetirementStudio.wElectionPercentage_cbo.cbo, dic["ElectionPercentage_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ElectionPercentage_txt", this.wRetirementStudio.wElectionPercentage_txt.txt, dic["ElectionPercentage_txt"], 0);
                _gLib._SetSyncUDWin("ElectionTable_cbo", this.wRetirementStudio.wElectionTable_cbo.cbo, dic["ElectionTable_cbo"], 0);

                _gLib._SetSyncUDWin("Adjustment", this.wRetirementStudio.wAdjustments.chk, dic["Adjustment"], 0);
                _gLib._SetSyncUDWin("Adjustment1_cbo", this.wRetirementStudio.wAdjustment1Operat.cbo, dic["Adjustment1_cbo"], 0);
                _gLib._SetSyncUDWin("Adjustment_P", this.wRetirementStudio.wAdjustment1_P.btn, dic["Adjustment_P"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Adjustment_P_txt", this.wRetirementStudio.wComm_P_txt.txt, dic["Adjustment_P_txt"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Button_V", this.wRetirementStudio.wButton_V.btnV, dic["Button_V"], 0);
                _gLib._VerifySyncUDWin("Button_Percent", this.wRetirementStudio.wButton_Percent.btnPercent, dic["Button_Percent"], 0);
                _gLib._VerifySyncUDWin("Button_T", this.wRetirementStudio.wButton_T.btnT, dic["Button_T"], 0);
                _gLib._VerifySyncUDWin("ElectionPercentage_cbo", this.wRetirementStudio.wElectionPercentage_cbo.cbo, dic["ElectionPercentage_cbo"], 0);
                _gLib._VerifySyncUDWin("ElectionPercentage_txt", this.wRetirementStudio.wElectionPercentage_txt.txt, dic["ElectionPercentage_txt"], 0);
                _gLib._VerifySyncUDWin("ElectionTable_cbo", this.wRetirementStudio.wElectionTable_cbo.cbo, dic["ElectionTable_cbo"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
