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
using Accessibility;
using RetirementStudio._ThridParty;
using System.Threading;
using System.Windows.Forms;

using RetirementStudio._UIMaps.FarPointClasses;
using RetirementStudio._Config;
using RetirementStudio._Libraries;


namespace RetirementStudio._UIMaps.SocialSecurityPIAFormulaClasses
{
    
    public partial class SocialSecurityPIAFormula
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2016-Jan-19
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("BenefitType", "");
        ///    dic.Add("FromToAgeDefinition", "");
        ///    dic.Add("FixedAge", "");
        ///    dic.Add("SSNRA", "");
        ///    dic.Add("ProjectedPay", "");
        ///    dic.Add("UseZeroEarningsBefore", "");
        ///    pSocialSecurityPIAFormula._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("BenefitType", this.wRetirementStudio.wBenefitType.cbo, dic["BenefitType"], 0);
                _gLib._SetSyncUDWin("FromToAgeDefinition", this.wRetirementStudio.wFromToAgeDefinition.cbo, dic["FromToAgeDefinition"], 0);
                _gLib._SetSyncUDWin("ProjectedPay", this.wRetirementStudio.wSSNRA_ProjectionPay.cbo, dic["ProjectedPay"], 0);
                _gLib._SetSyncUDWin("FixedAge", this.wRetirementStudio.wFixedAge.rd, dic["FixedAge"], 0);
                _gLib._SetSyncUDWin("SSNRA", this.wRetirementStudio.wSSNRA_rd.rd, dic["SSNRA"], 0);
                _gLib._SetSyncUDWin("ProjectedPay", this.wRetirementStudio.wSSNRA_ProjectionPay.cbo, dic["ProjectedPay"], 0);
                _gLib._SetSyncUDWin("UseZeroEarningsBefore", this.wRetirementStudio.wUseZeroEarningsBefore.chx, dic["UseZeroEarningsBefore"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", " function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




    }
}
