namespace RetirementStudio._UIMaps.FormOfPayment_DEClasses
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
    
    
    public partial class FormOfPayment_DE
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
        ///    dic.Add("FormOfPaymentType", "Reversionary");
        ///    dic.Add("NumOfPayPerYear_V", "");
        ///    dic.Add("NumOfPayPerYear_C", "");
        ///    dic.Add("SurvivorPercentOrAmount_V", "Click");
        ///    dic.Add("SurvivorPercentOrAmount_P", "");
        ///    dic.Add("NumOfPayPerYear_cbo", "");
        ///    dic.Add("NumOfPayPerYear_txt", "");
        ///    dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1Percent1");
        ///    dic.Add("SurvivorPercentOrAmount_txt", "");
        ///    pFormOfPayment_DE._PopVerify_FormOfPayment(dic); 
        /// 
        /// 
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FormOfPaymentType", "Spouse's");
        ///    dic.Add("NumOfPayPerYear_V", "");
        ///    dic.Add("NumOfPayPerYear_C", "");
        ///    dic.Add("SurvivorPercentOrAmount_V", "Click");
        ///    dic.Add("SurvivorPercentOrAmount_P", "");
        ///    dic.Add("NumOfPayPerYear_cbo", "");
        ///    dic.Add("NumOfPayPerYear_txt", "");
        ///    dic.Add("SurvivorPercentOrAmount_cbo", "Beneficiary1Percent1");
        ///    dic.Add("SurvivorPercentOrAmount_txt", "");
        ///    pFormOfPayment_DE._PopVerify_FormOfPayment(dic); 
        ///    
        /// 
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FormOfPaymentType", "Immediate orphan annuity");
        ///    dic.Add("NumOfPayPerYear_V", "");
        ///    dic.Add("NumOfPayPerYear_C", "");
        ///    dic.Add("NumOfPayPerYear_cbo", "");
        ///    dic.Add("NumOfPayPerYear_txt", "");
        ///    dic.Add("LastPaymentAge_V", "");
        ///    dic.Add("LastPaymentAge_C", "Click");
        ///    dic.Add("MaximumPaymentAge_V", "");
        ///    dic.Add("MaximumPaymentAge_C", "Click");
        ///    dic.Add("LastPaymentAge_txt", "26");
        ///    dic.Add("MaximumPaymentAge_txt", "26");
        ///    pFormOfPayment_DE._PopVerify_FormOfPayment(dic); 
        ///    
        ///  
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FormOfPaymentType", "Lump sum");
        ///    dic.Add("MonthstoDeferLump_C", "");
        ///    dic.Add("MonthstoDeferLump_txt", "");
        ///    dic.Add("LumpSumInstallments_C", "");
        ///    dic.Add("LumpSumInstallments_txt", "");
        ///    dic.Add("InstallmentsAnnualRate_P", "");
        ///    dic.Add("InstallmentsAnnualRate_txt", "");
        ///    pFormOfPayment_DE._PopVerify_FormOfPayment(dic); 
        ///    
        ///    
        ///    dic.Add("btnGuaranteePeriod_V", "");
        ///    dic.Add("GuaranteePeriod_cbo", "");
        ///    dic.Add("btnGuaranteePeriod_C", "");
        ///    dic.Add("GuaranteePeriod_txt", "");
        ///    dic.Add("cboGuaranteePeriod_YearMonth", "");
        ///    pFormOfPayment_DE._PopVerify_FormOfPayment(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_FormOfPayment(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FormOfPayment";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                if (dic["FormOfPaymentType"] != "")
                    _gLib._SendKeysUDWin("FormOfPaymentType", this.wRetirementStudio.wFormOfPaymentType.cbo, dic["FormOfPaymentType"].Substring(0, 1), false);
                _gLib._SetSyncUDWin("FormOfPaymentType", this.wRetirementStudio.wFormOfPaymentType.cbo, dic["FormOfPaymentType"], 0);
                if (dic["FormOfPaymentType"] != "")
                    _gLib._VerifySyncUDWin("FormOfPaymentType", this.wRetirementStudio.wFormOfPaymentType.cbo, dic["FormOfPaymentType"], 0);



                if (dic["FormOfPaymentType"].Equals("Lump sum"))
                {
                    _gLib._SetSyncUDWin("MonthstoDeferLump_C", this.wRetirementStudio.wMonthsToDefer_C.btn, dic["MonthstoDeferLump_C"], 0);
                    _gLib._SetSyncUDWin("LumpSumInstallments_C", this.wRetirementStudio.wLumpSumInstallment_C.btn, dic["LumpSumInstallments_C"], 0);
                    _gLib._SetSyncUDWin("InstallmentsAnnualRate_P", this.wRetirementStudio.wInstallmentAnnualRate_P.btn, dic["InstallmentsAnnualRate_P"], 0);

                    if (dic["MonthstoDeferLump_txt"] != "")
                        _gLib._SendKeysUDWin("", this.wRetirementStudio.wMonthsToDefer_V.btn, "{Tab}", 0, ModifierKeys.Shift, false);
                    this.wRetirementStudio.wComm_txt.SearchProperties.Add(WinEdit.PropertyNames.Instance, "1");
                    _gLib._SetSyncUDWin_ByClipboard("MonthstoDeferLump_txt", this.wRetirementStudio.wComm_txt.txt.UI_numEditConstantEdit1, dic["MonthstoDeferLump_txt"], 0);


                    if (dic["MonthstoDeferLump_C"] != "")
                        this.wRetirementStudio.wComm_txt.SearchProperties.Add(WinEdit.PropertyNames.Instance, "4");
                    _gLib._SetSyncUDWin_ByClipboard("LumpSumInstallments_txt", this.wRetirementStudio.wComm_txt.txt.UI_numEditConstantEdit1, dic["LumpSumInstallments_txt"], 0);

                    _gLib._SetSyncUDWin_ByClipboard("InstallmentsAnnualRate_txt", this.wRetirementStudio.wComm_p.txt.UI_numEditRateEdit1, dic["InstallmentsAnnualRate_txt"], 0);
                }


                if (dic["FormOfPaymentType"].Equals("Reversionary"))
                {

                    int iNumOfPayPerYear_cbo = 1;
                    int iSurvivorPercentOrAmount_cbo = 1;

                    _gLib._SetSyncUDWin("NumOfPayPerYear_V", this.wRetirementStudio.wNumOfPayPerYear_V.btn, dic["NumOfPayPerYear_V"], 0);
                    _gLib._SetSyncUDWin("NumOfPayPerYear_C", this.wRetirementStudio.wNumOfPayPerYear_C.btn, dic["NumOfPayPerYear_C"], 0);

                    _gLib._SetSyncUDWin("SurvivorPercentOrAmount_V", this.wRetirementStudio.wSurvivorPercentOrAmount_V.btn, dic["SurvivorPercentOrAmount_V"], 0);
                    _gLib._SetSyncUDWin("SurvivorPercentOrAmount_P", this.wRetirementStudio.wSurvivorPercentOrAmount_P.btn, dic["SurvivorPercentOrAmount_P"], 0);

                    if (dic["NumOfPayPerYear_V"] != "" && dic["SurvivorPercentOrAmount_V"] != "")
                        iNumOfPayPerYear_cbo = 2;

                    this.wRetirementStudio.wNumOfPayPerYear_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iNumOfPayPerYear_cbo.ToString());
                    _gLib._SetSyncUDWin("NumOfPayPerYear_cbo", this.wRetirementStudio.wNumOfPayPerYear_cbo.cbo, dic["NumOfPayPerYear_cbo"], 0);
                    this.wRetirementStudio.wNumOfPayPerYear_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iSurvivorPercentOrAmount_cbo.ToString());
                    _gLib._SetSyncUDWin("NumOfPayPerYear_cbo", this.wRetirementStudio.wNumOfPayPerYear_cbo.cbo, dic["SurvivorPercentOrAmount_cbo"], 0);
                         
                    _gLib._SetSyncUDWin_ByClipboard("NumOfPayPerYear_txt", this.wRetirementStudio.wNumOfPayPerYear_txt.txt, dic["NumOfPayPerYear_txt"], 0);
                    _gLib._SetSyncUDWin_ByClipboard("SurvivorPercentOrAmount_txt", this.wRetirementStudio.wSurvivorPercentOrAmount_txt.txt, dic["SurvivorPercentOrAmount_txt"], 0);

                }

                if (dic["FormOfPaymentType"].Equals("Spouse's"))
                {

                    int iNumOfPayPerYear_cbo = 1;
                    int iSurvivorPercentOrAmount_cbo = 1;

                    _gLib._SetSyncUDWin("NumOfPayPerYear_V", this.wRetirementStudio.wNumOfPayPerYear_V.btn, dic["NumOfPayPerYear_V"], 0);
                    _gLib._SetSyncUDWin("NumOfPayPerYear_C", this.wRetirementStudio.wNumOfPayPerYear_C.btn, dic["NumOfPayPerYear_C"], 0);

                    _gLib._SetSyncUDWin("SurvivorPercentOrAmount_V", this.wRetirementStudio.wSurvivorPercentOrAmount_V.btn, dic["SurvivorPercentOrAmount_V"], 0);
                    _gLib._SetSyncUDWin("SurvivorPercentOrAmount_P", this.wRetirementStudio.wSurvivorPercentOrAmount_P.btn, dic["SurvivorPercentOrAmount_P"], 0);

                    if (dic["NumOfPayPerYear_V"] != "" && dic["SurvivorPercentOrAmount_V"] != "")
                        iNumOfPayPerYear_cbo = 2;

                    this.wRetirementStudio.wNumOfPayPerYear_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iNumOfPayPerYear_cbo.ToString());
                    _gLib._SetSyncUDWin("NumOfPayPerYear_cbo", this.wRetirementStudio.wNumOfPayPerYear_cbo.cbo, dic["NumOfPayPerYear_cbo"], 0);
                    this.wRetirementStudio.wNumOfPayPerYear_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iSurvivorPercentOrAmount_cbo.ToString());
                    _gLib._SetSyncUDWin("NumOfPayPerYear_cbo", this.wRetirementStudio.wNumOfPayPerYear_cbo.cbo, dic["SurvivorPercentOrAmount_cbo"], 0);

                    _gLib._SetSyncUDWin_ByClipboard("NumOfPayPerYear_txt", this.wRetirementStudio.wNumOfPayPerYear_txt.txt, dic["NumOfPayPerYear_txt"], 0);
                    _gLib._SetSyncUDWin_ByClipboard("SurvivorPercentOrAmount_txt", this.wRetirementStudio.wSurvivorPercentOrAmount_txt.txt, dic["SurvivorPercentOrAmount_txt"], 0);

                }

                if (dic["FormOfPaymentType"].Equals("Immediate orphan annuity"))
                {

                    int iNumOfPayPerYear_cbo = 1;
                    int iNumOfPayPerYear_txt = 6;
                    int iLastPaymentAge_txt = 3;
                    int iMaximumPaymentAge_txt = 2;

                    _gLib._SetSyncUDWin("NumOfPayPerYear_V", this.wRetirementStudio.wNumOfPayPerYear_V.btn, dic["NumOfPayPerYear_V"], 0);
                    _gLib._SetSyncUDWin("NumOfPayPerYear_C", this.wRetirementStudio.wNumOfPayPerYear_C.btn, dic["NumOfPayPerYear_C"], 0);

                    _gLib._SetSyncUDWin("LastPaymentAge_V", this.wRetirementStudio.wLastPaymentAge_V.btn, dic["LastPaymentAge_V"], 0);
                    _gLib._SetSyncUDWin("LastPaymentAge_C", this.wRetirementStudio.wLastPaymentAge_C.btn, dic["LastPaymentAge_C"], 0);
                    _gLib._SetSyncUDWin("MaximumPaymentAge_V", this.wRetirementStudio.wMaximumPaymentAge_V.btn, dic["MaximumPaymentAge_V"], 0);
                    _gLib._SetSyncUDWin("MaximumPaymentAge_C", this.wRetirementStudio.wMaximumPaymentAge_C.btn, dic["MaximumPaymentAge_C"], 0);


                    this.wRetirementStudio.wNumOfPayPerYear_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iNumOfPayPerYear_cbo.ToString());
                    _gLib._SetSyncUDWin("NumOfPayPerYear_cbo", this.wRetirementStudio.wNumOfPayPerYear_cbo.cbo, dic["NumOfPayPerYear_cbo"], 0);
                    this.wRetirementStudio.wNumOfPayPerYear_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iNumOfPayPerYear_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("NumOfPayPerYear_txt", this.wRetirementStudio.wNumOfPayPerYear_txt.txt, dic["NumOfPayPerYear_txt"], 0);

                    this.wRetirementStudio.wNumOfPayPerYear_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iLastPaymentAge_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("LastPaymentAge_txt", this.wRetirementStudio.wNumOfPayPerYear_txt.txt, dic["LastPaymentAge_txt"], 0);

                    this.wRetirementStudio.wNumOfPayPerYear_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iMaximumPaymentAge_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("MaximumPaymentAge_txt", this.wRetirementStudio.wNumOfPayPerYear_txt.txt, dic["MaximumPaymentAge_txt"], 0);

                }

                if (dic["FormOfPaymentType"] == "")
                {
                    _gLib._SetSyncUDWin("NumOfPayPerYear_V", this.wRetirementStudio.wNumOfPayPerYear_V.btn, dic["NumOfPayPerYear_V"], 0);
                    _gLib._SetSyncUDWin("NumOfPayPerYear_C", this.wRetirementStudio.wNumOfPayPerYear_C.btn, dic["NumOfPayPerYear_C"], 0);

                    _gLib._SetSyncUDWin("btnGuaranteePeriod_V", this.wRetirementStudio.wGuranteePayments_V.btn, dic["btnGuaranteePeriod_V"], 0);
                    _gLib._SetSyncUDWin("btnGuaranteePeriod_C", this.wRetirementStudio.wGuranteePayments_C.btn, dic["btnGuaranteePeriod_C"], 0);


                    if (dic["btnGuaranteePeriod_V"] != "")
                    {
                        if (dic["NumOfPayPerYear_V"] != "")
                            this.wRetirementStudio.wNumOfPayPerYear_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                        _gLib._SetSyncUDWin("GuaranteePeriod_cbo", this.wRetirementStudio.wNumOfPayPerYear_cbo.cbo, dic["GuaranteePeriod_cbo"], 0);
                    }
                }
                               
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




    }
}
