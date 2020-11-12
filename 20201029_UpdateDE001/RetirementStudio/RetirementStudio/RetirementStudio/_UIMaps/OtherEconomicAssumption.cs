namespace RetirementStudio._UIMaps.OtherEconomicAssumptionClasses
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


    public partial class OtherEconomicAssumption
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        /// <summary>
        /// 2013-June-1
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("btnPayLimitIncrease_V", "");
        ///    dic.Add("btnPayLimitIncrease_Percent", "Click");
        ///    dic.Add("btnPayLimitIncrease_T", "");
        ///    dic.Add("PayLimitIncrease_V_cbo", "");
        ///    dic.Add("PayLimitIncrease_txt", "2.0");
        ///    dic.Add("PayLimitIncrease_T_cbo", "");
        ///    dic.Add("btn415LimitIncrease_V", "");
        ///    dic.Add("btn415LimitIncrease_Percent", "Click");
        ///    dic.Add("btn415LimitIncrease_T", "");
        ///    dic.Add("415LimitIncrease_V_cbo", "");
        ///    dic.Add("415LimitIncrease_txt", "2.0");
        ///    dic.Add("415LimitIncrease_T_cbo", "");
        ///    dic.Add("btnWageBaseIncrease_V", "");
        ///    dic.Add("btnWageBaseIncrease_Percent", "Click");
        ///    dic.Add("btnWageBaseIncrease_T", "");
        ///    dic.Add("WageBaseIncrease_V_cbo", "");
        ///    dic.Add("WageBaseIncrease_txt", "2.0");
        ///    dic.Add("WageBaseIncrease_T_cbo", "");
        ///    dic.Add("btnSocialSecurityCOLA_V", "");
        ///    dic.Add("btnSocialSecurityCOLA_Percent", "Click");
        ///    dic.Add("btnSocialSecurityCOLA_T", "");
        ///    dic.Add("SocialSecurityCOLA_V_cbo", "");
        ///    dic.Add("SocialSecurityCOLA_txt", "2.0");
        ///    dic.Add("SocialSecurityCOLA_T_cbo", "");
        ///    dic.Add("WorkingDaysPerYear_txt", "");
        ///    dic.Add("SoliTaxRate_txt", "");
        ///    pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_OtherEconomicAssumption(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_OtherEconomicAssumption";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iPayLimitIncrease_txt = 0;
            int i415LimitIncrease_txt = 0;
            int iWageBaseIncrease_txt = 0;
            int iSocialSecurityCOLA_txt = 0;

            int iPayLimitIncrease_cbo_V = 0;
            int i415LimitIncrease_cbo_V = 0;
            int iWageBaseIncrease_cbo_V = 0;
            int iSocialSecurityCOLA_cbo_V = 0;

            int iPayLimitIncrease_cbo_T = 0;
            int i415LimitIncrease_cbo_T = 0;
            int iWageBaseIncrease_cbo_T = 0;
            int iSocialSecurityCOLA_cbo_T = 0;

            int iTxtIncrease_txt = 0;
            int iIncrease_cbo_V = 0;
            int iIncrease_cbo_T = 0;


            if (dic["PopVerify"] == "Pop")
            {

                //  PayLimitIncrease
                _gLib._SetSyncUDWin("btnPayLimitIncrease_V", this.wRetirementStudio.wPayLimitIncrease_VIcon.btnPayLimitIncrease_V, dic["btnPayLimitIncrease_V"], 0);
                _gLib._SetSyncUDWin("btnPayLimitIncrease_Percent", this.wRetirementStudio.wPayLimitIncrease_PercentIcon.btnPayLimitIncrease_Percent, dic["btnPayLimitIncrease_Percent"], 0);
                _gLib._SetSyncUDWin("btnPayLimitIncrease_T", this.wRetirementStudio.wPayLimitIncrease_TIcon.btnPayLimitIncrease_T, dic["btnPayLimitIncrease_T"], 0);
                if (dic["btnPayLimitIncrease_V"] != "")
                {
                    iPayLimitIncrease_cbo_V = iIncrease_cbo_V + 1;
                    iIncrease_cbo_V = iIncrease_cbo_V + 1;
                    this.wRetirementStudio.wCommonComboBox_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iPayLimitIncrease_cbo_V.ToString());
                    _gLib._SetSyncUDWin("PayLimitIncrease_V_cbo", this.wRetirementStudio.wCommonComboBox_V.cbo_V, dic["PayLimitIncrease_V_cbo"], 0);
                }
                if (dic["btnPayLimitIncrease_Percent"] != "")
                {
                    iPayLimitIncrease_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iPayLimitIncrease_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("PayLimitIncrease_txt", this.wRetirementStudio.wCommonTXT.txt, dic["PayLimitIncrease_txt"], true, 0);
                }
                if (dic["btnPayLimitIncrease_T"] != "")
                {
                    iPayLimitIncrease_cbo_T = iIncrease_cbo_T + 1;
                    iIncrease_cbo_T = iIncrease_cbo_T + 1;
                    this.wRetirementStudio.wCommonComboBox_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, iPayLimitIncrease_cbo_T.ToString());
                    _gLib._SetSyncUDWin("PayLimitIncrease_T_cbo", this.wRetirementStudio.wCommonComboBox_T.cbo_T, dic["PayLimitIncrease_T_cbo"], 0);
                }



                //  415LimitIncrease
                _gLib._SetSyncUDWin("btn415LimitIncrease_V", this.wRetirementStudio.w415LimitIncrease_VIcon.btn415LimitIncrease_V, dic["btn415LimitIncrease_V"], 0);
                _gLib._SetSyncUDWin("btn415LimitIncrease_Percent", this.wRetirementStudio.w415LimitIncrease_PercentIcon.btn415LimitIncrease_Percent, dic["btn415LimitIncrease_Percent"], 0);
                _gLib._SetSyncUDWin("btn415LimitIncrease_T", this.wRetirementStudio.w415LimitIncrease_TIcon.btn415LimitIncrease_T, dic["btn415LimitIncrease_T"], 0);
                if (dic["btn415LimitIncrease_V"] != "")
                {
                    i415LimitIncrease_cbo_V = iIncrease_cbo_V + 1;
                    iIncrease_cbo_V = iIncrease_cbo_V + 1;
                    this.wRetirementStudio.wCommonComboBox_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, i415LimitIncrease_cbo_V.ToString());
                    _gLib._SetSyncUDWin("415LimitIncrease_V_cbo", this.wRetirementStudio.wCommonComboBox_V.cbo_V, dic["415LimitIncrease_V_cbo"], 0);
                }
                if (dic["btn415LimitIncrease_Percent"] != "")
                {
                    i415LimitIncrease_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, i415LimitIncrease_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("415LimitIncrease_txt", this.wRetirementStudio.wCommonTXT.txt, dic["415LimitIncrease_txt"], true, 0);
                }
                if (dic["btn415LimitIncrease_T"] != "")
                {
                    i415LimitIncrease_cbo_T = iIncrease_cbo_T + 1;
                    iIncrease_cbo_T = iIncrease_cbo_T + 1;
                    this.wRetirementStudio.wCommonComboBox_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, i415LimitIncrease_cbo_T.ToString());
                    _gLib._SetSyncUDWin("415LimitIncrease_T_cbo", this.wRetirementStudio.wCommonComboBox_T.cbo_T, dic["415LimitIncrease_T_cbo"], 0);
                }

                //  WageBaseIncrease
                _gLib._SetSyncUDWin("btnWageBaseIncrease_V", this.wRetirementStudio.wWageBaseIncrease_VIcon.btnWageBaseIncrease_V, dic["btnWageBaseIncrease_V"], 0);
                _gLib._SetSyncUDWin("btnWageBaseIncrease_Percent", this.wRetirementStudio.wWageBaseIncrease_PercentIcon.btnWageBaseIncrease_Percent, dic["btnWageBaseIncrease_Percent"], 0);
                _gLib._SetSyncUDWin("btnWageBaseIncrease_T", this.wRetirementStudio.wWageBaseIncrease_TIcon.btnWageBaseIncrease_T, dic["btnWageBaseIncrease_T"], 0);
                if (dic["btnWageBaseIncrease_V"] != "")
                {
                    iWageBaseIncrease_cbo_V = iIncrease_cbo_V + 1;
                    iIncrease_cbo_V = iIncrease_cbo_V + 1;
                    this.wRetirementStudio.wCommonComboBox_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iWageBaseIncrease_cbo_V.ToString());
                    _gLib._SetSyncUDWin("WageBaseIncrease_V_cbo", this.wRetirementStudio.wCommonComboBox_V.cbo_V, dic["WageBaseIncrease_V_cbo"], 0);
                }
                if (dic["btnWageBaseIncrease_Percent"] != "")
                {
                    iWageBaseIncrease_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iWageBaseIncrease_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("WageBaseIncrease_txt", this.wRetirementStudio.wCommonTXT.txt, dic["WageBaseIncrease_txt"], true, 0);
                }
                if (dic["btnWageBaseIncrease_T"] != "")
                {
                    iWageBaseIncrease_cbo_T = iIncrease_cbo_T + 1;
                    iIncrease_cbo_T = iIncrease_cbo_T + 1;
                    this.wRetirementStudio.wCommonComboBox_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, iWageBaseIncrease_cbo_T.ToString());
                    _gLib._SetSyncUDWin("WageBaseIncrease_T_cbo", this.wRetirementStudio.wCommonComboBox_T.cbo_T, dic["WageBaseIncrease_T_cbo"], 0);
                }


                //  SocialSecurityCOLA
                _gLib._SetSyncUDWin("btnSocialSecurityCOLA_V", this.wRetirementStudio.wSocialSecurityCOLA_VIcon.btnSocialSecurityCOLA_V, dic["btnSocialSecurityCOLA_V"], 0);
                _gLib._SetSyncUDWin("btnSocialSecurityCOLA_Percent", this.wRetirementStudio.wSocialSecurityCOLA_PercentIcon.btnSocialSecurityCOLA_Percent, dic["btnSocialSecurityCOLA_Percent"], 0);
                _gLib._SetSyncUDWin("btnSocialSecurityCOLA_T", this.wRetirementStudio.wSocialSecurityCOLA_TIcon.btnSocialSecurityCOLA_T, dic["btnSocialSecurityCOLA_T"], 0);
                if (dic["btnSocialSecurityCOLA_V"] != "")
                {
                    iSocialSecurityCOLA_cbo_V = iIncrease_cbo_V + 1;
                    iIncrease_cbo_V = iIncrease_cbo_V + 1;
                    this.wRetirementStudio.wCommonComboBox_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iSocialSecurityCOLA_cbo_V.ToString());
                    _gLib._SetSyncUDWin("SocialSecurityCOLA_V_cbo", this.wRetirementStudio.wCommonComboBox_V.cbo_V, dic["SocialSecurityCOLA_V_cbo"], 0);
                }
                if (dic["btnSocialSecurityCOLA_Percent"] != "")
                {
                    iSocialSecurityCOLA_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iSocialSecurityCOLA_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("SocialSecurityCOLA_txt", this.wRetirementStudio.wCommonTXT.txt, dic["SocialSecurityCOLA_txt"], true, 0);
                }
                if (dic["btnSocialSecurityCOLA_T"] != "")
                {
                    iSocialSecurityCOLA_cbo_T = iIncrease_cbo_T + 1;
                    iIncrease_cbo_T = iIncrease_cbo_T + 1;
                    this.wRetirementStudio.wCommonComboBox_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, iSocialSecurityCOLA_cbo_T.ToString());
                    _gLib._SetSyncUDWin("SocialSecurityCOLA_T_cbo", this.wRetirementStudio.wCommonComboBox_T.cbo_T, dic["SocialSecurityCOLA_T_cbo"], 0);
                }

                // WorkingDaysPerYear_txt
                if (dic["WorkingDaysPerYear_txt"] != "")
                {
                    i415LimitIncrease_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, "3");
                    _gLib._SetSyncUDWin_ByClipboard("415LimitIncrease_txt", this.wRetirementStudio.wCommonTXT.txt, dic["WorkingDaysPerYear_txt"], true, 0);
                }

                //SoliTaxRate_txt
                if (dic["SoliTaxRate_txt"] != "")
                {
                    i415LimitIncrease_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, "4");
                    _gLib._SetSyncUDWin_ByClipboard("415LimitIncrease_txt", this.wRetirementStudio.wCommonTXT.txt, dic["SoliTaxRate_txt"], true, 0);
                }
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Mar-31
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("WorkingDaysPerYear", "260,00");
        ///    dic.Add("AdjustFactorrFromNextToGross", "1,00");
        ///    dic.Add("TaxTariff", "");
        ///    dic.Add("SoliTaxRate", "");
        ///    dic.Add("ChurchTaxRate", "");
        ///    pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_DE(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_OtherEconomicAssumption_DE(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_OtherEconomicAssumption_DE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("WorkingDaysPerYear", this.wRetirementStudio.wWorkingDaysPerYear_DE.txt, dic["WorkingDaysPerYear"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AdjustFactorrFromNextToGross", this.wRetirementStudio.wAdjustFactorrFromNextToGross_DE.txt, dic["AdjustFactorrFromNextToGross"], 0);
                _gLib._SetSyncUDWin("TaxTariff", this.wRetirementStudio.wTaxTariff_DE.cbo, dic["TaxTariff"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SoliTaxRate", this.wRetirementStudio.wSoliTaxRate_DE.txt, dic["SoliTaxRate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ChurchTaxRate", this.wRetirementStudio.wChurchTaxRate_DE.txt, dic["ChurchTaxRate"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                
                _gLib._VerifySyncUDWin("WorkingDaysPerYear", this.wRetirementStudio.wWorkingDaysPerYear_DE.txt, dic["WorkingDaysPerYear"], 0);
                _gLib._VerifySyncUDWin("AdjustFactorrFromNextToGross", this.wRetirementStudio.wAdjustFactorrFromNextToGross_DE.txt, dic["AdjustFactorrFromNextToGross"], 0);
                _gLib._VerifySyncUDWin("TaxTariff", this.wRetirementStudio.wTaxTariff_DE.cbo, dic["TaxTariff"], 0);
                _gLib._VerifySyncUDWin("SoliTaxRate", this.wRetirementStudio.wSoliTaxRate_DE.txt, dic["SoliTaxRate"], 0);
                _gLib._VerifySyncUDWin("ChurchTaxRate", this.wRetirementStudio.wChurchTaxRate_DE.txt, dic["ChurchTaxRate"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-July-30
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SameStructureForAllPeriods", "True");
        ///    dic.Add("SalCapInc_P", "Click");
        ///    dic.Add("S148Inc_P", "Click");
        ///    dic.Add("LimmGMPRate_P", "Click");
        ///    dic.Add("SalCapInc_txt", "");
        ///    dic.Add("S148Inc_txt", "1.0");
        ///    dic.Add("LimmGMPRate_txt", "");
        ///    pOtherEconomicAssumption._PopVerify_OtherEconomicAssumption_UK(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_OtherEconomicAssumption_UK(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_OtherEconomicAssumption_DE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iIndex_txt = 1;


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("SameStructureForAllPeriods", this.wRetirementStudio.wSameStructureForAll.rd, dic["SameStructureForAllPeriods"], 0);
                _gLib._SetSyncUDWin("SalCapInc_P", this.wRetirementStudio.wSalCapInc_P_UK.btn, dic["SalCapInc_P"], 0);
                _gLib._SetSyncUDWin("S148Inc_P", this.wRetirementStudio.wS148Inc_P_UK.btn, dic["S148Inc_P"], 0);
                _gLib._SetSyncUDWin("LimmGMPRate_P", this.wRetirementStudio.wLimGMPRate_P_UK.btn, dic["LimmGMPRate_P"], 0);

                if (dic["LimmGMPRate_P"] != "")
                {
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iIndex_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("LimmGMPRate_txt", this.wRetirementStudio.wCommonTXT.txt, dic["LimmGMPRate_txt"], 0);
                    iIndex_txt++;
                }

                if (dic["SalCapInc_P"] != "")
                {
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iIndex_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("SalCapInc_txt", this.wRetirementStudio.wCommonTXT.txt, dic["SalCapInc_txt"], 0);
                    iIndex_txt++;
                }

                if (dic["S148Inc_P"] != "")
                {
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iIndex_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("S148Inc_txt", this.wRetirementStudio.wCommonTXT.txt, dic["S148Inc_txt"], 0);
                    
                }

             
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._MsgBox("Warning", "No vierify codes here!");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Jan-29
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("AddRow", "click");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("NumberOfYears", "10");
        ///    dic.Add("Rate", "4.75");
        ///    pOtherEconomicAssumption._SalCapInc_TimeBased_Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _SalCapInc_TimeBased_Table(MyDictionary dic)
        {
            string sFunctionName = "_SalCapInc_TimeBased_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("AddRow", this.wRetirementStudio.wSalCapInc_AddRow.btn, dic["AddRow"], 0);

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wSalCapInc_grid.grid, "Click", 0, false, 94, 28);
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wSalCapInc_grid.grid, "Click", 0, false, 94, 28);


            int iRow = Convert.ToInt32(dic["iRow"]);
            string sRow = "";
            for (int i = 1; i < iRow; i++)
                sRow = sRow + "{Down}";


            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSalCapInc_grid.grid, "{PageUp}{PageUp}{Home}" + sRow);


            if (dic["NumberOfYears"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSalCapInc_grid.grid, "{space}");
                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": NumberOfYears", this.wRetirementStudio.wGrid_txt.txt.UICtlNumEditorEdit1, dic["NumberOfYears"], 0);
            }

            if (dic["Rate"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSalCapInc_grid.grid, "{Tab}{space}");
                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": Rate", this.wRetirementStudio.wGrid_txt.txt.UICtlNumEditorEdit1, dic["Rate"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-Jan-29
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("AddRow", "click");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("NumberOfYears", "10");
        ///    dic.Add("Rate", "4.75");
        ///    pOtherEconomicAssumption._S148Inc_TimeBased_Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _S148Inc_TimeBased_Table(MyDictionary dic)
        {
            string sFunctionName = "_S148Inc_TimeBased_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("AddRow", this.wRetirementStudio.wS148Inc_AddRow.btn, dic["AddRow"], 0);

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wS148Inc_grid.grid, "Click", 0, false, 94, 28);
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wS148Inc_grid.grid, "Click", 0, false, 94, 28);


            int iRow = Convert.ToInt32(dic["iRow"]);
            string sRow = "";
            for (int i = 1; i < iRow; i++)
                sRow = sRow + "{Down}";


            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wS148Inc_grid.grid, "{PageUp}{PageUp}{Home}" + sRow);


            if (dic["NumberOfYears"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wS148Inc_grid.grid, "{space}");
                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": NumberOfYears", this.wRetirementStudio.wGrid_txt.txt.UICtlNumEditorEdit1, dic["NumberOfYears"], 0);
            }

            if (dic["Rate"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wS148Inc_grid.grid, "{Tab}{space}");
                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": Rate", this.wRetirementStudio.wGrid_txt.txt.UICtlNumEditorEdit1, dic["Rate"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-Jan-29
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("AddRow", "click");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("NumberOfYears", "10");
        ///    dic.Add("Rate", "4.75");
        ///    pOtherEconomicAssumption._LimGMPRate_TimeBased_Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _LimGMPRate_TimeBased_Table(MyDictionary dic)
        {
            string sFunctionName = "_LimGMPRate_TimeBased_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("AddRow", this.wRetirementStudio.wLimGMPRate_AddRow.btn, dic["AddRow"], 0);

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLimGMPRate_grid.grid, "Click", 0, false, 94, 28);
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLimGMPRate_grid.grid, "Click", 0, false, 94, 28);


            int iRow = Convert.ToInt32(dic["iRow"]);
            string sRow = "";
            for (int i = 1; i < iRow; i++)
                sRow = sRow + "{Down}";


            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLimGMPRate_grid.grid, "{PageUp}{PageUp}{Home}" + sRow);


            if (dic["NumberOfYears"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLimGMPRate_grid.grid, "{space}");
                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": NumberOfYears", this.wRetirementStudio.wGrid_txt.txt.UICtlNumEditorEdit1, dic["NumberOfYears"], 0);
            }

            if (dic["Rate"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLimGMPRate_grid.grid, "{Tab}{space}");
                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": Rate", this.wRetirementStudio.wGrid_txt.txt.UICtlNumEditorEdit1, dic["Rate"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Mar-10
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("BenefitCapacityFactor", "");
        ///    dic.Add("PICO", "");
        ///    dic.Add("BenefitPICO", "");
        ///    dic.Add("MinimumSalaryPICO", "");
        ///    dic.Add("SSContributionCeilingPICO", "");
        ///    dic.Add("NumberOfBenefitPayments", "");
        ///    dic.Add("NumberofSalaryPeriod", "");
        ///    dic.Add("NumberofContributions", "");
        ///    dic.Add("MinmumSalary", "");
        ///    dic.Add("SocialSecurityContributionCeiling", "");
        ///    dic.Add("SocialSecurityMaximumBenefit", "");
        ///    pOtherEconomicAssumption._PopVerify_Main_BR(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main_BR(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main_BR";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("BenefitCapacityFactor", this.wRetirementStudio.wBenefitCapacityFactor.txt, dic["BenefitCapacityFactor"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PICO", this.wRetirementStudio.wPICO.txt, dic["PICO"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BenefitPICO", this.wRetirementStudio.wBenefitPICO.txt, dic["BenefitPICO"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MinimumSalaryPICO", this.wRetirementStudio.wMinSalaryPICO.txt, dic["MinimumSalaryPICO"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SSContributionCeilingPICO", this.wRetirementStudio.wSSContributionCeiling.txt, dic["SSContributionCeilingPICO"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NumberOfBenefitPayments", this.wRetirementStudio.wNumBenefitPayment.txt, dic["NumberOfBenefitPayments"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NumberofSalaryPeriod", this.wRetirementStudio.wNumSalaryPeriods.txt, dic["NumberofSalaryPeriod"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NumberofContributions", this.wRetirementStudio.wNumContributions.txt, dic["NumberofContributions"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MinmumSalary", this.wRetirementStudio.wMinSalary.txt, dic["MinmumSalary"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SocialSecurityContributionCeiling", this.wRetirementStudio.wSocialSecurityContributionCeiling.txt, dic["SocialSecurityContributionCeiling"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SocialSecurityMaximumBenefit", this.wRetirementStudio.wSocialSecurityMaximumBenefit.txt, dic["SocialSecurityMaximumBenefit"], 0);
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




    }
}
