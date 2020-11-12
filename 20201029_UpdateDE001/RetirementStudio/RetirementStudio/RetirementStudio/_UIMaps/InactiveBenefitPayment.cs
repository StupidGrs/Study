namespace RetirementStudio._UIMaps.InactiveBenefitPaymentClasses
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
    
    
    public partial class InactiveBenefitPayment
    {
        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2015-May-26
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("Operation", "");
        ///    dic.Add("BenefitAmount_cbo", "NonPreserved");
        ///    dic.Add("StartDate", "StartDate1");
        ///    dic.Add("StopDate", "");
        ///    dic.Add("BeneficiaryAmount_txt", "");
        ///    dic.Add("COLA", "PostCommencementCOLA");
        ///    pInactiveBenefitPayment._TBL_InactiveBenefits(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("iRow", "2");
        ///    dic.Add("Operation", "+");
        ///    dic.Add("BenefitAmount_cbo", "DeferredPastRevaluation");
        ///    dic.Add("StartDate", "StartDate1");
        ///    dic.Add("StopDate", "");
        ///    dic.Add("BeneficiaryAmount_txt", "");
        ///    dic.Add("COLA", "DeferredCOLA");
        ///    pInactiveBenefitPayment._TBL_InactiveBenefits(dic); 
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TBL_InactiveBenefits(MyDictionary dic)
        {
            string sFunctionName = "_TBL_InactiveBenefits";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRow = Convert.ToInt32(dic["iRow"]);

            
            int iPos_Y = 53 + 20*(iRow-1);


            _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 25, iPos_Y);
            
            

            if (dic["Operation"] != "")
            {
                //////_gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 25, iPos_Y);
                _gLib._SetSyncUDWin("Operation", this.wRetirementStudio.wCommon_cbo.cbo, dic["Operation"], 0);

            }

            if (dic["BenefitAmount_cbo"] != "")
            {
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 117, iPos_Y);
                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wCommon_V.btn, "Click", 0);
                _gLib._SetSyncUDWin("BenefitAmount_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["BenefitAmount_cbo"], 0);
            }

            if (dic["StartDate"] != "")
            {

                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 252, iPos_Y);

                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wCommon_cbo.cbo, dic["StartDate"].ToString().Substring(0, 1), false);
                _gLib._SetSyncUDWin("StartDate", this.wRetirementStudio.wCommon_cbo.cbo, dic["StartDate"], 0);
            }

            if (dic["StopDate"] != "")
            {
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 332, iPos_Y);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wCommon_cbo.cbo, dic["StopDate"].ToString().Substring(0, 1), false);
                _gLib._SetSyncUDWin("StopDate", this.wRetirementStudio.wCommon_cbo.cbo, dic["StopDate"], 0);
            }


            if (dic["BeneficiaryAmount_txt"] != "")
            {
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 420, iPos_Y);
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wCommon_C.btn, "Click", 0 );
                _gLib._SetSyncUDWin_ByClipboard("StopDate", this.wRetirementStudio.wCommon_txt.txt, dic["BeneficiaryAmount_txt"], 0);
            }

            if (dic["COLA"] != "")
            {
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 656, iPos_Y);
                _gLib._SendKeysUDWin("Table", this.wRetirementStudio.wCommon_cbo.cbo, dic["COLA"].ToString().Substring(0, 1), false);
                _gLib._SetSyncUDWin("COLA", this.wRetirementStudio.wCommon_cbo.cbo, dic["COLA"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

    }
}
