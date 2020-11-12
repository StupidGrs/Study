namespace RetirementStudio._UIMaps.PayIncreaseClasses
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



    public partial class PayIncrease
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
        ///    dic.Add("Adjustment", "");
        ///    dic.Add("btnV", "");
        ///    dic.Add("btnPercent", "");
        ///    dic.Add("btnT", "");
        ///    dic.Add("txtRate", "");
        ///    dic.Add("cboRate", "");
        ///    dic.Add("cboRate_T", "");
        ///    pPayIncrease._PopVerify_PayIncrease(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PayIncrease(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PayIncrease";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Adjustment", this.wRetirementStudio.wAdjustments.chkAdjustments, dic["Adjustment"], 0);
                _gLib._SetSyncUDWin("btnV", this.wRetirementStudio.wVIcon.btnV, dic["btnV"], 0);
                _gLib._SetSyncUDWin("btnPercent", this.wRetirementStudio.wPercentIcon.btnPercent, dic["btnPercent"], 0);
                _gLib._SetSyncUDWin("btnT", this.wRetirementStudio.wTIcon.btnT, dic["btnT"], 0);
                _gLib._SetSyncUDWin_ByClipboard("txtRate", this.wRetirementStudio.wRate_txt.txtRate, dic["txtRate"], true, 0);
                _gLib._SetSyncUDWin("cboRate", this.wRetirementStudio.wRate_cbo.cboRate, dic["cboRate"], 0);
                _gLib._SetSyncUDWin("cboRate_T", this.wRetirementStudio.wRate_cbo_T.cbo, dic["cboRate_T"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Adjustment", this.wRetirementStudio.wAdjustments.chkAdjustments, dic["Adjustment"], 0);
                _gLib._VerifySyncUDWin("btnV", this.wRetirementStudio.wVIcon.btnV, dic["btnV"], 0);
                _gLib._VerifySyncUDWin("btnPercent", this.wRetirementStudio.wPercentIcon.btnPercent, dic["btnPercent"], 0);
                _gLib._VerifySyncUDWin("btnT", this.wRetirementStudio.wTIcon.btnT, dic["btnT"], 0);
                _gLib._VerifySyncUDWin("txtRate", this.wRetirementStudio.wRate_txt.txtRate, dic["txtRate"], 0);
                _gLib._VerifySyncUDWin("cboRate", this.wRetirementStudio.wRate_cbo.cboRate, dic["cboRate"], 0);
                _gLib._VerifySyncUDWin("cboRate_T", this.wRetirementStudio.wRate_cbo_T.cbo, dic["cboRate_T"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-July-31 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Adjustment", "");
        ///    dic.Add("btnV", "");
        ///    dic.Add("btnPercent", "");
        ///    dic.Add("btnT", "");
        ///    dic.Add("txtRate", "");
        ///    dic.Add("cboRate", "");
        ///    dic.Add("Adjustment1_P", "");
        ///    dic.Add("Adjustment1_txt_P", "");
        ///    pPayIncrease._PopVerify_Adjustment(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Adjustment(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Adjustment";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iAdjustment1_txt_P = 1;

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Adjustment", this.wRetirementStudio.wAdjustments.chkAdjustments, dic["Adjustment"], 0);
                _gLib._SetSyncUDWin("btnV", this.wRetirementStudio.wVIcon.btnV, dic["btnV"], 0);
                _gLib._SetSyncUDWin("btnPercent", this.wRetirementStudio.wPercentIcon.btnPercent, dic["btnPercent"], 0);
                _gLib._SetSyncUDWin("btnT", this.wRetirementStudio.wTIcon.btnT, dic["btnT"], 0);
                _gLib._SetSyncUDWin_ByClipboard("txtRate", this.wRetirementStudio.wRate_txt.txtRate, dic["txtRate"], true, 0);
                _gLib._SetSyncUDWin("cboRate", this.wRetirementStudio.wRate_cbo.cboRate, dic["cboRate"], 0);


                _gLib._SetSyncUDWin("Adjustment1_P", this.wRetirementStudio.wAdjustment1_P.btn, dic["Adjustment1_P"], 0);
                if (dic["btnPercent"] != "")
                    iAdjustment1_txt_P = 2;
                this.wRetirementStudio.wRate_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iAdjustment1_txt_P.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Adjustment1_txt_P", this.wRetirementStudio.wRate_txt.txtRate, dic["Adjustment1_txt_P"], 0);
                                
            }
                
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-May-25
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("NumberOfYears", "10");
        ///    dic.Add("Rate", "4.75");
        ///    pPayIncrease._TimeBased_Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _TimeBased_Table(MyDictionary dic)
        {
            string sFunctionName = "_TimeBased_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wTimeBased_Table.grid, "Click", 0, false, 94, 28);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTimeBased_Table.grid, "{PageUp}{PageUp}{Home}");
        
            
            int iRow = Convert.ToInt32(dic["iRow"]);
            string sRow = "";
            for (int i = 1; i < iRow; i++)
                sRow = sRow + "{Down}";

            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTimeBased_Table.grid, sRow , 0);


            if (dic["NumberOfYears"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTimeBased_Table.grid,  "{space}", 0);

                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": NumberOfYears", this.wRetirementStudio.wCom_Edit.txt.UICtlNumEditorEdit1, dic["NumberOfYears"], 0);
            }


            if (dic["Rate"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTimeBased_Table.grid,   "{Tab}{space}", 0);

                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": Rate", this.wRetirementStudio.wCom_Edit.txt.UICtlNumEditorEdit1, dic["Rate"], 0);
              
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
