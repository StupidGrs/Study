namespace RetirementStudio._UIMaps.ParticipantDataSetClasses
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

    using Accessibility;
    using RetirementStudio._ThridParty;
    using System.Threading;
    using System.Windows.Forms;

    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;


    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using RetirementStudio._UIMaps.FarPointClasses;

    public partial class ParticipantDataSet
    {


        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();


        public void _Debugging()
        {
            var a = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);

            var b = 0;

        }


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("DataEffectiveDate", "");
        ///    dic.Add("Snapshot", "");
        ///    dic.Add("DataFile", "");
        ///    dic.Add("GRSUnload", "True");
        ///    dic.Add("GotoDataSystem", "");
        ///    dic.Add("AddField", "");
        ///    dic.Add("GRSInformation", "");
        ///    dic.Add("CompareData", "");
        ///    dic.Add("ImportDataandApplyMapping", "");
        ///    dic.Add("CheckVOImportPopup", "");
        ///    pParticipantDataSet._PopVerify_ParticipantDataSet(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ParticipantDataSet(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ParticipantDataSet";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            bool bCheckVOImportPopup = false;
            if (dic["CheckVOImportPopup"].ToLower().Equals("true"))
                bCheckVOImportPopup = true;

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin_ByClipboard("DataEffectiveDate", this.wRetirementStudio.wDataEffectiveDate.cboDataEffectiveDate.txtDataEffectiveDate, dic["DataEffectiveDate"], 0);
                _gLib._SetSyncUDWin("Snapshot", this.wRetirementStudio.wSnapshot.rdSnapshot, dic["Snapshot"], 0);
                _gLib._SetSyncUDWin("DataFile", this.wRetirementStudio.wDataFile.rd, dic["DataFile"], 0);
                _gLib._SetSyncUDWin("GRSUnload", this.wRetirementStudio.wGRSUnload.rdGRSUnload, dic["GRSUnload"], 0);
                _gLib._SetSyncUDWin("GotoDataSystem", this.wRetirementStudio.wGotoDataSystem.btnGotoDataSystem, dic["GotoDataSystem"], 0);
                _gLib._SetSyncUDWin("AddField", this.wRetirementStudio.wAddField.btnAddField, dic["AddField"], 0);
                _gLib._SetSyncUDWin("GRSInformation", this.wRetirementStudio.wGRSInformation.btnGRSInformation, dic["GRSInformation"], 0);
                _gLib._SetSyncUDWin("CompareData", this.wRetirementStudio.wCompareData.chkCompareData, dic["CompareData"], 0);
                _gLib._SetSyncUDWin("ImportDataandApplyMapping", this.wRetirementStudio.wImportDataandApplyMappings.btnImportDataandApplyMapping, dic["ImportDataandApplyMapping"], 0);
                if (dic["ImportDataandApplyMapping"] != "") // wait for window enabled
                {
                    if (_gLib._Exists("Data Import", this.wDataImport.wYes.btnYes, 3, false))
                        _gLib._SetSyncUDWin("Data Import - Yes", this.wDataImport.wYes.btnYes, "Click", 0);

                    if (bCheckVOImportPopup && _gLib._Exists("Data Import", this.wDataImport.wOK.btn, Config.iTimeout * 5, false))
                        _gLib._SetSyncUDWin("Data Import - OK", this.wDataImport.wOK.btn, "Click", 0);
                    else
                        if (_gLib._Exists("Data Import", this.wDataImport.wOK.btn, 3, false))
                            _gLib._SetSyncUDWin("Data Import - OK", this.wDataImport.wOK.btn, "Click", 0);

                    _gLib._Wait(1);
                    if (_gLib._Exists("Wait For Studio Exists!", this.wRetirementStudio, Config.iTimeout, false))
                    {
                        if (!_gLib._Enabled("Wait For Studio Enable!", this.wRetirementStudio, Config.iTimeout, false))
                            _gLib._Wait(3);
                    }
                }
                _gLib._SetSyncUDWin("ViewMappedData", this.wRetirementStudio.wViewMappedData.btn, dic["ViewMappedData"], 0);
                _gLib._SetSyncUDWin("ExportMappingstoExcel", this.wRetirementStudio.wExportMappingstoExcel.btn, dic["ExportMappingstoExcel"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("DataEffectiveDate", this.wRetirementStudio.wDataEffectiveDate.cboDataEffectiveDate.txtDataEffectiveDate, dic["DataEffectiveDate"], 0);
                _gLib._VerifySyncUDWin("Snapshot", this.wRetirementStudio.wSnapshot.rdSnapshot, dic["Snapshot"], 0);
                _gLib._VerifySyncUDWin("GRSUnload", this.wRetirementStudio.wGRSUnload.rdGRSUnload, dic["GRSUnload"], 0);
                _gLib._VerifySyncUDWin("GotoDataSystem", this.wRetirementStudio.wGotoDataSystem.btnGotoDataSystem, dic["GotoDataSystem"], 0);
                _gLib._VerifySyncUDWin("AddField", this.wRetirementStudio.wAddField.btnAddField, dic["AddField"], 0);
                _gLib._VerifySyncUDWin("GRSInformation", this.wRetirementStudio.wGRSInformation.btnGRSInformation, dic["GRSInformation"], 0);
                _gLib._VerifySyncUDWin("CompareData", this.wRetirementStudio.wCompareData.chkCompareData, dic["CompareData"], 0);
                _gLib._VerifySyncUDWin("ImportDataandApplyMapping", this.wRetirementStudio.wImportDataandApplyMappings.btnImportDataandApplyMapping, dic["ImportDataandApplyMapping"], 0);


            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Apr-12 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("GRSServer", "Deerfield");
        ///    dic.Add("LoginID", "user1");
        ///    dic.Add("Password", "user1");
        ///    dic.Add("OK", "Click");
        ///    pParticipantDataSet._PopVerify_GRSLogin(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GRSLogin(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GRSLogin";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("GRSServer", this.wGRSLogin.wGRSServer.cboGRSServer, dic["GRSServer"], 0);
                _gLib._SetSyncUDWin("LoginID", this.wGRSLogin.wLoginID.txtLoginID, dic["LoginID"], 0);
                //_gLib._SetSyncUDWin("Password", this.wGRSLogin.wPassword.txtPassword, dic["Password"], 0);
                if (dic["Password"] != "")
                    _gLib._SendKeysUDWin("Password", this.wGRSLogin.wPassword.txtPassword, dic["Password"]);
                ////////////Keyboard.SendKeys(this.wGRSLogin.wPassword.txtPassword, dic["Password"]);

                _gLib._SetSyncUDWin("OK", this.wGRSLogin.wOK.btnOK, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("cboGRSServer", this.wGRSLogin.wGRSServer.cboGRSServer, dic["cboGRSServer"], 0);
                _gLib._VerifySyncUDWin("LoginID", this.wGRSLogin.wLoginID.txtLoginID, dic["LoginID"], 0);
                _gLib._VerifySyncUDWin("Password", this.wGRSLogin.wPassword.txtPassword, dic["Password"], 0);
                _gLib._VerifySyncUDWin("OK", this.wGRSLogin.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "GRS Clients");
        ///    dic.Add("Level_2", "L281 - QA US Benchmark 008 Data Source");
        ///    dic.Add("Level_3", "QA US Benchmark 008 Data Plan");
        ///    dic.Add("Level_4", "Data for Retirement Studio");
        ///    dic.Add("Level_5", "Data for 2011 Valuation");
        ///    dic.Add("Level_6", "Unload for 2011 Valuation");
        ///    pParticipantDataSet._GRSDataInput_TreeViewSelect(0, dic);
        /// 
        /// </summary>
        /// <param name="iSearchTimeout"></param>
        /// <param name="dic"></param>
        public void _GRSDataInput_TreeViewSelect(int iSearchTimeout, MyDictionary dic)
        {
            string sFunctionName = "_GRSDataInput_TreeViewSelect";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TreeViewSelectWin(iSearchTimeout, this.wDataInput.tvGRSClient, dic);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Cancel", "");
        ///    pParticipantDataSet._PopVerify_GRSDataInput(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GRSDataInput(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GRSDataInput";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("OK", this.wDataInput.wOK.btnOK, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("OK", this.wDataInput.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pParticipantDataSet._Initialzie();
        /// </summary>
        public void _Initialzie()
        {
            string sFunctionName = "_Initialzie";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iStartX, iStartY, iExpandIcon_X, iExpandIcon_Y, iStepY;
            iStartX = 38;
            iStartY = 1;
            iExpandIcon_X = 18;
            iExpandIcon_Y = 10;
            iStepY = 20;



            for (int i = 1; i <= 8; i++)
            {
                // expand the row
                //////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iExpandIcon_X, (i-1)*iStepY + iExpandIcon_Y));
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iExpandIcon_X, (i - 1) * iStepY + iExpandIcon_Y);


                // activate the sub row
                //////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iExpandIcon_X + 20, i* iStepY + iExpandIcon_Y));
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iExpandIcon_X + 20, i * iStepY + iExpandIcon_Y);

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Right}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Back}{Back}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Back}{Back}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Right}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Back}{Back}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Back}{Back}");

                // collapse the row
                ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iExpandIcon_X, (i - 1) * iStepY + iExpandIcon_Y));
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iExpandIcon_X, (i - 1) * iStepY + iExpandIcon_Y);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Personal Information");
        ///    dic.Add("Level_2", "Service");
        ///    dic.Add("Level_3", "BenService");
        ///    pParticipantDataSet._Initializie_SecondLevel(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Initializie_SecondLevel(MyDictionary dic)
        {
            string sFunctionName = "_Initializie_SecondLevel";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Point collapsePT = new Point();

            collapsePT = this._Navigate(dic, true, true);

            ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, collapsePT);
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, collapsePT.X, collapsePT.Y);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Classification Codes");
        ///    dic.Add("Level_2", "HourlyFlag");
        ///    dic.Add("Level_3", "");
        ///    dic.Add("Level_4", "");
        ///    dic.Add("Data", "ETEST");
        ///    dic.Add("bServiceFirstSubItem", "False");
        ///    dic.Add("bContinueWithoutCollapse", "True");
        ///    pParticipantDataSet._MapField(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Personal Information");
        ///    dic.Add("Level_2", "Service");
        ///    dic.Add("Level_3", "BenService");
        ///    dic.Add("Level_4", "");
        ///    dic.Add("Data", "BENSRV");
        ///    dic.Add("bServiceFirstSubItem", "True");
        ///    dic.Add("bContinueWithoutCollapse", "False");
        ///    pParticipantDataSet._MapField(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _MapField(MyDictionary dic)
        {
            string sFunctionName = "_MapField";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            #region old codes



            ////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(60, 8));


            ////int iStartX, iStartY, iExpandIcon_X, iExpandIcon_Y, iStepY;
            ////iStartX = 38;
            ////iStartY = 1;
            ////iExpandIcon_X = 18;
            ////iExpandIcon_Y = 10;
            ////iStepY = 20;



            ////Boolean bFindLabel = false;
            ////string sActLabel = "";
            ////int iRow_1, iRow_2, iRow_3;
            ////iRow_1 = 0;
            ////iRow_2 = 0;
            ////iRow_3 = 0;

            ////// search Level_1 
            ////for (int i = 1; i < 12; i++)
            ////{
            ////    sActLabel = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
            ////    if (dic["Level_1"] == sActLabel)
            ////    {
            ////        iRow_1 = i;
            ////        bFindLabel = true;
            ////        break;
            ////    }
            ////    else
            ////        Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
            ////}
            ////if (!bFindLabel)
            ////{
            ////    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + ">");
            ////    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + ">");
            ////}

            ////// find Level_1 and expand the category
            ////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iExpandIcon_X, (iRow_1 - 1) * iStepY + iExpandIcon_Y));
            ////// activate the sub row
            ////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iExpandIcon_X + 20, iRow_1 * iStepY + iExpandIcon_Y));


            ////// search Level_2
            ////bFindLabel = false;
            ////for (int i = 1; i < 30; i++)
            ////{
            ////    sActLabel = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
            ////    if (dic["Level_2"] == sActLabel)
            ////    {
            ////        iRow_2 = i;
            ////        bFindLabel = true;
            ////        break;
            ////    }
            ////    else
            ////        Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
            ////}
            ////if (!bFindLabel)
            ////{
            ////    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + " -> " + dic["Level_2"] + ">");
            ////    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + " -> " + dic["Level_2"] + ">");
            ////}

            ////if (dic["Level_3"] == "" && dic["Level_4"] == "")
            ////{
            ////    if (dic["Data"] != "")
            ////    {
            ////        Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Right}{Back}");
            ////        _gLib._SetSyncUDWin(dic["Data"], this.wRetirementStudio.wMapComboBox.cbo, dic["Data"], 0);
            ////        Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}");
            ////        Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{PageUp}");
            ////    }
            ////    // collapse the category
            ////    Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iExpandIcon_X, (iRow_1 - 1) * iStepY + iExpandIcon_Y));

            ////}


            #endregion

            MyDictionary dicTmp = new MyDictionary();

            Point collapsePT = new Point();

            dicTmp.Clear();
            dicTmp.Add("Level_1", dic["Level_1"]);
            dicTmp.Add("Level_2", dic["Level_2"]);
            dicTmp.Add("Level_3", dic["Level_3"]);
            dicTmp.Add("Level_4", dic["Level_4"]);
            if (dic["bServiceFirstSubItem"].ToUpper() == "TRUE" && dic["bContinueWithoutCollapse"].ToUpper() == "TRUE")
                collapsePT = this._Navigate(dicTmp, false, false, true, true);
            else if (dic["bServiceFirstSubItem"].ToUpper() != "TRUE" && dic["bContinueWithoutCollapse"].ToUpper() == "TRUE")
                collapsePT = this._Navigate(dicTmp, false, false, false, true);
            else if (dic["bServiceFirstSubItem"].ToUpper() == "TRUE" && dic["bContinueWithoutCollapse"].ToUpper() != "TRUE")
                collapsePT = this._Navigate(dicTmp, false, false, true, false);
            else
                collapsePT = this._Navigate(dicTmp, false);


            string sChar = dic["Data"].Substring(0, 1);

            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Right}" + sChar);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Right}" + sChar);
            _gLib._SetSyncUDWin(dic["Data"], this.wRetirementStudio.wMapComboBox.cbo, dic["Data"], 0);

            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}");
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Home}");

            if (dic["bContinueWithoutCollapse"].ToUpper() != "TRUE")
            {
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{PageUp}");
                ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, collapsePT);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{PageUp}");
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, collapsePT.X, collapsePT.Y);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Classification Codes");
        ///    dic.Add("Level_2", "HourlyFlag");
        ///    dic.Add("bIsIncludeInReport_Disabled", "");
        ///    dic.Add("bIncludeInReport", "");
        ///    dic.Add("sComparisonType", "");
        ///    dic.Add("bALL", "");
        ///    dic.Add("bACT", "");
        ///    dic.Add("bDEF", "");
        ///    dic.Add("bPEN", "");
        ///    dic.Add("bServiceFirstSubItem", "False");
        ///    dic.Add("bContinueWithoutCollapse", "True");
        ///    pParticipantDataSet._SetFieldProperty(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _SetFieldProperty(MyDictionary dic)
        {
            string sFunctionName = "_SetFieldProperty";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sAct = "";
            string sKey = "";
            string sFieldFullPath = "";

            // count the right key number for each column 
            int iIsIncludeInReport_Disabled = 0;
            if (dic["bIsIncludeInReport_Disabled"].ToUpper() == "TRUE")
                iIsIncludeInReport_Disabled = 1;

            int iRightNum_IncludedInReport = 3;
            int iRightNum_ComparisonType = 4 - iIsIncludeInReport_Disabled;
            int iRightNum_All = 7 - iIsIncludeInReport_Disabled;
            int iRightNum_ACT = 8 - iIsIncludeInReport_Disabled;
            int iRightNum_DEF = 9 - iIsIncludeInReport_Disabled;
            int iRightNum_PEN = 10 - iIsIncludeInReport_Disabled;


            Point collapsePT = new Point();

            // navigate to the expected field
            MyDictionary dicTmp = new MyDictionary();
            dicTmp.Clear();
            for (int i = 1; i <= dic.Count + 1 - 7; i++)
            {
                dicTmp.Add("Level_" + i.ToString(), dic["Level_" + i.ToString()]);
                sFieldFullPath = sFieldFullPath + dic["Level_" + i.ToString()] + " - ";
            }

            if (dic["bServiceFirstSubItem"].ToUpper() == "TRUE" && dic["bContinueWithoutCollapse"].ToUpper() == "TRUE")
                collapsePT = this._Navigate(dicTmp, false, false, true, true);
            else if (dic["bServiceFirstSubItem"].ToUpper() != "TRUE" && dic["bContinueWithoutCollapse"].ToUpper() == "TRUE")
                collapsePT = this._Navigate(dicTmp, false, false, false, true);
            else if (dic["bServiceFirstSubItem"].ToUpper() == "TRUE" && dic["bContinueWithoutCollapse"].ToUpper() != "TRUE")
                collapsePT = this._Navigate(dicTmp, false, false, true, false);
            else
                collapsePT = this._Navigate(dicTmp, false);


            if (dic["bIncludeInReport"].ToUpper() == "TRUE" && dic["bIsIncludeInReport_Disabled"].ToUpper() == "FALSE")
            {
                sKey = "";
                for (int i = 0; i < iRightNum_IncludedInReport; i++)
                    sKey = sKey + "{Right}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKey);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sKey);

                sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);

                if (sAct.ToUpper() != dic["bIncludeInReport"].ToUpper())
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Space}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKey);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Space}{Home}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sKey);

                    sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                    if (sAct.ToUpper() != dic["bIncludeInReport"].ToUpper())
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set Value: <" + dic["bIncludeInReport"] + "> to field <" + sFieldFullPath + ">. Actual Value: <" + sAct + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set Value: <" + dic["bIncludeInReport"] + "> to field <" + sFieldFullPath + ">. Actual Value: <" + sAct + ">");
                    }
                }

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Home}");
            }

            if (dic["sComparisonType"].ToUpper() != "")
            {
                sKey = "";
                for (int i = 0; i < iRightNum_ComparisonType; i++)
                    sKey = sKey + "{Right}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKey);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sKey);

                string sChar = dic["sComparisonType"].Substring(0, 1);

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sChar);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sChar);
                _gLib._SetSyncUDWin(dic["sComparisonType"], this.wRetirementStudio.wMapComboBox.cbo, dic["sComparisonType"], 0);

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Home}");


            }
            if (dic["bALL"].ToUpper() != "")
            {
                sKey = "";
                for (int i = 0; i < iRightNum_All; i++)
                    sKey = sKey + "{Right}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKey);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sKey);

                sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                if (sAct.ToUpper() != dic["bALL"].ToUpper())
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Space}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKey);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Space}{Home}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sKey);

                    sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                    if (sAct.ToUpper() != dic["bALL"].ToUpper())
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set Value: <" + dic["bALL"] + "> to field <" + sFieldFullPath + ">. Actual Value: <" + sAct + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set Value: <" + dic["bALL"] + "> to field <" + sFieldFullPath + ">. Actual Value: <" + sAct + ">");
                    }
                }

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Home}");
            }

            if (dic["bACT"].ToUpper() != "")
            {
                sKey = "";
                for (int i = 0; i < iRightNum_ACT; i++)
                    sKey = sKey + "{Right}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKey);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sKey);

                sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                if (sAct.ToUpper() != dic["bACT"].ToUpper())
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Space}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKey);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Space}{Home}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sKey);

                    sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                    if (sAct.ToUpper() != dic["bACT"].ToUpper())
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set Value: <" + dic["bACT"] + "> to field <" + sFieldFullPath + ">. Actual Value: <" + sAct + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set Value: <" + dic["bACT"] + "> to field <" + sFieldFullPath + ">. Actual Value: <" + sAct + ">");
                    }
                }

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Home}");
            }


            if (dic["bDEF"].ToUpper() != "")
            {
                sKey = "";
                for (int i = 0; i < iRightNum_DEF; i++)
                    sKey = sKey + "{Right}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKey);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sKey);

                sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                if (sAct.ToUpper() != dic["bDEF"].ToUpper())
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Space}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKey);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Space}{Home}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sKey);

                    sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                    if (sAct.ToUpper() != dic["bDEF"].ToUpper())
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set Value: <" + dic["bDEF"] + "> to field <" + sFieldFullPath + ">. Actual Value: <" + sAct + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set Value: <" + dic["bDEF"] + "> to field <" + sFieldFullPath + ">. Actual Value: <" + sAct + ">");
                    }
                }

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Home}");
            }

            if (dic["bPEN"].ToUpper() != "")
            {
                sKey = "";
                for (int i = 0; i < iRightNum_PEN; i++)
                    sKey = sKey + "{Right}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKey);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sKey);

                sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                if (sAct.ToUpper() != dic["bPEN"].ToUpper())
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Space}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKey);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Space}{Home}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sKey);

                    sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                    if (sAct.ToUpper() != dic["bPEN"].ToUpper())
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set Value: <" + dic["bPEN"] + "> to field <" + sFieldFullPath + ">. Actual Value: <" + sAct + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set Value: <" + dic["bPEN"] + "> to field <" + sFieldFullPath + ">. Actual Value: <" + sAct + ">");
                    }
                }

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Home}");
            }


            if (dic["bContinueWithoutCollapse"].ToUpper() != "TRUE")
            {
                ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, collapsePT);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, collapsePT.X, collapsePT.Y);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-19
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Personal Information");
        ///    dic.Add("Level_2", "Service");
        ///    dic.Add("Level_3", "VestService");
        ///    pParticipantDataSet._Navigate(dic, true, true); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Personal Information");
        ///    dic.Add("Level_2", "Service");
        ///    dic.Add("Level_3", "Salary");
        ///    dic.Add("Level_4", "SalaryCurrentYear");
        ///    pParticipantDataSet._Navigate(dic, false, false); 
        /// </summary>
        /// <param name="dic"></param>
        /// 
        public Point _Navigate(MyDictionary dic, Boolean bExpand)
        {
            return this._Navigate(dic, bExpand, false);
        }

        /// <summary>
        /// 2013-May-19
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Personal Information");
        ///    dic.Add("Level_2", "Service");
        ///    dic.Add("Level_3", "VestService");
        ///    pParticipantDataSet._Navigate(dic, true, true); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Personal Information");
        ///    dic.Add("Level_2", "Service");
        ///    dic.Add("Level_3", "Salary");
        ///    dic.Add("Level_4", "SalaryCurrentYear");
        ///    pParticipantDataSet._Navigate(dic, false, false); 
        /// </summary>
        /// <param name="dic"></param>
        public Point _Navigate(MyDictionary dic, Boolean bExpand, Boolean bInitialize)
        {
            return this._Navigate(dic, bExpand, bInitialize, false, false);
        }


        /// <summary>
        /// 2013-May-28
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Personal Information");
        ///    dic.Add("Level_2", "Service");
        ///    dic.Add("Level_3", "VestService");
        ///    pParticipantDataSet._Navigate(dic, true, true, true, true); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Personal Information");
        ///    dic.Add("Level_2", "Service");
        ///    dic.Add("Level_3", "Salary");
        ///    dic.Add("Level_4", "SalaryCurrentYear");
        ///    dic.Add("ReturnPosLevel", "2");
        ///    pParticipantDataSet._Navigate(dic, false, false, false, true); 
        /// </summary>
        /// <param name="dic"></param>
        public Point _Navigate(MyDictionary dic, Boolean bExpand, Boolean bInitialize, Boolean bServiceFirstSubItem, Boolean bContinueWithoutCollapse)
        {

            string sFunctionName = "_Navigate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Point collapsePoint = new Point();
            Point returnPoint = new Point();
            Boolean bFindLabel = false;
            string sActLabel = "";
            int iRow_1, iRow_2, iRow_3;
            iRow_1 = 0;
            iRow_2 = 0;
            iRow_3 = 0;

            int iStartX, iStartY, iExpandIcon_X, iExpandIcon_Y, iStepY, iExpandIcon_X2, iExpandIcon_X3;
            iStartX = 38;
            iStartY = 1;
            iExpandIcon_X = 18;
            iExpandIcon_Y = 10;
            iStepY = 20;

            iExpandIcon_X2 = 53;
            iExpandIcon_X3 = 88;

            if (bContinueWithoutCollapse) // this only support Pay history fields in Personal Information
            {
                collapsePoint.X = iExpandIcon_X;
                collapsePoint.Y = iExpandIcon_Y;

                // search next Level_2 , Level_3 and Level_4
                for (int i = 1; i < 16; i++)
                {
                    //////sActLabel = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);

                    Clipboard.Clear();
                    _gLib._SendKeysUDWin("wFPGrid", this.wRetirementStudio.wFPGrid.grid, "C", 0, ModifierKeys.Control, false);
                    sActLabel = Clipboard.GetText();

                    sActLabel = sActLabel.TrimEnd();

                    ////if (dic["Level_2"] == sActLabel || dic["Level_3"] == sActLabel || dic["Level_4"] == sActLabel)
                    if (sActLabel.Equals(dic["Level_2"]) || sActLabel.Equals(dic["Level_3"]) || sActLabel.Equals(dic["Level_4"]))
                    {
                        bFindLabel = true;
                        break;
                    }
                    else if (sActLabel.Contains(dic["Level_2"]) && dic["Level_3"].ToString().Equals(""))
                    {
                        bFindLabel = true;
                        break;
                    }
                    else if (dic["Level_2"].ToUpper() == "SERVICE" && bServiceFirstSubItem)
                    {
                        bFindLabel = true;
                        break;
                    }
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                }
                if (!bFindLabel)
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + " -> " + dic["Level_2"] + " -> " + dic["Level3"] + " -> " + dic["Level_4"] + ">");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + " -> " + dic["Level_2"] + " -> " + dic["Level3"] + " -> " + dic["Level_4"] + ">");
                }


            }
            else
            {

                ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(60, 8));
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 60, 8);
                //collapsePoint.X = iExpandIcon_X;
                //collapsePoint.Y = iExpandIcon_Y;

                _gLib._Wait(1);
                ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iExpandIcon_X + 60, iStepY + iExpandIcon_Y));
                ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(60, 8));
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iExpandIcon_X + 60, iStepY + iExpandIcon_Y);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 60, 8);

                if (dic["Level_1"] != "")
                {

                    // search Level_1 
                    for (int i = 1; i < 12; i++)
                    {
                        sActLabel = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                        if (dic["Level_1"] == sActLabel)
                        {
                            iRow_1 = i;
                            bFindLabel = true;
                            break;
                        }
                        else
                            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                        ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                    }
                    if (!bFindLabel)
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + ">");
                    }
                    else
                    {
                        collapsePoint.X = iExpandIcon_X;
                        collapsePoint.Y = (iRow_1 - 1) * iStepY + iExpandIcon_Y;

                        // always retrun the top level collapse position, because sub category not supposed to be collapsed
                        returnPoint.X = collapsePoint.X;
                        returnPoint.Y = collapsePoint.Y;

                        // found Level_1 and expand the category
                        // top category always need expand
                        ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, collapsePoint);
                        _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, collapsePoint.X, collapsePoint.Y);
                    }
                }

                bFindLabel = false;
                if (dic["Level_2"] != "")
                {
                    // activate the sub row
                    ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iExpandIcon_X + 20, iRow_1 * iStepY + iExpandIcon_Y));
                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iExpandIcon_X + 20, iRow_1 * iStepY + iExpandIcon_Y);

                    // search Level_2 
                    for (int i = 1; i < 30; i++)
                    {
                        sActLabel = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                        if (dic["Level_2"] == sActLabel)
                        {
                            iRow_2 = i;
                            bFindLabel = true;
                            break;
                        }
                        else
                            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                        ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                    }
                    if (!bFindLabel)
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + " -> " + dic["Level_2"] + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + " -> " + dic["Level_2"] + ">");
                    }
                    else
                    {
                        if (dic["Level_3"] != "")
                        {
                            collapsePoint.X = iExpandIcon_X2;
                            collapsePoint.Y = (iRow_1 - 1 + iRow_2) * iStepY + iExpandIcon_Y;

                            if (dic["ReturnPosLevel"] == "2")
                            {
                                returnPoint.X = collapsePoint.X;
                                returnPoint.Y = collapsePoint.Y;
                            }

                            // found Level_2 and expand the category
                            if (bExpand)
                                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, collapsePoint.X, collapsePoint.Y);
                            ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, collapsePoint);
                            // activate the sub row
                            ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iExpandIcon_X + 90, (iRow_1 + iRow_2) * iStepY + iExpandIcon_Y));
                            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iExpandIcon_X + 90, (iRow_1 + iRow_2) * iStepY + iExpandIcon_Y);

                            // initilize Level_3 by activating the combobox, otherwise, QTP not able to recoginize any item in this level
                            //////////////////////////////////////////////////////////////
                            if (bInitialize)
                            {
                                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Right}");
                                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Back}{Back}");
                                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Back}{Back}");
                                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Tab}{Home}");
                                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Up}");

                                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Right}");
                                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Back}{Back}");
                                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Back}{Back}");
                                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Tab}{Home}");
                                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Up}");

                            }
                            //////////////////////////////////////////////////////////////

                            // search Level_3 
                            bFindLabel = false;


                            for (int i = 1; i < 20; i++)
                            {


                                ////////////sActLabel = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                                /////////// this is special because sub item under Pay can not be recoginized, it just shows its parent "Pay" string
                                //////if (dic["Level_2"].ToUpper().Contains("PAY") && dic["Level_2"] == sActLabel)
                                //////{
                                //////    iRow_3 = i;
                                //////    bFindLabel = true;
                                //////    break;
                                //////}
                                //////else if (dic["Level_2"].ToUpper() == "SERVICE" && bServiceFirstSubItem)
                                //////{
                                //////    iRow_3 = i;
                                //////    bFindLabel = true;
                                //////    break;
                                //////}
                                //////else if (dic["Level_3"] == sActLabel)
                                //////{
                                //////    iRow_3 = i;
                                //////    bFindLabel = true;
                                //////    break;
                                //////}
                                //////else
                                //////    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");

                                sActLabel = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wFPGrid.grid);

                                try
                                {
                                    sActLabel = sActLabel.Substring(0, dic["Level_3"].Length + 2);
                                }
                                catch (Exception ex) { }


                                if (sActLabel.Contains(dic["Level_3"]))
                                {
                                    iRow_3 = i;
                                    bFindLabel = true;
                                    break;
                                }
                                else
                                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                            }
                            if (!bFindLabel)
                            {
                                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + " -> " + dic["Level_2"] + " -> " + dic["Level_3"] + ">");
                                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + " -> " + dic["Level_2"] + " -> " + dic["Level_3"] + ">");
                            }
                            else
                            {
                                if (dic["Level_4"] != "")
                                {
                                    collapsePoint.X = iExpandIcon_X3;
                                    collapsePoint.Y = (iRow_1 - 1 + iRow_2 + iRow_3) * iStepY + iExpandIcon_Y;

                                    // found Level_3 and expand the category
                                    if (bExpand)
                                        _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, collapsePoint.X, collapsePoint.Y);
                                    ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, collapsePoint);
                                    // activate the sub row

                                    ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iExpandIcon_X + 130, (iRow_1 + iRow_2 + iRow_3) * iStepY + iExpandIcon_Y));
                                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iExpandIcon_X + 130, (iRow_1 + iRow_2 + iRow_3) * iStepY + iExpandIcon_Y);

                                    // search Level_4 
                                    for (int i = 1; i < 30; i++)
                                    {
                                        Clipboard.Clear();
                                        _gLib._SendKeysUDWin("wFPGrid", this.wRetirementStudio.wFPGrid.grid, "C", 0, ModifierKeys.Control, false);
                                        sActLabel = Clipboard.GetText();
                                        ///sActLabel = _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);
                                        ///if (dic["Level_4"] == sActLabel)
                                        if (sActLabel.Contains(dic["Level_4"]))
                                        {
                                            bFindLabel = true;
                                            break;
                                        }
                                        else
                                            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                                        ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                                    }
                                    if (!bFindLabel)
                                    {
                                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + " -> " + dic["Level_2"] + " -> " + dic["Level3"] + " -> " + dic["Level_4"] + ">");
                                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  find label<" + dic["Level_1"] + " -> " + dic["Level_2"] + " -> " + dic["Level3"] + " -> " + dic["Level_4"] + ">");
                                    }

                                }



                            }


                        }

                    }

                }


            }






            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

            return returnPoint;

        }


        public void _ExpandOrCollapseFirstLevel(string sCategory)
        {
            string sFunctionName = "_ExpandOrCollapseFirstLevel";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iExpandIcon_X = 18;
            int iExpandIcon_Y = 10;
            int iStepY = 20;
            int iRow = 0;

            switch (sCategory)
            {
                case "Personal Information":
                    iRow = 1;
                    break;
                case "Beneficiary Information":
                    iRow = 2;
                    break;
                case "DB Information":
                    iRow = 3;
                    break;
                case "Classification Codes":
                    iRow = 4;
                    break;
                case "Custom Fields":
                    iRow = 5;
                    break;
                case "DC Information":
                    iRow = 6;
                    break;
                case "Accounting Results":
                    iRow = 7;
                    break;
                case "Funding Results":
                    iRow = 8;
                    break;
                default:
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail: Invalid Category Name: <" + sCategory + ">. Please Verify!");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail: Invalid Category Name: <" + sCategory + ">. Please Verify!");
                        break;
                    }
            }

            _gLib._SetSyncUDWin("Expand or collapse Category <" + sCategory + ">", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iExpandIcon_X, (iRow - 1) * iStepY + iExpandIcon_Y);
            //Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iExpandIcon_X, (iRow - 1) * iStepY + iExpandIcon_Y));

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");
        }



        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "DB Information");
        ///    dic.Add("Level_2", "Service");
        ///    dic.Add("FieldName", "BenefitInPayment");
        ///    dic.Add("HistoryFields", "");
        ///    pParticipantDataSet._ts_AddField(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _ts_AddField(MyDictionary dic)
        {
            string sFunctionName = "_ts_AddField";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Point collapsePt = new Point();

            MyDictionary dicTmp = new MyDictionary();

            if (dic["Level_2"] == "")
            {
                dicTmp.Clear();
                dicTmp.Add("Level_1", dic["Level_1"]);
                collapsePt = this._Navigate(dicTmp, false);
            }
            else
            {
                dicTmp.Clear();
                dicTmp.Add("Level_1", dic["Level_1"]);
                dicTmp.Add("Level_2", dic["Level_2"]);
                collapsePt = this._Navigate(dicTmp, true);
            }

            dicTmp.Clear();
            dicTmp.Add("PopVerify", "Pop");
            dicTmp.Add("AddField", "Click");
            dicTmp.Add("GRSInformation", "");
            this._PopVerify_ParticipantDataSet(dicTmp);

            dicTmp.Clear();
            dicTmp.Add("PopVerify", "Pop");
            dicTmp.Add("FieldName", dic["FieldName"]);
            dicTmp.Add("OK", "Click");
            this._PopVerify_AddField(dicTmp);

            if (dic["HistoryFields"] != "")
            {
                dicTmp.Clear();
                dicTmp.Add("PopVerify", "Pop");
                dicTmp.Add("HistoryFields", dic["HistoryFields"]);
                dicTmp.Add("OK", "Click");
                this._PopVerify_AddHistory(dicTmp);
            }


            // collapse the 
            ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, collapsePt);
            _gLib._SetSyncUDWin("", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, collapsePt.X, collapsePt.Y);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-11
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FieldName", "BenefitInPayment");
        ///    dic.Add("OK", "Click");
        ///    pParticipantDataSet._PopVerify_AddField(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_AddField(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_AddField";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("FieldName", this.wAddField.wFieldName.txtFieldName, dic["FieldName"], 0);
                _gLib._SetSyncUDWin("OK", this.wAddField.wOK.btnOK, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("FieldName", this.wAddField.wFieldName.txtFieldName, dic["FieldName"], 0);
                _gLib._VerifySyncUDWin("OK", this.wAddField.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("HistoryFields", "10");
        ///    dic.Add("OK", "Click");
        ///    pParticipantDataSet._PopVerify_AddHistory(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_AddHistory(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_AddHistory";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin_ByClipboard("HistoryFields", this.wAddHistory.wHistoryFields.txtHistoryFields, dic["HistoryFields"], 0);
                _gLib._SetSyncUDWin("OK", this.wAddHistory.wOK.btnOK, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("HistoryFields", this.wAddHistory.wHistoryFields.txtHistoryFields, dic["HistoryFields"], 0);
                _gLib._VerifySyncUDWin("OK", this.wAddHistory.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-Dec-130
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Personal Information");
        ///    dic.Add("Level_2", "Pay");
        ///    dic.Add("Level_3", "PayVector");
        ///    dic.Add("HistoryFields", "");
        ///    pParticipantDataSet._ts_AddHistory(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _ts_AddHistory(MyDictionary dic)
        {
            string sFunctionName = "_ts_AddHistory";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Point collapsePt = new Point();

            MyDictionary dicTmp = new MyDictionary();


            dicTmp.Clear();
            dicTmp.Add("Level_1", dic["Level_1"]);
            dicTmp.Add("Level_2", dic["Level_2"]);
            dicTmp.Add("Level_3", dic["Level_3"]);
            collapsePt = this._Navigate(dicTmp, true);


            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Right}{Space}");
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Right}{Space}");

            dicTmp.Clear();
            dicTmp.Add("PopVerify", "Pop");
            dicTmp.Add("HistoryFields", dic["HistoryFields"]);
            dicTmp.Add("OK", "Click");
            this._PopVerify_AddHistory(dicTmp);


            // collapse the 
            ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, collapsePt);
            _gLib._SetSyncUDWin("", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, collapsePt.X, collapsePt.Y);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Client", "L281 - QA US Benchmark 008 Data Source");
        ///    dic.Add("OK", "Click");
        ///    pParticipantDataSet._PopVerify_GRSClientForTableImport(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GRSClientForTableImport(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GRSClientForTableImport";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin(dic["Client"], this.wGRSClientforTableImport.wClients, dic["Client"], 100);
                _gLib._SetSyncUDWin("OK", this.wGRSClientforTableImport.wOK.btnOK, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wGRSClientforTableImport.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SelectAll", "Click");
        ///    dic.Add("Import", "Click");
        ///    dic.Add("NumOfTablesImported", "6");
        ///    pParticipantDataSet._PopVerify_SourceTable(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SourceTable(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_SourceTable";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("SelectAll", this.wSourceTable.wSelectAll.btnSelectAll, dic["SelectAll"], 100);
                _gLib._SetSyncUDWin("Import", this.wSourceTable.wImport.btnImport, dic["Import"], 0);
                if (dic["Import"] != "")
                {
                    if (dic["NumOfTablesImported"] != "")
                        _gLib._VerifySyncUDWin("ImportMessage", this.wSourceTable_Popup_Msg.txtMsg, dic["NumOfTablesImported"] + " table(s) have been imported.", Config.iTimeout * 2);
                    _gLib._SetSyncUDWin("OK", this.wSourceTable_Popup_OK.btnOK, "Click", Config.iTimeout * 2);
                }

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("SelectAll", this.wSourceTable.wSelectAll.btnSelectAll, dic["SelectAll"], 0);
                _gLib._VerifySyncUDWin("Import", this.wSourceTable.wImport.btnImport, dic["Import"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-20 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SnapshotName", "Valuation Data");
        ///    dic.Add("SnapshotName_Parent", "Data_2012");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("RetainThePreviousUnload", "");
        ///    dic.Add("SpecifyANewSnapshotRetainingPrevious", "");
        ///    dic.Add("SpecifyANewSnapshotRevertingAllFields", "");
        ///    dic.Add("SpecifyANewUnload", "");
        ///    dic.Add("SelectSnapshotOption_OK", "Click");
        ///    pParticipantDataSet._PopVerify_SelectSnapshotDefinition(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SelectSnapshotDefinition(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_SelectSnapshotDefinition";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            if (dic["PopVerify"] == "Pop")
            {
                if (dic["SnapshotName_Parent"] != "")
                {
                    UITestControlCollection uc = ((WinList)this.wSelectSnapshotDefinition.wSnapshotList.listSnapshot).Items;
                    for (int i = 0; i < uc.Count; i++)
                    {
                        ///////////////////////////_gLib._MsgBox(((WinListItem)uc[i]).HelpText, "");
                        try
                        {
                            if (((WinListItem)uc[i]).HelpText.ToString().Equals(dic["SnapshotName_Parent"]) && ((WinListItem)uc[i]).Name.ToString().Equals(dic["SnapshotName"]))
                            {
                                _gLib._SetSyncUDWin(dic["SnapshotName"], (WinListItem)uc[i], "Click", 0);
                                break;
                            }

                        }
                        catch (Exception ex)
                        {
                            // do nothing
                        }
                    }
                }
                else
                    _gLib._SetSyncUDWin(dic["SnapshotName"], this.wSelectSnapshotDefinition.wSnapshotList.listSnapshot, dic["SnapshotName"], 0);

                _gLib._SetSyncUDWin("OK", this.wSelectSnapshotDefinition.wOK.btnOK, dic["OK"], 0);


                //////////////////// priorr 6.8 codes
                //_gLib._SetSyncUDWin("RetainThePreviousUnload", this.wSelectSnapshotDefinition.wRetainThePreviousUnload.rdRetainThePreviousUnload, dic["RetainThePreviousUnload"], 0);
                //_gLib._SetSyncUDWin("SpecifyANewSnapshotRetainingPrevious", this.wSelectSnapshotDefinition.wSpecifyANewSnapshotRetainingPrevious.rdSpecifyANewSnapshotRetainingPrevious, dic["SpecifyANewSnapshotRetainingPrevious"], 0);
                //_gLib._SetSyncUDWin("SpecifyANewSnapshotRevertingAllFields", this.wSelectSnapshotDefinition.wSpecifyANewSnapshotRevertingAllFields.rdSpecifyANewSnapshotRevertingAllFields, dic["SpecifyANewSnapshotRevertingAllFields"], 0);
                //_gLib._SetSyncUDWin("SpecifyANewUnload", this.wSelectSnapshotDefinition.wSpecifyANewUnload.rdSpecifyANewUnload, dic["SpecifyANewUnload"], 0);
                //_gLib._SetSyncUDWin("SelectSnapshotOption_OK", this.wSelectSnapshotDefinition.wSelectSnapshotOption_OK.btnSelectSnapshotOption_OK, dic["SelectSnapshotOption_OK"], 0);
                ///////////////////



                if (dic["RetainThePreviousUnload"].ToLower().Equals("true") || dic["SpecifyANewUnload"].ToLower().Equals("true"))
                    _gLib._MsgBoxYesNo("Error", "<#1 - RetainThePreviousUnload> and <#4 - SpecifyANewUnload> are no longer available for Data snapshot import, please contact Webber for more info!");

                if (dic["SpecifyANewSnapshotRetainingPrevious"].ToLower().Equals("true"))
                    _gLib._SetSyncUDWin("KeepFieldMappings", this.wImportSnapshot.wKeepFieldMappings.rd, "True", 0);
                if (dic["SpecifyANewSnapshotRevertingAllFields"].ToLower().Equals("true"))
                    _gLib._SetSyncUDWin("DiscardFieldMappingsRevertDefaults", this.wImportSnapshot.wDiscardFieldMappingsRevertDefaults.rd, "True", 0);

                if (dic["SelectSnapshotOption_OK"].ToLower().Equals("click"))
                    _gLib._SetSyncUDWin("ImportSnapshot_OK", this.wImportSnapshot.wOK.btn, "Click", 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin(dic["SnapshotName"], this.wSelectSnapshotDefinition.wSnapshotList.listSnapshot, dic["SnapshotName"], 0);
                _gLib._VerifySyncUDWin("OK", this.wSelectSnapshotDefinition.wOK.btnOK, dic["OK"], 0);
                //////////_gLib._VerifySyncUDWin("RetainThePreviousUnload", this.wSelectSnapshotDefinition.wRetainThePreviousUnload.rdRetainThePreviousUnload, dic["RetainThePreviousUnload"], 0);
                //////////_gLib._VerifySyncUDWin("SpecifyANewSnapshotRetainingPrevious", this.wSelectSnapshotDefinition.wSpecifyANewSnapshotRetainingPrevious.rdSpecifyANewSnapshotRetainingPrevious, dic["SpecifyANewSnapshotRetainingPrevious"], 0);
                //////////_gLib._VerifySyncUDWin("SpecifyANewSnapshotRevertingAllFields", this.wSelectSnapshotDefinition.wSpecifyANewSnapshotRevertingAllFields.rdSpecifyANewSnapshotRevertingAllFields, dic["SpecifyANewSnapshotRevertingAllFields"], 0);
                //////////_gLib._VerifySyncUDWin("SpecifyANewUnload", this.wSelectSnapshotDefinition.wSpecifyANewUnload.rdSpecifyANewUnload, dic["SpecifyANewUnload"], 0);
                //////////_gLib._VerifySyncUDWin("SelectSnapshotOption_OK", this.wSelectSnapshotDefinition.wSelectSnapshotOption_OK.btnSelectSnapshotOption_OK, dic["SelectSnapshotOption_OK"], 0);


            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }






        /// <summary>
        /// 2015-Dec-28 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("KeepMapingField", "");
        ///    dic.Add("OK", "Click");
        ///    pParticipantDataSet._PopVerify_ImportDataFile_keepMapingField(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ImportDataFile_keepMapingField(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ImportDataFile_keepMapingField";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("KeepMapingField", this.wImportDataFile.wKeepfieldmappings.rd, dic["KeepMapingField"], 0);
                _gLib._SetSyncUDWin("OK", this.wImportDataFile.wOK.btn, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("KeepMapingField", this.wImportDataFile.wKeepfieldmappings.rd, dic["KeepMapingField"], 0);
                _gLib._VerifySyncUDWin("OK", this.wImportGRSUnload.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2015-Dec-28 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("KeepFieldMappingsDefinedButDiscardExistingData", "");
        ///    dic.Add("DiscardFieldMappingsAndDiscardExistingData", "");
        ///    dic.Add("KeepFieldMappingsAndAppendToExistingData", "");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Cancel", "");
        ///    pParticipantDataSet._PopVerify_ImportGRSUnload(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ImportGRSUnload(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ImportGRSUnload";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("KeepFieldMappingsDefinedButDiscardExistingData", this.wImportGRSUnload.wKeepFieldMappingsDefinedButDiscardExistingData.rd, dic["KeepFieldMappingsDefinedButDiscardExistingData"], 0);
                _gLib._SetSyncUDWin("DiscardFieldMappingsAndDiscardExistingData", this.wImportGRSUnload.wDiscardFieldMappingsAndDiscardExistingData.rd, dic["DiscardFieldMappingsAndDiscardExistingData"], 0);
                _gLib._SetSyncUDWin("KeepFieldMappingsAndAppendToExistingData", this.wImportGRSUnload.wKeepFieldMappingsAndAppendToExistingData.rd, dic["KeepFieldMappingsAndAppendToExistingData"], 0);
                _gLib._SetSyncUDWin("OK", this.wImportGRSUnload.wOK.btn, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wImportGRSUnload.wCancel.btn, dic["Cancel"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("KeepFieldMappingsDefinedButDiscardExistingData", this.wImportGRSUnload.wKeepFieldMappingsDefinedButDiscardExistingData.rd, dic["KeepFieldMappingsDefinedButDiscardExistingData"], 0);
                _gLib._VerifySyncUDWin("DiscardFieldMappingsAndDiscardExistingData", this.wImportGRSUnload.wDiscardFieldMappingsAndDiscardExistingData.rd, dic["DiscardFieldMappingsAndDiscardExistingData"], 0);
                _gLib._VerifySyncUDWin("KeepFieldMappingsAndAppendToExistingData", this.wImportGRSUnload.wKeepFieldMappingsAndAppendToExistingData.rd, dic["KeepFieldMappingsAndAppendToExistingData"], 0);
                _gLib._VerifySyncUDWin("OK", this.wImportGRSUnload.wOK.btn, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wImportGRSUnload.wCancel.btn, dic["Cancel"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pParticipantDataSet._PopVerify_AssetSnapshot(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_AssetSnapshot(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_AssetSnapshot";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wAssetSnapshot.wOK.btnOK, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("OK", this.wAssetSnapshot.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        private void _GRSInformation_Grid(WinWindow objParent, WinClient obj, string sRow, int iCol, string sData)
        {
            string sFunctionName = "_GRSInformation_Grid";

            string sKeys = "";

            try
            {
                for (int i = 0; i < iCol; i++)
                    sKeys = sKeys + "{Tab}";
                ////////////Keyboard.SendKeys(obj, sKeys, ModifierKeys.None);
                _gLib._SendKeysUDWin("FPGrid", obj, sKeys);


                WinWindow wEditWin = new WinWindow(objParent);
                wEditWin.SearchProperties.Add("ClassName", "WindowsForms10.EDIT", PropertyExpressionOperator.Contains);

                WinEdit wEdit = new WinEdit(objParent);
                wEdit.SearchProperties.Add("Instance", "1", PropertyExpressionOperator.EqualTo);

                _gLib._SetSyncUDWin("GRS Edit", wEdit, sData, Config.iTimeout / 10);
            }
            catch (Exception ex)
            {
                _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> Failed to set value <" + sData + "> to Row <" + sRow + "> at column <" + iCol + "> because of Exception thrown: " + Environment.NewLine + ex.Message);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> Failed to set value <" + sData + "> to Row <" + sRow + "> at column <" + iCol + "> because of Exception thrown: " + Environment.NewLine + ex.Message);
            }

        }


        /// <summary>
        /// 2013-Dec-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Decrement", "Retirement");
        ///    dic.Add("FundingAL", "8598183");
        ///    dic.Add("FundingNC", "428354");
        ///    dic.Add("AccountingAL", "8909671");
        ///    dic.Add("AccountingNC", "446021");
        ///    dic.Add("Instance","");
        ///    dic.Add("OK", "");
        ///    pParticipantDataSet._GRSInformation_TotalsByDecrement(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _GRSInformation_TotalsByDecrement(MyDictionary dic)
        {
            string sFunctionName = "_GRSInformation_TotalsByDecrement";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iPosX = 100;
            int iPosY = 25;


            if (dic["Instance"] == "2")
            {
                iPosX = 30;
                iPosY = 40;
                this.wGRSInformation.wTotalByDecrement.SearchProperties["Instance"] = dic["Instance"];
            }

            if (dic["FundingAL"] != "")
            {
                _gLib._SetSyncUDWin(sFunctionName, this.wGRSInformation.wTotalByDecrement.grid, "Click", 0, false, iPosX, iPosY);
                _fp._Navigate(this.wGRSInformation.wTotalByDecrement.grid, dic["Decrement"], 10);
                this._GRSInformation_Grid(this.wGRSInformation, this.wGRSInformation.wTotalByDecrement.grid, dic["Decrement"], 1, dic["FundingAL"]);
            }

            if (dic["FundingNC"] != "")
            {
                _gLib._SetSyncUDWin(sFunctionName, this.wGRSInformation.wTotalByDecrement.grid, "Click", 0, false, iPosX, iPosY);
                _fp._Navigate(this.wGRSInformation.wTotalByDecrement.grid, dic["Decrement"], 10);
                this._GRSInformation_Grid(this.wGRSInformation, this.wGRSInformation.wTotalByDecrement.grid, dic["Decrement"], 2, dic["FundingNC"]);
            }

            if (dic["AccountingAL"] != "")
            {
                _gLib._SetSyncUDWin(sFunctionName, this.wGRSInformation.wTotalByDecrement.grid, "Click", 0, false, iPosX, iPosY);
                _fp._Navigate(this.wGRSInformation.wTotalByDecrement.grid, dic["Decrement"], 10);
                this._GRSInformation_Grid(this.wGRSInformation, this.wGRSInformation.wTotalByDecrement.grid, dic["Decrement"], 3, dic["AccountingAL"]);
            }

            if (dic["AccountingNC"] != "")
            {
                _gLib._SetSyncUDWin(sFunctionName, this.wGRSInformation.wTotalByDecrement.grid, "Click", 0, false, iPosX, iPosY);
                _fp._Navigate(this.wGRSInformation.wTotalByDecrement.grid, dic["Decrement"], 10);
                this._GRSInformation_Grid(this.wGRSInformation, this.wGRSInformation.wTotalByDecrement.grid, dic["Decrement"], 4, dic["AccountingNC"]);
            }

            _gLib._SetSyncUDWin("OK", this.wGRSInformation.wOK.btnOK, dic["OK"], 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }


        /// <summary>
        /// 2013-Dec-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Liability", "PPA NAR PVVB Active");
        ///    dic.Add("AL", "123456789");
        ///    dic.Add("NC", "987654321");
        ///    dic.Add("OK", "");
        ///    pParticipantDataSet._GRSInformation_AdditionalLiabilityTotals(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _GRSInformation_AdditionalLiabilityTotals(MyDictionary dic)
        {
            string sFunctionName = "_GRSInformation_AdditionalLiabilityTotals";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iPosX = 100;
            int iPosY = 25;


            if (dic["AL"] != "")
            {
                _gLib._SetSyncUDWin(sFunctionName, this.wGRSInformation.wAdditionalLiabilityTotals.grid, "Click", 0, false, iPosX, iPosY);
                _fp._Navigate(this.wGRSInformation.wAdditionalLiabilityTotals.grid, dic["Liability"], 10);
                this._GRSInformation_Grid(this.wGRSInformation, this.wGRSInformation.wAdditionalLiabilityTotals.grid, dic["Liability"], 1, dic["AL"]);
            }

            if (dic["NC"] != "")
            {
                _gLib._SetSyncUDWin(sFunctionName, this.wGRSInformation.wAdditionalLiabilityTotals.grid, "Click", 0, false, iPosX, iPosY);
                _fp._Navigate(this.wGRSInformation.wAdditionalLiabilityTotals.grid, dic["Liability"], 10);
                this._GRSInformation_Grid(this.wGRSInformation, this.wGRSInformation.wAdditionalLiabilityTotals.grid, dic["Liability"], 2, dic["NC"]);
            }

            _gLib._SetSyncUDWin("OK", this.wGRSInformation.wOK.btnOK, dic["OK"], 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }

        /// <summary>
        /// 2013-Dec-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Row", "Number");
        ///    dic.Add("Active", "284");
        ///    dic.Add("Deferred", "65");
        ///    dic.Add("Retired", "241");
        ///    dic.Add("OK", "");
        ///    pParticipantDataSet._GRSInformation_MemberStatisticsTotals(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _GRSInformation_MemberStatisticsTotals(MyDictionary dic)
        {
            string sFunctionName = "_GRSInformation_MemberStatisticsTotals";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iPosX = 100;
            int iPosY = 25;



            if (dic["Active"] != "")
            {
                _gLib._SetSyncUDWin(sFunctionName, this.wGRSInformation.wMemberStatisticsTotals.grid, "Click", 0, false, iPosX, iPosY);
                _fp._Navigate(this.wGRSInformation.wMemberStatisticsTotals.grid, dic["Row"], 10);
                this._GRSInformation_Grid(this.wGRSInformation, this.wGRSInformation.wMemberStatisticsTotals.grid, dic["Row"], 1, dic["Active"]);
            }


            if (dic["Deferred"] != "")
            {
                _gLib._SetSyncUDWin(sFunctionName, this.wGRSInformation.wMemberStatisticsTotals.grid, "Click", 0, false, iPosX, iPosY);
                _fp._Navigate(this.wGRSInformation.wMemberStatisticsTotals.grid, dic["Row"], 10);
                this._GRSInformation_Grid(this.wGRSInformation, this.wGRSInformation.wMemberStatisticsTotals.grid, dic["Row"], 2, dic["Deferred"]);
            }

            if (dic["Retired"] != "")
            {
                _gLib._SetSyncUDWin(sFunctionName, this.wGRSInformation.wMemberStatisticsTotals.grid, "Click", 0, false, iPosX, iPosY);
                _fp._Navigate(this.wGRSInformation.wMemberStatisticsTotals.grid, dic["Row"], 10);
                this._GRSInformation_Grid(this.wGRSInformation, this.wGRSInformation.wMemberStatisticsTotals.grid, dic["Row"], 3, dic["Retired"]);
            }


            _gLib._SetSyncUDWin("OK", this.wGRSInformation.wOK.btnOK, dic["OK"], 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }




    }
}
