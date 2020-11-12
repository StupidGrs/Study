namespace RetirementStudio._UIMaps.LateRetirementFactorsClasses
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

    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using RetirementStudio._ThridParty;
    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._UIMaps.OutputManagerClasses;
    using RetirementStudio._UIMaps.TestCaseLibraryClasses;
    
    
    
    public partial class LateRetirementFactors
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
        ///    dic.Add("BenefitFrom_V", "");
        ///    dic.Add("BenefitFrom_C", "");
        ///    dic.Add("BenefitFrom_cbo", "");
        ///    dic.Add("BenefitFrom_txt", "");
        ///    dic.Add("ActuarialEquivalence_V", "");
        ///    dic.Add("ActuarialEquivalence_T", "");
        ///    dic.Add("ActuarialEquivalence_cbo_V", "");
        ///    pLateRetirementFactors._PopVerify_LateRetirementFactors_Standard(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_LateRetirementFactors_Standard(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_LateRetirementFactors_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("BenefitFrom_V", this.wRetirementStudio.wBenefitFrom_V.btn, dic["BenefitFrom_V"], 0);
                _gLib._SetSyncUDWin("BenefitFrom_C", this.wRetirementStudio.wBenefitFrom_C.btn, dic["BenefitFrom_C"], 0);
                _gLib._SetSyncUDWin("BenefitFrom_cbo", this.wRetirementStudio.wBenefitFrom_cbo.cbo, dic["BenefitFrom_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BenefitFrom_txt", this.wRetirementStudio.wBenefitFrom_txt.txt, dic["BenefitFrom_txt"], 0);

                _gLib._SetSyncUDWin("ActuarialEquivalence_V", this.wRetirementStudio.wActuarialEquivalence_V.btn, dic["ActuarialEquivalence_V"], 0);
                _gLib._SetSyncUDWin("ActuarialEquivalence_T", this.wRetirementStudio.wActuarialEquivalence_T.btn, dic["ActuarialEquivalence_T"], 0);
                _gLib._SetSyncUDWin("ActuarialEquivalence_cbo_V", this.wRetirementStudio.wActuarialEquivalence_cbo_V.cbo, dic["ActuarialEquivalence_cbo_V"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

 
                _gLib._VerifySyncUDWin("BenefitFrom_V", this.wRetirementStudio.wBenefitFrom_V.btn, dic["BenefitFrom_V"], 0);
                _gLib._VerifySyncUDWin("BenefitFrom_C", this.wRetirementStudio.wBenefitFrom_C.btn, dic["BenefitFrom_C"], 0);
                _gLib._VerifySyncUDWin("BenefitFrom_cbo", this.wRetirementStudio.wBenefitFrom_cbo.cbo, dic["BenefitFrom_cbo"], 0);
                _gLib._VerifySyncUDWin("BenefitFrom_txt", this.wRetirementStudio.wBenefitFrom_txt.txt, dic["BenefitFrom_txt"], 0);

                _gLib._VerifySyncUDWin("ActuarialEquivalence_V", this.wRetirementStudio.wActuarialEquivalence_V.btn, dic["ActuarialEquivalence_V"], 0);
                _gLib._VerifySyncUDWin("ActuarialEquivalence_T", this.wRetirementStudio.wActuarialEquivalence_T.btn, dic["ActuarialEquivalence_T"], 0);
                _gLib._VerifySyncUDWin("ActuarialEquivalence_cbo_V", this.wRetirementStudio.wActuarialEquivalence_cbo_V.cbo, dic["ActuarialEquivalence_cbo_V"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
