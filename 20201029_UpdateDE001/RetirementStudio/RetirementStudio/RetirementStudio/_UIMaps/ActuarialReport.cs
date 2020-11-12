namespace RetirementStudio._UIMaps.ActuarialReportClasses
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


    public partial class ActuarialReport
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///
        ///    pActuarialReport._SelectTab("");
        /// </summary>
        /// <param name="dic"></param>
        public void _SelectTab(String sName)
        {
            string sFunctionName = "_PopVerify_NetAssets";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TabPageSelectWin(sName, this.wRetirementStudio.wTab, Config.iTimeout);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Dec-23
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ShowLYLiabilitiesInLastYear", "");
        ///    dic.Add("MecerLocation", "");
        ///    dic.Add("NameToBePrintedOnReportLeft", "");
        ///    dic.Add("AcademicTitleOfPersonLeft", "");
        ///    dic.Add("NameToBePrintedOnReportRight", "");
        ///    dic.Add("AcademicTitleOfPersonRight", "");
        ///    dic.Add("ExtensionOfUndersigningPersonRight", "");
        ///    dic.Add("LocationOfUndersigningPersonRight", "");
        ///    dic.Add("IndividualTermsAndConditions", "");
        ///    dic.Add("DoNotAttachTermsAndConditions", "");
        ///    pActuarialReport._General(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _General(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("ShowLYLiabilitiesInLastYear", this.wRetirementStudio.wG_ShowLYliabilitiesinl.chx, dic["ShowLYLiabilitiesInLastYear"], 0);
            _gLib._SetSyncUDWin("MecerLocation", this.wRetirementStudio.wG_MercerLocation.txt, dic["MecerLocation"], 0);
            _gLib._SetSyncUDWin("NameToBePrintedOnReportLeft", this.wRetirementStudio.wG_NameToBePrintedOnReport_Left.txt, dic["NameToBePrintedOnReportLeft"], 0);
            _gLib._SetSyncUDWin("AcademicTitleOfPersonLeft", this.wRetirementStudio.wG_AcademicTitleOfUn_Left.txt, dic["AcademicTitleOfPersonLeft"], 0);
            _gLib._SetSyncUDWin("NameToBePrintedOnReportRight", this.wRetirementStudio.wG_NameToBePrintedOn_Right.txt, dic["NameToBePrintedOnReportRight"], 0);
            _gLib._SetSyncUDWin("AcademicTitleOfPersonRight", this.wRetirementStudio.wG_AcademicTitleOfUn_Right.txt, dic["AcademicTitleOfPersonRight"], 0);
            _gLib._SetSyncUDWin_ByClipboard("ExtensionOfUndersigningPersonRight", this.wRetirementStudio.wG_ExtensionOfUnders_Right.txt, dic["ExtensionOfUndersigningPersonRight"], 0);
            _gLib._SetSyncUDWin("LocationOfUndersigningPersonRight", this.wRetirementStudio.wG_LocationOfUndersi_Right.txt, dic["LocationOfUndersigningPersonRight"], 0);
            _gLib._SetSyncUDWin("IndividualTermsAndConditions", this.wRetirementStudio.wG_IndividualTermsAndCondition.Edit, dic["IndividualTermsAndConditions"], 0);
            _gLib._SetSyncUDWin("DoNotAttachTermsAndConditions", this.wRetirementStudio.wG_DoNotAttachTermsAndConditions.chx, dic["DoNotAttachTermsAndConditions"], 0);

        }


        /// <summary>
        /// 2015-Dec-23
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ClientLongName", "true");
        ///    dic.Add("ClientLongName_txt", "A. & C KOSIK GmbH");
        ///    dic.Add("ClientShortName", "true");
        ///    dic.Add("ClientShortName_txt", "A. & C KOSIK GmbH");
        ///    dic.Add("ClientCode", "");
        ///    dic.Add("AddressLine1", "true");
        ///    dic.Add("AddressLine1_txt", "Hirschberger Str. 1");
        ///    dic.Add("AddressLine2", "true");
        ///    dic.Add("AddressLine2_txt", "");
        ///    dic.Add("City", "true");
        ///    dic.Add("City_txt", "Kelheim");
        ///    dic.Add("PostalCode", "true");
        ///    dic.Add("PostalCode_txt", "93309");
        ///    dic.Add("Country", "true");
        ///    dic.Add("Country_txt", "Deutschland");
        ///    pActuarialReport._SubsidiaryInformation(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _SubsidiaryInformation(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("ClientLongName", this.wRetirementStudio.wSI_LongName.chx, dic["ClientLongName"], 0);
            _gLib._SetSyncUDWin("ClientLongName_txt", this.wRetirementStudio.wSI_LongName_txt.txt, dic["ClientLongName_txt"], 0);
            _gLib._SetSyncUDWin("ClientShortName", this.wRetirementStudio.wSI_ShortName.chx, dic["ClientShortName"], 0);
            _gLib._SetSyncUDWin("ClientShortName_txt", this.wRetirementStudio.wSI_ShortName_txt.txt, dic["ClientShortName_txt"], 0);
            _gLib._SetSyncUDWin("ClientCode", this.wRetirementStudio.wSI_ClientCode.txt, dic["ClientCode"], 0);
            _gLib._SetSyncUDWin("AddressLine1", this.wRetirementStudio.wSI_AddressLine1.chx, dic["AddressLine1"], 0);
            _gLib._SetSyncUDWin("AddressLine1_txt", this.wRetirementStudio.wSI_AddressLine1_txt.txt, dic["AddressLine1_txt"], 0);
            _gLib._SetSyncUDWin("AddressLine2", this.wRetirementStudio.wAddressLine2.chx, dic["AddressLine2"], 0);
            _gLib._SetSyncUDWin("AddressLine2_txt", this.wRetirementStudio.wAddressLine2_txt.txt, dic["AddressLine2_txt"], 0);
            _gLib._SetSyncUDWin("City", this.wRetirementStudio.wSI_City.chx, dic["City"], 0);
            _gLib._SetSyncUDWin("City_txt", this.wRetirementStudio.wSI_City_txt.txt, dic["City_txt"], 0);
            _gLib._SetSyncUDWin("PostalCode", this.wRetirementStudio.wSI_PostalCode.chx, dic["PostalCode"], 0);
            _gLib._SetSyncUDWin("PostalCode_txt", this.wRetirementStudio.wSI_PostalCode_txt.txt, dic["PostalCode_txt"], 0);
            _gLib._SetSyncUDWin("Country", this.wRetirementStudio.wSI_Country.chx, dic["Country"], 0);
            _gLib._SetSyncUDWin("Country_txt", this.wRetirementStudio.wSI_Country_txt.txt, dic["Country_txt"], 0);

        }


        /// <summary>
        /// 2015-Dec-23
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("ReportSetName", "");
        ///    dic.Add("ReportType", "");
        ///    dic.Add("ReportTemplate", "");
        ///    dic.Add("Listing1", "");
        ///    dic.Add("Listing2", "");
        ///    pActuarialReport._ReportContents_DefineReportSets(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _ReportContents_DefineReportSets(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRowNum = Convert.ToInt32(dic["iRow"]);
            string sFirstChar = "";
            string sRow = "";

            for (int i = 1; i < iRowNum; i++)
                sRow = sRow + "{Down}";

            int iStartY = 10;
            int iEndY = iStartY + iRowNum * 20;

            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Home}", 0, ModifierKeys.Control, false);

            if (iRowNum < 6)
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wRC_DefineReportSets.grid, "Click", 0, false, 30, iEndY);
            else
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRC_DefineReportSets.grid, sRow, 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wRC_DefineReportSets.grid, "Click", 0, false, 130, (this.wRetirementStudio.wRC_DefineReportSets.grid.Height - 8));

                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Home}", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRC_DefineReportSets.grid, sRow, 0);

                if (this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wRC_DefineReportSets.grid) + 1 != iRowNum)
                    _gLib._MsgBoxYesNo("", "cannot locat the row num, Expression row num is :" + iRowNum + ",but the actual row num is " + this._fp._ReturnSelectRowIndex(this.wRetirementStudio.wRC_DefineReportSets.grid) + ".please check ");
            }


            if (dic["ReportSetName"] != "")
            {
                _gLib._SendKeysUDWin("ReportSetName", this.wRetirementStudio.wRC_DefineReportSets.grid, dic["ReportSetName"], 0);

                _gLib._SendKeysUDWin("ReportSetName", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Tab}", 0);
                _gLib._SendKeysUDWin("ReportSetName", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Tab}", 0, ModifierKeys.Shift, false);

                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_DefineReportSets.grid) != dic["ReportSetName"])
                    _gLib._MsgBoxYesNo("Continue ? ?", "Fail to set value, the expection vaule is :" + dic["ReportSetName"] + ",but the actual value is :" + this.wRetirementStudio.wRC_DefineReportSets.grid + "");
            }


            if (dic["ReportType"] != "")
            {
                _gLib._SendKeysUDWin("ReportType", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Tab}{Home}{Tab}{Enter}", 0);
                _gLib._SetSyncUDWin("ReportType", this.wReportContent.wReportTemplate.wList, dic["ReportType"], 0, false);

                _gLib._SendKeysUDWin("ReportType", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Tab}{Home}{Tab}{Enter}", 0);
                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_DefineReportSets.grid) != dic["ReportType"])
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["ReportType"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_DefineReportSets.grid) + ">" + Environment.NewLine);
            }


            if (dic["ReportTemplate"] != "")
            {
                _gLib._SendKeysUDWin("ReportTemplate", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Tab}{Home}{Tab}{Tab}{Enter}", 0);
                _gLib._SetSyncUDWin("ReportTemplate", this.wReportContent.wReportTemplate.wList, dic["ReportTemplate"], 0, false);

                _gLib._SendKeysUDWin("ReportTemplate", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Tab}{Home}{Tab}{Tab}{Enter}", 0);
                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_DefineReportSets.grid) != dic["ReportTemplate"])
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["ReportTemplate"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_DefineReportSets.grid) + ">" + Environment.NewLine);
            }


            if (dic["Listing1"] != "")
            {
                _gLib._SendKeysUDWin("Listing1", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Left}{Home}{Tab}{Tab}{Tab}{Enter}", 0);
                _gLib._SetSyncUDWin("Listing1", this.wReportContent.wReportTemplate.wList, dic["Listing1"], 0, false);

                _gLib._SendKeysUDWin("Listing1", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Left}{Home}{Tab}{Tab}{Tab}{Enter}", 0);
                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_DefineReportSets.grid) != dic["Listing1"])
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["Listing1"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_DefineReportSets.grid) + ">" + Environment.NewLine);
            }


            if (dic["Listing2"] != "")
            {
                _gLib._SendKeysUDWin("Listing2", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Left}{Home}{Tab}{Tab}{Tab}{Tab}{Enter}", 0);
                _gLib._SetSyncUDWin("Listing2", this.wReportContent.wReportTemplate.wList, dic["Listing2"], 0, false);

                _gLib._SendKeysUDWin("Listing2", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Left}{Home}{Tab}{Tab}{Tab}{Tab}{Enter}", 0);
                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_DefineReportSets.grid) != dic["Listing2"])
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["Listing2"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_DefineReportSets.grid) + ">" + Environment.NewLine);

                //sFirstChar = dic["Listing2"].Substring(0, 1);

                //_gLib._SendKeysUDWin("Listing2", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{Tab}", 0);

                //for (int i = 1; i <= 20; i++)
                //{
                //    _gLib._SendKeysUDWin("Listing2", this.wRetirementStudio.wRC_DefineReportSets.grid, sFirstChar, 0);
                //    _gLib._SendKeysUDWin("Listing2", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                //    _gLib._SendKeysUDWin("Listing2", this.wRetirementStudio.wRC_DefineReportSets.grid, "{Tab}", 0);

                //    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_DefineReportSets.grid) == dic["Listing2"])
                //        break;
                //}

                //if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_DefineReportSets.grid) != dic["Listing2"])
                //    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["Listing2"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_DefineReportSets.grid) + ">" + Environment.NewLine);
            }


        }


        /// <summary>
        /// 2015-Dec-23
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("VOShortName", "");
        ///    dic.Add("VOZusammenfassung", "");
        ///    dic.Add("VOSummary", "");
        ///    pActuarialReport._ReportContents_VOSummaries(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _ReportContents_VOSummaries(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wRC_VOSummary_grid.grid, "Click", 0, false, 16, 35);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRC_VOSummary_grid.grid, "{Right}{Home}", 0);


            for (int i = 1; i < 20; i++)
            {

                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wRC_VOSummary_grid.grid) == dic["VOShortName"])
                    break;
                else
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRC_VOSummary_grid.grid, "{Down}", 0);
            }


            if (dic["VOZusammenfassung"] != "")
            {

                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRC_VOSummary_grid.grid, "{Tab}{Tab}{space}{Tab}{space}", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wOpenWindow.wFileName.txt, dic["VOZusammenfassung"], 0, false);
                if (_gLib._Exists("", this.wOpenWindow.wOpenSplit.btn, 0))
                    _gLib._SendKeysUDWin("FPGrid", this.wOpenWindow.wOpenSplit.btn, "{enter}", 5);
                else
                    _gLib._SetSyncUDWin("FPGrid", this.wOpenWindow.wOpen.btn, "Click", 5);
            }


            if (dic["VOSummary"] != "")
            {

                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRC_VOSummary_grid.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{space}{Tab}{space}", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wOpenWindow.wFileName.txt, dic["VOSummary"], 0, false);

                if (_gLib._Exists("", this.wOpenWindow.wOpenSplit.btn, 0))
                    _gLib._SendKeysUDWin("FPGrid", this.wOpenWindow.wOpenSplit.btn, "{enter}", 5);
                else
                    _gLib._SetSyncUDWin("FPGrid", this.wOpenWindow.wOpen.btn, "Click", 5);
            }


        }



        /// <summary>
        /// 2015-Dec-23
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("DirectPromise", "");
        ///    dic.Add("SupportFund", "");
        ///    dic.Add("NameOfSupportFund", "");
        ///    dic.Add("NumberOfReports", "");
        ///    pActuarialReport._TaxAndTrade(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _TaxAndTrade(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("FGrid", this.wRetirementStudio.wT_DirectPromise.chx, dic["DirectPromise"], 0, false, 18, 20);
            _gLib._SetSyncUDWin("FGrid", this.wRetirementStudio.wT_SupportFund.chx, dic["SupportFund"], 0);
            _gLib._SetSyncUDWin("FGrid", this.wRetirementStudio.wT_NameOfSupportFund.txt, dic["NameOfSupportFund"], 0);


            if (dic["NumberOfReports"] != "")
            {
                _gLib._SendKeysUDWin("NumberOfReports", this.wRetirementStudio.wT_NumberOfBreaks.txt, "{Home}{Delete}{Delete}{Delete}" + dic["NumberOfReports"] + "{Tab}", 0);

                if (_gLib._Exists("NumberOfReports", this.wConfirm.wYes.btn, 10, false))
                    _gLib._SetSyncUDWin("FGrid", this.wConfirm.wYes.btn, "click", 0);

                string sAct = this.wRetirementStudio.wT_NumberOfBreaks.txt.Text.ToString().Trim();
                if (sAct != dic["NumberOfReports"])
                    _gLib._MsgBoxYesNo("", "Function to set NumberOfReports, the expected value is: " + dic["NumberOfReports"] + " ,but the actual value is: " + sAct);

            }

        }



        /// <summary>
        /// 2015-Dec-23
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("InformationByBreak", "");
        ///    dic.Add("iCol", "");
        ///    dic.Add("sData", "");
        ///    dic.Add("sFieldType", "");
        ///    pActuarialReport._TaxAndTrade_TBL(dic,true); 
        /// </summary>
        /// <param name="dic"></param>
        public void _TaxAndTrade_TBL(MyDictionary dic, Boolean bContinue = false)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            int iCol = Convert.ToInt32(dic["iCol"]);
            string sCol = "";

            for (int i = 1; i <= iCol; i++)
                sCol = sCol + "{Tab}";


            if (!bContinue)
                _gLib._SetSyncUDWin("FGrid", this.wRetirementStudio.wT_Grid.grid, "click", 0, false, 33, 22);


            for (int i = 1; i <= 50; i++)
            {
                string sAct = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wT_Grid.grid);
                if (sAct.Equals(dic["InformationByBreak"]))
                    break;

                _gLib._SendKeysUDWin("", this.wRetirementStudio.wT_Grid.grid, "{Down}", 0);
            }


            if (!this._fp._ReturnSelectRowContent(this.wRetirementStudio.wT_Grid.grid).Equals(dic["InformationByBreak"]))
                _gLib._MsgBoxYesNo("", "cannot find item <" + dic["InformationByBreak"] + "> , please check it out::  " + dic["InformationByBreak"]);



            _gLib._SendKeysUDWin("", this.wRetirementStudio.wT_Grid.grid, sCol + "{space}", 0);


            if (dic["sData"].ToUpper() == "#BLANK")
            {
                _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wT_Grid.grid, "{space}{delete}{delete}{delete}{delete}{delete}{delete}{delete}{delete}{delete}{delete}{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}0{back}", 0);
                _gLib._SendKeysUDWin("", this.wRetirementStudio.wT_Grid.grid, "{Tab}{Home}", 0);
                return;
            }

            switch (dic["sFieldType"].ToUpper())
            {
                case "TXT":
                case "TEXT":
                    String Actl = "";

                    _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wT_Grid.grid, "{space}{delete}{delete}{delete}{delete}{delete}{delete}{delete}{delete}{delete}{delete}{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}0{back}", 0);

                    string temp = dic["sData"];
                    if (dic["sData"].LastIndexOf("%") == dic["sData"].Length - 1)
                        temp = dic["sData"].Substring(0, dic["sData"].Length - 1);

                    _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wT_Grid.grid, temp, 0);

                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wT_Grid.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wT_Grid.grid, "{Tab}", 0);

                    Actl = this._fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wT_Grid.grid).Trim();

                    if (Actl != dic["sData"])
                        _gLib._MsgBoxYesNo("Continue ? ", "The expection value is:  " + dic["sData"] + ":,but actual value is:  " + Actl + ":");

                    break;

                case "DATE":
                    _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wT_DateEditor.txt, dic["sData"], 0);

                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wT_Grid.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wT_Grid.grid, "{Tab}", 0);

                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wT_Grid.grid).ToUpper() != dic["sData"].ToUpper())
                        _gLib._MsgBoxYesNo("Continue ? ", "The expected value is: " + dic["sData"] + ",but actual value is " + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wT_Grid.grid));
                    break;

                case "LIST":
                    _gLib._SetSyncUDWin("FGrid", this.wRetirementStudio.wT_CommCbo.cbo, dic["sData"], 0);
                    break;

                case "CHX":
                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wT_Grid.grid).ToUpper() != dic["sData"].ToUpper())
                        _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wT_Grid.grid, "{space}", 0);
                    break;

                case "BROWSE":
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wT_FileNameItem.Edit, "{tab}{space}", 0);

                    _gLib._SetSyncUDWin("FPGrid", this.wOpenWindow.wFileName.txt, dic["sData"], 0, false);

                    if (_gLib._Exists("", this.wOpenWindow.wOpenSplit.btn, 0))
                        _gLib._SendKeysUDWin("FPGrid", this.wOpenWindow.wOpenSplit.btn, "{Enter}", 5);
                    else
                        _gLib._SetSyncUDWin("FPGrid", this.wOpenWindow.wOpen.btn, "Click", 5);

                    break;

                default:
                    _gLib._MsgBoxYesNo("", "Please config your parameter <sFieldType> in function <_TaxAndTrade_TBL>");
                    break;
            }

            _gLib._SendKeysUDWin("", this.wRetirementStudio.wT_Grid.grid, "{Tab}{Home}", 0);

        }


        /// <summary>
        /// 2015-Dec-23
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    pActuarialReport._TaxAndTrade_TBL_PageDown(); 
        /// </summary>
        /// <param name="dic"></param>
        public void _TaxAndTrade_TBL_PageDown()
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("", this.wRetirementStudio.wT_VehicleScroll.wVerticalScrollBar.PageDown, "click", 0, false);

            for (int i = 1; i <= 5; i++)
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wT_VehicleScroll.wVerticalScrollBar.top, "click", 0, false);

        }



        /// <summary>
        /// 2015-Dec-23
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("InformationByBreak", "");
        ///    dic.Add("iCol", "");
        ///    dic.Add("sData", "");
        ///    dic.Add("sFieldType", "");
        ///    pActuarialReport._IntAcc_TBL(dic,true); 
        /// </summary>
        /// <param name="dic"></param>
        public void _IntAcc_TBL(MyDictionary dic, Boolean bContinue = false)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            int iCol = Convert.ToInt32(dic["iCol"]);
            string sCol = "";

            for (int i = 1; i <= iCol; i++)
                sCol = sCol + "{Tab}";


            if (!bContinue)
                _gLib._SetSyncUDWin("FGrid", this.wRetirementStudio.wIntAcc_grid.grid, "click", 0, false, 33, 22);
            _gLib._SendKeysUDWin("", this.wRetirementStudio.wIntAcc_grid.grid, "{Home}", 0);


            for (int i = 1; i <= 100; i++)
            {
                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wIntAcc_grid.grid).Equals(dic["InformationByBreak"]))
                    break;
                else
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wIntAcc_grid.grid, "{Down}", 0);
            }


            if (!this._fp._ReturnSelectRowContent(this.wRetirementStudio.wIntAcc_grid.grid).Equals(dic["InformationByBreak"]))
                _gLib._MsgBoxYesNo("", "there is no item <" + dic["InformationByBreak"] + "> , please check it out");



            _gLib._SendKeysUDWin("", this.wRetirementStudio.wIntAcc_grid.grid, sCol + "{space}", 0);

            switch (dic["sFieldType"].ToUpper())
            {
                case "TXT":
                case "TEXT":

                    if (dic["sData"] == "#BLANK")
                    {
                        _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wIntAcc_grid.grid, "{delete}{delete}{delete}{delete}{delete}{delete}{delete}{delete}{delete}{back}{back}{back}{back}{back}{back}{back}{back}0{back}", 0);
                        //////////_gLib._MsgBox("", "set " + dic["InformationByBreak"] + " as blank");
                        break;
                    }

                    ////// if there is a "%" in value ,it cannot input by keyboard
                    string temp = dic["sData"];
                    if (dic["sData"].LastIndexOf("%") == dic["sData"].Length - 1)
                        temp = dic["sData"].Substring(0, dic["sData"].Length - 1);

                    _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wIntAcc_grid.grid, "{delete}{delete}{delete}{delete}{delete}{delete}{delete}{delete}{delete}{back}{back}{back}{back}{back}{back}{back}{back}{back}" + temp, 0);

                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wIntAcc_grid.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wIntAcc_grid.grid, "{Tab}", 0);

                    string Actl = this._fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wIntAcc_grid.grid).Trim();

                    if (Actl != dic["sData"])
                        _gLib._MsgBoxYesNo("Continue ? ", "In colnum " + iCol + ",The expection value is: " + dic["sData"] + ",but actual value is " + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wT_Grid.grid));

                    break;

                case "DATE":
                    _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wT_DateEditor.txt, dic["sData"], 0);

                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wIntAcc_grid.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wIntAcc_grid.grid, "{Tab}", 0);

                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wIntAcc_grid.grid).ToUpper() != dic["sData"].ToUpper())
                        _gLib._MsgBoxYesNo("Continue ? ", "The expection value is: " + dic["sData"] + ",but actual value is " + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wT_Grid.grid));
                    break;

                case "LIST":
                    _gLib._SetSyncUDWin("FGrid", this.wRetirementStudio.wT_CommCbo.cbo, dic["sData"], 0);
                    break;

                case "CHX":
                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wIntAcc_grid.grid).ToUpper() != dic["sData"].ToUpper())
                        _gLib._SendKeysUDWin("FGrid", this.wRetirementStudio.wIntAcc_grid.grid, "{space}", 0);
                    break;

                case "BROWSE":
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wIntAcc_grid.grid, "{space}{tab}{space}", 0);

                    _gLib._SetSyncUDWin("FPGrid", this.wOpenWindow.wFileName.txt, dic["sData"], 0, false);

                    if (_gLib._Exists("", this.wOpenWindow.wOpenSplit.btn, 0))
                        _gLib._SendKeysUDWin("FPGrid", this.wOpenWindow.wOpenSplit.btn, "{Enter}", 5);
                    else
                        _gLib._SetSyncUDWin("FPGrid", this.wOpenWindow.wOpen.btn, "Click", 5);

                    break;

                default:
                    _gLib._MsgBoxYesNo("", "Please config your parameter <sFieldType> in function <_IntAcc>");
                    break;
            }

            _gLib._SendKeysUDWin("", this.wRetirementStudio.wIntAcc_grid.grid, "{Tab}{Tab}", 0, ModifierKeys.Shift, false);

        }



        /// <summary>
        /// 2015-Dec-23
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("ValuationNode", "");
        ///    dic.Add("Rate", "");
        ///    pActuarialReport._SensitivityResults(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _SensitivityResults(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRowNum = Convert.ToInt32(dic["iRow"]);
            string sFirstChar = dic["ValuationNode"].Substring(0, 1);
            String sRowKeys = "";


            for (int i = 1; i < iRowNum; i++)
                sRowKeys = sRowKeys + "{Down}";

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wSR_SensitivityResults.grid, "Click", 0, false, 28, 25);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSR_SensitivityResults.grid, "{PageUp}" + sRowKeys, 0);

            if (dic["ValuationNode"] != "")
            {
                for (int i = 1; i <= 20; i++)
                {
                    _gLib._SendKeysUDWin("ValuationNode", this.wRetirementStudio.wSR_SensitivityResults.grid, "{Tab}{Home}{Tab}{space}" + sFirstChar + "{Right}{Left}", 0);

                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wSR_SensitivityResults.grid) == (dic["ValuationNode"]))
                        break;
                }

                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wSR_SensitivityResults.grid) != (dic["ValuationNode"]))
                    _gLib._MsgBoxYesNo("", "there is no item which we wanted, please check it out");
            }

            if (dic["Rate"] != "")
            {
                _gLib._SendKeysUDWin("Rate", this.wRetirementStudio.wSR_SensitivityResults.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{space}", 0);
                _gLib._SendKeysUDWin_byPaste("Rate", this.wRetirementStudio.wSR_Rate_Item.txt, dic["Rate"], 0, false);

            }

        }



        /// <summary>
        /// 2015-Dec-9
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("LongName", "");
        ///    dic.Add("ShortName", "");
        ///    dic.Add("OK", "");
        ///    pActuarialReport._SI_TreeViewAddItem(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _SI_TreeViewAddItem(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int X = this.wRetirementStudio.wTreeView.Tree.Width / 2;
            int Y = this.wRetirementStudio.wTreeView.Tree.Height / 2;

            //    Mouse.Click(this.wRetirementStudio.wFlowTree.flowTree, MouseButtons.Right, ModifierKeys.None, new Point(iPosX, iPosY));

            try
            {
                Mouse.Click(this.wRetirementStudio.wTreeView.Tree, MouseButtons.Right, ModifierKeys.None, new Point(X, Y));
            }
            catch (Exception ex)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to Right Click on Node Flow Tree. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right Click on Node Flow Tree. Because of Exception thrown: " + Environment.NewLine + ex.Message);
            }

            WinWindow wWin = new WinWindow();
            wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "DropDown");
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains);
            wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);


            MyDictionary dicTmp = new MyDictionary();
            dicTmp.Clear();
            dicTmp.Add("Level_1", "Add");
            _gLib._MenuSelectWin(0, wWin, dicTmp);

            _gLib._SetSyncUDWin("FPGrid", this.wAddSubsidiary.wLongName.txt, dic["LongName"], 0);
            _gLib._SetSyncUDWin("FPGrid", this.wAddSubsidiary.wShortName.txt, dic["ShortName"], 0);
            _gLib._SetSyncUDWin("FPGrid", this.wAddSubsidiary.wOK.btn, dic["OK"], 0);


        }



        /// <summary>
        /// 2015-Dec-9
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Level_1", "");
        ///    pActuarialReport._SI_TreeViewSelect(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _SI_TreeViewSelect(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            this.wRetirementStudio.wTreeView.Tree.Item.SearchProperties.Add(WinTreeItem.PropertyNames.Name, dic["Level_1"]);

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wTreeView.Tree.Item, "click", 0);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }




        /// <summary>
        /// 2015-Oct-15 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///   dic.Clear();
        ///   dic.Add("PopVerify", "Pop");
        ///   dic.Add("Copy", "click");
        ///   dic.Add("CopyAStandLayout", "true");
        ///   dic.Add("Template", "");
        ///   dic.Add("OK", "click");
        ///   pActuarialReport._ManageIndividualListingLayouts(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _ManageIndividualListingLayouts(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_DeleteValuationNode";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Copy", this.wRetirementStudio.wRC_Copy.btn, dic["Copy"], 0);
                _gLib._SetSyncUDWin("CopyAStandLayout", this.wCopyIndividualListing.wCopyastandardlayout.rd, dic["CopyAStandLayout"], 0);

                _gLib._SetSyncUDWin("Template", this.wCopyIndividualListing.wTemplateList.grid, dic["Template"], 0, false, 20, 32);
                _gLib._SendKeysUDWin("", this.wCopyIndividualListing.wTemplateList.grid, "{Down}{Down}{PageUp}", 0);

                String sAct = "";

                for (int i = 1; i <= 50; i++)
                {
                    sAct = this._fp._ReturnSelectRowContent(this.wCopyIndividualListing.wTemplateList.grid).Trim();

                    if (sAct == dic["Template"])
                        break;

                    _gLib._SendKeysUDWin("Template", this.wCopyIndividualListing.wTemplateList.grid, "{down}", 0);
                }

                if (sAct != dic["Template"])
                    _gLib._MsgBoxYesNo("", "Never find " + dic["Template"] + ",  Pls check you script");

                _gLib._SetSyncUDWin("OK", this.wCopyIndividualListing.wOK.btn, dic["OK"], 0);
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2015-Oct-15 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///   dic.Clear();
        ///   dic.Add("PopVerify", "Pop");
        ///   dic.Add("iListing", "1");
        ///   pActuarialReport._TemplateandIndividualListing_AddColumn(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TemplateandIndividualListing_AddColumn(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_DeleteValuationNode";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iFrom = this.wRetirementStudio.wRC_ReportDefinitions.grid.Width / 2;
                int iListing = Convert.ToInt32(dic["iListing"]);

                int iTotal = iFrom + 30 * (iListing - 1);

                Mouse.Click(this.wRetirementStudio.wRC_ReportDefinitions.grid, MouseButtons.Right, ModifierKeys.None, new Point(iTotal, 8));

                _gLib._SetSyncUDWin("AddColumn", this.wItem.wContextMenu.wAddColumn, "click", 0);

                //MyDictionary dicTmp = new MyDictionary();
                //dicTmp.Clear();
                //dicTmp.Add("Level_1", "AddColumn");
                //_gLib._MenuSelectWin(0, this.wItem.wContextMenu.wAddColumn, dicTmp);

            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


    }
}
