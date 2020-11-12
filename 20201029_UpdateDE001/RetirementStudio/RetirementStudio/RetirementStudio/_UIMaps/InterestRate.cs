namespace RetirementStudio._UIMaps.InterestRateClasses
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
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;


    public partial class InterestRate
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();

        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PrescribedRates", "");
        ///    dic.Add("NonPrescribedRates", "");
        ///    dic.Add("SameStructureForAllPeriods", "");
        ///    dic.Add("TimeBased", "");
        ///    dic.Add("VIcon", "");
        ///    dic.Add("PercentIcon", "");
        ///    dic.Add("TIcon", "");
        ///    dic.Add("txtRate", "");
        ///    dic.Add("cboRate", "");
        ///    pInterestRate._PopVerify_SameStructureForAllPeriods(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SameStructureForAllPeriods(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_SameStructureForAllPeriods";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("PrescribedRates", this.wRetirementStudio.wPrescribedRates.rdPrescribedRates, dic["PrescribedRates"], 0);
                _gLib._SetSyncUDWin("NonPrescribedRates", this.wRetirementStudio.wNonprescribedratesw.rd, dic["NonPrescribedRates"], 0);
                _gLib._SetSyncUDWin("SameStructureForAllPeriods", this.wRetirementStudio.wSameStructureForAllPeriods.rdSameStructureForAllPeriods, dic["SameStructureForAllPeriods"], 0);
                _gLib._SetSyncUDWin("TimeBased", this.wRetirementStudio.wTimeBased.rdTimeBased, dic["TimeBased"], 0);
                _gLib._SetSyncUDWin("PercentIcon", this.wRetirementStudio.wSameStructureForAllPeriods_Rate_PercentIcon.btnPercentIcon, dic["PercentIcon"], 0);
                _gLib._SetSyncUDWin("VIcon", this.wRetirementStudio.wCom_V.btn, dic["VIcon"], 0);
                _gLib._SetSyncUDWin("TIcon", this.wRetirementStudio.wSameStructureForAllPeriods_Rate_TIcon.btnTIcon, dic["TIcon"], 0);
                _gLib._SetSyncUDWin_ByClipboard("txtRate", this.wRetirementStudio.wSameStructureForAllPeriods_Rate_txt.txtRate, dic["txtRate"], true, 0);
                _gLib._SetSyncUDWin("cboRate", this.wRetirementStudio.wSameStructureForAllPeriods_Rate_cbo.cboRate, dic["cboRate"], 0);
            }
            
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("PrescribedRates", this.wRetirementStudio.wPrescribedRates.rdPrescribedRates, dic["PrescribedRates"], 0);
                _gLib._VerifySyncUDWin("SameStructureForAllPeriods", this.wRetirementStudio.wSameStructureForAllPeriods.rdSameStructureForAllPeriods, dic["SameStructureForAllPeriods"], 0);
                _gLib._VerifySyncUDWin("TimeBased", this.wRetirementStudio.wTimeBased.rdTimeBased, dic["TimeBased"], 0);
                _gLib._VerifySyncUDWin("PercentIcon", this.wRetirementStudio.wSameStructureForAllPeriods_Rate_PercentIcon.btnPercentIcon, dic["PercentIcon"], 0);
                _gLib._VerifySyncUDWin("TIcon", this.wRetirementStudio.wSameStructureForAllPeriods_Rate_TIcon.btnTIcon, dic["TIcon"], 0);
                _gLib._VerifySyncUDWin("txtRate", this.wRetirementStudio.wSameStructureForAllPeriods_Rate_txt.txtRate, dic["txtRate"], 0);
                _gLib._VerifySyncUDWin("cboRate", this.wRetirementStudio.wSameStructureForAllPeriods_Rate_cbo.cboRate, dic["cboRate"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PrescribedRates", "");
        ///    dic.Add("SameStructureForAllPeriods", "");
        ///    dic.Add("TimeBased", "");
        ///    dic.Add("Rate", "");
        ///    dic.Add("AsOfDate", "");
        ///    pInterestRate._PopVerify_PrescribedRates(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PrescribedRates(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PrescribedRates";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("PrescribedRates", this.wRetirementStudio.wPrescribedRates.rdPrescribedRates, dic["PrescribedRates"], 0);
                _gLib._SetSyncUDWin("SameStructureForAllPeriods", this.wRetirementStudio.wSameStructureForAllPeriods.rdSameStructureForAllPeriods, dic["SameStructureForAllPeriods"], 0);
                _gLib._SetSyncUDWin("TimeBased", this.wRetirementStudio.wTimeBased.rdTimeBased, dic["TimeBased"], 0);
                _gLib._SetSyncUDWin("Rate", this.wRetirementStudio.wPrescribedRates_Rate.cboRate, dic["Rate"], 0);

               if (dic["AsOfDate"]!="")
                {
                    _gLib._SendKeysUDWin("AsOfDate", this.wRetirementStudio.wPrecribedRates_AsOfDate.wAsOfDate.txtAsOfDate, "{Home}");
                    _gLib._SendKeysUDWin("AsOfDate", this.wRetirementStudio.wPrecribedRates_AsOfDate.wAsOfDate.txtAsOfDate, "{End}", 0, ModifierKeys.Shift, false);
                    _gLib._SetSyncUDWin_ByClipboard("AsOfDate", this.wRetirementStudio.wPrecribedRates_AsOfDate.wAsOfDate.txtAsOfDate, dic["AsOfDate"], 0, false, false);               
                    _gLib._VerifySyncUDWin("AsOfDate", this.wRetirementStudio.wPrecribedRates_AsOfDate.wAsOfDate.txtAsOfDate, dic["AsOfDate"], 0);
                }				
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("PrescribedRates", this.wRetirementStudio.wPrescribedRates.rdPrescribedRates, dic["PrescribedRates"], 0);
                _gLib._VerifySyncUDWin("SameStructureForAllPeriods", this.wRetirementStudio.wSameStructureForAllPeriods.rdSameStructureForAllPeriods, dic["SameStructureForAllPeriods"], 0);
                _gLib._VerifySyncUDWin("TimeBased", this.wRetirementStudio.wTimeBased.rdTimeBased, dic["TimeBased"], 0);
                _gLib._VerifySyncUDWin("Rate", this.wRetirementStudio.wPrescribedRates_Rate.cboRate, dic["Rate"], 0);
                _gLib._VerifySyncUDWin("AsOfDate", this.wRetirementStudio.wPrecribedRates_AsOfDate.wAsOfDate.txtAsOfDate, dic["AsOfDate"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-May-25 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AsOfDate", "");
        ///    dic.Add("ForActuarialEquivalence", "");
        ///    dic.Add("ForwardRate", "");
        ///    dic.Add("SpotRate", "");
        ///    dic.Add("AddRow", "");
        ///    pInterestRate._PopVerify_TimeBased(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_TimeBased(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_TimeBased";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
 
                _gLib._SetSyncUDWin_ByClipboard("AsOfDate", this.wRetirementStudio.wPrecribedRates_AsOfDate.wAsOfDate.txtAsOfDate, dic["AsOfDate"], 0);
                _gLib._SetSyncUDWin("ForActuarialEquivalence", this.wRetirementStudio.wForActuarialEquivalence.cbo, dic["ForActuarialEquivalence"], 0);
                _gLib._SetSyncUDWin("ForwardRate", this.wRetirementStudio.wForwardRate.rd, dic["ForwardRate"], 0);
                _gLib._SetSyncUDWin("SpotRate", this.wRetirementStudio.wSpotRate.rd, dic["SpotRate"], 0);
                _gLib._SetSyncUDWin("AddRow", this.wRetirementStudio.wAddRow.btn, dic["AddRow"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("AsOfDate", this.wRetirementStudio.wPrecribedRates_AsOfDate.wAsOfDate.txtAsOfDate, dic["AsOfDate"], 0);
                _gLib._VerifySyncUDWin("ForActuarialEquivalence", this.wRetirementStudio.wForActuarialEquivalence.cbo, dic["ForActuarialEquivalence"], 0);
                _gLib._VerifySyncUDWin("ForwardRate", this.wRetirementStudio.wForwardRate.rd, dic["ForwardRate"], 0);
                _gLib._VerifySyncUDWin("SpotRate", this.wRetirementStudio.wSpotRate.rd, dic["SpotRate"], 0);
                _gLib._VerifySyncUDWin("AddRow", this.wRetirementStudio.wAddRow.btn, dic["AddRow"], 0);
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
        ///    pInterestRate._TimeBased_Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _TimeBased_Table(MyDictionary dic)
        {
            string sFunctionName = "_TimeBased_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wTimeBased_FPGrid.grid, "Click", 0, false, 94, 28);
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wTimeBased_FPGrid.grid, "Click", 0, false, 94, 28);

            if (_gLib._Exists("Grid", this.wRetirementStudio.wTableField.txtNumOfYears, 0))
            {

                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTimeBased_FPGrid.grid, "{PageUp}{PageUp}");

                _gLib._Wait(1);

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wTimeBased_FPGrid.grid, "Click", 0, false, 94, 10);
            }

            int iRow = Convert.ToInt32(dic["iRow"]);

            if (dic["NumberOfYears"] != "")
            {
                for (int i = 0; i < (iRow - 1); i++)
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTimeBased_FPGrid.grid, "{Tab}{Tab}");

                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": NumberOfYears", this.wRetirementStudio.wTableField.txtNumOfYears, dic["NumberOfYears"], 0);
            }

            if (dic["Rate"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTimeBased_FPGrid.grid, "{Tab}");

                _gLib._SendKeysUDWin("Rate", this.wRetirementStudio.wTableField.txtRate, dic["Rate"]);

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wTimeBased_BlankArea.pane, "Click", 0, false, 30, 10);

                string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wTimeBased_FPGrid.grid);
                if (sAct != dic["Rate"])
                {

                    _gLib._MsgBox("", "" + float.Parse(sAct));
                    _gLib._MsgBox("", "" + float.Parse(dic["Rate"]));
                    // if sAct equals '10,75000000', we need cut them down and result as 0 is correct
                    if ((float.Parse(sAct) - float.Parse(dic["Rate"])) == 0)
                    { }
                    else
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set <" + dic["Rate"] + "> to object <Timebased Table>. Actual Value: <" + sAct + "> ");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Verify Object: <Timebased Table> with expected value: <" + dic["Rate"] + ">. Actual Value: <" + sAct + "> ");
                    }
                }
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
        ///    pInterestRate._TimeBased_Table_DE(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _TimeBased_Table_DE(MyDictionary dic)
        {
            string sFunctionName = "_TimeBased_Table_DE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");
            int iRow = Convert.ToInt32(dic["iRow"]);


            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wTimeBased_FPGrid.grid, "Click", 0, false, 94, 28);
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wTimeBased_FPGrid.grid, "Click", 0, false, 94, 28);

            if (_gLib._Exists("Grid", this.wRetirementStudio.wTableField.txtNumOfYears, 0))
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTimeBased_FPGrid.grid, "{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}");

                _gLib._Wait(1);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wTimeBased_FPGrid.grid, "Click", 0, false, 94, 10);
            }

            string sRow = "";
            for (int i = 0; i < (iRow - 1); i++)
                sRow = sRow + "{Tab}{Tab}";
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTimeBased_FPGrid.grid, sRow);


            if (dic["NumberOfYears"] != "")
                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": NumberOfYears", this.wRetirementStudio.wTableField.txtNumOfYears, dic["NumberOfYears"], 0);

            if (dic["Rate"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTimeBased_FPGrid.grid, "{Tab}");
                _gLib._SetSyncUDWin_ByClipboard("Rate", this.wRetirementStudio.wTableField.txtRate, dic["Rate"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-July-1
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PreDecrementRate", "");
        ///    dic.Add("PreCommencementRate", "");
        ///    dic.Add("PostCommencementRate", "");
        ///    pInterestRate._PopVerify_PreDecrementPrePostCommencement(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PreDecrementPrePostCommencement(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PreDecrementPrePostCommencement";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("PreDecrementPrePostCommencement", this.wRetirementStudio.wPreDecrementPrePostCommencement.rd, "True", 0);
                _gLib._SetSyncUDWin_ByClipboard("PreDecrementRate", this.wRetirementStudio.wPreDecrementRate.txt, dic["PreDecrementRate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PreCommencementRate", this.wRetirementStudio.wPreCommencementRate.txt, dic["PreCommencementRate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PostCommencementRate", this.wRetirementStudio.wPostCommencementRate.txt, dic["PostCommencementRate"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("PreDecrementPrePostCommencement", this.wRetirementStudio.wPreDecrementPrePostCommencement.rd, "True", 0);
                _gLib._VerifySyncUDWin("PreDecrementRate", this.wRetirementStudio.wPreDecrementRate.txt, dic["PreDecrementRate"], 0);
                _gLib._VerifySyncUDWin("PreCommencementRate", this.wRetirementStudio.wPreCommencementRate.txt, dic["PreCommencementRate"], 0);
                _gLib._VerifySyncUDWin("PostCommencementRate", this.wRetirementStudio.wPostCommencementRate.txt, dic["PostCommencementRate"], 0);


            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-12
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PreCommencementRate_C", "");
        ///    dic.Add("PreCommencementRate_T", "");
        ///    dic.Add("PostCommencementRate_C", "");
        ///    dic.Add("PostCommencementRate_T", "");
        ///    pInterestRate._PopVerify_PrePostCommencement(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PrePostCommencement(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PreDecrementPrePostCommencement";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                int itxt = 0;
                int iT_cbo = 0;

                _gLib._SetSyncUDWin("PrePostCommencement", this.wRetirementStudio.wPrepostcommencement.rd, "True", 0);




                if (dic["PreCommencementRate_C"] != "")
                {
                    itxt++;

                    _gLib._SetSyncUDWin_ByClipboard("PreCommencementRate", this.wRetirementStudio.wPreCommencementRate.txt, dic["PreCommencementRate_C"], 0);
                }


                _gLib._SetSyncUDWin("PrePostCommencement", this.wRetirementStudio.wPrepostcommencement.rd, "True", 0);

                if (dic["PreCommencementRate_T"] != "")
                {
                    iT_cbo++;
                    if (_gLib._Exists("", this.wRetirementStudio.wCom_T.btn,5))
                         _gLib._SetSyncUDWin("PreCommencementRate", this.wRetirementStudio.wCom_T.btn, "click", 0);
                    _gLib._SetSyncUDWin("PreCommencementRate", this.wRetirementStudio.wPreCommencementRate_T.cbo, dic["PreCommencementRate_T"], 0);
                }



                if (dic["PostCommencementRate_C"] != "")
                {
                    itxt++;
                    if (_gLib._Exists("", this.wRetirementStudio.wCom_T.btn, 5))
                    {
                        this.wRetirementStudio.wCom_C.btn.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                        _gLib._SetSyncUDWin("PreCommencementRate", this.wRetirementStudio.wCom_C.btn, "click", 0);
                    }
                    this.wRetirementStudio.wPostCommencementRate.txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("PostCommencementRate", this.wRetirementStudio.wPostCommencementRate.txt, dic["PostCommencementRate_C"], 0);
                }


                if (dic["PostCommencementRate_T"] != "")
                {
                    iT_cbo++;
                    this.wRetirementStudio.wCom_T.btn.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                    _gLib._SetSyncUDWin("PreCommencementRate", this.wRetirementStudio.wCom_T.btn, "click", 0);
                    this.wRetirementStudio.wPreCommencementRate_T.cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iT_cbo.ToString());
                    _gLib._SetSyncUDWin("PostCommencementRate", this.wRetirementStudio.wPreCommencementRate_T.cbo, dic["PostCommencementRate_T"], 0);

                }


            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("PreDecrementPrePostCommencement", this.wRetirementStudio.wPreDecrementPrePostCommencement.rd, "True", 0);
                _gLib._VerifySyncUDWin("PreCommencementRate", this.wRetirementStudio.wPreCommencementRate.txt, dic["PreCommencementRate"], 0);
                _gLib._VerifySyncUDWin("PostCommencementRate", this.wRetirementStudio.wPostCommencementRate.txt, dic["PostCommencementRate"], 0);


            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-12
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PreDecrementRate", "");
        ///    dic.Add("PostDecrementRate", "");
        ///    pInterestRate._PopVerify_PrePostDecrement(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PrePostDecrement(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PrePostDecrement";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("PreDecrementRate", this.wRetirementStudio.wPreDecrementRate_txt.txt.UITxtPreDecrementRateEdit1, dic["PreDecrementRate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PostDecrementRate", this.wRetirementStudio.wPostDecrementRate_txt.txt.UITxtPostDecrementRateEdit1, dic["PostDecrementRate"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-July-1
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Precommencement_Pre2009_txt", "");
        ///    dic.Add("Precommencement_Post2009_txt", "");
        ///    dic.Add("Postcommencementrate_txt", "");
        ///    pInterestRate._PopVerify_NonPrescribedRates(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_NonPrescribedRates(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_NonPrescribedRates";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                this.wRetirementStudio.wNonPrescribe_txt.SearchProperties.Add(WinEdit.PropertyNames.Instance, "3");
                _gLib._SetSyncUDWin_ByClipboard("Precommencement_Pre2009_txt", this.wRetirementStudio.wNonPrescribe_txt.txt.UI_numEditRateEdit1, dic["Precommencement_Pre2009_txt"], 0);
                this.wRetirementStudio.wNonPrescribe_txt.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2");
                _gLib._SetSyncUDWin_ByClipboard("Precommencement_Post2009_txt", this.wRetirementStudio.wNonPrescribe_txt.txt.UI_numEditRateEdit1, dic["Precommencement_Post2009_txt"], 0);
                this.wRetirementStudio.wNonPrescribe_txt.SearchProperties.Add(WinEdit.PropertyNames.Instance, "1");
                _gLib._SetSyncUDWin_ByClipboard("Postcommencementrate_txt", this.wRetirementStudio.wNonPrescribe_txt.txt.UI_numEditRateEdit1, dic["Postcommencementrate_txt"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete yet");
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Feb-16
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("YieldCurve", "true");
        ///    dic.Add("Adjustments", "true");
        ///    dic.Add("ForwardDuration", "");
        ///    dic.Add("AsOfDate", "");
        ///    dic.Add("Adjustment1Operator_cbo", "");
        ///    dic.Add("Adjustment1_c", "");
        ///    dic.Add("Adjustment2Operator_cbo", "");
        ///    dic.Add("Adjustment2_p", "");
        ///    dic.Add("Adjustment3Operator_cbo", "");
        ///    dic.Add("Adjustment3_c", "");
        ///    dic.Add("ForwardDuration_txt", "");
        ///    pInterestRate._PopVerify_YieldCurve_NL(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_YieldCurve_NL(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Yield_NL";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("YieldCurve", this.wRetirementStudio.wYieldcurve.rd, dic["YieldCurve"], 0);
                _gLib._SetSyncUDWin("Adjustments", this.wRetirementStudio.wAdjustments.chk, dic["Adjustments"], 0);
                _gLib._SetSyncUDWin("ForwardDuration", this.wRetirementStudio.wForwarDuration.chk, dic["ForwardDuration"], 0);

                if (dic["AsofDate"] != "")
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wPrecribedRates_AsOfDate.wAsOfDate.txtAsOfDate, "{end}{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}", 0);
                _gLib._SetSyncUDWin_ByClipboard("AsOfDate", this.wRetirementStudio.wPrecribedRates_AsOfDate.wAsOfDate.txtAsOfDate, dic["AsOfDate"], 0);
                
                _gLib._SetSyncUDWin("Adjustment1Operator_cbo", this.wRetirementStudio.wAdjustment1Operat.cbo, dic["Adjustment1Operator_cbo"], 0);
                _gLib._SetSyncUDWin("Adjustment2Operator_cbo", this.wRetirementStudio.wAdjustment2Operat.cbo, dic["Adjustment2Operator_cbo"], 0);
                _gLib._SetSyncUDWin("Adjustment3Operator_cbo", this.wRetirementStudio.wAdjustment3Operat.cbo, dic["Adjustment3Operator_cbo"], 0);

               
                //////// the next code just suitable for nl001
                if (dic["Adjustment1_c"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment1_c", this.wRetirementStudio.wAdjustment1_C.btn, "click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("Adjustment1_c", this.wRetirementStudio.wComm_C_txt.txt.UI_numEditConstantEdit1, dic["Adjustment1_c"], 0);
                }
                if (dic["Adjustment2_p"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment2_p", this.wRetirementStudio.wAdjustment2_P.btn, "click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("Adjustment2_p", this.wRetirementStudio.wComm_P_txt.txt.UI_numEditRateEdit1, dic["Adjustment2_p"], 0);
                }
                if (dic["Adjustment3_c"] != "")
                {
                    _gLib._SetSyncUDWin("Adjustment3_c", this.wRetirementStudio.wAdjustment3_C.btn, "click", 0);
                    this.wRetirementStudio.wComm_C_txt.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2");
                    _gLib._SetSyncUDWin_ByClipboard("Adjustment3_c", this.wRetirementStudio.wComm_C_txt.txt.UI_numEditConstantEdit1, dic["Adjustment3_c"], 0);
                }


                _gLib._SetSyncUDWin_ByClipboard("ForwardDuration_txt", this.wRetirementStudio.wForwardDuration_txt.txt.UINudForwardDurationEdit1, dic["ForwardDuration_txt"], 0);
                
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete yet");
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
