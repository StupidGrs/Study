namespace RetirementStudio._UIMaps.BreakFieldTextSubstitutionClasses
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
    
    public partial class BreakFieldTextSubstitution
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
        ///    dic.Add("iRow", "1");
        ///    dic.Add("BreakFieldValue", "REN2");
        ///    dic.Add("SubstitutionText", "The Second Plan Ren");
        ///    dic.Add("OK", "");
        ///    pBreakFieldTextSubstitution._Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Table(MyDictionary dic)
        {
            string sFunctionName = "_Table";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            int iRow = Convert.ToInt32(dic["iRow"]);

            _gLib._SetSyncUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution_FPGrid.grid, "Click", 0, false, 90, 30);
            _gLib._SendKeysUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution_FPGrid.grid, "{PgUp}{PgUp}{PgUp}{PgUp}{Home}");

            string sKeys = "";
            for (int i = 1; i < iRow; i++)
                sKeys = sKeys + "{Down}";

            _gLib._SendKeysUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution_FPGrid.grid, sKeys);


            if (dic["BreakFieldValue"] != "")
            {
                _gLib._SendKeysUDWin("BreakFieldValue", this.wBreakfieldtextsubstitution.wTextSubstitution_FPGrid.grid, dic["BreakFieldValue"]);
                _gLib._SendKeysUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution_FPGrid.grid, "{Tab}");
            }
            if (dic["SubstitutionText"] != "")
            {
                _gLib._SendKeysUDWin("SubstitutionText", this.wBreakfieldtextsubstitution.wTextSubstitution_FPGrid.grid, dic["SubstitutionText"]);
                _gLib._SendKeysUDWin("FPGrid", this.wBreakfieldtextsubstitution.wTextSubstitution_FPGrid.grid, "{Tab}");
            }

            _gLib._SetSyncUDWin("OK", this.wBreakfieldtextsubstitution.wOK.btn, dic["OK"], 0);



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
