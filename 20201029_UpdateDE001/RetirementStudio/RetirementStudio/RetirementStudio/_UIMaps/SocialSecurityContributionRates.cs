namespace RetirementStudio._UIMaps.SocialSecurityContributionRatesClasses
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
    
    
    public partial class SocialSecurityContributionRates
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
        ///    dic.Add("PrescribedRates", "");
        ///    dic.Add("Other", "True");
        ///    dic.Add("AsOfDate", "");
        ///    dic.Add("SocialSecurityContributionRateRV_Employer", "9,80");
        ///    dic.Add("SocialSecurityContributionRateKnappschaft_Employer", "9,80");
        ///    dic.Add("HealthInsuranceContribionRate_Employer", "7,30");
        ///    dic.Add("HealthInsuranceReducedRate_Employer", "7,00");
        ///    dic.Add("UnemploymentInsuranceContributionRate_Employer", "0,00");
        ///    dic.Add("CareInsuranceContributionRate_Employer", "0,975");
        ///    dic.Add("AccidentInsuranceContributionRate_Employer", "0,975");
        ///    dic.Add("SocialSecurityContributionRateRV_EE", "9,80");
        ///    dic.Add("SocialSecurityContributionRateKnappschaft_EE", "9,80");
        ///    dic.Add("HealthInsuranceContribionRate_EE", "8,20");
        ///    dic.Add("HealthInsuranceReducedRate_EE", "7,30");
        ///    dic.Add("UnemploymentInsuranceContributionRate_EE", "0,00");
        ///    dic.Add("CareInsuranceContributionRate_EE", "1,225");
        ///    dic.Add("PriscribedRates_AccidentInsuranceContributionRate", "");
        ///    pSocialSecurityContributionRates._PopVerify_SocialSecurityContributionRates(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SocialSecurityContributionRates(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_SocialSecurityContributionRates";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("PrescribedRates", this.wRetirementStudio.wPrescribedRates.rd, dic["PrescribedRates"], 0);
                _gLib._SetSyncUDWin("Other", this.wRetirementStudio.wOther.rd, dic["Other"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AsOfDate", this.wRetirementStudio.wAsOfDate.cbo.txt, dic["AsOfDate"], 0);

                _gLib._SetSyncUDWin_ByClipboard("SocialSecurityContributionRateRV_Employer", this.wRetirementStudio.wSocialSecurityContributionRateRV_Employer.txt, dic["SocialSecurityContributionRateRV_Employer"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SocialSecurityContributionRateKnappschaft_Employer", this.wRetirementStudio.wSocialSecurityContributionRateKnappschaft_Employer.txt, dic["SocialSecurityContributionRateKnappschaft_Employer"], 0);
                _gLib._SetSyncUDWin_ByClipboard("HealthInsuranceContribionRate_Employer", this.wRetirementStudio.wHealthInsuranceContribionRate_Employer.txt, dic["HealthInsuranceContribionRate_Employer"], 0);
                _gLib._SetSyncUDWin_ByClipboard("HealthInsuranceReducedRate_Employer", this.wRetirementStudio.wHealthInsuranceReducedRate_Employer.txt, dic["HealthInsuranceReducedRate_Employer"], 0);
                _gLib._SetSyncUDWin_ByClipboard("UnemploymentInsuranceContributionRate_Employer", this.wRetirementStudio.wUnemploymentInsuranceContributionRate_Employer.txt, dic["UnemploymentInsuranceContributionRate_Employer"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CareInsuranceContributionRate_Employer", this.wRetirementStudio.wCareInsuranceContributionRate_Employer.txt, dic["CareInsuranceContributionRate_Employer"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AccidentInsuranceContributionRate_Employer", this.wRetirementStudio.wAccidentInsuranceContributionRate_Employer.txt, dic["AccidentInsuranceContributionRate_Employer"], 0);

                _gLib._SetSyncUDWin_ByClipboard("SocialSecurityContributionRateRV_EE", this.wRetirementStudio.wSocialSecurityContributionRateRV_EE.txt, dic["SocialSecurityContributionRateRV_EE"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SocialSecurityContributionRateKnappschaft_EE", this.wRetirementStudio.wSocialSecurityContributionRateKnappschaft_EE.txt, dic["SocialSecurityContributionRateKnappschaft_EE"], 0);
                _gLib._SetSyncUDWin_ByClipboard("HealthInsuranceContribionRate_EE", this.wRetirementStudio.wHealthInsuranceContribionRate_EE.txt, dic["HealthInsuranceContribionRate_EE"], 0);
                _gLib._SetSyncUDWin_ByClipboard("HealthInsuranceReducedRate_EE", this.wRetirementStudio.wHealthInsuranceReducedRate_EE.txt, dic["HealthInsuranceReducedRate_EE"], 0);
                _gLib._SetSyncUDWin_ByClipboard("UnemploymentInsuranceContributionRate_EE", this.wRetirementStudio.wUnemploymentInsuranceContributionRate_EE.txt, dic["UnemploymentInsuranceContributionRate_EE"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CareInsuranceContributionRate_EE", this.wRetirementStudio.wCareInsuranceContributionRate_EE.txt, dic["CareInsuranceContributionRate_EE"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PriscribedRates_AccidentInsuranceContributionRate", this.wRetirementStudio.wPR_AccidentInsuranceContributionRate.txt.UITxtAccidentInsuranceEdit1, dic["PriscribedRates_AccidentInsuranceContributionRate"], 0);
           
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("PrescribedRates", this.wRetirementStudio.wPrescribedRates.rd, dic["PrescribedRates"], 0);
                _gLib._VerifySyncUDWin("Other", this.wRetirementStudio.wOther.rd, dic["Other"], 0);
                _gLib._VerifySyncUDWin("AsOfDate", this.wRetirementStudio.wAsOfDate.cbo.txt, dic["AsOfDate"], 0);
                _gLib._VerifySyncUDWin("SocialSecurityContributionRateRV_Employer", this.wRetirementStudio.wSocialSecurityContributionRateRV_Employer.txt, dic["SocialSecurityContributionRateRV_Employer"], 0);
                _gLib._VerifySyncUDWin("SocialSecurityContributionRateKnappschaft_Employer", this.wRetirementStudio.wSocialSecurityContributionRateKnappschaft_Employer.txt, dic["SocialSecurityContributionRateKnappschaft_Employer"], 0);
                _gLib._VerifySyncUDWin("HealthInsuranceContribionRate_Employer", this.wRetirementStudio.wHealthInsuranceContribionRate_Employer.txt, dic["HealthInsuranceContribionRate_Employer"], 0);
                _gLib._VerifySyncUDWin("HealthInsuranceReducedRate_Employer", this.wRetirementStudio.wHealthInsuranceReducedRate_Employer.txt, dic["HealthInsuranceReducedRate_Employer"], 0);
                _gLib._VerifySyncUDWin("UnemploymentInsuranceContributionRate_Employer", this.wRetirementStudio.wUnemploymentInsuranceContributionRate_Employer.txt, dic["UnemploymentInsuranceContributionRate_Employer"], 0);
                _gLib._VerifySyncUDWin("CareInsuranceContributionRate_Employer", this.wRetirementStudio.wCareInsuranceContributionRate_Employer.txt, dic["CareInsuranceContributionRate_Employer"], 0);
                _gLib._VerifySyncUDWin("AccidentInsuranceContributionRate_Employer", this.wRetirementStudio.wAccidentInsuranceContributionRate_Employer.txt, dic["AccidentInsuranceContributionRate_Employer"], 0);

                
                _gLib._VerifySyncUDWin("SocialSecurityContributionRateRV_EE", this.wRetirementStudio.wSocialSecurityContributionRateRV_EE.txt, dic["SocialSecurityContributionRateRV_EE"], 0);
                _gLib._VerifySyncUDWin("SocialSecurityContributionRateKnappschaft_EE", this.wRetirementStudio.wSocialSecurityContributionRateKnappschaft_EE.txt, dic["SocialSecurityContributionRateKnappschaft_EE"], 0);
                _gLib._VerifySyncUDWin("HealthInsuranceContribionRate_EE", this.wRetirementStudio.wHealthInsuranceContribionRate_EE.txt, dic["HealthInsuranceContribionRate_EE"], 0);
                _gLib._VerifySyncUDWin("HealthInsuranceReducedRate_EE", this.wRetirementStudio.wHealthInsuranceReducedRate_EE.txt, dic["HealthInsuranceReducedRate_EE"], 0);
                _gLib._VerifySyncUDWin("UnemploymentInsuranceContributionRate_EE", this.wRetirementStudio.wUnemploymentInsuranceContributionRate_EE.txt, dic["UnemploymentInsuranceContributionRate_EE"], 0);
                _gLib._VerifySyncUDWin("CareInsuranceContributionRate_EE", this.wRetirementStudio.wCareInsuranceContributionRate_EE.txt, dic["CareInsuranceContributionRate_EE"], 0);
           
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
