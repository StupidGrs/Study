namespace RetirementStudio._UIMaps.GMPAdjustmentFactorsClasses
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
    using Accessibility;
    using RetirementStudio._ThridParty;
    using System.Threading;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    
    
    public partial class GMPAdjustmentFactors
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2015-June-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Act_FromValuation_S148Increases", "");
        ///    dic.Add("Act_FromValuation_FixedRateAt", "");
        ///    dic.Add("Act_FromValuation_FixedRateAt_V", "");
        ///    dic.Add("Act_FromValuation_FixedRateAt_D", "");
        ///    dic.Add("Act_FromValuation_PensionIncrease", "");
        ///    dic.Add("Act_FromValuation_FixedRateAt_V_cbo", "");
        ///    dic.Add("Act_FromValuation_FixedRateAt_D_txt", "");
        ///    dic.Add("Act_FromDate_S148Increases", "");
        ///    dic.Add("Act_FromDate_FixedRateAt", "");
        ///    dic.Add("Act_FromDate_FixedRateAt_V", "");
        ///    dic.Add("Act_FromDate_FixedRateAt_D", "");
        ///    dic.Add("Act_FromDate_PensionIncrease", "");
        ///    dic.Add("Act_FromDate_FixedRateAt_V_cbo", "");
        ///    dic.Add("Act_FromDate_FixedRateAt_D_txt", "");
        ///    dic.Add("Inact_S148Increases", "");
        ///    dic.Add("Inact_FixedRateAtDateOfLeaving", "");
        ///    dic.Add("Inact_FixedRateAt", "");
        ///    dic.Add("Inact_FixedDateAt_V", "");
        ///    dic.Add("Inact_FixedDateAt_D", "");
        ///    dic.Add("Inact_LimitedRate", "");
        ///    dic.Add("Inact_PensionIncrease", "");
        ///    dic.Add("Inact_FixedDateAt_V_cbo", "");
        ///    dic.Add("Inact_FixedDateAt_D_txt", "");
        ///    dic.Add("Increase_Pre88GMP_V", "");
        ///    dic.Add("Increase_Pre88GMP_P", "");
        ///    dic.Add("Increase_Pre88GMP_T", "");
        ///    dic.Add("Increase_Post88GMP_V", "");
        ///    dic.Add("Increase_Post88GMP_P", "");
        ///    dic.Add("Increase_Post88GMP_T", "");
        ///    dic.Add("Increase_Pre88GMPPension", "");
        ///    dic.Add("Increase_Post88GMPPension", "");
        ///    dic.Add("Increase_Pre88GMP_V_cbo", "");
        ///    dic.Add("Increase_Pre88GMP_P_txt", "");
        ///    dic.Add("Increase_Pre88GMP_T_cbo", "");
        ///    dic.Add("Increase_Post88GMP_V_cbo", "");
        ///    dic.Add("Increase_Post88GMP_P_txt", "");
        ///    dic.Add("Increase_Post88GMP_T_cbo", "");
        ///    pGMPAdjustmentFactors._PopVerify_GMPAdjustmentFactors(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GMPAdjustmentFactors(MyDictionary dic)
        {



            string sFunctionName = "_PopVerify_GMPAdjustmentFactors";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iCbo_V = 0;
            int iTxt_D = 0;
            int iTxt_P = 0;
            int iCbo_T = 0;
            


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Act_FromValuation_S148Increases", this.wRetirementStudio.wAct_FromValuation_S148Increases.rd, dic["Act_FromValuation_S148Increases"], 0);
                _gLib._SetSyncUDWin("Act_FromValuation_FixedRateAt", this.wRetirementStudio.wAct_FromValuation_FixedRateAt.rd, dic["Act_FromValuation_FixedRateAt"], 0);
                if (_gLib._Enabled("Act_FromValuation_FixedRateAt_V", this.wRetirementStudio.wAct_FromValuation_FixedRateAt_V.btn, 1, false))
                    _gLib._SetSyncUDWin("Act_FromValuation_FixedRateAt_V", this.wRetirementStudio.wAct_FromValuation_FixedRateAt_V.btn, dic["Act_FromValuation_FixedRateAt_V"], 0);
                if (_gLib._Enabled("Act_FromValuation_FixedRateAt_D", this.wRetirementStudio.wAct_FromValuation_FixedRateAt_D.btn, 1, false))
                    _gLib._SetSyncUDWin("Act_FromValuation_FixedRateAt_D", this.wRetirementStudio.wAct_FromValuation_FixedRateAt_D.btn, dic["Act_FromValuation_FixedRateAt_D"], 0);
                _gLib._SetSyncUDWin("Act_FromValuation_PensionIncrease", this.wRetirementStudio.wAct_FromValuation_PensionIncrease.cbo, dic["Act_FromValuation_PensionIncrease"], 0);

                if (dic["Act_FromValuation_FixedRateAt_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("Act_FromValuation_FixedRateAt_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Act_FromValuation_FixedRateAt_V_cbo"], 0);

                if (dic["Act_FromValuation_FixedRateAt_D"] != "") iTxt_D++;
                this.wRetirementStudio.wCommon_txt_D.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_D.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Act_FromValuation_FixedRateAt_D_txt", this.wRetirementStudio.wCommon_txt_D.cbo.txt, dic["Act_FromValuation_FixedRateAt_D_txt"], 0);


                _gLib._SetSyncUDWin("Act_FromDate_S148Increases", this.wRetirementStudio.wAct_FromDate_S148Increases.rd, dic["Act_FromDate_S148Increases"], 0);
                _gLib._SetSyncUDWin("Act_FromDate_FixedRateAt", this.wRetirementStudio.wAct_FromDate_FixedRateAt.rd, dic["Act_FromDate_FixedRateAt"], 0);

                if (_gLib._Enabled("Act_FromDate_FixedRateAt_V", this.wRetirementStudio.wAct_FromDate_FixedRateAt_V.btn, 1, false))
                    _gLib._SetSyncUDWin("Act_FromDate_FixedRateAt_V", this.wRetirementStudio.wAct_FromDate_FixedRateAt_V.btn, dic["Act_FromDate_FixedRateAt_V"], 0);
                if (_gLib._Enabled("Act_FromDate_FixedRateAt_D", this.wRetirementStudio.wAct_FromDate_FixedRateAt_D.btn, 1, false))
                    _gLib._SetSyncUDWin("Act_FromDate_FixedRateAt_D", this.wRetirementStudio.wAct_FromDate_FixedRateAt_D.btn, dic["Act_FromDate_FixedRateAt_D"], 0);
                _gLib._SetSyncUDWin("Act_FromDate_PensionIncrease", this.wRetirementStudio.wAct_FromDate_PensionIncrease.cbo, dic["Act_FromDate_PensionIncrease"], 0);

                if (dic["Act_FromDate_FixedRateAt_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("Act_FromDate_FixedRateAt_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Act_FromDate_FixedRateAt_V_cbo"], 0);

                if (dic["Act_FromDate_FixedRateAt_D"] != "") iTxt_D++;
                this.wRetirementStudio.wCommon_txt_D.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_D.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Act_FromDate_FixedRateAt_D_txt", this.wRetirementStudio.wCommon_txt_D.cbo.txt, dic["Act_FromDate_FixedRateAt_D_txt"], 0);





                _gLib._SetSyncUDWin("Inact_S148Increases", this.wRetirementStudio.wInact_S148Increases.rd, dic["Inact_S148Increases"], 0);
                _gLib._SetSyncUDWin("Inact_FixedRateAtDateOfLeaving", this.wRetirementStudio.wInact_FixedRateAtDateOfLeaving.rd, dic["Inact_FixedRateAtDateOfLeaving"], 0);
                _gLib._SetSyncUDWin("Inact_FixedRateAt", this.wRetirementStudio.wInact_FixedRateAt.rd, dic["Inact_FixedRateAt"], 0);
                if (_gLib._Enabled("Inact_FixedDateAt_V", this.wRetirementStudio.wInact_FixedDateAt_V.btn, 1, false))
                    _gLib._SetSyncUDWin("Inact_FixedDateAt_V", this.wRetirementStudio.wInact_FixedDateAt_V.btn, dic["Inact_FixedDateAt_V"], 0);
                if (_gLib._Enabled("Inact_FixedDateAt_D", this.wRetirementStudio.wInact_FixedDateAt_D.btn, 1, false))
                    _gLib._SetSyncUDWin("Inact_FixedDateAt_D", this.wRetirementStudio.wInact_FixedDateAt_D.btn, dic["Inact_FixedDateAt_D"], 0);
                _gLib._SetSyncUDWin("Inact_LimitedRate", this.wRetirementStudio.wInact_LimitedRate.rd, dic["Inact_LimitedRate"], 0);
                _gLib._SetSyncUDWin("Inact_PensionIncrease", this.wRetirementStudio.wInact_PensionIncrease.cbo, dic["Inact_PensionIncrease"], 0);

                if (dic["Inact_FixedDateAt_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("Inact_FixedDateAt_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Inact_FixedDateAt_V_cbo"], 0);

                if (dic["Inact_FixedDateAt_D"] != "") iTxt_D++;
                this.wRetirementStudio.wCommon_txt_D.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_D.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Inact_FixedDateAt_D_txt", this.wRetirementStudio.wCommon_txt_D.cbo.txt, dic["Inact_FixedDateAt_D_txt"], 0);



                _gLib._SetSyncUDWin("Increase_Pre88GMP_V", this.wRetirementStudio.wIncrease_Pre88GMP_V.btn, dic["Increase_Pre88GMP_V"], 0);
                _gLib._SetSyncUDWin("Increase_Pre88GMP_P", this.wRetirementStudio.wIncrease_Pre88GMP_P.btn, dic["Increase_Pre88GMP_P"], 0);
                _gLib._SetSyncUDWin("Increase_Pre88GMP_T", this.wRetirementStudio.wIncrease_Pre88GMP_T.btn, dic["Increase_Pre88GMP_T"], 0);
                _gLib._SetSyncUDWin("Increase_Post88GMP_V", this.wRetirementStudio.wIncrease_Post88GMP_V.btn, dic["Increase_Post88GMP_V"], 0);
                _gLib._SetSyncUDWin("Increase_Post88GMP_P", this.wRetirementStudio.wIncrease_Post88GMP_P.btn, dic["Increase_Post88GMP_P"], 0);
                _gLib._SetSyncUDWin("Increase_Post88GMP_T", this.wRetirementStudio.wIncrease_Post88GMP_T.btn, dic["Increase_Post88GMP_T"], 0);
                _gLib._SetSyncUDWin("Increase_Pre88GMPPension", this.wRetirementStudio.wIncrease_Pre88GMPPension.cbo, dic["Increase_Pre88GMPPension"], 0);
                _gLib._SetSyncUDWin("Increase_Post88GMPPension", this.wRetirementStudio.wIncrease_Post88GMPPension.cbo, dic["Increase_Post88GMPPension"], 0);

                if (dic["Increase_Pre88GMP_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("Increase_Pre88GMP_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Increase_Pre88GMP_V_cbo"], 0);

                if (dic["Increase_Pre88GMP_P"] != "") iTxt_P++;
                this.wRetirementStudio.wCommon_txt_P.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_P.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Increase_Pre88GMP_P_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["Increase_Pre88GMP_P_txt"], 0);

                if (dic["Increase_Pre88GMP_T"] != "") iCbo_T++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_T.ToString());
                _gLib._SetSyncUDWin("Increase_Pre88GMP_T_cbo", this.wRetirementStudio.wCommon_cbo_T.cbo, dic["Increase_Pre88GMP_T_cbo"], 0);

                if (dic["Increase_Post88GMP_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("Increase_Post88GMP_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Increase_Post88GMP_V_cbo"], 0);

                if (dic["Increase_Post88GMP_P"] != "") iTxt_P++;
                this.wRetirementStudio.wCommon_txt_P.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_P.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Increase_Post88GMP_P_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["Increase_Post88GMP_P_txt"], 0);

                if (dic["Increase_Post88GMP_T"] != "") iCbo_T++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_T.ToString());
                _gLib._SetSyncUDWin("Increase_Post88GMP_T_cbo", this.wRetirementStudio.wCommon_cbo_T.cbo, dic["Increase_Post88GMP_T_cbo"], 0);

            
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._MsgBox("", "No Verify functin here!");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
