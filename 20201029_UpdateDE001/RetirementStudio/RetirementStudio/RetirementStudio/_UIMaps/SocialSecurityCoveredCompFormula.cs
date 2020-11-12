namespace RetirementStudio._UIMaps.SocialSecurityCoveredCompFormulaClasses
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

    
    
    public partial class SocialSecurityCoveredCompFormula
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();



        /// <summary>
        /// 2015-Aug-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("TaxableWageBase", "");
        ///    dic.Add("NearAgeOnTheValuationDate", "");
        ///    dic.Add("Final3Year_chx", "");
        ///    dic.Add("Final3Year_cbo", "");
        ///    dic.Add("RoundResultToNearest12", "");
        ///    pSocialSecurityCoveredCompFormula._PopVerify_Standard(dic); 

        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("TaxableWageBase", this.wRetirementStudio.wTaxableWageBase.chk, dic["TaxableWageBase"], 0);
                _gLib._SetSyncUDWin("NearAgeOnTheValuationDate", this.wRetirementStudio.wNearAgeOnTheValuationDate.rd, dic["NearAgeOnTheValuationDate"], 0);
                _gLib._SetSyncUDWin("Final3Year_chx", this.wRetirementStudio.wFinal3Year_chx.chx, dic["Final3Year_chx"], 0);
                _gLib._SetSyncUDWin("Final3Year_cbo", this.wRetirementStudio.wFinal3Year_cbo.cbo, dic["Final3Year_cbo"], 0);
                _gLib._SetSyncUDWin("RoundResultToNearest12", this.wRetirementStudio.wRoundResultToNearest12.rd, dic["RoundResultToNearest12"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("TaxableWageBase", this.wRetirementStudio.wTaxableWageBase.chk, dic["TaxableWageBase"], 0);
                _gLib._VerifySyncUDWin("NearAgeOnTheValuationDate", this.wRetirementStudio.wNearAgeOnTheValuationDate.rd, dic["NearAgeOnTheValuationDate"], 0);
                _gLib._VerifySyncUDWin("Final3Year_cbo", this.wRetirementStudio.wFinal3Year_cbo.cbo, dic["Final3Year_cbo"], 0);
                _gLib._VerifySyncUDWin("RoundResultToNearest12", this.wRetirementStudio.wRoundResultToNearest12.rd, dic["RoundResultToNearest12"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




    }


}
