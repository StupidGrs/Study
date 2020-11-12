namespace RetirementStudio._UIMaps.JubileeBenefitClasses
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
    
    
    public partial class JubileeBenefit
    {


        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();



        /// <summary>
        /// 2015-Apr-1
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FixedAmount", "");
        ///    dic.Add("SalaryBased", "");
        ///    dic.Add("JubileeAmount_V", "");
        ///    dic.Add("JubileeAmount_C", "");
        ///    dic.Add("JubileeAmount_cbo", "JBen01");
        ///    dic.Add("JubileeAmount_txt", "");
        ///    dic.Add("NetAmtUsingTotal", "");
        ///    dic.Add("NetAmtUsingSystem", "");
        ///    dic.Add("YearSalary", "");
        ///    dic.Add("TaxClass", "");
        ///    dic.Add("GrossAmount", "");
        ///    dic.Add("FinalAmount", "");
        ///    pJubileeBenefit._PopVerify_FixedAmount(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_FixedAmount(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FixedAmount";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("FixedAmount", this.wRetirementStudio.wFixedAmount.rd, dic["FixedAmount"], 0);
                _gLib._SetSyncUDWin("SalaryBased", this.wRetirementStudio.wSalaryBased.rd, dic["SalaryBased"], 0);
                _gLib._SetSyncUDWin("JubileeAmount_V", this.wRetirementStudio.wJubileeAmount_V.btn, dic["JubileeAmount_V"], 0);
                _gLib._SetSyncUDWin("JubileeAmount_C", this.wRetirementStudio.wJubileeAmount_C.btn, dic["JubileeAmount_C"], 0);
                _gLib._SetSyncUDWin("JubileeAmount_cbo", this.wRetirementStudio.wJubileeAmount_cbo.cbo, dic["JubileeAmount_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("JubileeAmount_txt", this.wRetirementStudio.wJubileeAmount_txt.txt, dic["JubileeAmount_txt"], 0);
                _gLib._SetSyncUDWin("NetAmtUsingTotal", this.wRetirementStudio.wNetAmtUsingTotal.rd, dic["NetAmtUsingTotal"], 0);
                _gLib._SetSyncUDWin("NetAmtUsingSystem", this.wRetirementStudio.wNetAmtUsingSystem.rd, dic["NetAmtUsingSystem"], 0);
                _gLib._SetSyncUDWin("YearSalary", this.wRetirementStudio.wYearSalary.cbo, dic["YearSalary"], 0);
                _gLib._SetSyncUDWin("TaxClass", this.wRetirementStudio.wTaxClass.cbo, dic["TaxClass"], 0);
                _gLib._SetSyncUDWin("GrossAmount", this.wRetirementStudio.wGrossAmount.rd, dic["GrossAmount"], 0);
                _gLib._SetSyncUDWin("FinalAmount", this.wRetirementStudio.wFinalAmount.rd, dic["FinalAmount"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("FixedAmount", this.wRetirementStudio.wFinalAmount.rd, dic["FixedAmount"], 0);
                _gLib._VerifySyncUDWin("SalaryBased", this.wRetirementStudio.wSalaryBased.rd, dic["SalaryBased"], 0);
                _gLib._VerifySyncUDWin("JubileeAmount_V", this.wRetirementStudio.wJubileeAmount_V.btn, dic["JubileeAmount_V"], 0);
                _gLib._VerifySyncUDWin("JubileeAmount_C", this.wRetirementStudio.wJubileeAmount_C.btn, dic["JubileeAmount_C"], 0);
                _gLib._VerifySyncUDWin("JubileeAmount_cbo", this.wRetirementStudio.wJubileeAmount_cbo.cbo, dic["JubileeAmount_cbo"], 0);
                _gLib._VerifySyncUDWin("JubileeAmount_txt", this.wRetirementStudio.wJubileeAmount_txt.txt, dic["JubileeAmount_txt"], 0);
                _gLib._VerifySyncUDWin("NetAmtUsingTotal", this.wRetirementStudio.wNetAmtUsingTotal.rd, dic["NetAmtUsingTotal"], 0);
                _gLib._VerifySyncUDWin("NetAmtUsingSystem", this.wRetirementStudio.wNetAmtUsingSystem.rd, dic["NetAmtUsingSystem"], 0);
                _gLib._VerifySyncUDWin("YearSalary", this.wRetirementStudio.wYearSalary.cbo, dic["YearSalary"], 0);
                _gLib._VerifySyncUDWin("TaxClass", this.wRetirementStudio.wTaxClass.cbo, dic["TaxClass"], 0);
                _gLib._VerifySyncUDWin("GrossAmount", this.wRetirementStudio.wGrossAmount.rd, dic["GrossAmount"], 0);
                _gLib._VerifySyncUDWin("FinalAmount", this.wRetirementStudio.wFinalAmount.rd, dic["FinalAmount"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Apr-1
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FixedAmount", "");
        ///    dic.Add("SalaryBased", "True");
        ///    dic.Add("SalaryDefinition", "PayProjection1");
        ///    dic.Add("DevideBy_V", "");
        ///    dic.Add("DevideBy_C", "Click");
        ///    dic.Add("DevideBy_cbo", "");
        ///    dic.Add("DevideBy_txt", "10,00000000");
        ///    pJubileeBenefit._PopVerify_SalaryBased(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SalaryBased(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_SalaryBased";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("FixedAmount", this.wRetirementStudio.wFixedAmount.rd, dic["FixedAmount"], 0);
                _gLib._SetSyncUDWin("SalaryBased", this.wRetirementStudio.wSalaryBased.rd, dic["SalaryBased"], 0);
                _gLib._SetSyncUDWin("SalaryDefinition", this.wRetirementStudio.wSalaryDefinition.cbo, dic["SalaryDefinition"], 0);
                _gLib._SetSyncUDWin("DevideBy_V", this.wRetirementStudio.wDevideBy_V.btn, dic["DevideBy_VDevideBy_V"], 0);
                _gLib._SetSyncUDWin("DevideBy_C", this.wRetirementStudio.wDevideBy_C.btn, dic["DevideBy_C"], 0);
                _gLib._SetSyncUDWin("DevideBy_cbo", this.wRetirementStudio.wDevideBy_cbo.cbo, dic["DevideBy_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DevideBy_txt", this.wRetirementStudio.wDevideBy_txt.txt, dic["DevideBy_txt"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("FixedAmount", this.wRetirementStudio.wFixedAmount.rd, dic["FixedAmount"], 0);
                _gLib._VerifySyncUDWin("SalaryBased", this.wRetirementStudio.wSalaryBased.rd, dic["SalaryBased"], 0);
                _gLib._VerifySyncUDWin("SalaryDefinition", this.wRetirementStudio.wSalaryDefinition.cbo, dic["SalaryDefinition"], 0);
                _gLib._VerifySyncUDWin("DevideBy_V", this.wRetirementStudio.wDevideBy_V.btn, dic["DevideBy_VDevideBy_V"], 0);
                _gLib._VerifySyncUDWin("DevideBy_C", this.wRetirementStudio.wDevideBy_C.btn, dic["DevideBy_C"], 0);
                _gLib._VerifySyncUDWin("DevideBy_cbo", this.wRetirementStudio.wDevideBy_cbo.cbo, dic["DevideBy_cbo"], 0);
                _gLib._VerifySyncUDWin("DevideBy_txt", this.wRetirementStudio.wDevideBy_txt.txt, dic["wevideBy_txt"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Feb-19
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Eligibility_Years", "");
        ///    dic.Add("Eligibility_From", "");
        ///    dic.Add("Benefit_PayProjection", "");
        ///    dic.Add("Benefit_PercentOfPay", "");
        ///    dic.Add("Benefit_ServiceForProration", "");
        ///    dic.Add("Benefit_PartTimeFactor", "");
        ///    pJubileeBenefit._PopVerify_SalaryRelated(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SalaryRelated(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_SalaryRelated";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("Eligibility_Years", this.wRetirementStudio.wEligibility_BasedOn_Year_NL.txt, dic["Eligibility_Years"], 0);
                _gLib._SetSyncUDWin("Eligibility_From", this.wRetirementStudio.wBenefit_FromDate.cbo, dic["Eligibility_From"], 0);
                _gLib._SetSyncUDWin("Benefit_PayProjection", this.wRetirementStudio.wBenefit_PayProjection.cbo, dic["Benefit_PayProjection"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Benefit_PercentOfPay", this.wRetirementStudio.wBenefit_PercenoffPay.txt.UINudPercentofPayEdit1, dic["Benefit_PercentOfPay"], 0);
                _gLib._SetSyncUDWin("Benefit_ServiceForProration", this.wRetirementStudio.wBenefit_ServiceForProration.cbo, dic["Benefit_ServiceForProration"], 0);
                _gLib._SetSyncUDWin("Benefit_PartTimeFactor", this.wRetirementStudio.wBenefit_PartTimeFactor.cbo, dic["Benefit_PartTimeFactor"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Eligibility_Years", this.wRetirementStudio.wJubileeAmount_txt.txt, dic["FixedAmount"], 0);
                _gLib._VerifySyncUDWin("Benefit_PayProjection", this.wRetirementStudio.wBenefit_PayProjection.cbo, dic["Benefit_PayProjection"], 0);
                _gLib._VerifySyncUDWin("Benefit_PercentOfPay", this.wRetirementStudio.wBenefit_PercenoffPay.txt.UINudPercentofPayEdit1, dic["Benefit_PercentOfPay"], 0);
                _gLib._VerifySyncUDWin("Benefit_ServiceForProration", this.wRetirementStudio.wBenefit_ServiceForProration.cbo, dic["Benefit_ServiceForProration"], 0);
                _gLib._VerifySyncUDWin("Benefit_PartTimeFactor", this.wRetirementStudio.wBenefit_PartTimeFactor.cbo, dic["Benefit_PartTimeFactor"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Feb-19
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FixedAmount", "");
        ///    dic.Add("Eligibility_Years", "");
        ///    dic.Add("Eligibility_From", "");
        ///    dic.Add("Benefit_ServiceForProration", "");
        ///    pJubileeBenefit._PopVerify_FixedAmount_NL(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_FixedAmount_NL(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FixedAmount_NL";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("FixedAmount", this.wRetirementStudio.wFixedAmount.rd, dic["FixedAmount"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Eligibility_Years", this.wRetirementStudio.wEligibility_BasedOn_Year_NL.txt, dic["Eligibility_Years"], 0);
                _gLib._SetSyncUDWin("Eligibility_From", this.wRetirementStudio.wBenefit_FromDate.cbo, dic["Eligibility_From"], 0);
                _gLib._SetSyncUDWin("Benefit_ServiceForProration", this.wRetirementStudio.wBenefit_ServiceForProration.cbo, dic["Benefit_ServiceForProration"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Eligibility_Years", this.wRetirementStudio.wJubileeAmount_txt.txt, dic["FixedAmount"], 0);
                _gLib._VerifySyncUDWin("Benefit_ServiceForProration", this.wRetirementStudio.wBenefit_ServiceForProration.cbo, dic["Benefit_ServiceForProration"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
