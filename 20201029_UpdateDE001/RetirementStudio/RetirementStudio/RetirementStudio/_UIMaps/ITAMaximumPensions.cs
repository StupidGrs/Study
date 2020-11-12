namespace RetirementStudio._UIMaps.ITAMaximumPensionsClasses
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
    
    
    public partial class ITAMaximumPensions
    {
        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();



        /// <summary>
        /// 2015-May-28 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("StartingAmount_C", "");
        ///    dic.Add("StartingAmount_T", "");
        ///    dic.Add("StartingAmount_cbo", "");
        ///    dic.Add("ProjectFrom_cbo", "");
        ///    dic.Add("ProjectFrom_txt", "");
        ///    dic.Add("PayAverage", "");
        ///    dic.Add("MaximumBridge", "False");
        ///    dic.Add("CQPPDefinition", "");
        ///    dic.Add("UserDefinedProjection", "");
        ///    dic.Add("CombinedMaximum", "False");
        ///    dic.Add("3YearAverageYMPE", "");
        ///    dic.Add("ServiceForCalculation", "ITAService");
        ///    dic.Add("DeferralOptions", "");
        ///    dic.Add("DeferralOptions_C", "");
        ///    pITAMaximumPensions._PopVerify_Standard(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("StartingAmount_C", this.wRetirementStudio.wStartingAmount_C.btn, dic["StartingAmount_C"], 0);
                _gLib._SetSyncUDWin("StartingAmount_T", this.wRetirementStudio.wStartingAmount_T.btn, dic["StartingAmount_T"], 0);
                _gLib._SetSyncUDWin("StartingAmount_cbo", this.wRetirementStudio.wStartingAmount_cbo.cbo, dic["StartingAmount_cbo"], 0);
                _gLib._SetSyncUDWin("ProjectFrom_cbo", this.wRetirementStudio.wProjectFrom_cbo.cbo, dic["ProjectFrom_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ProjectFrom_txt", this.wRetirementStudio.wProjectFrom_txt.txt, dic["ProjectFrom_txt"], true, 0);
                _gLib._SetSyncUDWin("PayAverage", this.wRetirementStudio.wPayAverage.cbo, dic["PayAverage"], 0);
                _gLib._SetSyncUDWin("MaximumBridge", this.wRetirementStudio.wMaximumBridge.chk, dic["MaximumBridge"], 0);
                _gLib._SetSyncUDWin("CQPPDefinition", this.wRetirementStudio.wCQPPDefinition.cbo, dic["CQPPDefinition"], 0);
                _gLib._SetSyncUDWin("UserDefinedProjection", this.wRetirementStudio.wUserDefinedProjection.cbo, dic["UserDefinedProjection"], 0);
                _gLib._SetSyncUDWin("CombinedMaximum", this.wRetirementStudio.wCombinedMaximum.chk, dic["CombinedMaximum"], 0);
                _gLib._SetSyncUDWin("3YearAverageYMPE", this.wRetirementStudio.w3YearAverageYMPE.cbo, dic["3YearAverageYMPE"], 0);
                _gLib._SetSyncUDWin("ServiceForCalculation", this.wRetirementStudio.wServiceForCalculation.cbo, dic["ServiceForCalculation"], 0);
                _gLib._SetSyncUDWin("DeferralOptions", this.wRetirementStudio.wDeferralOptions.cbo, dic["DeferralOptions"], 0);
                _gLib._SetSyncUDWin("DeferralOptions_C", this.wRetirementStudio.wDeferralOptions_C.btn, dic["DeferralOptions_C"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

 
                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("StartingAmount_C", this.wRetirementStudio.wStartingAmount_C.btn, dic["StartingAmount_C"], 0);
                _gLib._VerifySyncUDWin("StartingAmount_T", this.wRetirementStudio.wStartingAmount_T.btn, dic["StartingAmount_T"], 0);
                _gLib._VerifySyncUDWin("StartingAmount_cbo", this.wRetirementStudio.wStartingAmount_cbo.cbo, dic["StartingAmount_cbo"], 0);
                _gLib._VerifySyncUDWin("ProjectFrom_cbo", this.wRetirementStudio.wProjectFrom_cbo.cbo, dic["ProjectFrom_cbo"], 0);
                _gLib._VerifySyncUDWin("ProjectFrom_txt", this.wRetirementStudio.wProjectFrom_txt.txt, dic["ProjectFrom_txt"], 0);
                _gLib._VerifySyncUDWin("PayAverage", this.wRetirementStudio.wPayAverage.cbo, dic["PayAverage"], 0);
                _gLib._VerifySyncUDWin("MaximumBridge", this.wRetirementStudio.wMaximumBridge.chk, dic["MaximumBridge"], 0);
                _gLib._VerifySyncUDWin("CQPPDefinition", this.wRetirementStudio.wCQPPDefinition.cbo, dic["CQPPDefinition"], 0);
                _gLib._VerifySyncUDWin("UserDefinedProjection", this.wRetirementStudio.wUserDefinedProjection.cbo, dic["UserDefinedProjection"], 0);
                _gLib._VerifySyncUDWin("CombinedMaximum", this.wRetirementStudio.wCombinedMaximum.chk, dic["CombinedMaximum"], 0);
                _gLib._VerifySyncUDWin("3YearAverageYMPE", this.wRetirementStudio.w3YearAverageYMPE.cbo, dic["3YearAverageYMPE"], 0);
                _gLib._VerifySyncUDWin("ServiceForCalculation", this.wRetirementStudio.wServiceForCalculation.cbo, dic["ServiceForCalculation"], 0);
                _gLib._VerifySyncUDWin("DeferralOptions", this.wRetirementStudio.wDeferralOptions.cbo, dic["DeferralOptions"], 0);
            }
 


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
