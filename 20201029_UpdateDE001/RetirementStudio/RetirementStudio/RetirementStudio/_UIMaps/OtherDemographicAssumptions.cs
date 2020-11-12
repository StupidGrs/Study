namespace RetirementStudio._UIMaps.OtherDemographicAssumptionsClasses
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

    
    public partial class OtherDemographicAssumptions
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("cboPrescribedRates", "");
        ///    dic.Add("ApplyPercentMarriedAt", "");
        ///    dic.Add("btnPercentMarried_Percent", "");
        ///    dic.Add("btnPercentMarried_T", "");
        ///    dic.Add("txtPercentMarried_M", "80.0");
        ///    dic.Add("txtPercentMarried_F", "80.0");
        ///    dic.Add("cboPercentMarried", "");
        ///    dic.Add("btnDifferenceInSpouseAge_CIcon", "");
        ///    dic.Add("btnDifferenceInSpouseAge_TIcon", "");
        ///    dic.Add("txtDifferenceInSpouseAge_M", "-3");
        ///    dic.Add("txtDifferenceInSpouseAge_F", "3");
        ///    dic.Add("cboDifferenceInSpouseAge", "");
        ///    dic.Add("DifferenceInOrphanAge", "");
        ///    dic.Add("NumberOfChildren", "");
        ///    pOtherDemographicAssumptions._PopVerify_OtherDemographicAssumptions(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_OtherDemographicAssumptions(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_SameStructureForAllPeriods";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("cboPrescribedRates", this.wRetirementStudio.wPrescribedRates.cbo, dic["cboPrescribedRates"], 0);
                _gLib._SetSyncUDWin("ApplyPercentMarriedAt", this.wRetirementStudio.wApplyPercentMarriedAt.cbo, dic["ApplyPercentMarriedAt"], 0);
                _gLib._SetSyncUDWin("btnPercentMarried_Percent", this.wRetirementStudio.wPercentMarried_PercentIcon.btnPercentMarried_Percent, dic["btnPercentMarried_Percent"], 0);
                _gLib._SetSyncUDWin("btnPercentMarried_T", this.wRetirementStudio.wPercentMarried_TIcon.btnPercentMarried_T, dic["btnPercentMarried_T"], 0);
                _gLib._SetSyncUDWin_ByClipboard("txtPercentMarried_M", this.wRetirementStudio.wPercentMarried_M_txt.txtPercentMarried_M, dic["txtPercentMarried_M"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("txtPercentMarried_F", this.wRetirementStudio.wPercentMarried_F_txt.txtPercentMarried_F, dic["txtPercentMarried_F"], true, 0);
                _gLib._SetSyncUDWin("cboPercentMarried", this.wRetirementStudio.wPercentMarried_cbo.cboPercentMarried, dic["cboPercentMarried"], 0);
                _gLib._SetSyncUDWin("btnDifferenceInSpouseAge_CIcon", this.wRetirementStudio.wDifferenceInSpouseAge_CIcon.btnDifferenceInSpouseAge_CIcon, dic["btnDifferenceInSpouseAge_CIcon"], 0);
                _gLib._SetSyncUDWin("btnDifferenceInSpouseAge_TIcon", this.wRetirementStudio.wDifferenceInSpouseAge_TIcon.btnDifferenceInSpouseAge_TIcon, dic["btnDifferenceInSpouseAge_TIcon"], 0);
                _gLib._SetSyncUDWin_ByClipboard("txtDifferenceInSpouseAge_M", this.wRetirementStudio.wDifferenceInSpouseAge_M_txt.txtDifferenceInSpouseAge_M, dic["txtDifferenceInSpouseAge_M"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("txtDifferenceInSpouseAge_F", this.wRetirementStudio.wDifferenceInSpouseAge_F_txt.txtDifferenceInSpouseAge_F, dic["txtDifferenceInSpouseAge_F"], true, 0);
                _gLib._SetSyncUDWin("cboDifferenceInSpouseAge", this.wRetirementStudio.wDifferenceInSpouseAge_cbo.cboDifferenceInSpouseAge, dic["cboDifferenceInSpouseAge"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DifferenceInOrphanAge", this.wRetirementStudio.wNumDifOrphanAge.txt, dic["DifferenceInOrphanAge"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("NumberOfChildren", this.wRetirementStudio.wNumChildren.txt, dic["NumberOfChildren"], true, 0);

                
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("cboPrescribedRates", this.wRetirementStudio.wPrescribedRates.cbo, dic["cboPrescribedRates"], 0);
                _gLib._VerifySyncUDWin("ApplyPercentMarriedAt", this.wRetirementStudio.wApplyPercentMarriedAt.cbo, dic["ApplyPercentMarriedAt"], 0);
                _gLib._VerifySyncUDWin("btnPercentMarried_Percent", this.wRetirementStudio.wPercentMarried_PercentIcon.btnPercentMarried_Percent, dic["btnPercentMarried_Percent"], 0);
                _gLib._VerifySyncUDWin("btnPercentMarried_T", this.wRetirementStudio.wPercentMarried_TIcon.btnPercentMarried_T, dic["btnPercentMarried_T"], 0);
                _gLib._VerifySyncUDWin("txtPercentMarried_M", this.wRetirementStudio.wPercentMarried_M_txt.txtPercentMarried_M, dic["txtPercentMarried_M"], 0);
                _gLib._VerifySyncUDWin("txtPercentMarried_F", this.wRetirementStudio.wPercentMarried_F_txt.txtPercentMarried_F, dic["txtPercentMarried_F"], 0);
                _gLib._VerifySyncUDWin("cboPercentMarried", this.wRetirementStudio.wPercentMarried_cbo.cboPercentMarried, dic["cboPercentMarried"], 0);
                _gLib._VerifySyncUDWin("btnDifferenceInSpouseAge_CIcon", this.wRetirementStudio.wDifferenceInSpouseAge_CIcon.btnDifferenceInSpouseAge_CIcon, dic["btnDifferenceInSpouseAge_CIcon"], 0);
                _gLib._VerifySyncUDWin("btnDifferenceInSpouseAge_TIcon", this.wRetirementStudio.wDifferenceInSpouseAge_TIcon.btnDifferenceInSpouseAge_TIcon, dic["btnDifferenceInSpouseAge_TIcon"], 0);
                _gLib._VerifySyncUDWin("txtDifferenceInSpouseAge_M", this.wRetirementStudio.wDifferenceInSpouseAge_M_txt.txtDifferenceInSpouseAge_M, dic["txtDifferenceInSpouseAge_M"], 0);
                _gLib._VerifySyncUDWin("txtDifferenceInSpouseAge_F", this.wRetirementStudio.wDifferenceInSpouseAge_F_txt.txtDifferenceInSpouseAge_F, dic["txtDifferenceInSpouseAge_F"], 0);
                _gLib._VerifySyncUDWin("cboDifferenceInSpouseAge", this.wRetirementStudio.wDifferenceInSpouseAge_cbo.cboDifferenceInSpouseAge, dic["cboDifferenceInSpouseAge"], 0);


            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
