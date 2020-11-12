namespace RetirementStudio._UIMaps.MaxPensionDefinitionClasses
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
    
    
    public partial class MaxPensionDefinition
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
        ///    dic.Add("MaximumPensionFormula", "");
        ///    dic.Add("EarlyRetirementFactors", "");
        ///    dic.Add("LifeConversionFactors", "");
        ///    dic.Add("LateRetirementFactors", "");
        ///    dic.Add("ERFForAgeReduction", "");
        ///    dic.Add("BridgeConversionFactors", "");
        ///    dic.Add("AppliesToAllBenefits", "");
        ///    pMaxPensionDefinition._PopVerify_Standard(dic); 
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
                _gLib._SetSyncUDWin("MaximumPensionFormula", this.wRetirementStudio.wMaximumPensionFormula.cbo, dic["MaximumPensionFormula"], 0);
                _gLib._SetSyncUDWin("EarlyRetirementFactors", this.wRetirementStudio.wEarlyRetirementFactors.cbo, dic["EarlyRetirementFactors"], 0);
                _gLib._SetSyncUDWin("LifeConversionFactors", this.wRetirementStudio.wLifeConversionFactors.cbo, dic["LifeConversionFactors"], 0);
                _gLib._SetSyncUDWin("LateRetirementFactors", this.wRetirementStudio.wLateRetirementFactors.cbo, dic["LateRetirementFactors"], 0);
                _gLib._SetSyncUDWin("ERFForAgeReduction", this.wRetirementStudio.wERFForAgeReduction.cbo, dic["ERFForAgeReduction"], 0);
                _gLib._SetSyncUDWin("BridgeConversionFactors", this.wRetirementStudio.wBridgeConversionFactors.cbo, dic["BridgeConversionFactors"], 0);
                _gLib._SetSyncUDWin("AppliesToAllBenefits", this.wRetirementStudio.wAppliesToAllBenefits.cbo, dic["AppliesToAllBenefits"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {


                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rd, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("MaximumPensionFormula", this.wRetirementStudio.wMaximumPensionFormula.cbo, dic["MaximumPensionFormula"], 0);
                _gLib._VerifySyncUDWin("EarlyRetirementFactors", this.wRetirementStudio.wEarlyRetirementFactors.cbo, dic["EarlyRetirementFactors"], 0);
                _gLib._VerifySyncUDWin("LifeConversionFactors", this.wRetirementStudio.wLifeConversionFactors.cbo, dic["LifeConversionFactors"], 0);
                _gLib._VerifySyncUDWin("LateRetirementFactors", this.wRetirementStudio.wLateRetirementFactors.cbo, dic["LateRetirementFactors"], 0);
                _gLib._VerifySyncUDWin("ERFForAgeReduction", this.wRetirementStudio.wERFForAgeReduction.cbo, dic["ERFForAgeReduction"], 0);
                _gLib._VerifySyncUDWin("BridgeConversionFactors", this.wRetirementStudio.wBridgeConversionFactors.cbo, dic["BridgeConversionFactors"], 0);
                _gLib._VerifySyncUDWin("AppliesToAllBenefits", this.wRetirementStudio.wAppliesToAllBenefits.cbo, dic["AppliesToAllBenefits"], 0);
            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
