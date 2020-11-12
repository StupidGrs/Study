namespace RetirementStudio._UIMaps.CostOfLivingAdjustments_UKClasses
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
    
    
    public partial class CostOfLivingAdjustments_UK
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
        ///    dic.Add("StatutoryCPI", "");
        ///    dic.Add("StatutoryRPI", "");
        ///    dic.Add("WholeDPRevaluation", "");
        ///    pCostOfLivingAdjustments_UK._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("StatutoryCPI", this.wRetirementStudio.wStatutoryCPI.rd, dic["StatutoryCPI"], 0);
                _gLib._SetSyncUDWin("StatutoryRPI", this.wRetirementStudio.wStatutoryRPI.rd, dic["StatutoryRPI"], 0);
                _gLib._SetSyncUDWin("WholeDPRevaluation", this.wRetirementStudio.wWholeDPRevaluation.chk, dic["WholeDPRevaluation"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("StatutoryCPI", this.wRetirementStudio.wStatutoryCPI.rd, dic["StatutoryCPI"], 0);
                _gLib._VerifySyncUDWin("StatutoryRPI", this.wRetirementStudio.wStatutoryRPI.rd, dic["StatutoryRPI"], 0);
                _gLib._VerifySyncUDWin("WholeDPRevaluation", this.wRetirementStudio.wWholeDPRevaluation.chk, dic["WholeDPRevaluation"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2015-June-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("WholeDPRevaluation_Checked", "false");
        ///    dic.Add("Revaluation_DeferredPension", "");
        ///    dic.Add("Revaluation_Rate_V", "");
        ///    dic.Add("Revaluation_Rate_P", "");
        ///    dic.Add("Revaluation_Rate_T", "");
        ///    dic.Add("Revaluation_Rate_V_cbo", "");
        ///    dic.Add("Revaluation_Rate_P_txt", "");
        ///    dic.Add("Revaluation_Rate_T_cbo", "");
        ///    dic.Add("Revaluation_CumulativeMax", "");
        ///    dic.Add("Revaluation_PensionIncrease", "");
        ///    dic.Add("Increase_Starts_YearsFrom", "");
        ///    dic.Add("Increase_Starts_Date_V", "");
        ///    dic.Add("Increase_Starts_Date_D", "");
        ///    dic.Add("Increase_Starts_Date_V_cbo", "");
        ///    dic.Add("Increase_Starts_Date_D_txt", "");
        ///    dic.Add("Increase_Ends_YearsFrom", "");
        ///    dic.Add("Increase_Ends_Date_V", "");
        ///    dic.Add("Increase_Ends_Date_D", "");
        ///    dic.Add("Increase_Ends_Date_V_cbo", "");
        ///    dic.Add("Increase_Ends_Date_D_txt", "");
        ///    dic.Add("Increase_Amount_Rate_V", "");
        ///    dic.Add("Increase_Amount_Rate_P", "");
        ///    dic.Add("Increase_Amount_Rate_T", "");
        ///    dic.Add("Increase_Amount_Rate_V_cbo", "");
        ///    dic.Add("Increase_Amount_Rate_P_txt", "");
        ///    dic.Add("Increase_Amount_Rate_T_cbo", "");
        ///    dic.Add("Increase_Pension", "");
        ///    pCostOfLivingAdjustments_UK._PopVerify_StatutoryCPIRPI(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_StatutoryCPIRPI(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_StatutoryCPIRPI";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iCbo_V = 0;
            int iTxt_P = 0;
            int iCbo_T = 0;
            int iTxt_D = 0;


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Revaluation_DeferredPension", this.wRetirementStudio.wRevaluation_DeferredPension.chk, dic["Revaluation_DeferredPension"], 0);
                _gLib._SetSyncUDWin("Revaluation_Rate_V", this.wRetirementStudio.wRevaluation_Rate_V.btn, dic["Revaluation_Rate_V"], 0);
                _gLib._SetSyncUDWin("Revaluation_Rate_P", this.wRetirementStudio.wRevaluation_Rate_P.btn, dic["Revaluation_Rate_P"], 0);
                _gLib._SetSyncUDWin("Revaluation_Rate_T", this.wRetirementStudio.wRevaluation_Rate_T.btn, dic["Revaluation_Rate_T"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Revaluation_CumulativeMax", this.wRetirementStudio.wRevaluation_CumulativeMax.txt, dic["Revaluation_CumulativeMax"], 0);
                _gLib._SetSyncUDWin("Revaluation_PensionIncrease", this.wRetirementStudio.wRevaluation_PensionIncrease.cbo, dic["Revaluation_PensionIncrease"], 0);

                if (dic["Revaluation_Rate_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("Revaluation_Rate_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Revaluation_Rate_V_cbo"], 0);

                if (dic["Revaluation_Rate_P"] != "") iTxt_P++;
                this.wRetirementStudio.wCommon_txt_P.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_P.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Revaluation_Rate_P_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["Revaluation_Rate_P_txt"], 0);

                if (dic["Revaluation_Rate_T"] != "") iCbo_T++;
                this.wRetirementStudio.wCommon_cbo_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_T.ToString());
                _gLib._SetSyncUDWin("Revaluation_Rate_T_cbo", this.wRetirementStudio.wCommon_cbo_T.cbo, dic["Revaluation_Rate_T_cbo"], 0);


                if (dic["WholeDPRevaluation_Checked"].ToUpper().Equals("TRUE"))
                {
                    this.wRetirementStudio.wIncrease_Starts_Date_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, "3");
                    this.wRetirementStudio.wIncrease_Ends_Date_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, "4");
                    this.wRetirementStudio.wIncrease_Amount_Rate_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, "5");
                }

                _gLib._SetSyncUDWin("Increase_Starts_YearsFrom", this.wRetirementStudio.wIncrease_Starts_YearsFrom.cbo, dic["Increase_Starts_YearsFrom"], 0);
                _gLib._SetSyncUDWin("Increase_Starts_Date_V", this.wRetirementStudio.wIncrease_Starts_Date_V.btn, dic["Increase_Starts_Date_V"], 0);
                _gLib._SetSyncUDWin("Increase_Starts_Date_D", this.wRetirementStudio.wIncrease_Starts_Date_D.btn, dic["Increase_Starts_Date_D"], 0);

                if (dic["Increase_Starts_Date_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("Increase_Starts_Date_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Increase_Starts_Date_V_cbo"], 0);

                if (dic["Increase_Starts_Date_D"] != "") iTxt_D++;
                this.wRetirementStudio.wCommon_txt_D.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_D.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Increase_Starts_Date_D_txt", this.wRetirementStudio.wCommon_txt_D.cbo.txt, dic["Increase_Starts_Date_D_txt"], 0);



                _gLib._SetSyncUDWin("Increase_Ends_YearsFrom", this.wRetirementStudio.wIncrease_Ends_YearsFrom.cbo, dic["Increase_Ends_YearsFrom"], 0);
                _gLib._SetSyncUDWin("Increase_Ends_Date_V", this.wRetirementStudio.wIncrease_Ends_Date_V.btn, dic["Increase_Ends_Date_V"], 0);
                _gLib._SetSyncUDWin("Increase_Ends_Date_D", this.wRetirementStudio.wIncrease_Ends_Date_D.btn, dic["Increase_Ends_Date_D"], 0);

                if (dic["Increase_Ends_Date_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("Increase_Ends_Date_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Increase_Ends_Date_V_cbo"], 0);

                if (dic["Increase_Ends_Date_D"] != "") iTxt_D++;
                this.wRetirementStudio.wCommon_txt_D.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_D.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Increase_Ends_Date_D_txt", this.wRetirementStudio.wCommon_txt_D.cbo.txt, dic["Increase_Ends_Date_D_txt"], 0);



                _gLib._SetSyncUDWin("Increase_Amount_Rate_V", this.wRetirementStudio.wIncrease_Amount_Rate_V.btn, dic["Increase_Amount_Rate_V"], 0);
                _gLib._SetSyncUDWin("Increase_Amount_Rate_P", this.wRetirementStudio.wIncrease_Amount_Rate_P.btn, dic["Increase_Amount_Rate_P"], 0);
                _gLib._SetSyncUDWin("Increase_Amount_Rate_T", this.wRetirementStudio.wIncrease_Amount_Rate_T.btn, dic["Increase_Amount_Rate_T"], 0);
                
                if (dic["Increase_Amount_Rate_V"] != "") iCbo_V++;
                this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_V.ToString());
                _gLib._SetSyncUDWin("Increase_Amount_Rate_V_cbo", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["Increase_Amount_Rate_V_cbo"], 0);

                if (dic["Increase_Amount_Rate_P"] != "") iTxt_P++;
                this.wRetirementStudio.wCommon_txt_P.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt_P.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Increase_Amount_Rate_P_txt", this.wRetirementStudio.wCommon_txt_P.txt, dic["Increase_Amount_Rate_P_txt"], 0);

                if (dic["Increase_Amount_Rate_T"] != "") iCbo_T++;
                this.wRetirementStudio.wCommon_cbo_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo_T.ToString());
                _gLib._SetSyncUDWin("Increase_Amount_Rate_T_cbo", this.wRetirementStudio.wCommon_cbo_T.cbo, dic["Increase_Amount_Rate_T_cbo"], 0);


                _gLib._SetSyncUDWin("Increase_Pension", this.wRetirementStudio.wIncrease_Pension.cbo, dic["Increase_Pension"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._MsgBox("", "No Verify functin here!");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
