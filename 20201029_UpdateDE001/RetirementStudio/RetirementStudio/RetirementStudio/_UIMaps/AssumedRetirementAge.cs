namespace RetirementStudio._UIMaps.AssumedRetirementAgeClasses
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
    
    
    public partial class AssumedRetirementAge
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2015-Mar-31
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FromData", "True");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("AssumedRetirementAge_V", "Click");
        ///    dic.Add("AssumedRetirementAge_C", "");
        ///    dic.Add("AssumedRetirementAge_cbo", "AssumedRetirementAge");
        ///    dic.Add("AssumedRetirementAge_txt", "");
        ///    pAssumedRetirementAge._PopVerify_FromData(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_FromData(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FromData";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("FromData", this.wRetirementStudio.wFromData.rd, dic["FromData"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("AssumedRetirementAge_V", this.wRetirementStudio.wAssumedRetirementAge_V.btn, dic["AssumedRetirementAge_V"], 0);
                _gLib._SetSyncUDWin("AssumedRetirementAge_C", this.wRetirementStudio.wAssumedRetirementAge_C.btn, dic["AssumedRetirementAge_C"], 0);
                _gLib._SetSyncUDWin("AssumedRetirementAge_cbo", this.wRetirementStudio.wAssumedRetirementAge_cbo.cbo, dic["AssumedRetirementAge_cbo"], 0);
                _gLib._SetSyncUDWin("AssumedRetirementAge_txt", this.wRetirementStudio.wAssumedRetirementAge_txt.txt, dic["AssumedRetirementAge_txt"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("FromData", this.wRetirementStudio.wFromData.rd, dic["FromData"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("AssumedRetirementAge_V", this.wRetirementStudio.wAssumedRetirementAge_V.btn, dic["AssumedRetirementAge_V"], 0);
                _gLib._VerifySyncUDWin("AssumedRetirementAge_C", this.wRetirementStudio.wAssumedRetirementAge_C.btn, dic["AssumedRetirementAge_C"], 0);
                _gLib._VerifySyncUDWin("AssumedRetirementAge_cbo", this.wRetirementStudio.wAssumedRetirementAge_cbo.cbo, dic["AssumedRetirementAge_cbo"], 0);
                _gLib._VerifySyncUDWin("AssumedRetirementAge_txt", this.wRetirementStudio.wAssumedRetirementAge_txt.txt, dic["AssumedRetirementAge_txt"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2015-July-01
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Calculate", "True");
        ///    dic.Add("FromData", "");
        ///    dic.Add("CustomCode", "");
        ///    pAssumedRetirementAge._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FromData";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Calculate", this.wRetirementStudio.wCalculate.rd, dic["Calculate"], 0);
                _gLib._SetSyncUDWin("FromData", this.wRetirementStudio.wFromData.rd, dic["FromData"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Calculate", this.wRetirementStudio.wCalculate.rd, dic["Calculate"], 0);
                _gLib._VerifySyncUDWin("FromData", this.wRetirementStudio.wFromData.rd, dic["FromData"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rd, dic["CustomCode"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-July-01
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Fruhestmogliches", "");
        ///    dic.Add("Regelaltersgrenze", "");
        ///    dic.Add("ContractualRetureentAge", "");
        ///    dic.Add("OverwriteWithIndividualRetirementAge_chx", "");
        ///    dic.Add("OverwriteWithIndividual_Age_V", "");
        ///    dic.Add("OverwriteWithIndividual_Age_cbo", "");
        ///    dic.Add("OverwriteWithIndividual_Age_C", "");
        ///    dic.Add("OverwriteWithIndividual_Age_txt", "");
        ///    pAssumedRetirementAge._PopVerify_Calculate(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Calculate(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Calculate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Fruhestmogliches", this.wRetirementStudio.wFruhestmogliches.rd, dic["Fruhestmogliches"], 0);
                _gLib._SetSyncUDWin("Regelaltersgrenze", this.wRetirementStudio.wRegelaltersgrenze.rd, dic["Regelaltersgrenze"], 0);
                _gLib._SetSyncUDWin("ContractualRetureentAge", this.wRetirementStudio.wContractualRetirementAge.rd, dic["ContractualRetureentAge"], 0);
             
                _gLib._SetSyncUDWin("OverwriteWithIndividualRetirementAge_chx", this.wRetirementStudio.wOverwriteWithIndividualRetirementAge_chx.chx, dic["OverwriteWithIndividualRetirementAge_chx"], 0);
                
                _gLib._SetSyncUDWin("OverwriteWithIndividual_Age_V", this.wRetirementStudio.wBtn_V.btn, dic["OverwriteWithIndividual_Age_V"], 0);
                _gLib._SetSyncUDWin("OverwriteWithIndividual_Age_cbo", this.wRetirementStudio.wOverwriteWithIndividual_cbo.cbo, dic["OverwriteWithIndividual_Age_cbo"], 0);
                _gLib._SetSyncUDWin("OverwriteWithIndividual_Age_C", this.wRetirementStudio.wBtn_C.btn, dic["OverwriteWithIndividual_Age_C"], 0);
                _gLib._SetSyncUDWin("OverwriteWithIndividual_Age_txt", this.wRetirementStudio.wOverwriteWithIndividual_txt.Edit.txt, dic["OverwriteWithIndividual_Age_txt"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }


}
