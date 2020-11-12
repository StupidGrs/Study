namespace RetirementStudio._UIMaps.ConversionFactorsClasses
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
    using System.Threading;
    using System.Diagnostics;
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;

    
    public partial class ConversionFactors
    {

        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        public void _Debugging()
        {


            this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
        }

        /// <summary>
        /// 2013-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Standard", "True");
        ///    dic.Add("PresentValueFactor", "");
        ///    dic.Add("TabularOrConstantFactor", "");
        ///    dic.Add("CustomCode", "");
        ///    pConversionFactors._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._SetSyncUDWin("PresentValueFactor", this.wRetirementStudio.wPresentValueFactor.rdPresentValueFactor, dic["PresentValueFactor"], 0);
                _gLib._SetSyncUDWin("TabularOrConstantFactor", this.wRetirementStudio.wTabularOrConstantFactor.rdTabularOrConstantFactor, dic["TabularOrConstantFactor"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Standard", this.wRetirementStudio.wStandard.rdStandard, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("PresentValueFactor", this.wRetirementStudio.wPresentValueFactor.rdPresentValueFactor, dic["PresentValueFactor"], 0);
                _gLib._VerifySyncUDWin("TabularOrConstantFactor", this.wRetirementStudio.wTabularOrConstantFactor.rdTabularOrConstantFactor, dic["TabularOrConstantFactor"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
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
        ///    dic.Add("FormOfPaymentType_From", "");
        ///    dic.Add("FormOfPaymentType_To", "");
        ///    dic.Add("MortalityInDeferralPeriod_From", "");
        ///    dic.Add("MortalityInDeferralPeriod_To", "");
        ///    dic.Add("ActuarialEquivalence_From", "ActuarialEquivalence1");
        ///    dic.Add("ActuarialEquivalence_To", "ActuarialEquivalence1");
        ///    dic.Add("ApplySpouseAgeDifference_From", "True");
        ///    dic.Add("ApplySpouseAgeDifference_To", "True");
        ///    
        /// 
        ///    dic.Add("btnGuaranteePeriod_From_V", "");
        ///    dic.Add("GuaranteePeriod_From_cbo", "");
        ///    dic.Add("btnGuaranteePeriod_From_C", "Click");
        ///    dic.Add("GuaranteePeriod_From_txt", ""); 
        ///    
        ///    dic.Add("btnSurvivorPercentage_From_V", "");
        ///    dic.Add("SurvivorPercentage_From_cbo", "");
        ///    dic.Add("btnSurvivorPercentage_From_Percent", "");
        ///    dic.Add("SurvivorPercentage_From_txt", "");
        ///    
        ///    dic.Add("btnPopupAmount_From_V", "");
        ///    dic.Add("PopupAmount_From_cbo", "");
        ///    dic.Add("btnPopupAmount_From_C", "Click");
        ///    dic.Add("PopupAmount_From_txt", "");
        ///    
        ///    dic.Add("btnBenefitCommenceAge_From_V", "");
        ///    dic.Add("BenefitCommenceAge_From_cbo", "");
        ///    dic.Add("btnBenefitCommenceAge_From_C", "Click");
        ///    dic.Add("BenefitCommenceAge_From_txt", "");
        /// 
        ///    dic.Add("btnBenefitStopAge_From_V", "");
        ///    dic.Add("BenefitStopAge_From_cbo", "");
        ///    dic.Add("btnBenefitStopAge_From_C", "Click");
        ///    dic.Add("BenefitStopAge_From_txt", "");
        /// 
        ///    dic.Add("btnNumberOfPaymentsPerYear_From_V", "");
        ///    dic.Add("NumberOfPaymentsPerYear_From_cbo", "");
        ///    dic.Add("btnNumberOfPaymentsPerYear_From_C", "Click");
        ///    dic.Add("NumberOfPaymentsPerYear_From_txt", "");
        ///    
        ///    dic.Add("btnGuaranteePeriod_To_V", "");
        ///    dic.Add("GuaranteePeriod_To_cbo", "");
        ///    dic.Add("btnGuaranteePeriod_To_C", "Click");
        ///    dic.Add("GuaranteePeriod_To_txt", ""); 
        ///    
        ///    dic.Add("btnSurvivorPercentage_To_V", "");
        ///    dic.Add("SurvivorPercentage_To_cbo", "");
        ///    dic.Add("btnSurvivorPercentage_To_Percent", "");
        ///    dic.Add("SurvivorPercentage_To_txt", "");
        ///    
        ///    dic.Add("btnPopupAmount_To_V", "");
        ///    dic.Add("PopupAmount_To_cbo", "");
        ///    dic.Add("btnPopupAmount_To_C", "Click");
        ///    dic.Add("PopupAmount_To_txt", "");
        ///    
        ///    dic.Add("btnBenefitCommenceAge_To_V", "");
        ///    dic.Add("BenefitCommenceAge_To_cbo", "");
        ///    dic.Add("btnBenefitCommenceAge_To_C", "Click");
        ///    dic.Add("BenefitCommenceAge_To_txt", "");
        /// 
        ///    dic.Add("btnBenefitStopAge_To_V", "");
        ///    dic.Add("BenefitStopAge_To_cbo", "");
        ///    dic.Add("btnBenefitStopAge_To_C", "Click");
        ///    dic.Add("BenefitStopAge_To_txt", "");
        /// 
        ///    dic.Add("btnNumberOfPaymentsPerYear_To_V", "");
        ///    dic.Add("NumberOfPaymentsPerYear_To_cbo", "");
        ///    dic.Add("btnNumberOfPaymentsPerYear_To_C", "");
        ///    dic.Add("NumberOfPaymentsPerYear_To_txt", "");
        ///    pConversionFactors._PopVerify_Standard(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Standard(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Standard";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iGuaranteePeriod_From_txt = 0;
            int iPopupAmount_From_txt = 0;
            int iBenefitCommenceAge_From_txt = 0;
            int iBenefitStopAge_From_txt = 0;
            int iNumberOfPaymentsPerYear_From_txt = 0;
            int iGuaranteePeriod_To_txt = 0;
            int iPopupAmount_To_txt = 0;
            int iBenefitCommenceAge_To_txt = 0;
            int iBenefitStopAge_To_txt = 0;
            int iNumberOfPaymentsPerYear_To_txt = 0;

            int iGuaranteePeriod_From_cbo = 0;
            int iSurvivorPercent_From_cbo = 0;
            int iPopupAmount_From_cbo = 0;
            int iBenefitCommenceAge_From_cbo = 0;
            int iBenefitStopAge_From_cbo = 0;
            int iNumberOfPaymentsPerYear_From_cbo = 0;
            int iGuaranteePeriod_To_cbo = 0;
            int iSurvivorPercent_To_cbo = 0;
            int iPopupAmount_To_cbo = 0;
            int iBenefitCommenceAge_To_cbo = 0;
            int iBenefitStopAge_To_cbo = 0;
            int iNumberOfPaymentsPerYear_To_cbo = 0;

            int iIncrease_cbo = 0;
            int iTxtIncrease_txt = 0;


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("FormOfPaymentType_From", this.wRetirementStudio.wFormOfPaymentType_From.cbo_FormOfPaymentType_From, dic["FormOfPaymentType_From"], 0);
                

                //  GuaranteePeriod
                _gLib._SetSyncUDWin("btnGuaranteePeriod_From_V", this.wRetirementStudio.wGuaranteePeriod_From_VIcon.btnGuaranteePeriod_From_V, dic["btnGuaranteePeriod_From_V"], 0);
                _gLib._SetSyncUDWin("btnGuaranteePeriod_From_C", this.wRetirementStudio.wGuaranteePeriod_From_CIcon.btnGuaranteePeriod_From_C, dic["btnGuaranteePeriod_From_C"], 0);
                if (dic["btnGuaranteePeriod_From_V"] != "")
                {
                    iGuaranteePeriod_From_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iGuaranteePeriod_From_cbo.ToString());
                    _gLib._SetSyncUDWin("GuaranteePeriod_From_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["GuaranteePeriod_From_cbo"], 0);
                }
                if (dic["btnGuaranteePeriod_From_C"] != "")
                {
                    iGuaranteePeriod_From_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iGuaranteePeriod_From_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("GuaranteePeriod_From_txt", this.wRetirementStudio.wCommonTXT.txt, dic["GuaranteePeriod_From_txt"], true, 0);
                }


                //  SurvivorPercent
                if (_gLib._Enabled("", this.wRetirementStudio.wSurvivorPercentage_From_VIcon.btnSurvivorPercentage_From_V, 1, false))
                    _gLib._SetSyncUDWin("btnSurvivorPercentage_From_V", this.wRetirementStudio.wSurvivorPercentage_From_VIcon.btnSurvivorPercentage_From_V, dic["btnSurvivorPercentage_From_V"], 0);
                if (_gLib._Enabled("", this.wRetirementStudio.wSurvivorPercentage_From_PercentIcon.btnSurvivorPercentage_From_Percent, 1, false))
                    _gLib._SetSyncUDWin("btnSurvivorPercentage_From_Percent", this.wRetirementStudio.wSurvivorPercentage_From_PercentIcon.btnSurvivorPercentage_From_Percent, dic["btnSurvivorPercentage_From_Percent"], 0);
                if (dic["btnSurvivorPercentage_From_V"] != "")
                {
                    iSurvivorPercent_From_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iSurvivorPercent_From_cbo.ToString());
                    _gLib._SetSyncUDWin("SurvivorPercentage_From_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["SurvivorPercentage_From_cbo"], 0);
                }
                if (dic["btnSurvivorPercentage_From_Percent"] != "")
                {
                    _gLib._SetSyncUDWin_ByClipboard("SurvivorPercentage_From_txt", this.wRetirementStudio.wSurvivorPercentage_From_txt.txtSurvivorPercentage_From, dic["SurvivorPercentage_From_txt"], true, 0);
                }


                //  PopupAmmount
                if (_gLib._Enabled("", this.wRetirementStudio.wPopupAmount_From_VIcon.btnPopupAmount_From_V, 1, false))
                    _gLib._SetSyncUDWin("btnPopupAmount_From_V", this.wRetirementStudio.wPopupAmount_From_VIcon.btnPopupAmount_From_V, dic["btnPopupAmount_From_V"], 0);
                if (_gLib._Enabled("", this.wRetirementStudio.wPopupAmount_From_CIcon.btnPopupAmount_From_C, 1, false))
                    _gLib._SetSyncUDWin("btnPopupAmount_From_C", this.wRetirementStudio.wPopupAmount_From_CIcon.btnPopupAmount_From_C, dic["btnPopupAmount_From_C"], 0);
                if (dic["btnPopupAmount_From_V"] != "")
                {
                    iPopupAmount_From_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iPopupAmount_From_cbo.ToString());
                    _gLib._SetSyncUDWin("PopupAmount_From_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["PopupAmount_From_cbo"], 0);
                }
                if (dic["btnPopupAmount_From_C"] != "")
                {
                    iPopupAmount_From_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iPopupAmount_From_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("PopupAmount_From_txt", this.wRetirementStudio.wCommonTXT.txt, dic["PopupAmount_From_txt"], true, 0);
                }



                //  BenefitCommenceAge
                _gLib._SetSyncUDWin("btnBenefitCommenceAge_From_V", this.wRetirementStudio.wBenefitCommenceAge_From_VIcon.btnBenefitCommenceAge_From_V, dic["btnBenefitCommenceAge_From_V"], 0);
                _gLib._SetSyncUDWin("btnBenefitCommenceAge_From_C", this.wRetirementStudio.wBenefitCommenceAge_From_CIcon.btnBenefitCommenceAge_From_C, dic["btnBenefitCommenceAge_From_C"], 0);
                if (dic["btnBenefitCommenceAge_From_V"] != "")
                {
                    iBenefitCommenceAge_From_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitCommenceAge_From_cbo.ToString());
                    _gLib._SetSyncUDWin("BenefitCommenceAge_From_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["BenefitCommenceAge_From_cbo"], 0);
                }
                if (dic["btnBenefitCommenceAge_From_C"] != "")
                {
                    iBenefitCommenceAge_From_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitCommenceAge_From_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("BenefitCommenceAge_From_txt", this.wRetirementStudio.wCommonTXT.txt, dic["BenefitCommenceAge_From_txt"], true, 0);
                }


                //  BenefitStopAge
                _gLib._SetSyncUDWin("btnBenefitStopAge_From_V", this.wRetirementStudio.wBenefitStopAge_From_VIcon.btnBenefitStopAge_From_V, dic["btnBenefitStopAge_From_V"], 0);
                _gLib._SetSyncUDWin("btnBenefitStopAge_From_C", this.wRetirementStudio.wBenefitStopAge_From_CIcon.btnBenefitStopAge_From_C, dic["btnBenefitStopAge_From_C"], 0);
                if (dic["btnBenefitStopAge_From_V"] != "")
                {
                    iBenefitStopAge_From_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitStopAge_From_cbo.ToString());
                    _gLib._SetSyncUDWin("BenefitStopAge_From_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["BenefitStopAge_From_cbo"], 0);
                }
                if (dic["btnBenefitStopAge_From_C"] != "")
                {
                    iBenefitStopAge_From_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitStopAge_From_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("BenefitStopAge_From_txt", this.wRetirementStudio.wCommonTXT.txt, dic["BenefitStopAge_From_txt"], true, 0);
                }

                _gLib._SetSyncUDWin("MortalityInDeferralPeriod_From", this.wRetirementStudio.wMortalityInDeferralPeriod_From.cboMortalityInDeferralPeriod_From, dic["MortalityInDeferralPeriod_From"], 0);



                //  NumberOfPaymentsPerYear
                if (_gLib._Enabled("", this.wRetirementStudio.wNumberOfPaymentsPerYear_From_VIcon.btnNumberOfPaymentsPerYear_From_V,1,false))
                    _gLib._SetSyncUDWin("btnNumberOfPaymentsPerYear_From_V", this.wRetirementStudio.wNumberOfPaymentsPerYear_From_VIcon.btnNumberOfPaymentsPerYear_From_V, dic["btnNumberOfPaymentsPerYear_From_V"], 0);
                if (_gLib._Enabled("", this.wRetirementStudio.wNumberOfPaymentsPerYear_From_CIcon.btnNumberOfPaymentsPerYear_From_C, 1,false))
                    _gLib._SetSyncUDWin("btnNumberOfPaymentsPerYear_From_C", this.wRetirementStudio.wNumberOfPaymentsPerYear_From_CIcon.btnNumberOfPaymentsPerYear_From_C, dic["btnNumberOfPaymentsPerYear_From_C"], 0);
                if (dic["btnNumberOfPaymentsPerYear_From_V"] != "")
                {
                    iNumberOfPaymentsPerYear_From_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iNumberOfPaymentsPerYear_From_cbo.ToString());
                    _gLib._SetSyncUDWin("NumberOfPaymentsPerYear_From_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["NumberOfPaymentsPerYear_From_cbo"], 0);
                }
                if (dic["btnNumberOfPaymentsPerYear_From_C"] != "")
                {
                    iNumberOfPaymentsPerYear_From_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iNumberOfPaymentsPerYear_From_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("NumberOfPaymentsPerYear_From_txt", this.wRetirementStudio.wCommonTXT.txt, dic["NumberOfPaymentsPerYear_From_txt"], true, 0);
                }

                _gLib._SetSyncUDWin("ActuarialEquivalence_From", this.wRetirementStudio.wActuarialEquivalence_From.cboActuarialEquivalence_From, dic["ActuarialEquivalence_From"], 0);
                _gLib._SetSyncUDWin("ApplySpouseAgeDifference_From", this.wRetirementStudio.wApplySpouseAgeDifference_From.chkApplySpouseAgeDifference_From, dic["ApplySpouseAgeDifference_From"], 0);



                //////////////////////////// Convet To 
                _gLib._SetSyncUDWin("FormOfPaymentType_To", this.wRetirementStudio.wFormOfPaymentType_To.cbo_FormOfPaymentType_To, dic["FormOfPaymentType_To"], 0);


                //  GuaranteePeriod
                _gLib._SetSyncUDWin("btnGuaranteePeriod_To_V", this.wRetirementStudio.wGuaranteePeriod_To_VIcon.btnGuaranteePeriod_To_V, dic["btnGuaranteePeriod_To_V"], 0);
                _gLib._SetSyncUDWin("btnGuaranteePeriod_To_C", this.wRetirementStudio.wGuaranteePeriod_To_CIcon.btnGuaranteePeriod_To_C, dic["btnGuaranteePeriod_To_C"], 0);
                if (dic["btnGuaranteePeriod_To_V"] != "")
                {
                    iGuaranteePeriod_To_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iGuaranteePeriod_To_cbo.ToString());
                    _gLib._SetSyncUDWin("GuaranteePeriod_To_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["GuaranteePeriod_To_cbo"], 0);
                }
                if (dic["btnGuaranteePeriod_To_C"] != "")
                {
                    iGuaranteePeriod_To_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iGuaranteePeriod_To_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("GuaranteePeriod_To_txt", this.wRetirementStudio.wCommonTXT.txt, dic["GuaranteePeriod_To_txt"], true, 0);
                }


                //  SurvivorPercent
                if (_gLib._Enabled("", this.wRetirementStudio.wSurvivorPercentage_To_VIcon.btnSurvivorPercentage_To_V, 1, false))
                    _gLib._SetSyncUDWin("btnSurvivorPercentage_To_V", this.wRetirementStudio.wSurvivorPercentage_To_VIcon.btnSurvivorPercentage_To_V, dic["btnSurvivorPercentage_To_V"], 0);
                if (_gLib._Enabled("", this.wRetirementStudio.wSurvivorPercentage_To_PercentIcon.btnSurvivorPercentage_To_Percent, 1, false))
                    _gLib._SetSyncUDWin("btnSurvivorPercentage_To_Percent", this.wRetirementStudio.wSurvivorPercentage_To_PercentIcon.btnSurvivorPercentage_To_Percent, dic["btnSurvivorPercentage_To_Percent"], 0);
                if (dic["btnSurvivorPercentage_To_V"] != "")
                {
                    iSurvivorPercent_To_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iSurvivorPercent_To_cbo.ToString());
                    _gLib._SetSyncUDWin("SurvivorPercentage_To_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["SurvivorPercentage_To_cbo"], 0);
                }
                if (dic["btnSurvivorPercentage_To_Percent"] != "")
                {
                    _gLib._SetSyncUDWin_ByClipboard("SurvivorPercentage_To_txt", this.wRetirementStudio.wSurvivorPercentage_To_txt.txtSurvivorPercentage_To, dic["SurvivorPercentage_To_txt"], true, 0);
                }


                //  PopupAmmount
                if (_gLib._Enabled("", this.wRetirementStudio.wPopupAmount_To_VIcon.btnPopupAmount_To_V, 1, false))
                    _gLib._SetSyncUDWin("btnPopupAmount_To_V", this.wRetirementStudio.wPopupAmount_To_VIcon.btnPopupAmount_To_V, dic["btnPopupAmount_To_V"], 0);
                if (_gLib._Enabled("", this.wRetirementStudio.wPopupAmount_From_CIcon.btnPopupAmount_From_C, 1, false))
                    _gLib._SetSyncUDWin("btnPopupAmount_To_C", this.wRetirementStudio.wPopupAmount_To_CIcon.btnPopupAmount_To_C, dic["btnPopupAmount_To_C"], 0);
                if (dic["btnPopupAmount_To_V"] != "")
                {
                    iPopupAmount_To_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iPopupAmount_To_cbo.ToString());
                    _gLib._SetSyncUDWin("PopupAmount_To_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["PopupAmount_To_cbo"], 0);
                }
                if (dic["btnPopupAmount_To_C"] != "")
                {
                    iPopupAmount_To_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iPopupAmount_To_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("PopupAmount_To_txt", this.wRetirementStudio.wCommonTXT.txt, dic["PopupAmount_To_txt"], true, 0);
                }



                //  BenefitCommenceAge
                _gLib._SetSyncUDWin("btnBenefitCommenceAge_To_V", this.wRetirementStudio.wBenefitCommenceAge_To_VIcon.btnBenefitCommenceAge_To_V, dic["btnBenefitCommenceAge_To_V"], 0);
                _gLib._SetSyncUDWin("btnBenefitCommenceAge_To_C", this.wRetirementStudio.wBenefitCommenceAge_To_CIcon.btnBenefitCommenceAge_To_C, dic["btnBenefitCommenceAge_To_C"], 0);
                if (dic["btnBenefitCommenceAge_To_V"] != "")
                {
                    iBenefitCommenceAge_To_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitCommenceAge_To_cbo.ToString());
                    _gLib._SetSyncUDWin("BenefitCommenceAge_To_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["BenefitCommenceAge_To_cbo"], 0);
                }
                if (dic["btnBenefitCommenceAge_To_C"] != "")
                {
                    iBenefitCommenceAge_To_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitCommenceAge_To_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("BenefitCommenceAge_To_txt", this.wRetirementStudio.wCommonTXT.txt, dic["BenefitCommenceAge_To_txt"], true, 0);
                }


                //  BenefitStopAge
                _gLib._SetSyncUDWin("btnBenefitStopAge_To_V", this.wRetirementStudio.wBenefitStopAge_To_VIcon.btnBenefitStopAge_To_V, dic["btnBenefitStopAge_To_V"], 0);
                _gLib._SetSyncUDWin("btnBenefitStopAge_To_C", this.wRetirementStudio.wBenefitStopAge_To_CIcon.btnBenefitStopAge_To_C, dic["btnBenefitStopAge_To_C"], 0);
                if (dic["btnBenefitStopAge_To_V"] != "")
                {
                    iBenefitStopAge_To_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitStopAge_To_cbo.ToString());
                    _gLib._SetSyncUDWin("BenefitStopAge_To_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["BenefitStopAge_To_cbo"], 0);
                }
                if (dic["btnBenefitStopAge_To_C"] != "")
                {
                    iBenefitStopAge_To_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iBenefitStopAge_To_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("BenefitStopAge_To_txt", this.wRetirementStudio.wCommonTXT.txt, dic["BenefitStopAge_To_txt"], true, 0);
                }

                _gLib._SetSyncUDWin("MortalityInDeferralPeriod_To", this.wRetirementStudio.wMortalityInDeferralPeriod_To.cboMortalityInDeferralPeriod_To, dic["MortalityInDeferralPeriod_To"], 0);



                //  NumberOfPaymentsPerYear
                _gLib._SetSyncUDWin("btnNumberOfPaymentsPerYear_To_V", this.wRetirementStudio.wNumberOfPaymentsPerYear_To_VIcon.btnNumberOfPaymentsPerYear_To_V, dic["btnNumberOfPaymentsPerYear_To_V"], 0);
                _gLib._SetSyncUDWin("btnNumberOfPaymentsPerYear_To_C", this.wRetirementStudio.wNumberOfPaymentsPerYear_To_CIcon.btnNumberOfPaymentsPerYear_To_C, dic["btnNumberOfPaymentsPerYear_To_C"], 0);
                if (dic["btnNumberOfPaymentsPerYear_To_V"] != "")
                {
                    iNumberOfPaymentsPerYear_To_cbo = iIncrease_cbo + 1;
                    iIncrease_cbo = iIncrease_cbo + 1;
                    this.wRetirementStudio.wCommonComboBox.SearchProperties.Add(WinWindow.PropertyNames.Instance, iNumberOfPaymentsPerYear_To_cbo.ToString());
                    _gLib._SetSyncUDWin("NumberOfPaymentsPerYear_To_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["NumberOfPaymentsPerYear_To_cbo"], 0);
                }
                if (dic["btnNumberOfPaymentsPerYear_To_C"] != "")
                {
                    iNumberOfPaymentsPerYear_To_txt = iTxtIncrease_txt + 1;
                    iTxtIncrease_txt = iTxtIncrease_txt + 1;
                    this.wRetirementStudio.wCommonTXT.SearchProperties.Add(WinWindow.PropertyNames.Instance, iNumberOfPaymentsPerYear_To_txt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("NumberOfPaymentsPerYear_To_txt", this.wRetirementStudio.wCommonTXT.txt, dic["NumberOfPaymentsPerYear_To_txt"], true, 0);
                }

                _gLib._SetSyncUDWin("ActuarialEquivalence_To", this.wRetirementStudio.wActuarialEquivalence_To.cboActuarialEquivalence_To, dic["ActuarialEquivalence_To"], 0);
                _gLib._SetSyncUDWin("ApplySpouseAgeDifference_To", this.wRetirementStudio.wApplySpouseAgeDifference_To.chkApplySpouseAgeDifference_To, dic["ApplySpouseAgeDifference_To"], 0);


            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        
        /// <summary>
        /// 2016-Mar-9
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        /// 
        ///   dic.Clear();
        ///   dic.Add("FormOfPaymentType", "click");
        ///   dic.Add("GuaranteePeriod_C", "click");
        ///   dic.Add("GuaranteePeriod_txt", "0");
        ///   dic.Add("SurvivorPercentage_C", "click");
        ///   dic.Add("SurvivorPercentage_txt", "60,0");
        ///   dic.Add("BenefitCommencementAge_V", "");
        ///   dic.Add("BenefitCommencementAge_cbo", "");
        ///   dic.Add("BenefitCommencementAge_C", "");
        ///   dic.Add("BenefitCommencementAge_txt", "");
        ///   dic.Add("MortalityInDeferralPeriod", "Member only mortality");
        ///   dic.Add("ActuarialEquivalence", "LSActuarialEquivalent");
        ///   dic.Add("ApplyDifferentStartAgeforPostCommencement", "true");
        ///   dic.Add("StartAgeforPostCommencement_C", "");
        ///   dic.Add("StartAgeforPostCommencement_txt", "");
        ///   dic.Add("ApplyPercentMarriedAndSpouseAgeDifference", "true");
        ///   pConversionFactors._PopVerify_PresentValueFactor(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PresentValueFactor(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PresentValueFactor";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("FormOfPaymentType", this.wRetirementStudio.wFormOfPaymentType_To.cbo_FormOfPaymentType_To, dic["FormOfPaymentType"], 0);

                _gLib._SetSyncUDWin("GuaranteePeriod_C", this.wRetirementStudio.wGuaranteePeriod_From_CIcon.btnGuaranteePeriod_From_C, dic["GuaranteePeriod_C"], 0);
                //////dic["GuaranteePeriod_txt"]
                if (dic["GuaranteePeriod_txt"] != "")
                {
                    string sActVal = this.wRetirementStudio.wGuaranteePeriod_txt.txtGuaranteePeriod.txtGuaranteePeriod_edit.Text;
                    if (dic["GuaranteePeriod_txt"] != sActVal)
                    {
                        try
                        {
                            this.wRetirementStudio.wGuaranteePeriod_From_CIcon.btnGuaranteePeriod_From_C.SetFocus();
                            Keyboard.SendKeys("{Tab}{Tab}", ModifierKeys.Shift);
                            Keyboard.SendKeys(dic["GuaranteePeriod_txt"]);
                        }
                        catch (Exception ex)
                        {
                            _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set focus on <GuaranteePeriod_txt> Because exception threw out: " + Environment.NewLine + ex.Message);
                            _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set focus on <GuaranteePeriod_txt>. Because exception threw out: " + Environment.NewLine + ex.Message);
                        }
                        sActVal = this.wRetirementStudio.wGuaranteePeriod_txt.txtGuaranteePeriod.txtGuaranteePeriod_edit.Text;
                        if (dic["GuaranteePeriod_txt"] != sActVal)
                        {
                            _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + dic["GuaranteePeriod_txt"] + "> to object <GuaranteePeriod_txt>. Actual Value: <" + sActVal + "> ");
                        }
                    }
                }

                _gLib._SetSyncUDWin("SurvivorPercentage_C", this.wRetirementStudio.wSurvivorPercentage_C.btn, dic["SurvivorPercentage_C"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SurvivorPercentage_txt", this.wRetirementStudio.wSurvivorPercentage_txt.txt, dic["SurvivorPercentage_txt"], 0);
                _gLib._SetSyncUDWin("BenefitCommencementAge_V", this.wRetirementStudio.wPresentValueFactor_BenefitCommencementAge_V.btn, dic["BenefitCommencementAge_V"], 0);
                _gLib._SetSyncUDWin("BenefitCommencementAge_cbo", this.wRetirementStudio.wCommonComboBox.cbo, dic["BenefitCommencementAge_cbo"], 0);


                _gLib._SetSyncUDWin("BenefitCommencementAge_C", this.wRetirementStudio.wBenefitCommencementAge_C.btnBenefitCommencementAge_C, dic["BenefitCommencementAge_C"], 0);
                //////dic["BenefitCommencementAge_txt"]
                if (dic["BenefitCommencementAge_txt"] != "")
                {
                    string sActVal = this.wRetirementStudio.wBenefitCommencementAge_txt.txtBenefitCommencementAge.edit.Text;
                    if (dic["BenefitCommencementAge_txt"] != sActVal)
                    {
                        try
                        {
                            this.wRetirementStudio.wBenefitCommencementAge_C.btnBenefitCommencementAge_C.SetFocus();
                            Keyboard.SendKeys("{Tab}{Tab}", ModifierKeys.Shift);
                            Keyboard.SendKeys(dic["BenefitCommencementAge_txt"]);
                        }
                        catch (Exception ex)
                        {
                            _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set focus on <BenefitCommencementAge_txt> Because exception threw out: " + Environment.NewLine + ex.Message);
                            _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set focus on <BenefitCommencementAge_txt>. Because exception threw out: " + Environment.NewLine + ex.Message);
                        }
                        sActVal = this.wRetirementStudio.wGuaranteePeriod_txt.txtGuaranteePeriod.txtGuaranteePeriod_edit.Text;
                        if (dic["BenefitCommencementAge_txt"] != sActVal)
                        {
                            _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + dic["BenefitCommencementAge_txt"] + "> to object <GuaranteePeriod_txt>. Actual Value: <" + sActVal + "> ");
                        }
                    }
                }


                _gLib._SetSyncUDWin("MortalityInDeferralPeriod", this.wRetirementStudio.wMortalityInDeferralPeriod_From.cboMortalityInDeferralPeriod_From, dic["MortalityInDeferralPeriod"], 0);
                _gLib._SetSyncUDWin("ActuarialEquivalence", this.wRetirementStudio.wActuarialEquivalence_From.cboActuarialEquivalence_From, dic["ActuarialEquivalence"], 0);
                _gLib._SetSyncUDWin("ApplyDifferentStartAgeforPostCommencement", this.wRetirementStudio.wApplyDifferentStarta.chk, dic["ApplyDifferentStartAgeforPostCommencement"], 0);
                _gLib._SetSyncUDWin("ApplyPercentMarriedAndSpouseAgeDifference", this.wRetirementStudio.wApplyPercentMarriedAndSpouseAgeDifference.chk, dic["ApplyPercentMarriedAndSpouseAgeDifference"], 0);
                _gLib._SetSyncUDWin("StartAgeforPostCommencement_C", this.wRetirementStudio.wStartAge_C.btn, dic["StartAgeforPostCommencement_C"], 0);
                _gLib._SetSyncUDWin_ByClipboard("StartAgeforPostCommencement_txt", this.wRetirementStudio.wStartAge_txt.txt, dic["StartAgeforPostCommencement_txt"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
               
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
        ///    dic.Add("T", "");
        ///    dic.Add("C", "Click");
        ///    dic.Add("txtTabularOrConstantFactor_M", "0.8811");
        ///    dic.Add("txtTabularOrConstantFactor_F", "0.9143");
        ///    dic.Add("cboTabularOrConstantFactor", "");
        ///    pConversionFactors._PopVerify_TabularOrConstantFactor(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_TabularOrConstantFactor(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_TabularOrConstantFactor";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("C", this.wRetirementStudio.wGuaranteePeriod_To_CIcon.btnGuaranteePeriod_To_C, dic["C"], 0);
                _gLib._SetSyncUDWin("T", this.wRetirementStudio.wTabularOrConstantFactor_TIcon.btnT, dic["T"], 0);
                _gLib._SetSyncUDWin_ByClipboard("txtTabularOrConstantFactor_M", this.wRetirementStudio.wTabularOrConstantFactor_M_txt.txtTabularOrConstantFactor_M, dic["txtTabularOrConstantFactor_M"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("txtTabularOrConstantFactor_F", this.wRetirementStudio.wTabularOrConstantFactor_F_txt.txtTabularOrConstantFactor_F, dic["txtTabularOrConstantFactor_F"], true, 0);
                _gLib._SetSyncUDWin("cboTabularOrConstantFactor", this.wRetirementStudio.wTabularOrConstantFactor_cbo.cboTabularOrConstantFactor, dic["cboTabularOrConstantFactor"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("C", this.wRetirementStudio.wGuaranteePeriod_To_CIcon.btnGuaranteePeriod_To_C, dic["C"], 0);
                _gLib._VerifySyncUDWin("T", this.wRetirementStudio.wTabularOrConstantFactor_TIcon.btnT, dic["T"], 0);
                _gLib._VerifySyncUDWin("txtTabularOrConstantFactor_M", this.wRetirementStudio.wTabularOrConstantFactor_M_txt.txtTabularOrConstantFactor_M, dic["txtTabularOrConstantFactor_M"], 0);
                _gLib._VerifySyncUDWin("txtTabularOrConstantFactor_F", this.wRetirementStudio.wTabularOrConstantFactor_F_txt.txtTabularOrConstantFactor_F, dic["txtTabularOrConstantFactor_F"], 0);
                _gLib._VerifySyncUDWin("cboTabularOrConstantFactor", this.wRetirementStudio.wTabularOrConstantFactor_cbo.cboTabularOrConstantFactor, dic["cboTabularOrConstantFactor"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
