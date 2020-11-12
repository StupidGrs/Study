namespace RetirementStudio._UIMaps.AnnualFundingNoticeClasses
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

    
    

    public partial class AnnualFundingNotice
    {


        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2019-Feb-20
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Annual Funding Notice");
        ///    dic.Add("Level_2", "End of Notice Year");
        ///    pAnnualFundingNotice._TreeViewSelect(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewSelect(MyDictionary dic)
        {
            string sFunctionName = "_TreeViewSelect";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewSelectWin(0, this.wRetirementStudio.tvNaviTree, dic);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2019-Feb-20
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("YearOfFundingService", "");
        ///    dic.Add("YearBeforeFundingService", "");
        ///    pAnnualFundingNotice._PopVerify_EndOfNoticeYear(dic);

        /// </summary>
        /// 

        /// <param name="dic"></param>
        public void _PopVerify_EndOfNoticeYear(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_EndOfNoticeYear_NoticeYear";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("YearOfFundingService", this.wRetirementStudio.wEndofNoticeYr_YearOfFundingSer.rdYearoffundingservice, dic["YearOfFundingService"], 0);
                _gLib._SetSyncUDWin("YearBeforeFundingService", this.wRetirementStudio.wEndofNoticeYr_Yearbeforefundingser.rdYearbeforefundingser, dic["YearBeforeFundingService"], 0);
            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("YearOfFundingService", this.wRetirementStudio.wEndofNoticeYr_YearOfFundingSer.rdYearoffundingservice, dic["YearOfFundingService"], 0);
                _gLib._VerifySyncUDWin("YearBeforeFundingService", this.wRetirementStudio.wEndofNoticeYr_Yearbeforefundingser.rdYearbeforefundingser, dic["YearBeforeFundingService"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2019-Feb-20 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("TheFundingPolicyOfThePlanIs", "to contribute at least the minimum but no more than the unfunded ABO.");
        ///    dic.Add("TheInvestmentPolicyOfThePlanIs", "create a diversified portfolio bond favorable.");
        ///    dic.Add("Cash", "5.00");
        ///    dic.Add("USGovSecurities", "15.00");
        ///    dic.Add("PreferredCorpDebtInstruments", "5.00");
        ///    dic.Add("AllOtherCorpDebtInstruments", "45.00");
        ///    dic.Add("PreferredCorpStocks", "5.00");
        ///    dic.Add("CommonCorpStocks", "5.00");
        ///    dic.Add("PartnershipJointVentureInterests", "15.00");
        ///    dic.Add("RealEstate", "5.00");
        ///    dic.Add("EmployerSecurities", "5.00");
        ///    pAnnualFundingNotice._PopVerify_Policies(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>

        public void _PopVerify_Policies(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Policies";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("TheFundingPolicyOfThePlanIs", this.wRetirementStudio.wPolicies_FundingPolicy.txt, dic["TheFundingPolicyOfThePlanIs"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TheInvestmentPolicyOfThePlanIs", this.wRetirementStudio.wPolicies_InvestmentPolicy.txt, dic["TheInvestmentPolicyOfThePlanIs"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Cash", this.wRetirementStudio.wPolicies_AssetAllocationPct_Cash.txt, dic["Cash"], 0);
                _gLib._SetSyncUDWin_ByClipboard("USGovSecurities", this.wRetirementStudio.wPolicies_AssetAllocationPct_USGov.txt, dic["USGovSecurities"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PreferredCorpDebtInstruments", this.wRetirementStudio.wPolicies_AssetAllocationPct_PreferredCorpDebt.txt, dic["PreferredCorpDebtInstruments"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AllOtherCorpDebtInstruments", this.wRetirementStudio.wPolicies_AssetAllocationPct_AllOtherCorp.txt, dic["AllOtherCorpDebtInstruments"],  0);
                _gLib._SetSyncUDWin_ByClipboard("PreferredCorpStocks", this.wRetirementStudio.wPolicies_AssetAllocationPct_PreferredCorpStocks.txt, dic["PreferredCorpStocks"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CommonCorpStocks", this.wRetirementStudio.wPolicies_AssetAllocationPct_CommonCorpStocks.txt, dic["CommonCorpStocks"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PartnershipJointVentureInterests", this.wRetirementStudio.wPolicies_AssetAllocationPct_PartnershipJoint.txt, dic["PartnershipJointVentureInterests"], 0);
                _gLib._SetSyncUDWin_ByClipboard("RealEstate", this.wRetirementStudio.wPolicies_AssetAllocationPct_RealEstate.txt, dic["RealEstate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("EmployerSecurities", this.wRetirementStudio.wPolices_AssetAllocationPct_EmployerSecurities.txt, dic["EmployerSecurities"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                 _gLib._VerifySyncUDWin("TheFundingPolicyOfThePlanIs", this.wRetirementStudio.wPolicies_FundingPolicy.txt, dic["TheFundingPolicyOfThePlanIs"], 0);
                _gLib._VerifySyncUDWin("TheInvestmentPolicyOfThePlanIs", this.wRetirementStudio.wPolicies_InvestmentPolicy.txt, dic["TheInvestmentPolicyOfThePlanIs"], 0);
                _gLib._VerifySyncUDWin("Cash", this.wRetirementStudio.wPolicies_AssetAllocationPct_Cash.txt, dic["Cash"], 0);
                _gLib._VerifySyncUDWin("USGovSecurities", this.wRetirementStudio.wPolicies_AssetAllocationPct_USGov.txt, dic["USGovSecurities"], 0);
                _gLib._VerifySyncUDWin("PreferredCorpDebtInstruments", this.wRetirementStudio.wPolicies_AssetAllocationPct_PreferredCorpDebt.txt, dic["PreferredCorpDebtInstruments"],  0);
                _gLib._VerifySyncUDWin("AllOtherCorpDebtInstruments", this.wRetirementStudio.wPolicies_AssetAllocationPct_AllOtherCorp.txt, dic["AllOtherCorpDebtInstruments"],  0);
                _gLib._VerifySyncUDWin("PreferredCorpStocks", this.wRetirementStudio.wPolicies_AssetAllocationPct_PreferredCorpStocks.txt, dic["PreferredCorpStocks"],  0);
                _gLib._VerifySyncUDWin("CommonCorpStocks", this.wRetirementStudio.wPolicies_AssetAllocationPct_CommonCorpStocks.txt, dic["CommonCorpStocks"],  0);
                _gLib._VerifySyncUDWin("PartnershipJointVentureInterests", this.wRetirementStudio.wPolicies_AssetAllocationPct_PartnershipJoint.txt, dic["PartnershipJointVentureInterests"], 0);
                _gLib._VerifySyncUDWin("RealEstate", this.wRetirementStudio.wPolicies_AssetAllocationPct_RealEstate.txt, dic["RealEstate"], 0);
                _gLib._VerifySyncUDWin("EmployerSecurities", this.wRetirementStudio.wPolices_AssetAllocationPct_EmployerSecurities.txt, dic["EmployerSecurities"], 0);


            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
