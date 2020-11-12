namespace RetirementStudio._UIMaps.OutputManagerClasses
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

    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using RetirementStudio._ThridParty;
    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._UIMaps.MainClasses;


    public partial class OutputManager
    {
        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();
        private Main pMain = new Main();

        private int iTimeout_downloadFile = 20;

        public void _Debugging()
        {


        }


        /// <summary>
        /// 2013-May-15
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Doer", "True");
        ///    dic.Add("Checker", "");
        ///    dic.Add("Reviewer", "");
        ///    dic.Add("Setup", "click");
        ///    pOutputManager._PopVerify_OutputManager(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_OutputManager(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_OutputManager";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Doer", this.wRetirementStudio.wDoer.rdDoer, dic["Doer"], 0);
                _gLib._SetSyncUDWin("Checker", this.wRetirementStudio.wChecker.rdChecker, dic["Checker"], 0);
                _gLib._SetSyncUDWin("Reviewer", this.wRetirementStudio.wReviewer.rdReviewer, dic["Reviewer"], 0);
                _gLib._SetSyncUDWin("Setup", this.wRetirementStudio.wSetup.btnSetup, dic["Setup"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Doer", this.wRetirementStudio.wDoer.rdDoer, dic["Doer"], 0);
                _gLib._VerifySyncUDWin("Checker", this.wRetirementStudio.wChecker.rdChecker, dic["Checker"], 0);
                _gLib._VerifySyncUDWin("Reviewer", this.wRetirementStudio.wReviewer.rdReviewer, dic["Reviewer"], 0);
                _gLib._VerifySyncUDWin("Setup", this.wRetirementStudio.wSetup.btnSetup, dic["Setup"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        public void _SelectTab(string sTabName)
        {
            _gLib._TabPageSelectWin(sTabName, this.wRetirementStudio.wHome_Tab, 0);
        }


        /// <summary>
        /// 2013-May-16
        /// webber.ling@mercer.com
        /// 
        /// pOutputManager._Navigate("Liability Summary", "Conversion", true);
        /// pOutputManager._Navigate("Valuation Summary", "Rollforward", true);
        /// pOutputManager._Navigate("Detailed Results by Plan Def", "Conversion", true);
        /// </summary>
        /// <param name=""></param>

        public void _Navigate(string sReport, string sConversion_RollForward, Boolean bFunding)
        {
            this._Navigate(_Country.US, sReport, sConversion_RollForward, bFunding);
        }


        public void _Navigate(_Country eCountry, string sReport, string sConversion_RollForward, Boolean bFunding)
        {

            string sFunctionName = "_Navigate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iPosX = 60;
            int iPosY = 10000;
            int iStepY = 20;

            int iReportRow = 0;
            Boolean bAllValuationSet = true;

            eCountry = Config.eCountry;

            switch (sConversion_RollForward)
            {

                #region Conversion
                case "Conversion":
                    {
                        switch (sReport)
                        {

                            // just put it in here. this report was not appear in conversion
                            case "Age Service Matrix":
                                bAllValuationSet = false;
                                iReportRow = 6;
                                break;
                            case "Payout Projection by Participant":
                                bAllValuationSet = false;
                                iReportRow = 8;
                                break;

                            case "2D Cash flow Projection":
                            //////////case "2D Cash flow by Participant":
                                bAllValuationSet = false;
                                iReportRow = 9;
                                break;
                                
                            case "Liability Summary":
                                bAllValuationSet = true;
                                if (eCountry == _Country.DE)
                                    iReportRow = 1;
                                else
                                    iReportRow = 3;
                                break;
                            case "Member Statistics":
                                bAllValuationSet = true;
                                if (eCountry == _Country.DE)
                                    iReportRow = 2;
                                else
                                    iReportRow = 4;
                                break;
                            case "Conversion Diagnostic":
                                bAllValuationSet = true;
                                if (eCountry == _Country.DE)
                                    iReportRow = 3;
                                else
                                    iReportRow = 5;
                                break;
                            case "Test Case List":
                                bAllValuationSet = true;
                                if (eCountry == _Country.DE)
                                    iReportRow = 4;
                                else
                                    iReportRow = 6;
                                break;
                            case "Detailed Results":
                                bAllValuationSet = true;
                                if (eCountry == _Country.UK)
                                    iReportRow = 7;
                                else if (eCountry == _Country.DE)
                                    iReportRow = 6;
                                else
                                    iReportRow = 8;
                                break;
                            case "Detailed Results with Ben Type splits":
                                bAllValuationSet = true;
                                iReportRow = 8;
                                break;
                            case "Detailed Results by Plan Def":
                                bAllValuationSet = true;
                                if (eCountry == _Country.DE)
                                    iReportRow = 7;
                                else
                                    iReportRow = 9;
                                break;
                            case "Valuation Summary":
                                bAllValuationSet = false;
                                iReportRow = 1;
                                break;
                            case "Valuation Summary for Excel Export":
                                bAllValuationSet = false;
                                iReportRow = 2;
                                break;
                            case "Individual Output":
                            case "IOE":
                                bAllValuationSet = false;
                                if (eCountry == _Country.DE)
                                    iReportRow = 3;
                                else
                                    iReportRow = 2;
                                break;
                            case "Parameter Print":
                                bAllValuationSet = false;//if (eCountry == _Country.CA)
                                if (eCountry == _Country.DE)
                                    iReportRow = 4;
                                else
                                    iReportRow = 3;
                                break;
                            case "Parameter Summary":
                                bAllValuationSet = false;//if (eCountry == _Country.DE)
                                iReportRow = 4;
                                break;
                            case "Test Cases":
                                {
                                    bAllValuationSet = false;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 6;
                                    else
                                        iReportRow = 4;
                                    break;
                                }
                            case "Payout Projection - Benefit Cashflows":
                                bAllValuationSet = false;
                                iReportRow = 5;
                                break;
                            case "Payout Projection - Other Info":
                                bAllValuationSet = false;
                                iReportRow = 6;
                                break;

                            case "2D PayoutProjections":
                            case "2D Payout Projections":
                                bAllValuationSet = false;
                                iReportRow = 7;
                                break;
                            case "Payout Projection":
                                {
                                    bAllValuationSet = false;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 7;
                                    else
                                        iReportRow = 5;
                                    break;
                                }
                            case "FAS Expected Benefit Pmts":
                                bAllValuationSet = false;
                                iReportRow = 6;
                                break;
                            case "Reconciliation to Baseline":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.IR || eCountry == _Country.US)
                                        iReportRow = 8;
                                    else if (eCountry == _Country.UK)
                                        iReportRow = 9;
                                    else
                                        iReportRow = 7;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 9;
                                    else
                                    {
                                        if (eCountry == _Country.UK)
                                            iReportRow = 7;
                                        else
                                            iReportRow = 8;
                                    }
                                }
                                break;
                            case "Reconciliation to Baseline by Plan Def":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.US || eCountry == _Country.IR)
                                        iReportRow = 9;
                                    else
                                        iReportRow = 8;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 10;
                                    else
                                    {
                                        if (eCountry == _Country.UK)
                                            iReportRow = 8;
                                        else
                                            iReportRow = 9;
                                    }

                                }
                                break;
                            case "Liabilities Detailed Results":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.US || eCountry == _Country.IR || eCountry == _Country.UK)
                                        iReportRow = 10;
                                    else
                                        iReportRow = 9;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 11;
                                    else
                                    {
                                        if (eCountry == _Country.UK)
                                            iReportRow = 9;
                                        else
                                            iReportRow = 10;
                                    }

                                }
                                break;
                            case "Liabilities Detailed Results with Ben Type splits":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.UK)
                                        iReportRow = 11;
                                    else
                                        iReportRow = 11;
                                }

                                break;

                            case "Liabilities Detailed Results by Plan Def":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.US || eCountry == _Country.IR)
                                        iReportRow = 11;
                                    else
                                        iReportRow = 10;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 12;
                                    else
                                    {
                                        if (eCountry == _Country.UK)
                                            iReportRow = 10;
                                        else
                                            iReportRow = 11;
                                    }

                                }
                                break;
                            case "Future Valuation Population Projection":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    iReportRow = 12;
                                    if (eCountry == _Country.ANZ || eCountry == _Country.US)
                                        iReportRow = 13;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 14;
                                    else
                                        iReportRow = 13;
                                }
                                break;
                            case "Future Valuation Summary":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    iReportRow = 13;
                                    if (eCountry == _Country.ANZ || eCountry == _Country.US)
                                        iReportRow = 14;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 15;
                                    else
                                        iReportRow = 14;
                                }
                                break;
                            case "Future Valuation Individual Output":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    iReportRow = 14;
                                    if (eCountry == _Country.ANZ || eCountry == _Country.US)
                                        iReportRow = 15;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 16;
                                    else
                                        iReportRow = 15;
                                }
                                break;
                            case "Future Valuation Parameter Print":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    iReportRow = 15;
                                    if (eCountry == _Country.ANZ || eCountry == _Country.US)
                                        iReportRow = 16;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 17;
                                    else
                                        iReportRow = 16;
                                }
                                break;
                            case "Future Valuation Payouts":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    iReportRow = 16;
                                    if (eCountry == _Country.ANZ || eCountry == _Country.US)
                                        iReportRow = 17;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 18;
                                    else
                                        iReportRow = 17;
                                }
                                break;
                            case "Future Valuation Data Export":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    iReportRow = 17;
                                    if (eCountry == _Country.ANZ || eCountry == _Country.US)
                                        iReportRow = 18;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 19;
                                    else
                                        iReportRow = 18;
                                }
                                break;
                            case "Future Valuation Liabilities by Group":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    iReportRow = 18;
                                    if (eCountry == _Country.ANZ || eCountry == _Country.US)
                                        iReportRow = 19;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 20;
                                    else
                                        iReportRow = 19;
                                }
                                break;
                            case "Future Valuation Liabilities by Year":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    iReportRow = 19;
                                    if (eCountry == _Country.ANZ || eCountry == _Country.US)
                                        iReportRow = 20;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 21;
                                    else
                                        iReportRow = 20;
                                }
                                break;
                            case "Plan Aggregation":
                                bAllValuationSet = false;
                                if (bFunding)
                                    iReportRow = 22;
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 23;
                                    else
                                        iReportRow = 22;
                                }
                                break;
                            case "Coverage Test":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 24;
                                    else
                                        iReportRow = 23;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 24;
                                    else
                                        iReportRow = 23;
                                }
                                break;
                            case "General Test":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 25;
                                    else
                                        iReportRow = 24;
                                }
                                else
                                {
                                    if (eCountry == _Country.US)
                                        iReportRow = 25;
                                    else
                                        iReportRow = 24;
                                }
                                break;
                            default:
                                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReport + ">. Please Verify!");
                                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReport + ">. Please Verify!");
                                break;
                        }
                        break;
                    }

                #endregion

                #region RollForward
                case "RollForward":
                    {
                        switch (sReport)
                        {
                            case "Reconciliation to Prior Year":
                                {
                                    bAllValuationSet = true;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 2;
                                    else
                                        iReportRow = 6;
                                    break;
                                }
                            case "Reconciliation to Prior Year with Breaks":
                                {
                                    bAllValuationSet = true;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 3;
                                    else
                                        iReportRow = 7;
                                    break;
                                }
                            case "Reconciliation to Prior Year by Plan Def":
                                {
                                    bAllValuationSet = true;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 4;
                                    else
                                        iReportRow = 8;
                                    break;
                                }
                            case "Reconciliation to Prior Year by Plan Def with Breaks":
                                {
                                    bAllValuationSet = true;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 5;
                                    else
                                        iReportRow = 9;
                                    break;
                                }
                            case "Detailed Results":
                                {
                                    bAllValuationSet = true;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 6;
                                    else if (eCountry == _Country.UK)
                                        iReportRow = 8;
                                    else
                                        iReportRow = 10;
                                    break;
                                }
                            case "Detailed Results with Ben Type splits":
                                {
                                    bAllValuationSet = true;
                                    iReportRow = 9; /// UK only
                                    break;
                                }
                            case "Detailed Results with Breaks":
                                {
                                    bAllValuationSet = true;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 7;
                                    else if (eCountry == _Country.UK)
                                        iReportRow = 10;
                                    else
                                        iReportRow = 11;
                                    break;
                                }
                            case "Detailed Results with Breaks & Ben Type splits":
                                {
                                    bAllValuationSet = true;
                                    iReportRow = 11; /// UK only
                                    break;
                                }
                            case "Detailed Results by Plan Def":
                                {
                                    bAllValuationSet = true;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 8;
                                    else
                                        iReportRow = 12;
                                    break;
                                }
                            case "Detailed Results by Plan Def with Breaks":
                                {
                                    bAllValuationSet = true;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 9;
                                    else
                                        iReportRow = 13;
                                    break;
                                }
                            case "Status Reconciliation":
                                {
                                    bAllValuationSet = true;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 11;
                                    else if (eCountry == _Country.UK)
                                        iReportRow = 13;
                                    else
                                        iReportRow = 15;
                                    break;
                                }
                            case "Member Statistics":
                                {
                                    bAllValuationSet = true;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 12;
                                    else if (eCountry == _Country.UK)
                                        iReportRow = 14;
                                    else
                                        iReportRow = 16;
                                    break;
                                }
                            case "Individual Checking Template":
                                {
                                    bAllValuationSet = true;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 13;
                                    else if (eCountry == _Country.UK)
                                        iReportRow = 15;
                                    else
                                        iReportRow = 17;
                                    break;
                                }
                            case "Age Service Matrix":
                                bAllValuationSet = true;
                                if (eCountry == _Country.CA || eCountry == _Country.IR)
                                    iReportRow = 17;
                                else if (eCountry == _Country.UK)
                                    iReportRow = 16;
                                else
                                    iReportRow = 18;
                                break;
                            case "Data Comparison":
                                bAllValuationSet = true;
                                iReportRow = 19;
                                break;
                            case "Data Matching Summary":
                                bAllValuationSet = true;
                                if (eCountry == _Country.CA || eCountry == _Country.IR)
                                    iReportRow = 19;
                                else if (eCountry == _Country.NL)
                                    iReportRow = 20;
                                else if (eCountry == _Country.UK)
                                    iReportRow = 18;
                                else if (eCountry == _Country.DE)
                                    iReportRow = 15;
                                else
                                    iReportRow = 21;
                                break;
                            case "Combined Status Code Summary":
                                bAllValuationSet = true;
                                if (eCountry == _Country.UK)
                                    iReportRow = 19;
                                else if (eCountry == _Country.CA || eCountry == _Country.IR)
                                    iReportRow = 20;
                                else if (eCountry == _Country.NL)
                                    iReportRow = 21;
                                else if (eCountry == _Country.DE)
                                    iReportRow = 16;
                                else
                                    iReportRow = 22;
                                break;
                            case "Gain / Loss Status Reconciliation":
                                bAllValuationSet = true;
                                if (eCountry == _Country.UK)
                                    iReportRow = 20;
                                else if (eCountry == _Country.CA || eCountry == _Country.IR)
                                    iReportRow = 21;
                                else if (eCountry == _Country.NL)
                                    iReportRow = 22;
                                else if (eCountry == _Country.DE)
                                    iReportRow = 17;
                                else
                                    iReportRow = 23;
                                break;
                            case "Gain / Loss Summary of Liability Reconciliation":
                                bAllValuationSet = true;
                                if (eCountry == _Country.UK)
                                    iReportRow = 21;
                                else if (eCountry == _Country.CA || eCountry == _Country.IR)
                                    iReportRow = 22;
                                else if (eCountry == _Country.NL)
                                    iReportRow = 12;
                                else if (eCountry == _Country.DE)
                                    iReportRow = 18;
                                else
                                    iReportRow = 24;
                                break;
                            case "Decrement Gain / Loss Detail":
                            case "Active Decrement Gain / Loss Detail":
                                bAllValuationSet = true;
                                if (eCountry == _Country.UK)
                                    iReportRow = 22;
                                else if (eCountry == _Country.CA || eCountry == _Country.IR)
                                    iReportRow = 23;
                                else if (eCountry == _Country.NL)
                                    iReportRow = 24;
                                else if (eCountry == _Country.DE)
                                    iReportRow = 19;
                                else
                                    iReportRow = 25;
                                break;
                            case "Decrement Age":
                                bAllValuationSet = true;
                                if (eCountry == _Country.UK)
                                    iReportRow = 23;
                                else if (eCountry == _Country.CA || eCountry == _Country.IR)
                                    iReportRow = 24;
                                else if (eCountry == _Country.NL)
                                    iReportRow = 25;
                                else if (eCountry == _Country.DE)
                                    iReportRow = 20;
                                else
                                    iReportRow = 26;
                                break;
                            case "Gain / Loss Participant Listing":
                                bAllValuationSet = true;
                                if (eCountry == _Country.UK)
                                    iReportRow = 24;
                                else if (eCountry == _Country.CA || eCountry == _Country.IR)
                                    iReportRow = 25;
                                else if (eCountry == _Country.NL)
                                    iReportRow = 26;
                                else if (eCountry == _Country.DE)
                                    iReportRow = 21;
                                else
                                    iReportRow = 27;
                                break;
                            case "Liability Comparison":
                                bAllValuationSet = true;
                                iReportRow = 28;
                                break;
                            case "Liability Scenario":
                                bAllValuationSet = true;
                                if (eCountry == _Country.CA)
                                    iReportRow = 27;
                                else if (eCountry == _Country.IR)
                                    iReportRow = 26;
                                else if (eCountry == _Country.DE)
                                    iReportRow = 24;
                                else if (eCountry == _Country.UK)
                                    iReportRow = 26; ////18
                                else if (eCountry == _Country.NL)
                                    iReportRow = 27;
                                else
                                    iReportRow = 30;
                                break;
                            case "Liability Scenario with Breaks":
                                bAllValuationSet = true;
                                if (eCountry == _Country.CA)
                                    iReportRow = 28;
                                else if (eCountry == _Country.IR)
                                    iReportRow = 27;
                                else if (eCountry == _Country.DE)
                                    iReportRow = 25;
                                else if (eCountry == _Country.UK)
                                    iReportRow = 27; ////19
                                else if (eCountry == _Country.NL)
                                    iReportRow = 28;
                                else
                                    iReportRow = 31;
                                break;
                            case "Liability Scenario by Plan Def":
                                bAllValuationSet = true;
                                if (eCountry == _Country.CA)
                                    iReportRow = 29;
                                else if (eCountry == _Country.IR)
                                    iReportRow = 28;
                                else if (eCountry == _Country.DE)
                                    iReportRow = 26;
                                else if (eCountry == _Country.NL)
                                    iReportRow = 29;
                                else
                                    iReportRow = 32;
                                break;
                            case "Liability Scenario by Plan Def with Breaks":
                                bAllValuationSet = true;
                                if (eCountry == _Country.CA)
                                    iReportRow = 30;
                                else if (eCountry == _Country.IR)
                                    iReportRow = 29;
                                else if (eCountry == _Country.DE)
                                    iReportRow = 27;
                                else if (eCountry == _Country.NL)
                                    iReportRow = 30;
                                else
                                    iReportRow = 33;
                                break;
                            case "Funding Calculator Scenario":
                                bAllValuationSet = true;
                                if (eCountry == _Country.CA)
                                    iReportRow = 31;
                                else if (eCountry == _Country.NL)
                                    iReportRow = 31;
                                else
                                    iReportRow = 34;
                                break;
                            case "Valuation Summary":
                                bAllValuationSet = false;
                                iReportRow = 1;
                                break;
                            case "Valuation Summary for Excel Export":
                                bAllValuationSet = false;
                                iReportRow = 2;
                                break;
                            case "Individual Output":
                            case "IOE":
                                bAllValuationSet = false;
                                if (eCountry == _Country.DE)
                                    iReportRow = 3;
                                else
                                    iReportRow = 2;
                                break;
                            case "Parameter Print":
                                bAllValuationSet = false;//if (eCountry == _Country.CA)
                                if (eCountry == _Country.DE)
                                    iReportRow = 4;
                                else
                                    iReportRow = 3;
                                break;
                            case "Parameter Summary":
                                bAllValuationSet = false;//if (eCountry == _Country.DE)
                                iReportRow = 5;
                                break;
                            case "Test Cases":
                                {
                                    bAllValuationSet = false;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 6;
                                    else
                                        iReportRow = 4;
                                    break;
                                }
                            case "Payout Projection - Benefit Cashflows":
                                bAllValuationSet = false;
                                iReportRow = 5;
                                break;
                            case "Payout Projection - Other Info":
                                bAllValuationSet = false;
                                iReportRow = 6;
                                break;
                            case "2D Payout Projections":
                                bAllValuationSet = false;
                                iReportRow = 7;
                                break;
                            case "Payout Projection":
                                {
                                    bAllValuationSet = false;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 7;
                                    else
                                        iReportRow = 5;
                                    break;
                                }

                            case "Data Request":
                                {
                                    bAllValuationSet = false;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 11;
                                    else
                                        iReportRow = 7;
                                    break;
                                }
                            case "FAS Expected Benefit Pmts":
                                {
                                    bAllValuationSet = false;
                                    if (eCountry == _Country.DE)
                                        iReportRow = 10;
                                    else
                                        iReportRow = 7;
                                    break;
                                }
                            case "Reconciliation to Baseline":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 15;
                                    else if (eCountry == _Country.UK || eCountry == _Country.NL)
                                        iReportRow = 10;
                                    else if (eCountry == _Country.IR || eCountry == _Country.US)
                                        iReportRow = 9;
                                    else
                                        iReportRow = 8;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 14;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 10;
                                    else
                                        iReportRow = 9;
                                }
                                break;
                            case "Reconciliation to Baseline with Breaks":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 16;
                                    else if (eCountry == _Country.UK)
                                        iReportRow = 11;
                                    else if (eCountry == _Country.NL)
                                        iReportRow = 11;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 10;
                                    else
                                        iReportRow = 9;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 15;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 11;
                                    else
                                        iReportRow = 10;
                                }
                                break;
                            case "Reconciliation to Baseline by Plan Def":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 17;
                                    else if (eCountry == _Country.NL)
                                        iReportRow = 12;
                                    else if (eCountry == _Country.IR || eCountry == _Country.US)
                                        iReportRow = 11;
                                    else
                                        iReportRow = 10;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 16;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 12;
                                    else
                                        iReportRow = 11;
                                }
                                break;
                            case "Reconciliation to Baseline by Plan Def with Breaks":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 18;
                                    else if (eCountry == _Country.NL)
                                        iReportRow = 13;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 12;
                                    else
                                        iReportRow = 11;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 17;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 13;
                                    else
                                        iReportRow = 12;
                                }
                                break;
                            case "Liabilities Detailed Results":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 19;
                                    else if (eCountry == _Country.UK)
                                        iReportRow = 12;
                                    else if (eCountry == _Country.NL)
                                        iReportRow = 14;
                                    else if (eCountry == _Country.IR || eCountry == _Country.US)
                                        iReportRow = 13;
                                    else
                                        iReportRow = 12;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 18;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 14;
                                    else
                                        iReportRow = 13;
                                }
                                break;
                            case "Liabilities Detailed Results with Ben Type splits":
                                bAllValuationSet = false;
                                iReportRow = 13;
                                break;
                            case "Liabilities Detailed Results with Breaks":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 20;
                                    else if (eCountry == _Country.US || eCountry == _Country.UK)
                                        iReportRow = 14;
                                    else if (eCountry == _Country.NL)
                                        iReportRow = 15;
                                    else
                                        iReportRow = 13;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 19;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 14;
                                    else
                                        iReportRow = 14;
                                }
                                break;
                            case "Liabilities Detailed Results with Breaks & Ben Type splits":
                                bAllValuationSet = false;
                                iReportRow = 15;
                                break;
                            case "Liabilities Detailed Results by Plan Def":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 21;
                                    else if (eCountry == _Country.NL)
                                        iReportRow = 16;
                                    else if (eCountry == _Country.IR || eCountry == _Country.US)
                                        iReportRow = 15;
                                    else
                                        iReportRow = 14;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 20;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 16;
                                    else
                                        iReportRow = 15;
                                }
                                break;
                            case "Liabilities Detailed Results by Plan Def with Breaks":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 22;
                                    else if (eCountry == _Country.NL)
                                        iReportRow = 17;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 16;

                                    else
                                        iReportRow = 15;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 21;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 17;
                                    else
                                        iReportRow = 16;
                                }
                                break;
                            case "Funding Calculator - Checking Spreadsheet":
                                bAllValuationSet = false;
                                iReportRow = 17;
                                break;
                            case "Funding Calculator - Consulting Spreadsheet":
                                bAllValuationSet = false;
                                iReportRow = 18;
                                break;
                            case "Liability Set for FSM Export":
                                bAllValuationSet = false;
                                iReportRow = 17;
                                break;
                            case "Liability Set for Globe Export":
                                {
                                    bAllValuationSet = false;

                                    if (bFunding)
                                    {
                                        if (eCountry == _Country.DE)
                                            iReportRow = 23;
                                        else
                                            iReportRow = 17;
                                    }
                                    else
                                    {
                                        if (eCountry == _Country.DE)
                                            iReportRow = 22;
                                        else if (eCountry == _Country.US)
                                            iReportRow = 18;
                                        else
                                            iReportRow = 17;
                                    }
                                    break;
                                }

                            case "Globe Export with Breaks and Multiple Nodes":
                                {
                                    bAllValuationSet = false;
                                    if (bFunding)
                                    {
                                        if (eCountry == _Country.DE)
                                            iReportRow = 23;
                                        else
                                            iReportRow = 18;
                                    }
                                    else
                                    {
                                        if (eCountry == _Country.DE)
                                            iReportRow = 23;
                                        else
                                            iReportRow = 18;
                                    }
                                    break;
                                }

                            case "Direct Promise":
                            case "Jubilee":
                                bAllValuationSet = false;
                                if (bFunding)
                                    if (eCountry == _Country.DE)
                                        iReportRow = 26;
                                    else
                                        iReportRow = 25;
                                else
                                    iReportRow = 25;
                                break;
                            case "Support Fund":
                                bAllValuationSet = false;
                                if (bFunding)
                                    iReportRow = 26;
                                break;
                            case "IFRS":
                                bAllValuationSet = false;
                                if (bFunding)
                                    iReportRow = 28;
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 26;
                                    else
                                        iReportRow = 25;
                                }
                                break;
                            case "Funding Calculator":
                                bAllValuationSet = false;
                                if (eCountry == _Country.CA)
                                    iReportRow = 17;
                                else if (eCountry == _Country.US)
                                    iReportRow = 19;
                                else
                                    iReportRow = 18;
                                break;
                            case "Special Payment Calculation":
                                bAllValuationSet = false;
                                if (eCountry == _Country.CA)
                                    iReportRow = 18;
                                break;
                            case "ASC 960 Reconciliation":
                                bAllValuationSet = false;
                                iReportRow = 19;
                                if (eCountry == _Country.US)
                                    iReportRow = 20;
                                break;
                            case "Future Valuation Population Projection":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.UK)
                                        iReportRow = 20;
                                    else if (eCountry == _Country.DE)
                                        iReportRow = 31;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 22;
                                    else
                                        iReportRow = 21;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 29;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 20;
                                    else
                                        iReportRow = 19;
                                }
                                break;

                            case "Future Valuation Individual Population Projection":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    iReportRow = 32;
                                }
                                else
                                {
                                    iReportRow = 30;
                                }
                                break;

                            case "Future Valuation Summary":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.UK)
                                        iReportRow = 21;
                                    else if (eCountry == _Country.DE)
                                        iReportRow = 33;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 23;
                                    else
                                        iReportRow = 22;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 31;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 21;
                                    else
                                        iReportRow = 20;
                                }
                                break;
                            case "Future Valuation Individual Output":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.UK)
                                        iReportRow = 22;
                                    else if (eCountry == _Country.DE)
                                        iReportRow = 35;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 24;
                                    else
                                        iReportRow = 23;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 33;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 22;
                                    else
                                        iReportRow = 21;
                                }
                                break;
                            case "Future Valuation Parameter Print":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.UK)
                                        iReportRow = 23;
                                    else if (eCountry == _Country.DE)
                                        iReportRow = 36;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 25;
                                    else
                                        iReportRow = 24;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 34;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 23;
                                    else
                                        iReportRow = 22;
                                }
                                break;
                            case "Future Valuation Payouts":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.UK)
                                        iReportRow = 24;
                                    else if (eCountry == _Country.DE)
                                        iReportRow = 38;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 26;
                                    else
                                        iReportRow = 25;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 36;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 24;
                                    else
                                        iReportRow = 23;
                                }
                                break;
                            case "Future Valuation Liabilities Detailed Results":
                                bAllValuationSet = false;
                                iReportRow = 25;
                                break;
                            case "Funding Update Results Summary":
                                bAllValuationSet = false;
                                iReportRow = 26;
                                break;
                            case "Future Valuation Data Export":
                                bAllValuationSet = false;
                                if (bFunding)
                                    iReportRow = 26;

                                else if (eCountry == _Country.US)
                                    iReportRow = 25;
                                else
                                    iReportRow = 24;
                                break;
                            case "Future Valuation Liabilities by Group":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 40;

                                    else if (eCountry == _Country.US)
                                        iReportRow = 28;

                                    else
                                        iReportRow = 27;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 38;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 26;
                                    else
                                        iReportRow = 25;
                                }
                                break;
                            case "Future Valuation Liabilities by Year":
                                bAllValuationSet = false;
                                if (bFunding)
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 41;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 29;
                                    else
                                        iReportRow = 28;
                                }
                                else
                                {
                                    if (eCountry == _Country.DE)
                                        iReportRow = 39;
                                    else if (eCountry == _Country.US)
                                        iReportRow = 27;
                                    else
                                        iReportRow = 26;
                                }
                                break;
                            case "Plan Aggregation":
                                bAllValuationSet = false;
                                if (bFunding)
                                    iReportRow = 32;
                                else
                                    iReportRow = 28;
                                break;
                            case "Coverage Test":
                                bAllValuationSet = false;
                                if (bFunding)
                                    iReportRow = 33;
                                else
                                    iReportRow = 29;
                                break;
                            case "General Test":
                                bAllValuationSet = false;
                                if (bFunding)
                                    iReportRow = 34;
                                else
                                    iReportRow = 30;
                                break;
                            case "PBGC 4044 Liabilities by Plan Def":
                                bAllValuationSet = false;
                                if (bFunding)
                                    iReportRow = 39;
                                //////else
                                //////    iReportRow = 30;
                                break;

                            default:
                                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReport + ">. Please Verify!");
                                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReport + ">. Please Verify!");
                                break;

                        }


                        break;
                    }
                #endregion

                default:
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail: Invalid Category Name: <" + sConversion_RollForward + ">. Only <Conversion> or <RollForward> is accetable and Case Sensitive!");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail: Invalid Category Name: <" + sConversion_RollForward + ">. Only <Conversion> or <RollForward> is accetable and Case Sensitive!");
                    break;
            }


            // scroll down
            if (iReportRow > 27)
                _gLib._SetSyncUDWin("wVerticalScrollBar", this.wRetirementStudio.wVerticalScrollBar.pagedownButton, "Click", Config.iTimeout / 3, false, 6, 50);
            iPosY = iReportRow * iStepY + iStepY / 2;



            if (bAllValuationSet)
                Mouse.Click(this.wRetirementStudio.wAllValuationSets_FPGrid.grid, new Point(iPosX, iPosY));
            else
                Mouse.Click((UITestControl)this.wRetirementStudio.wSelectedValuationSets_FPGrid.grid, new Point(iPosX, iPosY));



            // if (bAllValuationSet)
            //    _gLib._SetSyncUDWin("Output Manager View", this.wRetirementStudio.wAllValuationSets_FPGrid.grid, "Click", Config.iTimeout / 3, false, iPosX, iPosY);
            ////////Mouse.Click(this.wRetirementStudio.wAllValuationSets_FPGrid.grid, new Point(iPosX, iPosY));
            //else
            //    ///////Mouse.Click(this.wRetirementStudio.wSelectedValuationSets_FPGrid.grid, new Point(iPosX, iPosY));
            //    _gLib._SetSyncUDWin("Output Manager View", this.wRetirementStudio.wSelectedValuationSets_FPGrid.grid, "Click", Config.iTimeout / 3, false, iPosX, iPosY);

        }


        /// <summary>
        /// 2013-May-16
        /// webber.ling@mercer.com
        /// 
        /// pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Member Statistics", "Conversion", true, true);
        /// pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Test Case List", "Conversion", true, true);
        /// pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Detailed Results", "Conversion", true, true);
        /// pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Detailed Results by Plan Def", "Conversion", false, true);
        /// pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Valuation Summary", "Conversion", true, true);
        /// pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_MatchWithRSData, "Liabilities Detailed Results", "Conversion", true, true);
        /// pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_MatchWithRSData, "Liabilities Detailed Results by Plan Def", "Conversion", true, true);
        /// pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Funding Calculator Scenario", "RollForward", true, true);
        /// pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results with Breaks", "RollForward", true, true);
        /// pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Liabilities Detailed Results by Plan Def with Breaks", "RollForward", false, true);
        /// pOutputManager._ExportReport_Common(sOutputFunding_Valuation2012_UpdateAssumptionDates, "ASC 960 Reconciliation", "RollForward", true, true);
        /// 
        /// 
        /// 
        /// pOutputManager._ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Valuation Summary", "Rollforward", true);
        /// </summary>
        /// <param name=""></param>
        /// 
        public void _ExportReport_Common(string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            this._ExportReport_Common(_Country.US, sReportDirctory, sReportName, sConversion_RollForward, bPDFTrue_ExcelFalse, bFunding);
        }

        public void _ExportReport_Common(_Country eCountry, string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            string sFunctionName = "_ExportReport_Common";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export report: " + sReportName);


            string sFileName = sReportDirctory + sReportName.Replace(" ", "").Replace("/", "");

            if (bPDFTrue_ExcelFalse)
                sFileName = sFileName + ".pdf";
            else
                sFileName = sFileName + ".xlsx";

            this._SelectTab("Output Manager");

            this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);

            this._SelectTab(sReportName);

            this._WaitForLoading();


            this._ExportItem(eCountry, sReportName, bPDFTrue_ExcelFalse);

            this._SaveAs(sFileName);

            _gLib._FileExists(sFileName, iTimeout_downloadFile, true);

            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finished exporting report: " + sReportName);



        }


        /// <summary>
        /// 2013-May-16
        /// webber.ling@mercer.com
        /// 
        /// pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Liability Summary", "Conversion", true, true);
        /// pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Conversion Diagnostic", "Conversion", true, true);
        /// pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "IOE", "Conversion", false, true);
        /// pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Parameter Print", "Conversion", true, true);
        /// pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Test Cases", "Conversion", true, true);
        /// pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Payout Projection", "Conversion", true, true);
        /// pOutputManager._ExportReport_Others(sOutputFunding_Conversion2011_Baseline, "Payout Projection", "Conversion", false, true);
        /// pOutputManager._ExportReport_Others(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Funding Calculator", "RollForward", false, true);
        /// pOutputManager._ExportReport_Others(@"C:\Users\webber-ling\Desktop\QA1_20151229.1\Client\", "Direct Promise", "RollForward", true, true);
        /// pOutputManager._ExportReport_Others(@"C:\Users\webber-ling\Desktop\QA1_20151229.1\Client\", "IFRS", "RollForward", true, true);
        /// 
        /// </summary>
        /// <param name=""></param>
        public void _ExportReport_Others(string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            this._ExportReport_Others(_Country.US, sReportDirctory, sReportName, sConversion_RollForward, bPDFTrue_ExcelFalse, bFunding);
        }


        public void _ExportReport_Others(_Country eCountry, string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            string sFunctionName = "_ExportReport_Others";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export report: " + sReportName);


            string sFileName = sReportDirctory + sReportName.Replace(" ", "").Replace("/", "");

            if (bPDFTrue_ExcelFalse)
                sFileName = sFileName + ".pdf";
            else
                sFileName = sFileName + ".xlsx";

            if (sReportName == "Test Cases" || sReportName == "Direct Promise" || sReportName == "Jubilee" || sReportName == "IFRS")
                sFileName = sFileName.Replace("pdf", "zip").Replace("xls", "zip");


            this._SelectTab("Output Manager");

            this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);



            switch (sReportName)
            {
                case "Data Comparison":
                case "Gain / Loss Participant Listing":
                    break;
                case "Liability Summary":
                case "Individual Checking Template":
                case "Member Statistics": // this is for CA Funding RollForward only
                case "Liability Set for Globe Export":
                case "Detailed Results with Ben Type splits":
                case "Liabilities Detailed Results with Ben Type splits":
                case "Future Valuation Liabilities Detailed Results":
                    {

                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._WaitForLoading();
                        break;
                    }
                case "Coverage Test":
                case "General Test":
                    {

                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                        break;
                    }
                case "Payout Projection":
                case "Payout Projection - Benefit Cashflows":
                case "Payout Projection - Other Info":
                    {
                        if (sReportName.Equals("Payout Projection - Benefit Cashflows"))
                            this._SelectTab("Benefit Cashflows");
                        else if (sReportName.Equals("Payout Projection - Other Info"))
                            this._SelectTab("Other Info");
                        else
                            this._SelectTab(sReportName);

                        #region for CA country and Funding
                        if (eCountry == _Country.CA && bFunding)
                        {

                            ///// Next checkbox name must be correct ,and you can add anyone you needed
                            string[] sName = { "Going Concern Liability", "Solvency Liability", "Wind-Up Liability" };

                            for (int i = 0; i < sName.Length; i++)
                            {
                                string sTempFileName = sFileName;

                                this.wRetirementStudio.wChklbLiabilities.wList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, sName[i]);

                                if (_gLib._Exists(sName[i], this.wRetirementStudio.wChklbLiabilities.wList.chk, 1, false))
                                {
                                    _gLib._SetSyncUDWin("", this.wRetirementStudio.wChklbLiabilities.wList.chk, "true", 0);

                                    _gLib._SetSyncUDWin("Group - None", this.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                                    _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);


                                    this._WaitForLoading();
                                    this._ExportItem(sReportName, bPDFTrue_ExcelFalse);


                                    if (bPDFTrue_ExcelFalse)
                                        sTempFileName = sTempFileName.Replace(".pdf", "_" + sName[i].Replace(" ", "") + ".pdf").Replace("Liability.pdf", ".pdf");
                                    else
                                        sTempFileName = sTempFileName.Replace(".xlsx", "_" + sName[i].Replace(" ", "") + ".xlsx").Replace("Liability.xlsx", ".xlsx");


                                    this._SaveAs(sTempFileName);
                                    _gLib._FileExists(sTempFileName, iTimeout_downloadFile, true);

                                    _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);

                                }
                            }
                            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                            return;
                        }
                        #endregion

                        _gLib._SetSyncUDWin("Group - None", this.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                        break;
                    }
                case "Conversion Diagnostic":
                    {

                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        _gLib._SetSyncUDWin("Group - None", this.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                        break;
                    }
                case "Individual Output":
                    {
                        this._SelectTab("Individual Output");

                        _gLib._SetSyncUDWin("Group - None", this.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        break;
                    }
                case "IOE":
                    {
                        this._SelectTab("Individual Output");
                        _gLib._SetSyncUDWin("Group - None", this.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        break;
                    }
                case "Test Cases":
                    {
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("ExportAllToExcel", this.wRetirementStudio.wExportAlltoExcel.txtExportAlltoExcel.linkExportAlltoExcel, "Click", 0);
                        break;
                    }
                case "Direct Promise":
                case "Jubilee":
                case "IFRS":
                    {
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("ExportAllToExcel", this.wRetirementStudio.wExportAllCombinedReport.txt.link, "Click", 0);
                        break;
                    }
                case "2D Payout Projections":
                    {
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("ExportAllToExcel", this.wRetirementStudio.wExportAllCombinedReport.txt.link, "Click", 0);
                        break;
                    }
                case "Parameter Print":
                case "Parameter Summary":
                case "Future Valuation Parameter Print":
                    {
                        //////MyDictionary dicTmp = new MyDictionary();
                        //////dicTmp.Clear();
                        //////dicTmp.Add("Level_1", "File");
                        //////dicTmp.Add("Level_2", "Save As");
                        //////dicTmp.Add("Level_3", "PDF");
                        //////_gLib._MenuSelectWin(0, this.wAdobe.wMenuBar, dicTmp);

                        while (_gLib._Exists("Parameter Print Wait Process Dialog", this.wWaitDialog.wOK.btn, 3, false))
                        {
                            _gLib._SetSyncUDWin("Parameter Print Wait Process Dialog - OK", this.wWaitDialog.wOK.btn, "click", 0);
                            _gLib._Wait(8);

                            this._SelectTab("Output Manager");
                            this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);
                        }


                        do
                        {
                            try
                            {
                                _gLib._SetSyncUDWin("Adobe", this.wAdobe.wTitleBar, "Click", Config.iTimeout / 3);

                                for (int i = 0; i < Config.iTimeout; i++)
                                    if (_gLib._Exists("Adobe Content Preparation", this.wAdobeContentPreparation, 1, false))
                                        _gLib._Wait(2);
                                    else
                                        break;
                                //////Mouse.Click(this.wAdobe.wTitleBar, new Point(400, 8));
                                Keyboard.SendKeys(this.wAdobe.wPage.clientPage.wPageView, "S", (ModifierKeys.Control | ModifierKeys.Shift));
                            }
                            catch (Exception ex)
                            { }
                        } while (!_gLib._Exists("Save As", this.wSaveAs, 5, false));

                        break;
                    }
                case "Funding Calculator":
                case "Funding Update Results Summary":
                case "Special Payment Calculation":
                    {
                        if (bPDFTrue_ExcelFalse)
                        {
                            break;
                        }
                        else
                        {
                            sFileName = sFileName.Replace(".xlsx", ".xlsx");
                            this._Excel_SaveFile(sFileName);
                            return;
                        }
                    }

                case "Funding Calculator - Checking Spreadsheet":
                case "Funding Calculator - Consulting Spreadsheet":
                    {
                        if (bPDFTrue_ExcelFalse)
                            break;

                        else
                        {
                            sFileName = sFileName.Replace(".xlsx", ".xlsm");
                            this._Excel_SaveFile(sFileName);

                            return;
                        }
                    }

                case "Data Request":
                    {
                        /// setting and download report 

                        return;
                    }


                case "Globe Export with Breaks and Multiple Nodes":
                    {
                        /// setting and download report 

                        break;
                    }



                default:
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReportName + ">. Please Verify!");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReportName + ">. Please Verify!");
                    break;
            }





            switch (sReportName)
            {
                case "Individual Output":
                    {
                        this._SelectTab(sReportName);
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        break;
                    }
                case "IOE":
                    {


                        if (_gLib._Exists("NewIOEParameters1", this.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, Config.iTimeout / 30, false))
                            _gLib._SetSyncUDWin("NewIOEParameters1", this.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, "Click", 0);
                        else
                        {
                            //Mouse.Click(this.wRetirementStudio.tvNaviTree.tviIndividualOutput, MouseButtons.Right, ModifierKeys.None, new Point(Config.iClickPos_X, Config.iClickPos_Y));
                            dic.Clear();
                            dic.Add("Level_1", "Individual Output");
                            _gLib._TreeViewSelectWin(0, this.wRetirementStudio.tvNaviTree, dic);

                            dic.Clear();
                            dic.Add("Level_1", "Individual Output");
                            dic.Add("MenuItem", "Add IOE Parameters");
                            _gLib._TreeViewRightSelectWin(0, this.wRetirementStudio.tvNaviTree.tviIndividualOutput, dic, false);
                        }

                        _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);

                        break;
                    }
                case "Parameter Print":
                case "Parameter Summary":
                case "Future Valuation Parameter Print":
                case "Test Cases":
                case "Direct Promise":
                case "Jubilee":
                case "IFRS":
                case "Data Comparison":
                case "Gain / Loss Participant Listing":
                case "Payout Projection - Benefit Cashflows":
                case "Payout Projection - Other Info":
                    break;
                case "Individual Checking Template":
                    {
                        #region
                        // Movement and Roll Froward Report

                        this._WaitForLoading();
                        _gLib._SetSyncUDWin("Movement and Roll Froward Report", this.wRetirementStudio.wSubTab.tabMovementandRollForward, "Click", 0);
                        this._WaitForLoading();

                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_MovementAndRollforward.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_MovementAndRollforward.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_MovementAndRollforward.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_MovementAndRollforward.xlsx"), iTimeout_downloadFile, true);
                        }


                        // Outlier Summary

                        this._WaitForLoading();
                        _gLib._SetSyncUDWin("Outlier Summary", this.wRetirementStudio.wSubTab.tabOutlierSummary, "Click", 0);
                        this._WaitForLoading();

                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_OutlierSummary.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_OutlierSummary.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_OutlierSummary.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_OutlierSummary.xlsx"), iTimeout_downloadFile, true);
                        }

                        // Checking Group Statistics

                        this._WaitForLoading();
                        _gLib._SetSyncUDWin("Checking Group Statistics", this.wRetirementStudio.wSubTab.tabCheckingGroupStatistics, "Click", 0);

                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CheckingGroupStatistics.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CheckingGroupStatistics.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CheckingGroupStatistics.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CheckingGroupStatistics.xlsx"), iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                        return;
                        #endregion
                    }
                case "General Test":
                    {
                        #region
                        this._SelectTab("General Test Summary");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_GeneralTestSummary.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_GeneralTestSummary.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_GeneralTestSummary.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_GeneralTestSummary.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                        this._SelectTab("Current Testing for each HCE");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CurrentTestingforEachHCE.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentTestingforEachHCE.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CurrentTestingforEachHCE.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentTestingforEachHCE.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                        this._SelectTab("Current and Prior Testing for each HCE");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CurrentAndPriorTestingforEachHCE.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentAndPriorTestingforEachHCE.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CurrentAndPriorTestingforEachHCE.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentAndPriorTestingforEachHCE.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



                        this._SelectTab("Current, Prior and Future Testing for each HCE");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CurrentPriorAndFutureTestingforEachHCE.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentPriorAndFutureTestingforEachHCE.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CurrentPriorAndFutureTestingforEachHCE.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentPriorAndFutureTestingforEachHCE.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



                        this._SelectTab("Current Testing Accrual Rates");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CurrentTestingAccrualRates.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentTestingAccrualRates.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CurrentTestingAccrualRates.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentTestingAccrualRates.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



                        this._SelectTab("Current and Prior Testing Accrual Rates");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CurrentAndPriorTestingAccrualRates.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentAndPriorTestingAccrualRates.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CurrentAndPriorTestingAccrualRates.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentAndPriorTestingAccrualRates.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



                        this._SelectTab("Current, Prior and Future Testing Accrual Rates");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CurrentPriorAndFutureTestingAccrualRates.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentPriorAndFutureTestingAccrualRates.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CurrentPriorAndFutureTestingAccrualRates.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentPriorAndFutureTestingAccrualRates.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                        this._SelectTab("General Test");
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                        #endregion
                        return;
                    }
                default:
                    {

                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);

                    }
                    break;
            }


            this._SaveAs(sFileName);

            if (!bPDFTrue_ExcelFalse)
            {
                switch (sReportName)
                {
                    case "IOE":
                    case "Data Comparison":
                    case "Gain / Loss Participant Listing":
                        {
                            _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                            break;
                        }

                    default:
                        break;
                }

            }
            _gLib._FileExists(sFileName, iTimeout_downloadFile, true);


            switch (sReportName)
            {
                case "Parameter Print":
                case "Parameter Summary":
                case "Future Valuation Parameter Print":
                    {
                        for (int i = 0; i < Config.iTimeout; i++)
                        {
                            if (_gLib._Exists("Adobe Content Preparation", this.wAdobeContentPreparation, 1, false))
                            {
                                _gLib._Wait(2);
                            }
                            else
                            {
                                _gLib._SetSyncUDWin("Adobe", this.wAdobe.wTitleBar, "Click", Config.iTimeout / 5);
                                _gLib._SetSyncUDWin("Adobe - Close", this.wAdobe.wTitleBar.btnClose, "Click", 0);
                                //////if (_gLib._Exists("Adobe", this.wAdobe.wTitleBar.btnClose, 1, false))
                                //////    _gLib._SetSyncUDWin("Adobe - Close", this.wAdobe.wTitleBar.btnClose, "Click", 0);
                                break;
                            }
                        }
                        break;
                    }
                case "Data Comparison":
                case "Gain / Loss Participant Listing":
                    break;
                default:
                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                    break;
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finished exporting report: " + sReportName);

        }


        /// <summary>
        /// 2013-May-18
        /// webber.ling@mercer.com
        /// 
        /// pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Liability Scenario", "RollForward", true, true);
        /// pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2013_ForAFN2012, "Liability Scenario by Plan Def", "RollForward", false, true);
        /// pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_Baseline, "Reconciliation to Prior Year", "RollForward", true, true);
        /// pOutputManager._ExportReport_SubReports(sOutputFunding_Conversion2011_Baseline, "Reconciliation to Baseline", "Conversion", true, true);
        /// pOutputManager._ExportReport_SubReports(sOutputFunding_Conversion2011_Baseline, "Reconciliation to Baseline by Plan Def", "Conversion", false, true);
        /// pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline", "RollForward", true, true);
        /// pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline with Breaks", "RollForward", true, true);
        /// pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline by Plan Def", "RollForward", false, true);
        /// pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_UpdateAssumptionDates, "Reconciliation to Baseline by Plan Def with Breaks", "RollForward", false, true);
        /// pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Liability Scenario", "RollForward", true, true);
        /// pOutputManager._ExportReport_SubReports(sOutputFunding_Valuation2012_ForAFTAPRange, "Liability Scenario by Plan Def", "RollForward", false, true);
        ///
        /// pOutputManager._ExportReport_SubReports(Config.eCountry, @"C:\Users\webber-ling\Desktop\QA1_20151229.1\Client\", "IFRS", "RollForward", true, true);
        /// pOutputManager._ExportReport_SubReports(Config.eCountry, @"C:\Users\webber-ling\Desktop\QA1_20151229.1\Client\", "Direct Promise", "RollForward", true, true);
        /// pOutputManager._ExportReport_SubReports(Config.eCountry, @"C:\Users\webber-ling\Desktop\QA1_20151229.1\Client\", "Support Fund", "RollForward", true, true);
        /// pOutputManager._ExportReport_SubReports(Config.eCountry, @"C:\Users\webber-ling\Desktop\QA1_20160107.1\Client\", "Jubilee", "RollForward", true, false);
        /// pOutputManager._ExportReport_SubReports(Config.eCountry, @"C:\Users\webber-ling\Desktop\QA1_20160107.1\Client\", "IFRS", "RollForward", true, false, true);
        /// 
        /// </summary>
        /// <param name=""></param>
        ///                
        public void _ExportReport_SubReports(string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            this._ExportReport_SubReports(_Country.US, sReportDirctory, sReportName, sConversion_RollForward, bPDFTrue_ExcelFalse, bFunding);
        }

        public void _ExportReport_SubReports(_Country eCountry, string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            this._ExportReport_SubReports(eCountry, sReportDirctory, sReportName, sConversion_RollForward, bPDFTrue_ExcelFalse, bFunding, false);
        }

        public void _ExportReport_SubReports(_Country eCountry, string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding, Boolean bAR_DuplicatedLinkText)
        {
            string sFunctionName = "_ExportReport_SubReports";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export report: " + sReportName);

            string sSubReport_TabName;
            string sFileName;
            string sPostFix;

            if (bPDFTrue_ExcelFalse)
                sPostFix = ".pdf";
            else
                sPostFix = ".xlsx";

            this._SelectTab("Output Manager");

            this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);
            this._SelectTab(sReportName);


            WinWindow wWin = new WinWindow(this.wRetirementStudio);
            wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.STATIC", PropertyExpressionOperator.Contains);
            UITestControlCollection uiCollection = wWin.FindMatchingControls();


            int iAR_DuplicatedLinkText = 1;

            for (int i = 0; i < uiCollection.Count; i++)
            {
                this._SelectTab(sReportName);
                WinText wText = new WinText((WinWindow)uiCollection[i]);

                if (wText.Name == "Select Liability Run" || wText.Name == "")
                {
                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                    return;
                }
                else if (wText.Name.Contains(":") || wText.Name.Contains("Select Report") || wText.Name.Equals("Direct Promise") || wText.Name.Equals("Support Fund") || (wText.Name.Equals("IFRS") & iAR_DuplicatedLinkText == 1) || wText.Name.Equals("Jubilee"))// || wText.Name.Contains("Click on the Status Code to change it.")
                {
                    if (!wText.Name.Equals("IFRS"))
                        continue;

                    if (bAR_DuplicatedLinkText & wText.Name.Equals("IFRS") & iAR_DuplicatedLinkText == 1)
                    {
                        iAR_DuplicatedLinkText++;
                        continue;
                    }

                }
                else
                {
                    wText.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);
                    WinHyperlink wLink = new WinHyperlink(wText);
                    wLink.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

                    _gLib._SetSyncUDWin(wLink.Name, wLink, "Click", 0);


                    sFileName = sReportDirctory + sReportName.Replace(" ", "").Replace("/", "") + "_" + wLink.Name.Replace("_", "") + sPostFix;


                    switch (sReportName)
                    {
                        case "Gain / Loss Participant Listing":
                        case "Liability Comparison":
                            break;
                        case "Reconciliation to Prior Year":
                        case "Reconciliation to Prior Year with Breaks":
                        case "Reconciliation to Prior Year by Plan Def":
                        case "Reconciliation to Prior Year by Plan Def with Breaks":
                        case "Reconciliation to Baseline":
                        case "Reconciliation to Baseline with Breaks":
                        case "Reconciliation to Baseline by Plan Def":
                        case "Reconciliation to Baseline by Plan Def with Breaks":
                        case "Gain / Loss Summary of Liability Reconciliation":
                        case "Gain / Loss Status Reconciliation":
                        case "Decrement Gain / Loss Detail":
                        case "Active Decrement Gain / Loss Detail":
                            {
                                if (bFunding)
                                    sSubReport_TabName = sReportName + " - " + wLink.Name.Replace("_", " ");
                                else
                                    sSubReport_TabName = sReportName + " - " + "FAS 87 " + wLink.Name.Replace("_", " ");

                                if (wLink.Name.Equals("GoingConcern"))
                                    sSubReport_TabName = sReportName + " - Going Concern";
                                if (wLink.Name.Equals("Tax"))
                                    sSubReport_TabName = sReportName + " - Tax";
                                if (wLink.Name.Equals("Trade"))
                                    sSubReport_TabName = sReportName + " - Trade";
                                if (wLink.Name.Equals("IntlAccountingPBO"))
                                    sSubReport_TabName = sReportName + " - Intl Accounting PBO";
                                if (wLink.Name.Equals("IntlAccountingABO"))
                                    sSubReport_TabName = sReportName + " - Intl Accounting ABO";

                                this._SelectTab(sSubReport_TabName);
                                ////_gLib._Enabled("Toolbar", this.wRetirementStudio.wToolbar.miExport, Config.iTimeout);
                                this._WaitForLoading();
                                _gLib._Enabled("Toolbar", this.wRetirementStudio.wToolbar.miExport, Config.iTimeout);
                                this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                                break;
                            }
                        case "Liability Scenario":
                        case "Liability Scenario with Breaks":
                        case "Liability Scenario by Plan Def":
                        case "Liability Scenario by Plan Def with Breaks":
                            {
                                if (bFunding)
                                    sSubReport_TabName = sReportName + " - " + wLink.Name.Replace("_", " ");
                                else
                                    sSubReport_TabName = sReportName + " - " + "FAS 87 " + wLink.Name.Replace("_", " ");

                                if (wLink.Name.Equals("GoingConcern"))
                                    sSubReport_TabName = sReportName + " - Going Concern";
                                if (wLink.Name.Equals("Tax"))
                                    sSubReport_TabName = sReportName + " - Tax";
                                if (wLink.Name.Equals("Trade"))
                                    sSubReport_TabName = sReportName + " - Trade";
                                if (wLink.Name.Equals("IntlAccountingPBO"))
                                    sSubReport_TabName = sReportName + " - Intl Accounting PBO";
                                if (wLink.Name.Equals("IntlAccountingABO"))
                                    sSubReport_TabName = sReportName + " - Intl Accounting ABO";

                                this._SelectTab(sSubReport_TabName);
                                this._WaitForLoading();
                                _gLib._Enabled("Toolbar", this.wRetirementStudio.wToolbar.miExport, Config.iTimeout);
                                this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                                break;
                            }
                        case "Direct Promise":
                        case "Support Fund":
                        case "Jubilee":
                        case "IFRS":
                            {
                                sSubReport_TabName = sReportName + " - " + wLink.Name.Replace("_", " ");

                                this._SelectTab(sSubReport_TabName);

                                _gLib._SetSyncUDWin("ExportAllCombinedReports", this.wRetirementStudio.wExportAllCombinedReports.txt.link, "Click", 0);


                                sFileName = sReportDirctory + "AR_" + sSubReport_TabName.Replace(" ", "").Replace("-", "_") + ".zip";



                                break;
                            }
                        default:
                            {
                                sSubReport_TabName = sReportName + " - " + wLink.Name.Replace("_", " ");

                                if (wLink.Name.Equals("GoingConcern"))
                                    sSubReport_TabName = sReportName + " - Going Concern";

                                this._SelectTab(sSubReport_TabName);
                                ////_gLib._Enabled("Toolbar", this.wRetirementStudio.wToolbar.miExport, Config.iTimeout);
                                this._WaitForLoading();
                                _gLib._Enabled("Toolbar", this.wRetirementStudio.wToolbar.miExport, Config.iTimeout);
                                this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                                break;
                            }
                    }



                    this._SaveAs(sFileName);


                    switch (sReportName)
                    {
                        case "Gain / Loss Participant Listing":
                        case "Liability Comparison":
                            _gLib._SetSyncUDWin("Extract Successfully Created - OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                            break;
                        default:
                            break;
                    }


                    _gLib._FileExists(sFileName, iTimeout_downloadFile, true);

                    switch (sReportName)
                    {
                        case "Gain / Loss Participant Listing":
                        case "Liability Comparison":
                            break;
                        default:
                            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                            break;
                    }

                }



            }


            this._SelectTab(sReportName);
            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finished exporting report: " + sReportName);


        }



        /// <summary>
        /// 2013-Sep-18
        /// webber.ling@mercer.com
        /// 
        /// pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2011_MatchWithRSData, "Liability Summary", "Conversion", true, true, 0);
        /// pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2011_MatchWithRSData, "Conversion Diagnostic", "Conversion", true, true, 0);
        /// 
        /// pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2011_MatchWithRSData, "Liability Summary", "Conversion", true, false, 0);
        /// pOutputManager._ExportReport_DrillDown(sOutputFunding_Conversion2011_MatchWithRSData, "Conversion Diagnostic", "Conversion", true, false, 0);
        /// 
        /// </summary>
        /// <param name=""></param>
        public void _ExportReport_DrillDown(string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding, int optiLiabSummary_RowNumber_Active)
        {
            string[] sl = new string[100];
            this._ExportReport_DrillDown(_Country.US, sReportDirctory, sReportName, sConversion_RollForward, bPDFTrue_ExcelFalse, bFunding, optiLiabSummary_RowNumber_Active, sl);
        }

        public void _ExportReport_DrillDown(_Country eCountry, string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding, int optiLiabSummary_RowNumber_Active, string[] slSubNames)
        {
            string sFunctionName = "_ExportReport_DrillDown";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export drill down reports: " + sReportName);

            string sFileName;
            string sPostFix;

            int iPosX = 80;
            int iPosY = 10000;
            int iStepY = 20;

            if (bPDFTrue_ExcelFalse)
                sPostFix = ".pdf";
            else
                sPostFix = ".xlsx";

            this._SelectTab("Output Manager");

            this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);

            switch (sReportName)
            {

                case "Liability Summary":
                    {
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();


                        /// Active Members
                        sFileName = "LiabilitySummary_ActiveMembers";
                        if (optiLiabSummary_RowNumber_Active == 0)
                            optiLiabSummary_RowNumber_Active = 9;
                        iPosY = optiLiabSummary_RowNumber_Active * iStepY + iStepY / 2;
                        _gLib._SetSyncUDWin("ActiveMember", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                        //////Mouse.Click(this.wRetirementStudio.wReportClient.clientReport, new Point(iPosX, iPosY));
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();
                        _gLib._SetSyncUDWin("GroupByStatusCode", this.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        this._SaveAs(sReportDirctory + sFileName + sPostFix);
                        _gLib._FileExists(sReportDirctory + sFileName + sPostFix, iTimeout_downloadFile, true);

                        /// Deferred Members
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        sFileName = "LiabilitySummary_DeferredMembers";
                        if (optiLiabSummary_RowNumber_Active == 0)
                            optiLiabSummary_RowNumber_Active = 9;
                        iPosY = (optiLiabSummary_RowNumber_Active + 1) * iStepY + iStepY / 2;
                        _gLib._SetSyncUDWin("DeferredMembers", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                        //////Mouse.Click(this.wRetirementStudio.wReportClient.clientReport, new Point(iPosX, iPosY));
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();
                        _gLib._SetSyncUDWin("GroupByStatusCode", this.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        this._SaveAs(sReportDirctory + sFileName + sPostFix);
                        _gLib._FileExists(sReportDirctory + sFileName + sPostFix, iTimeout_downloadFile, true);

                        /// Pensioners
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        sFileName = "LiabilitySummary_Pensioners";
                        if (optiLiabSummary_RowNumber_Active == 0)
                            optiLiabSummary_RowNumber_Active = 9;
                        iPosY = (optiLiabSummary_RowNumber_Active + 2) * iStepY + iStepY / 2;
                        _gLib._SetSyncUDWin("Pensioners", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                        ////////Mouse.Click(this.wRetirementStudio.wReportClient.clientReport, new Point(iPosX, iPosY));
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();
                        _gLib._SetSyncUDWin("GroupByStatusCode", this.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        this._SaveAs(sReportDirctory + sFileName + sPostFix);
                        _gLib._FileExists(sReportDirctory + sFileName + sPostFix, iTimeout_downloadFile, true);

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                        break;
                    }
                case "Conversion Diagnostic":
                    {

                        sFileName = "ConversionDiagnostic_GroupByNone";
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        _gLib._SetSyncUDWin("Group - None", this.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        this._SaveAs(sReportDirctory + sFileName + sPostFix);
                        _gLib._FileExists(sReportDirctory + sFileName + sPostFix, iTimeout_downloadFile, true);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);

                        sFileName = "ConversionDiagnostic_GroupByStatusCodes";
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Group - Status Codes", this.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        this._SaveAs(sReportDirctory + sFileName + sPostFix);
                        _gLib._FileExists(sReportDirctory + sFileName + sPostFix, iTimeout_downloadFile, true);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);

                        sFileName = "ConversionDiagnostic_GroupByCustom_Gender";
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Group - Set Custom", this.wRetirementStudio.wGroup_SetupCustomGrouping.rdSetupCustomGrouping, "True", 0);
                        _gLib._SetSyncUDWin("Group - Gender", this.wRetirementStudio.wCustomGrouping_Major.cboMajor, "Gender", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        this._SaveAs(sReportDirctory + sFileName + sPostFix);
                        _gLib._FileExists(sReportDirctory + sFileName + sPostFix, iTimeout_downloadFile, true);

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                        break;
                    }
                case "Member Statistics":
                case "Valuation Summary":
                case "FAS Expected Benefit Pmts":
                case "Liability Set for Globe Export":
                case "Future Valuation Summary":
                case "Future Valuation Liabilities by Group":
                case "Future Valuation Liabilities by Year":
                    {
                        int iStartY = 120;
                        iStepY = 24;
                         
                        for (int i = 0; i < slSubNames.Length; i++)
                        {
                            // for special purprse
                            if (slSubNames[i] == "")
                                continue;
                        
                            this._WaitForLoading();
                            this._SelectTab(sReportName);
                            //////if (optiLiabSummary_RowNumber_Active == 0)
                            //////    optiLiabSummary_RowNumber_Active = 0;
                            iPosY = iStartY + i * iStepY;
                            //////Mouse.Click(this.wRetirementStudio.wReportClient.clientReport, new Point(iPosX, iPosY));
                            _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                            if (sReportName == "Liability Set for Globe Export")
                                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                            this._SelectTab(sReportName);
                            this._WaitForLoading();
                            this._ExportItem(eCountry, sReportName, bPDFTrue_ExcelFalse);
                            this._SaveAs(sReportDirctory + sReportName.Replace(" ", "") + "_" + slSubNames[i] + sPostFix);
                            _gLib._FileExists(sReportDirctory + sReportName.Replace(" ", "") + "_" + slSubNames[i] + sPostFix, iTimeout_downloadFile, true);
                            _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                            if (sReportName == "Liability Set for Globe Export")
                                _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        }

                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                        break;
                    }
                case "Individual Checking Template":
                    {
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("VO by VO basis", this.wRetirementStudio.wVOGrouping_VObyVObasis.rd, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("All VOs", this.wRetirementStudio.wVOGrouping_FPGrid.grid, "Click", 0, false, 16, 28);


                        for (int i = 0; i < slSubNames.Length; i++)
                        {
                            // Movement and Roll Froward Report
                            this._SelectTab(slSubNames[i]);
                            this._WaitForLoading();
                            _gLib._SetSyncUDWin("Movement and Roll Froward Report", this.wRetirementStudio.wSubTab.tabMovementandRollForward, "Click", 0);
                            this._WaitForLoading();

                            this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                            sFileName = sReportDirctory + sReportName.Replace(" ", "") + "_MovementAndRollforward_" + slSubNames[i];
                            if (bPDFTrue_ExcelFalse)
                                sFileName = sFileName + ".pdf";
                            else
                                sFileName = sFileName + ".xlsx";

                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName, iTimeout_downloadFile, true);


                            // Outlier Summary

                            this._WaitForLoading();
                            _gLib._SetSyncUDWin("Outlier Summary", this.wRetirementStudio.wSubTab.tabOutlierSummary, "Click", 0);
                            this._WaitForLoading();

                            this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                            sFileName = sReportDirctory + sReportName.Replace(" ", "") + "_OutlierSummary_" + slSubNames[i];
                            if (bPDFTrue_ExcelFalse)
                                sFileName = sFileName + ".pdf";
                            else
                                sFileName = sFileName + ".xlsx";

                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName, iTimeout_downloadFile, true);

                            // Checking Group Statistics

                            this._WaitForLoading();
                            _gLib._SetSyncUDWin("Checking Group Statistics", this.wRetirementStudio.wSubTab.tabCheckingGroupStatistics, "Click", 0);

                            this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                            sFileName = sReportDirctory + sReportName.Replace(" ", "") + "_CheckingGroupStatistics_" + slSubNames[i];
                            if (bPDFTrue_ExcelFalse)
                                sFileName = sFileName + ".pdf";
                            else
                                sFileName = sFileName + ".xlsx";

                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName, iTimeout_downloadFile, true);

                            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                        }

                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                        break;

                    }

                default:
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReportName + ">. Please Verify!");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReportName + ">. Please Verify!");
                    break;
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Finish exporting drill down reports: " + sReportName);


        }




        public void _ts_DrillDown_ALL(string sReportDirctory, MyDictionary dic)
        {
            string sFunctionName = "_ts_DrillDown_ALL";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            string sReportName = "";
            string sFileName = "";



            #region Liability Summary

            int iPosX = 80;
            int iPosY = 10000;
            int iStepY = 20;
            int optiLiabSummary_RowNumber_Active = 9;


            #region US/CA Common
            ///// Liability Summary ==> Active Members
            this._SelectTab("Output Manager");
            sReportName = "Liability Summary";
            this._Navigate(Config.eCountry, "Liability Summary", "Conversion", true);

            this._SelectTab(sReportName);
            _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            this._SelectTab(sReportName);
            this._WaitForLoading();
            if (Config.eCountry.Equals(_Country.CA))
                sFileName = "zLiabilitySummary_GoingConcern_ActiveMembers";
            else
                sFileName = "zLiabilitySummary_ActiveMembers";

            iPosY = optiLiabSummary_RowNumber_Active * iStepY + iStepY / 2;
            _gLib._SetSyncUDWin("ActiveMember", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
            _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            this._SelectTab(sReportName);
            this._WaitForLoading();

            this._ts_FromGroupToExport(sReportDirctory, sReportName, sFileName);


            ///// Liability Summary ==> Deferred Members
            this._SelectTab("Output Manager");
            sReportName = "Liability Summary";
            this._Navigate(Config.eCountry, "Liability Summary", "Conversion", true);

            this._SelectTab(sReportName);
            _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            this._SelectTab(sReportName);
            this._WaitForLoading();
            if (Config.eCountry.Equals(_Country.CA))
                sFileName = "zLiabilitySummary_GoingConcern_DeferredMembers";
            else
                sFileName = "zLiabilitySummary_DeferredMembers";

            iPosY = (optiLiabSummary_RowNumber_Active + 1) * iStepY + iStepY / 2;
            _gLib._SetSyncUDWin("DeferredMember", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
            _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            this._SelectTab(sReportName);
            this._WaitForLoading();

            this._ts_FromGroupToExport(sReportDirctory, sReportName, sFileName);


            ///// Liability Summary ==> Pensioners
            this._SelectTab("Output Manager");
            sReportName = "Liability Summary";
            this._Navigate(Config.eCountry, "Liability Summary", "Conversion", true);

            this._SelectTab(sReportName);
            _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            this._SelectTab(sReportName);
            this._WaitForLoading();
            if (Config.eCountry.Equals(_Country.CA))
                sFileName = "zLiabilitySummary_GoingConcern_Pensioners";
            else
                sFileName = "zLiabilitySummary_Pensioners";

            iPosY = (optiLiabSummary_RowNumber_Active + 2) * iStepY + iStepY / 2;
            _gLib._SetSyncUDWin("Pensioners", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
            _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            this._SelectTab(sReportName);
            this._WaitForLoading();

            this._ts_FromGroupToExport(sReportDirctory, sReportName, sFileName);




            #endregion


            if (Config.eCountry.Equals(_Country.CA))
            {

                #region Solvency

                ///// Liability Summary ==> Active Members
                this._SelectTab("Output Manager");
                sReportName = "Liability Summary";
                this._Navigate(Config.eCountry, "Liability Summary", "Conversion", true);

                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                this._SelectTab(sReportName);
                this._WaitForLoading();
                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("NextPage", this.wRetirementStudio.wToolbar_btn.btnNextPage.btn, "Click", 0);
                sFileName = "zLiabilitySummary_Solvency_ActiveMembers";


                iPosY = optiLiabSummary_RowNumber_Active * iStepY + iStepY / 2;
                _gLib._SetSyncUDWin("ActiveMember", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                this._SelectTab(sReportName);
                this._WaitForLoading();

                this._ts_FromGroupToExport(sReportDirctory, sReportName, sFileName);


                ///// Liability Summary ==> Deferred Members
                this._SelectTab("Output Manager");
                sReportName = "Liability Summary";
                this._Navigate(Config.eCountry, "Liability Summary", "Conversion", true);

                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                this._SelectTab(sReportName);
                this._WaitForLoading();
                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("NextPage", this.wRetirementStudio.wToolbar_btn.btnNextPage.btn, "Click", 0);

                sFileName = "zLiabilitySummary_Solvency_DeferredMembers";

                iPosY = (optiLiabSummary_RowNumber_Active + 1) * iStepY + iStepY / 2;
                _gLib._SetSyncUDWin("DeferredMember", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                this._SelectTab(sReportName);
                this._WaitForLoading();

                this._ts_FromGroupToExport(sReportDirctory, sReportName, sFileName);


                ///// Liability Summary ==> Pensioners
                this._SelectTab("Output Manager");
                sReportName = "Liability Summary";
                this._Navigate(Config.eCountry, "Liability Summary", "Conversion", true);

                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                this._SelectTab(sReportName);
                this._WaitForLoading();
                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("NextPage", this.wRetirementStudio.wToolbar_btn.btnNextPage.btn, "Click", 0);
                sFileName = "zLiabilitySummary_Solvency_Pensioners";


                iPosY = (optiLiabSummary_RowNumber_Active + 2) * iStepY + iStepY / 2;
                _gLib._SetSyncUDWin("Pensioners", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                this._SelectTab(sReportName);
                this._WaitForLoading();

                this._ts_FromGroupToExport(sReportDirctory, sReportName, sFileName);

                #endregion

                #region Windup

                ///// Liability Summary ==> Active Members
                this._SelectTab("Output Manager");
                sReportName = "Liability Summary";
                this._Navigate(Config.eCountry, "Liability Summary", "Conversion", true);

                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                this._SelectTab(sReportName);
                this._WaitForLoading();
                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("NextPage", this.wRetirementStudio.wToolbar_btn.btnNextPage.btn, "Click", 0);
                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("NextPage", this.wRetirementStudio.wToolbar_btn.btnNextPage.btn, "Click", 0);
                sFileName = "zLiabilitySummary_Windup_ActiveMembers";


                iPosY = optiLiabSummary_RowNumber_Active * iStepY + iStepY / 2;
                _gLib._SetSyncUDWin("ActiveMember", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                this._SelectTab(sReportName);
                this._WaitForLoading();

                this._ts_FromGroupToExport(sReportDirctory, sReportName, sFileName);


                ///// Liability Summary ==> Deferred Members
                this._SelectTab("Output Manager");
                sReportName = "Liability Summary";
                this._Navigate(Config.eCountry, "Liability Summary", "Conversion", true);

                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                this._SelectTab(sReportName);
                this._WaitForLoading();
                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("NextPage", this.wRetirementStudio.wToolbar_btn.btnNextPage.btn, "Click", 0);
                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("NextPage", this.wRetirementStudio.wToolbar_btn.btnNextPage.btn, "Click", 0);

                sFileName = "zLiabilitySummary_Windup_DeferredMembers";

                iPosY = (optiLiabSummary_RowNumber_Active + 1) * iStepY + iStepY / 2;
                _gLib._SetSyncUDWin("DeferredMember", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                this._SelectTab(sReportName);
                this._WaitForLoading();

                this._ts_FromGroupToExport(sReportDirctory, sReportName, sFileName);


                ///// Liability Summary ==> Pensioners
                this._SelectTab("Output Manager");
                sReportName = "Liability Summary";
                this._Navigate(Config.eCountry, "Liability Summary", "Conversion", true);

                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                this._SelectTab(sReportName);
                this._WaitForLoading();
                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("NextPage", this.wRetirementStudio.wToolbar_btn.btnNextPage.btn, "Click", 0);
                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("NextPage", this.wRetirementStudio.wToolbar_btn.btnNextPage.btn, "Click", 0);

                sFileName = "zLiabilitySummary_Windup_Pensioners";


                iPosY = (optiLiabSummary_RowNumber_Active + 2) * iStepY + iStepY / 2;
                _gLib._SetSyncUDWin("Pensioners", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                this._SelectTab(sReportName);
                this._WaitForLoading();

                this._ts_FromGroupToExport(sReportDirctory, sReportName, sFileName);

                #endregion
            }


            #endregion


            #region Conversion Diagnostics


            this._SelectTab("Output Manager");
            sReportName = "Conversion Diagnostic";
            this._Navigate(Config.eCountry, "Conversion Diagnostic", "Conversion", true);
            this._SelectTab(sReportName);
            _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            sFileName = "zConversionDiagnostic";
            this._SelectTab(sReportName);
            this._ts_FromGroupToExport(sReportDirctory, sReportName, sFileName);

            #endregion


            #region Valuation Summary

            this._SelectTab("Output Manager");
            sReportName = "Valuation Summary";
            this._Navigate(Config.eCountry, "Valuation Summary", "Conversion", true);
            this._SelectTab(sReportName);
            this._WaitForLoading();
            if (Config.eCountry.Equals(_Country.US))
                _gLib._SetSyncUDWin("ZeroLiabilities", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 338, 685);
            if (Config.eCountry.Equals(_Country.CA))
                _gLib._SetSyncUDWin("ZeroLiabilities", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 338, 614);
            sFileName = "zValuationSummary_ZeroLiabilities";

            this._ts_FromGroupToExport(sReportDirctory, sReportName, sFileName);
            #endregion


            #region Individual Output

            this._SelectTab("Output Manager");
            sReportName = "Individual Output";
            this._Navigate(Config.eCountry, "Individual Output", "Conversion", true);
            this._SelectTab(sReportName);
            this._WaitForLoading();
            sFileName = "zIndividualOutput";

            this._ts_FromGroupToExport(sReportDirctory, sReportName, sFileName);

            #endregion


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        public void _ts_FromGroupToExport(string sReportDirctory, string sReportName, string sFileName)
        {

            int iPosX = 0;
            int iPosY = 0;


            //// group by None
            this._SelectTab(sReportName);

            _gLib._SetSyncUDWin("None", this.wRetirementStudio.wGroup_None.rdNone, "True", 0);
            _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            switch (sReportName)
            {
                case "Liability Summary":
                case "Conversion Diagnostic":
                case "Valuation Summary":
                    {
                        this._WaitForLoading();
                        this._SelectTab(sReportName);
                        if ((sReportName == "Conversion Diagnostic") && Config.eCountry.Equals(_Country.CA))
                            _gLib._SetSyncUDWin("All Participants", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 16, 384);
                        if ((sReportName == "Conversion Diagnostic") && Config.eCountry.Equals(_Country.US))
                            _gLib._SetSyncUDWin("All Participants", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 16, 344);

                        this._SelectTab(sReportName);


                        break;
                    }

                case "Individual Output":
                    {
                        if (_gLib._Exists("NewIOEParameters1", this.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, Config.iTimeout / 10, false))
                            _gLib._SetSyncUDWin("NewIOEParameters1", this.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, "Click", 0);
                        else
                        {

                            dic.Clear();
                            dic.Add("Level_1", "Individual Output");
                            _gLib._TreeViewSelectWin(0, this.wRetirementStudio.tvNaviTree, dic);

                            dic.Clear();
                            dic.Add("Level_1", "Individual Output");
                            dic.Add("MenuItem", "Add IOE Parameters");
                            _gLib._TreeViewRightSelectWin(0, this.wRetirementStudio.tvNaviTree.tviIndividualOutput, dic, false);


                            this._SelectTab(sReportName);

                        }


                        break;
                    }

                default:
                    break;
            }

            _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
            _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
            this._SaveAs(sReportDirctory + sFileName + "_byNone.xlsx");
            _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
            _gLib._FileExists(sReportDirctory + sFileName + "_byNone.xlsx", iTimeout_downloadFile, true);
            _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
            if (sReportName == "Conversion Diagnostic")
                _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);



            //// group by StatusCode
            this._SelectTab(sReportName);
            _gLib._SetSyncUDWin("None", this.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
            _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            this._SelectTab(sReportName);
            this._WaitForLoading();
            this._SelectTab(sReportName);

            switch (sReportName)
            {
                case "Liability Summary":
                    {
                        if (Config.eCountry.Equals(_Country.US))
                        {
                            iPosX = 22;
                            iPosY = 344;
                            _gLib._SetSyncUDWin("XXX", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                            this._SelectTab(sReportName);
                            _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                            _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                            this._SaveAs(sReportDirctory + sFileName + "_byStatusCode.xlsx");
                            _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                            _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode.xlsx", iTimeout_downloadFile, true);
                            _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);


                        }
                        if ((Config.eCountry.Equals(_Country.CA) && !sFileName.Contains("Def") && !sFileName.Contains("Pen")) || sFileName.Contains("Windup"))
                        {
                            iPosX = 20;
                            iPosY = 370;
                            _gLib._SetSyncUDWin("XXX", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                            this._SelectTab(sReportName);
                            _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                            _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                            this._SaveAs(sReportDirctory + sFileName + "_byStatusCode.xlsx");
                            _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                            _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode.xlsx", iTimeout_downloadFile, true);
                            _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        }

                        if (Config.eCountry.Equals(_Country.CA) && (sFileName.Contains("Def") || sFileName.Contains("Pen")) && !sFileName.Contains("Windup"))
                        {
                            this._ExportItem(Config.eCountry, sReportName, false);
                            this._SaveAs(sReportDirctory + sFileName + "_byStatusCode.xlsx");
                            _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode.xlsx", iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);

                        break;
                    }
                case "Conversion Diagnostic":
                    {
                        //// Active
                        iPosX = 22;
                        if (Config.eCountry.Equals(_Country.CA))
                            iPosY = 370;
                        else
                            iPosY = 346;

                        _gLib._SetSyncUDWin("Active", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                        _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                        this._SaveAs(sReportDirctory + sFileName + "_byStatusCode_Active.xlsx");
                        _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                        _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode_Active.xlsx", iTimeout_downloadFile, true);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);

                        //// Deferred
                        if (Config.eCountry.Equals(_Country.US))
                        {
                            this._SelectTab(sReportName);
                            iPosX = 26;
                            iPosY = 368;
                            _gLib._SetSyncUDWin("Deferred", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                            this._SelectTab(sReportName);
                            _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                            _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                            this._SaveAs(sReportDirctory + sFileName + "_byStatusCode_Deferred.xlsx");
                            _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                            _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode_Deferred.xlsx", iTimeout_downloadFile, true);
                            _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);

                            //// Pensioners
                            this._SelectTab(sReportName);
                            iPosX = 26;
                            iPosY = 395;
                            _gLib._SetSyncUDWin("Pensioners", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                            this._SelectTab(sReportName);
                            _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                            _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                            this._SaveAs(sReportDirctory + sFileName + "_byStatusCode_Pensioners.xlsx");
                            _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                            _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode_Pensioners.xlsx", iTimeout_downloadFile, true);
                            _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        }

                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);


                        break;
                    }

                case "Valuation Summary":
                    {
                        //// Active
                        iPosX = 16;
                        iPosY = 216;
                        _gLib._SetSyncUDWin("Active", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                        _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                        this._SaveAs(sReportDirctory + sFileName + "_byStatusCode_Active.xlsx");
                        _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                        _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode_Active.xlsx", iTimeout_downloadFile, true);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);

                        if (Config.eCountry.Equals(_Country.US))
                        {
                            //// Expired
                            this._SelectTab(sReportName);
                            iPosX = 16;
                            iPosY = 242;
                            _gLib._SetSyncUDWin("Expired", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                            this._SelectTab(sReportName);
                            _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                            _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                            this._SaveAs(sReportDirctory + sFileName + "_byStatusCode_Expired.xlsx");
                            _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                            _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode_Expired.xlsx", iTimeout_downloadFile, true);
                            _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);

                            //// NVTerm
                            this._SelectTab(sReportName);
                            iPosX = 18;
                            iPosY = 264;
                            _gLib._SetSyncUDWin("NVTerm", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                            this._SelectTab(sReportName);
                            _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                            _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                            this._SaveAs(sReportDirctory + sFileName + "_byStatusCode_NVTerm.xlsx");
                            _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                            _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode_NVTerm.xlsx", iTimeout_downloadFile, true);
                            _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);

                        }

                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);

                        break;
                    }

                case "Individual Output":
                    {

                        //// Active
                        this._SelectTab(sReportName);
                        iPosX = 88;
                        iPosY = 140;
                        _gLib._SetSyncUDWin("Active", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                        _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                        this._SaveAs(sReportDirctory + sFileName + "_byStatusCode_Active.xlsx");
                        _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                        _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode_Active.xlsx", iTimeout_downloadFile, true);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);


                        //// Deferred
                        this._SelectTab(sReportName);
                        iPosX = 88;
                        iPosY = 163;
                        _gLib._SetSyncUDWin("Deferred", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                        _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                        this._SaveAs(sReportDirctory + sFileName + "_byStatusCode_Deferred.xlsx");
                        _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                        _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode_Deferred.xlsx", iTimeout_downloadFile, true);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);


                        //// Retired
                        this._SelectTab(sReportName);
                        iPosX = 88;
                        iPosY = 188;
                        _gLib._SetSyncUDWin("Retired", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                        _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                        this._SaveAs(sReportDirctory + sFileName + "_byStatusCode_Retired.xlsx");
                        _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                        _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode_Retired.xlsx", iTimeout_downloadFile, true);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);


                        if (Config.eCountry.Equals(_Country.US))
                        {
                            //// Expired
                            this._SelectTab(sReportName);
                            iPosX = 88;
                            iPosY = 214;
                            _gLib._SetSyncUDWin("Expired", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                            this._SelectTab(sReportName);
                            _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                            _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                            this._SaveAs(sReportDirctory + sFileName + "_byStatusCode_Expired.xlsx");
                            _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                            _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode_Expired.xlsx", iTimeout_downloadFile, true);
                            _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);



                            //// NVTerm
                            this._SelectTab(sReportName);
                            iPosX = 88;
                            iPosY = 236;
                            _gLib._SetSyncUDWin("NVTerm", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                            this._SelectTab(sReportName);
                            _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                            _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                            this._SaveAs(sReportDirctory + sFileName + "_byStatusCode_NVTerm.xlsx");
                            _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                            _gLib._FileExists(sReportDirctory + sFileName + "_byStatusCode_NVTerm.xlsx", iTimeout_downloadFile, true);
                            _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        }

                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);

                        break;

                    }

                default:
                    break;
            }



            //// group by Custom Grorup
            this._SelectTab(sReportName);
            _gLib._SetSyncUDWin("Custom Grouping", this.wRetirementStudio.wGroup_SetupCustomGrouping.rdSetupCustomGrouping, "True", 0);
            _gLib._SetSyncUDWin("Group - Gender", this.wRetirementStudio.wCustomGrouping_Major.cboMajor, "Gender", 0);
            _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
            this._SelectTab(sReportName);
            this._WaitForLoading();
            this._SelectTab(sReportName);
            switch (sReportName)
            {
                case "Liability Summary":
                case "Conversion Diagnostic":
                    if (Config.eCountry.Equals(_Country.US))
                        _gLib._SetSyncUDWin("Female", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 13, 344);
                    if ((Config.eCountry.Equals(_Country.CA) && !sFileName.Contains("Def") && !sFileName.Contains("Pen")) || sFileName.Contains("Windup"))
                        _gLib._SetSyncUDWin("Female", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 13, 370);
                    break;
                case "Valuation Summary":
                    _gLib._SetSyncUDWin("Female", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 10, 218);
                    break;
                case "Individual Output":
                    _gLib._SetSyncUDWin("Female", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 80, 141);
                    break;
            }

            if (Config.eCountry.Equals(_Country.CA) && (sFileName.Contains("Def") || sFileName.Contains("Pen")) && !sFileName.Contains("Windup"))
            {

                this._ExportItem(Config.eCountry, sReportName, false);
                this._SaveAs(sReportDirctory + sFileName + "_byGender.xlsx");
                _gLib._FileExists(sReportDirctory + sFileName + "_byGender.xlsx", iTimeout_downloadFile, true);

            }
            else
            {
                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                this._SaveAs(sReportDirctory + sFileName + "_byGender_Female.xlsx");
                _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                _gLib._FileExists(sReportDirctory + sFileName + "_byGender_Female.xlsx", iTimeout_downloadFile, true);
                _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
            }



            this._SelectTab(sReportName);
            switch (sReportName)
            {
                case "Liability Summary":
                case "Conversion Diagnostic":
                    this._SelectTab(sReportName);
                    if (Config.eCountry.Equals(_Country.US))
                        _gLib._SetSyncUDWin("Male", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 13, 369);
                    if ((Config.eCountry.Equals(_Country.CA) && !sFileName.Contains("Def") && !sFileName.Contains("Pen")) || sFileName.Contains("Windup"))
                        _gLib._SetSyncUDWin("Male", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 13, 394);
                    break;
                case "Valuation Summary":
                    this._WaitForLoading();
                    this._SelectTab(sReportName);
                    _gLib._SetSyncUDWin("Male", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 10, 242);
                    break;
                case "Individual Output":
                    _gLib._SetSyncUDWin("Male", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, 80, 165);
                    break;
            }

            //////if ((eCountry.Equals(_Country.CA) && !sFileName.Contains("Def") && !sFileName.Contains("Pen")) && !sFileName.Contains("Windup"))
            if (Config.eCountry.Equals(_Country.CA) && (sFileName.Contains("Def") || sFileName.Contains("Pen")) && !sFileName.Contains("Windup"))
            {
                // do nothing since no link available
            }
            else
            {
                this._SelectTab(sReportName);
                _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                this._SaveAs(sReportDirctory + sFileName + "_byGender_Male.xlsx");
                _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                _gLib._FileExists(sReportDirctory + sFileName + "_byGender_Male.xlsx", iTimeout_downloadFile, true);
                _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
            }

            this._SelectTab(sReportName);
            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



        }



        /// <summary>
        /// 2013-Nov-18
        /// webber.ling@mercer.com
        /// 
        /// pOutputManager._ExportReport_FVPayouts(Config.eCountry, @"c:\", "Conversion", false, true);
        /// pOutputManager._ExportReport_FVPayouts(Config.eCountry, @"c:\", "Conversion", true, true);
        /// 
        /// </summary>
        /// <param name=""></param>
        public void _ExportReport_FVPayouts(_Country eCountry, string sReportDirctory, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            string sFunctionName = "_ExportReport_FVPayouts";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export FV Payouts ");

            //FutureValuationPayouts
            string sBaseFileName = sReportDirctory + "FutureValuationPayouts_";
            string sFileName = "";
            string sPostfix = ".xlsx";
            if (bPDFTrue_ExcelFalse)
                sPostfix = ".pdf";

            this._SelectTab("Output Manager");

            this._Navigate(eCountry, "Future Valuation Payouts", sConversion_RollForward, bFunding);

            this._SelectTab("Future Valuation Payouts");

            int iValYears = this.wRetirementStudio.wValuationYear.cboValuationYear.Items.Count;

            for (int i = 0; i < iValYears; i++)
            {
                this._SelectTab("Future Valuation Payouts");
                string sYear = "";
                _gLib._Wait(1);

                try
                {
                    sYear = this.wRetirementStudio.wValuationYear.cboValuationYear.Items[i].Name;
                }
                catch (Exception ex)
                {
                    _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to select Valuation Yea, Because exception threw out: " + Environment.NewLine + ex.Message);
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to select Valuation Yea, Because exception threw out: " + Environment.NewLine + ex.Message);
                }

                _gLib._SetSyncUDWin("Valuatio Year", this.wRetirementStudio.wValuationYear.cboValuationYear, sYear, 0);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);


                sFileName = sBaseFileName + sYear.Replace(" ", "") + sPostfix;

                if (eCountry.Equals(_Country.UK))
                {
                    this._SaveAs(sFileName);
                    _gLib._FileExists(sFileName, iTimeout_downloadFile, true);
                }
                else
                {
                    this._SelectTab("Future Valuation Payouts");
                    this._WaitForLoading();
                    this._ExportItem("Future Valuation Payouts", bPDFTrue_ExcelFalse);
                    this._SaveAs(sFileName);
                    _gLib._FileExists(sFileName, iTimeout_downloadFile, true);
                    this._SelectTab("Future Valuation Payouts");
                    _gLib._Wait(1);
                    _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                }
                this._SelectTab("Future Valuation Payouts");
            }

            this._SelectTab("Future Valuation Payouts");
            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finished exporting FV Payouts");

        }


        /// <summary>
        /// 2013-Nov-18
        /// webber.ling@mercer.com
        /// 
        ///    dic.Clear();
        ///    dic.Add("HighlyCompensated", "");
        ///    dic.Add("NonHighlyCompensated", "10");
        ///    pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_ProspectiveNDTRF, "Coverage Test", "RollForward", true, true, dic);
        ///    
        ///    dic.Clear();
        ///    dic.Add("CreateARateGroupForEachHCE", "");
        ///    dic.Add("GroupRates", "");
        ///    dic.Add("ForNormalAccrualRate", "");
        ///    dic.Add("ForMostValuableAccrualRate", "");
        ///    dic.Add("HighlyCompensated", "");
        ///    dic.Add("NonHighlyCompensated", "10");
        ///    pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPlan2_ProspectiveNDTRF, "General Test", "RollForward", true, true, dic);
        /// 
        ///    dic.Clear();
        ///    dic.Add("Group_ReportBreak", "True");
        ///    pOutputManager._ExportReport_Custom(Config.eCountry, sOutputPension_Conversion2008, "Payout Projection", "Conversion", true, true, dic);
        /// 
        /// 
        /// </summary>
        /// <param name="eCountry"></param>
        /// <param name="sReportDirctory"></param>
        /// <param name="sReportName"></param>
        /// <param name="sConversion_RollForward"></param>
        /// <param name="bPDFTrue_ExcelFalse"></param>
        /// <param name="bFunding"></param>
        /// <param name="myDic"></param>
        public void _ExportReport_Custom(_Country eCountry, string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding, MyDictionary myDic)
        {
            string sFunctionName = "_ExportReport_Custom";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export reports: " + sReportName);


            string sFileName = sReportDirctory + sReportName.Replace(" ", "").Replace("/", "");

            if (bPDFTrue_ExcelFalse)
                sFileName = sFileName + ".pdf";
            else
                sFileName = sFileName + ".xlsx";

            this._SelectTab("Output Manager");

            this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);
            this._SelectTab(sReportName);

            switch (sReportName)
            {
                case "Payout Projection":
                    {

                        //////this._WaitForLoading();
                        this._SelectTab(sReportName);
                        if (myDic["Group_ReportBreak"].ToUpper() == "TRUE")
                        {
                            sFileName = sFileName.Replace("PayoutProjection", "PayoutProjection_ReportBreak");
                            _gLib._SetSyncUDWin("Group - ReportBreak", this.wRetirementStudio.wGroup_ReportBreaks.rd, "True", 0);
                        }
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        this._SaveAs(sFileName);
                        _gLib._FileExists(sFileName, iTimeout_downloadFile, true);
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                        break;
                    }

                case "Coverage Test":
                    {
                        dic.Clear();
                        dic.Add("PopVerify", "Pop");
                        dic.Add("HighlyCompensated", myDic["HighlyCompensated"]);
                        dic.Add("NonHighlyCompensated", myDic["NonHighlyCompensated"]);
                        dic.Add("View", "Click");
                        this._PopVerify_CoverageTest(dic);


                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);

                        this._SaveAs(sFileName);

                        _gLib._FileExists(sFileName, iTimeout_downloadFile, true);

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                        break;
                    }
                case "General Test":
                    {
                        dic.Clear();
                        dic.Add("PopVerify", "Pop");
                        dic.Add("CreateARateGroupForEachHCE", myDic["CreateARateGroupForEachHCE"]);
                        dic.Add("GroupRates", myDic["GroupRates"]);
                        dic.Add("ForNormalAccrualRate", myDic["ForNormalAccrualRate"]);
                        dic.Add("ForMostValuableAccrualRate", myDic["ForMostValuableAccrualRate"]);
                        dic.Add("HighlyCompensated", myDic["HighlyCompensated"]);
                        dic.Add("NonHighlyCompensated", myDic["NonHighlyCompensated"]);
                        dic.Add("View", "Click");
                        this._PopVerify_GeneralTest(dic);

                        this._SelectTab("General Test Summary");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);


                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_GeneralTestSummary.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_GeneralTestSummary.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_GeneralTestSummary.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_GeneralTestSummary.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                        this._SelectTab("Current Testing for each HCE");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CurrentTestingforEachHCE.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentTestingforEachHCE.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CurrentTestingforEachHCE.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentTestingforEachHCE.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                        this._SelectTab("Current and Prior Testing for each HCE");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CurrentAndPriorTestingforEachHCE.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentAndPriorTestingforEachHCE.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CurrentAndPriorTestingforEachHCE.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentAndPriorTestingforEachHCE.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



                        this._SelectTab("Current, Prior and Future Testing for each HCE");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CurrentPriorAndFutureTestingforEachHCE.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentPriorAndFutureTestingforEachHCE.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CurrentPriorAndFutureTestingforEachHCE.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentPriorAndFutureTestingforEachHCE.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



                        this._SelectTab("Current Testing Accrual Rates");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CurrentTestingAccrualRates.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentTestingAccrualRates.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CurrentTestingAccrualRates.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentTestingAccrualRates.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



                        this._SelectTab("Current and Prior Testing Accrual Rates");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CurrentAndPriorTestingAccrualRates.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentAndPriorTestingAccrualRates.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CurrentAndPriorTestingAccrualRates.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentAndPriorTestingAccrualRates.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



                        this._SelectTab("Current, Prior and Future Testing Accrual Rates");
                        this._WaitForLoading();
                        this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                        if (bPDFTrue_ExcelFalse)
                        {
                            this._SaveAs(sFileName.Replace(".pdf", "_CurrentPriorAndFutureTestingAccrualRates.pdf"));
                            _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentPriorAndFutureTestingAccrualRates.pdf"), iTimeout_downloadFile, true);
                        }
                        else
                        {
                            this._SaveAs(sFileName.Replace(".xlsx", "_CurrentPriorAndFutureTestingAccrualRates.xlsx"));
                            _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentPriorAndFutureTestingAccrualRates.xlsx"), iTimeout_downloadFile, true);
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                        this._SelectTab("General Test");
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                    }
                    break;

                default:
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReportName + ">. Please Verify!");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReportName + ">. Please Verify!");
                    break;
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finish export reports: " + sReportName);

        }


        public void _WaitForLoading()
        {
            _gLib._Wait(1);
            while (_gLib._Exists("Loading....", this.wRetirementStudio.wLoading, 1, 1, false)) ;

        }



        public Boolean _ExportItem(string sReportName, Boolean bPDFTrue_ExcelFalse)
        {
            return this._ExportItem(_Country.US, sReportName, bPDFTrue_ExcelFalse);
        }

        public Boolean _ExportItem(_Country eCountry, string sReportName, Boolean bPDFTrue_ExcelFalse)
        {
            string sFunctionName = "_ExportItem";
            int iTimeCosted = 0;

            int iExportDownNum = 0;

            _gLib._Enabled("Toolbar", this.wRetirementStudio.wToolbar, Config.iTimeout);


            switch (sReportName)
            {
                case "Data Reports":
                case "Liability Summary":// 2 sub item avialable, 1-PDF, 2-Excel
                case "Conversion Diagnostic":
                case "Test Case List":
                case "Detailed Results with Breaks":
                case "Status Reconciliation":
                case "Member Statistics":
                case "Individual Checking Template":
                case "Age Service Matrix":
                case "Data Matching Summary":
                case "Combined Status Code Summary":
                case "Gain / Loss Status Reconciliation":
                case "Gain / Loss Summary of Liability Reconciliation":
                case "Decrement Gain / Loss Detail":
                case "Active Decrement Gain / Loss Detail":
                case "Decrement Age":
                case "Funding Calculator Scenario":
                case "Valuation Summary":
                case "Valuation Summary for Excel Export":
                case "Individual Output":
                case "Payout Projection":
                case "FAS Expected Benefit Pmts":
                case "Liabilities Detailed Results with Breaks":
                case "Funding Calculator":
                case "ASC 960 Reconciliation":
                case "Future Valuation Population Projection":
                case "Future Valuation Summary":
                case "Future Valuation Payouts":
                case "Future Valuation Liabilities by Group":
                case "Future Valuation Liabilities by Year":
                case "Future Valuation Liabilities Detailed Results":
                case "Coverage Test":
                case "General Test":
                case "PBGC 4044 Liabilities by Plan Def":
                    {
                        if (bPDFTrue_ExcelFalse)
                            iExportDownNum = 2;
                        else
                            iExportDownNum = 1;
                    }
                    break;


                // for UK case,
                case "Detailed Results":
                case "Liabilities Detailed Results":
                case "Liability Scenario":
                case "Liability Scenario with Breaks":
                case "Reconciliation to Prior Year":
                case "Reconciliation to Prior Year with Breaks":
                case "Reconciliation to Baseline":
                case "Reconciliation to Baseline with Breaks":
                    if (bPDFTrue_ExcelFalse)
                    {
                        if (eCountry != _Country.UK)
                        {
                            iExportDownNum = 2;
                        }
                    }
                    else
                        iExportDownNum = 1;
                    break;

                case "Reconciliation to Prior Year by Plan Def":// only 1 sub item available, Excel
                case "Reconciliation to Prior Year by Plan Def with Breaks":
                case "Detailed Results by Plan Def":
                case "Detailed Results by Plan Def with Breaks":
                case "Detailed Results with Ben Type splits":
                case "Liability Scenario by Plan Def":
                case "Liability Scenario by Plan Def with Breaks":
                case "Reconciliation to Baseline by Plan Def":
                case "Reconciliation to Baseline by Plan Def with Breaks":
                case "Liabilities Detailed Results by Plan Def":
                case "Liabilities Detailed Results by Plan Def with Breaks":
                case "Liabilities Detailed Results with Ben Type splits":
                    if (!bPDFTrue_ExcelFalse)
                        iExportDownNum = 2;
                    break;
                case "Liability Set for Globe Export":
                case "Liability Set for FSM Export":
                    {
                        if (bPDFTrue_ExcelFalse)
                        {
                            //if (eCountry == _Country.DE)
                            //    iExportDownNum = 1;
                            //else
                            iExportDownNum = 2;
                        }
                        else
                        {
                            //if (eCountry == _Country.DE)
                            //    iExportDownNum = 2;
                            //else
                            iExportDownNum = 1;
                        }
                        break;
                    }

                default:
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReportName + ">. Please Verify!");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReportName + ">. Please Verify!");
                    break;

            }


            if (iExportDownNum == 0)
                return false;

            string sKeys = "";
            for (int i = 0; i < iExportDownNum; i++)
                sKeys = sKeys + "{Down}";
            sKeys = sKeys + "{Enter}";


            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    ////////////Mouse.Click(this.wRetirementStudio.wToolbar.miExport, new Point(10, 10));
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wToolbar.miExport, sKeys);
                    _gLib._SetSyncUDWin("Export Button", this.wRetirementStudio.wToolbar.miExport, "Click", 0, false, 10, 10);
                    _gLib._SendKeysUDWin("Export Menu", this.wRetirementStudio.wToolbar.miExport, sKeys);


                    if (_gLib._Exists("Save As", this.wSaveAs, Config.iTimeout / 10, false))
                        break;
                    if (iTimeCosted >= Config.iTimeout)
                        break;
                }
                catch (Exception ex)
                {
                    iTimeCosted = iTimeCosted + 5;
                }

            }

            return true;
        }


        public void _ExportItem(Boolean bPDFTrue_ExcelFalse)
        {
            int iTimeCosted = 0;

            _gLib._Enabled("Toolbar", this.wRetirementStudio.wToolbar, 10);

            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    if (bPDFTrue_ExcelFalse)
                    {
                        //Mouse.Click(this.wRetirementStudio.wToolbar.miExport, new Point(10, 10));
                        _gLib._SetSyncUDWin("Export PDF", this.wRetirementStudio.wToolbar.miExport.miPDF, "Click", 0);
                        //Mouse.Click(this.wRetirementStudio.wToolbar.miExport.miPDF, new Point(Config.iClickPos_X, Config.iClickPos_Y));
                    }
                    else
                    {
                        //Mouse.Click(this.wRetirementStudio.wToolbar.miExport, new Point(10, 10));
                        _gLib._SetSyncUDWin("Export Excel", this.wRetirementStudio.wToolbar.miExport.miExcel, "Click", 0);
                        //Mouse.Click(this.wRetirementStudio.wToolbar.miExport.miExcel, new Point(Config.iClickPos_X, Config.iClickPos_Y));
                    }

                    if (_gLib._Exists("Save As", this.wSaveAs, Config.iTimeout / 10, false))
                        break;
                    if (iTimeCosted >= Config.iTimeout)
                        break;

                }
                catch (Exception ex)
                {
                    iTimeCosted = iTimeCosted + 5;
                }

            }
        }


        /// <summary>
        /// 2013-May-25
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("RemoveAll", "");
        ///    dic.Add("AddAll", "");
        ///    dic.Add("Node", "");
        ///    dic.Add("Add", "");
        ///    dic.Add("ShowSubtotalBreaks", "");
        ///    dic.Add("OK", "");
        ///    pOutputManager._PopVerify_OutputManagerSetup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_OutputManagerSetup(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_OutputManagerSetup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("RemoveAll", this.wOutputManagerSetup.wRemoveAll.btnRemoveAll, dic["RemoveAll"], 0);
                _gLib._SetSyncUDWin("AddAll", this.wOutputManagerSetup.wAddAll.btnAddAll, dic["AddAll"], 0);
                _gLib._SetSyncUDWin("Node", this.wOutputManagerSetup.wSetupOfScenarioPack.listSetupOfScenarioPack, dic["Node"], 0);
                _gLib._SetSyncUDWin("Add", this.wOutputManagerSetup.wAdd.btnAdd, dic["Add"], 0);
                _gLib._SetSyncUDWin("ShowSubtotalBreaks", this.wOutputManagerSetup.wShowSubtotalBreaks.cboShowSubtotalBreaks, dic["ShowSubtotalBreaks"], 0);
                _gLib._SetSyncUDWin("OK", this.wOutputManagerSetup.wOK.btnOK, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("RemoveAll", this.wOutputManagerSetup.wRemoveAll.btnRemoveAll, dic["RemoveAll"], 0);
                _gLib._VerifySyncUDWin("AddAll", this.wOutputManagerSetup.wAddAll.btnAddAll, dic["AddAll"], 0);
                _gLib._VerifySyncUDWin("Node", this.wOutputManagerSetup.wSetupOfScenarioPack.listSetupOfScenarioPack, dic["Node"], 0);
                _gLib._VerifySyncUDWin("Add", this.wOutputManagerSetup.wAdd.btnAdd, dic["Add"], 0);
                _gLib._VerifySyncUDWin("ShowSubtotalBreaks", this.wOutputManagerSetup.wShowSubtotalBreaks.cboShowSubtotalBreaks, dic["ShowSubtotalBreaks"], 0);
                _gLib._VerifySyncUDWin("OK", this.wOutputManagerSetup.wOK.btnOK, dic["OK"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        public void _SaveAs(string sFileName)
        {

            if (Environment.Is64BitOperatingSystem && !sFileName.Contains("Parameter"))
            {
                _gLib._SendKeysUDWin_byPaste("SaveAs - FileName", this.wSaveAs_Win7.paneDetails.txtFileName, sFileName, Config.iTimeout * 2, true);
                _gLib._SetSyncUDWin("SaveAs - Save", this.wSaveAs.wSave.btnSave, "Click", 0);
            }
            else
            {
                _gLib._SetSyncUDWin_ByClipboard("SaveAs - FileName", this.wSaveAs.wFileName.txtFileName, sFileName, 0);
                _gLib._SetSyncUDWin("SaveAs - Save", this.wSaveAs.wSave.btnSave, "Click", 0);
            }

        }

        public void _Excel_SaveFile(string sFileName)
        {
            do
            {
                _gLib._SetSyncUDWin("File - Tab", this.wExcel_1.wRibbon.tabFile, "Click", 0);
                _gLib._Wait(1);

                try
                {
                    //////Mouse.Click(this.wExcel.wTitleBar, new Point(200, 10));
                    //////_gLib._SetSyncUDWin("Excel - Save As", this.wExcel.wMenuBar.miFile.miSaveAs, "Click", 0);
                    _gLib._SendKeysUDWin("Excel", this.wExcel_1, "f", 0, ModifierKeys.Alt, false);
                    _gLib._SendKeysUDWin("Excel", this.wExcel_1, "a", false);
                    _gLib._SendKeysUDWin("Excel", this.wExcel_1, "o", false);
                    ////////////Keyboard.SendKeys("F", ModifierKeys.Alt);
                    ////////////_gLib._Wait(1);
                    ////////////Keyboard.SendKeys("a", ModifierKeys.None);

                }
                catch (Exception ex)
                { }
            } while (!_gLib._Exists("Save As", this.wSaveAs_Excel, Config.iTimeout / 10, false));

            _gLib._SetSyncUDWin_ByClipboard("SaveAs - FileName", this.wSaveAs_Excel.wFileName.txtFileName, sFileName, 0);
            _gLib._SetSyncUDWin("SaveAs - Save", this.wSaveAs_Excel.diagSaveAs.btnSave, "Click", 0);


            _gLib._FileExists(sFileName, iTimeout_downloadFile, true);
            //////_gLib._SetSyncUDWin("Excel - Close", this.wExcel.wTitleBar.btnClose, "Click", 0);
            _gLib._Wait(1);

            _gLib._SendKeysUDWin("Excel", this.wExcel, "{F4}", 0, ModifierKeys.Alt, false);
            _gLib._KillProcessByName("EXCEL");



        }

        /// <summary>
        /// 2013-Nov-11
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "QA US Benchmark 017 Existing DNT Plan");
        ///    dic.Add("Level_2", "FundingValuations");
        ///    dic.Add("Level_3", "Retro NDT 2011");
        ///    pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);
        /// 
        ///    dic.Clear();
        ///    dic.Add("Level_1", "QA US Benchmark 017 Existing DNT Plan 2");
        ///    dic.Add("Level_2", "FundingValuations");
        ///    dic.Add("Level_3", "Prospective NDT RF");
        ///    pOutputManager._TreeViewSelect_PlanAggregation_Coverage(dic, true);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewSelect_PlanAggregation_Coverage(MyDictionary dic, Boolean bChecked)
        {
            string sFunctionName = "_TreeViewSelect_PlanAggregation_Coverage";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewCheckBoxSelectWin(0, this.wRetirementStudio.wPlanAgregation_Treeview_Coverage.tviTreeView, dic, bChecked);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-Nov-11
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "QA US Benchmark 017 Existing DNT Plan");
        ///    dic.Add("Level_2", "FundingValuations");
        ///    dic.Add("Level_3", "Retro NDT 2011");
        ///    pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);
        /// 
        ///    dic.Clear();
        ///    dic.Add("Level_1", "QA US Benchmark 017 Existing DNT Plan 2");
        ///    dic.Add("Level_2", "FundingValuations");
        ///    dic.Add("Level_3", "Prospective NDT RF");
        ///    pOutputManager._TreeViewSelect_PlanAggregation_General(dic, true);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewSelect_PlanAggregation_General(MyDictionary dic, Boolean bChecked)
        {
            string sFunctionName = "_TreeViewSelect_PlanAggregation_General";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewCheckBoxSelectWin(0, this.wRetirementStudio.wPlanAgregation_TreeView_General.tviTreeView, dic, bChecked);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Nov-15
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("NoAggregation", "");
        ///    dic.Add("SamePlansIncluded", "");
        ///    dic.Add("PlansDiffer", "True");
        ///    dic.Add("UpdateAggregation", "Click");
        ///    dic.Add("Close", "");
        ///    pOutputManager._PopVerify_PlanAggregation(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PlanAggregation(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PlanAggregation";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("NoAggregation", this.wRetirementStudio.wNoAggregation.rdNoAggregation, dic["NoAggregation"], 0);
                _gLib._SetSyncUDWin("SamePlansIncluded", this.wRetirementStudio.wSamePlansIncluded.rdSamePlansIncluded, dic["SamePlansIncluded"], 0);
                _gLib._SetSyncUDWin("PlansDiffer", this.wRetirementStudio.wPlansDiffer.rdPlansDiffer, dic["PlansDiffer"], 0);
                _gLib._SetSyncUDWin("UpdateAggregation", this.wRetirementStudio.wUpdateAggregation.btnUpdateAggregation, dic["UpdateAggregation"], 0);
                _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, dic["UpdateAggregation"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("UpdateAggregation", this.wRetirementStudio.wUpdateAggregation.btnUpdateAggregation, dic["UpdateAggregation"], 0);
                _gLib._VerifySyncUDWin("NoAggregation", this.wRetirementStudio.wNoAggregation.rdNoAggregation, dic["NoAggregation"], 0);
                _gLib._VerifySyncUDWin("SamePlansIncluded", this.wRetirementStudio.wSamePlansIncluded.rdSamePlansIncluded, dic["SamePlansIncluded"], 0);
                _gLib._VerifySyncUDWin("PlansDiffer", this.wRetirementStudio.wPlansDiffer.rdPlansDiffer, dic["PlansDiffer"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Nov-15
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("HighlyCompensated", "");
        ///    dic.Add("NonHighlyCompensated", "10");
        ///    dic.Add("View", "Click");
        ///    pOutputManager._PopVerify_CoverageTest(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CoverageTest(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_CoverageTest";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin_ByClipboard("HighlyCompensated", this.wRetirementStudio.wHighlyCompensated.txtHighlyCompensated.txt, dic["HighlyCompensated"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NonHighlyCompensated", this.wRetirementStudio.wNonHighlyCompensated.txtNonHighlyCompensated.txt, dic["NonHighlyCompensated"], 0);
                _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, dic["View"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("HighlyCompensated", this.wRetirementStudio.wHighlyCompensated.txtHighlyCompensated.txt, dic["HighlyCompensated"], 0);
                _gLib._VerifySyncUDWin("NonHighlyCompensated", this.wRetirementStudio.wNonHighlyCompensated.txtNonHighlyCompensated.txt, dic["NonHighlyCompensated"], 0);
                _gLib._VerifySyncUDWin("View", this.wRetirementStudio.wView.btnView, dic["View"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-Nov-15
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CreateARateGroupForEachHCE", "");
        ///    dic.Add("GroupRates", "");
        ///    dic.Add("ForNormalAccrualRate", "");
        ///    dic.Add("ForMostValuableAccrualRate", "");
        ///    dic.Add("HighlyCompensated", "");
        ///    dic.Add("NonHighlyCompensated", "10");
        ///    dic.Add("View", "Click");
        ///    pOutputManager._PopVerify_GeneralTest(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GeneralTest(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GeneralTest";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("CreateARateGroupForEachHCE", this.wRetirementStudio.wCreateARateGroupForEachHCE.chkCreateARateGroupForEachHCE, dic["CreateARateGroupForEachHCE"], 0);
                _gLib._SetSyncUDWin("GroupRates", this.wRetirementStudio.wGroupRates.chkGroupRates, dic["GroupRates"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ForNormalAccrualRate", this.wRetirementStudio.wForNormalAccrualRate.txtForNormalAccrualRate.txt, dic["ForNormalAccrualRate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ForMostValuableAccrualRate", this.wRetirementStudio.wForMostValuableAccrualRate.txtForMostValuableAccrualRate.txt, dic["ForMostValuableAccrualRate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("HighlyCompensated", this.wRetirementStudio.wHighlyCompensated.txtHighlyCompensated.txt, dic["HighlyCompensated"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NonHighlyCompensated", this.wRetirementStudio.wNonHighlyCompensated.txtNonHighlyCompensated.txt, dic["NonHighlyCompensated"], 0);
                _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, dic["View"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("CreateARateGroupForEachHCE", this.wRetirementStudio.wCreateARateGroupForEachHCE.chkCreateARateGroupForEachHCE, dic["CreateARateGroupForEachHCE"], 0);
                _gLib._VerifySyncUDWin("GroupRates", this.wRetirementStudio.wGroupRates.chkGroupRates, dic["GroupRates"], 0);
                _gLib._VerifySyncUDWin("ForNormalAccrualRate", this.wRetirementStudio.wForNormalAccrualRate.txtForNormalAccrualRate, dic["ForNormalAccrualRate"], 0);
                _gLib._VerifySyncUDWin("ForMostValuableAccrualRate", this.wRetirementStudio.wForMostValuableAccrualRate.txtForMostValuableAccrualRate, dic["ForMostValuableAccrualRate"], 0);
                _gLib._VerifySyncUDWin("HighlyCompensated", this.wRetirementStudio.wHighlyCompensated.txtHighlyCompensated, dic["HighlyCompensated"], 0);
                _gLib._VerifySyncUDWin("NonHighlyCompensated", this.wRetirementStudio.wNonHighlyCompensated.txtNonHighlyCompensated, dic["NonHighlyCompensated"], 0);
                _gLib._VerifySyncUDWin("View", this.wRetirementStudio.wView.btnView, dic["View"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Jul-15
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///
        ///    pOutputManager._DE010_Jubilee2012_Baseline_ICT(@"c:/"); 
        /// </summary>
        /// <param name="dic"></param>
        public void _DE010_Jubilee2012_Baseline_ICT(string sReportDirctory)
        {
            //// _gLib._MsgBoxYesNo("", "function is not completed yet, please connect lori to complete this.");

            string sFunctionName = "_DE010_Jubilee2012_Baseline_ICT";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export _DE010_Jubilee2012_Baseline_ICT reports: ");

            #region Paramters
            string[] sInterestRate = { "6,000", "5,000", "4,000" };

            string[] sLowerBoundActive = { "95", "95", "99" };
            string[] sLowerBoundInActive = { "95", "95", "99" };
            string[] sUpperBoundActive = { "105", "105", "101" };
            string[] sUpperBoundInActive = { "105", "105", "101" };

            string[] sLiabilityType = { "Tax", "Trade", "International Accounting PBO" };

            string[] sIsVoGroup = { "true", "false", "false" };

            string[] sReportName = { "IndividualCheckingTemplate_Group1.xlsx", "IndividualCheckingTemplate_JUBI02_Trade.xlsx", "IndividualCheckingTemplate_JUBI02_IntAccountingPBO.xlsx" };
            string[] sTabName = { "Group 1", "JUBI02", "JUBI02" };

            #endregion Paramters

            for (int i = 0; i <= 2; i++)
            {

                #region close output manage and re-open it
                WinTabPage sTab = null;

                ////// close and reopen
                WinTabPage wTP = new WinTabPage(this.wRetirementStudio.wHome_Tab);
                wTP.SearchProperties.Add(WinTabPage.PropertyNames.Name, "Output Manager");


                if (_gLib._Exists("Output Manager", wTP, 2, false))
                {
                    this._SelectTab("Output Manager");
                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                }

                this._SelectTab("Valuation 2012");
                pMain._Home_ToolbarClick_Top(true);



                dic.Clear();
                if (Config.sClientName.ToUpper().Contains("Create"))
                {
                    dic.Add("iSelectRowNum", "2");
                    dic.Add("iSelectColNum", "1");
                }
                else
                {
                    dic.Add("iPosX", "272");
                    dic.Add("iPosY", "95");
                }
                dic.Add("MenuItem_1", "View Output");
                pMain._FlowTreeRightSelect(dic);


                this._SelectTab("Output Manager");
                this._Navigate(_Country.DE, "Individual Checking Template", "RollForward", false);

                #endregion close output manage and re-open it


                _gLib._SetSyncUDWin_ByClipboard("wICT_InterestRate", this.wRetirementStudio.wICT_InterestRate.txt, sInterestRate[i], 0);

                _gLib._SetSyncUDWin_ByClipboard("wICT_Active_Lower", this.wRetirementStudio.wICT_Active_Lower.txt, sLowerBoundActive[i], 0);
                _gLib._SetSyncUDWin_ByClipboard("wICT_InActive_Lower", this.wRetirementStudio.wICT_InActive_Lower.txt, sLowerBoundInActive[i], 0);
                _gLib._SetSyncUDWin_ByClipboard("wICT_Active_Upper", this.wRetirementStudio.wICT_Active_Upper.txt, sUpperBoundActive[i], 0);
                _gLib._SetSyncUDWin_ByClipboard("wICT_InActive_Upper", this.wRetirementStudio.wICT_InActive_Upper.txt, sUpperBoundInActive[i], 0);

                _gLib._SetSyncUDWin("wICT_LiabilityType", this.wRetirementStudio.wICT_LiabilityType.cbo, sLiabilityType[i], 0);


                ////// VO Grouping
                if (sIsVoGroup[i].ToLower() == "true")
                {
                    string sAct = "";

                    #region check on group
                    _gLib._SetSyncUDWin("wICT_GroupVOs", this.wRetirementStudio.wICT_GroupVOs.rd, "true", 0);

                    WinWindow wGRoup = new WinWindow(this.wRetirementStudio);
                    wGRoup.SearchProperties.Add(WinWindow.PropertyNames.ControlName, "sprVOGroupSelection");
                    WinClient grid = new WinClient(wGRoup);

                    _gLib._SetSyncUDWin("wICT_GroupVOs", grid, "click", 0, false, 20, 25);
                    _gLib._SendKeysUDWin("wICT_GroupVOs", grid, "{Home}", 0, ModifierKeys.Control, false);

                    _gLib._SendKeysUDWin("wICT_GroupVOs", grid, "{Tab}{Space}{Space}{Space}", 0);

                    sAct = _fp._ReturnSelectRowContent(grid);
                    if (sAct.ToLower() != "true")
                        _gLib._SendKeysUDWin("wICT_GroupVOs", grid, "{Space}{Space}", 0);

                    sAct = _fp._ReturnSelectRowContent(grid);
                    if (sAct.ToLower() != "true")
                        _gLib._SendKeysUDWin("wICT_GroupVOs", grid, "{Space}", 0);

                    sAct = _fp._ReturnSelectRowContent(grid);
                    if (sAct.ToLower() != "true")
                        _gLib._MsgBoxYesNo("", "check value is true");



                    _gLib._SendKeysUDWin("wICT_GroupVOs", grid, "{Home}", 0, ModifierKeys.Control, false);
                    _gLib._SendKeysUDWin("wICT_GroupVOs", grid, "{Tab}{Tab}{Tab}{Space}{Space}{Space}", 0);

                    sAct = _fp._ReturnSelectRowContent(grid);
                    if (sAct.ToLower() != "true")
                        _gLib._SendKeysUDWin("wICT_GroupVOs", grid, "{Space}{Space}", 0);

                    sAct = _fp._ReturnSelectRowContent(grid);
                    if (sAct.ToLower() != "true")
                        _gLib._SendKeysUDWin("wICT_GroupVOs", grid, "{Space}", 0);

                    sAct = _fp._ReturnSelectRowContent(grid);
                    if (sAct.ToLower() != "true")
                        _gLib._MsgBoxYesNo("", "check value is true");
                    #endregion check on group
                }
                else
                    _gLib._SetSyncUDWin("wICT_VObyVObasis", this.wRetirementStudio.wICT_VObyVObasis.rd, "true", 0);



                ////////// click process
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);


                /////////// click vo grid
                if (sIsVoGroup[i].ToLower() == "true")
                    _gLib._SetSyncUDWin("VOgrid", this.wRetirementStudio.wICT_VOGroup_Grid.grid, "Click", 0, false, 150, 28);
                else
                    _gLib._SetSyncUDWin("VOgrid", this.wRetirementStudio.wVOGrouping_FPGrid.grid, "Click", 0, false, 150, 28);

                /////////// loacate tab
                this.wRetirementStudio.wTab.tab.SearchProperties.Add(WinTabPage.PropertyNames.Name, sTabName[i]);


                if (!_gLib._Exists("Tab: " + sTabName[i], this.wRetirementStudio.wTab.tab, 5, false))
                    _gLib._MsgBoxYesNo("", "Function Failed!! Please mannual click vo in ICT window, and select Tab:" + sTabName[i]);

                this._SelectTab(sTabName[i]);

                _gLib._SetSyncUDWin("Movement and Roll Froward Report", this.wRetirementStudio.wSubTab.tabMovementandRollForward, "Click", 0);
                this._WaitForLoading();

                _gLib._MsgBox("", "Mannual steps:" + Environment.NewLine + Environment.NewLine
                    + "please manual click goto: " + Environment.NewLine + Environment.NewLine
                    + "Totil Number => LastPage button => Add Fields");

                ////////////// ////////////////manual click bottom totil number
                //////////////_gLib._SetSyncUDWin("totil Number", this.wRetirementStudio.wICT_content.grid, "click", 0,false, 313, 690);

                ////////////// ////////////////click last page
                //////////////_gLib._Wait(5);
                //////////////if (_gLib._Exists("to last page", this.wRetirementStudio.wICT_LastPageBtn.tool.btn, 5, false) && _gLib._Enabled("to last page", this.wRetirementStudio.wICT_LastPageBtn.tool.btn, 5, false))
                //////////////    _gLib._SetSyncUDWin("to last page", this.wRetirementStudio.wICT_LastPageBtn.tool.btn, "click", 0);

                ////////////// ////////////////click add fields    here we can add mutiple for to click this link
                //////////////_gLib._SetSyncUDWin("Add Fields", this.wRetirementStudio.wICT_content.grid, "click", 0, false, 1697, 600);


                if (_gLib._Exists("NewIOEParameters1", this.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, Config.iTimeout / 10, false))
                    _gLib._SetSyncUDWin("NewIOEParameters1", this.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, "Click", 0);
                else
                {
                    dic.Clear();
                    dic.Add("Level_1", "Individual Output");
                    _gLib._TreeViewSelectWin(0, this.wRetirementStudio.tvNaviTree, dic);

                    dic.Clear();
                    dic.Add("Level_1", "Individual Output");
                    dic.Add("MenuItem", "Add IOE Parameters");
                    _gLib._TreeViewRightSelectWin(0, this.wRetirementStudio.tvNaviTree.tviIndividualOutput, dic, false);
                }

                _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                this._SaveAs(sReportDirctory + sReportName[i]);

                _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                _gLib._FileExists(sReportDirctory + sReportName[i], iTimeout_downloadFile, true);

                _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
            }
        }

        /// <summary>
        /// 
        ///  sample:
        ///  pOutputManager._ParameterPrint_Standalone(@"C:\Users\ruiyang-song\Desktop\");
        /// </summary>
        /// <param name="sReportDirctory"></param>
        public void _ParameterPrint_Standalone(string sReportDirctory)
        {

            this._SelectTab("Parameter Print Report");

            this._WaitForLoading();

            //// click export and select pdf report
            _gLib._SetSyncUDWin("Export Button", this.wRetirementStudio.wToolbar.miExport, "Click", 0, false, 10, 10);
            _gLib._SendKeysUDWin("Export Menu", this.wRetirementStudio.wToolbar.miExport, "{Down}{Enter}");

            this._SaveAs(sReportDirctory + "ParameterPrint_Standalone");

            _gLib._FileExists(sReportDirctory + "ParameterPrint_StandAlone.pdf", iTimeout_downloadFile, true);

            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

        }


        /// <summary>
        /// 
        ///  sample:
        ///     dic.Add("Include", "true;true");
        ///     dic.Add("DataRequestGroup", "FormerEastGermary;FormerWastGermary");
        ///     dic.Add("Layout", "Data request layout default;Data request layout default");
        ///     dic.Add("SelectionCriteria", "$emp.OstWestKZ=1;$emp.OstWestKZ<>1");
        ///     dic.Add("UseReportBreak", "true");
        ///     dic.Add("Process", "click");
        ///     pOutputManager._Jubilee_DataRequest(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements, dic); 
        ///    
        /// <param name="sReportDirctory"></param>
        public void _Jubilee_DataRequest(_Country eCountry, string sReportDirctory, MyDictionary dic)
        {
            string[] Include = dic["Include"].Split(';');
            string[] DataRequestGroup = dic["DataRequestGroup"].Split(';');
            string[] Layout = dic["Layout"].Split(';');
            string[] SelectionCriteria = dic["SelectionCriteria"].Split(';');


            this._SelectTab("Output Manager");
            this._Navigate(eCountry, "Data Request", "RollForward", false);
            this._SelectTab("Data Request");


            for (int i = 1; i <= Include.Length; i++)
            {
                _gLib._SetSyncUDWin("FGrid", this.wRetirementStudio.wDR_grid.grid, "click", 0, false, 20, 5);
                _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wDR_grid.grid, "{tab}", 0);
                _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wDR_grid.grid, "{Home}{Home}{Home}", 0, ModifierKeys.Control, false);


                /// loacate lines:
                string sRowKeys = "";
                for (int j = 1; j < i; j++)
                    sRowKeys = sRowKeys + "{Tab}{Tab}{Tab}{Tab}";
                _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wDR_grid.grid, sRowKeys + "{Enter}", 0);


                /// setting Include
                if (!_fp._ReturnSelectRowContent(this.wRetirementStudio.wDR_grid.grid).ToLower().Equals(Include[i - 1].ToLower()))
                    _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wDR_grid.grid, "{Space}", 0);
                if (!_fp._ReturnSelectRowContent(this.wRetirementStudio.wDR_grid.grid).ToLower().Equals(Include[i - 1].ToLower()))
                    _gLib._MsgBox("", "please set <Include> as <" + Include[i - 1] + "> in line: " + i);


                /// setting DataRequestGroup
                _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wDR_grid.grid, "{Tab}{Enter}", 0);
                _gLib._SetSyncUDWin_ByClipboard("DataRequestGroup", this.wRetirementStudio.wDR_edit.txt, DataRequestGroup[i - 1], 0);


                /// setting Layout
                _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wDR_grid.grid, "{Tab}{Enter}", 0);
                _gLib._SetSyncUDWin("Layout", this.wRetirementStudio.wGM_comm_cbo.cbo, Layout[i - 1], 0);


                /// setting SelectionCriteria
                _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wDR_grid.grid, "{Tab}{Enter}", 0);
                _gLib._SetSyncUDWin("SelectionCriteria", this.wRetirementStudio.wDR_edit.txt, SelectionCriteria[i - 1], 0);
            }

            _gLib._SetSyncUDWin("UseReportBreak", this.wRetirementStudio.wDR_UseReportBreaks.cbo, dic["UseReportBreak"], 0);
            _gLib._SetSyncUDWin("Validate", wRetirementStudio.wDR_Validate.btn, "click", 0);
            _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wDR_Process.btn, "click", 0);

            _gLib._SetSyncUDWin("Format", this.wRetirementStudio.wDR_ExportFormat.cbo, "Excel", 0);
            _gLib._SetSyncUDWin("ExportAll", this.wRetirementStudio.wExportAll.btn, "click", 0);

            this._SaveAs(sReportDirctory + "V6.9Enhancements_DataRequest.zip");
            _gLib._SetSyncUDWin("OK", this.wDataRequestExport.wOK.btn, "Click", Config.iTimeout * 3);
            _gLib._FileExists(sReportDirctory + "V6.9Enhancements_DataRequest.zip", iTimeout_downloadFile, true);

            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
        }

        /// <summary>
        /// 
        ///  sample:
        ///    dic.Clear();
        ///    dic.Add("Description", "test"+Environment.NewLine+"6"+ Environment.NewLine+"sensi"+Environment.NewLine+"Nodes");
        ///    dic.Add("ResultToBeIncluded_ResultType", "End of Year assumptions;Custom Demographic assumptions 1 +;Custom Demographic assumptions 1 -;"
        ///         + "Custom Financial assumptions 1 +;Custom Financial assumptions 1 -;Salary increase rate +;Salary increase rate -;");
        ///    dic.Add("ResultToBeIncluded_ValuationNode", "V6.9 Enhancements;Mortality *1.135;Mortality *0.885;InterestSensitivity Null +0.5%;"
        ///         + "InterestSensitivity Null -0.5%;PaySensitivity 3.5%;PaySensitivity 2.5%");
        ///    dic.Add("ExportToExcel", "click");
        ///    dic.Add("ExportToGlobe", "click");
        ///    pOutputManager._Jubilee_GlobeExportWithBreaksAndMultipleNodes(Config.eCountry, sOutputJubilee_Valuation2012_V69Enhancements,dic);
        ///    
        /// 
        /// note:  you need separter it by ';'
        /// 
        /// <param name="sReportDirctory"></param>
        public void _Jubilee_GlobeExportWithBreaksAndMultipleNodes(_Country eCountry, string sReportDirctory, MyDictionary dic)
        {
            string[] ResultToBeIncluded_ResultType = dic["ResultToBeIncluded_ResultType"].Split(';');
            string[] ResultToBeIncluded_ValuationNode = dic["ResultToBeIncluded_ValuationNode"].Split(';');

            this._SelectTab("Output Manager");
            this._Navigate(eCountry, "Globe Export with Breaks and Multiple Nodes", "RollForward", false);
            this._SelectTab("Globe Export with Breaks");


            _gLib._SetSyncUDWin("Description", this.wRetirementStudio.wGM_description.txt, dic["Description"], 0);

            _gLib._SetSyncUDWin("FGrid", this.wRetirementStudio.wGM_ResultToBeIncluded.grid, "click", 0, false, 20, 5);

            for (int i = 1; i < ResultToBeIncluded_ResultType.Length; i++)
            {
                string sRowKeys = "";
                _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wGM_ResultToBeIncluded.grid, "{Home}{Home}{Home}", 0, ModifierKeys.Control, false);

                for (int j = 1; j < i; j++)
                    sRowKeys = sRowKeys + "{Tab}{Tab}";

                _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wGM_ResultToBeIncluded.grid, sRowKeys + "{Enter}", 0);
                if (!_gLib._Exists("", this.wRetirementStudio.wGM_comm_cbo.cbo, 1, false))
                    _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wGM_ResultToBeIncluded.grid, "{Enter}", 0);
                _gLib._SetSyncUDWin("ResultToBeIncluded_ResultType", this.wRetirementStudio.wGM_comm_cbo.cbo, ResultToBeIncluded_ResultType[i - 1], 0);


                _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wGM_ResultToBeIncluded.grid, "{Tab}{Enter}", 0);
                _gLib._SetSyncUDWin("ResultToBeIncluded_ValuationNode", this.wRetirementStudio.wGM_comm_cbo.cbo, ResultToBeIncluded_ValuationNode[i - 1], 0);

            }

            if (dic["ExportToExcel"] != "")
            {
                _gLib._MsgBox("", "you need manual download it : " + Environment.NewLine
                     + "1, click Export To Excel button" + Environment.NewLine
                     + "2, close popup" + Environment.NewLine
                     + "3, when export job finish, goto output manage page, click Excel icon behind GlobeExportwithBreaksandMultipleNodes, to download report");

                //_gLib._SetSyncUDWin("ExportToExcel", this.wRetirementStudio.wGM_ExportToExcel.btn, dic["ExportToExcel"], 0);

                //while(_gLib._Exists("NotComplete", this.wExportToGlobe.wOK_notcomplete.btn, 10, false))
                //{
                //    _gLib._SetSyncUDWin("NotComplete", this.wExportToGlobe.wOK_notcomplete.btn, "click", 0);
                //    _gLib._Wait(5);

                //    _gLib._SetSyncUDWin("ExportToExcel", this.wRetirementStudio.wGM_ExportToExcel.btn, dic["ExportToExcel"], 0);
                //}


                //this._SaveAs(sReportDirctory + "GlobeExportwithBreaksandMultipleNodesExportToExcel.xlsx");
                //_gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                //_gLib._FileExists(sReportDirctory + "GlobeExportwithBreaksandMultipleNodes.xlsx", iTimeout_downloadFile, true);

            }


            if (dic["ExportToGlobe"] != "")
            {
                _gLib._MsgBox("", "you need manual download it : " + Environment.NewLine
                   + "1, click ExportToGlobe button" + Environment.NewLine
                   + "2, close popup" + Environment.NewLine
                   + "3, when export job finish, goto output manage page, click Excel icon behind GlobeExportwithBreaksandMultipleNodes, to download report");

                //_gLib._SetSyncUDWin("ExportToGlobe", this.wRetirementStudio.wGM_ExpsrtToExcel.btn, dic["ExportToGlobe"], 0);

                //this._SaveAs(sReportDirctory + "GlobeExportwithBreaksandMultipleNodesExportToGlobe.xlsx");
                //_gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                //_gLib._FileExists(sReportDirctory + "GlobeExportwithBreaksandMultipleNodesExportToGlobe.xlsx", iTimeout_downloadFile, true);

            }



            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
        }


        /// <summary>
        /// 2017-May-18
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "PBGC_Plan_Term");
        ///    dic.Add("Level_2", "Provision Output Fields");
        ///    dic.Add("Level_3", "PBGC Dollar Max");
        ///    pOutputManager._TreeViewSelect_IOE(dic, true);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewSelect_IOE(MyDictionary dic, Boolean bChecked)
        {
            string sFunctionName = "_TreeViewSelect_IOE";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewCheckBoxSelectWin(0, this.wRetirementStudio.wIOE_SelectFields, dic, bChecked);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2018-Oct-15 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("VerifyMsg", "True");
        ///    pOutputManager._PopVerify_ReplaceExportedLiabilitySet(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ReplaceExportedLiabilitySet(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ReplaceExportedLiabilitySet";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            if (dic["VerifyMsg"].Equals("True"))
            {
                string sActMsg = this.wReplaceExportedLiabSet.wMsg.txt.Name;
                if (!sActMsg.Equals("A liability set with this name has already been exported. Do youwant to replace the existing liability set?"))
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail because Message not correct! ");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail because Message not correct! ");
                }

                _gLib._SetSyncUDWin("ReplaceExportedLiabilitySet", this.wReplaceExportedLiabSet.wMsg.txt, "Click", 0);

            }

            _gLib._SetSyncUDWin("OK", this.wReplaceExportedLiabSet.wOK.btn, dic["OK"], 0);



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2018-Feb-22
        /// huiqing.zhu@mercer.com
        /// 
        /// 
        ///sample:
        ///dic.Clear();
        ///    dic.Add("CreateARateGroupForEachHCE", "");
        ///    dic.Add("GroupRates", "");
        ///    dic.Add("ForNormalAccrualRate", "");
        ///    dic.Add("ForMostValuableAccrualRate", "");
        ///    dic.Add("HighlyCompensated", "");
        ///    dic.Add("NonHighlyCompensated", "10");
        ///    pOutputManager._ExportReport_Custom_NDT_GeneralTestSubSelect_US(sOutputPlan2_ProspectiveNDTRF, "General Test", "RollForward", true, true, true, true, true, true, true, true, dic);
        ///    
        /// 
        ///
        /// 
        /// 
        /// </summary>
        /// <param name="eCountry"></param>
        /// <param name="sReportDirctory"></param>
        /// <param name="sReportName"></param>
        /// <param name="sConversion_RollForward"></param>
        /// <param name="bPDFTrue_ExcelFalse"></param>
        /// <param name="bFunding"></param>
        /// <param name="bCurrentforeachHCE"></param>
        /// <param name="bCurrentandPriorforeachHCE"></param>
        /// <param name="bCurrentPriorandFutureforeachHCE"></param>
        /// <param name="bCurrentAccrualRates"></param>
        /// <param name="bCurrentandPriorAccrualRates"></param>
        /// <param name="bCurrentPriorandFutureAccrualRates"></param>
        /// <param name="myDic"></param>
        public void _ExportReport_Custom_NDT_GeneralTestSubSelect_US(string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding, Boolean bCurrentforeachHCE, Boolean bCurrentandPriorforeachHCE, Boolean bCurrentPriorandFutureforeachHCE, Boolean bCurrentAccrualRates, Boolean bCurrentandPriorAccrualRates, Boolean bCurrentPriorandFutureAccrualRates, MyDictionary myDic)
        {

            string sFunctionName = "_ExportReport_Custom_NDT_GeneralTestSubSelect_US";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export reports: " + sReportName);


            string sFileName = sReportDirctory + sReportName.Replace(" ", "").Replace("/", "");

            if (bPDFTrue_ExcelFalse)
                sFileName = sFileName + ".pdf";
            else
                sFileName = sFileName + ".xlsx";

            this._SelectTab("Output Manager");
            this._Navigate(_Country.US, sReportName, sConversion_RollForward, bFunding);
            this._SelectTab(sReportName);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("CreateARateGroupForEachHCE", myDic["CreateARateGroupForEachHCE"]);
            dic.Add("GroupRates", myDic["GroupRates"]);
            dic.Add("ForNormalAccrualRate", myDic["ForNormalAccrualRate"]);
            dic.Add("ForMostValuableAccrualRate", myDic["ForMostValuableAccrualRate"]);
            dic.Add("HighlyCompensated", myDic["HighlyCompensated"]);
            dic.Add("NonHighlyCompensated", myDic["NonHighlyCompensated"]);
            dic.Add("View", "Click");
            this._PopVerify_GeneralTest(dic);


            this._SelectTab("General Test Summary");
            this._WaitForLoading();
            this._ExportItem(sReportName, bPDFTrue_ExcelFalse);


            if (bPDFTrue_ExcelFalse)
            {
                this._SaveAs(sFileName.Replace(".pdf", "_GeneralTestSummary.pdf"));
                _gLib._FileExists(sFileName.Replace(".pdf", "_GeneralTestSummary.pdf"), iTimeout_downloadFile, true);
            }
            else
            {
                this._SaveAs(sFileName.Replace(".xlsx", "_GeneralTestSummary.xlsx"));
                _gLib._FileExists(sFileName.Replace(".xlsx", "_GeneralTestSummary.xlsx"), iTimeout_downloadFile, true);
            }
            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);





            if (bCurrentforeachHCE)
            {
                this._SelectTab("Current Testing for each HCE");
                this._WaitForLoading();
                this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                if (bPDFTrue_ExcelFalse)
                {
                    this._SaveAs(sFileName.Replace(".pdf", "_CurrentTestingforEachHCE"));
                    _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentTestingforEachHCE.pdf"), iTimeout_downloadFile, true);
                }
                else
                {
                    this._SaveAs(sFileName.Replace(".xlsx", "_CurrentTestingforEachHCE.xlsx"));
                    _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentTestingforEachHCE.xlsx"), iTimeout_downloadFile, true);
                }
                _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
            }


            if (bCurrentandPriorforeachHCE)
            {
                this._SelectTab("Current and Prior Testing for each HCE");
                this._WaitForLoading();
                this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                if (bPDFTrue_ExcelFalse)
                {
                    this._SaveAs(sFileName.Replace(".pdf", "_CurrentAndPriorTestingforEachHCE.pdf"));
                    _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentAndPriorTestingforEachHCE.pdf"), iTimeout_downloadFile, true);
                }
                else
                {
                    this._SaveAs(sFileName.Replace(".xlsx", "_CurrentAndPriorTestingforEachHCE.xlsx"));
                    _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentAndPriorTestingforEachHCE.xlsx"), iTimeout_downloadFile, true);
                }
                _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

            }



            if (bCurrentPriorandFutureforeachHCE)
            {

                this._SelectTab("Current, Prior and Future Testing for each HCE");
                this._WaitForLoading();
                this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                if (bPDFTrue_ExcelFalse)
                {
                    this._SaveAs(sFileName.Replace(".pdf", "_CurrentPriorAndFutureTestingforEachHCE.pdf"));
                    _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentPriorAndFutureTestingforEachHCE.pdf"), iTimeout_downloadFile, true);
                }
                else
                {
                    this._SaveAs(sFileName.Replace(".xlsx", "_CurrentPriorAndFutureTestingforEachHCE.xlsx"));
                    _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentPriorAndFutureTestingforEachHCE.xlsx"), iTimeout_downloadFile, true);
                }
                _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



            }



            if (bCurrentAccrualRates)
            {

                this._SelectTab("Current Testing Accrual Rates");
                this._WaitForLoading();
                this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                if (bPDFTrue_ExcelFalse)
                {
                    this._SaveAs(sFileName.Replace(".pdf", "_CurrentTestingAccrualRates.pdf"));
                    _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentTestingAccrualRates.pdf"), iTimeout_downloadFile, true);
                }
                else
                {
                    this._SaveAs(sFileName.Replace(".xlsx", "_CurrentTestingAccrualRates.xlsx"));
                    _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentTestingAccrualRates.xlsx"), iTimeout_downloadFile, true);
                }
                _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


            }





            if (bCurrentandPriorAccrualRates)
            {

                this._SelectTab("Current and Prior Testing Accrual Rates");
                this._WaitForLoading();
                this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                if (bPDFTrue_ExcelFalse)
                {
                    this._SaveAs(sFileName.Replace(".pdf", "_CurrentAndPriorTestingAccrualRates.pdf"));
                    _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentAndPriorTestingAccrualRates.pdf"), iTimeout_downloadFile, true);
                }
                else
                {
                    this._SaveAs(sFileName.Replace(".xlsx", "_CurrentAndPriorTestingAccrualRates.xlsx"));
                    _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentAndPriorTestingAccrualRates.xlsx"), iTimeout_downloadFile, true);
                }
                _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


            }




            if (bCurrentPriorandFutureAccrualRates)
            {

                this._SelectTab("Current, Prior and Future Testing Accrual Rates");
                this._WaitForLoading();
                this._ExportItem(sReportName, bPDFTrue_ExcelFalse);
                if (bPDFTrue_ExcelFalse)
                {
                    this._SaveAs(sFileName.Replace(".pdf", "_CurrentPriorAndFutureTestingAccrualRates.pdf"));
                    _gLib._FileExists(sFileName.Replace(".pdf", "_CurrentPriorAndFutureTestingAccrualRates.pdf"), iTimeout_downloadFile, true);
                }
                else
                {
                    this._SaveAs(sFileName.Replace(".xlsx", "_CurrentPriorAndFutureTestingAccrualRates.xlsx"));
                    _gLib._FileExists(sFileName.Replace(".xlsx", "_CurrentPriorAndFutureTestingAccrualRates.xlsx"), iTimeout_downloadFile, true);
                }
                _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



            }

            this._SelectTab("General Test");
            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


        }




        //*******************************  new function  about download pdf and excel in one time***************************************
        /**
         * for easy to understand, we decrease down switch function
         */


        /**
         * 
         * 
         * 
         * 
         * 
         * new fucntion
         * download both pdf and excel report
         */
        public void _ExportReport_Common_PDF_EXCEL(string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            this._ExportReport_Common_PDF_EXCEL(_Country.US, sReportDirctory, sReportName, sConversion_RollForward, bPDFTrue_ExcelFalse, bFunding);
        }

        public void _ExportReport_Common_PDF_EXCEL(_Country eCountry, string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            string sFunctionName = "_ExportReport_Common";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export report: " + sReportName);

            string sFileName = sReportDirctory + sReportName.Replace(" ", "").Replace("/", "");

            this._SelectTab("Output Manager");
            this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);

            this._SelectTab(sReportName);
            this._WaitForLoading();

            if (Config.bDownloadReports_PDF)
            {
                if (this._ExportItem(eCountry, sReportName, true))
                {
                    this._SaveAs(sFileName);
                    _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                }
            }

            if (Config.bDownloadReports_EXCEL)
            {
                this._ExportItem(eCountry, sReportName, false);
                this._SaveAs(sFileName);
                _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
            }

            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finished exporting report: " + sReportName);
        }



        public void _ExportReport_Others_PDF_EXCEL(string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            this._ExportReport_Others_PDF_EXCEL(_Country.US, sReportDirctory, sReportName, sConversion_RollForward, bPDFTrue_ExcelFalse, bFunding);
        }

        public void _ExportReport_Others_PDF_EXCEL(_Country eCountry, string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            string sFunctionName = "_ExportReport_Others_PDF_EXCEL";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export report: " + sReportName);

            string sFileName = sReportDirctory + sReportName.Replace(" ", "").Replace("/", "");


            this._SelectTab("Output Manager");
            this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);

            switch (sReportName)
            {

                case "Gain / Loss Participant Listing":
                    //_gLib._MsgBox("", "following ticket '124423', Gain / Loss Participant Listing' should use subreport function,");
                    this._SaveAs(sFileName);
                    _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                    _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                    return;

                case "Parameter Print":
                case "Parameter Summary":
                case "Future Valuation Parameter Print":
                    #region

                    sFileName = sFileName + ".pdf";

                    while (_gLib._Exists("Parameter Print Wait Process Dialog", this.wWaitDialog.wOK.btn, 3, false))
                    {
                        _gLib._SetSyncUDWin("Parameter Print Wait Process Dialog - OK", this.wWaitDialog.wOK.btn, "click", 0);
                        _gLib._Wait(8);

                        this._SelectTab("Output Manager");
                        this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);
                    }


                    do
                    {
                        try
                        {
                            _gLib._SetSyncUDWin("Adobe", this.wAdobe.wTitleBar, "Click", Config.iTimeout / 3);
                            for (int i = 0; i < Config.iTimeout; i++)
                                if (_gLib._Exists("Adobe Content Preparation", this.wAdobeContentPreparation, 1, false))
                                    _gLib._Wait(2);
                                else
                                    break;
                            Keyboard.SendKeys(this.wAdobe.wPage.clientPage.wPageView, "S", (ModifierKeys.Control | ModifierKeys.Shift));
                        }
                        catch (Exception ex) { }
                    } while (!_gLib._Exists("Save As", this.wSaveAs, 5, false));


                    this._SaveAs(sFileName);
                    _gLib._FileExists(sFileName, iTimeout_downloadFile, true);


                    for (int i = 0; i < Config.iTimeout; i++)
                    {
                        if (_gLib._Exists("Adobe Content Preparation", this.wAdobeContentPreparation, 1, false))
                            _gLib._Wait(2);
                        else
                        {
                            _gLib._SetSyncUDWin("Adobe", this.wAdobe.wTitleBar, "Click", Config.iTimeout / 5);
                            _gLib._SetSyncUDWin("Adobe - Close", this.wAdobe.wTitleBar.btnClose, "Click", 0);
                            break;
                        }
                    }
                    #endregion
                    return;


                case "Age Service Matrix":

                    // close
                    this._SelectTab(sReportName);
                    this._WaitForLoading();
                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                    // //  download second report
                    // // do not concern achieve method
                    sFileName = sFileName + "_2";
                    this._SelectTab("Output Manager");
                    this._Navigate(eCountry, sReportName, "Conversion", bFunding);

                    this._SelectTab(sReportName);
                    this._WaitForLoading();

                    if (Config.bDownloadReports_PDF)
                    {
                        if (this._ExportItem(eCountry, sReportName, true))
                        {
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                        }
                    }

                    if (Config.bDownloadReports_EXCEL)
                    {
                        this._ExportItem(eCountry, sReportName, false);
                        this._SaveAs(sFileName);
                        _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                    }
                    break;

                case "Payout Projection by Participant":
                case "2D Cash flow Projection":
                case "Data Comparison":
                    this._SaveAs(sFileName);
                    _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                    _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                    return;

                case "Funding Calculator":
                case "Funding Update Results Summary":
                case "Special Payment Calculation":
                    sFileName = sFileName + ".xlsx";
                    this._Excel_SaveFile(sFileName);
                    return;
                              
                case "Funding Calculator - Checking Spreadsheet":
                case "Funding Calculator - Consulting Spreadsheet":
                    //if (Config.bDownloadReports_EXCEL)
                    sFileName = sFileName + ".xlsm";
                    this._Excel_SaveFile(sFileName);
                    return;

                case "Data Request":
                    /// setting and download report 
                    return;

                case "Globe Export with Breaks and Multiple Nodes":
                    // do not use this function yet
                    return;

                case "IOE":
                    #region

                    this._SelectTab("Individual Output");
                    _gLib._SetSyncUDWin("Group - None", this.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                    _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);


                    if (_gLib._Exists("NewIOEParameters1", this.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, Config.iTimeout / 30, false))
                        _gLib._SetSyncUDWin("NewIOEParameters1", this.wRetirementStudio.tvNaviTree.tviIndividualOutput.tviNewIOEParameters1, "Click", 0);
                    else
                    {
                        //Mouse.Click(this.wRetirementStudio.tvNaviTree.tviIndividualOutput, MouseButtons.Right, ModifierKeys.None, new Point(Config.iClickPos_X, Config.iClickPos_Y));
                        dic.Clear();
                        dic.Add("Level_1", "Individual Output");
                        _gLib._TreeViewSelectWin(0, this.wRetirementStudio.tvNaviTree, dic);

                        dic.Clear();
                        dic.Add("Level_1", "Individual Output");
                        dic.Add("MenuItem", "Add IOE Parameters");
                        _gLib._TreeViewRightSelectWin(0, this.wRetirementStudio.tvNaviTree.tviIndividualOutput, dic, false);
                    }
                    _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);

                    this._SaveAs(sFileName);
                    _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                    _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);

                    #endregion
                    break;

                case "Individual Checking Template":
                    #region

                    this._SelectTab(sReportName);
                    _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                    this._WaitForLoading();

                    string ictRootName = sFileName;


                    //// Movement and Roll Froward Report
                    sFileName = ictRootName + "_MovementAndRollforward";


                    this._WaitForLoading();
                    _gLib._SetSyncUDWin("Movement and Roll Froward Report", this.wRetirementStudio.wSubTab.tabMovementandRollForward, "Click", 0);
                    this._WaitForLoading();

                    if (Config.bDownloadReports_PDF)
                    {
                        if (this._ExportItem(eCountry, sReportName, true))
                        {
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                        }
                    }
                    if (Config.bDownloadReports_EXCEL)
                    {
                        if (this._ExportItem(eCountry, sReportName, false))
                        {
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                        }
                    }



                    /// Outlier Summary
                    sFileName = ictRootName + "_OutlierSummary";


                    this._WaitForLoading();
                    _gLib._SetSyncUDWin("Outlier Summary", this.wRetirementStudio.wSubTab.tabOutlierSummary, "Click", 0);
                    this._WaitForLoading();

                    if (Config.bDownloadReports_PDF)
                    {
                        if (this._ExportItem(eCountry, sReportName, true))
                        {
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                        }
                    }
                    if (Config.bDownloadReports_EXCEL)
                    {
                        if (this._ExportItem(eCountry, sReportName, false))
                        {
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                        }
                    }


                    /// Checking Group Statistics
                    sFileName = ictRootName + "_CheckingGroupStatistics";

                    this._WaitForLoading();
                    _gLib._SetSyncUDWin("Checking Group Statistics", this.wRetirementStudio.wSubTab.tabCheckingGroupStatistics, "Click", 0);
                    this._WaitForLoading();

                    if (Config.bDownloadReports_PDF)
                    {
                        if (this._ExportItem(eCountry, sReportName, true))
                        {
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                        }
                    }
                    if (Config.bDownloadReports_EXCEL)
                    {
                        if (this._ExportItem(eCountry, sReportName, false))
                        {
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                        }
                    }

                    #endregion
                    break;

                case "Liability Summary":
                case "Member Statistics": // this is for CA Funding RollForward only
                case "Detailed Results with Ben Type splits":
                case "Liabilities Detailed Results with Ben Type splits":
                case "Future Valuation Liabilities Detailed Results":
                    this._SelectTab(sReportName);
                    _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                    this._WaitForLoading();
                    break;

                case "Liability Set for Globe Export":
                case "Liability Set for FSM Export":
                    string original = this.wRetirementStudio.wSetName_liabilitySetForGlobeExport.txt.Text;
                    if (original.Contains("%"))
                        _gLib._SetSyncUDWin("set name", this.wRetirementStudio.wSetName_liabilitySetForGlobeExport.txt, original.Replace("%", ""), 0);
                    this._SelectTab(sReportName);
                    _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                    this._WaitForLoading();
                    break;

                case "General Test":
                    #region
                    this._SelectTab(sReportName);
                    _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);

                    this._SelectTab("General Test Summary");
                    this._WaitForLoading();

                    if (Config.bDownloadReports_PDF)
                    {
                        if (this._ExportItem(eCountry, sReportName, true))
                        {
                            this._SaveAs(sFileName + "_GeneralTestSummary.pdf");
                            _gLib._FileExists(sFileName + "_GeneralTestSummary.pdf", iTimeout_downloadFile, true);
                        }
                    }

                    if (Config.bDownloadReports_EXCEL)
                    {
                        if (this._ExportItem(eCountry, sReportName, false))
                        {
                            this._SaveAs(sFileName + "_GeneralTestSummary.xlsx");
                            _gLib._FileExists(sFileName + "_GeneralTestSummary.xlsx", iTimeout_downloadFile, true);
                        }
                    }

                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                    this._SelectTab("Current Testing for each HCE");
                    this._WaitForLoading();

                    if (Config.bDownloadReports_PDF)
                    {
                        if (this._ExportItem(eCountry, sReportName, true))
                        {
                            this._SaveAs(sFileName + "_CurrentTestingforEachHCE.pdf");
                            _gLib._FileExists(sFileName + "_CurrentTestingforEachHCE.pdf", iTimeout_downloadFile, true);
                        }
                    }

                    if (Config.bDownloadReports_EXCEL)
                    {
                        if (this._ExportItem(eCountry, sReportName, false))
                        {
                            this._SaveAs(sFileName + "_CurrentTestingforEachHCE.xlsx");
                            _gLib._FileExists(sFileName + "_CurrentTestingforEachHCE.xlsx", iTimeout_downloadFile, true);
                        }
                    }

                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                    this._SelectTab("Current and Prior Testing for each HCE");
                    this._WaitForLoading();


                    if (Config.bDownloadReports_PDF)
                    {
                        if (this._ExportItem(eCountry, sReportName, true))
                        {
                            this._SaveAs(sFileName + "_CurrentAndPriorTestingforEachHCE.pdf");
                            _gLib._FileExists(sFileName + "_CurrentAndPriorTestingforEachHCE.pdf", iTimeout_downloadFile, true);
                        }
                    }

                    if (Config.bDownloadReports_EXCEL)
                    {
                        if (this._ExportItem(eCountry, sReportName, false))
                        {
                            this._SaveAs(sFileName + "_CurrentAndPriorTestingforEachHCE.xlsx");
                            _gLib._FileExists(sFileName + "_CurrentAndPriorTestingforEachHCE.xlsx", iTimeout_downloadFile, true);
                        }
                    }


                    this._SelectTab("Current, Prior and Future Testing for each HCE");
                    this._WaitForLoading();


                    if (Config.bDownloadReports_PDF)
                    {
                        if (this._ExportItem(eCountry, sReportName, true))
                        {
                            this._SaveAs(sFileName + "_CurrentPriorAndFutureTestingforEachHCE.pdf");
                            _gLib._FileExists(sFileName + "_CurrentPriorAndFutureTestingforEachHCE.pdf", iTimeout_downloadFile, true);
                        }
                    }

                    if (Config.bDownloadReports_EXCEL)
                    {
                        if (this._ExportItem(eCountry, sReportName, false))
                        {
                            this._SaveAs(sFileName + "_CurrentPriorAndFutureTestingforEachHCE.xlsx");
                            _gLib._FileExists(sFileName + "_CurrentPriorAndFutureTestingforEachHCE.xlsx", iTimeout_downloadFile, true);
                        }
                    }

                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



                    this._SelectTab("Current Testing Accrual Rates");
                    this._WaitForLoading();


                    if (Config.bDownloadReports_PDF)
                    {
                        if (this._ExportItem(eCountry, sReportName, true))
                        {
                            this._SaveAs(sFileName + "_CurrentTestingAccrualRates.pdf");
                            _gLib._FileExists(sFileName + "_CurrentTestingAccrualRates.pdf", iTimeout_downloadFile, true);
                        }
                    }

                    if (Config.bDownloadReports_EXCEL)
                    {
                        if (this._ExportItem(eCountry, sReportName, false))
                        {
                            this._SaveAs(sFileName + "_CurrentTestingAccrualRates.xlsx");
                            _gLib._FileExists(sFileName + "_CurrentTestingAccrualRates.xlsx", iTimeout_downloadFile, true);
                        }
                    }
                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



                    this._SelectTab("Current and Prior Testing Accrual Rates");
                    this._WaitForLoading();


                    if (Config.bDownloadReports_PDF)
                    {
                        if (this._ExportItem(eCountry, sReportName, true))
                        {
                            this._SaveAs(sFileName + "_CurrentAndPriorTestingAccrualRates.pdf");
                            _gLib._FileExists(sFileName + "_CurrentAndPriorTestingAccrualRates.pdf", iTimeout_downloadFile, true);
                        }
                    }

                    if (Config.bDownloadReports_EXCEL)
                    {
                        if (this._ExportItem(eCountry, sReportName, false))
                        {
                            this._SaveAs(sFileName + "_CurrentAndPriorTestingAccrualRates.xlsx");
                            _gLib._FileExists(sFileName + "_CurrentAndPriorTestingAccrualRates.xlsx", iTimeout_downloadFile, true);
                        }
                    }
                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);



                    this._SelectTab("Current, Prior and Future Testing Accrual Rates");
                    this._WaitForLoading();


                    if (Config.bDownloadReports_PDF)
                    {
                        if (this._ExportItem(eCountry, sReportName, true))
                        {
                            this._SaveAs(sFileName + "_CurrentPriorAndFutureTestingAccrualRates.pdf");
                            _gLib._FileExists(sFileName + "_CurrentPriorAndFutureTestingAccrualRates.pdf", iTimeout_downloadFile, true);
                        }
                    }

                    if (Config.bDownloadReports_EXCEL)
                    {
                        if (this._ExportItem(eCountry, sReportName, false))
                        {
                            this._SaveAs(sFileName + "_CurrentPriorAndFutureTestingAccrualRates.xlsx");
                            _gLib._FileExists(sFileName + "_CurrentPriorAndFutureTestingAccrualRates.xlsx", iTimeout_downloadFile, true);
                        }
                    }
                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                    this._SelectTab("General Test");
                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                    #endregion
                    return;

                case "Payout Projection":
                    this._SelectTab(sReportName);

                    // CA & Funding, then return
                    #region for CA country and Funding
                    if (eCountry == _Country.CA && bFunding)
                    {

                        ///// Next checkbox name must be correct ,and you can add anyone you needed
                        string[] sName = { "Going Concern Liability", "Solvency Liability", "Wind-Up Liability" };

                        for (int i = 0; i < sName.Length; i++)
                        {

                            this.wRetirementStudio.wChklbLiabilities.wList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, sName[i]);

                            if (_gLib._Exists(sName[i], this.wRetirementStudio.wChklbLiabilities.wList.chk, 1, false))
                            {
                                _gLib._SetSyncUDWin("", this.wRetirementStudio.wChklbLiabilities.wList.chk, "true", 0);

                                _gLib._SetSyncUDWin("Group - None", this.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                                this._WaitForLoading();

                                string sTempFileName = sFileName + "_" + sName[i].Replace(" ", "").Replace("Liability", "");


                                if (Config.bDownloadReports_PDF)
                                {
                                    if (this._ExportItem(eCountry, sReportName, true))
                                    {
                                        this._SaveAs(sTempFileName);
                                        _gLib._FileExists(sTempFileName + ".pdf", iTimeout_downloadFile, true);
                                    }
                                }


                                if (Config.bDownloadReports_EXCEL)
                                {
                                    if (this._ExportItem(eCountry, sReportName, false))
                                    {
                                        this._SaveAs(sTempFileName + ".xlsx");
                                        _gLib._FileExists(sTempFileName + ".xlsx", iTimeout_downloadFile, true);
                                    }
                                }

                                _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);

                            }
                        }
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                        return;
                    }
                    #endregion

                    // others
                    _gLib._SetSyncUDWin("Group - None", this.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                    _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                    break;


                // only works fon UK
                case "Payout Projection - Benefit Cashflows":
                case "Payout Projection - Other Info":
                    #region
                    //sReportName = sReportName.Replace("Payout Projection - ", "");
                    //this._SelectTab(sReportName);
                    if (sReportName.Equals("Payout Projection - Benefit Cashflows"))
                        this._SelectTab("Benefit Cashflows");
                    else if (sReportName.Equals("Payout Projection - Other Info"))
                        this._SelectTab("Other Info");

                    _gLib._SetSyncUDWin("Group - None", this.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                    _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                    sFileName = sFileName + ".xlsx";
                    this._SaveAs(sFileName);
                    _gLib._FileExists(sFileName, iTimeout_downloadFile, true);

                    #endregion
                    break;


                case "2D PayoutProjections":
                case "2D Payout Projections":
                    this._SelectTab("2D Payout Projections");

                    sFileName = sFileName + ".xlsx";
                    _gLib._SetSyncUDWin("ExportToExcel", this.wRetirementStudio.wExporttoExcel.link.sublink, "Click", 0);
                    this._SaveAs(sFileName);
                    _gLib._SetSyncUDWin("Extract Successfully Created - OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                    _gLib._FileExists(sFileName, iTimeout_downloadFile, true);

                    sFileName = sFileName + ".json";
                    _gLib._SetSyncUDWin("ExportToJson", this.wRetirementStudio.wExporttoJson.link.sublink, "Click", 0);
                    this._SaveAs(sFileName);
                    _gLib._SetSyncUDWin("Extract Successfully Created - OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                    _gLib._FileExists(sFileName, iTimeout_downloadFile, true);
                    break;


                /**
                 * 
                 */
                case "Individual Output":
                    #region

                    this._SelectTab(sReportName);

                    _gLib._SetSyncUDWin("Group - rdGrroupbyStatusCodes", this.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
                    _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);


                    this._SelectTab(sReportName);
                    this._WaitForLoading();
                    #endregion
                    break;

                case "Test Cases":
                    #region

                    this._SelectTab(sReportName);
                    _gLib._SetSyncUDWin("ExportAllToExcel", this.wRetirementStudio.wExportAlltoExcel.txtExportAlltoExcel.linkExportAlltoExcel, "Click", 0);

                    sFileName = sFileName + ".zip";
                    this._SaveAs(sFileName);
                    _gLib._FileExists(sFileName, iTimeout_downloadFile, true);

                    #endregion
                    break;

                case "Direct Promise":
                case "Jubilee":
                case "IFRS":
                    #region

                    this._SelectTab(sReportName);
                    _gLib._SetSyncUDWin("ExportAllToExcel", this.wRetirementStudio.wExportAllCombinedReport.txt.link, "Click", 0);

                    sFileName = sFileName + ".zip";
                    this._SaveAs(sFileName);
                    _gLib._FileExists(sFileName, iTimeout_downloadFile, true);

                    #endregion
                    break;

                case "Conversion Diagnostic":
                    this._SelectTab(sReportName);
                    _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                    _gLib._SetSyncUDWin("Group - None", this.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                    _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                    break;


                case "Coverage Test":
                    this._SelectTab(sReportName);
                    _gLib._SetSyncUDWin("View", this.wRetirementStudio.wView.btnView, "Click", 0);
                    break;


                case "Future Valuation Individual Population Projection":
                    {
                        _gLib._Wait(5);
                        if (_gLib._Exists("Process", this.wRetirementStudio.wProcess.btnProcess, 5, false))
                        {
                            _gLib._SetSyncUDWin("Include stochastic decrement details", this.wRetirementStudio.wIncludestochasticde.chk, "true", 0);
                            _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                            //// it happens in random, i will complete later,
                            //if (_gLib._Exists("Not Complete", t , 5, false))
                            //{ }

                            this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);
                        }

                        _gLib._SetSyncUDWin("Previous Results", this.wFVIndividualPopulationProjection.wPreviousResults.btn, "Click", 0);
                        this._SaveAs(sFileName);
                        _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                        _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                        return;
                    }


                case "Future Valuation Individual Output":
                    {
                        if (_gLib._Exists("", this.wFVIndividualPopulationProjection.wNewExport.btn, 3, false))
                        {
                            _gLib._SetSyncUDWin("Export", this.wFVIndividualPopulationProjection.wNewExport.btn, "Click", 0);
                        }

                        _gLib._SetSyncUDWin("Export", this.wRetirementStudio.wExport.btnExport, "Click", 0);
                        _gLib._Wait(5);

                        this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);

                        _gLib._SetSyncUDWin("Previous Results", this.wFVIndividualPopulationProjection.wPreviousResults.btn, "Click", 0);
                        this._SaveAs(sFileName);
                        _gLib._SetSyncUDWin("OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                        _gLib._FileExists(sFileName + ".xlsx", Config.iTimeout, true);
                        return;
                    }

                default:
                    _gLib._MsgBoxYesNo("", "Please offer your details to Lori without hesitate, we need update function:  Client, Plan, Service, Node, ReportName, function: <_ExportReport_Others_PDF_EXCEL>");
                    break;
            }


            // download both pdf and excel report
            switch (sReportName)
            {
                case "Coverage Test":
                case "Payout Projection":
                case "Individual Output":
                case "Conversion Diagnostic":
                case "Liability Summary":
                case "Member Statistics":
                case "Liability Set for Globe Export":
                case "Liability Set for FSM Export":
                case "Detailed Results with Ben Type splits":
                case "Liabilities Detailed Results with Ben Type splits":
                case "Future Valuation Liabilities Detailed Results":
                    #region
                    {
                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sFileName + "");
                                _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }

                        if (Config.bDownloadReports_EXCEL)
                        {
                            if (this._ExportItem(eCountry, sReportName, false))
                            {
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                            }
                        }
                        break;
                    }
                    #endregion
            }

            // close and end function

            //this._SaveAs(sFileName);
            //_gLib._FileExists(sFileName , iTimeout_downloadFile, true);
            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finished exporting report: " + sReportName);
        }
         
         

        public void _ExportReport_SubReports_PDF_EXCEL(string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            this._ExportReport_SubReports_PDF_EXCEL(_Country.US, sReportDirctory, sReportName, sConversion_RollForward, bPDFTrue_ExcelFalse, bFunding);
        }

        public void _ExportReport_SubReports_PDF_EXCEL(_Country eCountry, string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            this._ExportReport_SubReports_PDF_EXCEL(eCountry, sReportDirctory, sReportName, sConversion_RollForward, bPDFTrue_ExcelFalse, bFunding, false);
        }

        public void _ExportReport_SubReports_PDF_EXCEL(_Country eCountry, string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding, Boolean bAR_DuplicatedLinkText)
        {
            string sFunctionName = "_ExportReport_SubReports";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export report: " + sReportName);

            string sSubReport_TabName;
            string sFileName;


            this._SelectTab("Output Manager");
            this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);
            this._SelectTab(sReportName);


            WinWindow wWin = new WinWindow(this.wRetirementStudio);
            wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.STATIC", PropertyExpressionOperator.Contains);
            UITestControlCollection uiCollection = wWin.FindMatchingControls();


            int iAR_DuplicatedLinkText = 1;

            for (int i = 0; i < uiCollection.Count; i++)
            {
                this._SelectTab(sReportName);
                WinText wText = new WinText((WinWindow)uiCollection[i]);

                if (wText.Name == "Select Liability Run" || wText.Name == "")
                {
                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                    return;
                }
                else if (wText.Name.Contains(":") || wText.Name.Contains("Select Report") || wText.Name.Equals("Direct Promise") || wText.Name.Equals("Support Fund") || (wText.Name.Equals("IFRS") & iAR_DuplicatedLinkText == 1) || wText.Name.Equals("Jubilee"))// || wText.Name.Contains("Click on the Status Code to change it.")
                {
                    if (!wText.Name.Equals("IFRS"))
                        continue;

                    if (bAR_DuplicatedLinkText & wText.Name.Equals("IFRS") & iAR_DuplicatedLinkText == 1)
                    {
                        iAR_DuplicatedLinkText++;
                        continue;
                    }
                }
                else
                {
                    wText.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);
                    WinHyperlink wLink = new WinHyperlink(wText);
                    wLink.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

                    _gLib._SetSyncUDWin(wLink.Name, wLink, "Click", 0);

                    sFileName = sReportDirctory + sReportName.Replace(" ", "").Replace("/", "") + "_" + wLink.Name.Replace("_", "");


                    switch (sReportName)
                    {
                        case "Gain / Loss Participant Listing":
                        case "Liability Comparison":
                            this._SaveAs(sFileName);
                            _gLib._SetSyncUDWin("Extract Successfully Created - OK", this.wExtractSuccessfullyCreated_Popup.wOK.btnOK, "Click", Config.iTimeout * 3);
                            _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                            continue;

                        case "Reconciliation to Prior Year":
                        case "Reconciliation to Prior Year with Breaks":
                        case "Reconciliation to Prior Year by Plan Def":
                        case "Reconciliation to Prior Year by Plan Def with Breaks":
                        case "Reconciliation to Baseline":
                        case "Reconciliation to Baseline with Breaks":
                        case "Reconciliation to Baseline by Plan Def":
                        case "Reconciliation to Baseline by Plan Def with Breaks":
                        case "Gain / Loss Summary of Liability Reconciliation":
                        case "Gain / Loss Status Reconciliation":
                        case "Decrement Gain / Loss Detail":
                        case "Active Decrement Gain / Loss Detail":
                            #region
                            if (bFunding)
                                sSubReport_TabName = sReportName + " - " + wLink.Name.Replace("_", " ");
                            else
                                sSubReport_TabName = sReportName + " - " + "FAS 87 " + wLink.Name.Replace("_", " ");

                            if (wLink.Name.Equals("GoingConcern")) sSubReport_TabName = sReportName + " - Going Concern";
                            if (wLink.Name.Equals("Tax")) sSubReport_TabName = sReportName + " - Tax";
                            if (wLink.Name.Equals("Trade")) sSubReport_TabName = sReportName + " - Trade";
                            if (wLink.Name.Equals("IntlAccountingPBO")) sSubReport_TabName = sReportName + " - Intl Accounting PBO";
                            if (wLink.Name.Equals("IntlAccountingABO")) sSubReport_TabName = sReportName + " - Intl Accounting ABO";


                            this._SelectTab(sSubReport_TabName);
                            ////_gLib._Enabled("Toolbar", this.wRetirementStudio.wToolbar.miExport, Config.iTimeout);
                            this._WaitForLoading();
                            _gLib._Enabled("Toolbar", this.wRetirementStudio.wToolbar, Config.iTimeout);


                            if (Config.bDownloadReports_PDF)
                            {
                                if (this._ExportItem(eCountry, sReportName, true))
                                {
                                    this._SaveAs(sFileName);
                                    _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                                }
                            }

                            if (Config.bDownloadReports_EXCEL)
                            {
                                if (this._ExportItem(eCountry, sReportName, false))
                                {
                                    this._SaveAs(sFileName);
                                    _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                                }
                            }

                            break;
                            #endregion

                        case "Liability Scenario":
                        case "Liability Scenario with Breaks":
                        case "Liability Scenario by Plan Def":
                        case "Liability Scenario by Plan Def with Breaks":
                            #region
                            if (bFunding)
                                sSubReport_TabName = sReportName + " - " + wLink.Name.Replace("_", " ");
                            else
                                sSubReport_TabName = sReportName + " - " + "FAS 87 " + wLink.Name.Replace("_", " ");

                            if (wLink.Name.Equals("GoingConcern")) sSubReport_TabName = sReportName + " - Going Concern";
                            if (wLink.Name.Equals("Tax")) sSubReport_TabName = sReportName + " - Tax";
                            if (wLink.Name.Equals("Trade")) sSubReport_TabName = sReportName + " - Trade";
                            if (wLink.Name.Equals("IntlAccountingPBO")) sSubReport_TabName = sReportName + " - Intl Accounting PBO";
                            if (wLink.Name.Equals("IntlAccountingABO")) sSubReport_TabName = sReportName + " - Intl Accounting ABO";


                            this._SelectTab(sSubReport_TabName);
                            this._WaitForLoading();
                            _gLib._Enabled("Toolbar", this.wRetirementStudio.wToolbar.miExport, Config.iTimeout);


                            if (Config.bDownloadReports_PDF)
                            {
                                if (this._ExportItem(eCountry, sReportName, true))
                                {
                                    this._SaveAs(sFileName);
                                    _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                                }
                            }

                            if (Config.bDownloadReports_EXCEL)
                            {
                                if (this._ExportItem(eCountry, sReportName, false))
                                {
                                    this._SaveAs(sFileName);
                                    _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                                }
                            }
                            break;
                            #endregion


                        case "Direct Promise":
                        case "Support Fund":
                        case "Jubilee":
                        case "IFRS":
                            #region
                            sSubReport_TabName = sReportName + " - " + wLink.Name.Replace("_", " ");

                            this._SelectTab(sSubReport_TabName);
                            _gLib._SetSyncUDWin("ExportAllCombinedReports", this.wRetirementStudio.wExportAllCombinedReports.txt.link, "Click", 0);

                            sFileName = sReportDirctory + "AR_" + sSubReport_TabName.Replace(" ", "").Replace("-", "_") + ".zip";

                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName, iTimeout_downloadFile, true);
                            break;
                            #endregion


                        default:
                            {
                                sSubReport_TabName = sReportName + " - " + wLink.Name.Replace("_", " ");

                                if (wLink.Name.Equals("GoingConcern"))
                                    sSubReport_TabName = sReportName + " - Going Concern";

                                this._SelectTab(sSubReport_TabName);
                                ////_gLib._Enabled("Toolbar", this.wRetirementStudio.wToolbar.miExport, Config.iTimeout);
                                this._WaitForLoading();
                                _gLib._Enabled("Toolbar", this.wRetirementStudio.wToolbar.miExport, Config.iTimeout);


                                if (Config.bDownloadReports_PDF)
                                {
                                    if (this._ExportItem(eCountry, sReportName, true))
                                    {
                                        this._SaveAs(sFileName);
                                        _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                                    }
                                }

                                if (Config.bDownloadReports_EXCEL)
                                {
                                    if (this._ExportItem(eCountry, sReportName, false))
                                    {
                                        this._SaveAs(sFileName);
                                        _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                                    }
                                }
                                continue;
                            }
                    }


                    // close current sub-page
                    _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                }
            }// end for loop


            // close current page and end function
            this._SelectTab(sReportName);
            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finished exporting report: " + sReportName);
        }



        public void _ExportReport_DrillDown_PDF_EXCEL(string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding, int optiLiabSummary_RowNumber_Active)
        {
            string[] sl = new string[100];
            this._ExportReport_DrillDown_PDF_EXCEL(_Country.US, sReportDirctory, sReportName, sConversion_RollForward, bPDFTrue_ExcelFalse, bFunding, optiLiabSummary_RowNumber_Active, sl);
        }

        public void _ExportReport_DrillDown_PDF_EXCEL(_Country eCountry, string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding, int optiLiabSummary_RowNumber_Active, string[] slSubNames)
        {
            string sFunctionName = "_ExportReport_DrillDownPDF_EXCEL";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export drill down reports: " + sReportName);

            string sFileName;


            int iPosX = 80;
            int iPosY = 10000;
            int iStepY = 20;


            this._SelectTab("Output Manager");
            this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);

            switch (sReportName)
            {

                case "Liability Summary":
                    {
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        /// Active Members
                        sFileName = sReportDirctory + "LiabilitySummary_ActiveMembers";

                        if (optiLiabSummary_RowNumber_Active == 0)
                            optiLiabSummary_RowNumber_Active = 9;
                        iPosY = optiLiabSummary_RowNumber_Active * iStepY + iStepY / 2;
                        _gLib._SetSyncUDWin("ActiveMember", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                        //////Mouse.Click(this.wRetirementStudio.wReportClient.clientReport, new Point(iPosX, iPosY));
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        _gLib._SetSyncUDWin("GroupByStatusCode", this.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                        }


                        /// Deferred Members
                        sFileName = sReportDirctory + "LiabilitySummary_DeferredMembers";

                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        if (optiLiabSummary_RowNumber_Active == 0)
                            optiLiabSummary_RowNumber_Active = 9;
                        iPosY = (optiLiabSummary_RowNumber_Active + 1) * iStepY + iStepY / 2;
                        _gLib._SetSyncUDWin("DeferredMembers", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                        //////Mouse.Click(this.wRetirementStudio.wReportClient.clientReport, new Point(iPosX, iPosY));
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        _gLib._SetSyncUDWin("GroupByStatusCode", this.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                        }


                        /// Pensioners
                        sFileName = sReportDirctory + "LiabilitySummary_Pensioners";

                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        if (optiLiabSummary_RowNumber_Active == 0)
                            optiLiabSummary_RowNumber_Active = 9;
                        iPosY = (optiLiabSummary_RowNumber_Active + 2) * iStepY + iStepY / 2;
                        _gLib._SetSyncUDWin("Pensioners", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                        ////////Mouse.Click(this.wRetirementStudio.wReportClient.clientReport, new Point(iPosX, iPosY));
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        _gLib._SetSyncUDWin("GroupByStatusCode", this.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                        break;
                    }


                case "Conversion Diagnostic":
                    {
                        // ConversionDiagnostic_GroupByNone
                        sFileName = sReportDirctory + "ConversionDiagnostic_GroupByNone";

                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        _gLib._SetSyncUDWin("Group - None", this.wRetirementStudio.wGroup_None.rdNone, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);


                        /// GroupByStatusCodes
                        sFileName = sReportDirctory + "ConversionDiagnostic_GroupByStatusCodes";

                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Group - Status Codes", this.wRetirementStudio.wGroup_GroupbyStatusCodes.rdGrroupbyStatusCodes, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);


                        // ConversionDiagnostic_GroupByCustom_Gender
                        sFileName = sReportDirctory + "ConversionDiagnostic_GroupByCustom_Gender";
                        this._SelectTab(sReportName);

                        _gLib._SetSyncUDWin("Group - Set Custom", this.wRetirementStudio.wGroup_SetupCustomGrouping.rdSetupCustomGrouping, "True", 0);
                        _gLib._SetSyncUDWin("Group - Gender", this.wRetirementStudio.wCustomGrouping_Major.cboMajor, "Gender", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                        break;
                    }

                case "Member Statistics":
                case "Valuation Summary":
                case "FAS Expected Benefit Pmts":
                case "Liability Set for Globe Export":
                case "Future Valuation Summary":
                case "Future Valuation Liabilities by Group":
                case "Future Valuation Liabilities by Year":
                    {
                        int iStartY = 120;
                        iStepY = 24;

                        for (int i = 0; i < slSubNames.Length; i++)
                        {
                            if (slSubNames[i] == "")
                                continue;
                            
                            sFileName = sReportDirctory + sReportName.Replace(" ", "") + "_" + slSubNames[i];


                            this._WaitForLoading();
                            this._SelectTab(sReportName);
                            //////if (optiLiabSummary_RowNumber_Active == 0)
                            //////    optiLiabSummary_RowNumber_Active = 0;
                            iPosY = iStartY + i * iStepY;
                            //////Mouse.Click(this.wRetirementStudio.wReportClient.clientReport, new Point(iPosX, iPosY));
                            _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wReportClient.clientReport, "Click", 0, false, iPosX, iPosY);
                            if (sReportName == "Liability Set for Globe Export")
                                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                            this._SelectTab(sReportName);
                            this._WaitForLoading();


                            if (Config.bDownloadReports_PDF)
                            {
                                if (this._ExportItem(eCountry, sReportName, true))
                                {
                                    this._SaveAs(sFileName);
                                    _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                                }
                            }
                            if (Config.bDownloadReports_EXCEL)
                            {
                                this._ExportItem(eCountry, sReportName, false);
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                            }

                            _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                            if (sReportName == "Liability Set for Globe Export")
                                _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                        }

                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                        break;
                    }


                case "Individual Checking Template":
                    {
                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("VO by VO basis", this.wRetirementStudio.wVOGrouping_VObyVObasis.rd, "True", 0);
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);

                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("All VOs", this.wRetirementStudio.wVOGrouping_FPGrid.grid, "Click", 0, false, 16, 28);


                        for (int i = 0; i < slSubNames.Length; i++)
                        {
                            /// Movement and Roll Froward Report
                            sFileName = sReportDirctory + sReportName.Replace(" ", "") + "_MovementAndRollforward_" + slSubNames[i];

                            this._SelectTab(slSubNames[i]);
                            this._WaitForLoading();
                            _gLib._SetSyncUDWin("Movement and Roll Froward Report", this.wRetirementStudio.wSubTab.tabMovementandRollForward, "Click", 0);
                            this._WaitForLoading();


                            if (Config.bDownloadReports_PDF)
                            {
                                if (this._ExportItem(eCountry, sReportName, true))
                                {
                                    this._SaveAs(sFileName);
                                    _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                                }
                            }
                            if (Config.bDownloadReports_EXCEL)
                            {
                                this._ExportItem(eCountry, sReportName, false);
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                            }


                            /// Outlier Summary
                            sFileName = sReportDirctory + sReportName.Replace(" ", "") + "_OutlierSummary_" + slSubNames[i];

                            this._WaitForLoading();
                            _gLib._SetSyncUDWin("Outlier Summary", this.wRetirementStudio.wSubTab.tabOutlierSummary, "Click", 0);
                            this._WaitForLoading();

                            if (Config.bDownloadReports_PDF)
                            {
                                if (this._ExportItem(eCountry, sReportName, true))
                                {
                                    this._SaveAs(sFileName);
                                    _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                                }
                            }
                            if (Config.bDownloadReports_EXCEL)
                            {
                                this._ExportItem(eCountry, sReportName, false);
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                            }


                            /// Checking Group Statistics
                            sFileName = sReportDirctory + sReportName.Replace(" ", "") + "_CheckingGroupStatistics_" + slSubNames[i];

                            this._WaitForLoading();
                            _gLib._SetSyncUDWin("Checking Group Statistics", this.wRetirementStudio.wSubTab.tabCheckingGroupStatistics, "Click", 0);

                            if (Config.bDownloadReports_PDF)
                            {
                                if (this._ExportItem(eCountry, sReportName, true))
                                {
                                    this._SaveAs(sFileName);
                                    _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                                }
                            }
                            if (Config.bDownloadReports_EXCEL)
                            {
                                this._ExportItem(eCountry, sReportName, false);
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                            }

                            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                        }

                        this._SelectTab(sReportName);
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                        break;
                    }

                default:
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReportName + ">. Please Verify!");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReportName + ">. Please Verify!");
                    break;
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Finish exporting drill down reports: " + sReportName);
        }



        public void _ExportReport_FVPayouts_PDF_EXCEL(_Country eCountry, string sReportDirctory, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding)
        {
            string sFunctionName = "_ExportReport_FVPayouts_PDF_EXCEL";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export FV Payouts ");

            //FutureValuationPayouts
            string sBaseFileName = sReportDirctory + "FutureValuationPayouts_";
            string sFileName = "";

            this._SelectTab("Output Manager");
            this._Navigate(eCountry, "Future Valuation Payouts", sConversion_RollForward, bFunding);

            this._SelectTab("Future Valuation Payouts");
            int iValYears = this.wRetirementStudio.wValuationYear.cboValuationYear.Items.Count;

            for (int i = 0; i < iValYears; i++)
            {
                this._SelectTab("Future Valuation Payouts");
                string sYear = "";
                try
                {
                    sYear = this.wRetirementStudio.wValuationYear.cboValuationYear.Items[i].Name;
                }
                catch (Exception ex)
                {
                    _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to select Valuation Yea, Because exception threw out: " + Environment.NewLine + ex.Message);
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to select Valuation Yea, Because exception threw out: " + Environment.NewLine + ex.Message);
                }

                _gLib._SetSyncUDWin("Valuatio Year", this.wRetirementStudio.wValuationYear.cboValuationYear, sYear, 0);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);


                sFileName = sBaseFileName + sYear.Replace(" ", "");

                if (eCountry.Equals(_Country.UK))
                {
                    this._SaveAs(sFileName + ".xls");
                    _gLib._FileExists(sFileName + ".xls", iTimeout_downloadFile, true);

                }
                else
                {
                    this._SelectTab("Future Valuation Payouts");
                    this._WaitForLoading();

                    if (Config.bDownloadReports_PDF)
                    {
                        if (this._ExportItem(eCountry, "Future Valuation Payouts", true))
                        {
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                        }
                    }
                    if (Config.bDownloadReports_EXCEL)
                    {
                        this._ExportItem(eCountry, "Future Valuation Payouts", false);
                        this._SaveAs(sFileName);
                        _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                    }

                    _gLib._SetSyncUDWin("Back", this.wRetirementStudio.wBack.txtBack.linkBack, "Click", 0);
                }
                this._SelectTab("Future Valuation Payouts");
            }

            this._SelectTab("Future Valuation Payouts");
            _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finished exporting FV Payouts");

        }



        public void _ExportReport_Custom_PDF_EXCEL(_Country eCountry, string sReportDirctory, string sReportName, string sConversion_RollForward, Boolean bPDFTrue_ExcelFalse, Boolean bFunding, MyDictionary myDic)
        {
            string sFunctionName = "_ExportReport_Custom";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export reports: " + sReportName);

            string sFileName = sReportDirctory + sReportName.Replace(" ", "").Replace("/", "");


            this._SelectTab("Output Manager");
            this._Navigate(eCountry, sReportName, sConversion_RollForward, bFunding);
            this._SelectTab(sReportName);


            switch (sReportName)
            {
                case "Payout Projection":
                    {

                        //////this._WaitForLoading();
                        this._SelectTab(sReportName);
                        if (myDic["Group_ReportBreak"].ToUpper() == "TRUE")
                        {
                            sFileName = sFileName.Replace("PayoutProjection", "PayoutProjection_ReportBreak");
                            _gLib._SetSyncUDWin("Group - ReportBreak", this.wRetirementStudio.wGroup_ReportBreaks.rd, "True", 0);
                        }
                        _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wProcess.btnProcess, "Click", 0);
                        this._SelectTab(sReportName);
                        this._WaitForLoading();

                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                        break;
                    }

                case "Coverage Test":
                    {
                        dic.Clear();
                        dic.Add("PopVerify", "Pop");
                        dic.Add("HighlyCompensated", myDic["HighlyCompensated"]);
                        dic.Add("NonHighlyCompensated", myDic["NonHighlyCompensated"]);
                        dic.Add("View", "Click");
                        this._PopVerify_CoverageTest(dic);

                        this._WaitForLoading();
                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sFileName);
                                _gLib._FileExists(sFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sFileName);
                            _gLib._FileExists(sFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                        break;
                    }
                case "General Test":
                    #region
                    {
                        dic.Clear();
                        dic.Add("PopVerify", "Pop");
                        dic.Add("CreateARateGroupForEachHCE", myDic["CreateARateGroupForEachHCE"]);
                        dic.Add("GroupRates", myDic["GroupRates"]);
                        dic.Add("ForNormalAccrualRate", myDic["ForNormalAccrualRate"]);
                        dic.Add("ForMostValuableAccrualRate", myDic["ForMostValuableAccrualRate"]);
                        dic.Add("HighlyCompensated", myDic["HighlyCompensated"]);
                        dic.Add("NonHighlyCompensated", myDic["NonHighlyCompensated"]);
                        dic.Add("View", "Click");
                        this._PopVerify_GeneralTest(dic);


                        //
                        this._SelectTab("General Test Summary");
                        this._WaitForLoading();

                        string sTempFileName = sFileName + "_GeneralTestSummary";
                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sTempFileName);
                                _gLib._FileExists(sTempFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sTempFileName + ".xlsx");
                            _gLib._FileExists(sTempFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                        //
                        this._SelectTab("Current Testing for each HCE");
                        this._WaitForLoading();

                        sTempFileName = sFileName + "_CurrentTestingforEachHCE";
                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sTempFileName);
                                _gLib._FileExists(sTempFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sTempFileName + ".xlsx");
                            _gLib._FileExists(sTempFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                        //
                        this._SelectTab("Current and Prior Testing for each HCE");
                        this._WaitForLoading();

                        sTempFileName = sFileName + "_CurrentAndPriorTestingforEachHCE";
                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sTempFileName);
                                _gLib._FileExists(sTempFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sTempFileName + ".xlsx");
                            _gLib._FileExists(sTempFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                        //
                        this._SelectTab("Current, Prior and Future Testing for each HCE");
                        this._WaitForLoading();

                        sTempFileName = sFileName + "_CurrentPriorAndFutureTestingforEachHCE";
                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sTempFileName);
                                _gLib._FileExists(sTempFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sTempFileName + ".xlsx");
                            _gLib._FileExists(sTempFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                        //
                        this._SelectTab("Current Testing Accrual Rates");
                        this._WaitForLoading();

                        sTempFileName = sFileName + "_CurrentTestingAccrualRates";
                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sTempFileName);
                                _gLib._FileExists(sTempFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sTempFileName + ".xlsx");
                            _gLib._FileExists(sTempFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                        //
                        this._SelectTab("Current and Prior Testing Accrual Rates");
                        this._WaitForLoading();

                        sTempFileName = sFileName + "_CurrentAndPriorTestingAccrualRates";
                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sTempFileName);
                                _gLib._FileExists(sTempFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sTempFileName + ".xlsx");
                            _gLib._FileExists(sTempFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);


                        //
                        this._SelectTab("Current, Prior and Future Testing Accrual Rates");
                        this._WaitForLoading();

                        sTempFileName = sFileName + "_CurrentPriorAndFutureTestingAccrualRates";
                        if (Config.bDownloadReports_PDF)
                        {
                            if (this._ExportItem(eCountry, sReportName, true))
                            {
                                this._SaveAs(sTempFileName);
                                _gLib._FileExists(sTempFileName + ".pdf", iTimeout_downloadFile, true);
                            }
                        }
                        if (Config.bDownloadReports_EXCEL)
                        {
                            this._ExportItem(eCountry, sReportName, false);
                            this._SaveAs(sTempFileName + ".xlsx");
                            _gLib._FileExists(sTempFileName + ".xlsx", iTimeout_downloadFile, true);
                        }

                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);

                        this._SelectTab("General Test");
                        _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wMainToolbar.btnClose, "Click", 0);
                    }

                    #endregion
                    break;

                default:
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReportName + ">. Please Verify!");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReportName + ">. Please Verify!");
                    break;
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finish export reports: " + sReportName);

        }


    }
}
