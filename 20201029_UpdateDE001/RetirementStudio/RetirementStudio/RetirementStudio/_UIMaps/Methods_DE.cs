namespace RetirementStudio._UIMaps.Methods_DEClasses
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


    public partial class Methods_DE
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2013-May-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "2");
        ///    dic.Add("CostMethod", "Entry Age Normal");
        ///    dic.Add("MembershipDate", "MembershipDate1");
        ///    dic.Add("AnnualIncreaseRate", "SalaryScale");
        ///    dic.Add("EarliestEntryAgeMethod", "");
        ///    dic.Add("EarliestEntryAge_txt", "");
        ///    dic.Add("AllowNegativeNormal", "");
        ///    pMethods_DE._Table_TradeLiability(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Table_TradeLiability(MyDictionary dic)
        {
            string sFunctionName = "_Table_TradeLiability";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iRow = 1;
                string sRow = "";

                if (dic["iRow"] != "")
                    iRow = Convert.ToInt32(dic["iRow"]);

                for (int i = 1; i < iRow; i++)
                    sRow = sRow + "{Down}";

                _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "Click", 0, false, 80, 60);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, sRow, 0);


                if (dic["CostMethod"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "{Tab}");

                    string sChar = dic["CostMethod"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, sChar);

                    _gLib._SetSyncUDWin("CostMethod", this.wRetirementStudio.wCommon_cbo.cbo, dic["CostMethod"], 0);
                }

                if (dic["MembershipDate"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "{Tab}{Home}{Tab}{Tab}");

                    string sChar = dic["MembershipDate"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, sChar);

                    _gLib._SetSyncUDWin("CostMethod", this.wRetirementStudio.wCommon_cbo.cbo, dic["MembershipDate"], 0);
                }

                if (dic["AnnualIncreaseRate"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "{Tab}{Home}{Tab}{Tab}{Tab}");
                    
                    string sChar = dic["AnnualIncreaseRate"].Substring(0, 1);
                   
                    if (dic["AnnualIncreaseRate"] =="#1#")
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "{space}");
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, sChar);

                    _gLib._SetSyncUDWin("CostMethod", this.wRetirementStudio.wCommon_cbo.cbo, dic["AnnualIncreaseRate"], 0);

                }
                if (dic["EarliestEntryAgeMethod"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{Tab}");

                    string sChar = dic["EarliestEntryAgeMethod"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, sChar);

                    _gLib._SetSyncUDWin("CostMethod", this.wRetirementStudio.wCommon_cbo.cbo, dic["EarliestEntryAgeMethod"], 0);

                }

                if (dic["EarliestEntryAge_txt"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{Tab}{Tab}{Space}");

                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, dic["EarliestEntryAge_txt"], 0);
                }

                if (dic["AllowNegativeNormal"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Space}");

                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wTradeLiability_FPGrid.grid).ToUpper() != dic["AllowNegativeNormal"].ToUpper())
                        _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "{space}", 0);

                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wTradeLiability_FPGrid.grid).ToUpper() != dic["AllowNegativeNormal"].ToUpper())
                        _gLib._MsgBoxYesNo("", "Function Failed!!  in AllowNegativeNormal expected value is : " + dic["AllowNegativeNormal"] + ",but the actual value is: " + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wTradeLiability_FPGrid.grid));
                     }

            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-May-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "2");
        ///    dic.Add("CostMethod", "Entry Age Normal");
        ///    dic.Add("AnnualIncreaseRate", "SalaryScale");
        ///    pMethods_DE._Table_TradeLiability_Jubilee(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Table_TradeLiability_Jubilee(MyDictionary dic)
        {
            string sFunctionName = "_Table_TradeLiability_Jubilee";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iRow = 1;
                string sRow = "";

                if (dic["iRow"] != "")
                    iRow = Convert.ToInt32(dic["iRow"]);

                for (int i = 1; i < iRow; i++)
                    sRow = sRow + "{Down}";

                _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "Click", 0, false, 80, 60);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, sRow, 0);



                if (dic["CostMethod"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "Click", 0, false, 80, 60);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, sRow, 0);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "{Tab}");

                   
                    string sChar = dic["CostMethod"].Substring(0, 1);
                    if (sChar == "#") sChar = "a";
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, sChar);

                    _gLib._SetSyncUDWin("CostMethod", this.wRetirementStudio.wCommon_cbo.cbo, dic["CostMethod"], 0);
                }


                if (dic["AnnualIncreaseRate"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "Click", 0, false, 80, 60);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, sRow, 0);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, "{Tab}{Tab}");

                    string sChar = dic["AnnualIncreaseRate"].Substring(0, 1);
                    if (sChar == "#") 
                        sChar = "a";
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, sChar);

                    if (dic["AnnualIncreaseRate"].ToLower() == "null")
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wTradeLiability_FPGrid.grid, sChar + "{PageUp}{PageUp}{PageUp}");
                    else
                        _gLib._SetSyncUDWin("AnnualIncreaseRate", this.wRetirementStudio.wCommon_cbo.cbo, dic["AnnualIncreaseRate"], 0);

                }

            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "2");
        ///    dic.Add("CostMethod", "");
        ///    dic.Add("CompareToAccrued", "");
        ///    dic.Add("AllowNegativeNormal", "True");
        ///    pMethods_DE._Table_InternationalAccounting(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Table_InternationalAccounting(MyDictionary dic)
        {
            string sFunctionName = "_Table_InternationalAccounting";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iRow = 1;
                string sRow = "";

                if (dic["iRow"] != "")
                    iRow = Convert.ToInt32(dic["iRow"]);

                for (int i = 1; i < iRow; i++)
                    sRow = sRow + "{Down}";

                _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "Click", 0, false, 80, 60);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, sRow, 0);



                if (dic["CostMethod"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "Click", 0, false, 80, 60);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, sRow, 0);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "{Tab}");

                    string sChar = dic["CostMethod"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, sChar);

                    _gLib._SetSyncUDWin("CostMethod", this.wRetirementStudio.wCommon_cbo.cbo, dic["CostMethod"], 0);
                }


                if (dic["CompareToAccrued"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "Click", 0, false, 80, 60);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, sRow, 0);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "{Tab}{Tab}");

                    Clipboard.Clear();
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "C", 0, ModifierKeys.Control, false);
                    string sStatus = Clipboard.GetText();

                    if (sStatus.ToUpper().Contains(dic["CompareToAccrued"].ToUpper()))
                    {
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + ">: CompareToAccrued is alaready set to <" + dic["CompareToAccrued"] + ">");
                        return;
                    }

                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "{Space}");
                    Clipboard.Clear();
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "C", 0, ModifierKeys.Control, false);
                    sStatus = Clipboard.GetText();
                    if (!sStatus.ToUpper().Contains(dic["AllowNegativeNormal"].ToUpper()))
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + ">: Fail to set CompareToAccrued  to <" + dic["CompareToAccrued"] + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Failed to set CompareToAccrued as <" + dic["CompareToAccrued"] + ">");

                    }

                }


                if (dic["AllowNegativeNormal"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "Click", 0, false, 80, 60);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, sRow, 0);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "{Tab}{Tab}{Tab}");

                    Clipboard.Clear();
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "C", 0, ModifierKeys.Control, false);
                    string sStatus = Clipboard.GetText();

                    if (sStatus.ToUpper().Contains(dic["AllowNegativeNormal"].ToUpper()))
                    {
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + ">: AllowNegativeNormal is alaready set to <" + dic["AllowNegativeNormal"] + ">");
                        return;
                    }

                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "{Space}");
                    Clipboard.Clear();
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wInternationalAccounting_FPGrid.grid, "C", 0, ModifierKeys.Control, false);
                    sStatus = Clipboard.GetText();
                    if (!sStatus.ToUpper().Contains(dic["AllowNegativeNormal"].ToUpper()))
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + ">: Fail to set AllowNegativeNormal  to <" + dic["AllowNegativeNormal"] + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Failed to set AllowNegativeNormal as <" + dic["AllowNegativeNormal"] + ">");

                    }

                }

            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Dec-14 
        /// ruiyyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("AddRow", "");
        ///    dic.Add("DeleteRow", "");
        ///    dic.Add("VOShortName", "");
        ///    dic.Add("BenefitDefinition", "");
        ///    dic.Add("PSVCoverage", "True");
        ///    dic.Add("Tax", "True");
        ///    dic.Add("Trade", "True");
        ///    dic.Add("IntAcctng", "True");
        ///    pMethods_DE._Table_BenefitsToExclude(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Table_BenefitsToExclude(MyDictionary dic)
        {
            string sFunctionName = "_Table_BenefitsToExclude";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iRow = 1;


                if (dic["AddRow"] != "")
                    _gLib._SetSyncUDWin("VOShortName", this.wRetirementStudio.wBenefitToExclude_btn.btn, dic["AddRow"], 0);

                if (dic["DeleteRow"] != "")
                    _gLib._SetSyncUDWin("VOShortName", this.wRetirementStudio.wBenefitToExclude_DeleteRow.btn, dic["DeleteRow"], 0);
              
                            
                if (dic["iRow"] != "")
                    iRow = (Convert.ToInt32(dic["iRow"])) * ((this.wRetirementStudio.wBenefitToExclude_grid.grid.Height / 8) + 8);


                if (dic["VOShortName"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "Click", 0, false, 50, iRow);

                    string sChar = dic["VOShortName"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wBenefitToExclude_grid.grid, sChar);

                    _gLib._SetSyncUDWin("VOShortName", this.wRetirementStudio.wBenefitToExcludeItem.cbo, dic["VOShortName"], 0);
                }


                if (dic["BenefitDefinition"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "Click", 0, false, 150, iRow);
                
                    string sChar = dic["BenefitDefinition"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wBenefitToExclude_grid.grid, sChar);

                    _gLib._SetSyncUDWin("BenefitDefinition", this.wRetirementStudio.wBenefitToExcludeItem.cbo, dic["BenefitDefinition"], 0);
                }


                if (dic["PSVCoverage"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "Click", 0, false, this.wRetirementStudio.wBenefitToExclude_grid.grid.Width / 2, iRow);

                    if (dic["PSVCoverage"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBenefitToExclude_grid.grid).ToUpper()))
                       _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{space}", 0);
              
                }


                if (dic["Tax"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "Click", 0, false, 50, iRow);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{Tab}{Tab}{Tab}{space}", 0);

                    if (dic["Tax"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBenefitToExclude_grid.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{space}", 0);
                }


                if (dic["Trade"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "Click", 0, false, 50, iRow);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{Tab}{Tab}{Tab}{Tab}{space}", 0);

                    if (dic["Trade"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBenefitToExclude_grid.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{space}", 0);
                }


                if (dic["IntAcctng"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "Click", 0, false, 50, iRow);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{space}", 0);

                    if ( dic["IntAcctng"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBenefitToExclude_grid.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{space}", 0);
                }
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2015-Dec-14 
        /// ruiyyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("AddRow", "");
        ///    dic.Add("DeleteRow", "");
        ///    dic.Add("VOShortName", "");
        ///    dic.Add("BenefitDefinition", "");
        ///    dic.Add("Tax", "True");
        ///    dic.Add("Trade", "True");
        ///    dic.Add("IntAcctng", "True");
        ///    pMethods_DE._Table_BenefitsToExclude_Jubilee(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Table_BenefitsToExclude_Jubilee(MyDictionary dic)
        {
            string sFunctionName = "_Table_BenefitsToExclude_Jubilee";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iRow = 1;


                if (dic["AddRow"] != "")
                    _gLib._SetSyncUDWin("VOShortName", this.wRetirementStudio.wBenefitToExclude_btn.btn, dic["AddRow"], 0);

                if (dic["DeleteRow"] != "")
                    _gLib._SetSyncUDWin("VOShortName", this.wRetirementStudio.wBenefitToExclude_DeleteRow.btn, dic["DeleteRow"], 0);


                if (dic["iRow"] != "")
                    iRow = (Convert.ToInt32(dic["iRow"])) * ((this.wRetirementStudio.wBenefitToExclude_grid.grid.Height / 8) + 8);


                if (dic["VOShortName"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "Click", 0, false, 50, iRow);

                    string sChar = dic["VOShortName"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wBenefitToExclude_grid.grid, sChar);

                    _gLib._SetSyncUDWin("VOShortName", this.wRetirementStudio.wBenefitToExcludeItem.cbo, dic["VOShortName"], 0);
                }


                if (dic["BenefitDefinition"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "Click", 0, false, 150, iRow);

                    string sChar = dic["BenefitDefinition"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wBenefitToExclude_grid.grid, sChar);

                    _gLib._SetSyncUDWin("BenefitDefinition", this.wRetirementStudio.wBenefitToExcludeItem.cbo, dic["BenefitDefinition"], 0);
                }


                if (dic["Tax"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "Click", 0, false, 50, iRow);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{Tab}{Tab}{space}", 0);

                    if (dic["Tax"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBenefitToExclude_grid.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{space}", 0);
                }


                if (dic["Trade"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "Click", 0, false, 50, iRow);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{Tab}{Tab}{Tab}{space}", 0);

                    if (dic["Trade"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBenefitToExclude_grid.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{space}", 0);
                }


                if (dic["IntAcctng"] != "")
                {
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "Click", 0, false, 50, iRow);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{Tab}{Tab}{Tab}{Tab}{space}", 0);

                    if (dic["IntAcctng"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBenefitToExclude_grid.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBenefitToExclude_grid.grid, "{space}", 0);
                }
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
        ///    dic.Add("CheckDeferredVested", "True");
        ///    dic.Add("UseDeprecatedCOLAMethod", "True");
        ///    pMethods_DE._PopVerify_Methods_DE(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Methods_DE(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("CheckDeferredVested", this.wRetirementStudio.wCheckDeferredVested.chk, dic["CheckDeferredVested"], 0);
                _gLib._SetSyncUDWin("UseDeprecatedCOLAMethod", this.wRetirementStudio.wUseDeprecatedCOLAMethod.chk, dic["UseDeprecatedCOLAMethod"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("CheckDeferredVested", this.wRetirementStudio.wCheckDeferredVested.chk, dic["CheckDeferredVested"], 0);
                _gLib._VerifySyncUDWin("UseDeprecatedCOLAMethod", this.wRetirementStudio.wUseDeprecatedCOLAMethod.chk, dic["UseDeprecatedCOLAMethod"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Dec-21
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AddRow", "click");
        ///    dic.Add("DeleteRow", "");
        ///    dic.Add("iRow", "");
        ///    dic.Add("isDisableTrade", "");
        ///    dic.Add("VOShortName", "");
        ///    dic.Add("BenefitDefinition", "");
        ///    dic.Add("Trade", "True");
        ///    dic.Add("IntAcctng", "");
        ///    dic.Add("PUCOverride", "");
        ///    dic.Add("TUCOverride", "");
        ///    dic.Add("ServiceForProrate", "");
        ///    pMethods_DE._MethodOverrieds_Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _MethodOverrieds_Table(MyDictionary dic)
        {
            string sFunctionName = "_MethodOverrieds_Table";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRow = Convert.ToInt32(dic["iRow"]);
                string sBackTabs = "";

             

                for (int i = 1; i <= 100; i++)
                    sBackTabs = sBackTabs + "{tab}";

                   
                if (dic["AddRow"] != "")
                    _gLib._SetSyncUDWin("VOShortName", this.wRetirementStudio.wMethodOverrides_b.btn, dic["AddRow"], 0);  
                if (dic["DeleteRow"] != "")
                    _gLib._SetSyncUDWin("VOShortName", this.wRetirementStudio.MethodOverrides_DeleteRow.btn, dic["DeleteRow"], 0);


                _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "Click", 0, false, 50, 30);
                _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}", 0 );
                _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}", 0, ModifierKeys.Shift, false);


                if (dic["VOShortName"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Home}", 0, ModifierKeys.Control, false);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, sBackTabs, 0, ModifierKeys.Shift, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}");
                    }
                    string sChar = dic["VOShortName"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides.grid, sChar);

                    _gLib._SetSyncUDWin("VOShortName", this.wRetirementStudio.wBenefitToExcludeItem.cbo, dic["VOShortName"], 0);
                }


                if (dic["BenefitDefinition"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Home}", 0, ModifierKeys.Control, false);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, sBackTabs, 0, ModifierKeys.Shift, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}");
                    }
          
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}");
                   
                    string sChar = dic["BenefitDefinition"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides.grid, sChar);

                    _gLib._SetSyncUDWin("BenefitDefinition", this.wRetirementStudio.wBenefitToExcludeItem.cbo, dic["BenefitDefinition"], 0);
                }


                if (dic["Trade"] != "")
                {  
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Home}", 0, ModifierKeys.Control, false);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, sBackTabs, 0, ModifierKeys.Shift, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}");
                    }
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid,  "{Tab}{Tab}");

                    if (dic["Trade"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wMethodOverrides.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{space}{space}{space}", 0);
                    if (dic["Trade"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wMethodOverrides.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{space}{space}", 0); 
                    if (dic["Trade"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wMethodOverrides.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{space}", 0);

                    string sA = "";
                    if (dic["Trade"].ToUpper() != (sA = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wMethodOverrides.grid).ToUpper()))
                    _gLib._MsgBoxYesNo("", "Please check Trade value, exception values is :" + dic["IntAcctng"] + ", but actual value is: " + sA);   
                }


                if (dic["IntAcctng"] != "")
                {   
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Home}", 0, ModifierKeys.Control, false);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, sBackTabs, 0, ModifierKeys.Shift, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}");
                    }

                    if (dic["isDisableTrade"].ToLower() == "true")
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}{Tab}");
                    else
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid,  "{Tab}{Tab}{Tab}");

                    if (dic["IntAcctng"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wMethodOverrides.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{space}{space}{space}", 0);
                    if (dic["IntAcctng"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wMethodOverrides.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{space}{space}", 0);
                    if (dic["IntAcctng"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wMethodOverrides.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{space}", 0);
                 
                    string sA  = "";
                    if (dic["IntAcctng"].ToUpper() !=  (sA = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wMethodOverrides.grid).ToUpper()))
                        _gLib._MsgBoxYesNo("", "Please check IntAcctng value, exception values is :" +dic["IntAcctng"] + ", but actual value is: " +sA );   
                }


                if (dic["PUCOverride"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Home}", 0, ModifierKeys.Control, false);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, sBackTabs, 0, ModifierKeys.Shift, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}");
                    }

                    if (dic["isDisableTrade"].ToLower() == "true")
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}{Tab}{Tab}");
                    else
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}{Tab}{Tab}{Tab}", 0);

                    string sChar = dic["PUCOverride"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides.grid, sChar);

                    _gLib._SetSyncUDWin("PUCOverride", this.wRetirementStudio.wBenefitToExcludeItem.cbo, dic["PUCOverride"], 0);
                }


                if (dic["TUCOverride"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Home}", 0, ModifierKeys.Control, false);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, sBackTabs, 0, ModifierKeys.Shift, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}");
                    }

                    if (dic["isDisableTrade"].ToLower() == "true")
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}{Tab}{Tab}{Tab}");
                    else
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid,  "{Tab}{Tab}{Tab}{Tab}{Tab}", 0);

                    string sChar = dic["TUCOverride"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides.grid, sChar);

                    _gLib._SetSyncUDWin("TUCOverride", this.wRetirementStudio.wBenefitToExcludeItem.cbo, dic["TUCOverride"], 0);
                }


                if (dic["ServiceForProrate"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Home}", 0, ModifierKeys.Control, false);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, sBackTabs, 0, ModifierKeys.Shift, false);
                    for (int i = 1; i <= 200; i++)
                    {
                        if (iRow == (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wMethodOverrides.grid)) + 1)
                            break;
                        else
                            _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}");
                    }

                    if (dic["isDisableTrade"].ToLower() == "true")
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}");
                    else
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}", 0);

                    string sChar = dic["ServiceForProrate"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wMethodOverrides.grid, sChar);

                    _gLib._SetSyncUDWin("ServiceForProrate", this.wRetirementStudio.wBenefitToExcludeItem.cbo, dic["ServiceForProrate"], 0);
                }
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2015-Dec-21
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SameBeneficMethod", "");
        ///    dic.Add("iRow", "");
        ///    dic.Add("BenficiaryMethod", "");
        ///    dic.Add("DataFieldIndicating", "True");
        ///    dic.Add("UseCollectivePremium", "");
        ///    pMethods_DE._BenficiaryMethod_VO_Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _BenficiaryMethod_VO_Table(MyDictionary dic)
        {
            string sFunctionName = "_Table_InternationalAccounting";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("SameBeneficMethod", this.wRetirementStudio.wSameBeneficiaryMthodforAllVOs.chk, dic["SameBeneficMethod"], 0, false, 50, 55);

                int iRow = Convert.ToInt32(dic["iRow"]);
                String sRow = "";

                for (int i = 2; i <= iRow; i++)
                    sRow = sRow + "{Down}";

                _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wBeneficiaryMethod.grid, "Click", 0, false, 50, 55);
                _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBeneficiaryMethod.grid, "{PageUp}" + sRow );


                if (dic["BenficiaryMethod"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBeneficiaryMethod.grid, "{Tab}{Home}{Tab}{space}");

                    string sChar  = "B";
                    if (dic["BenficiaryMethod"].Substring(0, 1) != "#")
                        sChar = dic["BenficiaryMethod"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wBeneficiaryMethod.grid, sChar);

                    _gLib._SetSyncUDWin("BenficiaryMethod", this.wRetirementStudio.wBenefitToExcludeItem.cbo, dic["BenficiaryMethod"], 0);
                }


                if (dic["DataFieldIndicating"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBeneficiaryMethod.grid,  "{Tab}{Home}{Tab}{Tab}{space}");

                    string sChar = "B";
                    if (dic["DataFieldIndicating"].Substring(0, 1) != "#")
                        sChar = dic["BenficiaryMethod"].Substring(0, 1);
                   _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wBeneficiaryMethod.grid, sChar);

                    _gLib._SetSyncUDWin("DataFieldIndicating", this.wRetirementStudio.wBenefitToExcludeItem.cbo, dic["DataFieldIndicating"], 0);
                }


                if (dic["UseCollectivePremium"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBeneficiaryMethod.grid,  "{Tab}{Home}{Tab}{Tab}{Tab}{space}");

                    if (dic["UseCollectivePremium"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBeneficiaryMethod.grid).ToUpper()))
                        _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wMethodOverrides.grid, "{Space}", 0);

                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBeneficiaryMethod.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wBeneficiaryMethod.grid, "{Tab}");

                    if (dic["UseCollectivePremium"].ToUpper() != (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBeneficiaryMethod.grid).ToUpper()))
                        _gLib._MsgBoxYesNo("", "Fucntion:_BenficiaryMethod_VO_Table failed. the expression value is :<" + dic["UseCollectivePremium"] + "> but the actual value is :<" + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBeneficiaryMethod.grid)+">");

                }

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Nov-27
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("TradeLiability_SameMethodforAllVOs", "True");
        ///    dic.Add("IntAccLiability_SameMethodforAllVOs", "True");
        ///    pMethods_DE._Methods_Pension_DE006(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Methods_Pension_DE006(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("TradeLiability_SameMethodforAllVOs", this.wRetirementStudio.wTradeLiability_SameMethods.chx, dic["TradeLiability_SameMethodforAllVOs"], 0);
                _gLib._SetSyncUDWin("IntAccLiability_SameMethodforAllVOs", this.wRetirementStudio.wIntermationalAccounting_SameMethods.chx, dic["IntAccLiability_SameMethodforAllVOs"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("TradeLiability_SameMethodforAllVOs", this.wRetirementStudio.wTradeLiability_SameMethods.chx, dic["TradeLiability_SameMethodforAllVOs"], 0);
                _gLib._VerifySyncUDWin("IntAccLiability_SameMethodforAllVOs", this.wRetirementStudio.wIntermationalAccounting_SameMethods.chx, dic["IntAccLiability_SameMethodforAllVOs"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2016-Jan-05
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Description", "");
        ///    dic.Add("VOShortName", "");
        ///    dic.Add("Variable", "");
        ///    dic.Add("Age_cbo", "");
        ///    pMethods_DE._AdditionalValuesToOutput(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _AdditionalValuesToOutput(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                int iRow = Convert.ToInt32(dic["iRow"]);
                String sRow = "";

                for (int i = 2; i <= iRow; i++)
                    sRow = sRow + "{Down}";

                _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wAdditional_grid.grid, "Click", 0, false, 50, 20);
                _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wAdditional_grid.grid, "{PageUp}" + sRow);


                if (dic["Description"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wAdditional_grid.grid, "{space}{back}");
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wItem_txt.Edit, dic["Description"],0,true);
                }


                if (dic["VOShortName"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wAdditional_grid.grid, "{tab}{Home}{tab}{space}");
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wItem.cbo, dic["VOShortName"], 0);
                }


                if (dic["Variable"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wAdditional_grid.grid, "{tab}{Home}{tab}{tab}{space}");
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wItem.cbo, dic["Variable"], 0);
                }

                if (dic["Age_cbo"] != "")
                {
                    _gLib._SendKeysUDWin("FP Grid", this.wRetirementStudio.wAdditional_grid.grid, "{tab}{Home}{tab}{tab}{tab}{space}");
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wButton_V.btn, "click", 0);
                    _gLib._SetSyncUDWin("FP Grid", this.wRetirementStudio.wCommon_cbo.cbo, dic["Age_cbo"], 0);
                }

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
