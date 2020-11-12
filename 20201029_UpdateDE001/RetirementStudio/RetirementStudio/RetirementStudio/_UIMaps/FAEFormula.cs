namespace RetirementStudio._UIMaps.FAEFormulaClasses
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


    public partial class FAEFormula
    {
        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("ServiceProrateFormula", "");
        ///    dic.Add("ServiceProrateReduction", "");
        ///    dic.Add("PayAverage", "");
        ///    dic.Add("Service", "");
        ///    dic.Add("ServiceLimitTo", "");
        ///    dic.Add("StopAccrualAt_V", "");
        ///    dic.Add("StopAccrualAt_C", "");
        ///    dic.Add("StopAccrualAt_cbo", "");
        ///    dic.Add("StopAccrualAt_TXT", "");
        ///    dic.Add("RateTiersBasedOn", "");
        ///    dic.Add("NumberOfRateTiers", "");
        ///    dic.Add("IntegrationType", "");
        ///    dic.Add("NumberOfBreakPoints", "");
        ///    pFAEFormula._PopVerify_Standard(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("ServiceProrateFormula", this.wRetirementStudio.wServiceProrateFormula.chkServiceProrateFormula, dic["ServiceProrateFormula"], 0);
                _gLib._SetSyncUDWin("ServiceProrateReduction", this.wRetirementStudio.wServiceProrateReduction.cboServiceProrateReduction, dic["ServiceProrateReduction"], 0);
                _gLib._SetSyncUDWin("PayAverage", this.wRetirementStudio.wPayAverage.cboPayAverage, dic["PayAverage"], 0);
                _gLib._SetSyncUDWin("Service", this.wRetirementStudio.wService.cboService, dic["Service"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ServiceLimitTo", this.wRetirementStudio.wServiceLimitTo.txtServiceLimitTo, dic["ServiceLimitTo"], true, 0);
                _gLib._SetSyncUDWin("StopAccrualAt_V", this.wRetirementStudio.wStopAccrualAt_V.btnV, dic["StopAccrualAt_V"], 0);
                _gLib._SetSyncUDWin("StopAccrualAt_C", this.wRetirementStudio.wStopAccrualAt_C.btnC, dic["StopAccrualAt_C"], 0);
                _gLib._SetSyncUDWin("StopAccrualAt_cbo", this.wRetirementStudio.wStopAccrualAt_cbo.cbo, dic["StopAccrualAt_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("StopAccrualAt_TXT", this.wRetirementStudio.wStopAccrualAt_TXT.txt, dic["StopAccrualAt_TXT"], true, 0);
                _gLib._SetSyncUDWin("RateTiersBasedOn", this.wRetirementStudio.wRateTiersBasedOn.cboRateTiersBasedOn, dic["RateTiersBasedOn"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NumberOfRateTiers", this.wRetirementStudio.wNumberOfRateTiers.txtNumberOfRateTiers, dic["NumberOfRateTiers"], true, 0);
                _gLib._SetSyncUDWin("IntegrationType", this.wRetirementStudio.wIntegrationType.cboIntegrationType, dic["IntegrationType"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NumberOfBreakPoints", this.wRetirementStudio.wNumberOfBreakPoints.txtNumberOfBreakPoints, dic["NumberOfBreakPoints"], true, 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("ServiceProrateFormula", this.wRetirementStudio.wServiceProrateFormula.chkServiceProrateFormula, dic["ServiceProrateFormula"], 0);
                _gLib._VerifySyncUDWin("ServiceProrateReduction", this.wRetirementStudio.wServiceProrateReduction.cboServiceProrateReduction, dic["ServiceProrateReduction"], 0);
                _gLib._VerifySyncUDWin("PayAverage", this.wRetirementStudio.wPayAverage.cboPayAverage, dic["PayAverage"], 0);
                _gLib._VerifySyncUDWin("Service", this.wRetirementStudio.wService.cboService, dic["Service"], 0);
                _gLib._VerifySyncUDWin("ServiceLimitTo", this.wRetirementStudio.wServiceLimitTo.txtServiceLimitTo, dic["ServiceLimitTo"], 0);
                _gLib._VerifySyncUDWin("StopAccrualAt_V", this.wRetirementStudio.wStopAccrualAt_V.btnV, dic["StopAccrualAt_V"], 0);
                _gLib._VerifySyncUDWin("StopAccrualAt_C", this.wRetirementStudio.wStopAccrualAt_C.btnC, dic["StopAccrualAt_C"], 0);
                _gLib._VerifySyncUDWin("StopAccrualAt_cbo", this.wRetirementStudio.wStopAccrualAt_cbo.cbo, dic["StopAccrualAt_cbo"], 0);
                _gLib._VerifySyncUDWin("StopAccrualAt_TXT", this.wRetirementStudio.wStopAccrualAt_TXT.txt, dic["StopAccrualAt_TXT"], 0);
                _gLib._VerifySyncUDWin("RateTiersBasedOn", this.wRetirementStudio.wRateTiersBasedOn.cboRateTiersBasedOn, dic["RateTiersBasedOn"], 0);
                _gLib._VerifySyncUDWin("NumberOfRateTiers", this.wRetirementStudio.wNumberOfRateTiers.txtNumberOfRateTiers, dic["NumberOfRateTiers"], 0);
                _gLib._VerifySyncUDWin("IntegrationType", this.wRetirementStudio.wIntegrationType.cboIntegrationType, dic["IntegrationType"], 0);
                _gLib._VerifySyncUDWin("NumberOfBreakPoints", this.wRetirementStudio.wNumberOfBreakPoints.txtNumberOfBreakPoints, dic["NumberOfBreakPoints"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Sep-22 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// pFAEFormula._TBL_NonIntegrated(1, 2, 1, "0.015");
        /// </summary>
        /// <param name="iRow"></param>
        /// <param name="iCol"></param>
        /// <param name="iNumOfRateTiers"></param>
        /// <param name="sData"></param>
        public void _TBL_NonIntegrated(int iRow, int iCol, int iNumOfRateTiers, string sData)
        {

            string sFunctionName = "_TBL_NonIntegrated";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            /// initialize by focus on first cell
            _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 20, 30);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}", ModifierKeys.Shift);
            _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
            _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}", 0, ModifierKeys.None, false);
            _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}", 0, ModifierKeys.Shift, false);

            string sKeys = "";
            int jMax = iNumOfRateTiers;

            if (iRow <= 1)
            {
                if (iNumOfRateTiers == 1)
                {
                    for (int j = 1; j < iCol; j++)
                        sKeys = sKeys + "{Tab}";
                }
                else
                {
                    for (int j = 2; j < iCol; j++)
                        sKeys = sKeys + "{Tab}";
                }
            }
            else
            {
                for (int j = 2; j < iCol; j++)
                    sKeys = sKeys + "{Tab}";

                for (int i = 1; i < iRow; i++)
                {

                    if (iRow > 1)
                        jMax = jMax + 1;

                    for (int j = 0; j < jMax; j++)
                        sKeys = sKeys + "{Tab}";
                }

            }

            if (sKeys != "")
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, sKeys);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKeys);


            if (sData != "")
                _gLib._SetSyncUDWin_ByClipboard(sData, this.wRetirementStudio.wCommonTXT_FPGrid.txt, sData, 0, true, false);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-May-26
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("iNumOfBreakpoints", "1");
        ///    dic.Add("btnC", "");
        ///    dic.Add("btnV", "Click");
        ///    dic.Add("sData2", "Avg5YMPE");
        ///    dic.Add("sData3", "0.01");
        ///    pFAEFormula._TBL_Excess(dic); 
        ///    
        /// 
        ///    dic.Clear();
        ///    dic.Add("iRow", "2");
        ///    dic.Add("iNumOfBreakpoints", "1");
        ///    dic.Add("btnC", "");
        ///    dic.Add("btnV", "");
        ///    dic.Add("sData2", "");
        ///    dic.Add("sData3", "0.0175");
        ///    dic.Add("isEmployeeContributionsFormula", "true");
        ///    pFAEFormula._TBL_Excess(dic); 
        /// 
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TBL_Excess(MyDictionary dic)
        {

            string sFunctionName = "_TBL_Excess";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            /// initialize by focus on first cell
            _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 20, 30);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}", ModifierKeys.Shift);
            _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
            _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}", 0, ModifierKeys.Shift, false);

            string sDwn = "";
            string sKeys = "";

            int iRow = Convert.ToInt32(dic["iRow"]);
            int iNumOfBreakpoints = Convert.ToInt32(dic["iNumOfBreakpoints"]);
            string sC = dic["btnC"];
            string sV = dic["btnV"];
            string sData2 = dic["sData2"];
            string sData3 = dic["sData3"];


            for (int i = 1; i < iRow; i++)
                sDwn = sDwn + "{Down}";

            _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

            if (sData2 != "")
            {
                sKeys = sDwn + "{Tab}";
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, sKeys);

                if (sC != "")
                {
                    if (dic["isEmployeeContributionsFormula"].ToLower() == "true")
                        this.wRetirementStudio.wStopAccrualAt_C.SearchProperties.Add(WinButton.PropertyNames.Instance, "2");
                    _gLib._SetSyncUDWin("C", this.wRetirementStudio.wStopAccrualAt_C.btnC, "Click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("sData2", this.wRetirementStudio.wStopAccrualAt_TXT.txt, sData2, 0);
                }
                if (sV != "")
                {
                    if (dic["isEmployeeContributionsFormula"].ToLower() == "true")
                    {
                        this.wRetirementStudio.wStopAccrualAt_V.SearchProperties.Add(WinButton.PropertyNames.Instance, "2");
                        this.wRetirementStudio.wStopAccrualAt_cbo.SearchProperties.Add(WinComboBox.PropertyNames.Instance, "2");
                    }
                    _gLib._SetSyncUDWin("V", this.wRetirementStudio.wStopAccrualAt_V.btnV, "Click", 0);
                    _gLib._SetSyncUDWin("sData2", this.wRetirementStudio.wStopAccrualAt_cbo.cbo, sData2, 0);
                }

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

            }

            if (sData3 != "")
            {
                sKeys = sDwn + "{End}";
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, sKeys);

                _gLib._SetSyncUDWin_ByClipboard("sData3", this.wRetirementStudio.wCommonTXT_FPGrid.txt, sData3, 0);


                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

            }



            //if (sKeys != "")
            //    _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, sKeys);



            //if (sData != "")
            //    _gLib._SetSyncUDWin_ByClipboard(sData, this.wRetirementStudio.wCommonTXT_FPGrid.txt, sData, 0, true, false);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Feb-23
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("btnC", "");
        ///    dic.Add("btnV", "Click");
        ///    dic.Add("sData2", "");
        ///    dic.Add("sData3", "");
        ///    dic.Add("sData4", "");
        ///    pFAEFormula._TBL_Excess_MoreThanOneTires(dic); 
        /// 
        ///    //// here only support 3 lines, please connect webber or lori when you need add lines
        ///   //// we need add a paramete to calculate the number of back tab when add sData..
        /// </summary>
        /// <param name="dic"></param>
        public void _TBL_Excess_MoreThanOneTires(MyDictionary dic)
        {

            string sFunctionName = "_TBL_Excess_MoreThanOneTires";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            string sDwn = "";
            int iRow = Convert.ToInt32(dic["iRow"]);
            string sC = dic["btnC"];
            string sV = dic["btnV"];
            string sData2 = dic["sData2"];
            string sData3 = dic["sData3"];
            string sData4 = dic["sData4"];

            for (int i = 1; i < iRow; i++)
                sDwn = sDwn + "{Down}";

            if (iRow == 3) sDwn = sDwn + "{PageDown}";

            if (sData2 != "")
            {
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 438, 27);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{PageUp}{PageDown}{PageUp}{PageUp}", false);

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, sDwn + "{End}");
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}", 0, ModifierKeys.Shift, false);


                if (sC != "")
                {
                    _gLib._SetSyncUDWin("C", this.wRetirementStudio.wBreakpoint1_C.btnC, "Click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("sData2", this.wRetirementStudio.wBreakpoint1_TXT.txt, sData2, 0);
                }
                if (sV != "")
                {
                    _gLib._SetSyncUDWin("V", this.wRetirementStudio.wBreakpoint1_V.btnV, "Click", 0);
                    _gLib._SetSyncUDWin("sData2", this.wRetirementStudio.wBreakpoint1_cbo.cbo, sData2, 0);
                }

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
            }

            if (sData3 != "")
            {
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 438, 27);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{PageUp}{PageUp}", false);


                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, sDwn + "{End}");
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}", 0, ModifierKeys.Shift, false);

                _gLib._SetSyncUDWin_ByClipboard("sData3", this.wRetirementStudio.wCommonTXT_FPGrid.txt, sData3, 0);

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
            }

            if (sData4 != "")
            {
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 438, 27);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{PageUp}{PageUp}", false);

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, sDwn);
                _gLib._SetSyncUDWin_ByClipboard("sData4", this.wRetirementStudio.wCommonTXT_FPGrid.txt, sData4, 0);

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-Feb-23
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("btnC", "");
        ///    dic.Add("btnV", "Click");
        ///    dic.Add("sData2", "");
        ///    dic.Add("sData3", "");
        ///    dic.Add("sData4", "");
        ///    dic.Add("sData5", "");
        ///    pFAEFormula._TBL_Excess_With3Tires_DE010(dic); 
        /// 
        ///    //// here only support 3 lines, please connect webber or lori when you need add lines
        ///   //// we need add a paramete to calculate the number of back tab when add sData..
        /// </summary>
        /// <param name="dic"></param>
        public void _TBL_Excess_With3Tires_DE010(MyDictionary dic)
        {

            string sFunctionName = "_TBL_Excess_With3Tires";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            string sDwn = "";

            string sFirstData2 = "";
            int iRow = Convert.ToInt32(dic["iRow"]);
            string sC = dic["btnC"];
            string sV = dic["btnV"];
            string sData2 = dic["sData2"];
            string sData3 = dic["sData3"];
            string sData4 = dic["sData4"];
            string sData5 = dic["sData5"];


            for (int i = 1; i < iRow; i++)
                sDwn = sDwn + "{Down}";

            if (iRow == 3) sDwn = sDwn + "{PageDown}{Tab}";

            if (sData2 != "")
            {
                for (int i = 1; i < iRow; i++)
                    sDwn = sDwn + "{Down}";

                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 438, 27);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{PageUp}{PageDown}{PageUp}{PageUp}", false);

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, sDwn + "{End}");
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}{Tab}", 0, ModifierKeys.Shift, false);


                if (sC != "")
                {
                    _gLib._SetSyncUDWin("C", this.wRetirementStudio.wStopAccrualAt_C.btnC, "Click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("sData2", this.wRetirementStudio.wStopAccrualAt_TXT.txt, sData2, 0);
                }
                if (sV != "")
                {
                    if (dic["sData2"].Substring(0, 1) != "#")
                        sFirstData2 = dic["sData2"].Substring(0, 1);
                    else sFirstData2 = "B";

                    _gLib._SetSyncUDWin("V", this.wRetirementStudio.wStopAccrualAt_V.btnV, "Click", 0);

                    _gLib._SendKeysUDWin("sData2", this.wRetirementStudio.wStopAccrualAt_cbo.cbo, sFirstData2);
                    _gLib._SetSyncUDWin("sData2", this.wRetirementStudio.wStopAccrualAt_cbo.cbo, sData2, 0);

                }

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
            }


            sDwn = "";
            for (int i = 1; i < iRow; i++)
                sDwn = sDwn + "{Down}";
            if (iRow == 3) sDwn = sDwn + "{PageDown}{Tab}";


            if (sData3 != "")
            {

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 438, 27);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{PageUp}{PageUp}{End}{End}", false);


                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, sDwn + "{End}{End}");
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}", 0, ModifierKeys.Shift, false);

                _gLib._SetSyncUDWin_ByClipboard("sData3", this.wRetirementStudio.wCommonTXT_FPGrid.txt, sData3, 0);

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
            }

            if (sData4 != "")
            {
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 438, 27);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{PageUp}{PageUp}", false);


                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, sDwn + "{End}");
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}", 0, ModifierKeys.Shift, false);

                _gLib._SetSyncUDWin_ByClipboard("sData4", this.wRetirementStudio.wCommonTXT_FPGrid.txt, sData4, 0);

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

            }


            if (sData5 != "")
            {
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 438, 27);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{PageUp}{PageUp}", false);


                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, sDwn + "{End}");
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}");

                _gLib._SetSyncUDWin_ByClipboard("sData5", this.wRetirementStudio.wCommonTXT_FPGrid.txt, sData5, 0);

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        ///// <summary>
        ///// 2016-Feb-23
        ///// ruiyang.song@mercer.com
        ///// 
        ///// sample:
        /////    dic.Clear();
        /////    dic.Add("iRow", "2");  
        /////    dic.Add("sData3", "");
        /////    dic.Add("sData4", "");
        /////    dic.Add("sData5", "");
        /////    pFAEFormula._TBL_Offset_updateToAge_US(dic); 
        ///// 
        ///// </summary>
        ///// <param name="dic"></param>
        //public void _TBL_Offset_updateToAge_US(MyDictionary dic)
        //{

        //    string sFunctionName = "_TBL_Offset_updateToAge_US";
        //    _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


        //    int iRow = Convert.ToInt32(dic["iRow"]);
        //    int iPos_X = 280;
        //    int iPos_Y = 9 + iRow * 18;



        //    if (dic["sData2"] != "")
        //    {
        //        _gLib._MsgBox("", "please confirm here need sDate2 - " + dic["sData2"]);
        //    }



        //    if (dic["sData3"] != "")
        //    {
        //        _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid_horizontalBar.bar, "Click", 0, false);
        //        _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iPos_X, iPos_Y);

        //        _gLib._SetSyncUDWin_ByClipboard("sData3", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["sData3"], 0);

        //        _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
        //    }

        //    if (dic["sData4"] != "")
        //    {
        //        _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid_horizontalBar.bar, "Click", 0, false);
        //        _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iPos_X, iPos_Y);
        //        _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}", false);
        //        _gLib._SetSyncUDWin_ByClipboard("sData4", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["sData4"], 0);

        //        _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
        //    }


        //    if (dic["sData5"] != "")
        //    {
        //        _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid_horizontalBar.bar, "Click", 0, false);
        //        _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iPos_X, iPos_Y);
        //        _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Tab}", false);
        //        _gLib._SetSyncUDWin_ByClipboard("sData5", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["sData5"], 0);

        //        _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
        //    }

        //    _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        //}

        /// <summary>
        /// 2016-Feb-23
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "2");  
        ///    dic.Add("sData3", "");
        ///    dic.Add("sData4", "");
        ///    dic.Add("sData5", "");
        ///    pFAEFormula._TBL_Offset_updateToAge_US011(dic); 
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TBL_Offset_updateToAge_US011(MyDictionary dic)
        {

            string sFunctionName = "_TBL_Offset_updateToAge_US011";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            int iRow = Convert.ToInt32(dic["iRow"]);
            string sRowTabs = ""; // iRow=1/2 no need
            if (iRow == 3) sRowTabs = "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}";


            if (dic["sData2"] != "")
            {
                _gLib._MsgBox("", "please confirm here need sDate2 - " + dic["sData2"]);
            }



            if (dic["sData3"] != "")
            {
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, 50);

                _gLib._SendKeysUDWin("Tabs", this.wRetirementStudio.wFPGrid.grid, sRowTabs + "{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("sData3", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["sData3"], 0);
            }

            if (dic["sData4"] != "")
            {
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, 50);

                _gLib._SendKeysUDWin("Tabs", this.wRetirementStudio.wFPGrid.grid, sRowTabs + "{Tab}{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("sData4", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["sData4"], 0);
            }


            if (dic["sData5"] != "")
            {
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 50, 50);

                _gLib._SendKeysUDWin("Tabs", this.wRetirementStudio.wFPGrid.grid, sRowTabs + "{Tab}{Tab}{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("sData5", this.wRetirementStudio.wCommonTXT_FPGrid.txt, dic["sData5"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
