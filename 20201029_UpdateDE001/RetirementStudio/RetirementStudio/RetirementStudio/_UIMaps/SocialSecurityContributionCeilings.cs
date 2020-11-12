namespace RetirementStudio._UIMaps.SocialSecurityContributionCeilingsClasses
{
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;

    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Accessibility;
    using RetirementStudio._ThridParty;
    using System.Threading;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    

    public partial class SocialSecurityContributionCeilings
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2015-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("West", "");
        ///    dic.Add("East", "True");
        ///    dic.Add("WestEast_FromData", "");
        ///    dic.Add("Knappschaft", "");
        ///    dic.Add("RV_FromData", "");
        ///    dic.Add("HealthInsuranceWest_cbo_T", "");
        ///    dic.Add("RVWest_cbo_T", "");
        ///    dic.Add("IncreaseRate_P", "click");
        ///    dic.Add("IncreaseRate_txt", "");
        ///    dic.Add("ValuationAge", "");
        ///    dic.Add("LastTableEntry", "true");
        ///    pSocialSecurityContributionCeilings._SocialSecurityContributionRates(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _SocialSecurityContributionRates(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_SocialSecurityContributionRates";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("West", this.wRetirementStudio.wWest.rd, dic["West"], 0);
                _gLib._SetSyncUDWin("East", this.wRetirementStudio.wEast.rd, dic["East"], 0);
                _gLib._SetSyncUDWin("WestEast_FromData", this.wRetirementStudio.wW_FromData.rd, dic["WestEast_FromData"], 0);
                _gLib._SetSyncUDWin("Knappschaft", this.wRetirementStudio.wKnappschaft.rd, dic["Knappschaft"], 0);
                _gLib._SetSyncUDWin("RV_FromData", this.wRetirementStudio.wRV_FromData.rd, dic["RV_FromData"], 0);

                _gLib._SetSyncUDWin("HealthInsuranceWest_cbo_T", this.wRetirementStudio.wHealthInsurance_cbo_T.cbo, dic["HealthInsuranceWest_cbo_T"], 0);
                _gLib._SetSyncUDWin("RVWest_cbo_T", this.wRetirementStudio.wRV_cbo_T.cbo, dic["RVWest_cbo_T"], 0);
                _gLib._SetSyncUDWin("IncreaseRate_P", this.wRetirementStudio.wP.btn, dic["IncreaseRate_P"], 0);
                _gLib._SetSyncUDWin_ByClipboard("IncreaseRate_txt", this.wRetirementStudio.wIncreaseRate.Edit.txt, dic["IncreaseRate_txt"], 0);
                _gLib._SetSyncUDWin("ValuationAge", this.wRetirementStudio.wValuationAge.rd, dic["ValuationAge"], 0);
                _gLib._SetSyncUDWin("LastTableEntry", this.wRetirementStudio.wLastTableEntry.rd, dic["LastTableEntry"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

               
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-09-20
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("HealthInsuranceWest_T", "click");
        ///    dic.Add("HealthInsuranceWest_T_cbox", "");
        ///    dic.Add("RVWest_T", "click");
        ///    dic.Add("RVWest_T_cbo", "click");
        ///    dic.Add("HealthEnsuranceEast_T", "click");
        ///    dic.Add("HealthEnsuranceEast_T_cbo", "click");
        ///    dic.Add("RVEast_T", "click");
        ///    dic.Add("RVEast_T_cbo", "click");
        ///    pSocialSecurityContributionCeilings._FromData_ContributionCeilings(dic); 
        public void _FromData_ContributionCeilings(MyDictionary dic)
        {

            if (dic["PopVerify"] == "Pop")
            {

                this.wRetirementStudio.wCommon_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, "3");
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommon_T.btn, dic["HealthInsuranceWest_T"], 0);
                this.wRetirementStudio.wComom_cbo_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wComom_cbo_T.cbo, dic["HealthInsuranceWest_T_cbox"], 0);


                this.wRetirementStudio.wCommon_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, "4");
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommon_T.btn, dic["RVWest_T"], 0);
                this.wRetirementStudio.wComom_cbo_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, "3");
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wComom_cbo_T.cbo, dic["RVWest_T_cbo"], 0);


                this.wRetirementStudio.wCommon_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommon_T.btn, dic["HealthEnsuranceEast_T"], 0);
                this.wRetirementStudio.wComom_cbo_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, "1");
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wComom_cbo_T.cbo, dic["HealthEnsuranceEast_T_cbo"], 0);


                this.wRetirementStudio.wCommon_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, "5");
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommon_T.btn, dic["RVEast_T"], 0);
                this.wRetirementStudio.wComom_cbo_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, "4");
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wComom_cbo_T.cbo, dic["RVEast_T_cbo"], 0);

            }

        }

    }
}
