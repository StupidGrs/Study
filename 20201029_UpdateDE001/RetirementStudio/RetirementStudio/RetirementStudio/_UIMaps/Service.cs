namespace RetirementStudio._UIMaps.ServiceClasses
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

    public partial class Service
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
        ///    dic.Add("ServiceAtValuationDate", "True");
        ///    dic.Add("RulesBasedService", "");
        ///    dic.Add("ServiceAsAFunction", "");
        ///    dic.Add("CustomCode", "");
        ///    dic.Add("UseServiceCa", "");
        ///    dic.Add("ForInternationalAccounting_DE", "");
        ///    dic.Add("ForTrade_DE", "");
        ///    dic.Add("CalculateExactServiceAtReitermentAge_UK", "");
        ///    pService._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ServiceAtValuationDate", this.wRetirementStudio.wServiceAtValuationDate.rdServiceAtValuationDate, dic["ServiceAtValuationDate"], 0);
                _gLib._SetSyncUDWin("RulesBasedService", this.wRetirementStudio.wRulesBasedService.rdRulesBasedService, dic["RulesBasedService"], 0);
                _gLib._SetSyncUDWin("ServiceAsAFunction", this.wRetirementStudio.wServiceAsAFunction.rdwServiceAsAFunction, dic["ServiceAsAFunction"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
                _gLib._SetSyncUDWin("UseServiceCa", this.wRetirementStudio.wUseServiceCap.chkUseServiceCap, dic["UseServiceCa"], 0);
                _gLib._SetSyncUDWin("ForInternationalAccounting_DE", this.wRetirementStudio.wForInternationalAccounting_DE.chk, dic["ForInternationalAccounting_DE"], 0);
                _gLib._SetSyncUDWin("ForTrade_DE", this.wRetirementStudio.wForTrade_DE.chk, dic["ForTrade_DE"], 0);
                _gLib._SetSyncUDWin("CalculateExactServiceAtReitermentAge_UK", this.wRetirementStudio.wCalculateExactServiceAt.chk, dic["CalculateExactServiceAtReitermentAge_UK"], 0);
           
            }

            if (dic["PopVerify"] == "Verify")
            {
                
                _gLib._VerifySyncUDWin("ServiceAtValuationDate", this.wRetirementStudio.wServiceAtValuationDate.rdServiceAtValuationDate, dic["ServiceAtValuationDate"], 0);
                _gLib._VerifySyncUDWin("RulesBasedService", this.wRetirementStudio.wRulesBasedService.rdRulesBasedService, dic["RulesBasedService"], 0);
                _gLib._VerifySyncUDWin("ServiceAsAFunction", this.wRetirementStudio.wServiceAsAFunction.rdwServiceAsAFunction, dic["ServiceAsAFunction"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);
                _gLib._VerifySyncUDWin("UseServiceCa", this.wRetirementStudio.wUseServiceCap.chkUseServiceCap, dic["UseServiceCa"], 0);
                _gLib._VerifySyncUDWin("ForInternationalAccounting_DE", this.wRetirementStudio.wForInternationalAccounting_DE.chk, dic["ForInternationalAccounting_DE"], 0);
                _gLib._VerifySyncUDWin("ForTrade_DE", this.wRetirementStudio.wForTrade_DE.chk, dic["ForTrade_DE"], 0);
                _gLib._VerifySyncUDWin("CalculateExactServiceAtReitermentAge_UK", this.wRetirementStudio.wCalculateExactServiceAt.chk, dic["CalculateExactServiceAtReitermentAge_UK"], 0);
           
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
        ///    dic.Add("ProvidedInDataField", "");
        ///    dic.Add("RoundingRule", "");
        ///    dic.Add("V", "");
        ///    dic.Add("C", "");
        ///    dic.Add("T", "");
        ///    dic.Add("txtServiceIncrement", "");
        ///    dic.Add("cboServiceIncrement", "");
        ///    pService._PopVerify_ServiceAtValuationDate(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ServiceAtValuationDate(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ServiceAtValuationDate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ProvidedInDataField", this.wRetirementStudio.wServiceAtValuationDate_ProvidedInDataField.cboProvidedInDataField, dic["ProvidedInDataField"], 0);
                _gLib._SetSyncUDWin("RoundingRule", this.wRetirementStudio.wServiceAtValuationDate_RoundingRule.cboRoundingRule, dic["RoundingRule"], 0);
                _gLib._SetSyncUDWin("V", this.wRetirementStudio.wServiceAtValuationDate_VIcon.btnV, dic["V"], 0);
                _gLib._SetSyncUDWin("C", this.wRetirementStudio.wServiceAtValuationDate_CIcon.btnC, dic["C"], 0);
                _gLib._SetSyncUDWin("T", this.wRetirementStudio.wServiceAtValuationDate_TIcon.btnT, dic["T"], 0);
                _gLib._SetSyncUDWin_ByClipboard("txtServiceIncrement", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrement_txt.txtServiceIncrement, dic["txtServiceIncrement"], true, 0);
                _gLib._SetSyncUDWin("cboServiceIncrement", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrease_cbo.cboServiceIncrement, dic["cboServiceIncrement"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("ProvidedInDataField", this.wRetirementStudio.wServiceAtValuationDate_ProvidedInDataField.cboProvidedInDataField, dic["ProvidedInDataField"], 0);
                _gLib._VerifySyncUDWin("RoundingRule", this.wRetirementStudio.wServiceAtValuationDate_RoundingRule.cboRoundingRule, dic["RoundingRule"], 0);
                _gLib._VerifySyncUDWin("V", this.wRetirementStudio.wServiceAtValuationDate_VIcon.btnV, dic["V"], 0);
                _gLib._VerifySyncUDWin("C", this.wRetirementStudio.wServiceAtValuationDate_CIcon.btnC, dic["C"], 0);
                _gLib._VerifySyncUDWin("T", this.wRetirementStudio.wServiceAtValuationDate_TIcon.btnT, dic["T"], 0);
                _gLib._VerifySyncUDWin("txtServiceIncrement", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrement_txt.txtServiceIncrement, dic["txtServiceIncrement"], 0);
                _gLib._VerifySyncUDWin("cboServiceIncrement", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrease_cbo.cboServiceIncrement, dic["cboServiceIncrement"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Dec-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ServiceStarts_Age_V", "");
        ///    dic.Add("ServiceStarts_Age_C", "");
        ///    dic.Add("ServiceStarts_Age_cbo", "");
        ///    dic.Add("ServiceStarts_Age_txt", "");
        ///    dic.Add("ServiceStarts_FixedDate", "");
        ///    dic.Add("Date", "");
        ///    dic.Add("RoundingRule", "Completed months");
        ///    dic.Add("ServiceIncreasement_V", "");
        ///    dic.Add("ServiceIncreasement_C", "");
        ///    dic.Add("ServiceIncreasement_cbo", "");
        ///    dic.Add("ServiceIncreasement_txt", "");
        ///    pService._PopVerify_RulesBasedService(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_RulesBasedService(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_RulesBasedService";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iIndex_cbo = 2;
            int iIndex_txt = 1;

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ServiceStarts_Age_V", this.wRetirementStudio.wServiceStarts_Age_V.btn, dic["ServiceStarts_Age_V"], 0);
                _gLib._SetSyncUDWin("ServiceStarts_Age_C", this.wRetirementStudio.wServiceStarts_Age_C.btn, dic["ServiceStarts_Age_C"], 0);

 
                this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iIndex_cbo.ToString());
                _gLib._SetSyncUDWin("ServiceStarts_Age_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["ServiceStarts_Age_cbo"], 0);

                this.wRetirementStudio.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iIndex_txt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("ServiceStarts_Age_txt", this.wRetirementStudio.wCommon_txt.txt, dic["ServiceStarts_Age_txt"], true, 0);

                _gLib._SetSyncUDWin_ByClipboard("ServiceStarts_FixedDate", this.wRetirementStudio.wServiceStarts_FixedDate_DE.cbo.txt, dic["ServiceStarts_FixedDate"], true, 0);
                _gLib._SetSyncUDWin("Date", this.wRetirementStudio.wRulesBasedService_Date.cboDate, dic["Date"], 0);

                _gLib._SetSyncUDWin("Rounding Rule", this.wRetirementStudio.wServiceAtValuationDate_RoundingRule.cboRoundingRule, dic["RoundingRule"], 0);

                _gLib._SetSyncUDWin("ServiceIncreasement_V", this.wRetirementStudio.wServiceIncreasement_V.btn, dic["ServiceIncreasement_V"], 0);
                _gLib._SetSyncUDWin("ServiceIncreasement_C", this.wRetirementStudio.wServiceIncreasement_C.btn, dic["ServiceIncreasement_C"], 0);

                if (dic["ServiceStarts_Age_V"] != "")
                    iIndex_cbo = 3;

                this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iIndex_cbo.ToString());
                _gLib._SetSyncUDWin("ServiceIncreasement_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["ServiceIncreasement_cbo"], 0);


                if (dic["ServiceStarts_Age_C"] != "")
                    iIndex_txt = 2;

                this.wRetirementStudio.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iIndex_txt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("ServiceIncreasement_txt", this.wRetirementStudio.wCommon_txt.txt, dic["ServiceIncreasement_txt"], true, 0);


            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Apr-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ProvidedInDataField", "ValuationServiceAtValDate");
        ///    dic.Add("ServiceEndsAt_V", "");
        ///    dic.Add("ServiceEndsAt_C", "Click");
        ///    dic.Add("ServiceEndsAt_cbo", "");
        ///    dic.Add("ServiceEndsAt_txt", "65");
        ///    dic.Add("MaximumService_UseServiceCap", "");
        ///    dic.Add("FixedDate_UseServiceCap", "");
        ///    dic.Add("Date_UseServiceCap", "");
        ///    dic.Add("RoundingRule", ""); 
        ///    dic.Add("ServiceIncrement_V", "");
        ///    dic.Add("ServiceIncrement_C", "");
        ///    dic.Add("ServiceIncrement_cbo", "");
        ///    dic.Add("ServiceIncrement_txt", "");
        ///    pService._PopVerify_ServiceAtValuationDate_UseServiceCap(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ServiceAtValuationDate_UseServiceCap(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ServiceAtValuationDate_UseServiceCap";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iV = 1;
            int iC = 1;
            int icbo = 1;
            int itxt = 1;

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ProvidedInDataField", this.wRetirementStudio.wServiceAtValuationDate_ProvidedInDataField.cboProvidedInDataField, dic["ProvidedInDataField"], 0);

                if(dic["ServiceEndsAt_V"]!="")
                {
                    this.wRetirementStudio.wServiceAtValuationDate_VIcon.btnV.SearchProperties.Add(WinWindow.PropertyNames.Instance, iV.ToString());
                    iV++;
                    _gLib._SetSyncUDWin("ServiceEndsAt_V", this.wRetirementStudio.wServiceAtValuationDate_VIcon.btnV, dic["ServiceEndsAt_V"], 0);
               
                }

                if (dic["ServiceEndsAt_C"] != "")
                {
                    this.wRetirementStudio.wServiceAtValuationDate_CIcon.btnC.SearchProperties.Add(WinWindow.PropertyNames.Instance, iC.ToString());
                    iC++;
                    _gLib._SetSyncUDWin("ServiceEndsAt_C", this.wRetirementStudio.wServiceAtValuationDate_CIcon.btnC, dic["ServiceEndsAt_C"], 0);
                }

                if (dic["ServiceEndsAt_cbo"] != "")
                {
                    this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrease_cbo.cboServiceIncrement.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    icbo=7;
                    _gLib._SetSyncUDWin("ServiceEndsAt_cbo", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrease_cbo.cboServiceIncrement, dic["ServiceEndsAt_cbo"], 0);
                }
                if (dic["ServiceEndsAt_txt"] != "")
                {
                    this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrement_txt.txtServiceIncrement.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    itxt=6;
                    _gLib._SetSyncUDWin_ByClipboard("ServiceEndsAt_txt", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrement_txt.txtServiceIncrement, dic["ServiceEndsAt_txt"], true, 0);
                }

                _gLib._SetSyncUDWin_ByClipboard("MaximumService_UseServiceCap", this.wRetirementStudio.wMaximumService_UseServiceCap.txt, dic["MaximumService_UseServiceCap"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("FixedDate_UseServiceCap", this.wRetirementStudio.wFixedDate_UseServiceCap.cbo.txt, dic["FixedDate_UseServiceCap"], true, 0);
                _gLib._SetSyncUDWin("Date_UseServiceCap", this.wRetirementStudio.wDate_UseServiceCap.cbo, dic["Date_UseServiceCap"], 0);
   
                _gLib._SetSyncUDWin("RoundingRule", this.wRetirementStudio.wServiceAtValuationDate_RoundingRule.cboRoundingRule, dic["RoundingRule"], 0);

                if (dic["ServiceIncrement_V"] != "")
                {
                    this.wRetirementStudio.wServiceAtValuationDate_VIcon.btnV.SearchProperties.Add(WinWindow.PropertyNames.Instance, iV.ToString());
                    _gLib._SetSyncUDWin("ServiceIncrement_V", this.wRetirementStudio.wServiceAtValuationDate_VIcon.btnV, dic["ServiceIncrement_V"], 0);
                }

                if (dic["ServiceIncrement_C"] != "")
                {
                    this.wRetirementStudio.wServiceAtValuationDate_CIcon.btnC.SearchProperties.Add(WinWindow.PropertyNames.Instance, iC.ToString());
                    _gLib._SetSyncUDWin("ServiceIncrement_C", this.wRetirementStudio.wServiceAtValuationDate_CIcon.btnC, dic["ServiceIncrement_C"], 0);
                }

                if (dic["ServiceIncrement_cbo"] != "")
                {
                    this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrease_cbo.cboServiceIncrement.SearchProperties.Add(WinWindow.PropertyNames.Instance, icbo.ToString());
                    _gLib._SetSyncUDWin("ServiceIncrement_cbo", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrease_cbo.cboServiceIncrement, dic["ServiceIncrement_cbo"], 0);
                }
                if (dic["ServiceIncrement_txt"] != "")
                {
                    this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrement_txt.txtServiceIncrement.SearchProperties.Add(WinWindow.PropertyNames.Instance, itxt.ToString());
                    _gLib._SetSyncUDWin_ByClipboard("ServiceIncrement_txt", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrement_txt.txtServiceIncrement, dic["ServiceIncrement_txt"], true, 0);
                }
            }

            //////if (dic["PopVerify"] == "Verify")
            //////{

            //////    _gLib._VerifySyncUDWin("ProvidedInDataField", this.wRetirementStudio.wServiceAtValuationDate_ProvidedInDataField.cboProvidedInDataField, dic["ProvidedInDataField"], 0);
            //////    _gLib._VerifySyncUDWin("RoundingRule", this.wRetirementStudio.wServiceAtValuationDate_RoundingRule.cboRoundingRule, dic["RoundingRule"], 0);
            //////    _gLib._VerifySyncUDWin("V", this.wRetirementStudio.wServiceAtValuationDate_VIcon.btnV, dic["V"], 0);
            //////    _gLib._VerifySyncUDWin("C", this.wRetirementStudio.wServiceAtValuationDate_CIcon.btnC, dic["C"], 0);
            //////    _gLib._VerifySyncUDWin("T", this.wRetirementStudio.wServiceAtValuationDate_TIcon.btnT, dic["T"], 0);
            //////    _gLib._VerifySyncUDWin("txtServiceIncrement", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrement_txt.txtServiceIncrement, dic["txtServiceIncrement"], 0);
            //////    _gLib._VerifySyncUDWin("cboServiceIncrement", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrease_cbo.cboServiceIncrement, dic["cboServiceIncrement"], 0);

            //////}


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-May-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ServiceStarts_Date", "WaitingPeriodStartDate");
        ///    dic.Add("CalculationMethod", "Valuation date");
        ///    dic.Add("RoundingPeriod", "Years");
        ///    dic.Add("RoundingMethod", "Completed");
        ///    pService._PopVerify_RulesBasedService_DE(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_RulesBasedService_DE(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_RulesBasedService_DE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ServiceStarts_Date", this.wRetirementStudio.wRulesBasedService_Date.cboDate, dic["ServiceStarts_Date"], 0);
                _gLib._SetSyncUDWin("CalculationMethod", this.wRetirementStudio.wCalculationMethod_DE.cbo, dic["CalculationMethod"], 0);
                _gLib._SetSyncUDWin("RoundingPeriod", this.wRetirementStudio.wRoundingPeriod_DE.cbo, dic["RoundingPeriod"], 0);
                _gLib._SetSyncUDWin("RoundingMethod", this.wRetirementStudio.wRoundingMethod_DE.cbo, dic["RoundingMethod"], 0);
            
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("ServiceStarts_Date", this.wRetirementStudio.wRulesBasedService_Date.cboDate, dic["ServiceStarts_Date"], 0);
                _gLib._VerifySyncUDWin("CalculationMethod", this.wRetirementStudio.wCalculationMethod_DE.cbo, dic["CalculationMethod"], 0);
                _gLib._VerifySyncUDWin("RoundingPeriod", this.wRetirementStudio.wRoundingPeriod_DE.cbo, dic["RoundingPeriod"], 0);
                _gLib._VerifySyncUDWin("RoundingMethod", this.wRetirementStudio.wRoundingMethod_DE.cbo, dic["RoundingMethod"], 0);
            
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-May-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("IRUK", "True");
        ///    dic.Add("ServiceStarts_V", "");
        ///    dic.Add("ServiceStarts_C", "");
        ///    dic.Add("ServiceStarts_cbo", "");
        ///    dic.Add("ServiceStarts_txt", "");
        ///    dic.Add("ServiceStarts_FixedDate", "");
        ///    dic.Add("ServiceStarts_Date", "");
        ///    dic.Add("ServiceEnds_V", "");
        ///    dic.Add("ServiceEnds_C", "");
        ///    dic.Add("ServiceEnds_cbo", "");
        ///    dic.Add("ServiceEnds_txt", "");
        ///    dic.Add("MaximumService_UseServiceCap", "");
        ///    dic.Add("ServiceEnds_FixedDate", "");
        ///    dic.Add("ServiceEnds_Date", "");
        ///    dic.Add("CalculationMethod", "Valuation date");
        ///    dic.Add("RoundingPeriod", "Years");
        ///    dic.Add("RoundingMethod", "Completed");
        ///    dic.Add("RoundingRule", "");
        ///    dic.Add("ServiceIncreasement_V", "");
        ///    dic.Add("ServiceIncreasement_C", "");
        ///    dic.Add("ServiceIncreasement_cbo", "");
        ///    dic.Add("ServiceIncreasement_txt", "");
        ///    pService._PopVerify_RulesBasedService_UseServiceCap_DE(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_RulesBasedService_UseServiceCap_DE(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_RulesBasedService_UseServiceCap_DE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ServiceStarts_V", this.wRetirementStudio.wServiceAtValuationDate_VIcon.btnV, dic["ServiceStarts_V"], 0);
                _gLib._SetSyncUDWin("ServiceStarts_C", this.wRetirementStudio.wServiceAtValuationDate_CIcon.btnC, dic["ServiceStarts_C"], 0);
                _gLib._SetSyncUDWin("ServiceStarts_cbo", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrease_cbo.cboServiceIncrement, dic["ServiceStarts_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ServiceStarts_txt", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrement_txt.txtServiceIncrement, dic["ServiceStarts_txt"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ServiceStarts_FixedDate", this.wRetirementStudio.wServiceStarts_FixedDate_DE.cbo.txt, dic["ServiceStarts_FixedDate"], 0);
                _gLib._SetSyncUDWin("ServiceStarts_Date", this.wRetirementStudio.wRulesBasedService_Date.cboDate, dic["ServiceStarts_Date"], 0);

                if (dic["ServiceEnds_cbo"] != "")
                {
                    
                    string sInstance = "1";

                    if (dic["ServiceStarts_V"] != "") sInstance = "2";

                    ////////if (dic["IRUK"].ToUpper() == "TRUE")
                    ////////{ 
                    ////////    if (dic["ServiceStarts_V"] != "") sInstance = "3";
                    ////////}
                    ////////else
                    ////////    if (dic["ServiceStarts_V"] != "") sInstance = "2";


                    this.wRetirementStudio.wServiceAtValuationDate_VIcon.btnV.SearchProperties.Add(WinWindow.PropertyNames.Instance, sInstance);
                    this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrease_cbo.cboServiceIncrement.SearchProperties.Add(WinWindow.PropertyNames.Instance, sInstance);
                        
                    _gLib._SetSyncUDWin("ServiceEnds_V", this.wRetirementStudio.wServiceAtValuationDate_VIcon.btnV, dic["ServiceEnds_V"], 0);
                    _gLib._SetSyncUDWin("ServiceEnds_cbo", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrease_cbo.cboServiceIncrement, dic["ServiceEnds_cbo"], 0);

                }
                if (dic["ServiceEnds_txt"] != "")
                {
                    string sInstance = "1";
                    if (dic["ServiceStarts_C"] != "") sInstance = "2";

                    this.wRetirementStudio.wServiceAtValuationDate_CIcon.btnC.SearchProperties.Add(WinWindow.PropertyNames.Instance, sInstance);
                    _gLib._SetSyncUDWin("ServiceEnds_C", this.wRetirementStudio.wServiceAtValuationDate_CIcon.btnC, dic["ServiceEnds_C"], 0);
                    this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrement_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, sInstance);
                    _gLib._SetSyncUDWin_ByClipboard("ServiceEnds_txt", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrement_txt.txtServiceIncrement, dic["ServiceEnds_txt"], 0);

                }
                
                _gLib._SetSyncUDWin_ByClipboard("MaximumService_UseServiceCap", this.wRetirementStudio.wMaximumService_UseServiceCap.txt, dic["MaximumService_UseServiceCap"], true, 0);

                _gLib._SetSyncUDWin_ByClipboard("ServiceEnds_FixedDate", this.wRetirementStudio.wServiceEnds_FixedDate_DE.cbo.txt, dic["ServiceEnds_FixedDate"], 0);
                _gLib._SetSyncUDWin("ServiceEnds_Date", this.wRetirementStudio.wServiceEnds_Date_DE.cbo, dic["ServiceEnds_Date"], 0);


                _gLib._SetSyncUDWin("CalculationMethod", this.wRetirementStudio.wCalculationMethod_DE.cbo, dic["CalculationMethod"], 0);
                _gLib._SetSyncUDWin("RoundingPeriod", this.wRetirementStudio.wRoundingPeriod_DE.cbo, dic["RoundingPeriod"], 0);
                _gLib._SetSyncUDWin("RoundingMethod", this.wRetirementStudio.wRoundingMethod_DE.cbo, dic["RoundingMethod"], 0);
                _gLib._SetSyncUDWin("Rounding Rule", this.wRetirementStudio.wServiceAtValuationDate_RoundingRule.cboRoundingRule, dic["RoundingRule"], 0);


                _gLib._SetSyncUDWin("ServiceIncreasement_V", this.wRetirementStudio.wRulesBased_UseCap_ServiceIncrease_V.btn, dic["ServiceIncreasement_V"], 0);
                _gLib._SetSyncUDWin("ServiceIncreasement_C", this.wRetirementStudio.wRulesBased_UseCap_ServiceIncrease_C.btn, dic["ServiceIncreasement_C"], 0);
                
                if (dic["ServiceIncreasement_cbo"] != "")
                {
                    int sInstance = 2;
                    if (dic["ServiceStarts_V"] != "") sInstance = sInstance + 1;
                    if (dic["ServiceEnds_V"] != "") sInstance = sInstance + 1;

                    this.wRetirementStudio.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, sInstance.ToString());

                    _gLib._SetSyncUDWin("ServiceIncreasement_cbo", this.wRetirementStudio.wCommon_cbo.cbo, dic["ServiceIncreasement_cbo"], 0);

                }
                if (dic["ServiceIncreasement_txt"] != "")
                {
                    int sInstance = 1;
                    if (dic["ServiceStarts_C"] != "") sInstance = sInstance + 1;
                    if (dic["ServiceEnds_C"] != "") sInstance = sInstance + 1;
                    this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrement_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, sInstance.ToString());

                    _gLib._SetSyncUDWin_ByClipboard("ServiceIncreasement_txt", this.wRetirementStudio.wServiceAtValuationDate_ServiceIncrement_txt.txtServiceIncrement, dic["ServiceIncreasement_txt"], 0);

                }
            
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._MsgBox("Warning", "No Verify function here!");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-April-5
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OtherDate", "");
        ///    dic.Add("Month", "");
        ///    dic.Add("Day", "");
        ///    dic.Add("Alignment", "");
        ///    pService._PopVerify_RulesBasedService_CalculationRules(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_RulesBasedService_CalculationRules(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_RulesBasedService_CalculationRules";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OtherDate", this.wRetirementStudio.wOtherDate.chk, dic["OtherDate"], 0);
                _gLib._SetSyncUDWin("Month", this.wRetirementStudio.wMonth.cbo, dic["Month"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Day", this.wRetirementStudio.wDay.txt.UIUneDayEdit1, dic["Day"], 0);
                _gLib._SetSyncUDWin("Alignment", this.wRetirementStudio.wAlignment.cbo, dic["Alignment"], 0);
             

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._MsgBox("Warning", "No Verify function here!");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
