namespace RetirementStudio._UIMaps.PBGCDollarMaxClasses
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
    
    
    public partial class PBGCDollarMax
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2017-May-16
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "True");
        ///    dic.Add("UserDefinedFOPAdjustment", "");
        ///    dic.Add("CustomCode", "");
        ///    pPBGCDollarMax._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._SetSyncUDWin("UserDefinedFOPAdjustment", this.wRetirementStudio.wUserDefinedFOPAdjustment.rd, dic["UserDefinedFOPAdjustment"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("UserDefinedFOPAdjustment", this.wRetirementStudio.wUserDefinedFOPAdjustment.rd, dic["UserDefinedFOPAdjustment"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2017-May-16
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("IgnoreAgeAdjustment", "True");
        ///    dic.Add("LawYear_ValuationYearPlus", "");
        ///    dic.Add("LawYear_ValuationYearsPlus_txt", "");
        ///    dic.Add("LawYear_SpecifiedYear", "");
        ///    dic.Add("LawYear_SpecifiedYear_txt", "");
        ///    dic.Add("FOP_FormOfPayment", "");
        ///    dic.Add("FOP_GuaranteePeriod_txt", "");
        ///    dic.Add("FOP_SurvivorPercent_txt", "");
        ///    dic.Add("User_DefinedFormOfPaymentAdjustment_txt", "");
        ///    pPBGCDollarMax._PopVerify_Standard(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("IgnoreAgeAdjustment", this.wRetirementStudio.wIgnoreAgeAdjustment.chk, dic["IgnoreAgeAdjustment"], 0);
                _gLib._SetSyncUDWin("LawYear_ValuationYearPlus", this.wRetirementStudio.wLawYear_ValuationYearPlus.rd, dic["LawYear_ValuationYearPlus"], 0);
                _gLib._SetSyncUDWin_ByClipboard("LawYear_ValuationYearsPlus_txt", this.wRetirementStudio.wLawYear_ValuationYearsPlus_txt.txt, dic["LawYear_ValuationYearsPlus_txt"], 0);
                _gLib._SetSyncUDWin("LawYear_SpecifiedYear", this.wRetirementStudio.wLawYear_SpecifiedYear.rd, dic["LawYear_SpecifiedYear"], 0);
                _gLib._SetSyncUDWin_ByClipboard("LawYear_SpecifiedYear_txt", this.wRetirementStudio.wLawYear_SpecifiedYear_txt.txt, dic["LawYear_SpecifiedYear_txt"], 0);

                _gLib._SetSyncUDWin("FOP_FormOfPayment", this.wRetirementStudio.wFOP_FormOfPayment.cbo, dic["FOP_FormOfPayment"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FOP_GuaranteePeriod_txt", this.wRetirementStudio.wFOP_GuaranteePeriod_txt.txt, dic["FOP_GuaranteePeriod_txt"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FOP_SurvivorPercent_txt", this.wRetirementStudio.wFOP_SurvivorPercent_txt.txt, dic["FOP_SurvivorPercent_txt"], 0);

                _gLib._SetSyncUDWin_ByClipboard("User_DefinedFormOfPaymentAdjustment_txt", this.wRetirementStudio.wFOP_GuaranteePeriod_txt.txt, dic["User_DefinedFormOfPaymentAdjustment_txt"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("IgnoreAgeAdjustment", this.wRetirementStudio.wIgnoreAgeAdjustment.chk, dic["IgnoreAgeAdjustment"], 0);
                _gLib._VerifySyncUDWin("LawYear_ValuationYearPlus", this.wRetirementStudio.wLawYear_ValuationYearPlus.rd, dic["LawYear_ValuationYearPlus"], 0);
                _gLib._VerifySyncUDWin("LawYear_ValuationYearsPlus_txt", this.wRetirementStudio.wLawYear_ValuationYearsPlus_txt.txt, dic["LawYear_ValuationYearsPlus_txt"], 0);
                _gLib._VerifySyncUDWin("LawYear_SpecifiedYear", this.wRetirementStudio.wLawYear_SpecifiedYear.rd, dic["LawYear_SpecifiedYear"], 0);
                _gLib._VerifySyncUDWin("LawYear_SpecifiedYear_txt", this.wRetirementStudio.wLawYear_SpecifiedYear_txt.txt, dic["LawYear_SpecifiedYear_txt"], 0);

                _gLib._VerifySyncUDWin("FOP_FormOfPayment", this.wRetirementStudio.wFOP_FormOfPayment.cbo, dic["FOP_FormOfPayment"], 0);
                _gLib._VerifySyncUDWin("FOP_GuaranteePeriod_txt", this.wRetirementStudio.wFOP_GuaranteePeriod_txt.txt, dic["FOP_GuaranteePeriod_txt"], 0);
                _gLib._VerifySyncUDWin("FOP_SurvivorPercent_txt", this.wRetirementStudio.wFOP_SurvivorPercent_txt.txt, dic["FOP_SurvivorPercent_txt"], 0);



            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
