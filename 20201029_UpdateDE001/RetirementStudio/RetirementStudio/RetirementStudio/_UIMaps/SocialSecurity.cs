namespace RetirementStudio._UIMaps.SocialSecurityClasses
{
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;
    
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using System.Threading;
    using System.Diagnostics;

    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using RetirementStudio._ThridParty;
    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._UIMaps.OutputManagerClasses;
    using RetirementStudio._UIMaps.TestCaseLibraryClasses;


    public partial class SocialSecurity
    {
        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();
        

        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SaveThisBenefit", "");
        ///    dic.Add("Method_SpecialAsDefinedInData", "");
        ///    dic.Add("Method_Salary", "");
        ///    dic.Add("SSCC_Other_Rd", "");
        ///    dic.Add("SSCC_Other_cbo", "");
        ///    dic.Add("SSCC_Increase", "");
        ///    dic.Add("AktuellerRentenwert_Other_Rd", "");
        ///    dic.Add("AktuellerRentenwert_Other_cbo", "");
        ///    dic.Add("AktuellerRentenwert_Increase", "");
        ///    dic.Add("VorlDurchs_Other_Rd", "");
        ///    dic.Add("VorlDurchs_Other_cbo", "");
        ///    dic.Add("VorlDurchs_Increase", "");
        ///    pSocialSecurity._SocialSecurity(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _SocialSecurity(MyDictionary dic)
        {
            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("SaveThisBenefit", this.wRetirementStudio.wSavethisbenefitforaudit.chx, dic["SaveThisBenefit"], 0);
                _gLib._SetSyncUDWin("Method_SpecialAsDefinedInData", this.wRetirementStudio.wMethod_Specialasdefinedinda.rdbtn, dic["Method_SpecialAsDefinedInData"], 0);
                _gLib._SetSyncUDWin("Method_Salary", this.wRetirementStudio.wMethod_Salary.cbo, dic["Method_Salary"], 0);
                _gLib._SetSyncUDWin("SSCC_Other_Rd", this.wRetirementStudio.wSSCC_Other_Rd.rdbtn, dic["SSCC_Other_Rd"], 0);
                _gLib._SetSyncUDWin("SSCC_Other_cbo", this.wRetirementStudio.wSSCC_Other_CBO.cbo, dic["SSCC_Other_cbo"], 0);
                _gLib._SetSyncUDWin("SSCC_Increase", this.wRetirementStudio.wSSCC_Increase.cbo, dic["SSCC_Increase"], 0);
                _gLib._SetSyncUDWin("AktuellerRentenwert_Other_Rd", this.wRetirementStudio.wAktuellerRentenwer_Other_Rd.rdbtn, dic["AktuellerRentenwert_Other_Rd"], 0);
                _gLib._SetSyncUDWin("AktuellerRentenwert_Other_cbo", this.wRetirementStudio.wAktuellerRentenwer_Other_CBO.cbo, dic["AktuellerRentenwert_Other_cbo"], 0);
                _gLib._SetSyncUDWin("AktuellerRentenwert_Increase", this.wRetirementStudio.wAktuellerRentenwer_Increase.cbo, dic["AktuellerRentenwert_Increase"], 0);
                _gLib._SetSyncUDWin("VorlDurchs_Other_Rd", this.wRetirementStudio.wVorlDurchschn_Other_Rd.rdbtn, dic["VorlDurchs_Other_Rd"], 0);
                _gLib._SetSyncUDWin("VorlDurchs_Other_cbo", this.wRetirementStudio.wVorlDurchschn_Other_CBO.cbo, dic["VorlDurchs_Other_cbo"], 0);
                _gLib._SetSyncUDWin("VorlDurchs_Increase", this.wRetirementStudio.wVorlDurchschn_Increase.cbo, dic["VorlDurchs_Increase"], 0);
            }
        }



        /// <summary>
        /// 2016-Mar-11 
        ///  ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SalaryIncreaseAssumption", "");
        ///    dic.Add("PayProjection", "");
        ///    dic.Add("LifeExpectancyTable", "");
        ///    pSocialSecurity._SocialSecurity_BR(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _SocialSecurity_BR(MyDictionary dic)
        {
            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("SalaryIncreaseAssumption", this.wRetirementStudio.wSalaryIncreaseAss.cbo, dic["SalaryIncreaseAssumption"], 0);
                _gLib._SetSyncUDWin("PayProjection", this.wRetirementStudio.wPayProjection.cbo, dic["PayProjection"], 0);
                _gLib._SetSyncUDWin("LifeExpectancyTable", this.wRetirementStudio.wLifeExpectancyTable.cbo, dic["LifeExpectancyTable"], 0);
            }
        }



        /// <summary>
        /// 2016-Mar-11 
        ///  ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Calculation", "");
        ///    dic.Add("Override_V", "");
        ///    dic.Add("Override_C", "");
        ///    pSocialSecurity._CalculationOverrides(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _CalculationOverrides(MyDictionary dic)
        {
            if (dic["PopVerify"] == "Pop")
            {
               
                int iRow = Convert.ToInt32(dic["iRow"]);
                string sRow = "";

                for (int i = 1; i < iRow; i++)
                    sRow = sRow + "{Tab}{Tab}";

                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCalculationOverrides_grid.grid, "click", 0, false, 30, 20);
                _gLib._SendKeysUDWin("", this.wRetirementStudio.wCalculationOverrides_grid.grid, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}", 0, ModifierKeys.Shift, false);


                if (dic["Calculation"] != "")
                {
                    _gLib._SetSyncUDWin("", this.wRetirementStudio.wCalculationOverrides_grid.grid, "click", 0, false, 30, 20);
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wCalculationOverrides_grid.grid, "{Home}", 0, ModifierKeys.Control, false);

                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wCalculationOverrides_grid.grid, sRow + dic["Calculation"].Substring(0,1) , 0);

                    _gLib._SetSyncUDWin("", this.wRetirementStudio.wCalculation.cbo, dic["Calculation"], 0);
                }

                if (dic["Override_V"] != "")
                {
                    _gLib._SetSyncUDWin("Override_V", this.wRetirementStudio.wCalculationOverrides_grid.grid, "click", 0, false, 30, 20);
                    _gLib._SendKeysUDWin("Override_V", this.wRetirementStudio.wCalculationOverrides_grid.grid, "{Home}", 0, ModifierKeys.Control, false);

                    _gLib._SendKeysUDWin("Override_V", this.wRetirementStudio.wCalculationOverrides_grid.grid, sRow + "{Tab}{Space}", 0);

                    _gLib._SetSyncUDWin("Override_V", this.wRetirementStudio.wOverride_V.btn, "click", 0);

                    _gLib._SendKeysUDWin("Override_V", this.wRetirementStudio.wOverride.cbo, dic["Override_V"].Substring(0,1), 0);
                    _gLib._SetSyncUDWin("Override_V", this.wRetirementStudio.wOverride.cbo, dic["Override_V"], 0);
                }

                if (dic["Override_C"] != "")
                {
                    _gLib._SetSyncUDWin("Override_C", this.wRetirementStudio.wCalculationOverrides_grid.grid, "click", 0, false, 30, 20);
                    _gLib._SendKeysUDWin("Override_C", this.wRetirementStudio.wCalculationOverrides_grid.grid, "{Home}", 0, ModifierKeys.Control, false);

                    _gLib._SendKeysUDWin("Override_C", this.wRetirementStudio.wCalculationOverrides_grid.grid, sRow + "{Tab}{Space}", 0);

                    _gLib._SetSyncUDWin("Override_C", this.wRetirementStudio.wOverride_C.btn, "click", 0);
                    //_gLib._SendKeysUDWin("Override_C", this.wRetirementStudio.wOverride_txt.txt, "{Back}{Home}", 0);
                    _gLib._SendKeysUDWin_byPaste("Override_C", this.wRetirementStudio.wOverride_txt.txt, dic["Override_C"], 0, false);
                    ////_gLib._SetSyncUDWin("Override_C", this.wRetirementStudio.wOverride_txt.txt, dic["Override_C"], 0);
                }
            }
        }
    


    }
}
