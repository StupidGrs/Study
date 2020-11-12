namespace RetirementStudio._UIMaps.PayCreditClasses
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
    
    
    public partial class PayCredit
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2015-Aug-28
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ProjectedSalary", "");
        ///    dic.Add("ServiceBasedOn", "");
        ///    pPayCredit._PopVerify_Standard(dic); 

        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ProjectedSalary", this.wRetirementStudio.wProjectedSalary.cbo, dic["ProjectedSalary"], 0);
                _gLib._SetSyncUDWin("ServiceBasedOn", this.wRetirementStudio.wServiceBasedOn.cbo, dic["ServiceBasedOn"], 0);
     
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("ProjectedSalary", this.wRetirementStudio.wProjectedSalary.cbo, dic["ProjectedSalary"], 0);
                _gLib._VerifySyncUDWin("ServiceBasedOn", this.wRetirementStudio.wServiceBasedOn.cbo, dic["ServiceBasedOn"], 0);
     
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
