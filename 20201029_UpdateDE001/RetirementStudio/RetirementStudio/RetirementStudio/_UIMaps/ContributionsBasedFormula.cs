namespace RetirementStudio._UIMaps.ContributionsBasedFormulaClasses
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

    
    
    public partial class ContributionsBasedFormula
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
        ///    dic.Add("SimpleLinearization", "True");
        ///    dic.Add("FormulaCalculated", "");
        ///    dic.Add("PreDefinedAmount", "");
        ///    dic.Add("AccountBalance", "");
        ///    dic.Add("PriodYear", "");
        ///    dic.Add("StartAge", "");
        ///    dic.Add("PreDefinedAmount_cbo", "");
        ///    dic.Add("TransformationRate_Percent", "");
        ///    dic.Add("TransformationRate_Rate", "");
        ///    dic.Add("TransformationRate_T", "");
        ///    dic.Add("TransformationRate_T_cbo", "");
        ///    pContributionsBasedFormula._ContributionsBasedFormula(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _ContributionsBasedFormula(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("SimpleLinearization", this.wRetirementStudio.wSimplelinearization.rd, dic["SimpleLinearization"], 0);
                _gLib._SetSyncUDWin("FormulaCalculated", this.wRetirementStudio.wFormulacalculated.rd, dic["FormulaCalculated"], 0);
                _gLib._SetSyncUDWin("PreDefinedAmount", this.wRetirementStudio.wPredefinedamount.rd ,dic["PreDefinedAmount"], 0);
                _gLib._SetSyncUDWin("AccountBalance", this.wRetirementStudio.wAccountBalance.cbo, dic["AccountBalance"], 0);
                _gLib._SetSyncUDWin("PriodYear", this.wRetirementStudio.wPriodYear.rd, dic["PriodYear"], 0);
                _gLib._SetSyncUDWin("StartAge", this.wRetirementStudio.wStartAge.cbo, dic["StartAge"], 0);
                _gLib._SetSyncUDWin("PreDefinedAmount_cbo", this.wRetirementStudio.wPreDefinedAmount_cbo.cbo, dic["PreDefinedAmount_cbo"], 0);
                _gLib._SetSyncUDWin("TransformationRate_Percent", this.wRetirementStudio.wTransformationP.Btn, dic["TransformationRate_Percent"], 0);
                _gLib._SetSyncUDWin("TransformationRate_T", this.wRetirementStudio.wT_btn.btn, dic["TransformationRate_T"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TransformationRate_Rate", this.wRetirementStudio.wTransformationEdit.Edit.txt, dic["TransformationRate_Rate"], 0);
                _gLib._SetSyncUDWin("TransformationRate_T_cbo", this.wRetirementStudio.wTransformationRate_T.cbo, dic["TransformationRate_T_cbo"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
