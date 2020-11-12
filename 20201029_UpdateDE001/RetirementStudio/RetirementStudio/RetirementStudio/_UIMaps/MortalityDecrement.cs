namespace RetirementStudio._UIMaps.MortalityDecrementClasses
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


    public partial class MortalityDecrement
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2013-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PrescribedRates", "True");
        ///    dic.Add("SameStructureForAllPeriods", "");
        ///    dic.Add("PrePostCommencement", "");
        ///    dic.Add("PreDecrementPostCommencement", "");
        ///    dic.Add("UnisexMortality", "");
        ///    dic.Add("ProjectedStaticMortalit", "");
        ///    dic.Add("GenerationalMortality", "");
        ///    dic.Add("DisabledVsHealthy", "");
        ///    dic.Add("MemberVsSpouse", "");
        ///    pMortalityDecrement._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("PrescribedRates", this.wRetirementStudio.wPrescribedRates.rdPrescribedRates, dic["PrescribedRates"], 0);
                _gLib._SetSyncUDWin("SameStructureForAllPeriods", this.wRetirementStudio.wSameStructureForAllPeriods.rdSameStructureForAllPeriods, dic["SameStructureForAllPeriods"], 0);
                _gLib._SetSyncUDWin("PrePostCommencement", this.wRetirementStudio.wPrepostCommencement.rd, dic["PrePostCommencement"], 0);
                _gLib._SetSyncUDWin("PreDecrementPostCommencement", this.wRetirementStudio.wPreDecrementPrepost_rd.rd, dic["PreDecrementPostCommencement"], 0);
                _gLib._SetSyncUDWin("UnisexMortality", this.wRetirementStudio.wUnisexmortality.rd, dic["UnisexMortality"], 0);
                _gLib._SetSyncUDWin("ProjectedStaticMortalit", this.wRetirementStudio.wProjectedStaticMortality.rd, dic["ProjectedStaticMortalit"], 0);
                _gLib._SetSyncUDWin("GenerationalMortality", this.wRetirementStudio.wGenerationalMortality.rd, dic["GenerationalMortality"], 0);
                _gLib._SetSyncUDWin("DisabledVsHealthy", this.wRetirementStudio.wDisabledVsHealthy.chkDisabledVsHealthy, dic["DisabledVsHealthy"], 0);
                _gLib._SetSyncUDWin("MemberVsSpouse", this.wRetirementStudio.wMemberVsSpouse.chkMemberVsSpouse, dic["MemberVsSpouse"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("PrescribedRates", this.wRetirementStudio.wPrescribedRates.rdPrescribedRates, dic["PrescribedRates"], 0);
                _gLib._VerifySyncUDWin("SameStructureForAllPeriods", this.wRetirementStudio.wSameStructureForAllPeriods.rdSameStructureForAllPeriods, dic["SameStructureForAllPeriods"], 0);
                _gLib._VerifySyncUDWin("DisabledVsHealthy", this.wRetirementStudio.wDisabledVsHealthy.chkDisabledVsHealthy, dic["DisabledVsHealthy"], 0);
                _gLib._VerifySyncUDWin("MemberVsSpouse", this.wRetirementStudio.wMemberVsSpouse.chkMemberVsSpouse, dic["MemberVsSpouse"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Rate", "");
        ///    dic.Add("AsOfDate", "");
        ///    dic.Add("PercentEligible", "50.00");
        ///    dic.Add("Optoutoffinalprescr", "true");
        ///    pMortalityDecrement._PopVerify_PrescribedRates(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PrescribedRates(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PrescribedRates";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Rate", this.wRetirementStudio.wPrescribedRate_Rate.cboRate, dic["Rate"], 0);

                if (dic["AsOfDate"] != "")
                {
                    _gLib._SetSyncUDWin("Rate", this.wRetirementStudio.wPrescribedRate_Rate.cboRate, dic["Rate"], 0);
                    _gLib._SendKeysUDWin("AsOfDate", this.wRetirementStudio.wPrescribedRate_Rate.cboRate, "{tab}", 0);
                    _gLib._SetSyncUDWin_ByClipboard("AsOfDate", this.wRetirementStudio.wPrescribedRate_AsOfDate.cboAsOfDate.txtAsOfDate, dic["AsOfDate"], 0, false, false);
                    _gLib._VerifySyncUDWin("AsOfDate", this.wRetirementStudio.wPrescribedRate_AsOfDate.cboAsOfDate.txtAsOfDate, dic["AsOfDate"], 0);
                }
                _gLib._SetSyncUDWin_ByClipboard("PercentEligible", this.wRetirementStudio.wPrecribedReate_PercentEligible.txtPercentEligible, dic["PercentEligible"], true, 0);

                _gLib._SetSyncUDWin("Optoutoffinalprescr", this.wRetirementStudio.wOptoutoffinalprescr.chk, dic["Optoutoffinalprescr"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Rate", this.wRetirementStudio.wPrescribedRate_Rate.cboRate, dic["Rate"], 0);
                _gLib._VerifySyncUDWin("AsOfDate", this.wRetirementStudio.wPrescribedRate_AsOfDate.cboAsOfDate.txtAsOfDate, dic["AsOfDate"], 0);
                _gLib._VerifySyncUDWin("PercentEligible", this.wRetirementStudio.wPrecribedReate_PercentEligible.txtPercentEligible, dic["PercentEligible"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-June-1
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Mortality", "");
        ///    dic.Add("Mortality_Setback_M", "");
        ///    dic.Add("Mortality_Setback_F", ""); 
        ///    dic.Add("Mortality_Weighting_M", "");
        ///    dic.Add("Mortality_Weighting_F", "");
        ///    dic.Add("Mortality_cbo_2", "");
        ///    dic.Add("Mortality_Setback_M_NL", "");
        ///    dic.Add("Mortality_Setback_F_NL", "");
        ///    dic.Add("Disabled", "");
        ///    dic.Add("Disabled_Setback_M", "");
        ///    dic.Add("Disabled_Setback_F", "");
        ///    dic.Add("Disabled_Setback_combo", "");
        ///    dic.Add("Disabled_Weighting_M", "");
        ///    dic.Add("Disabled_Weighting_F", "");
        ///    dic.Add("Disabled_Setback_M_NL", "");
        ///    dic.Add("Disabled_Setback_F_NL", "");
        ///    dic.Add("ProjectionScale", "");
        ///    dic.Add("ProjectToYear", "");
        ///    dic.Add("Spouse", "");
        ///    dic.Add("Spouse_Weighting_M", "");
        ///    dic.Add("Spouse_Weighting_F", "");
        ///    dic.Add("ProportionMale", "");
        ///    dic.Add("ProportionFeMale", "");
        ///    pMortalityDecrement._PopVerify_SameStructureForAll(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SameStructureForAll(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_SameStructureForAll";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Mortality", this.wRetirementStudio.wSameStructureForAll_Mortality.cboMortality, dic["Mortality"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Mortality_Setback_M", this.wRetirementStudio.wSameStructureForAll_Mortality_Setback_M.txtMortality_Setback_M, dic["Mortality_Setback_M"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Mortality_Setback_F", this.wRetirementStudio.wSameStructureForAll_Mortality_Setback_F.txtMortality_Setback_F, dic["Mortality_Setback_F"], 0);

                _gLib._SetSyncUDWin("Mortality_cbo_2", this.wRetirementStudio.wMortalityIndex2.cbo, dic["Mortality_cbo_2"], 0);

                _gLib._SetSyncUDWin_ByClipboard("Mortality_Weighting_M", this.wRetirementStudio.wMortalityWeight_M.txt, dic["Mortality_Weighting_M"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Mortality_Weighting_F", this.wRetirementStudio.wMortalityWeight_F.txt, dic["Mortality_Weighting_F"], 0);


                _gLib._SetSyncUDWin_ByClipboard("Mortality_Setback_M_NL", this.wRetirementStudio.wSameStructureFroAll_Mortality_Setback_M_NL.txt.UI_numEditConstantEdit1, dic["Mortality_Setback_M_NL"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Mortality_Setback_F_NL", this.wRetirementStudio.wSameStructureFroAll_Mortality_Setback_F_NL.txt.UI_numEditConstantEdit1, dic["Mortality_Setback_F_NL"], 0);


                _gLib._SetSyncUDWin("Disabled", this.wRetirementStudio.wSameStructureForAll_Disabled.cboDisabled, dic["Disabled"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Disabled_Setback_M", this.wRetirementStudio.wSameStructureForAll_Disabled_Setback_M.txtDisabled_Setback_M, dic["Disabled_Setback_M"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Disabled_Setback_F", this.wRetirementStudio.wSameStructureForAll_Disabled_Setback_F.txtDisabled_Setback_F, dic["Disabled_Setback_F"], 0);
                _gLib._SetSyncUDWin("Disabled_Setback_combo", this.wRetirementStudio.wDisabledSetback_combo.cbo, dic["Disabled_Setback_combo"], 0);


                _gLib._SetSyncUDWin_ByClipboard("Disabled_Weighting_M", this.wRetirementStudio.wDisabledWeight_M.txt, dic["Disabled_Weighting_M"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Disabled_Weighting_F", this.wRetirementStudio.wDisabledWeight_F.txt, dic["Disabled_Weighting_F"], 0);


                _gLib._SetSyncUDWin_ByClipboard("Disabled_Setback_M_NL", this.wRetirementStudio.wSameStructureForAll_Disabled_Setback_M_NL.txt.UI_numEditTableSetbackEdit1, dic["Disabled_Setback_M_NL"], 0);

                if (dic["Disabled_Setback_F_NL"] != "")
                    _gLib._SendKeysUDWin("Disabled_Setback_F_NL", this.wRetirementStudio.wSameStructureForAll_Disabled_Setback_F_NL.txt.UI_numEditTableSetbackEdit1, "{Delete}{Delete}{Delete}{Back}{Back}{Back}" + dic["Disabled_Setback_F_NL"], 0);
                _gLib._VerifySyncUDWin("Disabled_Setback_F_NL", this.wRetirementStudio.wSameStructureForAll_Disabled_Setback_F_NL.txt, dic["Disabled_Setback_F_NL"], 0);

                _gLib._SetSyncUDWin("ProjectionScale", this.wRetirementStudio.wProjectionScale.cbo, dic["ProjectionScale"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ProjectToYear", this.wRetirementStudio.wProjectToYear.Edit.txt, dic["ProjectToYear"], 0);
                _gLib._SetSyncUDWin("Spouse", this.wRetirementStudio.wSpouse.cbo, dic["Spouse"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ProportionMale", this.wRetirementStudio.wMortalityProportion.UINudMortalityProportiEdit, dic["ProportionMale"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ProportionFeMale", this.wRetirementStudio.wSpouseProportionM.UINudSpouseProportionMEdit, dic["ProportionFeMale"], 0);

                _gLib._SetSyncUDWin_ByClipboard("Spouse_Weighting_M", this.wRetirementStudio.wSpouseWeight_M.txt, dic["Spouse_Weighting_M"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Spouse_Weighting_F", this.wRetirementStudio.wSpouseWeight_F.txt, dic["Spouse_Weighting_F"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Mortality", this.wRetirementStudio.wSameStructureForAll_Mortality.cboMortality, dic["Mortality"], 0);
                _gLib._VerifySyncUDWin("Mortality_Setback_M", this.wRetirementStudio.wSameStructureForAll_Mortality_Setback_M.txtMortality_Setback_M, dic["Mortality_Setback_M"], 0);
                _gLib._VerifySyncUDWin("Mortality_Setback_F", this.wRetirementStudio.wSameStructureForAll_Mortality_Setback_F.txtMortality_Setback_F, dic["Mortality_Setback_F"], 0);

                _gLib._VerifySyncUDWin("Disabled", this.wRetirementStudio.wSameStructureForAll_Disabled.cboDisabled, dic["Disabled"], 0);
                _gLib._VerifySyncUDWin("Disabled_Setback_M", this.wRetirementStudio.wSameStructureForAll_Disabled_Setback_M.txtDisabled_Setback_M, dic["Disabled_Setback_M"], 0);
                _gLib._VerifySyncUDWin("Disabled_Setback_F", this.wRetirementStudio.wSameStructureForAll_Disabled_Setback_F.txtDisabled_Setback_F, dic["Disabled_Setback_F"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Jan-21
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PreDecrement", "");
        ///    dic.Add("PreCommencement", "");
        ///    dic.Add("PostCommencement", "");
        ///    
        ///    dic.Add("PreDecrement_SetBack_M", "");
        ///    dic.Add("PreDecrement_SetBack_F", "");
        ///    dic.Add("PreDecrement_Weighting_M", "");
        ///    dic.Add("PreDecrement_Weighting_F", "");
        /// 
        ///    dic.Add("PreCommencement_SetBack_M", "");
        ///    dic.Add("PreCommencement_SetBack_F", "");
        ///    dic.Add("PreCommencement_Weighting_M", "");
        ///    dic.Add("PreCommencement_Weighting_F", "");
        /// 
        ///    dic.Add("PostCommencement_SetBack_M", "");
        ///    dic.Add("PostCommencement_SetBack_F", "");
        ///    dic.Add("PostCommencement_Weighting_M", "");
        ///    dic.Add("PostCommencement_Weighting_F", "");
        ///    pMortalityDecrement._PrePostCommencement(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PrePostCommencement(MyDictionary dic)
        {
            string sFunctionName = "_PrePostCommencement";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("PreDecrement", this.wRetirementStudio.wPreDecrementMale.cbo, dic["PreDecrement"], 0);
                _gLib._SetSyncUDWin("PreCommencement", this.wRetirementStudio.wPreCommencement.cbo, dic["PreCommencement"], 0);
                _gLib._SetSyncUDWin("PostCommencement", this.wRetirementStudio.wPostCommencement.cbo, dic["PostCommencement"], 0);


                _gLib._SetSyncUDWin_ByClipboard("PreDecrement_SetBack_M", this.wRetirementStudio.wPreDecrement_S_M.txt, dic["PreDecrement_SetBack_M"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PreDecrement_SetBack_F", this.wRetirementStudio.wPreDecrement_S_F.txt, dic["PreDecrement_SetBack_F"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PreDecrement_Weighting_M", this.wRetirementStudio.wPreDecrement_Weigh_M.txt, dic["PreDecrement_Weighting_M"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PreDecrement_Weighting_F", this.wRetirementStudio.wPreDecrement_Weigh_M.txt, dic["PreDecrement_Weighting_F"], 0);

                _gLib._SetSyncUDWin_ByClipboard("PreCommencement_SetBack_M", this.wRetirementStudio.wPreCommencement_S_M.txt, dic["PreCommencement_SetBack_M"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PreCommencement_SetBack_F", this.wRetirementStudio.wPreCommencement_S_F.txt, dic["PreCommencement_SetBack_F"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PreCommencement_Weighting_M", this.wRetirementStudio.wPreCommencement_Weight_M.txt, dic["PreCommencement_Weighting_M"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PreCommencement_Weighting_F", this.wRetirementStudio.wPreCommencement_Weight_F.txt, dic["PreCommencement_Weighting_F"], 0);

                _gLib._SetSyncUDWin_ByClipboard("PostCommencement_SetBack_M", this.wRetirementStudio.wPostCommencement_S_M.txt, dic["PostCommencement_SetBack_M"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PostCommencement_SetBack_F", this.wRetirementStudio.wPostCommencement_S_F.txt, dic["PostCommencement_SetBack_F"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PostCommencement_Weighting_M", this.wRetirementStudio.wPostCommencement_W_M.txt, dic["PostCommencement_Weighting_M"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PostCommencement_Weighting_F", this.wRetirementStudio.wPostCommencement_W_F.txt, dic["PostCommencement_Weighting_F"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-Jan-21
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PreCommencement", "");//optional
        ///    dic.Add("PreDecrement", "");
        ///    dic.Add("ProjectionScale_Pre", "");
        ///    
        ///    dic.Add("PostCommencement", "");
        ///    dic.Add("ProjectionScale_Post", "");
        ///    
        ///    dic.Add("Disabled", "");
        ///    dic.Add("ProjectionScale_Dis", "");
        ///    
        ///    dic.Add("Spouse", "");
        ///    dic.Add("ProjectionScale_Spouse", "");
        ///    pMortalityDecrement._PrePostCommencement_ANZ(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PrePostCommencement_ANZ(MyDictionary dic)
        {
            string sFunctionName = "_PrePostCommencement_ANZ";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("PreCommencement", this.wRetirementStudio.wPreCommencementMale.cbo, dic["PreCommencement"], 0);
                _gLib._SetSyncUDWin("PreDecrement", this.wRetirementStudio.wPreCommencement.cbo, dic["PreDecrement"], 0);
                _gLib._SetSyncUDWin("ProjectionScale_Pre", this.wRetirementStudio.wProjectionScale.cbo, dic["ProjectionScale_Pre"], 0);

                _gLib._SetSyncUDWin("PostCommencement", this.wRetirementStudio.wPostCommencement_ANZ.cbo, dic["PostCommencement"], 0);
                _gLib._SetSyncUDWin("ProjectionScale_Post", this.wRetirementStudio.wProjectionScale_Post.cbo, dic["ProjectionScale_Post"], 0);

                _gLib._SetSyncUDWin("Disabled", this.wRetirementStudio.wDisabled.cbo, dic["Disabled"], 0);
                _gLib._SetSyncUDWin("ProjectionScale_Dis", this.wRetirementStudio.wProjectionScale_Disabled.cbo, dic["ProjectionScale_Dis"], 0);

                _gLib._SetSyncUDWin("Spouse", this.wRetirementStudio.wSpouse.cbo, dic["Spouse"], 0);
                _gLib._SetSyncUDWin("ProjectionScale_Spouse", this.wRetirementStudio.wProjectionScale_Spouse.cbo, dic["ProjectionScale_Spouse"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
