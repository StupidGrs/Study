namespace RetirementStudio._UIMaps.CashBalanceClasses
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

    using Accessibility;
    using RetirementStudio._ThridParty;


    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    
    
    
    public partial class CashBalance
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();




        /// <summary>
        /// 2015-Aug-28
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SimpleLinearization", "");
        ///    dic.Add("LinearizationWithBreakpoint", "");
        ///    dic.Add("HistoricalValuations", "");
        ///    dic.Add("CustomCode", "");
        ///    pCashBalance._Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("SimpleLinearization", this.wRetirementStudio.wSimplelinearizationWindow.UISimplelinearizationRadioButton, dic["SimpleLinearization"], 0);
                _gLib._SetSyncUDWin("LinearizationWithBreakpoint", this.wRetirementStudio.wLinearizationwithbre.rd, dic["LinearizationWithBreakpoint"], 0);
                _gLib._SetSyncUDWin("HistoricalValuations", this.wRetirementStudio.wHistoricalvaluesWindow.UIHistoricalvaluesRadioButton, dic["HistoricalValuations"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomcodeWindow.UICustomcodeRadioButton, dic["CustomCode"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
              
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Aug-28
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("StartingBalance", "");
        ///    dic.Add("PayCredits", "");
        ///    dic.Add("FreezePayCreditsAtAge_txt", "");
        ///    dic.Add("RateOnBalanceIsDiffer", "");
        ///    pCashBalance._PopVerify_Standard(dic); 

        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("StartingBalance", this.wRetirementStudio.wStartingBalance.cbo, dic["StartingBalance"], 0);
                _gLib._SetSyncUDWin("PayCredits", this.wRetirementStudio.wPayCredits.cbo, dic["PayCredits"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FreezePayCreditsAtAge_txt", this.wRetirementStudio.wFreezePayCreditsAtAge_TXT.txtFreezePayCreditsAtAge.txt, dic["FreezePayCreditsAtAge_txt"], true, 0);
                _gLib._SetSyncUDWin("RateOnBalanceIsDiffer", this.wRetirementStudio.wRateOnBalancesIsDiffer.rdRateOnBalancesIsDiffer, dic["RateOnBalanceIsDiffer"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("StartingBalance", this.wRetirementStudio.wStartingBalance.cbo, dic["StartingBalance"], 0);
                _gLib._VerifySyncUDWin("PayCredits", this.wRetirementStudio.wPayCredits.cbo, dic["PayCredits"], 0);
                _gLib._VerifySyncUDWin("FreezePayCreditsAtAge_txt", this.wRetirementStudio.wFreezePayCreditsAtAge_TXT.txtFreezePayCreditsAtAge.txt, dic["FreezePayCreditsAtAge_txt"], 0);
                _gLib._VerifySyncUDWin("RateOnBalanceIsDiffer", this.wRetirementStudio.wRateOnBalancesIsDiffer.rdRateOnBalancesIsDiffer, dic["RateOnBalanceIsDiffer"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Jan-5
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AccountBalance", "");
        ///    dic.Add("PriodYear", "");
        ///    dic.Add("BreakPoint_C", "");
        ///    dic.Add("BreakPoint_txt", "");
        ///    dic.Add("BreakPointAge", "");
        ///    dic.Add("PayCredits_PayCredits", "");
        ///    dic.Add("InterestCredit_RateOnBalance_TheSame", "");
        ///    dic.Add("InterestCredit_RateOnBalance_Difference", "");
        ///    pCashBalance._LinearizationWithBreakpoint(dic); 

        /// </summary>
        /// <param name="dic"></param>
        public void _LinearizationWithBreakpoint(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("AccountBalance", this.wRetirementStudio.wAccountBalance.cbo, dic["AccountBalance"], 0);
                _gLib._SetSyncUDWin("PriodYear", this.wRetirementStudio.wPriorYear.rd, dic["PriodYear"], 0);
                _gLib._SetSyncUDWin("BreakPoint_C", this.wRetirementStudio.wButton_C.btn, dic["BreakPoint_C"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BreakPoint_txt", this.wRetirementStudio.wBreakPoint_txt.Edit.txt, dic["BreakPoint_txt"], 0);
                _gLib._SetSyncUDWin("BreakPointAge", this.wRetirementStudio.wBreakpointAge.cbo, dic["BreakPointAge"], 0);
                _gLib._SetSyncUDWin("PayCredits_PayCredits", this.wRetirementStudio.wPayCredits.cbo, dic["PayCredits_PayCredits"], 0);
                _gLib._SetSyncUDWin("InterestCredit_RateOnBalance_TheSame", this.wRetirementStudio.wTheSame.rd, dic["InterestCredit_RateOnBalance_TheSame"], 0);
                _gLib._SetSyncUDWin("InterestCredit_RateOnBalance_Difference", this.wRetirementStudio.wDifference.rd, dic["InterestCredit_RateOnBalance_Difference"], 0);
      
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "Function is not completed");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-Jan-5
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("ForAges", "");
        ///    dic.Add("Rates", "");
        ///    dic.Add("CreditingPeriod", "");
        ///    dic.Add("CreditingFrequency", "");
        ///    pCashBalance._LinearizationWithBreakpoint_tbl(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _LinearizationWithBreakpoint_tbl(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iRow = Convert.ToInt32(dic["iRow"]);
                string sRow = "";

                for (int i = 1; i < iRow; i++)
                    sRow = sRow + "{Down}";

                _gLib._SetSyncUDWin("Rates", this.wRetirementStudio.wCashBalanceRate.grid, "click", 0, false, 40,20);
                _gLib._SendKeysUDWin("Rates", this.wRetirementStudio.wCashBalanceRate.grid, sRow, 0);


                if (dic["Rates"] != "")
                {
                    _gLib._SendKeysUDWin("Rates", this.wRetirementStudio.wCashBalanceRate.grid, "{Tab}", 0);


                    if (dic["Rates"] == "#1#")
                    {
                        _gLib._SetSyncUDWin("Rates", this.wRetirementStudio.wCom_cbo.cbo.btn, "click", 0);
                        _gLib._SendKeysUDWin("Rates", this.wRetirementStudio.wCom_cbo.cbo.btn, "{pageup}{pageup}", 0);
                        //////_gLib._SendKeysUDWin("Rates", this.wRetirementStudio.wCashBalanceRate.grid, "{pageup}{pageup}", 0);

                        _gLib._SetSyncUDWin("Rates", this.wRetirementStudio.wCom_cbo.cbo.btn, "click", 0);
                        
                        string sAct = this.wRetirementStudio.wCom_cbo.cbo.btn.DisplayText.Trim();
                        if (sAct != "")
                            _gLib._MsgBoxYesNo("", "Fail to set the first item,please manual set as \"\" under Rate in line" + iRow);
                    }
                    else
                    {
                        string sFirst = dic["Rates"].Substring(0, 1);


                        this.wRetirementStudio.wCom_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2"); /// 20150515, webber added for US011 CashBalance
                                               
                        _gLib._SetSyncUDWin("Rates", this.wRetirementStudio.wCom_cbo.cbo.btn, "click", 0);

                        //////_gLib._SetSyncUDWin("Rates", this.wRetirementStudio.wCom_cbo.cbo, dic["Rates"], 0);


                        //////_gLib._SendKeysUDWin("Rates", this.wRetirementStudio.wCashBalanceRate.grid, "{Tab}", 0);


                        //////////for(int i=1;i<=5;i++)
                        //////////{

                        //////////    this.wRetirementStudio.wCom_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, i.ToString());
                        //////////    this.wRetirementStudio.wCom_cbo.cbo.DrawHighlight();

                        //////////}

                        Boolean bSelected = false;

                        for (int i = 1; i <= 2; i++)
                        {
                            sFirst = sFirst + dic["Rates"].Substring(0, 1); 
                            _gLib._SendKeysUDWin("Rates", this.wRetirementStudio.wCom_cbo.cbo, sFirst, 0);
                            this.wRetirementStudio.wCom_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2"); /// 20150515, webber added for US011 CashBalance
                            string sAct = this.wRetirementStudio.wCom_cbo.cbo.SelectedItem.Trim();

                            //////////////////_gLib._Report(_PassFailStep.Fail, i.ToString() + sAct);
                            if (sAct == dic["Rates"])
                            {
                                bSelected = true;
                                break;
                            }
                        }

                        if(!bSelected)
                        {
                            _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to select <" +  dic["Rates"] + ">");
                            _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to send Keys <" +  dic["Rates"] + ">");
                        }

                        _gLib._SendKeysUDWin("Rates", this.wRetirementStudio.wCashBalanceRate.grid, "{Tab}", 0);

                   
                    
                    
                    }
                }


                if (dic["ForAges"] != "" || dic["CreditingPeriod"] != "" || dic["CreditingFrequency"] != "")
                {
                    _gLib._MsgBox("", "Function is not complete,");
                }
             
              
            }

            if (dic["PopVerify"] == "Verify")
            {

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
