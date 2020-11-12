namespace RetirementStudio._UIMaps.ExcessContributionDefinitionClasses
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
    
    public partial class ExcessContributionDefinition
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();



        /// <summary>
        /// 2013-May-28
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PayAsLumpSum", "");
        ///    dic.Add("IncreaseBenefit", "");
        ///    dic.Add("Actives", "");
        ///    dic.Add("DeferredInactives", "");
        ///    dic.Add("PercentCovered", "");
        ///    dic.Add("ContributionDefinition", "");
        ///    pExcessContributionDefinition._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("PayAsLumpSum", this.wRetirementStudio.wPayAsLumpSum.rd, dic["PayAsLumpSum"], 0);
                _gLib._SetSyncUDWin("IncreaseBenefit", this.wRetirementStudio.wIncreaseBenefit.rd, dic["IncreaseBenefit"], 0);
                _gLib._SetSyncUDWin("Actives", this.wRetirementStudio.wActives.rd, dic["Actives"], 0);
                _gLib._SetSyncUDWin("DeferredInactives", this.wRetirementStudio.wDeferredInactives.rd, dic["DeferredInactives"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PercentCovered", this.wRetirementStudio.wPercentCovered.txt, dic["PercentCovered"], true, 0);
                _gLib._SetSyncUDWin("ContributionDefinition", this.wRetirementStudio.wContributionDefinition.cbo, dic["ContributionDefinition"], 0);
          
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("PayAsLumpSum", this.wRetirementStudio.wPayAsLumpSum.rd, dic["PayAsLumpSum"], 0);
                _gLib._VerifySyncUDWin("IncreaseBenefit", this.wRetirementStudio.wIncreaseBenefit.rd, dic["IncreaseBenefit"], 0);
                _gLib._VerifySyncUDWin("Actives", this.wRetirementStudio.wActives.rd, dic["Actives"], 0);
                _gLib._VerifySyncUDWin("DeferredInactives", this.wRetirementStudio.wDeferredInactives.rd, dic["DeferredInactives"], 0);
                _gLib._VerifySyncUDWin("PercentCovered", this.wRetirementStudio.wPercentCovered.txt, dic["PercentCovered"],  0);
                _gLib._VerifySyncUDWin("ContributionDefinition", this.wRetirementStudio.wContributionDefinition.cbo, dic["ContributionDefinition"], 0);
          
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-28 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Name_1", "PVRetire");
        ///    dic.Add("Name_1_Status", "True");
        ///    dic.Add("Name_2", "");
        ///    dic.Add("Name_2_Status", "");
        ///    dic.Add("Name_3", "");
        ///    dic.Add("Name_3_Status", "");
        ///    pExcessContributionDefinition._Retirement(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Retirement(MyDictionary dic)
        {
            string sFunctionName = "_Retirement";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["Name_1"] != "")
            {
                this.wRetirementStudio.wRetirementList.wlist.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_1"]);
                _gLib._SetSyncUDWin(dic["Name_1"], this.wRetirementStudio.wRetirementList.wlist.chk, dic["Name_1_Status"], 0);
            }
            if (dic["Name_2"] != "")
            {
                this.wRetirementStudio.wRetirementList.wlist.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_2"]);
                _gLib._SetSyncUDWin(dic["Name_2"], this.wRetirementStudio.wRetirementList.wlist.chk, dic["Name_2_Status"], 0);
            }
            if (dic["Name_3"] != "")
            {
                this.wRetirementStudio.wRetirementList.wlist.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_3"]);
                _gLib._SetSyncUDWin(dic["Name_3"], this.wRetirementStudio.wRetirementList.wlist.chk, dic["Name_3_Status"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-May-28 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Name_1", "PVRetire");
        ///    dic.Add("Name_1_Status", "True");
        ///    dic.Add("Name_2", "");
        ///    dic.Add("Name_2_Status", "");
        ///    dic.Add("Name_3", "");
        ///    dic.Add("Name_3_Status", "");
        ///    dic.Add("Name_4", "");
        ///    dic.Add("Name_4_Status", "");
        ///    pExcessContributionDefinition._Withdrawal(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Withdrawal(MyDictionary dic)
        {
            string sFunctionName = "_Withdrawal";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["Name_1"] != "")
            {
                this.wRetirementStudio.wWithdrawalList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_1"]);
                _gLib._SetSyncUDWin(dic["Name_1"], this.wRetirementStudio.wWithdrawalList.chk, dic["Name_1_Status"], 0);
            }
            if (dic["Name_2"] != "")
            {
                this.wRetirementStudio.wWithdrawalList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_2"]);
                _gLib._SetSyncUDWin(dic["Name_2"], this.wRetirementStudio.wWithdrawalList.chk, dic["Name_2_Status"], 0);
            }
            if (dic["Name_3"] != "")
            {
                this.wRetirementStudio.wWithdrawalList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_3"]);
                _gLib._SetSyncUDWin(dic["Name_3"], this.wRetirementStudio.wWithdrawalList.chk, dic["Name_3_Status"], 0);
            }
            if (dic["Name_4"] != "")
            {
                this.wRetirementStudio.wWithdrawalList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_4"]);
                _gLib._SetSyncUDWin(dic["Name_4"], this.wRetirementStudio.wWithdrawalList.chk, dic["Name_4_Status"], 0);
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2013-May-28 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Name_1", "PVRetire");
        ///    dic.Add("Name_1_Status", "True");
        ///    dic.Add("Name_2", "");
        ///    dic.Add("Name_2_Status", "");
        ///    dic.Add("Name_3", "");
        ///    dic.Add("Name_3_Status", "");
        ///    pExcessContributionDefinition._Mortality(dic); 
        /// </summary>
        /// <param name="dic"></param>
        /// 
        public void _Mortality(MyDictionary dic)
        {
            string sFunctionName = "_Mortality";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["Name_1"] != "")
            {
                this.wRetirementStudio.wMortalityList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_1"]);
                _gLib._SetSyncUDWin(dic["Name_1"], this.wRetirementStudio.wMortalityList.chk, dic["Name_1_Status"], 0);
            }
            if (dic["Name_2"] != "")
            {
                this.wRetirementStudio.wMortalityList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_2"]);
                _gLib._SetSyncUDWin(dic["Name_2"], this.wRetirementStudio.wMortalityList.chk, dic["Name_2_Status"], 0);
            }
            if (dic["Name_3"] != "")
            {
                this.wRetirementStudio.wMortalityList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_3"]);
                _gLib._SetSyncUDWin(dic["Name_3"], this.wRetirementStudio.wMortalityList.chk, dic["Name_3_Status"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2013-May-28 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Name_1", "PVRetire");
        ///    dic.Add("Name_1_Status", "True");
        ///    dic.Add("Name_2", "");
        ///    dic.Add("Name_2_Status", "");
        ///    dic.Add("Name_3", "");
        ///    dic.Add("Name_3_Status", "");
        ///    pExcessContributionDefinition._SelectBenefitToCompareList(dic); 
        /// </summary>
        /// <param name="dic"></param>
        /// 
        public void _SelectBenefitToCompareList(MyDictionary dic)
        {
            string sFunctionName = "_SelectBenefitToCompareList";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["Name_1"] != "")
            {
                this.wRetirementStudio.wSelectBenefitToCompareList.wList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_1"]);
                _gLib._SetSyncUDWin(dic["Name_1"], this.wRetirementStudio.wSelectBenefitToCompareList.wList.chk, dic["Name_1_Status"], 0);
            }
            if (dic["Name_2"] != "")
            {
                this.wRetirementStudio.wSelectBenefitToCompareList.wList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_2"]);
                _gLib._SetSyncUDWin(dic["Name_2"], this.wRetirementStudio.wSelectBenefitToCompareList.wList.chk, dic["Name_2_Status"], 0);
            }
            if (dic["Name_3"] != "")
            {
                this.wRetirementStudio.wSelectBenefitToCompareList.wList.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Name_3"]);
                _gLib._SetSyncUDWin(dic["Name_3"], this.wRetirementStudio.wSelectBenefitToCompareList.wList.chk, dic["Name_3_Status"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }
    }
}
