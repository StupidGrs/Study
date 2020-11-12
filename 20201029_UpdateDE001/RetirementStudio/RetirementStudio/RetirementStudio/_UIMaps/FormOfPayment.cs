namespace RetirementStudio._UIMaps.FormOfPaymentClasses
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


    public partial class FormOfPayment
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
        ///    dic.Add("FormOfPaymentType", "");
        ///    dic.Add("MortalityInReferralPeriod", "");
        ///    
        ///    dic.Add("btnGuaranteePeriod_V", "");
        ///    dic.Add("GuaranteePeriod_cbo", "");
        ///    dic.Add("btnGuaranteePeriod_C", "");
        ///    dic.Add("GuaranteePeriod_txt", "");
        ///    dic.Add("cboGuaranteePeriod_YearMonth", "");
        ///    
        ///    dic.Add("btnSurvivorPercentOrAmount_V", "");
        ///    dic.Add("SurvivorPercentOrAmount_cbo", "");
        ///    dic.Add("btnSurvivorPercentOrAmount_Percent", "");
        ///    dic.Add("SurvivorPercentOrAmount_txt", "");
        ///    dic.Add("cboSurvivorPercentOrAmount_PercentOrAmount", "");
        ///    
        ///    dic.Add("btnPopupAmount_V", "");
        ///    dic.Add("PopupAmount_cbo", "");
        ///    dic.Add("btnPopupAmount_C", "");
        ///    dic.Add("PopupAmount_txt", "");
        /// 
        ///    dic.Add("btnNumberOfPaymentsPerYear_V", "");
        ///    dic.Add("NumberOfPaymentsPerYear_cbo", "");
        ///    dic.Add("btnNumberOfPaymentsPerYear_C", "");
        ///    dic.Add("NumberOfPaymentsPerYear_txt", "");
        ///  
        ///    dic.Add("IgnorePercentMarried_DE", "");
        ///    pFormOfPayment._PopVerify_FormOfPayment(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_FormOfPayment(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FormOfPayment";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iGuaranteePeriod_cbo = 0;
            int iSurvivorPercentOrAmount_cbo = 0;
            int iPopupAmount_cbo = 0;
            int iNumberOfPaymentsPerYear_cbo = 0;

            int iGuaranteePeriod_txt = 0;
            int iPopupAmount_txt = 0;
            int iNumberOfPaymentsPerYear_txt = 0;

            int iIncrease_cbo = 0;
            int iTxtIncrease_txt = 0;



            if (dic["PopVerify"] == "Pop")
            {
                if (dic["FormOfPaymentType"] != "")
                    _gLib._SendKeysUDWin("FormOfPaymentType", this.wRetirementStudio.wFormOfPaymentType.cboFormOfPaymentType, dic["FormOfPaymentType"].Substring(0,1),false);
                _gLib._SetSyncUDWin("FormOfPaymentType", this.wRetirementStudio.wFormOfPaymentType.cboFormOfPaymentType, dic["FormOfPaymentType"], 0);
                if (dic["FormOfPaymentType"]!="")
                    _gLib._VerifySyncUDWin("FormOfPaymentType", this.wRetirementStudio.wFormOfPaymentType.cboFormOfPaymentType, dic["FormOfPaymentType"], 0);


                //  GuaranteePeriod
                if (_gLib._Enabled("", this.wRetirementStudio.wGuaranteePeriod_VIcon.btnGuaranteePeriod_V, 1, false))
                    _gLib._SetSyncUDWin("btnGuaranteePeriod_V", this.wRetirementStudio.wGuaranteePeriod_VIcon.btnGuaranteePeriod_V, dic["btnGuaranteePeriod_V"], 0);
                if (_gLib._Enabled("", this.wRetirementStudio.wGuaranteePeriod_CIcon.btnGuaranteePeriod_C, 1, false))
                    _gLib._SetSyncUDWin("btnGuaranteePeriod_C", this.wRetirementStudio.wGuaranteePeriod_CIcon.btnGuaranteePeriod_C, dic["btnGuaranteePeriod_C"], 0);

                if (dic["btnGuaranteePeriod_V"] != "")
                {
                    iGuaranteePeriod_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iGuaranteePeriod_cbo.ToString());
                    _gLib._SetSyncUDWin("GuaranteePeriod_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["GuaranteePeriod_cbo"], 0);
                }
                if (dic["btnGuaranteePeriod_C"] != "")
                {
                    iGuaranteePeriod_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iGuaranteePeriod_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("GuaranteePeriod_txt", this.wRetirementStudio.wCommonTXT.txt, dic["GuaranteePeriod_txt"], true, 0);
                
                }

                _gLib._SetSyncUDWin("cboGuaranteePeriod_YearMonth", this.wRetirementStudio.wGuaranteePeriod_YearMonth.cboGuaranteePeriod_YearMonth, dic["cboGuaranteePeriod_YearMonth"], 0);


                //  SurvivorPercentOrAmount
                if (_gLib._Enabled("", this.wRetirementStudio.wSurvivorPercentOrAmount_VIcon.btnSurvivorPercentOrAmount_V, 1, false))
                    _gLib._SetSyncUDWin("btnSurvivorPercentOrAmount_V", this.wRetirementStudio.wSurvivorPercentOrAmount_VIcon.btnSurvivorPercentOrAmount_V, dic["btnSurvivorPercentOrAmount_V"], 0);
                if (_gLib._Enabled("", this.wRetirementStudio.wSurvivorPercentOrAmount_PercentIcon.btnSurvivorPercentOrAmount_Percent, 1, false))
                    _gLib._SetSyncUDWin("btnSurvivorPercentOrAmount_Percent", this.wRetirementStudio.wSurvivorPercentOrAmount_PercentIcon.btnSurvivorPercentOrAmount_Percent, dic["btnSurvivorPercentOrAmount_Percent"], 0);
                if (dic["btnSurvivorPercentOrAmount_V"] != "")
                {
                    iSurvivorPercentOrAmount_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iSurvivorPercentOrAmount_cbo.ToString());
                    _gLib._SetSyncUDWin("SurvivorPercentage_From_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["SurvivorPercentOrAmount_cbo"], 0);
                }
                if (dic["btnSurvivorPercentOrAmount_Percent"] != "")
                {
                    _gLib._SetSyncUDWin_ByClipboard("SurvivorPercentOrAmount_txt", this.wRetirementStudio.wSurvivorPercentOrAmount_txt.txtSurvivorPercentOrAmount, dic["SurvivorPercentOrAmount_txt"], true, 0);
                }

                _gLib._SetSyncUDWin("cboSurvivorPercentOrAmount_PercentOrAmount", this.wRetirementStudio.wSurvivorPercentOrAmount_PercentOrAmount.cboSurvivorPercentOrAmountPercentOrAmount, dic["cboSurvivorPercentOrAmount_PercentOrAmount"], 0);


                //  PopupAmmount
                if (_gLib._Enabled("", this.wRetirementStudio.wPopupAmount_VIcon.btnPopupAmount_V, 1, false))
                    _gLib._SetSyncUDWin("btnPopupAmount_V", this.wRetirementStudio.wPopupAmount_VIcon.btnPopupAmount_V, dic["btnPopupAmount_V"], 0);
                if (_gLib._Enabled("", this.wRetirementStudio.wPopupAmount_CIcon.btnPopupAmount_C, 1, false))
                    _gLib._SetSyncUDWin("btnPopupAmount_C", this.wRetirementStudio.wPopupAmount_CIcon.btnPopupAmount_C, dic["btnPopupAmount_C"], 0);
                if (dic["btnPopupAmount_V"] != "")
                {
                    iPopupAmount_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iPopupAmount_cbo.ToString());
                    _gLib._SetSyncUDWin("PopupAmount_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["PopupAmount_cbo"], 0);
                }
                if (dic["btnPopupAmount_C"] != "")
                {
                    iPopupAmount_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iPopupAmount_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("PopupAmount_txt", this.wRetirementStudio.wCommonTXT.txt, dic["PopupAmount_txt"], true, 0);
                }

                _gLib._SetSyncUDWin("MortalityInReferralPeriod", this.wRetirementStudio.wMortalityInReferralPeriod.cboMortalityInReferralPeriod, dic["MortalityInReferralPeriod"], 0);

                //  NumberOfPaymentsPerYear
                _gLib._SetSyncUDWin("btnNumberOfPaymentsPerYear_V", this.wRetirementStudio.wNumberOfPaymentsPerYear_VIcon.btnNumberOfPaymentsPerYear_V, dic["btnNumberOfPaymentsPerYear_V"], 0);
                _gLib._SetSyncUDWin("btnNumberOfPaymentsPerYear_C", this.wRetirementStudio.wNumberOfPaymentsPerYear_CIcon.btnNumberOfPaymentsPerYear_C, dic["btnNumberOfPaymentsPerYear_C"], 0);
                if (dic["btnNumberOfPaymentsPerYear_V"] != "")
                {
                    iNumberOfPaymentsPerYear_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iNumberOfPaymentsPerYear_cbo.ToString());
                    _gLib._SetSyncUDWin("NumberOfPaymentsPerYear_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["NumberOfPaymentsPerYear_cbo"], 0);
                }
                if (dic["btnNumberOfPaymentsPerYear_C"] != "")
                {
                    iNumberOfPaymentsPerYear_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;

                    _gLib._SendKeysUDWin("btnNumberOfPaymentsPerYear_C", this.wRetirementStudio.wNumberOfPaymentsPerYear_CIcon.btnNumberOfPaymentsPerYear_C, "{Tab}{Tab}", 0, ModifierKeys.Shift, false );
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iNumberOfPaymentsPerYear_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("NumberOfPaymentsPerYear_txt", this.wRetirementStudio.wCommonTXT.txt, dic["NumberOfPaymentsPerYear_txt"], true, 0);
                }

                _gLib._SetSyncUDWin("IgnorePercentMarried_DE", this.wRetirementStudio.wIgnorePercentMarried.chx, dic["IgnorePercentMarried_DE"], 0);


            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
