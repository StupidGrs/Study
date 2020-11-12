namespace RetirementStudio._UIMaps.VersorgungsausgleichClasses
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


    using Accessibility;
    using RetirementStudio._ThridParty;
    using System.Threading;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;


    public partial class Versorgungsausgleich
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2013-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Reductionamount", "");
        ///    dic.Add("Reductionage_txt", "");
        ///    dic.Add("Benefitformula", "");
        ///    pVersorgungsausgleich._Versorgungsausgleich(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Versorgungsausgleich(MyDictionary dic)
        {
            if(dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Reductionamount",this.wRetirementStudio.wReductionAmount.cbo, dic["Reductionamount"],0);
                _gLib._SetSyncUDWin_ByClipboard("Reductionage_txt",this.wRetirementStudio.wReduction_txt.Edit.txt, dic["Reductionage_txt"],0);
                _gLib._SetSyncUDWin("Benefitformula", this.wRetirementStudio.wBenefitFormula.cbo, dic["Benefitformula"], 0);
            }
        }
    }
}
