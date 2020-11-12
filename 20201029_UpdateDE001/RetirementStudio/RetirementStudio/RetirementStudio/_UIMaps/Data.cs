namespace RetirementStudio._UIMaps.DataClasses
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
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;

    using Accessibility;
    using RetirementStudio._ThridParty;
    using System.Threading;
    using System.Windows.Forms;
    
    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using RetirementStudio._UIMaps.OutputManagerClasses;
    using RetirementStudio._UIMaps.MainClasses;

    public partial class Data
    {

        private FarPoint _fp =  new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        public OutputManager pOutputManager = new OutputManager();
        private Main pMain = new Main();

        public void _Debugging()
        {

            //var i = _gLib._TBL_ReturnIndex_Row("", this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, "8/11/1986", 3, 0, true);
            //var b = "";

            //Keyboard.SendKeys(this.wCK_StandardInputs.wInactiveBenefitRange_Min, "123");

            //var sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wCK_FPGrid.grid);
            //var c=1;

            //this._fpCV._ReturnSelectRowContent(this.wRetirementStudio.wCurrentView.gridCurrentView);
            //this._fpCV._ReturnSelectColIndex(this.wRetirementStudio.wCurrentView.gridCurrentView);



            //object[] native = this.wRetirementStudio.wCurrentView.gridCurrentView.NativeElement as object[];
            //IAccessible a = native[0] as IAccessible;



            //this._CV_Initialize("");


        }


        private void _CV_Initialize(string sFristLabelName)
        {
            string sFunctionName = "_CV_Initialize";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts by selecting:" + sFristLabelName);


            int xPos = 20;
            int yPos = 25;
            this._fp._ClickFirstRow(this.wRetirementStudio.wFPGrid.grid, xPos, yPos);

            if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) == sFristLabelName)
                _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully initialized by selecting: " + sFristLabelName);
            else
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> Ends");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail to initialize Current View by selecting: " + sFristLabelName);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends");

        }


        public void _CV_Navigate(string sLabelName, Boolean bContinueSearchOnCurrent)
        {
            string sFunctionName = "_CV_Navigate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) == sLabelName)
            {
                _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> : Label: " + sLabelName + " is already selected!");
                return;
            }
                

            int iSearchMax = 100;

            if (!bContinueSearchOnCurrent)
            {
                string sUp = "";
                for (int i = 1; i < 10; i++)
                    sUp = sUp + "{PageUp}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sUp);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sUp);
            }

            this._fp._Navigate(this.wRetirementStudio.wFPGrid.grid, sLabelName, iSearchMax);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }



        public void _CV_ClickEdit(string sLabelName, Boolean bContinueSearchOnCurrent, int iStep = 2)
        {
            string sFunctionName = "_CV_ClickEdit";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Home}");

            this._CV_Navigate(sLabelName, bContinueSearchOnCurrent);

            string sRights = "";
            for (int i = 0; i < iStep; i++)
                sRights = sRights + "{Right}";
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sRights);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Space}");
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2013-Apr-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Data 2011");
        ///    dic.Add("Level_2", "Current View");
        ///    pData._TreeViewSelect(dic);
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


        public void _CV_ExpandPersonalInformation()
        {
            string sFunctionName = "_TreeViewSelect";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            
            Boolean bExpaned = false;
            int iTryNum = 5;

            this._CV_Initialize("Personal Information");

            for (int i = 1; i <= iTryNum; i++)
            {
                _gLib._SetSyncUDWin("Personal Information Expand", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 5 + i, 25);
                //////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(5 + i, 25));

                ////////////Keyboard.SendKeys("{Down}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");


                if (_fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) == "EmployeeIDNumber" || _fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) == "IsEligible_VOParent")
                {
                    bExpaned = true;
                    break;
                }
            }

            if (!bExpaned)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> Failed to expand Personal Information");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Failed to expand Personal Information");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2013-Apr-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("EditSelection", "");
        ///    dic.Add("AddSingleLabel", "Click");
        ///    dic.Add("AddMultipleLabels", "");
        ///    pData._PopVerify_CurrentView(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CurrentView(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_CurrentView";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("EditSelection", this.wRetirementStudio.wCV_EditSelection.btnEditSelection, dic["EditSelection"], 0);
                _gLib._SetSyncUDWin("AddSingleLabel", this.wRetirementStudio.wCV_AddSingleLabel.btnAddSingleLabel, dic["AddSingleLabel"], 0);
                _gLib._SetSyncUDWin("AddMultipleLabels", this.wRetirementStudio.wCV_AddMultipleLabels.btnAddMultipleLabels, dic["AddMultipleLabels"], 0);
            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("EditSelection", this.wRetirementStudio.wCV_EditSelection.btnEditSelection, dic["EditSelection"], 0);
                _gLib._VerifySyncUDWin("AddSingleLabel", this.wRetirementStudio.wCV_AddSingleLabel.btnAddSingleLabel, dic["AddSingleLabel"], 0);
                _gLib._VerifySyncUDWin("AddMultipleLabels", this.wRetirementStudio.wCV_AddMultipleLabels.btnAddMultipleLabels, dic["AddMultipleLabels"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }


        /// <summary>
        /// 2013-Apr-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Label", "");
        ///    dic.Add("DisplayName", "");
        ///    dic.Add("SelectAnExistingWHField", "");
        ///    dic.Add("ExistingWHField", "");
        ///    dic.Add("VariesbyVO", "");
        ///    dic.Add("HistoryLabels", "");
        ///    dic.Add("Monthly", "");
        ///    dic.Add("Yearly", "");
        ///    dic.Add("WarehouseFieldType", "");
        ///    dic.Add("FieldLength", "");
        ///    dic.Add("DecimalPlaces", "");
        ///    dic.Add("FromDate", "");
        ///    dic.Add("OK", "");
        ///    dic.Add("Cancel", "");
        ///    pData._PopVerify_CV_AddLabel(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CV_AddLabel(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_CV_AddLabel";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Label", this.wCV_AddLabel.wLabel.txtLabel, dic["Label"], 0);
                _gLib._SetSyncUDWin("DisplayName", this.wCV_AddLabel.wDisplayName.txtDisplayName, dic["DisplayName"], 0);
                _gLib._SetSyncUDWin("SelectAnExistingWHField", this.wCV_AddLabel.wSelectAnExistingWHField.rd, dic["SelectAnExistingWHField"], 0);
                _gLib._SetSyncUDWin("ExistingWHField", this.wCV_AddLabel.wExistingWHField.cbo, dic["ExistingWHField"], 0);
                _gLib._SetSyncUDWin("VariesbyVO", this.wCV_AddLabel.wVariesbyVO.chk, dic["VariesbyVO"], 0);
                _gLib._SetSyncUDWin("HistoryLabels", this.wCV_AddLabel.wHistoryLabels.txtHistoryLabels, dic["HistoryLabels"], 0);
                _gLib._SetSyncUDWin("Monthly", this.wCV_AddLabel.wMonthly.rdMonthly, dic["Monthly"], 0);
                _gLib._SetSyncUDWin("Yearly", this.wCV_AddLabel.wYearly.rdYearly, dic["Yearly"], 0);
                _gLib._SetSyncUDWin("WarehouseFieldType", this.wCV_AddLabel.wWarehouseFieldType.cboWarehouseFieldType, dic["WarehouseFieldType"], 0);
                _gLib._SetSyncUDWin("FieldLength", this.wCV_AddLabel.wFieldLength.txtFieldLength, dic["FieldLength"], 0);
                _gLib._SetSyncUDWin("DecimalPlaces", this.wCV_AddLabel.wDecimalPlaces.txtDecimalPlaces, dic["DecimalPlaces"], 0);
                if (dic["FromDate"] != "")
                    _gLib._SendKeysUDWin("FromDate", this.wCV_AddLabel.wFromDate.txtFromDate, "{End}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}", 0);
                _gLib._SetSyncUDWin_ByClipboard("FromDate", this.wCV_AddLabel.wFromDate.txtFromDate, dic["FromDate"], 0);
                _gLib._SetSyncUDWin("OK", this.wCV_AddLabel.wOK.btnOK, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wCV_AddLabel.wCancel.btnCancel, dic["Cancel"], 0);
            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Label", this.wCV_AddLabel.wLabel.txtLabel, dic["Label"], 0);
                _gLib._VerifySyncUDWin("DisplayName", this.wCV_AddLabel.wDisplayName.txtDisplayName, dic["DisplayName"], 0);
                _gLib._VerifySyncUDWin("SelectAnExistingWHField", this.wCV_AddLabel.wSelectAnExistingWHField.rd, dic["SelectAnExistingWHField"], 0);
                _gLib._VerifySyncUDWin("ExistingWHField", this.wCV_AddLabel.wExistingWHField.cbo, dic["ExistingWHField"], 0);
                _gLib._VerifySyncUDWin("VariesbyVO", this.wCV_AddLabel.wVariesbyVO.chk, dic["VariesbyVO"], 0);
                _gLib._VerifySyncUDWin("HistoryLabels", this.wCV_AddLabel.wHistoryLabels.txtHistoryLabels, dic["HistoryLabels"], 0);
                _gLib._VerifySyncUDWin("Monthly", this.wCV_AddLabel.wMonthly.rdMonthly, dic["Monthly"], 0);
                _gLib._VerifySyncUDWin("Yearly", this.wCV_AddLabel.wYearly.rdYearly, dic["Yearly"], 0);
                _gLib._VerifySyncUDWin("WarehouseFieldType", this.wCV_AddLabel.wWarehouseFieldType.cboWarehouseFieldType, dic["WarehouseFieldType"], 0);
                _gLib._VerifySyncUDWin("FieldLength", this.wCV_AddLabel.wFieldLength.txtFieldLength, dic["FieldLength"], 0);
                _gLib._VerifySyncUDWin("DecimalPlaces", this.wCV_AddLabel.wDecimalPlaces.txtDecimalPlaces, dic["DecimalPlaces"], 0);
                _gLib._VerifySyncUDWin("FromDate", this.wCV_AddLabel.wFromDate.txtFromDate, dic["FromDate"], 0);
                _gLib._VerifySyncUDWin("OK", this.wCV_AddLabel.wOK.btnOK, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wCV_AddLabel.wCancel.btnCancel, dic["Cancel"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-Apr-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Category", "Personal Information");
        ///    dic.Add("Label", "");
        ///    dic.Add("DisplayName", "");
        ///    dic.Add("SelectAnExistingWHField", "");
        ///    dic.Add("ExistingWHField", "");
        ///    dic.Add("VariesbyVO", "");
        ///    dic.Add("HistoryLabels", "");
        ///    dic.Add("Monthly", "");
        ///    dic.Add("Yearly", "");
        ///    dic.Add("WarehouseFieldType", "");
        ///    dic.Add("FieldLength", "");
        ///    dic.Add("DecimalPlaces", "");
        ///    dic.Add("FromDate", "");
        ///    dic.Add("OK", "");
        ///    dic.Add("Cancel", "");
        ///    pData._CV_AddSingleLabel(dic, true); 
        /// </summary>
        /// <param name="dic"></param>
        public void _CV_AddSingleLabel(MyDictionary dic, Boolean bContinueSearchOnCurrent)
        {
            string sFunctionName = "_CV_AddSingleLabel";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            this._CV_Navigate(dic["Category"], bContinueSearchOnCurrent);

            MyDictionary tmpDic = new MyDictionary();
            tmpDic.Clear();
            tmpDic.Add("PopVerify", "Pop");
            tmpDic.Add("EditSelection", "");
            tmpDic.Add("AddSingleLabel", "Click");
            tmpDic.Add("AddMultipleLabels", "");
            this._PopVerify_CurrentView(tmpDic);

            this._PopVerify_CV_AddLabel(dic);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-Apr-23 
        /// webber.ling@mercer.com
        /// 
        /// sample: 
        /// pData._CV_AddMultipleLabels(@"c:\CurrentViewMultipleLabels.xls");
        /// </summary>
        /// <param name="sExcelFile"></param>
        public void _CV_AddMultipleLabels(string sExcelFile, Boolean bIsMultiple = true)
        {
            string sFunctionName = "_CV_AddMultipleLabels";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if(bIsMultiple)
            { 
                MyDictionary tmpDic = new MyDictionary();
                tmpDic.Clear();
                tmpDic.Add("PopVerify", "Pop");
                tmpDic.Add("EditSelection", "");
                tmpDic.Add("AddSingleLabel", "");
                tmpDic.Add("AddMultipleLabels", "Click");
                this._PopVerify_CurrentView(tmpDic);
            }

            _gLib._KillProcessByName("EXCEL");
            MyExcel _excel = new MyExcel(sExcelFile, true);
            _excel.OpenExcelFile(1);

            int iTotalRow = _excel.getTotalRowCount();
            int iTotalCol = _excel.getTotalColumnCount();
            string sContents = "";
            for (int i = 2; i <= iTotalRow; i++)
            {
                string sRow = "";
                for (int j = 1; j <= iTotalCol; j++)
                    sRow = sRow + _excel.getOneCellValue(i, j) + "\t";
                
                sContents = sContents + sRow + Environment.NewLine;
            }
            _excel.CloseExcelApplication();

            Clipboard.Clear();
            Clipboard.SetText(sContents);

            _fp._ClickFirstRow(wCV_AddLabels.wFPGrid.grid, 5, 15);
            ////////////Keyboard.SendKeys(wCV_AddLabels.wFPGrid.grid, "v", ModifierKeys.Control);
            _gLib._SendKeysUDWin("FPGrid", wCV_AddLabels.wFPGrid.grid, "v", 0, ModifierKeys.Control, false);

            ////////////Keyboard.SendKeys(wCV_AddLabels.wFPGrid.grid, "{PageDown}", ModifierKeys.None);
            _gLib._SendKeysUDWin("FPGrid", wCV_AddLabels.wFPGrid.grid, "{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}");

            int iTotalRow_Act = _fp._ReturnSelectRowIndex(wCV_AddLabels.wFPGrid.grid) + 1;

            if (iTotalRow != iTotalRow_Act)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> going to add <" + (iTotalRow - 1).ToString() + "> labels. Actual <" + (iTotalRow_Act + 1).ToString() + "> labels added! ");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> going to add <" + (iTotalRow - 1).ToString() + "> labels. Actual <" + (iTotalRow_Act + 1).ToString() + "> labels added! ");
            }

            _gLib._SetSyncUDWin("OK", wCV_AddLabels.wOK.btnOK, "Click", 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2016-Feb-16
        /// webber.ling@mercer.com
        /// 
        /// sample: 
        /// pData._BU_PasteValues(@"\\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive\AUTs\RetirementStudio\DataFile\Data_PerformanceTest\BatchUpdateInput.xlsx");
        /// </summary>
        /// <param name="sExcelFile"></param>
        public void _BU_PasteValues(string sExcelFile, int iXPos = 630)
        {
            string sFunctionName = "_BU_PasteValues";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            _gLib._KillProcessByName("EXCEL");
            MyExcel _excel = new MyExcel(sExcelFile, true);
            _excel.OpenExcelFile(1);

            int iTotalRow = _excel.getTotalRowCount();
            int iTotalCol = _excel.getTotalColumnCount();
            string sContents = "";
            for (int i = 2; i <= iTotalRow; i++)
            {
                string sRow = "";
                for (int j = 1; j <= iTotalCol; j++)
                    sRow = sRow + _excel.getOneCellValue(i, j) + "\t";

                sContents = sContents + sRow + Environment.NewLine;
            }
            _excel.CloseExcelApplication();

            Clipboard.Clear();
            Clipboard.SetText(sContents);
            _fp._ClickFirstRow(this.wRetirementStudio.wBU_FPGrid.grid, 30, 28);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wBU_FPGrid.grid, "{Tab}", 0);

            _fp._ClickFirstRow(this.wRetirementStudio.wBU_FPGrid.grid, iXPos, 28);

            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wBU_FPGrid.grid, "v", 0, ModifierKeys.Control, false);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }



        /// <summary>
        /// 2013-Apr-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("LocalFile", "Click");
        ///    dic.Add("GRSUnloadFile", "");
        ///    dic.Add("SharepointFile", "");
        ///    dic.Add("RepositoryFileName", "");
        ///    dic.Add("Browse", "Click");
        ///    dic.Add("Upload", "");
        ///    pData._PopVerify_UploadData(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_UploadData(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_UploadData";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("LocalFile", this.wRetirementStudio.wUD_LocalFile.rdLocalFile, dic["LocalFile"], 0);
                _gLib._SetSyncUDWin("GRSUnloadFile", this.wRetirementStudio.wUD_GRSUnloadFile.rdGRSUnloadFile, dic["GRSUnloadFile"], 0);
                _gLib._SetSyncUDWin("SharepointFile", this.wRetirementStudio.wUD_SharepointFile.rdSharepointFile, dic["SharepointFile"], 0);
                _gLib._SetSyncUDWin("RepositoryFileName", this.wRetirementStudio.wUD_RepositoryFileName.txt, dic["RepositoryFileName"], 0);
                _gLib._SetSyncUDWin("Browse", this.wRetirementStudio.wUD_Browse.btnBrowse, dic["Browse"], 0);
                _gLib._SetSyncUDWin("Upload", this.wRetirementStudio.wUD_Upload.btnUpload, dic["Upload"], 0);
                ////if(dic["Upload"]!="")
                ////{
                ////    _gLib._Wait(Config.iWaitMedium);
                ////}
            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("LocalFile", this.wRetirementStudio.wUD_LocalFile.rdLocalFile, dic["LocalFile"], 0);
                _gLib._VerifySyncUDWin("GRSUnloadFile", this.wRetirementStudio.wUD_GRSUnloadFile.rdGRSUnloadFile, dic["GRSUnloadFile"], 0);
                _gLib._VerifySyncUDWin("SharepointFile", this.wRetirementStudio.wUD_SharepointFile.rdSharepointFile, dic["SharepointFile"], 0);
                _gLib._VerifySyncUDWin("RepositoryFileName", this.wRetirementStudio.wUD_RepositoryFileName.txt, dic["wUD_RepositoryFileName"], 0);
                _gLib._VerifySyncUDWin("Browse", this.wRetirementStudio.wUD_Browse.btnBrowse, dic["Browse"], 0);
                _gLib._VerifySyncUDWin("Upload", this.wRetirementStudio.wUD_Upload.btnUpload, dic["Upload"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-Apr-24 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ClickCell", "Click");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("iCol", "1");
        ///    dic.Add("sRow", "");
        ///    dic.Add("sCol", "");
        ///    dic.Add("sData", "abc");
        ///    pData._UD_RepositoryContents(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Return");
        ///    dic.Add("ClickCell", "");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("iCol", "1");
        ///    dic.Add("sRow", "");
        ///    dic.Add("sCol", "");
        ///    dic.Add("sData", "");
        ///    string sData = pData._UD_RepositoryContents(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("ClickCell", "");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("iCol", "1");
        ///    dic.Add("sRow", "");
        ///    dic.Add("sCol", "");
        ///    dic.Add("sData", "abc");
        ///    pData._UD_RepositoryContents(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public string _UD_RepositoryContents(MyDictionary dic)
        {
            string sFunctionName = "_UD_RepositoryContents";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sReturnValue = "";

            if (dic["PopVerify"] == "Pop")
            {
                if (dic["ClickCell"] != "")
                {
                    _gLib._TBL_Table("", this.wRetirementStudio.wUD_RepositoryContents.tbl_RepositoryContents, Convert.ToInt32(dic["iRow"].ToString()),
                        Convert.ToInt32(dic["iCol"].ToString()), dic["sData"], 0, true, false, false, false);
                }
            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._TBL_Table("", this.wRetirementStudio.wUD_RepositoryContents.tbl_RepositoryContents, Convert.ToInt32(dic["iRow"].ToString()),
                    Convert.ToInt32(dic["iCol"].ToString()), dic["sData"], 0, false, false, true, false);
            }
            if (dic["PopVerify"].ToUpper() == "RETURN")
            {
                sReturnValue = _gLib._TBL_Table("", this.wRetirementStudio.wUD_RepositoryContents.tbl_RepositoryContents, Convert.ToInt32(dic["iRow"].ToString()),
                    Convert.ToInt32(dic["iCol"].ToString()), dic["sData"], 0, false, false, false, true);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

            return sReturnValue;
        }



        /// <summary>
        /// 2013-Apr-25 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Conversion 2010");
        ///    dic.Add("Level_2", "Imports");
        ///    dic.Add("MenuItem", "Add new file");
        ///    pData._TreeViewRightSelect(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewRightSelect(MyDictionary dic)
        {
            string sFunctionName = "_TreeViewRightSelect";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewRightSelectWin(0, this.wRetirementStudio.tvNaviTree, dic);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Apr-25 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FileDefinitionName", "ImportData");
        ///    dic.Add("FileType", "");
        ///    dic.Add("Delimiter_Tab", "");
        ///    dic.Add("Browse", "Click");
        ///    dic.Add("SingleTabPerRecordFile_cbo", "");
        ///    dic.Add("Preview", "");
        ///    pData._PopVerify_IP_SelectFile(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_SelectFile(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_IP_SelectFile";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("FileDefinitionName", this.wRetirementStudio.wIP_SelectFile_FileDefinitionName.txtFileDefinitionName, dic["FileDefinitionName"], 0);
                _gLib._SetSyncUDWin("FileType", this.wRetirementStudio.wIP_SelectFile_FileType.cboFileType, dic["FileType"], 0);
                _gLib._SetSyncUDWin("Delimiter_Tab", this.wRetirementStudio.wIP_SelectFile_Delimiter.rdTab, dic["Delimiter_Tab"], 0);
                _gLib._SetSyncUDWin("Browse", this.wRetirementStudio.wIP_Selectfile_Browse.btnBrowse, dic["Browse"], 0);
                _gLib._SetSyncUDWin("SingleTabPerRecordFile_cbo", this.wRetirementStudio.wIP_SelectFile_SingleTab_cbo.cbo, dic["SingleTabPerRecordFile_cbo"], 0);
                _gLib._SetSyncUDWin("Preview", this.wRetirementStudio.wIP_SelectFile_Preview.btnPreview, dic["Preview"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("FileDefinitionName", this.wRetirementStudio.wIP_SelectFile_FileDefinitionName.txtFileDefinitionName, dic["FileDefinitionName"], 0);
                _gLib._VerifySyncUDWin("FileType", this.wRetirementStudio.wIP_SelectFile_FileType.cboFileType, dic["FileType"], 0);
                _gLib._VerifySyncUDWin("Delimiter_Tab", this.wRetirementStudio.wIP_SelectFile_Delimiter.rdTab, dic["Delimiter_Tab"], 0);
                _gLib._VerifySyncUDWin("Browse", this.wRetirementStudio.wIP_Selectfile_Browse.btnBrowse, dic["Browse"], 0);
                _gLib._VerifySyncUDWin("SingleTabPerRecordFile_cbo", this.wRetirementStudio.wIP_SelectFile_SingleTab_cbo.cbo, dic["SingleTabPerRecordFile_cbo"], 0);
                _gLib._VerifySyncUDWin("Preview", this.wRetirementStudio.wIP_SelectFile_Preview.btnPreview, dic["Preview"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }



        /// <summary>
        /// 2013-Apr-24 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FileName", "abc.xls");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Cancel", "");
        ///    pData._PopVerify_IP_SelectFile_FileSelection(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FileName", "#1#");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Cancel", "");
        ///    pData._PopVerify_IP_SelectFile_FileSelection(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_SelectFile_FileSelection(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_IP_SelectFile_FileSelection";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("FileName", this.wIP_SelectFile_FileSelection.wFileList.listFileList, dic["FileName"], 0);
                _gLib._SetSyncUDWin("OK", this.wIP_SelectFile_FileSelection.wOK.btnOK, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wIP_SelectFile_FileSelection.wCancel.btnCancel, dic["Cancel"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("FileName", this.wIP_SelectFile_FileSelection.wFileList.listFileList, dic["FileName"], 0);
                _gLib._VerifySyncUDWin("OK", this.wIP_SelectFile_FileSelection.wOK.btnOK, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wIP_SelectFile_FileSelection.wCancel.btnCancel, dic["Cancel"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        public void _SelectTab(string sTabName)
        {
            string sFunctionName = "_SelectTab";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            
            _gLib._TabPageSelectWin(sTabName, this.wRetirementStudio.wIP_Tabs, 0);



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        public void _SelectTab_VU(string sTabName)
        {
            string sFunctionName = "_SelectTab_VU";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TabPageSelectWin(sTabName, this.wRetirementStudio.wVU_TabPage, 0);



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-Aug-07 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// pData._IP_Columns_Rename("Hire Date", "HireDate1");
        /// </summary>
        /// <param name="sOriginal"></param>
        /// <param name="sNew"></param>
        public void _IP_Columns_Rename(string sOriginal, string sNew)
        {
            string sFunctionName = "_IP_Columns_Rename";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRow = _gLib._TBL_ReturnIndex_Row("", this.wRetirementStudio.wIP_Columns.tblColumns, sOriginal, 1, 0, false);
            _gLib._TBL_Table(sNew, this.wRetirementStudio.wIP_Columns.tblColumns, iRow, 2, sNew, 0, false, true, true, false);



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends");
        }

        public void _CV_Initialize(string sFristLabelName, string slastLabelName, int iLevel, int iMainCategorySkipped, string sCheckLabelName)
        {
            string sFunctionName = "_CV_Initialize";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts by selecting:" + sFristLabelName);

            this._IP_Mapping_Initialize(sFristLabelName, slastLabelName, iLevel, 0, iMainCategorySkipped, sCheckLabelName);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends");
        }


        public void _IP_Mapping_Initialize(string sFristLabelName, string slastLabelName, int iLevel, int iMappedFieldSkiped, int iMainCategorySkipped, string sCheckLabelName, int iSpecialYPos = 0)
        {
            string sFunctionName = "_IP_Mapping_Initialize";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts by selecting:" + sFristLabelName);


            // dock window has not been drap-drop, need to dragand drop
            if (this.wRetirementStudio.wIP_Mapping_DockingWin.wDockingWin.BoundingRectangle.Height > 200)
            {
                try
                {
                    Mouse.StartDragging(this.wRetirementStudio.wIP_Mapping_DockingWin.wDockingWin, new Point(420, 2));
                    Mouse.StopDragging(this.wRetirementStudio.wIP_Mapping_DockingWin.wDockingWin, 2, 282);
                }
                catch (Exception ex)
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> Failed to DragDrop the Mapping screen to resize it. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> Failed to DragDrop the Mapping screen to resize it. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                }
            }

            int xPos = 20;
            int yPos = 25;
            this._fp._ClickFirstRow(this.wRetirementStudio.wFPGrid.grid, xPos, yPos);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{PageUp}{PageUp}");
            this._fp._ClickFirstRow(this.wRetirementStudio.wFPGrid.grid, xPos, yPos);

            // pickup the first item
            if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) == sFristLabelName)
                _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully selected: " + sFristLabelName);
            else
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> Ends");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail to select: " + sFristLabelName);
            }

            // expand necessary category
            int iDownNumMax = 50;
            int iActDownNum = 0;
            Boolean bFind = false;
            
            int ixStart_Level1 = 6;
            int ixStart_Level2 = 26;
            int ixStart_Level3 = 46;
            int ixStart_Level4 = 66;
            int iyStep_Level1 = 20;
            int iyStep_Level2_WithoutMap = 18;
            int iyStep_Level2_WithMap = 16;
            //int iyStep_Level3 = 15;
            int iyOffset = iyStep_Level2_WithoutMap / 2;
            int iXPos = 0;
            int iYPos = 0;
            //int iMappedFieldSkiped = 0;



            for (int i = 0; i <= iDownNumMax; i++)
            {


                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) == slastLabelName)
                {
                    bFind = true;
                    break;
                }
                if (slastLabelName.ToUpper().Equals("DC INFORMATION"))
                {
                    

                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid).ToUpper() == slastLabelName.ToUpper())
                    {
                        bFind = true;
                        break;
                    }
                }
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                iActDownNum++;

            }

            if (!bFind)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to find expected node <" + slastLabelName + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail because fail to find expected node <" + slastLabelName + ">");
            }
            else
            {
                switch (iLevel)
                {
                    case 1:
                        {
                            Boolean bExpanded = false;
                            iXPos = ixStart_Level1;

                            for (int i = 0; i < 10; i++)
                            {
                                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid).ToUpper() != sCheckLabelName.ToUpper())
                                {
                                    if (iSpecialYPos==0)
                                        iYPos = iyStep_Level1 + iActDownNum * iyStep_Level1 + iyOffset - 4 + i;
                                    else
                                        iYPos = iSpecialYPos - 4 + i;

                                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iXPos, iYPos);
                                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");

                                }
                                else
                                    bExpanded = true;
                            }
                            if (!bExpanded)
                            {
                                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to expand  node <" + slastLabelName + ">");
                                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> failed because fail to expand  node <" + slastLabelName + ">");
                            }

                            //////////for (int i = 1; i <= iActDownNum + 1; i++)
                            //////////    Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iXPos, iyStep_Level1 + (iActDownNum - i + 1) * iyStep_Level1 + iyOffset));
                            break;
                        }
                    case 2:
                        iXPos = ixStart_Level2;
                        iYPos = iMappedFieldSkiped * iyStep_Level2_WithMap 
                            + (iActDownNum - iMappedFieldSkiped - iMainCategorySkipped) * iyStep_Level2_WithoutMap 
                            + (iMainCategorySkipped) * iyStep_Level1 + iyOffset + iActDownNum/2;
                        ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iXPos, iYPos));
                        _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iXPos, iYPos);

                        if (sCheckLabelName != "")
                        {
                            Boolean bExpanded = false;
                            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");

                            ////string sAct = "";

                            for (int i = 0; i < 12; i++)
                            {

                                ////sAct = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid);

                                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) != sCheckLabelName)
                                {
                                    ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iXPos, iYPos - 3 + i));
                                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iXPos, iYPos - 3 + i);
                                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                                }
                                else
                                    bExpanded = true;
                            }
                            if (!bExpanded)
                            {
                                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to expand  node <" + slastLabelName + ">");
                                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> failed because fail to expand  node <" + slastLabelName + ">");
                            }

                        }
                        break;
                    case 3:
                        iXPos = ixStart_Level3;
                        iYPos = iMappedFieldSkiped * iyStep_Level2_WithMap
                                + (iActDownNum - iMappedFieldSkiped - iMainCategorySkipped) * iyStep_Level2_WithoutMap
                                + (iMainCategorySkipped) * iyStep_Level1 + iyOffset + iActDownNum/2;
                        ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iXPos, iYPos));
                        _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iXPos, iYPos);
                        if (sCheckLabelName != "")
                        {
                            Boolean bExpanded = false;
                            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                            for (int i = 0; i < 16; i++)
                            {
                                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) != sCheckLabelName)
                                {
                                    ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iXPos, iYPos - 8 + i));
                                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iXPos, iYPos - 8 + i);
                                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                                }
                                else
                                    bExpanded = true;
                            }
                            if (!bExpanded)
                            {
                                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to expand  node <" + slastLabelName + ">");
                                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> failed because fail to expand  node <" + slastLabelName + ">");
                            }

                        }
                        break;
                    case 4:
                        iXPos = ixStart_Level4;
                        iYPos = iMappedFieldSkiped * iyStep_Level2_WithMap
                                + (iActDownNum - iMappedFieldSkiped - iMainCategorySkipped) * iyStep_Level2_WithoutMap
                                + (iMainCategorySkipped) * iyStep_Level1 + iyOffset + iActDownNum / 2;
                        ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iXPos, iYPos));
                        _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iXPos, iYPos);
                        if (sCheckLabelName != "")
                        {
                            Boolean bExpanded = false;
                            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                            for (int i = 0; i < 16; i++)
                            {
                                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) != sCheckLabelName)
                                {
                                    ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iXPos, iYPos - 8 + i));
                                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iXPos, iYPos - 8 + i);
                                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                                }
                                else
                                    bExpanded = true;
                            }
                            if (!bExpanded)
                            {
                                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to expand  node <" + slastLabelName + ">");
                                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> failed because fail to expand  node <" + slastLabelName + ">");
                            }

                        }
                        break;
                    default:
                        iXPos = ixStart_Level1;
                        break;
                }


            }
            

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends");
        }

        public void _IP_Mapping_Initialize(string sFristLabelName, string slastLabelName, int iLevel, int iMappedFieldSkiped, int iMainCategorySkipped)
        {
            this._IP_Mapping_Initialize(sFristLabelName, slastLabelName, iLevel, iMappedFieldSkiped, iMainCategorySkipped, "");
        }

        public void _IP_Mapping_MapField(string sSystemLabel, string sUserLabel, int iBeginDownNum, Boolean bContinueSearchOnCurrent)
        {
            this._IP_Mapping_MapField(sSystemLabel, sUserLabel, iBeginDownNum, bContinueSearchOnCurrent, 0);
        }


        
        public void _IP_Mapping_MapField(string sSystemLabel, string sUserLabel, int iBeginDownNum, Boolean bContinueSearchOnCurrent, int iNumOfSkipFields)
        {
            string sFunctionName = "_IP_Mapping_MapField";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            // revert to first row, first column
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Home}");


            if (!bContinueSearchOnCurrent)
            {
                string sUp = "";
                for (int i = 0; i <= 20; i++)
                    sUp = sUp + "{PageUp}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sUp);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sUp);

                // click  first row, first column
                int xPos = 20;
                int yPos = 25;
                this._fp._ClickFirstRow(this.wRetirementStudio.wFPGrid.grid, xPos, yPos);
            }




            int iDownNumMax = 100;
            Boolean bFind = false;
            Boolean bMapped = false;

            string sSkipDownKey = "";
            for (int i = 0; i < iNumOfSkipFields; i++)
                sSkipDownKey = sSkipDownKey + "{Down}";
            if(sSkipDownKey!="")
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sSkipDownKey);
                //////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sSkipDownKey);
                


            for (int i = 0; i <= iDownNumMax; i++)
            {
                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) == sSystemLabel)
                {
                    bFind = true;
                    break;
                }
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                ////////////try
                ////////////{
                ////////////    Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                ////////////}
                ////////////catch (Exception ex)
                ////////////{
                ////////////    _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to send Keys. Because exception threw out: " + Environment.NewLine + ex.Message);
                ////////////    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to send Keys. Because exception threw out: " + Environment.NewLine + ex.Message);
                ////////////}
            }

            if (!bFind)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to find expected node <" + sSystemLabel + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail because fail to find expected node <" + sSystemLabel + ">");
            }
            else
            {

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Right}{Right}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Right}{Right}");


                string sChar = sUserLabel.Substring(0, 1);
                string sCharToSend = "";
                for (int iOuter = 0; iOuter <= 50; iOuter++)
                {
                    sCharToSend = "";
                    // improve the search performance by given start point to search down
                    if (iBeginDownNum != 0)
                    {
                        for (int i = 1; i < iBeginDownNum; i++)
                            sCharToSend = sCharToSend + sChar;
                    }
                    for (int iInner = 0; iInner <= iOuter; iInner++)
                        sCharToSend = sCharToSend + sChar;
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sCharToSend);
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Left}{Right}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sCharToSend);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Left}{Right}");

                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) == sUserLabel)
                    {
                        bMapped = true;
                        break;
                    }

                }
                if (!bMapped)
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to map user node <" + sUserLabel + "> to system node <" + sSystemLabel + ">");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail because fail to map user node <" + sUserLabel + "> to system node <" + sSystemLabel + ">");
                }

            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends");
        }



        public void _IP_Mapping_ClickEdit(string sSystemLabel, Boolean bContinueSearchOnCurrent)
        {
            string sFunctionName = "_IP_Mapping_ClickEdit";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            // revert to first row, first column
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}");
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Home}");


            if (!bContinueSearchOnCurrent)
            {
                string sUp = "";
                for (int i = 0; i <= 10; i++)
                    sUp = sUp + "{PageUp}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sUp);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, sUp);

                // click  first row, first column
                int xPos = 20;
                int yPos = 25;
                this._fp._ClickFirstRow(this.wRetirementStudio.wFPGrid.grid, xPos, yPos);
            }




            int iDownNumMax = 100;
            Boolean bFind = false;

            for (int i = 0; i <= iDownNumMax; i++)
            {
                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) == sSystemLabel)
                {
                    bFind = true;
                    break;
                }
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
            }

            if (!bFind)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to find expected node <" + sSystemLabel + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail because fail to find expected node <" + sSystemLabel + ">");
            }
            else
            {

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Right}{Right}{Right}{Space}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFPGrid.grid, "{Right}{Right}{Right}{Space}");
                /////_gLib._Exists("Transformation Definition", wIP_TransformationDefinition, 0);

            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends");
        }


        /// <summary>
        /// 2013-Aug-07
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Lookup", "True");
        ///    dic.Add("Standard", "");
        ///    dic.Add("OK", "");
        ///    pData._PopVerify_IP_Mapping_Transformation(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Mapping_Transformation(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_Mapping_Transformation";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("Lookup", this.wIP_TransformationDefinition.wLookup.chkLookup, dic["Lookup"], 0);
                _gLib._SetSyncUDWin("Standard", this.wIP_TransformationDefinition.wStandard.chk, dic["Standard"], 0);
                _gLib._SetSyncUDWin("OK", this.wIP_TransformationDefinition.wOK.btnOK, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Lookup", this.wIP_TransformationDefinition.wLookup.chkLookup, dic["Lookup"], 0);
                _gLib._VerifySyncUDWin("Standard", this.wIP_TransformationDefinition.wStandard.chk, dic["Standard"], 0);
                _gLib._VerifySyncUDWin("OK", this.wIP_TransformationDefinition.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        public void _IP_Mapping_Transformation(int iRow, int iCol, string sValue)
        {

            string sFunctionName = "_IP_Mapping_Transformation";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            //Boolean bValueCorrectSet = false;
            int xPos = 50;
            int yPos = 50;
            string sKeys = "";
            string sBackKeys = "{Home}{PageUp}{PageUp}";
            

            sKeys = "";
            ////////this._fp._ClickFirstRow(this.wIP_TransformationDefinition.wFPGrid.grid, xPos, yPos);
            _gLib._SendKeysUDWin("FPGrid", this.wIP_TransformationDefinition.wFPGrid.grid, sBackKeys);
            this._fp._ClickFirstRow(this.wIP_TransformationDefinition.wFPGrid.grid, xPos, yPos);

            if(iRow == 0)
                sKeys = sKeys + "{Up}";
            for (int i = 1; i < iRow; i++)
                sKeys = sKeys + "{Down}";
            for (int i = 1; i < iCol; i++)
                sKeys = sKeys + "{Right}";
            if(sKeys!="")
                _gLib._SendKeysUDWin("FPGrid", this.wIP_TransformationDefinition.wFPGrid.grid, sKeys);
                ////////////Keyboard.SendKeys(this.wIP_TransformationDefinition.wFPGrid.grid, sKeys);

            ////////////Keyboard.SendKeys(this.wIP_TransformationDefinition.wFPGrid.grid, sValue);
            _gLib._SendKeysUDWin("FPGrid", this.wIP_TransformationDefinition.wFPGrid.grid, "{Delete}" + sValue +"{Tab}");
            //Keyboard.SendKeys(this.wIP_TransformationDefinition.wFPGrid.grid, "{Enter}");

            sKeys = "";
            ////////this._fp._ClickFirstRow(this.wIP_TransformationDefinition.wFPGrid.grid, xPos, yPos);
            _gLib._SendKeysUDWin("FPGrid", this.wIP_TransformationDefinition.wFPGrid.grid, sBackKeys);
            this._fp._ClickFirstRow(this.wIP_TransformationDefinition.wFPGrid.grid, xPos, yPos);

            if (iRow == 0)
                sKeys = sKeys + "{Up}";
            for (int i = 1; i < iRow; i++)
                sKeys = sKeys + "{Down}";
            for (int i = 1; i < iCol; i++)
                sKeys = sKeys + "{Right}";
            if (sKeys != "")
                _gLib._SendKeysUDWin("FPGrid", this.wIP_TransformationDefinition.wFPGrid.grid, sKeys);
                ////////////Keyboard.SendKeys(this.wIP_TransformationDefinition.wFPGrid.grid, sKeys);

            string sActValue = this._fp._ReturnSelectRowContent(this.wIP_TransformationDefinition.wFPGrid.grid);
            if (sActValue != sValue)
            {
  		 		if (!sActValue.Contains(sValue))
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to set value <" + sValue + "> to Row <" + iRow + ">, Column <" + iCol + ">, Actual value <" + sActValue + ">");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> failed because fail to set value <" + sValue + "> to Row <" + iRow + ">, Column <" + iCol + ">, Actual value <" + sActValue + ">");
                }
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Aug-07
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CopyMappings", "");
        ///    dic.Add("ClearMappings", "");
        ///    dic.Add("Preview", "Click");
        ///    pData._PopVerify_IP_Mapping(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Mapping(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_Mapping";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("CopyMappings", this.wRetirementStudio.wIP_Mapping_CopyMappings.btn, dic["CopyMappings"], 0);
                _gLib._SetSyncUDWin("ClearMappings", this.wRetirementStudio.wIP_Mapping_ClearMappings.btn, dic["ClearMappings"], 0);
                _gLib._SetSyncUDWin("Preview", this.wRetirementStudio.wIP_Mapping_Preview.btnPreview, dic["Preview"], 0);
                
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("CopyMappings", this.wRetirementStudio.wIP_Mapping_CopyMappings.btn, dic["CopyMappings"], 0);
                _gLib._VerifySyncUDWin("ClearMappings", this.wRetirementStudio.wIP_Mapping_ClearMappings.btn, dic["ClearMappings"], 0);
                _gLib._VerifySyncUDWin("Preview", this.wRetirementStudio.wIP_Mapping_Preview.btnPreview, dic["Preview"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-02 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Status", "");
        ///    dic.Add("LoadBlankData", "");
        ///    dic.Add("MatchingIsCaseSensitive", "");
        ///    dic.Add("IgnoreGoneRecordsForMatching", "");
        ///    dic.Add("CorrectionImportForAdmin", "");
        ///    dic.Add("ValidateData", "");
        ///    dic.Add("LoadData", "");
        ///    dic.Add("ValidateAndLoadData", "Click");
        ///    pData._PopVerify_IP_ValidateAndLoad(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("Status", "STAGED");
        ///    dic.Add("LoadBlankData", "");
        ///    dic.Add("MatchingIsCaseSensitive", "");
        ///    dic.Add("IgnoreGoneRecordsForMatching", "");
        ///    dic.Add("CorrectionImportForAdmin", "");
        ///    dic.Add("ValidateData", "");
        ///    dic.Add("LoadData", "");
        ///    dic.Add("ValidateAndLoadData", "");
        ///    pData._PopVerify_IP_ValidateAndLoad(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_ValidateAndLoad(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_ValidateAndLoad";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("LoadBlankData", this.wRetirementStudio.wIP_VL_LoadBlankData.chkLoadBlankData, dic["LoadBlankData"], 0);
                _gLib._SetSyncUDWin("MatchingIsCaseSensitive", this.wRetirementStudio.wIP_VL_MatchingIsCaseSensitive.chkMatchingIsCaseSensitive, dic["MatchingIsCaseSensitive"], 0);
                _gLib._SetSyncUDWin("IgnoreGoneRecordsForMatching", this.wRetirementStudio.wIP_VL_IgnoreGoneRecordsForMatching.chkIgnoreGoneRecordsForMatching, dic["IgnoreGoneRecordsForMatching"], 0);
                _gLib._SetSyncUDWin("CorrectionImportForAdmin", this.wRetirementStudio.wIP_VL_CorrectionImportForAdmin.chk, dic["CorrectionImportForAdmin"], 0);
                _gLib._SetSyncUDWin("ValidateData", this.wRetirementStudio.wIP_VL_ValidateData.btnValidateData, dic["ValidateData"], 0);
                _gLib._SetSyncUDWin("LoadData", this.wRetirementStudio.wIP_VL_LoadData.btnLoadData, dic["LoadData"], 0);
                _gLib._SetSyncUDWin("ValidateAndLoadData", this.wRetirementStudio.wIP_VL_ValidateAndLoadData.btnValidateAndLoadData, dic["ValidateAndLoadData"], 0);
                if(dic["ValidateAndLoadData"]!="")
                    _gLib._SetSyncUDWin("ValidateAndLoadData", this.wIP_VL_MappingSummaryAndConfirm.wProceedWithVL.btn, "Click", 0);
            
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Status", this.wRetirementStudio.wIP_VL_Status.txtStatus, dic["Status"], 0);
                _gLib._VerifySyncUDWin("LoadBlankData", this.wRetirementStudio.wIP_VL_LoadBlankData.chkLoadBlankData, dic["LoadBlankData"], 0);
                _gLib._VerifySyncUDWin("MatchingIsCaseSensitive", this.wRetirementStudio.wIP_VL_MatchingIsCaseSensitive.chkMatchingIsCaseSensitive, dic["MatchingIsCaseSensitive"], 0);
                _gLib._VerifySyncUDWin("IgnoreGoneRecordsForMatching", this.wRetirementStudio.wIP_VL_IgnoreGoneRecordsForMatching.chkIgnoreGoneRecordsForMatching, dic["IgnoreGoneRecordsForMatching"], 0);
                _gLib._VerifySyncUDWin("CorrectionImportForAdmin", this.wRetirementStudio.wIP_VL_CorrectionImportForAdmin.chk, dic["CorrectionImportForAdmin"], 0);
                _gLib._VerifySyncUDWin("ValidateData", this.wRetirementStudio.wIP_VL_ValidateData.btnValidateData, dic["ValidateData"], 0);
                _gLib._VerifySyncUDWin("LoadData", this.wRetirementStudio.wIP_VL_LoadData.btnLoadData, dic["LoadData"], 0);
                _gLib._VerifySyncUDWin("ValidateAndLoadData", this.wRetirementStudio.wIP_VL_ValidateAndLoadData.btnValidateAndLoadData, dic["ValidateAndLoadData"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-3 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Message", "");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_IP_ValidateAndLoad_Popup(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("Message", "Data validate & load SUCCESS");
        ///    dic.Add("OK", "");
        ///    pData._PopVerify_IP_ValidateAndLoad_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_ValidateAndLoad_Popup(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_IP_ValidateAndLoad_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Message", this.wIP_ValidateAndLoad_Popup.wMessage.txtMessage, dic["Message"], 0);
                _gLib._SetSyncUDWin("OK", this.wIP_ValidateAndLoad_Popup.wOK.btnOK, dic["OK"], 0);
            }
            if (dic["PopVerify"] == "Verify")
            {
                if (dic["Message"] != "")
                {
                    string sMsg = dic["Message"].Replace("&", "");
                    _gLib._VerifySyncUDWin("Message", this.wIP_ValidateAndLoad_Popup.wMessage.txtMessage, sMsg, 0);
                }
                _gLib._VerifySyncUDWin("OK", this.wIP_ValidateAndLoad_Popup.wOK.btnOK, dic["OK"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }
        

        /// <summary>
        /// 2013-May-3 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Field", "EmployeeIDNumber");
        ///    dic.Add("Include", "True");
        ///    dic.Add("ImportFormulaOverride", "");
        ///    dic.Add("WarehouseFormulaOverride", "");
        ///    pData._IP_Matching_FPSpread(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("Field", "EmployeeIDNumber");
        ///    dic.Add("Include", "False");
        ///    dic.Add("ImportFormulaOverride", "");
        ///    dic.Add("WarehouseFormulaOverride", "");
        ///    pData._IP_Matching_FPSpread(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _IP_Matching_FPSpread(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_IP_ValidateAndLoad";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            // rever to first row
            string sUp = "";
            for (int i = 0; i < 9; i++)
                sUp = sUp + "{PageUp}";
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, sUp);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, sUp);

            this._fp._ClickFirstRow(this.wRetirementStudio.wIP_Matching_FPGrid.grid, 50, 27);

            this._fp._Navigate(this.wRetirementStudio.wIP_Matching_FPGrid.grid, dic["Field"], 0);

            if (dic["Include"] != "")
            {
                if (dic["Include"] != "True" && dic["Include"] != "False")
                {
                    this._gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because input parameter 'Include' value NOT correct, its either 'True' or 'False'.");
                    this._gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because input parameter 'Include' value NOT correct, its either 'True' or 'False'.");
                }
                else
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Left}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Left}");

                    string sAct = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wIP_Matching_FPGrid.grid);
                    if (sAct != dic["Include"])
                    {
                        ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Space}");
                        ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                        ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Left}");
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Space}");
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Left}");

                        sAct = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wIP_Matching_FPGrid.grid);
                        
                        if (sAct != dic["Include"])
                        {
                            this._gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed to set 'Include' value as <" + dic["Include"] + ">, actual value <" + sAct + ">");
                            this._gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to set 'Include' value as <" + dic["Include"] + ">, actual value <" + sAct + ">");
                        }
                    }

                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                }

            }

            if (dic["ImportFormulaOverride"] != "")
            {
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, dic["ImportFormulaOverride"]);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, dic["ImportFormulaOverride"]);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}{Right}");
                string sAct = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wIP_Matching_FPGrid.grid);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Left}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Left}");
                if (sAct != dic["ImportFormulaOverride"])
                {
                    this._gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed to set 'ImportFormulaOverride' value as <" + dic["ImportFormulaOverride"] + ">, actual value <" + sAct + ">");
                    this._gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to set 'ImportFormulaOverride' value as <" + dic["ImportFormulaOverride"] + ">, actual value <" + sAct + ">");
                }

            }

            if (dic["WarehouseFormulaOverride"] != "")
            {
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, dic["WarehouseFormulaOverride"]);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}{Right}{Right}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, " "+"{Back}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, dic["WarehouseFormulaOverride"]);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Right}{Right}{Right}{Right}");

                string sAct = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wIP_Matching_FPGrid.grid);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Left}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Left}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Left}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wIP_Matching_FPGrid.grid, "{Left}{Left}{Left}");
                if (sAct != dic["WarehouseFormulaOverride"])
                {
                    this._gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed to set 'WarehouseFormulaOverride' value as <" + dic["WarehouseFormulaOverride"] + ">, actual value <" + sAct + ">");
                    this._gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to set 'WarehouseFormulaOverride' value as <" + dic["WarehouseFormulaOverride"] + ">, actual value <" + sAct + ">");
                }

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }



        /// <summary>
        /// 2013-May-7 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Unique_NoMatch", "Click");
        ///    dic.Add("Unique_UniqueMatch", "");
        ///    dic.Add("Unique_MultipleMatches", "");
        ///    dic.Add("Duplicate_NoMatch", "");
        ///    dic.Add("Duplicate_UniqueMatch", "");
        ///    dic.Add("Duplicate_MultipleMatches", "");
        ///    dic.Add("Warehouse_NoMatch", "");
        ///    dic.Add("RunCurrentStage", "");
        ///    dic.Add("RunAllStages", "");
        ///    dic.Add("AcceptAllRecordsAs_What", "");
        ///    dic.Add("AcceptSelectedRecordsAs_What", "");
        ///    pData._PopVerify_IP_Matching_MatchingResultsSummary(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("Unique_NoMatch_Num", "130");
        ///    dic.Add("Unique_UniqueMatch_Num", "0");
        ///    dic.Add("Unique_MultipleMatches_Num", "0");
        ///    dic.Add("Duplicate_NoMatch_Num", "0");
        ///    dic.Add("Duplicate_UniqueMatch_Num", "0");
        ///    dic.Add("Duplicate_MultipleMatches_Num", "0");
        ///    dic.Add("Warehouse_NoMatch_Num", "0");
        ///    pData._PopVerify_IP_Matching_MatchingResultsSummary(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Matching_MatchingResultsSummary(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_IP_Matching_MatchingResultsSummary";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Unique_NoMatch", this.wRetirementStudio.wIP_Matching_UD_NoMatch.txtNoMatch.linkNoMatch, dic["Unique_NoMatch"], 0);
                _gLib._SetSyncUDWin("Unique_UniqueMatch", this.wRetirementStudio.wIP_Matching_UD_UniqueMatch.txtUniqueMatch.linkUniqueMatch, dic["Unique_UniqueMatch"], 0);
                _gLib._SetSyncUDWin("Unique_MultipleMatches", this.wRetirementStudio.wIP_Matching_UD_MultipleMatches.txtMultipleMatches.linkMultipleMatches, dic["Unique_MultipleMatches"], 0);
                _gLib._SetSyncUDWin("Duplicate_NoMatch", this.wRetirementStudio.wIP_Matching_DD_NoMatch.txtNoMatch.linkNoMatch, dic["Duplicate_NoMatch"], 0);
                _gLib._SetSyncUDWin("Duplicate_UniqueMatch", this.wRetirementStudio.wIP_Matching_DD_UniqueMatch.txtUniqueMatch.linkUniqueMatch, dic["Duplicate_UniqueMatch"], 0);
                _gLib._SetSyncUDWin("Duplicate_MultipleMatches", this.wRetirementStudio.wIP_Matching_DD_MultipleMatches.txtMultipleMatches.linkMultipleMatches, dic["Duplicate_MultipleMatches"], 0);
                _gLib._SetSyncUDWin("Warehouse_NoMatch", this.wRetirementStudio.wIP_Matching_WR_NoMatch.txtNoMatch.linkNoMatch, dic["Warehouse_NoMatch"], 0);

                _gLib._SetSyncUDWin("RunCurrentStage", this.wRetirementStudio.wIP_Matching_RunCurrentStage.btnRunCurrentStage, dic["RunCurrentStage"], 0);
                _gLib._SetSyncUDWin("RunAllStages", this.wRetirementStudio.wIP_Matching_RunAllStages.btnRunAllStages, dic["RunAllStages"], 0);

                if (dic["AcceptAllRecordsAs_What"] != "")
                {
                    _gLib._SetSyncUDWin("AcceptAllRecordsAs", this.wRetirementStudio.wIP_Matching_AcceptAllRecordsAs.btn.btn1, "Click", 0);
                    _gLib._SetSyncUDWin("AcceptAllRecordsAs_What", this.wIP_Matching_AcceptRecordsAs_Popup.wAcceptAll.listItems, dic["AcceptAllRecordsAs_What"], 0, false);
                }
                if (dic["AcceptSelectedRecordsAs_What"] != "")
                {
                    _gLib._SetSyncUDWin("AcceptSelectedRecordsAs", this.wRetirementStudio.wIP_Matching_AcceptSelectedRecordsAs.btn.btn1, "Click", 0);
                    _gLib._SetSyncUDWin("AcceptSelectedRecordsAs_What", this.wIP_Matching_AcceptRecordsAs_Popup.wAcceptSelected.listItems, dic["AcceptSelectedRecordsAs_What"], 0, false);
                }
            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Unique_NoMatch_Num", this.wRetirementStudio.wIP_Matching_UD_NoMatch_Num.txtNoMatch, dic["Unique_NoMatch_Num"], 0);
                _gLib._VerifySyncUDWin("Unique_UniqueMatch_Num", this.wRetirementStudio.wIP_Matching_UD_UniqueMatch_Num.txtUniqueMatch, dic["Unique_UniqueMatch_Num"], 0);
                _gLib._VerifySyncUDWin("Unique_MultipleMatches_Num", this.wRetirementStudio.wIP_Matching_UD_MultipleMatches_Num.txtMultipleMatches, dic["Unique_MultipleMatches_Num"], 0);
                _gLib._VerifySyncUDWin("Duplicate_NoMatch_Num", this.wRetirementStudio.wIP_Matching_DD_NoMatch_Num.txtNoMatch, dic["Duplicate_NoMatch_Num"], 0);
                _gLib._VerifySyncUDWin("Duplicate_UniqueMatch_Num", this.wRetirementStudio.wIP_Matching_DD_UniqueMatch_Num.txtUniqueMatch, dic["Duplicate_UniqueMatch_Num"], 0);
                _gLib._VerifySyncUDWin("Duplicate_MultipleMatches_Num", this.wRetirementStudio.wIP_Matching_DD_MultipleMatches_Num.txtMultipleMatches, dic["Duplicate_MultipleMatches_Num"], 0);
                _gLib._VerifySyncUDWin("Warehouse_NoMatch_Num", this.wRetirementStudio.wIP_Matching_WR_NoMatch_Num.txtNoMatch, dic["Warehouse_NoMatch_Num"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        
        /// <summary>
        /// 2013-May-07 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Yes", "");
        ///    dic.Add("No", "");
        ///    pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("Message", "Are you sure you want to accept all records with a status of New");
        ///    dic.Add("Yes", "");
        ///    dic.Add("No", "");
        ///    pData._PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Matching_ConfirmAcceptRecods_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_Matching_ConfirmAcceptRecods_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Yes", this.wIP_Matching_ConfirmAccept_Popup.wYes.btnYes, dic["Yes"], 0);
                _gLib._SetSyncUDWin("No", this.wIP_Matching_ConfirmAccept_Popup.wNo.btnNo, dic["No"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Message", this.wIP_Matching_ConfirmAccept_Popup.wMessage.txtMessage, dic["Message"], 0);
                _gLib._VerifySyncUDWin("Yes", this.wIP_Matching_ConfirmAccept_Popup.wYes.btnYes, dic["Yes"], 0);
                _gLib._VerifySyncUDWin("No", this.wIP_Matching_ConfirmAccept_Popup.wNo.btnNo, dic["No"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-DEc-18 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_IP_Matching_RunCurrentStage_Popup(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Matching_RunCurrentStage_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_Matching_RunCurrentStage_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wIP_Matching_RunCurrentStage.wOK.btn, dic["OK"], 0);
                
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wIP_Matching_RunCurrentStage.wOK.btn, dic["OK"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-DEc-18 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_IP_Matching_RunAllStages_Popup(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Matching_RunAllStages_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_Matching_RunAllStages_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wIP_Matching_RunAllStages.wOK.btn, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wIP_Matching_RunAllStages.wOK.btn, dic["OK"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-07 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ImportFilter", "");
        ///    dic.Add("WarehouseFilter", "");
        ///    dic.Add("MatchManually", "");
        ///    dic.Add("FindMatches", "Click");
        ///    pData._PopVerify_IP_Matching(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Matching(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_Matching";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("ImportFilter", this.wRetirementStudio.wIP_Matching_ImportFilter.txt, dic["ImportFilter"], 0);
                _gLib._SetSyncUDWin_ByClipboard("WarehouseFilter", this.wRetirementStudio.wIP_Matching_WarehouseFilter.txt, dic["WarehouseFilter"], 0);
                _gLib._SetSyncUDWin("MatchManually", this.wRetirementStudio.wIP_Matching_MatchManually.btnMatchManually, dic["MatchManually"], 0);
                _gLib._SetSyncUDWin("FindMatches", this.wRetirementStudio.wIP_Matching_FindMatches.btnFindMatches, dic["FindMatches"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("ImportFilter", this.wRetirementStudio.wIP_Matching_ImportFilter.txt, dic["ImportFilter"], 0);
                _gLib._VerifySyncUDWin("WarehouseFilter", this.wRetirementStudio.wIP_Matching_WarehouseFilter.txt, dic["WarehouseFilter"], 0);
                _gLib._VerifySyncUDWin("MatchManually", this.wRetirementStudio.wIP_Matching_MatchManually.btnMatchManually, dic["MatchManually"], 0);
                _gLib._VerifySyncUDWin("FindMatches", this.wRetirementStudio.wIP_Matching_FindMatches.btnFindMatches, dic["FindMatches"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        
        /// <summary>
        /// 2013-May-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_IP_Matching_RunResults_Popup(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("Message", "All 'UniqueNoMatch' records have been accepted");
        ///    dic.Add("OK", "");
        ///    pData._PopVerify_IP_Matching_RunResults_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Matching_RunResults_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_Matching_RunResults_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wIP_Matching_RunResults_Popup.wOK.btnOK, dic["OK"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Message", this.wIP_Matching_RunResults_Popup.wMessage.txtMessage, dic["Message"], 0);
                _gLib._VerifySyncUDWin("OK", this.wIP_Matching_RunResults_Popup.wOK.btnOK, dic["OK"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-7 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("RefreshResults", "");
        ///    dic.Add("UnacceptAllRecords", "");
        ///    dic.Add("UnacceptSelectedRecords", "");
        ///    dic.Add("SaveToWarehouse", "Click");
        ///    dic.Add("MergeDuplicates", "");
        ///    pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("Matched_Num", "0");
        ///    dic.Add("New_Num", "130");
        ///    dic.Add("Ignored_Num", "0");
        ///    dic.Add("Gone_Num", "0");
        ///    dic.Add("Leaver_Num", "0");
        ///    dic.Add("Unmatched_Num", "0");
        ///    dic.Add("Unmerged_Num", "0");
        ///    pData._PopVerify_IP_Matching_AcceptedResultsSummary(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Matching_AcceptedResultsSummary(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_IP_Matching_AcceptedResultsSummary";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("RefreshResults", this.wRetirementStudio.wIP_Matching_RefreshResults.btnRefreshResults, dic["RefreshResults"], 0);
                _gLib._SetSyncUDWin("UnacceptAllRecords", this.wRetirementStudio.wIP_Matching_UnacceptAllRecords.btnUnacceptAllRecords, dic["UnacceptAllRecords"], 0);
                _gLib._SetSyncUDWin("UnacceptSelectedRecords", this.wRetirementStudio.wIP_Matching_UnacceptSelectedRecords.btnUnacceptSelectedRecords, dic["UnacceptSelectedRecords"], 0);
                _gLib._SetSyncUDWin("SaveToWarehouse", this.wRetirementStudio.wIP_Matching_SaveToWarehouse.btnSaveToWarehouse, dic["SaveToWarehouse"], 0);
                _gLib._SetSyncUDWin("MergeDuplicates", this.wRetirementStudio.wIP_Matching_MergeDuplicates.btnMergeDuplicates, dic["MergeDuplicates"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Matched_Num", this.wRetirementStudio.wIP_Matching_AR_Matched_Num.txtMatched, dic["Matched_Num"], 0);
                _gLib._VerifySyncUDWin("New_Num", this.wRetirementStudio.wIP_Matching_AR_New_Num.txtNew, dic["New_Num"], 0);
                _gLib._VerifySyncUDWin("Ignored_Num", this.wRetirementStudio.wIP_Matching_AR_Ignored_Num.txtIgnored, dic["Ignored_Num"], 0);
                _gLib._VerifySyncUDWin("Gone_Num", this.wRetirementStudio.wIP_Matching_AR_Gone_Num.txtGone, dic["Gone_Num"], 0);
                _gLib._VerifySyncUDWin("Leaver_Num", this.wRetirementStudio.wIP_Matching_AR_Leaver_Num.txtLeaver, dic["Leaver_Num"], 0);
                _gLib._VerifySyncUDWin("Unmatched_Num", this.wRetirementStudio.wIP_Matching_AR_Unmatched_Num.txtUnmatched, dic["Unmatched_Num"], 0);
                _gLib._VerifySyncUDWin("Unmerged_Num", this.wRetirementStudio.wIP_Matching_AR_Unmerged_Num.txtUnmerged, dic["Unmerged_Num"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2017-Feb-18 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_IP_Matching_ProcessMatchingResultsContinuePopup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Matching_ProcessMatchingResultsContinuePopup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_Matching_ProcessMatchingResultsContinuePopup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wIP_Matching_ProcessMatchingResultsContinue_Popup.wOK.btn, dic["OK"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Yes", this.wIP_Matching_ProcessMatchingResultsContinue_Popup.wOK.btn, dic["OK"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        
        /// <summary>
        /// 2013-May-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Yes", "Click");
        ///    dic.Add("No", "");
        ///    pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("Message", "Once the matching results have been processed, all the Import parameters for this file will become read-only. Do you wish to proceed?");
        ///    dic.Add("Yes", "");
        ///    dic.Add("No", "");
        ///    pData._PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_Matching_ProcessMatchingResultsConfirm_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Yes", this.wIP_Matching_ProcessMatchingResultsConfirm_Popup.wYes.btnYes, dic["Yes"], 0);
                _gLib._SetSyncUDWin("No", this.wIP_Matching_ProcessMatchingResultsConfirm_Popup.wNo.btnNo, dic["No"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Message", this.wIP_Matching_ProcessMatchingResultsConfirm_Popup.wMessage.txtMessage, dic["Message"], 0);
                _gLib._VerifySyncUDWin("Yes", this.wIP_Matching_ProcessMatchingResultsConfirm_Popup.wYes.btnYes, dic["Yes"], 0);
                _gLib._VerifySyncUDWin("No", this.wIP_Matching_ProcessMatchingResultsConfirm_Popup.wNo.btnNo, dic["No"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        
        /// <summary>
        /// 2013-May-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("Message", "The matching results have now been processed. All the Import parameters for this file are now read-only.");
        ///    dic.Add("OK", "");
        ///    pData._PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_Matching_ProcessMatchingResultsComplete_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._Exists("ProcessMatchingResultsComplete_Popup", this.wIP_Matching_ProcessMatchingResultsComplete_Popup, Config.iTimeout * 3, true);
                _gLib._SetSyncUDWin("OK", this.wIP_Matching_ProcessMatchingResultsComplete_Popup.wOK.btnOK, dic["OK"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Message", this.wIP_Matching_ProcessMatchingResultsComplete_Popup.wMessage.txtMessage, dic["Message"], 0);
                _gLib._VerifySyncUDWin("OK", this.wIP_Matching_ProcessMatchingResultsComplete_Popup.wOK.btnOK, dic["OK"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("DerivationGroupName", "DeriveUSC");
        /// dic.Add("NewVersion", "");
        /// dic.Add("Filter", "");
        /// dic.Add("MoveUp", "");
        /// dic.Add("MoveDown", "");
        /// dic.Add("Add", "Click");
        /// dic.Add("Insert", "");
        /// dic.Add("Delete", "");
        /// dic.Add("AddWorkFields", "");
        /// dic.Add("SelectFieldsForPreview", "");
        /// dic.Add("SelectSampleRecords_Formula", "");
        /// dic.Add("SelectSampleRecords_Accept", "");
        /// dic.Add("SelectSampleRecords_Apply", "");
        /// dic.Add("PrintAll", "");
        /// dic.Add("PrintToFile", "");
        /// dic.Add("CalculateAndPreview", "");
        /// dic.Add("SaveToWarehouse", "");
        /// pData._PopVerify_DerivationGroups(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DerivationGroups(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_DerivationGroups";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("DerivationGroupName", this.wRetirementStudio.wDG_DerivationGroupName.txtDerivationGroupName, dic["DerivationGroupName"], 0);
                _gLib._SetSyncUDWin("NewVersion", this.wRetirementStudio.wDG_NewVersion.btn, dic["NewVersion"], 0);
                _gLib._SetSyncUDWin("Filter", this.wRetirementStudio.wDG_Filter.cboFilter, dic["Filter"], 0);
                _gLib._SetSyncUDWin("MoveUp", this.wRetirementStudio.wDG_MoveUp.btnMoveUp, dic["MoveUp"], 0);
                _gLib._SetSyncUDWin("MoveDown", this.wRetirementStudio.wDG_MoveDown.btnMoveDown, dic["MoveDown"], 0);
                _gLib._SetSyncUDWin("Add", this.wRetirementStudio.wDG_Add.btnAdd, dic["Add"], 0);
                _gLib._SetSyncUDWin("Insert", this.wRetirementStudio.wDG_Insert.btnInsert, dic["Insert"], 0);
                _gLib._SetSyncUDWin("Delete", this.wRetirementStudio.wDG_Delete.btnDelete, dic["Delete"], 0);
                _gLib._SetSyncUDWin("AddWorkFields", this.wRetirementStudio.wDG_AddWorkFields.btnAddWorkFields, dic["AddWorkFields"], 0);
                _gLib._SetSyncUDWin("SelectFieldsForPreview", this.wRetirementStudio.wDG_SelectFieldsForPreview.btnSelectFieldsForPreview, dic["SelectFieldsForPreview"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SelectSampleRecords_Formula", this.wRetirementStudio.wDG_SelectSampleRecords_Formula.txt, dic["SelectSampleRecords_Formula"], 0);
                _gLib._SetSyncUDWin("SelectSampleRecords_Accept", this.wRetirementStudio.wDG_SelectSampleRecords_Accept.btn, dic["SelectSampleRecords_Accept"], 0);
                _gLib._SetSyncUDWin("SelectSampleRecords_Apply", this.wRetirementStudio.wDG_SelectSampleRecords_Apply.btn, dic["SelectSampleRecords_Apply"], 0);
                _gLib._SetSyncUDWin("PrintAll", this.wRetirementStudio.wDG_PrintAll.btn, dic["PrintAll"], 0);
                _gLib._SetSyncUDWin("PrintToFile", this.wRetirementStudio.wDG_PrintToFile.btn, dic["PrintToFile"], 0);
                _gLib._SetSyncUDWin("CalculateAndPreview", this.wRetirementStudio.wDG_CalculateAndPreview.btnCalculateAndPreview, dic["CalculateAndPreview"], 0);
                _gLib._SetSyncUDWin("SaveToWarehouse", this.wRetirementStudio.wDG_SaveToWarehouse.btnSaveToWarehouse, dic["SaveToWarehouse"], 0);


            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("DerivationGroupName", this.wRetirementStudio.wDG_DerivationGroupName.txtDerivationGroupName, dic["DerivationGroupName"], 0);
                _gLib._VerifySyncUDWin("NewVersion", this.wRetirementStudio.wDG_NewVersion.btn, dic["NewVersion"], 0);
                _gLib._VerifySyncUDWin("Filter", this.wRetirementStudio.wDG_Filter.cboFilter, dic["Filter"], 0);
                _gLib._VerifySyncUDWin("MoveUp", this.wRetirementStudio.wDG_MoveUp.btnMoveUp, dic["MoveUp"], 0);
                _gLib._VerifySyncUDWin("MoveDown", this.wRetirementStudio.wDG_MoveDown.btnMoveDown, dic["MoveDown"], 0);
                _gLib._VerifySyncUDWin("Add", this.wRetirementStudio.wDG_Add.btnAdd, dic["Add"], 0);
                _gLib._VerifySyncUDWin("Insert", this.wRetirementStudio.wDG_Insert.btnInsert, dic["Insert"], 0);
                _gLib._VerifySyncUDWin("Delete", this.wRetirementStudio.wDG_Delete.btnDelete, dic["Delete"], 0);
                _gLib._VerifySyncUDWin("AddWorkFields", this.wRetirementStudio.wDG_AddWorkFields.btnAddWorkFields, dic["AddWorkFields"], 0);
                _gLib._VerifySyncUDWin("SelectFieldsForPreview", this.wRetirementStudio.wDG_SelectFieldsForPreview.btnSelectFieldsForPreview, dic["SelectFieldsForPreview"], 0);
                _gLib._VerifySyncUDWin("SelectSampleRecords_Formula", this.wRetirementStudio.wDG_SelectSampleRecords_Formula.txt, dic["SelectSampleRecords_Formula"], 0);
                _gLib._VerifySyncUDWin("SelectSampleRecords_Accept", this.wRetirementStudio.wDG_SelectSampleRecords_Accept.btn, dic["SelectSampleRecords_Accept"], 0);
                _gLib._VerifySyncUDWin("SelectSampleRecords_Apply", this.wRetirementStudio.wDG_SelectSampleRecords_Apply.btn, dic["SelectSampleRecords_Apply"], 0);
                _gLib._VerifySyncUDWin("PrintAll", this.wRetirementStudio.wDG_PrintAll.btn, dic["PrintAll"], 0);
                _gLib._VerifySyncUDWin("PrintToFile", this.wRetirementStudio.wDG_PrintToFile.btn, dic["PrintToFile"], 0);
                _gLib._VerifySyncUDWin("CalculateAndPreview", this.wRetirementStudio.wDG_CalculateAndPreview.btnCalculateAndPreview, dic["CalculateAndPreview"], 0);
                _gLib._VerifySyncUDWin("SaveToWarehouse", this.wRetirementStudio.wDG_SaveToWarehouse.btnSaveToWarehouse, dic["SaveToWarehouse"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        

        /// <summary>
        /// 2013-May-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("Apply", "");
        ///    dic.Add("DerivedField", "USC");
        ///    dic.Add("DerivedField_SearchFromIndex", "3");
        ///    dic.Add("Type", "");
        ///    dic.Add("Edit", "Click");
        ///    pData._DG_DerivationGrid(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("Apply", "False");
        ///    dic.Add("DerivedField", "");
        ///    dic.Add("DerivedField_SearchFromIndex", "");
        ///    dic.Add("Type", "");
        ///    dic.Add("Edit", "");
        ///    pData._DG_DerivationGrid(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _DG_DerivationGrid(MyDictionary dic)
        {
            string sFunctionName = "_DG_DerivationGrid";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            // initialize the grid by click first row
            ////////////Mouse.Click(this.wRetirementStudio.wDG_FPGrid.grid, new Point(8, 25));
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{PageUp}");
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Right}{Right}{Right}{Right}{Enter}{Enter}");
            ////////////Mouse.Click(this.wRetirementStudio.wDG_FPGrid.grid, new Point(8, 25));
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Home}");
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "Click", 0, false, 8, 25);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{PageUp}{PageUp}{PageUp}{Right}{Right}{Right}{Right}{Enter}{Enter}");
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "Click", 0, false, 8, 25);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{Home}");

            if (dic["iRow"] != "") // select the row first, otherwise, rest of codes just work on current row
            {
                int iRow = Convert.ToInt32(dic["iRow"]);
                string sKeys = "";
                for (int i = 1; i < iRow; i++)
                    sKeys = sKeys + "{Down}";
                
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, sKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Down}");

                int iActRow = _fp._ReturnSelectRowIndex(this.wRetirementStudio.wDG_FPGrid.grid)+1;

                if (iRow != iActRow)
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> Failed to select row <" + iRow + ">, actual focus on row <" + iActRow + ">");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Failed to select row <" + iRow + ">, actual focus on row <" + iActRow + ">");
                }
            }

            if (dic["Apply"] != "") 
            {
                string sActValue = _fp._ReturnSelectRowContent(this.wRetirementStudio.wDG_FPGrid.grid);

                if(dic["Apply"].ToString().ToUpper()!=sActValue.ToUpper())
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{Space}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Space}");
                
                sActValue = _fp._ReturnSelectRowContent(this.wRetirementStudio.wDG_FPGrid.grid);

                if (dic["Apply"].ToString().ToUpper() != sActValue.ToUpper())
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> Failed to set Apply value as <" + dic["Apply"] + ">, actual value <" + sActValue + ">");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Failed to set Apply value as <" + dic["Apply"] + ">, actual value <" + sActValue + ">");
                }
            }

            if (dic["DerivedField"] != "")
            {
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Left}{Left}{Left}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Right}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{Left}{Left}{Left}{Right}");

                string sChar = dic["DerivedField"].Substring(0, 1);
                string sCharToSend = "";
                Boolean bSelected = false;
                int iBeginDownNum = 0;
                if (dic["DerivedField_SearchFromIndex"] != "")
                    iBeginDownNum = Convert.ToInt32(dic["DerivedField_SearchFromIndex"]);

                for (int iOuter = 0; iOuter <= 80; iOuter++)
                {
                    sCharToSend = "";
                    // improve the search performance by given start point to search down
                    if (iBeginDownNum != 0)
                    {
                        for (int i = 1; i < iBeginDownNum; i++)
                            sCharToSend = sCharToSend + sChar;
                    }
                    for (int iInner = 0; iInner <= iOuter; iInner++)
                        sCharToSend = sCharToSend + sChar;
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, sCharToSend);
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Left}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Right}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, sCharToSend);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{Left}{Right}");

                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wDG_FPGrid.grid) == dic["DerivedField"])
                    {
                        bSelected = true;
                        break;
                    }

                }
                if (!bSelected)
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> Failed because fail to select Derived Field <" + dic["DerivedField"] + ">");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Failed because fail to select Derived Field <" + dic["DerivedField"] + ">");
                }

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Left}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{Left}");
            }

            if (dic["Type"] != "")
            {
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Left}{Left}{Left}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Right}{Right}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{Left}{Left}{Left}{Right}{Right}");
                string sChar = dic["Type"].Substring(0, 1);
                string sActType = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wDG_FPGrid.grid);

                if (dic["Type"] != sActType)
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, sChar);
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Left}{Right}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, sChar);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{Left}{Right}");
                }
                sActType = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wDG_FPGrid.grid);

                if (dic["Type"] != sActType)
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> Failed because fail to select Type <" + dic["Type"] + ">");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Failed because fail to select Type <" + dic["Type"] + ">");
                }

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Left}{Left}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{Left}{Left}");
            }

            if (dic["Edit"] != "")
            {
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Left}{Left}{Left}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Right}{Right}{Right}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{Left}{Left}{Left}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{Right}{Right}{Right}");
                try
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Space}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{Space}");
                    if (!_gLib._Exists("Derivation Definition", this.wDG_DerivationDefinition, 0, false))
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDG_FPGrid.grid, "{Space}");
                        ////////////Keyboard.SendKeys(this.wRetirementStudio.wDG_FPGrid.grid, "{Space}");

                }
                catch (Exception ex)
                {
                    // do nothing
                }
            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }



        /// <summary>
        /// 2013-May-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Name", "");
        ///    dic.Add("SelectInputFields", "");
        ///    dic.Add("StandardorCustomFilter", "");
        ///    dic.Add("Filter", "");
        ///    dic.Add("Filter_TrueFalse", "");
        ///    dic.Add("CustomExpression", "");
        ///    dic.Add("CustomExpression_Formula", "");
        ///    dic.Add("Formula", "=DeriveUSC(ParticipantStatus_C,PayStatus_C,HealthStatus_C,AliveStatus_C)");
        ///    dic.Add("CustomExpression_Accept", "");
        ///    dic.Add("Previous", "");
        ///    dic.Add("Next", "");
        ///    dic.Add("OK", "");
        ///    pData._PopVerify_DG_DerivationDefinition(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DG_DerivationDefinition(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_DG_DerivationDefinition";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                //////// changed due to DE008 Name string with "+"
                ////////_gLib._SetSyncUDWin("Name", this.wDG_DerivationDefinition.wName.txtName, dic["Name"], 0);
                if (dic["Name"] != "")
                    this.wDG_DerivationDefinition.wName.txtName.Text = String.Empty;
                _gLib._SetSyncUDWin_ByClipboard("Name", this.wDG_DerivationDefinition.wName.txtName, dic["Name"], 0);
               

                _gLib._SetSyncUDWin("SelectInputFields", this.wDG_DerivationDefinition.wSelectInputFields.btnSelectInputFields, dic["SelectInputFields"], 0);
                _gLib._SetSyncUDWin("StandardorCustomFilter", this.wDG_DerivationDefinition.wStandardorCustomFilter.rdStandardorCustomFilter, dic["StandardorCustomFilter"], 0);
                if (dic["Filter"] != "")
                {
                    _gLib._SetSyncUDWin("Filter", this.wDG_DerivationDefinition.wFilter.txtFilter.btnDropDown, "Click", 0);
                    WinCheckBox wChk = new WinCheckBox(this.wIP_Matching_AcceptRecordsAs_Popup.wDerivationDefintion_Filter);
                    wChk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Filter"]);

                    string sFilter_TrueFalse = dic["Filter_TrueFalse"];

                    if (sFilter_TrueFalse == "")
                        sFilter_TrueFalse = "True";

                    _gLib._SetSyncUDWin(dic["Filter"], wChk, sFilter_TrueFalse, 0);
                    _gLib._SetSyncUDWin("", this.wDG_DerivationDefinition.wStandardorCustomFilter.rdStandardorCustomFilter, "Click", 0);

                }
                _gLib._SetSyncUDWin("CustomExpression", this.wDG_DerivationDefinition.wCustomExpression.rdCustomExpression, dic["CustomExpression"], 0);
                //_gLib._SetSyncUDWin("CustomExpression_Formula", this.wDG_DerivationDefinition.wCustomExpression_Formula.txtFormula, dic["CustomExpression_Formula"], 0);
                if (dic["CustomExpression_Formula"] != "")
                {
                    //this.wDG_DerivationDefinition.wFormula.txtFormula.Text = "";
                    Clipboard.Clear();
                    Clipboard.SetText(dic["CustomExpression_Formula"]);
                    ////////////Keyboard.SendKeys(this.wDG_DerivationDefinition.wCustomExpression_Formula.txtFormula, "v", ModifierKeys.Control);
                    _gLib._SendKeysUDWin("CustomExpression_Formula", this.wDG_DerivationDefinition.wCustomExpression_Formula.txtFormula, "v", 0, ModifierKeys.Control, false);
                    _gLib._VerifySyncUDWin("CustomExpression_Formula", this.wDG_DerivationDefinition.wCustomExpression_Formula.txtFormula, dic["CustomExpression_Formula"] + "\r", 0);
                    _gLib._SetSyncUDWin("CustomExpression_Accept", this.wDG_DerivationDefinition.wCustomExpression_Accept.btnAccept, "Click", 0);
                }

                _gLib._SetSyncUDWin("CustomExpression_Accept", this.wDG_DerivationDefinition.wCustomExpression_Accept.btnAccept, dic["CustomExpression_Accept"], 0);

                //_gLib._SetSyncUDWin("Formula", this.wDG_DerivationDefinition.wFormula.txtFormula, dic["Formula"], 0);
                if (dic["Formula"] != "")
                {
                    this.wDG_DerivationDefinition.wFormula.txtFormula.Text = "";
                    Clipboard.Clear();
                    Clipboard.SetText(dic["Formula"]);
                    ////////////Keyboard.SendKeys(this.wDG_DerivationDefinition.wFormula.txtFormula, "v", ModifierKeys.Control);
                    _gLib._SendKeysUDWin("Formula", this.wDG_DerivationDefinition.wFormula.txtFormula, "v", 0, ModifierKeys.Control, false);
                    _gLib._VerifySyncUDWin("Formula", this.wDG_DerivationDefinition.wFormula.txtFormula, dic["Formula"] + "\r", 0);
                    _gLib._SetSyncUDWin("Accept", this.wDG_DerivationDefinition.wAccept.btnAccept, "Click", 0);
                    _gLib._SetSyncUDWin("Accept", this.wDG_DerivationDefinition.wAccept.btnAccept, "Click", 0);
                    
                }

                _gLib._SetSyncUDWin("Previous", this.wDG_DerivationDefinition.wPrevious.btnPrevious, dic["Previous"], 0);
                _gLib._SetSyncUDWin("Next", this.wDG_DerivationDefinition.wNext.btnNext, dic["Next"], 0);
                _gLib._SetSyncUDWin("OK", this.wDG_DerivationDefinition.wOK.btnOK, dic["OK"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Name", this.wDG_DerivationDefinition.wName.txtName, dic["Name"], 0);
                _gLib._VerifySyncUDWin("SelectInputFields", this.wDG_DerivationDefinition.wSelectInputFields.btnSelectInputFields, dic["SelectInputFields"], 0);
                _gLib._VerifySyncUDWin("StandardorCustomFilter", this.wDG_DerivationDefinition.wStandardorCustomFilter.rdStandardorCustomFilter, dic["StandardorCustomFilter"], 0);
                _gLib._VerifySyncUDWin("CustomExpression", this.wDG_DerivationDefinition.wCustomExpression.rdCustomExpression, dic["CustomExpression"], 0);
                _gLib._VerifySyncUDWin("CustomExpression_Formula", this.wDG_DerivationDefinition.wCustomExpression_Formula.txtFormula, dic["CustomExpression_Formula"] + "\r", 0);
                _gLib._VerifySyncUDWin("Formula", this.wDG_DerivationDefinition.wFormula.txtFormula, dic["Formula"], 0);
                _gLib._VerifySyncUDWin("Previous", this.wDG_DerivationDefinition.wPrevious.btnPrevious, dic["Previous"], 0);
                _gLib._VerifySyncUDWin("Next", this.wDG_DerivationDefinition.wNext.btnNext, dic["Next"], 0);
                _gLib._VerifySyncUDWin("OK", this.wDG_DerivationDefinition.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Oct-28 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("StandardorCustomFilter", "");
        ///    dic.Add("Filter", "");
        ///    dic.Add("Filter_TrueFalse", "");
        ///    dic.Add("CustomExpression", "");
        ///    dic.Add("CustomExpression_Formula", "");
        ///    dic.Add("ClientFieldValue", "");
        ///    dic.Add("AdminField", "");
        ///    dic.Add("Value", "");
        ///    dic.Add("Date_V", "");
        ///    dic.Add("Date_D", "");
        ///    dic.Add("Date_cbo_V", "");
        ///    dic.Add("Date_txt_D", "");
        ///    dic.Add("Previous", "");
        ///    dic.Add("Next", "");
        ///    dic.Add("OK", "");
        ///    pData._PopVerify_DG_DerivationDefinition_Extract(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DG_DerivationDefinition_Extract(MyDictionary dic)
        {
 

            string sFunctionName = "_PopVerify_DG_DerivationDefinition_Extract";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("StandardorCustomFilter", this.wDG_DerivationDefinition.wStandardorCustomFilter.rdStandardorCustomFilter, dic["StandardorCustomFilter"], 0);
                if (dic["Filter"] != "")
                {
                    _gLib._SetSyncUDWin("Filter", this.wDG_DerivationDefinition.wFilter.txtFilter.btnDropDown, "Click", 0);
                    WinCheckBox wChk = new WinCheckBox(this.wIP_Matching_AcceptRecordsAs_Popup.wDerivationDefintion_Filter);
                    wChk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Filter"]);

                    string sFilter_TrueFalse = dic["Filter_TrueFalse"];

                    if (sFilter_TrueFalse == "")
                        sFilter_TrueFalse = "True";

                    _gLib._SetSyncUDWin(dic["Filter"], wChk, sFilter_TrueFalse, 0);
                    _gLib._SetSyncUDWin("", this.wDG_DerivationDefinition.wStandardorCustomFilter.rdStandardorCustomFilter, "Click", 0);

                }
                _gLib._SetSyncUDWin("CustomExpression", this.wDG_DerivationDefinition.wCustomExpression.rdCustomExpression, dic["CustomExpression"], 0);
                if (dic["CustomExpression_Formula"] != "")
                {
                    //this.wDG_DerivationDefinition.wFormula.txtFormula.Text = "";
                    Clipboard.Clear();
                    Clipboard.SetText(dic["CustomExpression_Formula"]);
                    ////////////Keyboard.SendKeys(this.wDG_DerivationDefinition.wCustomExpression_Formula.txtFormula, "v", ModifierKeys.Control);
                    _gLib._SendKeysUDWin("CustomExpression_Formula", this.wDG_DerivationDefinition.wCustomExpression_Formula.txtFormula, "v", 0, ModifierKeys.Control, false);
                    _gLib._VerifySyncUDWin("CustomExpression_Formula", this.wDG_DerivationDefinition.wCustomExpression_Formula.txtFormula, dic["CustomExpression_Formula"] + "\r", 0);
                    _gLib._SetSyncUDWin("CustomExpression_Accept", this.wDG_DerivationDefinition.wCustomExpression_Accept.btnAccept, "Click", 0);
                }

                _gLib._SetSyncUDWin("CustomExpression_Accept", this.wDG_DerivationDefinition.wCustomExpression_Accept.btnAccept, dic["CustomExpression_Accept"], 0);


                _gLib._SetSyncUDWin("ClientFieldValue", this.wDG_ExtractDerivationDefinition.wClientFieldValue.txt, dic["ClientFieldValue"], 0);
                _gLib._SetSyncUDWin("AdminField", this.wDG_ExtractDerivationDefinition.wAdminField.cbo, dic["AdminField"], 0);
                _gLib._SetSyncUDWin("Value", this.wDG_ExtractDerivationDefinition.wValue.cbo, dic["Value"], 0);
                _gLib._SetSyncUDWin("Date_V", this.wDG_ExtractDerivationDefinition.wDate_V.btn, dic["Date_V"], 0);
                _gLib._SetSyncUDWin("Date_D", this.wDG_ExtractDerivationDefinition.wDate_D.btn, dic["Date_D"], 0);
                _gLib._SetSyncUDWin("Date_cbo_V", this.wDG_ExtractDerivationDefinition.wDate_cbo_V.cbo, dic["Date_cbo_V"], 0);
                _gLib._SendKeysUDWin_byPaste("Date_txt_D", this.wDG_ExtractDerivationDefinition.wDate_txt_D.txt, dic["Date_txt_D"], 0, true);
                _gLib._SetSyncUDWin("ClientFieldValue", this.wDG_ExtractDerivationDefinition.wClientFieldValue.txt, dic["ClientFieldValue"], 0);

                _gLib._SetSyncUDWin("Previous", this.wDG_DerivationDefinition.wPrevious.btnPrevious, dic["Previous"], 0);
                _gLib._SetSyncUDWin("Next", this.wDG_DerivationDefinition.wNext.btnNext, dic["Next"], 0);
                _gLib._SetSyncUDWin("OK", this.wDG_DerivationDefinition.wOK.btnOK, dic["OK"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Name", this.wDG_DerivationDefinition.wName.txtName, dic["Name"], 0);
                _gLib._VerifySyncUDWin("SelectInputFields", this.wDG_DerivationDefinition.wSelectInputFields.btnSelectInputFields, dic["SelectInputFields"], 0);
                _gLib._VerifySyncUDWin("StandardorCustomFilter", this.wDG_DerivationDefinition.wStandardorCustomFilter.rdStandardorCustomFilter, dic["StandardorCustomFilter"], 0);
                _gLib._VerifySyncUDWin("CustomExpression", this.wDG_DerivationDefinition.wCustomExpression.rdCustomExpression, dic["CustomExpression"], 0);
                _gLib._VerifySyncUDWin("CustomExpression_Formula", this.wDG_DerivationDefinition.wCustomExpression_Formula.txtFormula, dic["CustomExpression_Formula"] + "\r", 0);
                _gLib._VerifySyncUDWin("ClientFieldValue", this.wDG_ExtractDerivationDefinition.wClientFieldValue.txt, dic["ClientFieldValue"], 0);
                _gLib._VerifySyncUDWin("AdminField", this.wDG_ExtractDerivationDefinition.wAdminField.cbo, dic["AdminField"], 0);
                _gLib._VerifySyncUDWin("Value", this.wDG_ExtractDerivationDefinition.wValue.cbo, dic["Value"], 0);
                _gLib._VerifySyncUDWin("Date_V", this.wDG_ExtractDerivationDefinition.wDate_V.btn, dic["Date_V"], 0);
                _gLib._VerifySyncUDWin("Date_D", this.wDG_ExtractDerivationDefinition.wDate_D.btn, dic["Date_D"], 0);
                _gLib._VerifySyncUDWin("Date_cbo_V", this.wDG_ExtractDerivationDefinition.wDate_cbo_V.cbo, dic["Date_cbo_V"], 0);
                _gLib._VerifySyncUDWin("Date_txt_D", this.wDG_ExtractDerivationDefinition.wDate_txt_D.txt, dic["Date_txt_D"], 0);

                _gLib._VerifySyncUDWin("Previous", this.wDG_DerivationDefinition.wPrevious.btnPrevious, dic["Previous"], 0);
                _gLib._VerifySyncUDWin("Next", this.wDG_DerivationDefinition.wNext.btnNext, dic["Next"], 0);
                _gLib._VerifySyncUDWin("OK", this.wDG_DerivationDefinition.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2013-Aug-08 
        /// webber.ling@mercer.com
        /// 
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("iCol", "6");
        ///    dic.Add("sData", "Age");
        ///    dic.Add("sFormula", "");
        ///    dic.Add("sRange", "");
        ///    dic.Add("bVerify", "");
        ///    dic.Add("bTable", "");
        ///    pData._DG_DerivationDefinition_Grid(dic); 
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("iCol", "1");
        ///    dic.Add("sData", "");
        ///    dic.Add("sFormula", "");
        ///    dic.Add("sRange", "Test");
        ///    dic.Add("bVerify", "");
        ///    dic.Add("bTable", "");
        ///    pData._DG_DerivationDefinition_Grid(dic); 
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("iCol", "5");
        ///    dic.Add("sData", "");
        ///    dic.Add("sFormula", "=Table(");
        ///    dic.Add("sRange", "");
        ///    dic.Add("bVerify", "");
        ///    dic.Add("bTable", "True");
        ///    pData._DG_DerivationDefinition_Grid(dic); 
        /// </summary>
        /// <param name="sOriginal"></param>
        /// <param name="sNew"></param>
        public void _DG_DerivationDefinition_Grid(MyDictionary dic)
        {
            string sFunctionName = "_DG_DerivationDefinition_Grid";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sKeys = "";
            string sAct = "";
            int xPos = 40;
            int yPos = 30;
            int iRow = Convert.ToInt32(dic["iRow"]);
            int iCol = Convert.ToInt32(dic["iCol"]);
            bool bTable = false;

            if (dic["bTable"].ToUpper().Equals("TRUE"))
                bTable = true;


            this._DG_DerivationDefinition_Grid_Navigate(xPos, yPos, iRow, iCol);

            if (dic["sData"] != "")
            {
                sKeys = dic["sData"] + "{Enter}";
                ////////////Keyboard.SendKeys(this.wDG_DerivationDefinition.wFPGrid.grid, sKeys);
                _gLib._SendKeysUDWin("FPGrid", this.wDG_DerivationDefinition.wFPGrid.grid, sKeys);


                if (dic["bVerify"].ToUpper() != "FALSE")
                {
                    this._DG_DerivationDefinition_Grid_Navigate(xPos, yPos, iRow, iCol);
                    sAct = _fp._ReturnSelectRowContent(this.wDG_DerivationDefinition.wFPGrid.grid);

                    if (sAct != dic["sData"])
                    {
                        _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed to set data <" + dic["sData"] + "> at Row  <" + iRow + ">,  column <" + iCol + ">, actual <" + sAct + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to set data <" + dic["sData"] + "> at Row  <" + iRow + ">,  column <" + iCol + ">, actual <" + sAct + ">");
                    }
                }

            }

            if (dic["sFormula"] != "")
            {

                this.wDG_DerivationDefinition.wFormula.txtFormula.Text = "";
                Clipboard.Clear();
                Clipboard.SetText(dic["sFormula"]);
                ////////////Keyboard.SendKeys(this.wDG_DerivationDefinition.wFormula.txtFormula, "v", ModifierKeys.Control);
                _gLib._SendKeysUDWin("sFormula", this.wDG_DerivationDefinition.wFormula.txtFormula, "v", 0, ModifierKeys.Control, false);
                if(!bTable)
                { 
                    _gLib._VerifySyncUDWin("Formula", this.wDG_DerivationDefinition.wFormula.txtFormula, dic["sFormula"] + "\r", 0);
                    _gLib._SetSyncUDWin("Accept", this.wDG_DerivationDefinition.wAccept.btnAccept, "Click", 0);
                    _gLib._SetSyncUDWin("Accept", this.wDG_DerivationDefinition.wAccept.btnAccept, "Click", 0);
                }

            }
            

            if (dic["sRange"] != "")
            {
                _gLib._SetSyncUDWin("Range", this.wDG_DerivationDefinition.wRange.txtRange, dic["sRange"], 0);
                _gLib._SendKeysUDWin("Range", this.wDG_DerivationDefinition.wRange.txtRange, "{Enter}");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends");
        }

        /// <summary>
        /// 2013-Sep-18 
        /// webber.ling@mercer.com
        /// 
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "4");
        ///    dic.Add("iCol", "2");
        ///    dic.Add("sLabel", "Service - Months");
        ///    dic.Add("sData", "1");
        ///    pData._DG_DerivationDefinition_Grid_Date(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "4");
        ///    dic.Add("iCol", "2");
        ///    dic.Add("sLabel", "Service - Months");
        ///    dic.Add("sData", "Delete");
        ///    pData._DG_DerivationDefinition_Grid_Date(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "4");
        ///    dic.Add("iCol", "2");
        ///    dic.Add("sLabel", "Service - Months");
        ///    dic.Add("sData", "1/1/2013");
        ///    pData._DG_DerivationDefinition_Grid_Date(dic); 
        /// </summary>
        public void _DG_DerivationDefinition_Grid_Date(MyDictionary dic)
        {
            string sFunctionName = "_DG_DerivationDefinition_Grid_Date";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Boolean bValueSet = false;
            int xPos = 40;
            int yPos = 30;
            int iRow = Convert.ToInt32(dic["iRow"]);
            int iCol = Convert.ToInt32(dic["iCol"]);


            this._DG_DerivationDefinition_Grid_Navigate(xPos, yPos, iRow, iCol, dic["sLabel"]);

            if (dic["sData"].ToUpper().Equals("DELETE"))
            {
                Clipboard.Clear();
                Clipboard.SetText(" ");
                _gLib._Wait(0.5);
                _gLib._SendKeysUDWin("sData", this.wDG_DerivationDefinition.wFPGrid.grid, "V", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("sData", this.wDG_DerivationDefinition.wFPGrid.grid, "V", 0, ModifierKeys.Control, false);
                if (this._fp._ReturnSelectRowContent(this.wDG_DerivationDefinition.wFPGrid.grid) == "")
                    bValueSet = true;
            }
            else 
            { 
                Clipboard.Clear();
                Clipboard.SetText(dic["sData"]);
                _gLib._Wait(0.5);
                ////////////Keyboard.SendKeys(this.wDG_DerivationDefinition.wFPGrid.grid, "V", ModifierKeys.Control);
                ////////////Keyboard.SendKeys(this.wDG_DerivationDefinition.wFPGrid.grid, "V", ModifierKeys.Control);
                _gLib._SendKeysUDWin("sData", this.wDG_DerivationDefinition.wFPGrid.grid, "V", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("sData", this.wDG_DerivationDefinition.wFPGrid.grid, "V", 0, ModifierKeys.Control, false);
                if (this._fp._ReturnSelectRowContent(this.wDG_DerivationDefinition.wFPGrid.grid) == dic["sData"])
                    bValueSet = true;
            }

            #region poor codes 

            //int value;
            //if (int.TryParse(dic["sData"], out value))
            //{
            //    int len = dic["sData"].Length;
            //    for (int i = 0; i < len; i++)
            //    {
            //        string sChar = dic["sData"].Substring(i,1);
            //        Keyboard.SendKeys(this.wDG_DerivationDefinition.wFPGrid.grid, sChar);
            //        Keyboard.SendKeys(this.wDG_DerivationDefinition.wFPGrid.grid, "{Left}{Right}");
            //    }

            //    if (this._fp._ReturnSelectRowContent(this.wDG_DerivationDefinition.wFPGrid.grid) == dic["sData"])
            //    {
            //        bValueSet = true;
            //    }
            //}
            //else
            //{

            //    string sChar = dic["sData"].Substring(0, 1);
            //    for (int iOuter = 0; iOuter <= 10; iOuter++)
            //    {
            //        Keyboard.SendKeys(this.wDG_DerivationDefinition.wFPGrid.grid, sChar);
            //        Keyboard.SendKeys(this.wDG_DerivationDefinition.wFPGrid.grid, "{Left}{Right}");

            //        if (this._fp._ReturnSelectRowContent(this.wDG_DerivationDefinition.wFPGrid.grid) == dic["sData"])
            //        {
            //            bValueSet = true;
            //            break;
            //        }

            //    }
            //}

            #endregion



            if (!bValueSet)
            {
                _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed to set data <" + dic["sData"] + "> at Row  <" + iRow + ">,  column <" + iCol + ">, for label <" + dic["sLabel"] + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to set data <" + dic["sData"] + "> at Row  <" + iRow + ">,  column <" + iCol + ">, for label <" + dic["sLabel"] + ">");
            }

 


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends");
        }


        private void _DG_DerivationDefinition_Grid_Navigate(int iStart_X, int iStart_Y, int iRow, int iCol)
        {

            this._fp._ClickFirstRow(this.wDG_DerivationDefinition.wFPGrid.grid, iStart_X, iStart_Y);
            ////////////Keyboard.SendKeys(this.wDG_DerivationDefinition.wFPGrid.grid, "{Home}{PageUp}{PageUp}{PageUp}");
            _gLib._SendKeysUDWin("FPGrid", this.wDG_DerivationDefinition.wFPGrid.grid, "{Home}{PageUp}{PageUp}{PageUp}");


            string sKeys = "";
            for (int i = 0; i < iRow - 1; i++)
                sKeys = sKeys + "{Down}";
            for (int i = 0; i < iCol - 1; i++)
                sKeys = sKeys + "{Right}";


            ////////////Keyboard.SendKeys(this.wDG_DerivationDefinition.wFPGrid.grid, sKeys);
            _gLib._SendKeysUDWin("FPGrid", this.wDG_DerivationDefinition.wFPGrid.grid, sKeys);
        }


        private void _DG_DerivationDefinition_Grid_Navigate(int iStart_X, int iStart_Y, int iRow, int iCol, string sVerifyString)
        {
            string sFunctionName = "_DG_DerivationDefinition_Grid_Navigate";

            this._fp._ClickFirstRow(this.wDG_DerivationDefinition.wFPGrid.grid, iStart_X, iStart_Y);
            ////////////Keyboard.SendKeys(this.wDG_DerivationDefinition.wFPGrid.grid, "{Home}{PageUp}{PageUp}{PageUp}");
            _gLib._SendKeysUDWin("FPGrid", this.wDG_DerivationDefinition.wFPGrid.grid, "{Home}{PageUp}{PageUp}{PageUp}");
            string sKeys = "";
            for (int i = 0; i < iRow - 1; i++)
                sKeys = sKeys + "{Down}";
            for (int i = 0; i < iCol - 1; i++)
                sKeys = sKeys + "{Right}";


            ////////////Keyboard.SendKeys(this.wDG_DerivationDefinition.wFPGrid.grid, sKeys+"{Left}");
            _gLib._SendKeysUDWin("FPGrid", this.wDG_DerivationDefinition.wFPGrid.grid, sKeys + "{Left}");

            string sActString = _fp._ReturnSelectRowContent(this.wDG_DerivationDefinition.wFPGrid.grid);
            if (sActString != sVerifyString)
            {
                _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed to verify data <" + sVerifyString + "> at Row  <" + iRow + ">,  column <" + iCol + ">, actual <" + sActString + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to verify data <" + sVerifyString + "> at Row  <" + iRow + ">,  column <" + iCol + ">, actual <" + sActString + ">");
            }
            ////////////Keyboard.SendKeys(this.wDG_DerivationDefinition.wFPGrid.grid, "{Right}");
            _gLib._SendKeysUDWin("FPGrid", this.wDG_DerivationDefinition.wFPGrid.grid, "{Right}");
        }


        /// <summary>
        /// 2013-May-8 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Include all");
        ///    dic.Add("Level_2", "Personal Information");
        ///    dic.Add("Level_3", "EmployeeIDNumber");
        ///    pData._TreeViewSelect_SelectInputFields_CurrentView(dic, true, false);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewSelect_SelectInputFields_CurrentView(MyDictionary dic, Boolean bChecked, Boolean bCloseDialog)
        {
            string sFunctionName = "_TreeViewSelect_SelectInputFields_CurrentView";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewCheckBoxSelectWin(0, this.wSelectInputFields.wTreeViewCurrent.tvCurrentView, dic, bChecked);

            if (bCloseDialog)
                _gLib._SetSyncUDWin("OK", this.wSelectInputFields.wOK.btnOK, "Click", 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-July-18 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Include all");
        ///    dic.Add("Level_2", "Personal Information");
        ///    dic.Add("Level_3", "EmployeeIDNumber");
        ///    pData._TreeViewSelect_SelectInputFields_PriorView(dic, true, false);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewSelect_SelectInputFields_PriorView(MyDictionary dic, Boolean bChecked, Boolean bCloseDialog)
        {
            string sFunctionName = "_TreeViewSelect_SelectInputFields_PriorView";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewCheckBoxSelectWin(0, this.wSelectInputFields.wTreeViewPrevious.tvPriorView, dic, bChecked);

            if (bCloseDialog)
                _gLib._SetSyncUDWin("OK", this.wSelectInputFields.wOK.btnOK, "Click", 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Oct-18 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Include all");
        ///    dic.Add("Level_2", "Personal Information");
        ///    dic.Add("Level_3", "EmployeeIDNumber");
        ///    pData._TreeViewSelect_SelectInputFields_StandardInput(dic, true, false);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewSelect_SelectInputFields_StandardInput(MyDictionary dic, Boolean bChecked, Boolean bCloseDialog)
        {
            string sFunctionName = "_TreeViewSelect_SelectInputFields_StandardInput";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewCheckBoxSelectWin(0, this.wSelectInputFields.wTreeViewStandardInput, dic, bChecked);

            if (bCloseDialog)
                _gLib._SetSyncUDWin("OK", this.wSelectInputFields.wOK.btnOK, "Click", 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DG_SaveDerivedValuesToWarehouse_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_DG_SaveDerivedValuesToWarehouse_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wDG_SaveDerivedValuesToWarehouse_Popup.wOK.btnOK, dic["OK"], 0);
                if (dic["OK"]!="")
                { 
                    _gLib._Wait(1);
                    ////////if ( _gLib._Enabled("", this.wDG_SaveDerivedValuesToWarehouse_Popup.wOK, 1) )
                    ////////    _gLib._SetSyncUDWin("OK", this.wDG_SaveDerivedValuesToWarehouse_Popup.wOK.btnOK, dic["OK"], 0);
                    _gLib._Enabled("", this.wRetirementStudio.wDG_Add, Config.iTimeout);
                }
  
                

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wDG_SaveDerivedValuesToWarehouse_Popup.wOK.btnOK, dic["OK"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Oct-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Yes", "Click");
        ///    pData._PopVerify_Undo_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Undo_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_Undo_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Yes", this.wUndo_Popup.wYes.btn, dic["Yes"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Yes", this.wUndo_Popup.wYes.btn, dic["Yes"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }
        
        /// <summary>
        /// 2013-May-10 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("SnapshotName", "Valuation Data");
        /// dic.Add("Filter", "Active Member");
        /// dic.Add("UseLatestDate", "");
        /// dic.Add("Preview", "");
        /// dic.Add("Preview_Next", "");
        /// dic.Add("Preview_Last", "");
        /// dic.Add("PublishSnapshot", "");
        /// dic.Add("CreateExtract", "");
        /// dic.Add("CheckPopup", "");
        /// pData._PopVerify_Snapshots(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Snapshots(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_Snapshots";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("SnapshotName", this.wRetirementStudio.wSP_SnapshotName.txtSnapshotName, dic["SnapshotName"], 0);
                if (dic["Filter"] != "")
                {
                    _gLib._SetSyncUDWin("Filter", this.wRetirementStudio.wSP_Filter.btn.btnDropDown, "Click", 0);
                    WinCheckBox wChk = new WinCheckBox(this.wIP_Matching_AcceptRecordsAs_Popup.wDerivationDefintion_Filter);
                    wChk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Filter"]);
                    _gLib._SetSyncUDWin(dic["Filter"], wChk, "True", 0);
                    //////_gLib._SetSyncUDWin("", this.wRetirementStudio., "Click", 0);



                }
                _gLib._SetSyncUDWin("UseLatestDate", this.wRetirementStudio.wSP_UseLatestDate.chkUseLatestDate, dic["UseLatestDate"], 0);
                _gLib._SetSyncUDWin("Preview", this.wRetirementStudio.wSP_Preview.btnPreview, dic["Preview"], 0);
                _gLib._SetSyncUDWin("Preview_Next", this.wRetirementStudio.wSP_Preview_Next.txt.link, dic["Preview_Next"], 0);
                _gLib._SetSyncUDWin("Preview_Last", this.wRetirementStudio.wSP_Preview_Last.txt.link, dic["Preview_Last"], 0);


                if (dic["Preview"] != "" && _gLib._Exists("Confrim", this.wConfirm_Popup, 1, false))
                {
                    MyDictionary tmpDic = new MyDictionary();
                    tmpDic.Clear();
                    tmpDic.Add("PopVerify", "Pop");
                    tmpDic.Add("Yes", "click");
                    this._PopVerify_Confirm_Popup(tmpDic);
                    _gLib._Wait(1);
                }
                _gLib._SetSyncUDWin("PublishSnapshot", this.wRetirementStudio.wSP_PublishSnapshot.btnPublishSnapshot, dic["PublishSnapshot"], 0);
                if (dic["PublishSnapshot"] != "" && _gLib._Exists("Confrim", this.wConfirm_Popup, 1, false) && dic["CheckPopup"] != "")
                {
                    MyDictionary tmpDic = new MyDictionary();
                    tmpDic.Clear();
                    tmpDic.Add("PopVerify", "Pop");
                    tmpDic.Add("Yes", "click");
                    this._PopVerify_Confirm_Popup(tmpDic); 
                }
                _gLib._SetSyncUDWin("CreateExtract", this.wRetirementStudio.wSP_CreateExtract.btnCreateExtract, dic["CreateExtract"], 0);


            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("SnapshotName", this.wRetirementStudio.wSP_SnapshotName.txtSnapshotName, dic["SnapshotName"], 0);
                _gLib._VerifySyncUDWin("UseLatestDate", this.wRetirementStudio.wSP_UseLatestDate.chkUseLatestDate, dic["UseLatestDate"], 0);
                _gLib._VerifySyncUDWin("Preview", this.wRetirementStudio.wSP_Preview.btnPreview, dic["Preview"], 0);
                _gLib._VerifySyncUDWin("PublishSnapshot", this.wRetirementStudio.wSP_PublishSnapshot.btnPublishSnapshot, dic["PublishSnapshot"], 0);
                _gLib._VerifySyncUDWin("CreateExtract", this.wRetirementStudio.wSP_CreateExtract.btnCreateExtract, dic["CreateExtract"], 0);
                _gLib._VerifySyncUDWin("Preview_Next", this.wRetirementStudio.wSP_Preview_Next.txt.link, dic["Preview_Next"], 0);
                _gLib._VerifySyncUDWin("Preview_Last", this.wRetirementStudio.wSP_Preview_Last.txt.link, dic["Preview_Last"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-10
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Include all");
        ///    dic.Add("Level_2", "Personal Information");
        ///    dic.Add("Level_3", "EmployeeIDNumber");
        ///    pData._TreeViewSelect_Snapshots(dic, true);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewSelect_Snapshots(MyDictionary dic, Boolean bChecked)
        {
            string sFunctionName = "_TreeViewSelect_Snapshots";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewCheckBoxSelectWin(0, this.wRetirementStudio.wSP_TreeViewCurrent.tvCurrentView, dic, bChecked);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2015-Oct-10
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Include all");
        ///    dic.Add("Level_2", "Personal Information");
        ///    dic.Add("Level_3", "EmployeeIDNumber");
        ///    pData._TreeViewSelect_Snapshots_PriorView(dic, true);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewSelect_Snapshots_PriorView(MyDictionary dic, Boolean bChecked)
        {
            string sFunctionName = "_TreeViewSelect_Snapshots_PriorView";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewCheckBoxSelectWin(0, this.wRetirementStudio.wSP_TreeViewPrior.tvPriorView, dic, bChecked);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-10 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "click");
        ///    pData._PopVerify_SP_Snapshots_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SP_Snapshots_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_SP_Snapshots_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wSP_Snapshot_Popup.wOK.btnOK, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wSP_Snapshot_Popup.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2014-July-10 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Yes", "click");
        ///    dic.Add("OK", "");
        ///    pData._PopVerify_Confirm_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Confirm_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_Confirm_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Yes", this.wConfirm_Popup.wYes.btn, dic["Yes"], 0);
                _gLib._SetSyncUDWin("OK", this.wConfirm_Popup.wOK.btn, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Yes", this.wConfirm_Popup.wYes.btn, dic["Yes"], 0);
                _gLib._VerifySyncUDWin("OK", this.wConfirm_Popup.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-Sep-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Yes", "click");
        ///    pData._PopVerify_SP_RePublishSnapshot_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SP_RePublishSnapshot_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_SP_RePublishSnapshot_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Yes", this.wSP_RepublishSnapshot.wYes.btnYes, dic["Yes"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Yes", this.wSP_RepublishSnapshot.wYes.btnYes, dic["Yes"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("StandardInputs", "Click");
        /// dic.Add("AddCustomGroup", "");
        /// dic.Add("AddCheck", "");
        /// dic.Add("ApplyChecks", "");
        /// dic.Add("ClearAllResults", "");
        /// dic.Add("AllQuery", "");
        /// dic.Add("AllPlug", "");
        /// dic.Add("AllOK", "");
        /// dic.Add("Notes", "");
        /// pData._PopVerify_Checks(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Checks(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_Checks";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("StandardInputs", this.wRetirementStudio.wCK_StandardInputs.btnStandardInputs, dic["StandardInputs"], 0);
                _gLib._SetSyncUDWin("AddCustomGroup", this.wRetirementStudio.wCK_AddCustomGroup.btnAddCustomGroup, dic["AddCustomGroup"], 0);
                _gLib._SetSyncUDWin("AddCheck", this.wRetirementStudio.wCK_AddCheck.btnAddCheck, dic["AddCheck"], 0);
                _gLib._SetSyncUDWin("ApplyChecks", this.wRetirementStudio.wCK_ApplyChecks.btnApplyChecks, dic["ApplyChecks"], 0);
                if (dic["ApplyChecks"] != "")
                {
                    if (_gLib._Exists("OK", this.wCK_Warning_Popup.wOK.btn, 2, false))
                        _gLib._SetSyncUDWin("OK", this.wCK_Warning_Popup.wOK.btn, "Click", 0);

                    if(_gLib._Exists("Save", this.wCK_Checks_Popup, 2, false))
                        _gLib._SetSyncUDWin("Yes", this.wCK_Checks_Popup.wYes.btnYes, "Click", 0);
                }
                _gLib._SetSyncUDWin("ClearAllResults", this.wRetirementStudio.wCK_ClearAllResults.btnClearAllResults, dic["ClearAllResults"], 0);
                _gLib._SetSyncUDWin("AllQuery", this.wRetirementStudio.wCK_AllQuery.rdAllQuery, dic["AllQuery"], 0);
                _gLib._SetSyncUDWin("AllPlug", this.wRetirementStudio.wCK_AllPlug.rdAllPlug, dic["AllPlug"], 0);
                _gLib._SetSyncUDWin("AllOK", this.wRetirementStudio.wCK_AllOK.rdAllOK, dic["AllOK"], 0);
                _gLib._SetSyncUDWin("Notes", this.wRetirementStudio.wCK_Notes.txtNotes, dic["Notes"], 0);


            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("StandardInputs", this.wRetirementStudio.wCK_StandardInputs.btnStandardInputs, dic["StandardInputs"], 0);
                _gLib._VerifySyncUDWin("AddCustomGroup", this.wRetirementStudio.wCK_AddCustomGroup.btnAddCustomGroup, dic["AddCustomGroup"], 0);
                _gLib._VerifySyncUDWin("AddCheck", this.wRetirementStudio.wCK_AddCheck.btnAddCheck, dic["AddCheck"], 0);
                _gLib._VerifySyncUDWin("ApplyChecks", this.wRetirementStudio.wCK_ApplyChecks.btnApplyChecks, dic["ApplyChecks"], 0);
                _gLib._VerifySyncUDWin("ClearAllResults", this.wRetirementStudio.wCK_ClearAllResults.btnClearAllResults, dic["ClearAllResults"], 0);
                _gLib._VerifySyncUDWin("AllQuery", this.wRetirementStudio.wCK_AllQuery.rdAllQuery, dic["AllQuery"], 0);
                _gLib._VerifySyncUDWin("AllPlug", this.wRetirementStudio.wCK_AllPlug.rdAllPlug, dic["AllPlug"], 0);
                _gLib._VerifySyncUDWin("AllOK", this.wRetirementStudio.wCK_AllOK.rdAllOK, dic["AllOK"], 0);
                _gLib._VerifySyncUDWin("Notes", this.wRetirementStudio.wCK_Notes.txtNotes, dic["Notes"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Aug-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("NewGroupName", "Conversion Checks");
        /// dic.Add("OK", "Click");
        /// dic.Add("Cancel", "");
        /// pData._PopVerify_Checks_AddCustomGroup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Checks_AddCustomGroup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_Checks_AddCustomGroup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("NewGroupName", this.wCK_AddCustomGroup.wNewGroupName.txtNewGroupName, dic["NewGroupName"], 0);
                _gLib._SetSyncUDWin("OK", this.wCK_AddCustomGroup.wOK.btnOK, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wCK_AddCustomGroup.wCancel.btnCancel, dic["Cancel"], 0);
                

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("NewGroupName", this.wCK_AddCustomGroup.wNewGroupName.txtNewGroupName, dic["NewGroupName"], 0);
                _gLib._VerifySyncUDWin("OK", this.wCK_AddCustomGroup.wOK.btnOK, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wCK_AddCustomGroup.wCancel.btnCancel, dic["Cancel"], 0);
   
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-12 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("Pay_C", "");
        /// dic.Add("Pay_P", "");
        /// dic.Add("AccruedBenefit_C", "");
        /// dic.Add("AccruedBenefit_P", "");
        /// dic.Add("CashBalanceBenefit_C", "");
        /// dic.Add("CashBalanceBenefit_P", "");
        /// dic.Add("BenefitService_C", "BenService_C");
        /// dic.Add("BenefitService_P", "");
        /// dic.Add("VestingService_C", "VestService_C");
        /// dic.Add("VestingService_P", "");
        /// dic.Add("Hours_C", "");
        /// dic.Add("Hours_P", "");
        /// dic.Add("InactiveBenefit_C", "");
        /// dic.Add("InactiveBenefit_P", "");
        /// dic.Add("StartDate_C", "");
        /// dic.Add("StartDate_P", "");
        /// dic.Add("HireDate_C", "");
        /// dic.Add("HireDate_P", "");
        /// dic.Add("MembershipDate_C", "MembershipDate1_C");
        /// dic.Add("MembershipDate_P", "#1#");
        /// dic.Add("TerminationDate_C", "");
        /// dic.Add("PaymentForm_C", "");
        /// dic.Add("PaymentForm_P", "");
        /// dic.Add("YearsCertain_C", "");
        /// dic.Add("YearsCertain_P", "");
        /// dic.Add("BeneficiaryPercent_C", "");
        /// dic.Add("BeneficiaryPercent_P", "");
        /// dic.Add("OK", "");
        /// pData._PopVerify_CK_StandardInputs_Part1(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CK_StandardInputs_Part1(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_CK_StandardInputs_Part1";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Pay_C", this.wCK_StandardInputs.wPay_C.cboPay_C, dic["Pay_C"], 0);
                _gLib._SetSyncUDWin("Pay_P", this.wCK_StandardInputs.wPay_P.cboPay_P, dic["Pay_P"], 0);
                _gLib._SetSyncUDWin("AccruedBenefit_C", this.wCK_StandardInputs.wAccruedBenefit_C.cboAccruedBenefit_C, dic["AccruedBenefit_C"], 0);
                _gLib._SetSyncUDWin("AccruedBenefit_P", this.wCK_StandardInputs.wAccruedBenefit_P.cboAccruedBenefit_P, dic["AccruedBenefit_P"], 0);
                _gLib._SetSyncUDWin("CashBalanceBenefit_C", this.wCK_StandardInputs.wCashBalanceBenefit_C.cboCashBalanceBenefit_C, dic["CashBalanceBenefit_C"], 0);
                _gLib._SetSyncUDWin("CashBalanceBenefit_P", this.wCK_StandardInputs.wCashBalanceBenefit_P.cboCashBalanceBenefit_P, dic["CashBalanceBenefit_P"], 0);
                _gLib._SetSyncUDWin("BenefitService_C", this.wCK_StandardInputs.wBenefitService_C.cboBenefitService_C, dic["BenefitService_C"], 0);
                _gLib._SetSyncUDWin("BenefitService_P", this.wCK_StandardInputs.wBenefitService_P.cboBenefitService_P, dic["BenefitService_P"], 0);
                _gLib._SetSyncUDWin("VestingService_C", this.wCK_StandardInputs.wVestingService_C.cboVestingService_C, dic["VestingService_C"], 0);
                _gLib._SetSyncUDWin("VestingService_P", this.wCK_StandardInputs.wVestingService_P.cboVestingService_P, dic["VestingService_P"], 0);
                _gLib._SetSyncUDWin("Hours_C", this.wCK_StandardInputs.wHours_C.cboHours_C, dic["Hours_C"], 0);
                _gLib._SetSyncUDWin("Hours_P", this.wCK_StandardInputs.wHours_P.cboHours_P, dic["Hours_P"], 0);
                _gLib._SetSyncUDWin("InactiveBenefit_C", this.wCK_StandardInputs.wInactiveBenefit_C.cboInactiveBenefit_C, dic["InactiveBenefit_C"], 0);
                _gLib._SetSyncUDWin("InactiveBenefit_P", this.wCK_StandardInputs.wInactiveBenefit_P.cboInactiveBenefit_P, dic["InactiveBenefit_P"], 0);
                _gLib._SetSyncUDWin("StartDate_C", this.wCK_StandardInputs.wStartDate_C.cboStartDate_C, dic["StartDate_C"], 0);
                _gLib._SetSyncUDWin("StartDate_P", this.wCK_StandardInputs.wStartDate_P.cboStartDate_P, dic["StartDate_P"], 0);
                _gLib._SetSyncUDWin("HireDate_C", this.wCK_StandardInputs.wHireDate_C.cboHireDate_C, dic["HireDate_C"], 0);
                _gLib._SetSyncUDWin("HireDate_P", this.wCK_StandardInputs.wHireDate_P.cboHireDate_P, dic["HireDate_P"], 0);
                _gLib._SetSyncUDWin("MembershipDate_C", this.wCK_StandardInputs.wMembershipDate_C.cboMembershipDate_C, dic["MembershipDate_C"], 0);
                _gLib._SetSyncUDWin("MembershipDate_P", this.wCK_StandardInputs.wMembershipDate_P.cboMembershipDate_P, dic["MembershipDate_P"], 0);
                _gLib._SetSyncUDWin("TerminationDate_C", this.wCK_StandardInputs.wTerminationDate_C.cboTerminationDate_C, dic["TerminationDate_C"], 0);
                _gLib._SetSyncUDWin("PaymentForm_C", this.wCK_StandardInputs.wPaymentForm_C.cboPaymentForm_C, dic["PaymentForm_C"], 0);
                _gLib._SetSyncUDWin("PaymentForm_P", this.wCK_StandardInputs.wPaymentForm_P.cboPaymentForm_P, dic["PaymentForm_P"], 0);
                _gLib._SetSyncUDWin("YearsCertain_C", this.wCK_StandardInputs.wYearsCertain_C.cboYearsCertain_C, dic["YearsCertain_C"], 0);
                _gLib._SetSyncUDWin("YearsCertain_P", this.wCK_StandardInputs.wYearsCertain_P.cboYearsCertain_P, dic["YearsCertain_P"], 0);
                _gLib._SetSyncUDWin("BeneficiaryPercent_C", this.wCK_StandardInputs.wBeneficiaryPercent_C.cboBeneficiaryPercent_C, dic["BeneficiaryPercent_C"], 0);
                _gLib._SetSyncUDWin("BeneficiaryPercent_P", this.wCK_StandardInputs.wBeneficiaryPercent_P.cboBeneficiaryPercent_P, dic["BeneficiaryPercent_P"], 0);
                _gLib._SetSyncUDWin("OK", this.wCK_StandardInputs.wOK.btnOK, dic["OK"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Pay_C", this.wCK_StandardInputs.wPay_C.cboPay_C, dic["Pay_C"], 0);
                _gLib._VerifySyncUDWin("Pay_P", this.wCK_StandardInputs.wPay_P.cboPay_P, dic["Pay_P"], 0);
                _gLib._VerifySyncUDWin("AccruedBenefit_C", this.wCK_StandardInputs.wAccruedBenefit_C.cboAccruedBenefit_C, dic["AccruedBenefit_C"], 0);
                _gLib._VerifySyncUDWin("AccruedBenefit_P", this.wCK_StandardInputs.wAccruedBenefit_P.cboAccruedBenefit_P, dic["AccruedBenefit_P"], 0);
                _gLib._VerifySyncUDWin("CashBalanceBenefit_C", this.wCK_StandardInputs.wCashBalanceBenefit_C.cboCashBalanceBenefit_C, dic["CashBalanceBenefit_C"], 0);
                _gLib._VerifySyncUDWin("CashBalanceBenefit_P", this.wCK_StandardInputs.wCashBalanceBenefit_P.cboCashBalanceBenefit_P, dic["CashBalanceBenefit_P"], 0);
                _gLib._VerifySyncUDWin("BenefitService_C", this.wCK_StandardInputs.wBenefitService_C.cboBenefitService_C, dic["BenefitService_C"], 0);
                _gLib._VerifySyncUDWin("BenefitService_P", this.wCK_StandardInputs.wBenefitService_P.cboBenefitService_P, dic["BenefitService_P"], 0);
                _gLib._VerifySyncUDWin("VestingService_C", this.wCK_StandardInputs.wVestingService_C.cboVestingService_C, dic["VestingService_C"], 0);
                _gLib._VerifySyncUDWin("VestingService_P", this.wCK_StandardInputs.wVestingService_P.cboVestingService_P, dic["VestingService_P"], 0);
                _gLib._VerifySyncUDWin("Hours_C", this.wCK_StandardInputs.wHours_C.cboHours_C, dic["Hours_C"], 0);
                _gLib._VerifySyncUDWin("Hours_P", this.wCK_StandardInputs.wHours_P.cboHours_P, dic["Hours_P"], 0);
                _gLib._VerifySyncUDWin("InactiveBenefit_C", this.wCK_StandardInputs.wInactiveBenefit_C.cboInactiveBenefit_C, dic["InactiveBenefit_C"], 0);
                _gLib._VerifySyncUDWin("InactiveBenefit_P", this.wCK_StandardInputs.wInactiveBenefit_P.cboInactiveBenefit_P, dic["InactiveBenefit_P"], 0);
                _gLib._VerifySyncUDWin("StartDate_C", this.wCK_StandardInputs.wStartDate_C.cboStartDate_C, dic["StartDate_C"], 0);
                _gLib._VerifySyncUDWin("StartDate_P", this.wCK_StandardInputs.wStartDate_P.cboStartDate_P, dic["StartDate_P"], 0);
                _gLib._VerifySyncUDWin("HireDate_C", this.wCK_StandardInputs.wHireDate_C.cboHireDate_C, dic["HireDate_C"], 0);
                _gLib._VerifySyncUDWin("HireDate_P", this.wCK_StandardInputs.wHireDate_P.cboHireDate_P, dic["HireDate_P"], 0);
                _gLib._VerifySyncUDWin("MembershipDate_C", this.wCK_StandardInputs.wMembershipDate_C.cboMembershipDate_C, dic["MembershipDate_C"], 0);
                _gLib._VerifySyncUDWin("MembershipDate_P", this.wCK_StandardInputs.wMembershipDate_P.cboMembershipDate_P, dic["MembershipDate_P"], 0);
                _gLib._VerifySyncUDWin("TerminationDate_C", this.wCK_StandardInputs.wTerminationDate_C.cboTerminationDate_C, dic["TerminationDate_C"], 0);
                _gLib._VerifySyncUDWin("PaymentForm_C", this.wCK_StandardInputs.wPaymentForm_C.cboPaymentForm_C, dic["PaymentForm_C"], 0);
                _gLib._VerifySyncUDWin("PaymentForm_P", this.wCK_StandardInputs.wPaymentForm_P.cboPaymentForm_P, dic["PaymentForm_P"], 0);
                _gLib._VerifySyncUDWin("YearsCertain_C", this.wCK_StandardInputs.wYearsCertain_C.cboYearsCertain_C, dic["YearsCertain_C"], 0);
                _gLib._VerifySyncUDWin("YearsCertain_P", this.wCK_StandardInputs.wYearsCertain_P.cboYearsCertain_P, dic["YearsCertain_P"], 0);
                _gLib._VerifySyncUDWin("BeneficiaryPercent_C", this.wCK_StandardInputs.wBeneficiaryPercent_C.cboBeneficiaryPercent_C, dic["BeneficiaryPercent_C"], 0);
                _gLib._VerifySyncUDWin("BeneficiaryPercent_P", this.wCK_StandardInputs.wBeneficiaryPercent_P.cboBeneficiaryPercent_P, dic["BeneficiaryPercent_P"], 0);
                _gLib._VerifySyncUDWin("OK", this.wCK_StandardInputs.wOK.btnOK, dic["OK"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("PayChange_Min", "");
        /// dic.Add("PayChange_Max", "");
        /// dic.Add("PayRange_Min", "");
        /// dic.Add("PayRange_Max", "");
        /// dic.Add("AccruedBenefitChange_Min", "");
        /// dic.Add("AccruedBenefitChange_Max", "");
        /// dic.Add("AccruedBenefitRange_Min", "");
        /// dic.Add("AccruedBenefitRange_Max", "");
        /// dic.Add("InactiveBenefitChange_Min", "");
        /// dic.Add("InactiveBenefitChange_Max", "");
        /// dic.Add("InactiveBenefitRange_Min", "");
        /// dic.Add("InactiveBenefitRange_Max", "");
        /// dic.Add("CashBalanceChange_Act_Min", "");
        /// dic.Add("CashBalanceChange_Act_Max", "");
        /// dic.Add("CashBalanceChange_InAct_Min", "");
        /// dic.Add("CashBalanceChange_InAct_Max", "");
        /// dic.Add("CashBalanceRange_Min", "");
        /// dic.Add("CashBalanceRange_Max", "");
        /// dic.Add("HoursRange_Min", "");
        /// dic.Add("HoursRange_Max", "");
        /// dic.Add("BenefitServiceRange_Min", "");
        /// dic.Add("BenefitServiceRange_Max", "");
        /// dic.Add("VestingServiceRange_Min", "");
        /// dic.Add("VestingServiceRange_Max", "");
        /// dic.Add("BenefitServiceForNewAct_Max", "");
        /// dic.Add("VestServiceForNewAct_Max", "");
        /// dic.Add("AgeForNewAct_Min", "");
        /// dic.Add("AgeForNewAct_Max", "");
        /// dic.Add("AgeForNewRetirees_Min", "");
        /// dic.Add("YearsRequiredForVesting", "");
        /// dic.Add("BirthDate_Threshold", "");
        /// dic.Add("HireDate_Threshold", "");
        /// dic.Add("MembershipDate_Threshold", "");
        /// dic.Add("StartDate_Threshold", "");
        /// dic.Add("OK", "");
        /// pData._PopVerify_CK_StandardInputs_Part2(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CK_StandardInputs_Part2(MyDictionary dic)
        {
            


            string sFunctionName = "_PopVerify_CK_StandardInputs_Part2";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("PayChange_Min", this.wCK_StandardInputs.wPayChange_Min.txtPayChange_Min, dic["PayChange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PayChange_Max", this.wCK_StandardInputs.wPayChange_Max.txtPayChange_Max, dic["PayChange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PayRange_Min", this.wCK_StandardInputs.wPayRange_Min.txtPayRange_Min, dic["PayRange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PayRange_Max", this.wCK_StandardInputs.wPayRange_Max.txtPayRange_Max, dic["PayRange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AccruedBenefitChange_Min", this.wCK_StandardInputs.wAccruedBenefitChange_Min.txtAccruedBenefitChange_Min, dic["AccruedBenefitChange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AccruedBenefitChange_Max", this.wCK_StandardInputs.wAccruedBenefitChange_Max.txtAccruedBenefitChange_Max, dic["AccruedBenefitChange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AccruedBenefitRange_Min", this.wCK_StandardInputs.wAccruedBenefitRange_Min.txtAccruedBenefitRange_Min, dic["AccruedBenefitRange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AccruedBenefitRange_Max", this.wCK_StandardInputs.wAccruedBenefitRange_Max.txtAccruedBenefitRange_Max, dic["AccruedBenefitRange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InactiveBenefitChange_Min", this.wCK_StandardInputs.wInactiveBenefitChange_Min.txtInactiveBenefitChange_Min, dic["InactiveBenefitChange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InactiveBenefitChange_Max", this.wCK_StandardInputs.wInactiveBenefitChange_Max.txtInactiveBenefitChange_Max, dic["InactiveBenefitChange_Max"], 0);

                _gLib._SetSyncUDWin_ByClipboard("InactiveBenefitRange_Min", this.wCK_StandardInputs.wInactiveBenefitRange_Min.txtInactiveBenefitRange_Min, dic["InactiveBenefitRange_Min"], 0);
                //if (dic["InactiveBenefitRange_Min"] != "")
                //{
                //    Keyboard.SendKeys(this.wCK_StandardInputs.wInactiveBenefitRange_Min.txtInactiveBenefitRange_Min, "{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}");
                //    Keyboard.SendKeys(this.wCK_StandardInputs.wInactiveBenefitRange_Min.txtInactiveBenefitRange_Min, dic["InactiveBenefitRange_Min"]); 
                //}
                _gLib._SetSyncUDWin_ByClipboard("InactiveBenefitRange_Max", this.wCK_StandardInputs.wInactiveBenefitRange_Max.txtInactiveBenefitRange_Max, dic["InactiveBenefitRange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CashBalanceChange_Act_Min", this.wCK_StandardInputs.wCashBalanceChange_Act_Min.txtCashBalanceChange_Act_Min, dic["CashBalanceChange_Act_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CashBalanceChange_Act_Max", this.wCK_StandardInputs.wCashBalanceChange_Act_Max.txtCashBalanceChange_Act_Max, dic["CashBalanceChange_Act_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CashBalanceChange_InAct_Min", this.wCK_StandardInputs.wCashBalanceChange_InAct_Min.txtCashBalanceChange_InAct_Min, dic["CashBalanceChange_InAct_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CashBalanceChange_InAct_Max", this.wCK_StandardInputs.wCashBalanceChange_InAct_Max.txtCashBalanceChange_InAct_Max, dic["CashBalanceChange_InAct_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CashBalanceRange_Min", this.wCK_StandardInputs.wCashBalanceRange_Min.txtCashBalanceRange_Min, dic["CashBalanceRange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CashBalanceRange_Max", this.wCK_StandardInputs.wCashBalanceRange_Max.txtCashBalanceRange_Max, dic["CashBalanceRange_Max"], 0);

                if (dic["HoursRange_Min"].Equals("#Clear#"))
                    _gLib._SetSyncUDWin_ByClipboard("HoursRange_Min", this.wCK_StandardInputs.wHoursRange_Min.txtHoursRange_Min, " ", 0, false, false);
                else
                    _gLib._SetSyncUDWin_ByClipboard("HoursRange_Min", this.wCK_StandardInputs.wHoursRange_Min.txtHoursRange_Min, dic["HoursRange_Min"], 0);

                if (dic["HoursRange_Max"].Equals("#Clear#"))
                    _gLib._SetSyncUDWin_ByClipboard("HoursRange_Max", this.wCK_StandardInputs.wHoursRange_Max.txtHoursRange_Max, " ", 0, false, false);
                else
                    _gLib._SetSyncUDWin_ByClipboard("HoursRange_Max", this.wCK_StandardInputs.wHoursRange_Max.txtHoursRange_Max, dic["HoursRange_Max"], 0);
                
                //////_gLib._SetSyncUDWin_ByClipboard("HoursRange_Max", this.wCK_StandardInputs.wHoursRange_Max.txtHoursRange_Max, dic["HoursRange_Max"], 0);

                if (dic["BenefitServiceRange_Min"].Equals("#Clear#"))
                    _gLib._SetSyncUDWin_ByClipboard("BenefitServiceRange_Min", this.wCK_StandardInputs.wBenefitServiceRange_Min.txtBenefitServiceRange_Min, " ", 0, false, false);
                else
                    _gLib._SetSyncUDWin_ByClipboard("BenefitServiceRange_Min", this.wCK_StandardInputs.wBenefitServiceRange_Min.txtBenefitServiceRange_Min, dic["BenefitServiceRange_Min"], 0);

                if (dic["BenefitServiceRange_Max"].Equals("#Clear#"))
                    _gLib._SetSyncUDWin_ByClipboard("BenefitServiceRange_Max", this.wCK_StandardInputs.wBenefitServiceRange_Max.txtBenefitServiceRange_Max, " ", 0, false, false);
                else
                    _gLib._SetSyncUDWin_ByClipboard("BenefitServiceRange_Max", this.wCK_StandardInputs.wBenefitServiceRange_Max.txtBenefitServiceRange_Max, dic["BenefitServiceRange_Max"], 0);
                
                //////_gLib._SetSyncUDWin_ByClipboard("BenefitServiceRange_Min", this.wCK_StandardInputs.wBenefitServiceRange_Min.txtBenefitServiceRange_Min, dic["BenefitServiceRange_Min"], 0);
                //////_gLib._SetSyncUDWin_ByClipboard("BenefitServiceRange_Max", this.wCK_StandardInputs.wBenefitServiceRange_Max.txtBenefitServiceRange_Max, dic["BenefitServiceRange_Max"], 0);
                
                
                _gLib._SetSyncUDWin_ByClipboard("VestingServiceRange_Min", this.wCK_StandardInputs.wVestingServiceRange_Min.txtVestingServiceRange_Min, dic["VestingServiceRange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("VestingServiceRange_Max", this.wCK_StandardInputs.wVestingServiceRange_Max.txtVestingServiceRange_Max, dic["VestingServiceRange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BenefitServiceForNewAct_Max", this.wCK_StandardInputs.wBenefitServiceForNewAct_Max.txtBenefitServiceForNewAct_Max, dic["BenefitServiceForNewAct_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("VestServiceForNewAct_Max", this.wCK_StandardInputs.wVestServiceForNewAct_Max.txtVestServiceForNewAct_Max, dic["VestServiceForNewAct_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AgeForNewAct_Min", this.wCK_StandardInputs.wAgeForNewAct_Min.txtAgeForNewAct_Min, dic["AgeForNewAct_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AgeForNewAct_Max", this.wCK_StandardInputs.wAgeForNewAct_Max.txtAgeForNewAct_Max, dic["AgeForNewAct_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AgeForNewRetirees_Min", this.wCK_StandardInputs.wAgeForNewRetirees_Min.txtAgeForNewRetirees_Min, dic["AgeForNewRetirees_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("YearsRequiredForVesting", this.wCK_StandardInputs.wYearsRequiredForVesting.txtYearsRequiredForVesting, dic["YearsRequiredForVesting"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BirthDate_Threshold", this.wCK_StandardInputs.wBirthDate_Threshold.txtBirthDate_Threshold, dic["BirthDate_Threshold"], 0);
                _gLib._SetSyncUDWin_ByClipboard("HireDate_Threshold", this.wCK_StandardInputs.wHireDate_Threshold.txtHireDate_Threshold, dic["HireDate_Threshold"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MembershipDate_Threshold", this.wCK_StandardInputs.wMembershipDate_Threshold.txtMembershipDate_Threshold, dic["MembershipDate_Threshold"], 0);
                _gLib._SetSyncUDWin_ByClipboard("StartDate_Threshold", this.wCK_StandardInputs.wStartDate_Threshold.txtStartDate_Threshold, dic["StartDate_Threshold"], 0);
                
                _gLib._SetSyncUDWin("OK", this.wCK_StandardInputs.wOK.btnOK, dic["OK"], 0);


            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("StandardInputs", this.wRetirementStudio.wCK_StandardInputs.btnStandardInputs, dic["StandardInputs"], 0);

                _gLib._VerifySyncUDWin("PayChange_Min", this.wCK_StandardInputs.wPayChange_Min.txtPayChange_Min, dic["PayChange_Min"], 0);
                _gLib._VerifySyncUDWin("PayChange_Max", this.wCK_StandardInputs.wPayChange_Max.txtPayChange_Max, dic["PayChange_Max"], 0);
                _gLib._VerifySyncUDWin("PayRange_Min", this.wCK_StandardInputs.wPayRange_Min.txtPayRange_Min, dic["PayRange_Min"], 0);
                _gLib._VerifySyncUDWin("PayRange_Max", this.wCK_StandardInputs.wPayRange_Max.txtPayRange_Max, dic["PayRange_Max"], 0);
                _gLib._VerifySyncUDWin("AccruedBenefitChange_Min", this.wCK_StandardInputs.wAccruedBenefitChange_Min.txtAccruedBenefitChange_Min, dic["AccruedBenefitChange_Min"], 0);
                _gLib._VerifySyncUDWin("AccruedBenefitChange_Max", this.wCK_StandardInputs.wAccruedBenefitChange_Max.txtAccruedBenefitChange_Max, dic["AccruedBenefitChange_Max"], 0);
                _gLib._VerifySyncUDWin("AccruedBenefitRange_Min", this.wCK_StandardInputs.wAccruedBenefitRange_Min.txtAccruedBenefitRange_Min, dic["AccruedBenefitRange_Min"], 0);
                _gLib._VerifySyncUDWin("AccruedBenefitRange_Max", this.wCK_StandardInputs.wAccruedBenefitRange_Max.txtAccruedBenefitRange_Max, dic["AccruedBenefitRange_Max"], 0);
                _gLib._VerifySyncUDWin("InactiveBenefitChange_Min", this.wCK_StandardInputs.wInactiveBenefitChange_Min.txtInactiveBenefitChange_Min, dic["InactiveBenefitChange_Min"], 0);
                _gLib._VerifySyncUDWin("InactiveBenefitChange_Max", this.wCK_StandardInputs.wInactiveBenefitChange_Max.txtInactiveBenefitChange_Max, dic["InactiveBenefitChange_Max"], 0);
                _gLib._VerifySyncUDWin("InactiveBenefitRange_Min", this.wCK_StandardInputs.wInactiveBenefitRange_Min.txtInactiveBenefitRange_Min, dic["InactiveBenefitRange_Min"], 0);
                _gLib._VerifySyncUDWin("InactiveBenefitRange_Max", this.wCK_StandardInputs.wInactiveBenefitRange_Max.txtInactiveBenefitRange_Max, dic["InactiveBenefitRange_Max"], 0);
                _gLib._VerifySyncUDWin("CashBalanceChange_Act_Min", this.wCK_StandardInputs.wCashBalanceChange_Act_Min.txtCashBalanceChange_Act_Min, dic["CashBalanceChange_Act_Min"], 0);
                _gLib._VerifySyncUDWin("CashBalanceChange_Act_Max", this.wCK_StandardInputs.wCashBalanceChange_Act_Max.txtCashBalanceChange_Act_Max, dic["CashBalanceChange_Act_Max"], 0);
                _gLib._VerifySyncUDWin("CashBalanceChange_InAct_Min", this.wCK_StandardInputs.wCashBalanceChange_InAct_Min.txtCashBalanceChange_InAct_Min, dic["CashBalanceChange_InAct_Min"], 0);
                _gLib._VerifySyncUDWin("CashBalanceChange_InAct_Max", this.wCK_StandardInputs.wCashBalanceChange_InAct_Max.txtCashBalanceChange_InAct_Max, dic["CashBalanceChange_InAct_Max"], 0);
                _gLib._VerifySyncUDWin("CashBalanceRange_Min", this.wCK_StandardInputs.wCashBalanceRange_Min.txtCashBalanceRange_Min, dic["CashBalanceRange_Min"], 0);
                _gLib._VerifySyncUDWin("CashBalanceRange_Max", this.wCK_StandardInputs.wCashBalanceRange_Max.txtCashBalanceRange_Max, dic["CashBalanceRange_Max"], 0);
                _gLib._VerifySyncUDWin("HoursRange_Min", this.wCK_StandardInputs.wHoursRange_Min.txtHoursRange_Min, dic["HoursRange_Min"], 0);
                _gLib._VerifySyncUDWin("HoursRange_Max", this.wCK_StandardInputs.wHoursRange_Max.txtHoursRange_Max, dic["HoursRange_Max"], 0);
                _gLib._VerifySyncUDWin("BenefitServiceRange_Min", this.wCK_StandardInputs.wBenefitServiceRange_Min.txtBenefitServiceRange_Min, dic["BenefitServiceRange_Min"], 0);
                _gLib._VerifySyncUDWin("BenefitServiceRange_Max", this.wCK_StandardInputs.wBenefitServiceRange_Max.txtBenefitServiceRange_Max, dic["BenefitServiceRange_Max"], 0);
                _gLib._VerifySyncUDWin("VestingServiceRange_Min", this.wCK_StandardInputs.wVestingServiceRange_Min.txtVestingServiceRange_Min, dic["VestingServiceRange_Min"], 0);
                _gLib._VerifySyncUDWin("VestingServiceRange_Max", this.wCK_StandardInputs.wVestingServiceRange_Max.txtVestingServiceRange_Max, dic["VestingServiceRange_Max"], 0);
                _gLib._VerifySyncUDWin("BenefitServiceForNewAct_Max", this.wCK_StandardInputs.wBenefitServiceForNewAct_Max.txtBenefitServiceForNewAct_Max, dic["BenefitServiceForNewAct_Max"], 0);
                _gLib._VerifySyncUDWin("VestServiceForNewAct_Max", this.wCK_StandardInputs.wVestServiceForNewAct_Max.txtVestServiceForNewAct_Max, dic["VestServiceForNewAct_Max"], 0);
                _gLib._VerifySyncUDWin("AgeForNewAct_Min", this.wCK_StandardInputs.wAgeForNewAct_Min.txtAgeForNewAct_Min, dic["AgeForNewAct_Min"], 0);
                _gLib._VerifySyncUDWin("AgeForNewAct_Max", this.wCK_StandardInputs.wAgeForNewAct_Max.txtAgeForNewAct_Max, dic["AgeForNewAct_Max"], 0);
                _gLib._VerifySyncUDWin("AgeForNewRetirees_Min", this.wCK_StandardInputs.wAgeForNewRetirees_Min.txtAgeForNewRetirees_Min, dic["AgeForNewRetirees_Min"], 0);
                _gLib._VerifySyncUDWin("YearsRequiredForVesting", this.wCK_StandardInputs.wYearsRequiredForVesting.txtYearsRequiredForVesting, dic["YearsRequiredForVesting"], 0);
                _gLib._VerifySyncUDWin("BirthDate_Threshold", this.wCK_StandardInputs.wBirthDate_Threshold.txtBirthDate_Threshold, dic["BirthDate_Threshold"], 0);
                _gLib._VerifySyncUDWin("HireDate_Threshold", this.wCK_StandardInputs.wHireDate_Threshold.txtHireDate_Threshold, dic["HireDate_Threshold"], 0);
                _gLib._VerifySyncUDWin("MembershipDate_Threshold", this.wCK_StandardInputs.wMembershipDate_Threshold.txtMembershipDate_Threshold, dic["MembershipDate_Threshold"], 0);
                _gLib._VerifySyncUDWin("StartDate_Threshold", this.wCK_StandardInputs.wStartDate_Threshold.txtStartDate_Threshold, dic["StartDate_Threshold"], 0);
                _gLib._VerifySyncUDWin("OK", this.wCK_StandardInputs.wOK.btnOK, dic["OK"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-Feb-26
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("Pay_T", "");
        /// dic.Add("Pay_L", "");
        /// dic.Add("PensionerMemberPension_T", "");
        /// dic.Add("PensionerMemberPension_L", "");
        /// dic.Add("DeferredMemberPension_T", "");
        /// dic.Add("DeferredMemberPension_L", "");
        /// dic.Add("SpouserPension_T", "");
        /// dic.Add("SpouserPension_L", "");
        /// dic.Add("PensionerMemberBenefit1_T", "");
        /// dic.Add("DeferredMemberBenefit1_T", "");
        /// dic.Add("SpouseBenefit1_T", "");
        /// dic.Add("PensionerMemberBenefit2_T", "");
        /// dic.Add("DeferredMemberBenefit2_T", "");
        /// dic.Add("SpouseBenefit2_T", "");
        /// dic.Add("ServiceStartField_T", "");
        /// dic.Add("CertainPeriodfield_T", "");
        /// dic.Add("OK", "");
        /// pData._PopVerify_CK_StandardInputs_Part1_UK(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CK_StandardInputs_Part1_UK(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_CK_StandardInputs_Part1_UK";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Pay_T", this.wCK_StandardInputs.wPay_C.cboPay_C, dic["Pay_T"], 0);
                _gLib._SetSyncUDWin("Pay_L", this.wCK_StandardInputs.wPay_P.cboPay_P, dic["Pay_L"], 0);
                _gLib._SetSyncUDWin("PensionerMemberPension_T", this.wCK_StandardInputs.wAccruedBenefit_C.cboAccruedBenefit_C, dic["PensionerMemberPension_T"], 0);
                _gLib._SetSyncUDWin("PensionerMemberPension_L", this.wCK_StandardInputs.wAccruedBenefit_P.cboAccruedBenefit_P, dic["PensionerMemberPension_L"], 0);
                _gLib._SetSyncUDWin("DeferredMemberPension_T", this.wCK_StandardInputs.wCashBalanceBenefit_C.cboCashBalanceBenefit_C, dic["DeferredMemberPension_T"], 0);
                _gLib._SetSyncUDWin("DeferredMemberPension_L", this.wCK_StandardInputs.wCashBalanceBenefit_P.cboCashBalanceBenefit_P, dic["DeferredMemberPension_L"], 0);
                _gLib._SetSyncUDWin("SpouserPension_T", this.wCK_StandardInputs.wBenefitService_C.cboBenefitService_C, dic["SpouserPension_T"], 0);
                _gLib._SetSyncUDWin("SpouserPension_L", this.wCK_StandardInputs.wBenefitService_P.cboBenefitService_P, dic["SpouserPension_L"], 0);
                _gLib._SetSyncUDWin("PensionerMemberBenefit1_T", this.wCK_StandardInputs.wVestingService_C.cboVestingService_C, dic["PensionerMemberBenefit1_T"], 0);
                _gLib._SetSyncUDWin("DeferredMemberBenefit1_T", this.wCK_StandardInputs.wVestingService_P.cboVestingService_P, dic["DeferredMemberBenefit1_T"], 0);
                _gLib._SetSyncUDWin("SpouseBenefit1_T", this.wCK_StandardInputs.wHours_C.cboHours_C, dic["SpouseBenefit1_T"], 0);
                _gLib._SetSyncUDWin("PensionerMemberBenefit2_T", this.wCK_StandardInputs.wHours_P.cboHours_P, dic["PensionerMemberBenefit2_T"], 0);
                _gLib._SetSyncUDWin("DeferredMemberBenefit2_T", this.wCK_StandardInputs.wInactiveBenefit_C.cboInactiveBenefit_C, dic["DeferredMemberBenefit2_T"], 0);
                _gLib._SetSyncUDWin("SpouseBenefit2_T", this.wCK_StandardInputs.wInactiveBenefit_P.cboInactiveBenefit_P, dic["SpouseBenefit2_T"], 0);
                _gLib._SetSyncUDWin("ServiceStartField_T", this.wCK_StandardInputs.wStartDate_C.cboStartDate_C, dic["ServiceStartField_T"], 0);
                _gLib._SetSyncUDWin("CertainPeriodfield_T", this.wCK_StandardInputs.wStartDate_P.cboStartDate_P, dic["CertainPeriodfield_T"], 0);
               
                _gLib._SetSyncUDWin("OK", this.wCK_StandardInputs.wOK.btnOK, dic["OK"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2016-Feb-26
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("YearsCertain_Min", "");
        /// dic.Add("YearsCertain_Max", "");
        /// dic.Add("PayChange_Min", "");
        /// dic.Add("PayChange_Max", "");
        /// dic.Add("PayRange_Min", "");
        /// dic.Add("PayRange_Max", "");
        /// dic.Add("PensionerMemberPensionIncrease_Min", "");
        /// dic.Add("PensionerMemberPensionIncrease_Max", "");
        /// dic.Add("DeferredMemberPensionerIncrease_Min", "");
        /// dic.Add("DeferredMemberPensionerIncrease_Max", "");
        /// dic.Add("SpousePensionIncrease_Min", "");
        /// dic.Add("SpousePensionIncrease_Max", "");
        
        /// dic.Add("PensionerMemberBenefit1_Range_Min", "");
        /// dic.Add("PensionerMemberBenefit1_Range_Max", "");
        /// dic.Add("DefferedMemberBenefit1_Range_Min", "");
        /// dic.Add("DefferedMemberBenefit1_Range_Max", "");
        /// dic.Add("SpouseMemberBenefit1_Range_Min", "");
        /// dic.Add("SpouseMemberBenefit1_Range_Max", "");

        /// dic.Add("PensionerMemberBenefit2_Range_Min", "");
        /// dic.Add("PensionerMemberBenefit2_Range_Max", "");
        /// dic.Add("DefferedMemberBenefit2_Range_Min", "");
        /// dic.Add("DefferedMemberBenefit2_Range_Max", "");
        /// dic.Add("SpouseMemberBenefit2_Range_Min", "");
        /// dic.Add("SpouseMemberBenefit2_Range_Max", "");

        /// dic.Add("Pre88GMPRange_Min", "");
        /// dic.Add("Pre88GMPRange_Max", "");
        /// dic.Add("Post88GMPRange_Min", "");
        /// dic.Add("Post88GMPRange_Max", "");
        /// dic.Add("HireAge_Min", "");
        /// dic.Add("HireAge_Max", "");
        /// dic.Add("ValuationAge_Min", "");
        /// dic.Add("ValuationAge_Max", "");
        /// dic.Add("MembershipAge_Min", "");
        /// dic.Add("MembershipAge_Max", "");
        /// dic.Add("MinimumServiceAtValuation", "");
        /// dic.Add("MaximumaPre88GMPIncrease", "");
        /// dic.Add("MaximumaPost88GMPIncrease", "");
        /// dic.Add("OK", "");
        /// pData._PopVerify_CK_StandardInputs_Part2_UK(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CK_StandardInputs_Part2_UK(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_CK_StandardInputs_Part2_UK";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("YearsCertain_Min", this.wCK_StandardInputs.wPayChange_Min.txtPayChange_Min, dic["YearsCertain_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("YearsCertain_Max", this.wCK_StandardInputs.wPayChange_Max.txtPayChange_Max, dic["YearsCertain_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PayChange_Min", this.wCK_StandardInputs.wPayRange_Min.txtPayRange_Min, dic["PayChange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PayChange_Max", this.wCK_StandardInputs.wPayRange_Max.txtPayRange_Max, dic["PayChange_Max"], 0);

                if (dic["PayRange_Min"] != "")
                    _gLib._SendKeysUDWin("PayRange_Min", this.wCK_StandardInputs.wPayRange_Max.txtPayRange_Max, "{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("PayRange_Min", this.wCK_StandardInputs.wCashBalanceChange_Act_Max.txtPayRange_Min, dic["PayRange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PayRange_Max", this.wCK_StandardInputs.wAccruedBenefitChange_Max.txtAccruedBenefitChange_Max, dic["PayRange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PensionerMemberPensionIncrease_Min", this.wCK_StandardInputs.wAccruedBenefitRange_Min.txtAccruedBenefitRange_Min, dic["PensionerMemberPensionIncrease_Min"], 0);

                if (dic["PensionerMemberPensionIncrease_Max"] != "")
                    _gLib._SendKeysUDWin("PensionerMemberPensionIncrease_Max", this.wCK_StandardInputs.wAccruedBenefitRange_Min.txtAccruedBenefitRange_Min, "{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("PensionerMemberPensionIncrease_Max", this.wCK_StandardInputs.wCashBalanceChange_Act_Max.txtPensionerMemberPensionIncrease_Max, dic["PensionerMemberPensionIncrease_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DeferredMemberPensionerIncrease_Min", this.wCK_StandardInputs.wInactiveBenefitChange_Min.txtInactiveBenefitChange_Min, dic["DeferredMemberPensionerIncrease_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DeferredMemberPensionerIncrease_Max", this.wCK_StandardInputs.wInactiveBenefitChange_Max.txtInactiveBenefitChange_Max, dic["DeferredMemberPensionerIncrease_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SpousePensionIncrease_Min", this.wCK_StandardInputs.wInactiveBenefitRange_Min.txtInactiveBenefitRange_Min, dic["SpousePensionIncrease_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SpousePensionIncrease_Max", this.wCK_StandardInputs.wInactiveBenefitRange_Max.txtInactiveBenefitRange_Max, dic["SpousePensionIncrease_Max"], 0);

                _gLib._SetSyncUDWin_ByClipboard("PensionerMemberBenefit1_Range_Min", this.wCK_StandardInputs.wCashBalanceChange_Act_Min.txtCashBalanceChange_Act_Min, dic["PensionerMemberBenefit1_Range_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PensionerMemberBenefit1_Range_Max", this.wCK_StandardInputs.wCashBalanceChange_Act_Max.txtCashBalanceChange_Act_Max, dic["PensionerMemberBenefit1_Range_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DefferedMemberBenefit1_Range_Min", this.wCK_StandardInputs.wCashBalanceChange_InAct_Min.txtCashBalanceChange_InAct_Min, dic["DefferedMemberBenefit1_Range_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DefferedMemberBenefit1_Range_Max", this.wCK_StandardInputs.wCashBalanceChange_InAct_Max.txtCashBalanceChange_InAct_Max, dic["DefferedMemberBenefit1_Range_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SpouseMemberBenefit1_Range_Min", this.wCK_StandardInputs.wCashBalanceRange_Min.txtCashBalanceRange_Min, dic["SpouseMemberBenefit1_Range_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SpouseMemberBenefit1_Range_Max", this.wCK_StandardInputs.wCashBalanceRange_Max.txtCashBalanceRange_Max, dic["SpouseMemberBenefit1_Range_Max"], 0);

                _gLib._SetSyncUDWin_ByClipboard("PensionerMemberBenefit2_Range_Min", this.wCK_StandardInputs.wHoursRange_Min.txtHoursRange_Min, dic["PensionerMemberBenefit2_Range_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PensionerMemberBenefit2_Range_Max", this.wCK_StandardInputs.wHoursRange_Max.txtHoursRange_Max, dic["PensionerMemberBenefit2_Range_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DefferedMemberBenefit2_Range_Min", this.wCK_StandardInputs.wBenefitServiceRange_Min.txtBenefitServiceRange_Min, dic["DefferedMemberBenefit2_Range_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DefferedMemberBenefit2_Range_Max", this.wCK_StandardInputs.wBenefitServiceRange_Max.txtBenefitServiceRange_Max, dic["DefferedMemberBenefit2_Range_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SpouseMemberBenefit2_Range_Min", this.wCK_StandardInputs.wVestingServiceRange_Min.txtVestingServiceRange_Min, dic["SpouseMemberBenefit2_Range_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SpouseMemberBenefit2_Range_Max", this.wCK_StandardInputs.wVestingServiceRange_Max.txtVestingServiceRange_Max, dic["SpouseMemberBenefit2_Range_Max"], 0);

                _gLib._SetSyncUDWin_ByClipboard("Pre88GMPRange_Min", this.wCK_StandardInputs.wBenefitServiceForNewAct_Max.txtBenefitServiceForNewAct_Max, dic["Pre88GMPRange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Pre88GMPRange_Max", this.wCK_StandardInputs.wVestServiceForNewAct_Max.txtVestServiceForNewAct_Max, dic["Pre88GMPRange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Post88GMPRange_Min", this.wCK_StandardInputs.wAgeForNewAct_Min.txtAgeForNewAct_Min, dic["Post88GMPRange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Post88GMPRange_Max", this.wCK_StandardInputs.wAgeForNewAct_Max.txtAgeForNewAct_Max, dic["Post88GMPRange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("HireAge_Min", this.wCK_StandardInputs.wAgeForNewRetirees_Min.txtAgeForNewRetirees_Min, dic["HireAge_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("HireAge_Max", this.wCK_StandardInputs.wYearsRequiredForVesting.txtYearsRequiredForVesting, dic["HireAge_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ValuationAge_Min", this.wCK_StandardInputs.wBirthDate_Threshold.txtBirthDate_Threshold, dic["ValuationAge_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ValuationAge_Max", this.wCK_StandardInputs.wHireDate_Threshold.txtHireDate_Threshold, dic["ValuationAge_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MembershipAge_Min", this.wCK_StandardInputs.wMembershipDate_Threshold.txtMembershipDate_Threshold, dic["MembershipAge_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MembershipAge_Max", this.wCK_StandardInputs.wStartDate_Threshold.txtStartDate_Threshold, dic["MembershipAge_Max"], 0);

                if (dic["MinimumServiceAtValuation"] != "")
                    _gLib._SendKeysUDWin("MinimumServiceAtValuation", this.wCK_StandardInputs.wStartDate_Threshold.txtStartDate_Threshold, "{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("MinimumServiceAtValuation", this.wCK_StandardInputs.wCashBalanceChange_Act_Max.txtMinimumServiceAtValuation, dic["MinimumServiceAtValuation"], 0);

                if (dic["MaximumaPre88GMPIncrease"] != "")
                    _gLib._SendKeysUDWin("MaximumaPre88GMPIncrease", this.wCK_StandardInputs.wStartDate_Threshold.txtStartDate_Threshold, "{Tab}{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("MaximumaPre88GMPIncrease", this.wCK_StandardInputs.wCashBalanceChange_Act_Max.txtMaximumPre88GMPIncrease, dic["MaximumaPre88GMPIncrease"], 0);

                if (dic["MaximumaPost88GMPIncrease"] != "")
                    _gLib._SendKeysUDWin("MaximumaPost88GMPIncrease", this.wCK_StandardInputs.wStartDate_Threshold.txtStartDate_Threshold, "{Tab}{Tab}{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("MaximumaPost88GMPIncrease", this.wCK_StandardInputs.wCashBalanceChange_Act_Max.txtMaximumPost88GMPIncrease, dic["MaximumaPost88GMPIncrease"], 0);

                _gLib._SetSyncUDWin("OK", this.wCK_StandardInputs.wOK.btnOK, dic["OK"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
              
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-Feb-26
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("AnnuitantBenefit_T", "");
        /// dic.Add("BeneficiaryBenefit_T", "");
        /// dic.Add("Pay_T", "");
        /// dic.Add("Pay_L", "");
        /// dic.Add("Service_T", "");
        /// dic.Add("Service_L", "");
        /// dic.Add("CertainPeriod_T", "");
        /// dic.Add("Continuation_T", "");
        /// dic.Add("OK", "");
        /// pData._PopVerify_CK_StandardInputs_Part1_DE(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CK_StandardInputs_Part1_DE(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_CK_StandardInputs_Part1_DE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("AnnuitantBenefit_T", this.wCK_StandardInputs.wPay_C.cboPay_C, dic["AnnuitantBenefit_T"], 0);
                _gLib._SetSyncUDWin("BeneficiaryBenefit_T", this.wCK_StandardInputs.wPay_P.cboPay_P, dic["BeneficiaryBenefit_T"], 0);
                _gLib._SetSyncUDWin("Pay_T", this.wCK_StandardInputs.wAccruedBenefit_C.cboAccruedBenefit_C, dic["Pay_T"], 0);
                _gLib._SetSyncUDWin("Pay_L", this.wCK_StandardInputs.wBenefitActives_NL.cbo, dic["Pay_L"], 0);
                _gLib._SetSyncUDWin("Service_T", this.wCK_StandardInputs.wCashBalanceBenefit_C.cboCashBalanceBenefit_C, dic["Service_T"], 0);
                _gLib._SetSyncUDWin("Service_L", this.wCK_StandardInputs.wCashBalanceBenefit_P.cboCashBalanceBenefit_P, dic["Service_L"], 0);
                _gLib._SetSyncUDWin("CertainPeriod_T", this.wCK_StandardInputs.wBenefitService_C.cboBenefitService_C, dic["CertainPeriod_T"], 0);
                _gLib._SetSyncUDWin("Continuation_T", this.wCK_StandardInputs.wAccruedBenefit_P.cboAccruedBenefit_P, dic["Continuation_T"], 0);

                _gLib._SetSyncUDWin("OK", this.wCK_StandardInputs.wOK.btnOK, dic["OK"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2016-Feb-26
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("AnnuitantBenefitRange_Min", "");
        /// dic.Add("AnnuitantBenefitRange_Max", "");
        /// dic.Add("BeneficiaryBenefitRange_Min", "");
        /// dic.Add("BeneficiaryBenefitRange_Max", "");
        /// dic.Add("CertainPeriod_Min", "");
        /// dic.Add("CertainPeriod_Max", "");
        /// dic.Add("Continuation_T", "");
        /// dic.Add("Continuation_L", "");
        /// dic.Add("HireAge_Min", "");
        /// dic.Add("HireAge_Max", "");
        /// dic.Add("PayRange_Min", "");
        /// dic.Add("PayRange_Max", "");
        /// dic.Add("PayIncrease_Max", "");
        /// dic.Add("PayDecrease_Max", "");
        /// dic.Add("OK", "");
        /// pData._PopVerify_CK_StandardInputs_Part2_DE(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CK_StandardInputs_Part2_DE(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_CK_StandardInputs_Part2_DE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("AnnuitantBenefitRange_Min", this.wCK_StandardInputs.wCashBalanceChange_InAct_Min.txtCashBalanceChange_InAct_Min, dic["AnnuitantBenefitRange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AnnuitantBenefitRange_Max", this.wCK_StandardInputs.wPayChange_Max.txtPayChange_Max, dic["AnnuitantBenefitRange_Max"], 0);

                if (dic["BeneficiaryBenefitRange_Min"] != "")
                    _gLib._SendKeysUDWin("BeneficiaryBenefitRange_Min", this.wCK_StandardInputs.wPayChange_Max.txtPayChange_Max, "{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("BeneficiaryBenefitRange_Min", this.wCK_StandardInputs.wCashBalanceRange_Min.txtCashBalanceRange_Min, dic["BeneficiaryBenefitRange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BeneficiaryBenefitRange_Max", this.wCK_StandardInputs.wPayRange_Max.txtPayRange_Max, dic["BeneficiaryBenefitRange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CertainPeriod_Min", this.wCK_StandardInputs.wAccruedBenefitChange_Min.txtAccruedBenefitChange_Min, dic["CertainPeriod_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CertainPeriod_Max", this.wCK_StandardInputs.wAccruedBenefitChange_Max.txtAccruedBenefitChange_Max, dic["CertainPeriod_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Continuation_T", this.wCK_StandardInputs.wAccruedBenefitRange_Min.txtAccruedBenefitRange_Min, dic["Continuation_T"], 0);

                if (dic["Continuation_L"] != "")
                    _gLib._SendKeysUDWin("Continuation_L", this.wCK_StandardInputs.wAccruedBenefitRange_Min.txtAccruedBenefitRange_Min, "{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("Continuation_L", this.wCK_StandardInputs.wBenefitServiceRange_Max.txtBenefitServiceRange_Max, dic["Continuation_L"], 0);
                _gLib._SetSyncUDWin_ByClipboard("HireAge_Min", this.wCK_StandardInputs.wInactiveBenefitChange_Min.txtInactiveBenefitChange_Min, dic["HireAge_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("HireAge_Max", this.wCK_StandardInputs.wInactiveBenefitChange_Max.txtInactiveBenefitChange_Max, dic["HireAge_Max"], 0);

                if (dic["PayRange_Min"] != "")
                    _gLib._SendKeysUDWin("PayRange_Min", this.wCK_StandardInputs.wInactiveBenefitChange_Max.txtInactiveBenefitChange_Max, "{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("PayRange_Min", this.wCK_StandardInputs.wBenefitServiceForNewAct_Max.txtBenefitServiceForNewAct_Max, dic["PayRange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PayRange_Max", this.wCK_StandardInputs.wInactiveBenefitRange_Max.txtInactiveBenefitRange_Max, dic["PayRange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PayIncrease_Max", this.wCK_StandardInputs.wCashBalanceChange_Act_Min.txtCashBalanceChange_Act_Min, dic["PayIncrease_Max"], 0);

                if (dic["PayDecrease_Max"] != "")
                    _gLib._SendKeysUDWin("PayDecrease_Max", this.wCK_StandardInputs.wCashBalanceChange_Act_Min.txtCashBalanceChange_Act_Min, "{Tab}", 0);
                _gLib._SetSyncUDWin_ByClipboard("PayDecrease_Max", this.wCK_StandardInputs.wAgeForNewAct_Max.txtAgeForNewAct_Max, dic["PayDecrease_Max"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        
        /// <summary>
        /// 2016-Feb-19 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("Pay_T", "");
        /// dic.Add("Pay_L", "");
        /// dic.Add("Salary_T", "");
        /// dic.Add("Salary_L", "");
        /// dic.Add("AccruedBenefit_T", "");
        /// dic.Add("AccruedBenefit_L", "");
        /// dic.Add("PensionableServiceDate_T", "");
        /// dic.Add("PensionableServiceDate_L", "");
        /// dic.Add("NormalRetirementAge_T", "");
        /// dic.Add("NormalRetirementAge_L", "");
        /// dic.Add("NormalRetirementDate_T", "NRD_C");
        /// dic.Add("NormalRetirementDate_L", "");
        /// dic.Add("InactiveBenefit_T", "");
        /// dic.Add("InactiveBenefit_L", "");
        /// dic.Add("HireDate_T", "");
        /// dic.Add("HireDate_L", "");
        /// dic.Add("ExitDate_T", "");
        /// dic.Add("ExitDate_L", "");
        /// dic.Add("ContributionAmount_T", "");
        /// dic.Add("ContributionAmount_L", "");
        /// dic.Add("OK", "");
        /// pData._PopVerify_CK_StandardInputs_Part1_IR(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CK_StandardInputs_Part1_IR(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_CK_StandardInputs_Part1_IR";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Pay_T", this.wCK_StandardInputs.wPay_C.cboPay_C, dic["Pay_T"], 0);
                _gLib._SetSyncUDWin("Pay_L", this.wCK_StandardInputs.wPay_P.cboPay_P, dic["Pay_L"], 0);
                _gLib._SetSyncUDWin("Salary_T", this.wCK_StandardInputs.wAccruedBenefit_C.cboAccruedBenefit_C, dic["Salary_T"], 0);
                _gLib._SetSyncUDWin("Salary_L", this.wCK_StandardInputs.wAccruedBenefit_P.cboAccruedBenefit_P, dic["Salary_L"], 0);
                _gLib._SetSyncUDWin("AccruedBenefit_T", this.wCK_StandardInputs.wCashBalanceBenefit_C.cboCashBalanceBenefit_C, dic["AccruedBenefit_T"], 0);
                _gLib._SetSyncUDWin("AccruedBenefit_L", this.wCK_StandardInputs.wCashBalanceBenefit_P.cboCashBalanceBenefit_P, dic["AccruedBenefit_L"], 0);
                _gLib._SetSyncUDWin("PensionableServiceDate_T", this.wCK_StandardInputs.wBenefitService_C.cboBenefitService_C, dic["PensionableServiceDate_T"], 0);
                _gLib._SetSyncUDWin("PensionableServiceDate_L", this.wCK_StandardInputs.wBenefitService_P.cboBenefitService_P, dic["PensionableServiceDate_L"], 0);
                _gLib._SetSyncUDWin("NormalRetirementAge_T", this.wCK_StandardInputs.wVestingService_C.cboVestingService_C, dic["NormalRetirementAge_T"], 0);
                _gLib._SetSyncUDWin("NormalRetirementAge_L", this.wCK_StandardInputs.wVestingService_P.cboVestingService_P, dic["NormalRetirementAge_L"], 0);
                _gLib._SetSyncUDWin("NormalRetirementDate_T", this.wCK_StandardInputs.wHours_C.cboHours_C, dic["NormalRetirementDate_T"], 0);
                _gLib._SetSyncUDWin("NormalRetirementDate_L", this.wCK_StandardInputs.wHours_P.cboHours_P, dic["NormalRetirementDate_L"], 0);
                _gLib._SetSyncUDWin("InactiveBenefit_T", this.wCK_StandardInputs.wInactiveBenefit_C.cboInactiveBenefit_C, dic["InactiveBenefit_T"], 0);
                _gLib._SetSyncUDWin("InactiveBenefit_L", this.wCK_StandardInputs.wInactiveBenefit_P.cboInactiveBenefit_P, dic["InactiveBenefit_L"], 0);
                _gLib._SetSyncUDWin("HireDate_T", this.wCK_StandardInputs.wStartDate_C.cboStartDate_C, dic["HireDate_T"], 0);
                _gLib._SetSyncUDWin("HireDate_L", this.wCK_StandardInputs.wStartDate_P.cboStartDate_P, dic["HireDate_L"], 0);
                _gLib._SetSyncUDWin("ExitDate_T", this.wCK_StandardInputs.wHireDate_C.cboHireDate_C, dic["ExitDate_T"], 0);
                _gLib._SetSyncUDWin("ExitDate_L", this.wCK_StandardInputs.wHireDate_P.cboHireDate_P, dic["ExitDate_L"], 0);
                _gLib._SetSyncUDWin("ContributionAmount_T", this.wCK_StandardInputs.wMembershipDate_C.cboMembershipDate_C, dic["ContributionAmount_T"], 0);
                _gLib._SetSyncUDWin("ContributionAmount_L", this.wCK_StandardInputs.wMembershipDate_P.cboMembershipDate_P, dic["ContributionAmount_L"], 0);
                _gLib._SetSyncUDWin("OK", this.wCK_StandardInputs.wOK.btnOK, dic["OK"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2016-Feb-19 
        ///ruiyang.song@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("PayChange_Min", "");
        /// dic.Add("PayChange_Max", "");
        /// dic.Add("PayRange_Min", "");
        /// dic.Add("PayRange_Max", "");
        /// dic.Add("SalaryChange_Min", "");
        /// dic.Add("SalaryChange_Max", "");
        /// dic.Add("SalaryRange_Min", "");
        /// dic.Add("SalaryRange_Max", "");
        /// dic.Add("OK", "");
        /// pData._PopVerify_CK_StandardInputs_Part2_IR(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CK_StandardInputs_Part2_IR(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_CK_StandardInputs_Part2_IR";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("PayChange_Min", this.wCK_StandardInputs.wPayChange_Min.txtPayChange_Min, dic["PayChange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PayChange_Max", this.wCK_StandardInputs.wPayChange_Max.txtPayChange_Max, dic["PayChange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PayRange_Min", this.wCK_StandardInputs.wPayRange_Min.txtPayRange_Min, dic["PayRange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PayRange_Max", this.wCK_StandardInputs.wPayRange_Max.txtPayRange_Max, dic["PayRange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SalaryChange_Min", this.wCK_StandardInputs.wAccruedBenefitChange_Min.txtAccruedBenefitChange_Min, dic["SalaryChange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SalaryChange_Max", this.wCK_StandardInputs.wAccruedBenefitChange_Max.txtAccruedBenefitChange_Max, dic["SalaryChange_Max"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SalaryRange_Min", this.wCK_StandardInputs.wAccruedBenefitRange_Min.txtAccruedBenefitRange_Min, dic["SalaryRange_Min"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SalaryRange_Max", this.wCK_StandardInputs.wAccruedBenefitRange_Max.txtAccruedBenefitRange_Max, dic["SalaryRange_Max"], 0);
               
                _gLib._SetSyncUDWin("OK", this.wCK_StandardInputs.wOK.btnOK, dic["OK"], 0);


            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-Feb-19 
        ///ruiyang.song@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("AnnuitantBenefit_T", "");
        /// dic.Add("BeneficiaryBenefit_T", "");
        /// dic.Add("BenefitActives_T", "");
        /// dic.Add("BenefitActives_L", "");
        /// dic.Add("BenefitInactives_T", "");
        /// dic.Add("BenefitInactives_L", "");
        /// dic.Add("Pay_T", "");
        /// dic.Add("Pay_L", "");
        /// dic.Add("OK", "");
        /// pData._PopVerify_CK_StandardInputs_Part1_IR(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CK_StandardInputs_Part1_NL(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_CK_StandardInputs_Part1_IR";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("AnnuitantBenefit_T", this.wCK_StandardInputs.wPay_C.cboPay_C, dic["AnnuitantBenefit_T"], 0);
                _gLib._SetSyncUDWin("BeneficiaryBenefit_T", this.wCK_StandardInputs.wPay_P.cboPay_P, dic["BeneficiaryBenefit_T"], 0);
                _gLib._SetSyncUDWin("BenefitActives_T", this.wCK_StandardInputs.wAccruedBenefit_C.cboAccruedBenefit_C, dic["BenefitActives_T"], 0);
                _gLib._SetSyncUDWin("BenefitActives_L", this.wCK_StandardInputs.wBenefitActives_NL.cbo, dic["BenefitActives_L"], 0);
                _gLib._SetSyncUDWin("BenefitInactives_T", this.wCK_StandardInputs.wCashBalanceBenefit_C.cboCashBalanceBenefit_C, dic["BenefitInactives_T"], 0);
                _gLib._SetSyncUDWin("BenefitInactives_L", this.wCK_StandardInputs.wCashBalanceBenefit_P.cboCashBalanceBenefit_P, dic["BenefitInactives_L"], 0);
                _gLib._SetSyncUDWin("Pay_T", this.wCK_StandardInputs.wBenefitService_C.cboBenefitService_C, dic["Pay_T"], 0);
                _gLib._SetSyncUDWin("Pay_L", this.wCK_StandardInputs.wBenefitService_P.cboBenefitService_P, dic["Pay_L"], 0);
                
                _gLib._SetSyncUDWin("OK", this.wCK_StandardInputs.wOK.btnOK, dic["OK"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("CheckName", "Invalid or no Gender");
        ///    dic.Add("iSearchDownNum", "20");
        ///    dic.Add("Include", "True");
        ///    dic.Add("ViewCheck", "");
        ///    dic.Add("Filter", "");
        ///    dic.Add("EditFilter", "");
        ///    dic.Add("#Failed", "");
        ///    dic.Add("#Passed", "");
        ///    dic.Add("#Error", "");
        ///    dic.Add("#NA", "");
        ///    dic.Add("LabelsToDisplay", "");
        ///    dic.Add("QueryInstructions", "");
        ///    dic.Add("CorrectFields", "");
        ///    pData._CK_CheckGrip(dic, true, true, true); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("CheckName", "All");
        ///    dic.Add("iSearchDownNum", "");
        ///    dic.Add("Include", "True");
        ///    dic.Add("ViewCheck", "");
        ///    dic.Add("Filter", "");
        ///    dic.Add("EditFilter", "");
        ///    dic.Add("#Failed", "");
        ///    dic.Add("#Passed", "");
        ///    dic.Add("#Error", "");
        ///    dic.Add("#NA", "");
        ///    dic.Add("LabelsToDisplay", "");
        ///    dic.Add("QueryInstructions", "");
        ///    dic.Add("CorrectFields", "");
        ///    pData._CK_CheckGrip(dic, true, true, false); 
        /// </summary>
        /// <param name="dic"></param>
        public void _CK_CheckGrip(MyDictionary dic, Boolean bSearchCheck, Boolean bContinueSearchOnCurrent, Boolean bVerifyInclude)
        {
            string sFunctionName = "_CK_CheckGrip";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            int iSearchMaxNum = 100;
            Boolean bFindCheck = false;

            if (bSearchCheck)
            {
                if (!bContinueSearchOnCurrent)
                {
                    ////////////Mouse.Click(this.wRetirementStudio.wCK_FPGrid.grid, new Point(50, 45));
                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, "Click", 0, false, 50, 45);

                    string sKey = "{Home}";
                    for (int i = 0; i < 20; i++)
                        sKey = sKey + "{PageUp}";
                    
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, sKey);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, sKey);

                }
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Home}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, "{Home}");

                if (dic["iSearchDownNum"] != "")
                {
                    string sKeys = "";
                    int iSearchDownNum = Convert.ToInt32(dic["iSearchDownNum"]);
                    for (int i = 0; i < iSearchDownNum; i++)
                        sKeys = sKeys + "{Down}";
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, sKeys);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, sKeys);
                }

                for (int i = 0; i < iSearchMaxNum; i++)
                {

                    string sActCheckName = "";

                    if (dic["CheckName"].Contains(","))
                    {
                        Clipboard.Clear();
                        ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "C", ModifierKeys.Control);
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, "C", 0, ModifierKeys.Control, false);
                        sActCheckName = Clipboard.GetText();
                    }
                    else
                    {
                        sActCheckName = _fp._ReturnSelectRowContent(this.wRetirementStudio.wCK_FPGrid.grid);
                    }
                    //if (sActCheckName == dic["CheckName"])
                    if (sActCheckName.Contains(dic["CheckName"]))
                    {
                        bFindCheck = true;
                        break;
                    }
                    //////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Down}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, "{Down}");
                }
                if (!bFindCheck)
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> Failed to find check <" + dic["CheckName"] + ">");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Failed to find check <" + dic["CheckName"] + ">");
                }

            }

            if (dic["Include"] != "")
            {
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Home}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Right}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, "{Home}{Right}");
                string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wCK_FPGrid.grid);

                if (sAct == "1") sAct = "True";
                if (sAct == "0") sAct = "False";

                if (sAct.ToUpper()!= dic["Include"].ToUpper())
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Space}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, "{Space}");

                    if (bVerifyInclude)
                    {
                        ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Left}");
                        ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Right}");
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, "{Left}{Right}");

                        sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wCK_FPGrid.grid);

                        if (sAct == "1") sAct = "True";
                        if (sAct == "0") sAct = "False";
                        if (sAct.ToUpper() != dic["Include"].ToUpper())
                        {
                            _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> Failed to set check <" + dic["CheckName"] + "> field Include value as <" + dic["Include"] + ">");
                            _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Failed to set check <" + dic["CheckName"] + "> field Include value as <" + dic["Include"] + ">");
                        }
                    }
                }
            }

            if (dic["EditFilter"] != "")
            {
                string sKey = "{Home}";
                for (int i = 0; i < 4; i++)
                    sKey = sKey + "{Right}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, sKey);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Space}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, sKey);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, "{Space}");
            }
            if (dic["LabelsToDisplay"] != "")
            {
                string sKey = "{Home}";
                for (int i = 0; i < 9; i++)
                    sKey = sKey + "{Right}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, sKey);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Space}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, sKey);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, "{Space}");
            }

            if (dic["QueryInstructions"] != "")
            {
                string sKey = "{Home}";
                for (int i = 0; i < 10; i++)
                    sKey = sKey + "{Right}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, sKey);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Space}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, sKey);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, "{Space}");
            }

            if (dic["CorrectFields"] != "")
            {
                string sKey = "{Home}";
                for (int i = 0; i < 11; i++)
                    sKey = sKey + "{Right}";
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, sKey);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Space}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, sKey);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, "{Space}");
            }

            //int iActRow = _fp._ReturnSelectRowIndex(this.wRetirementStudio.wDG_FPGrid.grid) + 1;

            //if (iRow != iActRow)
            //{
            //    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> Failed to select row <" + iRow + ">, actual focus on row <" + iActRow + ">");
            //    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Failed to select row <" + iRow + ">, actual focus on row <" + iActRow + ">");
            //}

        }


        /// <summary>
        /// 2016-May-10
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pData._CK_CheckGrip_ClickLink_Fail("Data2015RF_1", "Benefit Checks => Certain Period Invalid", "11070");
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _CK_CheckGrip_ClickLink_Fail(string sServiceName, string sCheckName, string sNumber, int iRow =1000 )
        {

            int ixPos = 708;
            int iyPos = 0;

            if (iRow == 1000)
                iyPos = 141;
            else
            {
                int iyStart = 86;
                int iyStep = 20;

                iyPos = iyStart + (iRow - 3) * iyStep;

            }




            _gLib._SetSyncUDWin("", this.wRetirementStudio.wCK_FPGrid.grid, "Click", 0, false, ixPos, iyPos);
            pMain._SelectTab(sServiceName);

            string sActNumber = this.wRetirementStudio.wCK_ResultsPreview_Total.txtTotal.GetProperty("text").ToString();

            if (!sActNumber.Equals(sNumber))
                _gLib._MsgBoxYesNo("Warning", "Check < " + sCheckName + " >,  Expected #Failed Number <" + sNumber + ">, Actual Number <" + sActNumber + ">");




        }

        /// <summary>
        /// 2013-Aug-10
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pData._CK_CheckGrip_SendKeys("{Up}");
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _CK_CheckGrip_SendKeys(string sKeys)
        {
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, sKeys);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCK_FPGrid.grid, sKeys);

        }

        /// <summary>
        /// 2013-Aug-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("StandardorCustomFilter", "");
        /// dic.Add("Filter", "");
        /// dic.Add("FilterStatus", "");
        /// dic.Add("CustomExpression", "");
        /// dic.Add("CustomExpression_Formula", "");
        /// dic.Add("OK", "");
        /// dic.Add("Cancel", "");
        /// pData._PopVerify_CK_EditFilter(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CK_EditFilter(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_CK_EditFilter";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sFilterStatus = dic["FilterStatus"];
            if (dic["FilterStatus"] == "")
                sFilterStatus = "True";


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("StandardorCustomFilter", this.wCK_EditFilter.wStandardorCustomFilter.rdStandardorCustomFilter, dic["StandardorCustomFilter"], 0);
                if (dic["Filter"] != "")
                {
                    _gLib._SetSyncUDWin("Filter", this.wCK_EditFilter.wFilter.txtFilter.btnDropDown, "Click", 0);
                    WinCheckBox wChk = new WinCheckBox(this.wIP_Matching_AcceptRecordsAs_Popup.wDerivationDefintion_Filter);
                    wChk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["Filter"]);
                    _gLib._SetSyncUDWin(dic["Filter"], wChk, sFilterStatus, 0);

                }
                _gLib._SetSyncUDWin("CustomExpression", this.wCK_EditFilter.wCustomExpression.rdCustomExpression, dic["CustomExpression"], 0);
                
                if (dic["CustomExpression_Formula"] != "")
                {
                    this.wCK_EditFilter.wCustomExpression_Formula.txtFormula.Text= "";
                    Clipboard.Clear();
                    Clipboard.SetText(dic["CustomExpression_Formula"]);
                    ////////////Keyboard.SendKeys(this.wCK_EditFilter.wCustomExpression_Formula.txtFormula, "v", ModifierKeys.Control);
                    _gLib._SendKeysUDWin("CustomExpression_Formula", this.wCK_EditFilter.wCustomExpression_Formula.txtFormula, "v", 0, ModifierKeys.Control, false);
                    _gLib._VerifySyncUDWin("CustomExpression_Formula", this.wCK_EditFilter.wCustomExpression_Formula.txtFormula, dic["CustomExpression_Formula"] + "\r", 0);
                    _gLib._SetSyncUDWin("CustomExpression_Accept", this.wCK_EditFilter.wCustomExpression_Accept.btnAccept, "Click", 0);
                }

                _gLib._SetSyncUDWin("CustomExpression_Accept", this.wCK_EditFilter.wCustomExpression_Accept.btnAccept, dic["CustomExpression_Accept"], 0);


                _gLib._SetSyncUDWin("OK", this.wCK_EditFilter.wOK.btnOK, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wCK_EditFilter.wCancel.btnCancel, dic["Cancel"], 0);


            }


            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("StandardorCustomFilter", this.wCK_EditFilter.wStandardorCustomFilter.rdStandardorCustomFilter, dic["StandardorCustomFilter"], 0);
                _gLib._VerifySyncUDWin("CustomExpression", this.wCK_EditFilter.wCustomExpression.rdCustomExpression, dic["CustomExpression"], 0);
                _gLib._VerifySyncUDWin("CustomExpression_Formula", this.wCK_EditFilter.wCustomExpression_Formula.txtFormula, dic["CustomExpression_Formula"], 0);
                _gLib._VerifySyncUDWin("OK", this.wCK_EditFilter.wOK.btnOK, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wCK_EditFilter.wOK.btnOK, dic["Cancel"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Aug-08
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("QueryWording", "");
        /// dic.Add("OK", "Click");
        /// dic.Add("Cancel", "");
        /// pData._PopVerify_CK_QueryInstructions(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CK_QueryInstructions(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_CK_QueryInstructions";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("QueryWording", this.wCK_QueryInstructions.wQueryWording.txtQueryWording, dic["QueryWording"], 0);
                _gLib._SetSyncUDWin("OK", this.wCK_QueryInstructions.wOK.btnOK, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wCK_QueryInstructions.wCancel.btnCancel, dic["Cancel"], 0);
                
            }
            if (dic["PopVerify"] == "Verify")
            {
                
                _gLib._VerifySyncUDWin("QueryWording", this.wCK_QueryInstructions.wQueryWording.txtQueryWording, dic["QueryWording"], 0);
                _gLib._VerifySyncUDWin("OK", this.wCK_QueryInstructions.wOK.btnOK, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wCK_QueryInstructions.wCancel.btnCancel, dic["Cancel"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("CreateMatrix", "Click");
        /// pData._PopVerify_StatusMatrix(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_StatusMatrix(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_StatusMatrix";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("CreateMatrix", this.wRetirementStudio.wSM_CreateMatrix.btnCreateMatrix, dic["CreateMatrix"], 0);
                if(_gLib._Exists("Status Matrix popup", this.wSM_Popup.wOK.btnOK, 6, false))
                    _gLib._SetSyncUDWin("OK", this.wSM_Popup.wOK.btnOK, "Click", 0);
                if (_gLib._Exists("Status Matrix popup", this.wSM_Popup.wYes.btnYes, 1, false))
                    _gLib._SetSyncUDWin("Yes", this.wSM_Popup.wYes.btnYes, "Click", 0);
            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("CreateMatrix", this.wRetirementStudio.wSM_CreateMatrix.btnCreateMatrix, dic["CreateMatrix"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("Checks", "");
        /// dic.Add("Checks_Filter", "");
        /// dic.Add("StatusMatrix", "");
        /// dic.Add("StatusMatrix_Filter", "");
        /// dic.Add("ReportName", "");
        /// dic.Add("GenerateReport", "");
        /// pData._PopVerify_Reports(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Reports(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_Reports";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Checks", this.wRetirementStudio.wRP_Checks.rdChecks, dic["Checks"], 0);
                _gLib._SetSyncUDWin("Checks_Filter", this.wRetirementStudio.wRP_Checks_Filter.cboChecks_Filter, dic["Checks_Filter"], 0);
                _gLib._SetSyncUDWin("StatusMatrix", this.wRetirementStudio.wRP_StatusMatrix.rdStatusMatrix, dic["StatusMatrix"], 0);
                _gLib._SetSyncUDWin("StatusMatrix_Filter", this.wRetirementStudio.wRP_StatusMatrix_Filter.cboStatusMatrix_Filter, dic["StatusMatrix_Filter"], 0);
                _gLib._SetSyncUDWin("ReportName", this.wRetirementStudio.wRP_ReportName.txtReportName, dic["ReportName"], 0);
                _gLib._SetSyncUDWin("GenerateReport", this.wRetirementStudio.wRP_GenerateReport.btnGenerateReport, dic["GenerateReport"], 0);
                if (dic["GenerateReport"] != "")
                {
                    if(_gLib._Exists("Save Parameter", this.wRP_SaveDataServiceParameters_Popup, 1, false))
                        _gLib._SetSyncUDWin("Save Parameter - yes", this.wRP_SaveDataServiceParameters_Popup.wYes.btnYes, "Click", 0);
                }

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Checks", this.wRetirementStudio.wRP_Checks.rdChecks, dic["Checks"], 0);
                _gLib._VerifySyncUDWin("Checks_Filter", this.wRetirementStudio.wRP_Checks_Filter.cboChecks_Filter, dic["Checks_Filter"], 0);
                _gLib._VerifySyncUDWin("StatusMatrix", this.wRetirementStudio.wRP_StatusMatrix.rdStatusMatrix, dic["StatusMatrix"], 0);
                _gLib._VerifySyncUDWin("StatusMatrix_Filter", this.wRetirementStudio.wRP_StatusMatrix_Filter.cboStatusMatrix_Filter, dic["StatusMatrix_Filter"], 0);
                _gLib._VerifySyncUDWin("ReportName", this.wRetirementStudio.wRP_ReportName.txtReportName, dic["ReportName"], 0);
                _gLib._VerifySyncUDWin("GenerateReport", this.wRetirementStudio.wRP_GenerateReport.btnGenerateReport, dic["GenerateReport"], 0);

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
        ///    dic.Add("Yes", "Click");
        ///    pData._PopVerify_RP_SaveDataServiceParameters_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_RP_SaveDataServiceParameters_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_RP_SaveDataServiceParameters_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Yes", this.wRP_SaveDataServiceParameters_Popup.wYes.btnYes, dic["Yes"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
               
                _gLib._VerifySyncUDWin("Yes", this.wRP_SaveDataServiceParameters_Popup.wYes.btnYes, dic["Yes"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Sep-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_VU_PrintToFile_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_VU_PrintToFile_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_VU_PrintToFile_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
 
                _gLib._SetSyncUDWin("OK", this.wVU_PrintToFile_Popup.wOK.btn, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("OK", this.wVU_PrintToFile_Popup.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2015-Sep-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_VU_ReportOnManualChanges(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_VU_ReportOnManualChanges(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_VU_ReportOnManualChanges";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wVU_ReportOnManualChanges.wOK.btn, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("OK", this.wVU_ReportOnManualChanges.wOK.btn, dic["OK"], 0);
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
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_RP_ReportGenerated_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_RP_ReportGenerated_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_RP_ReportGenerated_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._Exists("ReportGenerated_Popup", this.wRP_ReportGenerated_Popup, Config.iTimeout * 3);
                _gLib._SetSyncUDWin("OK", this.wRP_ReportGenerated_Popup.wOK.btnOK, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wRP_ReportGenerated_Popup.wOK.btnOK, dic["OK"], 0);
                
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Dec-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Yes", "Click");
        ///    pData._PopVerify_RP_OverwriteReport_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_RP_OverwriteReport_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_RP_OverwriteReport_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Yes", this.wRP_OverwriteReport.wYes.btn, dic["Yes"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Yes", this.wRP_OverwriteReport.wYes.btn, dic["Yes"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-May-26 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iStartNum", "");
        ///    dic.Add("sColumn", "BirthDate");
        ///    dic.Add("sData", "8/11/1986");
        ///    pData._IP_Matching_MatchingResults_Select(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _IP_Matching_MatchingResults_Select(MyDictionary dic)
        {
            string sFunctionName = "_IP_Matching_MatchingResults_Select";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            
            int iCol = 1000;

            switch (dic["sColumn"])
            {
                case "EmployeeIDNumber":        
                    iCol = 1;
                    break;
                case "BirthDate":
                    iCol = 3;
                    break;
                case "HireDate1":
                    iCol = 4;
                    break;
                default:
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because input Column Name <" + dic["sColumn"] + "> is NOT supported!");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because input Column Name <" + dic["sColumn"] + "> is NOT supported!");
                        break;
                    }

            }

            //////if (iCol != 1000)
            //////{
            //////    int iRow = _gLib._TBL_ReturnIndex_Row("", this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, dic["sData"], iCol, 0, true);
            //////    _gLib._TBL_Table("Matching Results", this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, iRow, iCol, "", 0, true, false, false, false);
            //////}

            int iStartNumber = 0;

            if (dic["iStartNum"] != "")
                iStartNumber = Convert.ToInt32(dic["iStartNum"]);


            _gLib._SetSyncUDWin("Results table", this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults.rowFirstRow.cellBirthDate, "Click", 0);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, "{Tab}");
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, "{Tab}{Home}{PageUp}{PageUp}{PageUp}{PageUp}");
            _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, "{Tab}");
            _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, "{Tab}{Home}{PageUp}{PageUp}{PageUp}{PageUp}");

            string sKeys = "";
            for (int i = 1; i < iCol; i++)
                sKeys = sKeys + "{Right}";
            if (sKeys != "")
                _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, sKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, sKeys);

            sKeys = "";
            for (int i = 0; i < iStartNumber; i++)
                sKeys = sKeys + "{Down}";
            if (sKeys != "")
                _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, sKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, sKeys);


            string sAct = "";
            Boolean bFind = false;
            for (int i = 0; i < 80; i++)
            {
                Clipboard.Clear();
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, "C", ModifierKeys.Control);
                _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, "C", 0, ModifierKeys.Control, false);
                
                sAct = Clipboard.GetText();

                if (sAct.Contains(dic["sData"]))
                {
                    bFind = true;
                    break;
                }

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, "{Down}");
                _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wIP_Matching_MatchingResults.tblMatchingResults, "{Down}");
            
            }
            if (!bFind)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to find : <" + dic["sData"] + ">. Please Verify!");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to find : <" + dic["sData"] + ">. Please Verify!");
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-Sep-05 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("sColumn", "EmployeeIDNumber");
        ///    dic.Add("sData", "314327834");
        ///    dic.Add("iStartNum", "5");
        ///    dic.Add("Query", "True");
        ///    dic.Add("Plug", "");
        ///    dic.Add("Ok", "");
        ///    pData._CK_CheckResults_SetFlag(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _CK_CheckResults_SetFlag(MyDictionary dic)
        {
            string sFunctionName = "_CK_CheckResults_SetFlag";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");
            int iRow = 1000;
            int iCol = 1000;

            int iStartNumber = 0;

            if (dic["iStartNum"] != "")
                iStartNumber = Convert.ToInt32(dic["iStartNum"]);



            switch (dic["sColumn"])
            {
                case "EmployeeIDNumber":
                    iCol = 1; 
                    break;
                default:
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because input Column Name <" + dic["sColumn"] + "> is NOT supported!");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because input Column Name <" + dic["sColumn"] + "> is NOT supported!");
                        break;
                    }

            }

            _gLib._SetSyncUDWin("Results table", this.wRetirementStudio.wCK_CheckResultsTab.tabFail, "Click", 0);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResultsTab.tabFail, "{Tab}");
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{Tab}{Home}{PageUp}{PageUp}{PageUp}{PageUp}");
            _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wCK_CheckResultsTab.tabFail, "{Tab}");
            _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{Tab}{Home}{PageUp}{PageUp}{PageUp}{PageUp}");

            string sKeys = "";
            for (int i = 0; i < iStartNumber; i++)
                sKeys = sKeys + "{Down}";
            if(sKeys!="")
                _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, sKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, sKeys);


            string sAct = "";
            Boolean bFind = false;
            for (int i = 0; i < 80; i++)
            {
                Clipboard.Clear();
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "C", ModifierKeys.Control);
                _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "C", 0, ModifierKeys.Control, false);

                try
                {
                    sAct = Clipboard.GetText();
                    if (sAct == dic["sData"])
                    {
                        bFind = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    _gLib._MsgBoxYesNo("", ex.Message);
                    // do nothing here because the msgbox function will give user option to quit or keep testing
                }



                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{Down}");
                _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{Down}");
            }
            if (!bFind)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to find : <" + dic["sData"] + ">. Please Verify!");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to find : <" + dic["sData"] + ">. Please Verify!");
            }
            else 
            {
                
                if (dic["Query"] != "")
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{End}{Left}{Left}{Left}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{Space}");
                    _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{End}{Left}{Left}{Left}{Space}");

                    Clipboard.Clear();
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "C", ModifierKeys.Control);
                    _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "C", 0, ModifierKeys.Control, false);

                    sAct = Clipboard.GetText();
                    if (sAct.ToUpper() != dic["Query"].ToUpper())
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set  Query : <" + dic["Query"] + "> to <" + dic["sData"] + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set  Query : <" + dic["Query"] + "> to <" + dic["sData"] + ">");
                    }
                }
                if (dic["Plug"] != "")
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{End}{Left}{Left}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{Space}");
                    _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{End}{Left}{Left}{Space}");
                    Clipboard.Clear();
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "C", ModifierKeys.Control);
                    _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "C", 0, ModifierKeys.Control, false);
                    sAct = Clipboard.GetText();
                    if (sAct.ToUpper() != dic["Plug"].ToUpper())
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set  Plug : <" + dic["Plug"] + "> to <" + dic["sData"] + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set  Plug : <" + dic["Plug"] + "> to <" + dic["sData"] + ">");
                    }
                }
                if (dic["Ok"] != "")
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{End}{Left}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{Space}");
                    _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "{End}{Left}{Space}");
                    Clipboard.Clear();
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "C", ModifierKeys.Control);
                    _gLib._SendKeysUDWin("Results table", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, "C", 0, ModifierKeys.Control, false);
                    sAct = Clipboard.GetText();
                    if (sAct.ToUpper() != dic["Ok"].ToUpper())
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set  Ok : <" + dic["Ok"] + "> to <" + dic["sData"] + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set  Ok : <" + dic["Ok"] + "> to <" + dic["sData"] + ">");
                    }
                }
            }

            #region poor performance codes

            ////if (iCol != 1000)
            ////{
            ////    if (dic["bReverseSearch"].ToUpper() == "TRUE")
            ////        iRow = _gLib._TBL_ReturnIndex_Row("", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, dic["sData"], iCol, 0, true);
            ////    else
            ////        iRow = _gLib._TBL_ReturnIndex_Row("", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, dic["sData"], iCol, 0, false);
            ////}
            ////string sTrueFalse = "";

            ////int iTotalCol = _gLib._TBL_ReturnTotalNumber_Col("", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, 0);

            ////if (dic["Query"] != "")
            ////{
            ////    iCol = iTotalCol - 3;
            ////    sTrueFalse = dic["Query"];
            ////}
            ////if (dic["Plug"] != "")
            ////{
            ////    iCol = iTotalCol - 2;
            ////    sTrueFalse = dic["Plug"];
            ////}
            ////if (dic["Ok"] != "")
            ////{
            ////    iCol = iTotalCol - 1;
            ////    sTrueFalse = dic["Ok"];
            ////}

            ////if (iRow != 1000)
            ////    _gLib._TBL_Table("Matching Results", this.wRetirementStudio.wCK_CheckResults.tblCheckResults, iRow, iCol, sTrueFalse, 0, false, true, true, false);
            

            #endregion

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-June-25
        /// webber.ling@mercer.com
        /// 
        /// pData._OM_Navigate("Current View");
        /// pData._OM_Navigate("Filter Summary");
        /// pData._OM_Navigate("Derivations Summary");
        /// </summary>
        /// <param name=""></param>
        public void _OM_Navigate(string sReport)
        {
            string sFunctionName = "_OM_Navigate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iPosX = 70;
            int iPosY = 10000;
            int iStepY = 20;


            int iReportRow = 0;
            int iReportRow_Right = 0;
      
            
            switch (sReport)
            {
                case "Prior View":
                    iReportRow = 1;
                    break;
                case "Current View":
                    iReportRow = 3;
                    break;
                case "Import Summary":
                    iReportRow = 5;
                    break;
                case "Manual Matching":
                    iReportRow = 6;
                    break;
                case "Simple Import Summary":
                    iReportRow = 8;
                    break;
                case "Filter Summary":
                    iReportRow = 10;
                    break;
                case "Derivations Summary":
                    iReportRow = 12;
                    break;
                case "Checks Results Summary":
                    iReportRow = 14;
                    break;
                case "Manual Update Summary":
                    iReportRow = 16;
                    break;
                case "Plugs Summary":
                    iReportRow = 18;
                    break;
                case "Corrections Summary":
                    iReportRow = 19;
                    break;
                case "Batch Update Summary":
                    iReportRow = 21;
                    break;
                case "Snapshot Summary":
                    iReportRow = 23;
                    break;
                case "Reports Summary":
                    iReportRow = 25;
                    break;
                case "View and Update":
                    iReportRow_Right = 4;
                    break;
                default:
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReport + ">. Please Verify!");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail: Invalid Report Name: <" + sReport + ">. Please Verify!");
                    break;
            }

            iPosY = iReportRow * iStepY + iStepY / 2;
            _gLib._SetSyncUDWin("Data Output Manager", this.wRetirementStudio.wOM_FPGrid.grid, "Click", 0, false, iPosX, iPosY);

            if (iReportRow_Right!=0)
            {
                iPosY = iReportRow_Right * iStepY + iStepY / 2;
                _gLib._SetSyncUDWin("Data Output Manager", this.wRetirementStudio.wOM_FPGrid_SupportingInfo.grid, "Click", 0, false, iPosX, iPosY);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        private void _OM_ExportItem(Boolean bPDFTrue_ExcelFalse)
        {
            pOutputManager._ExportItem("Data Reports", bPDFTrue_ExcelFalse);
 
        }
        
        
        /// <summary>
        /// 2013-June-26
        /// webber.ling@mercer.com
        /// 
        /// pData._OM_ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Reports Summary", true);
        /// pData._OM_ExportReport_Common(sOutputFunding_Conversion2011_Baseline, "Current View", true);
        /// 
        /// </summary>
        /// <param name=""></param>
        public void _OM_ExportReport_Common(string sReportDirctory, string sReportName, Boolean bPDFTrue_ExcelFalse)
        {

            string sFunctionName = "_OM_ExportReport_Common";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export report: " + sReportName);

            string sFileName = sReportDirctory + sReportName.Replace(" ", "").Replace("/", "");

            if (bPDFTrue_ExcelFalse)
                sFileName = sFileName + ".pdf";
            else
                sFileName = sFileName + ".xls";

            if (_gLib._Exists("Save", this.wOM_DataService_Popup, 0.5, 0.1, false))
                _gLib._SetSyncUDWin("NO", this.wOM_DataService_Popup.wNO.btnNo, "Click", 0);

            pMain._SelectTab("Data Output Manager");

            this._OM_Navigate(sReportName);

            pMain._SelectTab(sReportName);

            this._OM_ExportItem(bPDFTrue_ExcelFalse);

            this.pOutputManager._SaveAs(sFileName);

            _gLib._FileExists(sFileName, 3, true);
            

            pMain._Home_ToolbarClick_Top(false);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finished exporting report: " + sReportName);

        }

        public void _OM_ExportReport_Common(string sReportDirctory, string sReportName, Boolean bPDFTrue_ExcelFalse, Boolean bExcel2010)
        {

            string sFunctionName = "_OM_ExportReport_Common";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export report: " + sReportName);

            string sFileName = sReportDirctory + sReportName.Replace(" ", "").Replace("/", "");

            if (bPDFTrue_ExcelFalse)
                sFileName = sFileName + ".pdf";
            else
            { 
                if(bExcel2010)
                    sFileName = sFileName + ".xlsx";
                else
                    sFileName = sFileName + ".xls";
            }

            if (_gLib._Exists("Save", this.wOM_DataService_Popup, 0.5, 0.1, false))
                _gLib._SetSyncUDWin("NO", this.wOM_DataService_Popup.wNO.btnNo, "Click", 0);

            pMain._SelectTab("Data Output Manager");

            this._OM_Navigate(sReportName);

            pMain._SelectTab(sReportName);

            this._OM_ExportItem(bPDFTrue_ExcelFalse);

            this.pOutputManager._SaveAs(sFileName);

            _gLib._FileExists(sFileName, 3, true);


            pMain._Home_ToolbarClick_Top(false);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finished exporting report: " + sReportName);

        }


        /// <summary>
        /// 2013-June-26
        /// webber.ling@mercer.com
        /// 
        /// pData._OM_ExportReport_SubReports(sOutput_Data2012, "Import Summary", "Data2012_ImportSummary", 130, 1, true);
        /// pData._OM_ExportReport_SubReports(sOutput_Data2012, "Reports Summary", "Data2012_Plug", 130, 2, false);
        /// pData._OM_ExportReport_SubReports(sOutput_Data2012, "Simple Import Summary", "Data2012_SimpleImportSummary_SimpleImportDetail", 130, 1, false);
        /// pData._OM_ExportReport_SubReports(sOutput_Data2012, "Derivations Summary", "Data2012_DerivationSummary_Set12DigitsIDForBeneficiary", 105, 2, true);
        /// pData._OM_ExportReport_SubReports(sOutput_Data2012, "Batch Update Summary", "Data2012_BatchUpdateSummary_FixTermDate", 130, 1, false);
        /// 
        /// </summary>
        /// <param name=""></param>
        public string _OM_ExportReport_SubReports(string sReportDirctory, string sMainReportName, string sReportName, int iStartPoint_Y, int iSubReportRow, Boolean bPDFTrue_ExcelFalse)
        {

            string sFunctionName = "_OM_ExportReport_SubReports";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> going to export report: " + sMainReportName + " - "+ sReportName);

            string sFileName = sReportDirctory + sReportName.Replace(" ", "").Replace("/", "");

            string sPostFix = "";
            if (bPDFTrue_ExcelFalse)
                sPostFix = ".pdf";
            else
                sPostFix = ".xlsx";

            if (_gLib._Exists("Save", this.wOM_DataService_Popup, 0.5, 0.1, false))
                _gLib._SetSyncUDWin("NO", this.wOM_DataService_Popup.wNO.btnNo, "Click", 0);

            pMain._SelectTab("Data Output Manager");


            int iPosX = 30;
            int iPosY = 10000;
            int iStepY = 25;

            iStartPoint_Y = iStartPoint_Y + iStepY * 2;

            this._OM_Navigate(sMainReportName);


            iPosY = iStartPoint_Y + (iSubReportRow-1) * iStepY + iStepY / 2;
            _gLib._SetSyncUDWin(sMainReportName, this.wRetirementStudio.wOM_FPGrid_Report.grid, "Click", 0, false, iPosX, iPosY);


            switch (sMainReportName)
            {
                case "Reports Summary":
                    pOutputManager._Excel_SaveFile(sFileName + sPostFix);
                    _gLib._FileExists(sFileName + sPostFix, true);
                    break;
                case "Derivations Summary":
                    this._OM_ExportItem(bPDFTrue_ExcelFalse);
                    this.pOutputManager._SaveAs(sFileName + sPostFix);
                    _gLib._FileExists(sFileName + sPostFix, true);
                    break;
                case "Simple Import Summary":
                case "Batch Update Summary":
                    _gLib._SetSyncUDWin("Export to Excel", this.wRetirementStudio.wOM_ExporttoExcel.btnExporttoExcel, "Click", 0);
                    this.pOutputManager._SaveAs(sFileName + sPostFix);
                    _gLib._FileExists(sFileName + sPostFix, true);
                    break;
                case "Import Summary":
                    _gLib._TabPageSelectWin("Data File Mapping", this.wRetirementStudio.wOM_TabPage, 0);
                    this._OM_ExportItem(bPDFTrue_ExcelFalse);
                    this.pOutputManager._SaveAs(sFileName + "_DataFileMapping" + sPostFix);
                    _gLib._FileExists(sFileName + "_DataFileMapping" + sPostFix, true);

                    _gLib._TabPageSelectWin("Data File Pre-Matching Derivations", this.wRetirementStudio.wOM_TabPage, 0);
                    this._OM_ExportItem(bPDFTrue_ExcelFalse);
                    this.pOutputManager._SaveAs(sFileName + "_PMD" + sPostFix);
                    _gLib._FileExists(sFileName + "_PMD" + sPostFix, true);

                    _gLib._TabPageSelectWin("Data File Matching", this.wRetirementStudio.wOM_TabPage, 0);
                    this._OM_ExportItem(bPDFTrue_ExcelFalse);
                    this.pOutputManager._SaveAs(sFileName + "_DataFileMatching" + sPostFix);
                    _gLib._FileExists(sFileName + "_DataFileMatching" + sPostFix, true);

                    break;
                case "Snapshot Summary":
                    _gLib._TabPageSelectWin("Snapshot Summary", this.wRetirementStudio.wOM_TabPage, 0);
                    _gLib._SetSyncUDWin(sMainReportName, this.wRetirementStudio.wOM_FPGrid_Report.grid, "Click", 0, false, 380, 298);


                    _gLib._TabPageSelectWin("Member Statistics Report", this.wRetirementStudio.wOM_TabPage, 0);
                    string sFileName_1 = sFileName + "_MemberStatisticsReport";
                    this._OM_ExportItem(bPDFTrue_ExcelFalse);
                    this.pOutputManager._SaveAs(sFileName_1 + sPostFix);
                    _gLib._FileExists(sFileName_1 + sPostFix, true);

                    _gLib._TabPageSelectWin("Status Reconciliation-Data Reports", this.wRetirementStudio.wOM_TabPage, 0);
                    string sFileName_2 = sFileName + "_StatusReconciliation-DataReports";
                    this._OM_ExportItem(bPDFTrue_ExcelFalse);
                    this.pOutputManager._SaveAs(sFileName_2 + sPostFix);
                    _gLib._FileExists(sFileName_2 + sPostFix, true);

                    _gLib._TabPageSelectWin("Age/Service Matrix", this.wRetirementStudio.wOM_TabPage, 0);
                    string sFileName_3 = sFileName + "_AgeServiceMatrix";
                    this._OM_ExportItem(bPDFTrue_ExcelFalse);
                    this.pOutputManager._SaveAs(sFileName_3 + sPostFix);
                    _gLib._FileExists(sFileName_3 + sPostFix, true);

                    _gLib._TabPageSelectWin("Inactive Benefit Summary by Age Report", this.wRetirementStudio.wOM_TabPage, 0);
                    string sFileName_4 = sFileName + "_InactiveBenefitSummarybyAgeReport";
                    this._OM_ExportItem(bPDFTrue_ExcelFalse);
                    this.pOutputManager._SaveAs(sFileName_4 + sPostFix);
                    _gLib._FileExists(sFileName_4 + sPostFix, true);

                    break;

                default:
                    break;
            }

            

            pMain._Home_ToolbarClick_Top(false);
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> finished exporting report: " + sReportName);

            return sFileName + sPostFix;

            

        }


        /// <summary>
        /// 2013-Sep-17 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Plug", "");
        ///    dic.Add("Correction", "True");
        ///    dic.Add("NoFlag", "");
        ///    dic.Add("Preview", "Click");
        ///    dic.Add("Process", "Click");
        ///    pData._PopVerify_SimpleImport(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SimpleImport(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_SimpleImport";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("Plug", this.wRetirementStudio.wSI_Plug.rd, dic["Plug"], 0);
                _gLib._SetSyncUDWin("Correction", this.wRetirementStudio.wSI_Correction.rd, dic["Correction"], 0);
                _gLib._SetSyncUDWin("NoFlag", this.wRetirementStudio.wSI_NoFlag.rd, dic["NoFlag"], 0);
                _gLib._SetSyncUDWin("Preview", this.wRetirementStudio.wIP_Mapping_Preview.btnPreview, dic["Preview"], 0);
                _gLib._SetSyncUDWin("Process", this.wRetirementStudio.wSIP_Process.btnProcess, dic["Process"], 0);
                if (dic["Process"] != "")
                {
                    _gLib._Wait(Config.iWaitMedium);
                    _gLib._Exists("RetirementStudio", this.wRetirementStudio, 0, false);
                    _gLib._Enabled("RetirementStudio", this.wRetirementStudio, 0, false);
                }

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Plug", this.wRetirementStudio.wSI_Plug.rd, dic["Plug"], 0);
                _gLib._VerifySyncUDWin("Correction", this.wRetirementStudio.wSI_Correction.rd, dic["Correction"], 0);
                _gLib._VerifySyncUDWin("NoFlag", this.wRetirementStudio.wSI_NoFlag.rd, dic["NoFlag"], 0);
                _gLib._VerifySyncUDWin("Preview", this.wRetirementStudio.wIP_Mapping_Preview.btnPreview, dic["Preview"], 0);
                _gLib._VerifySyncUDWin("Process", this.wRetirementStudio.wSIP_Process.btnProcess, dic["Process"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-Sep-17 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("BatchUpdateName", "BatchUpdate1");
        ///    dic.Add("SelectFieldstoDisplay", "Click");
        ///    dic.Add("StandardorCustomFilter_rd", "");
        ///    dic.Add("StandardorCustomFilter_cbo", "");
        ///    dic.Add("CustomExpression_rd", "");
        ///    dic.Add("CustomExpression_Formula", "");
        ///    dic.Add("CustomExpression_Accept", "");
        ///    dic.Add("Apply", "");
        ///    dic.Add("Plug", "");
        ///    dic.Add("Correction", "");
        ///    dic.Add("SaveToWarehouse", "");
        ///    pData._PopVerify_BatchUpdate(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_BatchUpdate(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_BatchUpdate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("BatchUpdateName", this.wRetirementStudio.wBU_BatchUpdateName.txtBatchUpdateName, dic["BatchUpdateName"], 0);
                _gLib._SetSyncUDWin("SelectFieldstoDisplay", this.wRetirementStudio.wBU_SelectFieldstoUpdate.btnSelectFieldstoUpdate, dic["SelectFieldstoDisplay"], 0);
                _gLib._SetSyncUDWin("StandardorCustomFilter_rd", this.wRetirementStudio.wBU_StandardorCustomFilter.rdStandardorCustomFilter, dic["StandardorCustomFilter_rd"], 0);
                ////_gLib._SetSyncUDWin("StandardorCustomFilter_cbo", this.wRetirementStudio.wBU_StandardorCustomFilter_cbo.cboFilter, dic["StandardorCustomFilter_cbo"], 0);
            
                
                if (dic["StandardorCustomFilter_cbo"] != "")
                {
                    _gLib._SetSyncUDWin("StandardorCustomFilter_cbo dropdown", this.wRetirementStudio.wBU_StandardorCustomFilter_cbo.btnDropDown, "Click", 0);
                    _gLib._SetSyncUDWin("StandardorCustomFilter_cbo", this.wRetirementStudio.wBU_StandardorCustomFilter_cbo.cboFilter, dic["StandardorCustomFilter_cbo"], 0);

                }
                
                _gLib._SetSyncUDWin("CustomExpression_rd", this.wRetirementStudio.wBU_CustomExpression.rdCustomExpression, dic["CustomExpression_rd"], 0);

                if (dic["CustomExpression_Formula"]!="")
                {
                    try 
                    {
                        this.wRetirementStudio.wBU_CustomExpressionFormula.txtFormula.Text = String.Empty;
                    }
                    catch (Exception ex)
                    {
                        _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set Edit object <CustomExpression_Formula>. Because exception threw out: " + Environment.NewLine + ex.Message);
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set Edit object <CustomExpression_Formula>.  Because exception threw out: " + Environment.NewLine + ex.Message);
                    }
                    _gLib._SetSyncUDWin_ByClipboard("CustomExpression_Formula", this.wRetirementStudio.wBU_CustomExpressionFormula.txtFormula, dic["CustomExpression_Formula"], 0);
                }
                _gLib._SetSyncUDWin("CustomExpression_Accept", this.wRetirementStudio.wBU_CustomExpressionAccept.btnAccept, dic["CustomExpression_Accept"], 0);
                _gLib._SetSyncUDWin("Apply", this.wRetirementStudio.wBU_Apply.btnApply, dic["Apply"], 0);
                _gLib._SetSyncUDWin("Plug", this.wRetirementStudio.wBU_Plug.rdPlug, dic["Plug"], 0);
                _gLib._SetSyncUDWin("Correction", this.wRetirementStudio.wBU_Correction.rdCorrection, dic["Correction"], 0);
                _gLib._SetSyncUDWin("SaveToWarehouse", this.wRetirementStudio.wBU_SavetoWarehouse.btnSavetoWarehouse, dic["SaveToWarehouse"], 0);
                if (dic["SaveToWarehouse"] != "")
                    _gLib._Enabled("", this.wRetirementStudio, 30, false);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("BatchUpdateName", this.wRetirementStudio.wBU_BatchUpdateName.txtBatchUpdateName, dic["BatchUpdateName"], 0);
                _gLib._VerifySyncUDWin("SelectFieldstoDisplay", this.wRetirementStudio.wBU_SelectFieldstoUpdate.btnSelectFieldstoUpdate, dic["SelectFieldstoDisplay"], 0);
                _gLib._VerifySyncUDWin("StandardorCustomFilter_rd", this.wRetirementStudio.wBU_StandardorCustomFilter.rdStandardorCustomFilter, dic["StandardorCustomFilter_rd"], 0);
                _gLib._VerifySyncUDWin("StandardorCustomFilter_cbo", this.wRetirementStudio.wBU_StandardorCustomFilter_cbo.cboFilter, dic["StandardorCustomFilter_cbo"], 0);
                _gLib._VerifySyncUDWin("CustomExpression_rd", this.wRetirementStudio.wBU_CustomExpression.rdCustomExpression, dic["CustomExpression_rd"], 0);
                _gLib._VerifySyncUDWin("CustomExpression_Formula", this.wRetirementStudio.wBU_CustomExpressionFormula.txtFormula, dic["CustomExpression_Formula"], 0);
                _gLib._VerifySyncUDWin("CustomExpression_Accept", this.wRetirementStudio.wBU_CustomExpressionAccept.btnAccept, dic["CustomExpression_Accept"], 0);
                _gLib._VerifySyncUDWin("Apply", this.wRetirementStudio.wBU_Apply.btnApply, dic["Apply"], 0);
                _gLib._VerifySyncUDWin("Plug", this.wRetirementStudio.wBU_Plug.rdPlug, dic["Plug"], 0);
                _gLib._VerifySyncUDWin("Correction", this.wRetirementStudio.wBU_Correction.rdCorrection, dic["Correction"], 0);
                _gLib._VerifySyncUDWin("SaveToWarehouse", this.wRetirementStudio.wBU_SavetoWarehouse.btnSavetoWarehouse, dic["SaveToWarehouse"], 0);


            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Sep-17 
        /// webber.ling@mercer.com
        /// 
        /// 
        /// </summary>
        /// <param name="sSearchField"></param>
        /// <param name="iCol_1"></param>
        /// <param name="sColValue_1"></param>
        /// <param name="iCol_2"></param>
        /// <param name="sColValue_2"></param>
        /// sample:
        /// pData._BU_FPGrid("641562271", 3, "38713.51", 4, "annualized 2012 pay rate");
        /// 
        public void _BU_FPGrid(string sSearchField, int iCol_1, string sColValue_1, int iCol_2, string sColValue_2 )
        {
            string sFunctionName = "_BU_FPGrid";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("Batch FP Grid", wRetirementStudio.wBU_FPGrid.grid, "Click", 0, false, 50, 30);
            ////////////Keyboard.SendKeys("{Tab}");
            _gLib._SendKeysUDWin("Batch FP Grid", wRetirementStudio.wBU_FPGrid.grid, "{Tab}");
            _gLib._SetSyncUDWin("Batch FP Grid", wRetirementStudio.wBU_FPGrid.grid, "Click", 0, false, 50, 30);
            //if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBU_FPGrid.grid) == sSearchField)
            //{
            //    _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> : Label: " + sLabelName + " is already selected!");
            //    return;
            //}


            int iSearchMax = 100;

            if (this._fp._Navigate(this.wRetirementStudio.wBU_FPGrid.grid, sSearchField, iSearchMax))
            {
                string sKeys = "";
                string sAct = "";
                if (iCol_1 != 0)
                {
                    for (int i = 1; i < iCol_1; i++)
                        sKeys = sKeys + "{Right}";
                    
                    ////////////Keyboard.SendKeys(sKeys);
                    ////////////Keyboard.SendKeys(sColValue_1 + "{Enter}");
                    _gLib._SendKeysUDWin("Batch FP Grid", wRetirementStudio.wBU_FPGrid.grid, sKeys);
                    _gLib._SendKeysUDWin("Batch FP Grid", wRetirementStudio.wBU_FPGrid.grid, sColValue_1 + "{Enter}");

                    sAct = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBU_FPGrid.grid);
                    if (sAct == sColValue_1)
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> : successfully set value: <" + sColValue_1 + "> at column <" + iCol_1 + "> to Label: <" + sSearchField + ">");
                    else
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> : Fail to set value: <" + sColValue_1 + "> at column <" + iCol_1 + "> to Label: <" + sSearchField + ">, actual value <" + sAct);
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> : Fail to set value: <" + sColValue_1 + "> at column <" + iCol_1 + "> to Label: <" + sSearchField + ">, actual value <" + sAct);
                    }
                    ////////////Keyboard.SendKeys("{Home}");
                    _gLib._SendKeysUDWin("Batch FP Grid", wRetirementStudio.wBU_FPGrid.grid, "{Home}");
                }

                sKeys = "";
                if (iCol_2 != 0)
                {
                    for (int i = 1; i < iCol_2; i++)
                        sKeys = sKeys + "{Right}";
                    
                    ////////////Keyboard.SendKeys(sKeys);
                    ////////////Keyboard.SendKeys(sColValue_2 + "{Enter}");
                    _gLib._SendKeysUDWin("Batch FP Grid", wRetirementStudio.wBU_FPGrid.grid, sKeys);
                    _gLib._SendKeysUDWin("Batch FP Grid", wRetirementStudio.wBU_FPGrid.grid, sColValue_2 + "{Enter}");

                    sAct = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wBU_FPGrid.grid);
                    if (sAct == sColValue_2)
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> : successfully set value: <" + sColValue_2 + "> at column <" + iCol_2 + "> to Label: <" + sSearchField + ">");
                    else
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> : Fail to set value: <" + sColValue_2 + "> at column <" + iCol_2 + "> to Label: <" + sSearchField + ">, actual value <" + sAct);
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> : Fail to set value: <" + sColValue_2 + "> at column <" + iCol_2 + "> to Label: <" + sSearchField + ">, actual value <" + sAct);
                    }
                    ////////////Keyboard.SendKeys("{Home}");
                    _gLib._SendKeysUDWin("Batch FP Grid", wRetirementStudio.wBU_FPGrid.grid, "{Home}");
                }

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2013-Sep-18
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AddFilter", "");
        ///    dic.Add("DeleteHighlightedFilter", "");
        ///    pData._PopVerify_Filters(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Filters(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Filters";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("AddFilter", this.wRetirementStudio.wFL_AddFilter.btnAddFilter, dic["AddFilter"], 0);
                _gLib._SetSyncUDWin("DeleteHighlightedFilter", this.wRetirementStudio.wFL_DeleteHighlightedFilter.btnDeleteHighlightedFilter, dic["DeleteHighlightedFilter"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("AddFilter", this.wRetirementStudio.wFL_AddFilter.btnAddFilter, dic["AddFilter"], 0);
                _gLib._VerifySyncUDWin("DeleteHighlightedFilter", this.wRetirementStudio.wFL_DeleteHighlightedFilter.btnDeleteHighlightedFilter, dic["DeleteHighlightedFilter"], 0);


            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2013-Sep-18
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pData._FL_Grid("Custom", 53, false);
        /// </summary>
        /// <param name="sFilter"></param>
        /// <param name="iDownNum"></param>
        /// <param name="bClickEdit"></param>
        public void _FL_Grid(string sFilter, int iDownNum, Boolean bClickEdit)
        {
            string sFunctionName = "_FL_Grid";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            // revert to first row, first column
            ////////////Mouse.Click(this.wRetirementStudio.wFL_FPGrid.grid, new Point(30, 30));
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFL_FPGrid.grid, "{Home}{PageUp}{PageUp}{PageUp}");
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wFL_FPGrid.grid, "Click", 0, false, 30, 30);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFL_FPGrid.grid, "{Home}{PageUp}{PageUp}{PageUp}");
            
            int iDownNumMax = 100;
            Boolean bFind = false;


            string sSkipDownKey = "";
            for (int i = 0; i < iDownNum; i++)
                sSkipDownKey = sSkipDownKey + "{Down}";
            if (sSkipDownKey != "")
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFL_FPGrid.grid, sSkipDownKey);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFL_FPGrid.grid, sSkipDownKey);


            for (int i = 0; i <= iDownNumMax; i++)
            {
                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFL_FPGrid.grid) == sFilter)
                {
                    bFind = true;
                    break;
                }
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFL_FPGrid.grid, "{Down}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFL_FPGrid.grid, "{Down}");
            }

            if (!bFind)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to find expected filter <" + sFilter + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail because fail to find expected filter <" + sFilter + ">");
            }

            if(bClickEdit)
            {

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Right}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{space}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wFL_FPGrid.grid, "{Right}{Space}");

            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends");
        }


        /// <summary>
        /// 2013-Sep-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pData._ts_Undo("PostMatchDerivations for 2. Date Calc for Act/Def", 0, "Fix Start Date for Tier 2 Members");
        /// </summary>
        /// <param name="sUndoEntry"></param>
        /// <param name="iSearchFrom"></param>
        /// <param name="sUndoComments"></param>
        public void _ts_Undo(string sUndoEntry, int iSearchFrom, string sUndoComments)
        {
            string sFunctionName = "_ts_Undo";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Boolean bFindEntry = this._ts_SearchUndoItem(sUndoEntry, iSearchFrom);

            if (!bFindEntry)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to find undo entry <" + sUndoEntry + "> ");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to find undo entry <" + sUndoEntry + "> ");
            }

            _gLib._SetSyncUDWin("Undo", this.wRetirementStudio.wUndo_Undo.btnUndo, "Click", 0);

            if (_gLib._Exists("Upload", this.wUndo_Popup, 1, false))
                _gLib._SetSyncUDWin("OK", this.wUndo_Popup.wYes.btn, "click", 0);

            _gLib._SetSyncUDWin_ByClipboard("Undo comments", this.wUndo_ConfirmUndo.wComments.txtComments, sUndoComments, 0);
            _gLib._SetSyncUDWin("OK", this.wUndo_ConfirmUndo.wOK.btnOK, "Click", 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2015-Oct-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pData._ts_SearchUndoItem("PostMatchDerivations for 2. Date Calc for Act/Def", 0);
        /// </summary>
        /// <param name="sUndoEntry"></param>
        /// <param name="iSearchFrom"></param>
        /// <returns></returns>
        public Boolean _ts_SearchUndoItem(string sUndoEntry, int iSearchFrom)
        {
            string sFunctionName = "_ts_SearchUndoItem";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("rdShowUndo", this.wRetirementStudio.wUndo_ShowHideUndoEntries.wGroup.rdShowUndo, "Click", 0);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wUndo_FPGrid.grid, "{PageUp}{PageUp}{PageUp}");
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wUndo_FPGrid.grid, "{PageUp}{PageUp}{PageUp}");
            _gLib._SetSyncUDWin("rdHideUndo", this.wRetirementStudio.wUndo_ShowHideUndoEntries.wGroup.rdHideUndo, "Click", 0);

            _gLib._SetSyncUDWin("Entry entries", this.wRetirementStudio.wUndo_FPGrid.grid, "Click", 0, false, 50, 30);

            string sKeys = "";
            for (int i = 0; i < iSearchFrom; i++)
                sKeys = sKeys + "{Down}";

            if (sKeys != "")
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wUndo_FPGrid.grid, sKeys);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wUndo_FPGrid.grid, sKeys);

            string sAct = "";
            Boolean bFindEntry = false;
            for (int i = 0; i <= 30; i++)
            {
                Clipboard.Clear();
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wUndo_FPGrid.grid, "c", ModifierKeys.Control);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wUndo_FPGrid.grid, "c", 0, ModifierKeys.Control, false);
                sAct = Clipboard.GetText();

                if (sAct.Contains(sUndoEntry))
                {
                    bFindEntry = true;
                    break;
                }

                ////////////Keyboard.SendKeys(this.wRetirementStudio.wUndo_FPGrid.grid, "{Down}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wUndo_FPGrid.grid, "{Down}");
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> End");

            return bFindEntry;
            

        }

        /// <summary>
        /// 2013-Sep-22 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Yes", "Click");
        ///    pData._PopVerify_BU_DeleteBatchUpdate_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_BU_DeleteBatchUpdate_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_BU_DeleteBatchUpdate_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Yes", this.wBU_DeleteBatchUpdate.wYes.btnYes, dic["Yes"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Yes", this.wBU_DeleteBatchUpdate.wYes.btnYes, dic["Yes"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Sep-22 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pData._ts_SP_CreateExtract(sOutput_Data2012 + "Data2012_SnapshotExtract.xls");
        /// </summary>
        /// <param name="sFileName"></param>
        public string _ts_SP_CreateExtract(string sFileName)
        {

            string res = "";

            string sFunctionName = "_ts_SP_CreateExtract";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "Click");
            this._PopVerify_Snapshots(dic);

            if (_gLib._Exists("Save Project", this.wSP_Snapshot_Popup, 1, false))
            {
                MyDictionary tmpDic = new MyDictionary();
                tmpDic.Clear();
                tmpDic.Add("PopVerify", "Pop");
                tmpDic.Add("OK", "click");
                this._PopVerify_SP_Snapshots_Popup(tmpDic);
            }


            this.pOutputManager._SaveAs(sFileName);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            this._PopVerify_SP_ExtractCreated_Popup(dic);

            if (!_gLib._FileExists(sFileName, 120, false))
                res = "E_FileNotSaved";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

            return res;


        }

        public string _ts_SP_CreateExtract_BusinessSupport(string sFileName)
        {

            string res = "";

            string sFunctionName = "_ts_SP_CreateExtract";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "Click");
            this._PopVerify_Snapshots(dic);

            if (_gLib._Exists("Save Project", this.wSP_Snapshot_Popup, 1, false))
            {
                MyDictionary tmpDic = new MyDictionary();
                tmpDic.Clear();
                tmpDic.Add("PopVerify", "Pop");
                tmpDic.Add("OK", "click");
                this._PopVerify_SP_Snapshots_Popup(tmpDic);
            }


            this.pOutputManager._SaveAs(sFileName);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            this._PopVerify_SP_ExtractCreated_Popup(dic);

            _gLib._Wait(3);

            if (_gLib._Exists("wSP_ExtractCreated", this.wSP_ExtractCreated.wOK.btnOK, 1, 1, false))
                _gLib._SetSyncUDWin("OK", this.wSP_ExtractCreated.wOK.btnOK, dic["OK"], 0);

 

            if (!_gLib._FileExists(sFileName, 120, false))
                res = "E_FileNotSaved";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

            return res;


        }
        /// <summary>
        /// 2013-Sep-22 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "click");
        ///    this._PopVerify_SP_ExtractCreated_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        private void _PopVerify_SP_ExtractCreated_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_SP_ExtractCreated_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._Exists("wSP_ExtractCreated", this.wSP_ExtractCreated.wOK.btnOK, Config.iTimeout * 20);
                _gLib._SetSyncUDWin("OK", this.wSP_ExtractCreated.wOK.btnOK, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wSP_ExtractCreated.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Sep-25 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("sDataFileRecords", "330929586");
        ///    dic.Add("sWarehouseRecords", "900330929586");
        ///    dic.Add("bExactMatch", "");
        ///    dic.Add("iMaxSeachNum", "");
        ///    dic.Add("AcceptSelectedDataFile_AsNew", "");
        ///    dic.Add("AcceptSelectedDataFile_AsIgnore", "");
        ///    dic.Add("Close", "");
        ///    pData._IP_MatchManually(dic); 
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("sDataFileRecords", "FC298277G");
        ///    dic.Add("sWarehouseRecords", "");
        ///    dic.Add("bExactMatch", "");
        ///    dic.Add("iMaxSeachNum", "");
        ///    dic.Add("AcceptSelectedDataFile_AsNew", "Click");
        ///    dic.Add("AcceptSelectedDataFile_AsIgnore", "");
        ///    dic.Add("Close", "");
        ///    pData._IP_MatchManually(dic); 
        ///    
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("sDataFileRecords", "");
        ///    dic.Add("sWarehouseRecords", "63314192");
        ///    dic.Add("bExactMatch", "");
        ///    dic.Add("iMaxSeachNum", "");
        ///    dic.Add("AcceptSelectedDataFile_AsNew", "");
        ///    dic.Add("AcceptSelectedDataFile_AsIgnore", "");
        ///    dic.Add("AcceptSelectedWH_AsUnmatched", "Click");
        ///    dic.Add("AcceptSelectedWH_AsGone", "");
        ///    dic.Add("AcceptSelectedWH_AsLeaver", "");
        ///    dic.Add("Close", "");
        ///    pData._IP_MatchManually(dic); 
        ///    
        /// 
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _IP_MatchManually(MyDictionary dic)
        {
     

            string sFunctionName = "_IP_MatchManually";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iMaxSeachNum = 20;
            if (dic["iMaxSeachNum"] != "")
                iMaxSeachNum = Convert.ToInt32(dic["iMaxSeachNum"]);
            
            Boolean bExactMatch = false;
            if (dic["bExactMatch"].ToUpper() != "TRUE")
                bExactMatch = true;

            _gLib._SetSyncUDWin("Data File Records table", this.wIP_ManualMatching.wDataFileRecords.tbl.topRow.topLeftHeader, "Click", 0, false, 10, 10);
            ////////////Keyboard.SendKeys(this.wIP_ManualMatching.wDataFileRecords.tbl, "{PageUp}");
            _gLib._SendKeysUDWin("Data File Records table", this.wIP_ManualMatching.wDataFileRecords.tbl, "{PageUp}");

            Boolean bFindDataRecords = false;
            string sAct = "";
            if (dic["sDataFileRecords"]!="")
            {
                for (int i = 1; i < iMaxSeachNum; i++)
                {
                
                    Clipboard.Clear();
                    ////////////Keyboard.SendKeys(this.wIP_ManualMatching.wDataFileRecords.tbl, "C", ModifierKeys.Control);
                    _gLib._SendKeysUDWin("Data File Records table", this.wIP_ManualMatching.wDataFileRecords.tbl, "C", 0, ModifierKeys.Control, false);
                    sAct = Clipboard.GetText();

                    if (bExactMatch && (sAct == dic["sDataFileRecords"]))
                    {
                        bFindDataRecords = true;
                        break;
                    }
                    else if (sAct.Contains(dic["sDataFileRecords"]))
                    {
                        bFindDataRecords = true;
                        break;
                    }
                    ////////////Keyboard.SendKeys(this.wIP_ManualMatching.wDataFileRecords.tbl, "{Down}");
                    _gLib._SendKeysUDWin("Data File Records table", this.wIP_ManualMatching.wDataFileRecords.tbl, "{Down}");

                }
                if (!bFindDataRecords)
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to find Data File Records <" + dic["sDataFileRecords"] + "> ");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to find Data File Records <" + dic["sDataFileRecords"] + "> ");
                }
            }


            if (dic["sWarehouseRecords"]!="")
            {
                _gLib._SetSyncUDWin("Warehouse Records table", this.wIP_ManualMatching.wWarehouseRecords.tbl.topRow.topLeftHeader, "Click", 0, false, 10, 10);
                ////////////Keyboard.SendKeys(this.wIP_ManualMatching.wWarehouseRecords.tbl, "{PageUp}");
                _gLib._SendKeysUDWin("Warehouse Records table", this.wIP_ManualMatching.wWarehouseRecords.tbl, "{PageUp}");


                Boolean bFindWarehouseRecords = false;
                for (int i = 0; i < iMaxSeachNum; i++)
                {
                
                    Clipboard.Clear();
                    ////////////Keyboard.SendKeys(this.wIP_ManualMatching.wWarehouseRecords.tbl, "C", ModifierKeys.Control);
                    _gLib._SendKeysUDWin("Warehouse Records table", this.wIP_ManualMatching.wWarehouseRecords.tbl, "C", 0, ModifierKeys.Control, false);
                    sAct = Clipboard.GetText();

                    if (bExactMatch && (sAct == dic["sWarehouseRecords"]))
                    {
                        bFindWarehouseRecords = true;
                        break;
                    }
                    else if (sAct.Contains(dic["sWarehouseRecords"]))
                    {
                        bFindWarehouseRecords = true;
                        break;
                    }
                    ////////////Keyboard.SendKeys(this.wIP_ManualMatching.wWarehouseRecords.tbl, "{Down}");
                    _gLib._SendKeysUDWin("Warehouse Records table", this.wIP_ManualMatching.wWarehouseRecords.tbl, "{Down}");

                }
                if (!bFindWarehouseRecords)
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to find Warehouse File Records <" + dic["sWarehouseRecords"] + "> ");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to find Warehouse File Records <" + dic["sWarehouseRecords"] + "> ");
                }

                if (bFindDataRecords && bFindWarehouseRecords)
                    _gLib._SetSyncUDWin("Match Accept", this.wIP_ManualMatching.wMatchAccept.btnMatchAccept, "Click", 0);
            }

            _gLib._SetSyncUDWin("AcceptSelectedDataFile_AsNew", this.wIP_ManualMatching.wAcceptSelectedDataFile_AsNew.btn, dic["AcceptSelectedDataFile_AsNew"], 0);
            _gLib._SetSyncUDWin("AcceptSelectedDataFile_AsIgnore", this.wIP_ManualMatching.wAcceptSelectedDataFile_AsIgnore.btn, dic["AcceptSelectedDataFile_AsIgnore"], 0);
            _gLib._SetSyncUDWin("AcceptSelectedWH_AsUnmatched", this.wIP_ManualMatching.wAcceptSelectedWH_AsUnmatched.btn, dic["AcceptSelectedWH_AsUnmatched"], 0);
            _gLib._SetSyncUDWin("AcceptSelectedWH_AsGone", this.wIP_ManualMatching.wAcceptSelectedWH_AsGone.btn, dic["AcceptSelectedWH_AsGone"], 0);
            _gLib._SetSyncUDWin("AcceptSelectedWH_AsLeaver", this.wIP_ManualMatching.wAcceptSelectedWH_AsLeaver.btn, dic["AcceptSelectedWH_AsLeaver"], 0);
            _gLib._SetSyncUDWin("Close", this.wIP_ManualMatching.wClose.btnClose, dic["Close"], 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-Sep-30 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// pData._IP_ExpandMainCategory_FromEnd("Work Fields", 2, "PaymentFromDescription");
        ///    
        /// </summary>
        /// <param name="sCategory"></param>
        /// <param name="iIndexFromEnd"></param>
        /// <param name="sCheckLabelName"></param>
        public void _IP_ExpandMainCategory_FromEnd(string sCategory, int iIndexFromEnd, string sCheckLabelName)
        {
            string sFunctionName = "_IP_ExpandMainCategory_FromEnd";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Boolean bFind = false;

            int ixStart_Level1 = 6;
            int iyStep_Level1 = 20;
            int iBottomOffset = 8;

            int iXPos = ixStart_Level1;
            int iYPos = 0;
            this._fp._ClickFirstRow(this.wRetirementStudio.wFPGrid.grid, 20, 25);

            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}");
            _gLib._SendKeysUDWin("Mapping Grid", this.wRetirementStudio.wFPGrid.grid, "{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}");

            string sKeys = "";
            for (int i = 1; i < iIndexFromEnd; i++)
                sKeys = sKeys + "{Up}";
            if(sKeys!="")
                _gLib._SendKeysUDWin("Mapping Grid", this.wRetirementStudio.wFPGrid.grid, sKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKeys);

            if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) != sCategory)
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail to find < " + sCategory + "> from End Index <" + iIndexFromEnd + ">, Please double check!");
            else
            {
                int iBottom = this.wRetirementStudio.wFPGrid.grid.BoundingRectangle.Height; //547
                iYPos = iBottom - (iBottomOffset + (iIndexFromEnd - 1) * iyStep_Level1 + iyStep_Level1/2);

                ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iXPos, iYPos));
                _gLib._SetSyncUDWin("Mapping Grid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iXPos, iYPos);

                if (sCheckLabelName == "")
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail because sCheckLabelName can NOT be Blank! Quit Function!");
                else
                {
                    Boolean bExpanded = false;
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                    _gLib._SendKeysUDWin("Mapping Grid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                    for (int i = 0; i < 10; i++)
                    {
                        if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid.grid) != sCheckLabelName)
                        {
                            ////////////Mouse.Click(this.wRetirementStudio.wFPGrid.grid, new Point(iXPos, iYPos - 5 + i));
                            ////////////Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Down}");
                            _gLib._SetSyncUDWin("Mapping Grid", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, iXPos, iYPos - 5 + i);
                            _gLib._SendKeysUDWin("Mapping Grid", this.wRetirementStudio.wFPGrid.grid, "{Down}");
                        }
                        else
                            bExpanded = true;
                    }
                    if (!bExpanded)
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to expand  node <" + sCategory + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> failed because fail to expand  node <" + sCategory + ">");
                    }

                }

                
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-Sep-30 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// pData._CK_ExpandGroup_FromEnd("Conversion Checks", 1, "Pay is under 30K or over 100K");
        ///    
        /// </summary>
        /// <param name="sGroupName"></param>
        /// <param name="iIndexFromEnd"></param>
        /// <param name="sCheckLabelName"></param>
        public void _CK_ExpandGroup_FromEnd(string sGroupName, int iIndexFromEnd, string sCheckLabelName)
        {
            string sFunctionName = "_CK_ExpandGroup_FromEnd";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Boolean bFind = false;

            int ixStart_Level1 = 26;
            int iyStep_Level1 = 18;
            int iBottomOffset = 20;

            int iXPos = ixStart_Level1;
            int iYPos = 0;
            this._fp._ClickFirstRow(this.wRetirementStudio.wCK_FPGrid.grid, 20, 50);

            ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}");
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}");
            _gLib._SendKeysUDWin("Check Grid", this.wRetirementStudio.wCK_FPGrid.grid, "{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}");
            _gLib._SendKeysUDWin("Check Grid", this.wRetirementStudio.wCK_FPGrid.grid, "{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}{PageDown}");


            string sKeys = "";
            for (int i = 1; i < iIndexFromEnd; i++)
                sKeys = sKeys + "{Up}";
            if (sKeys != "")
                _gLib._SendKeysUDWin("Check Grid", this.wRetirementStudio.wCK_FPGrid.grid, sKeys);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, sKeys);

            if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wCK_FPGrid.grid) != sGroupName)
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail to find < " + sGroupName + "> from End Index <" + iIndexFromEnd + ">, Please double check!");
            else
            {
                int iBottom = this.wRetirementStudio.wCK_FPGrid.grid.BoundingRectangle.Height; //211
                iYPos = iBottom - (iBottomOffset + (iIndexFromEnd - 1) * iyStep_Level1 + iyStep_Level1 / 2);

                ////////////Mouse.Click(this.wRetirementStudio.wCK_FPGrid.grid, new Point(iXPos, iYPos));
                _gLib._SetSyncUDWin("Check Grid", this.wRetirementStudio.wCK_FPGrid.grid, "Click", 0, false, iXPos, iYPos);

                if (sCheckLabelName == "")
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail because sCheckLabelName can NOT be Blank! Quit Function!");
                else
                {
                    Boolean bExpanded = false;
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Down}");
                    _gLib._SendKeysUDWin("Check Grid", this.wRetirementStudio.wCK_FPGrid.grid, "{Down}");
                    for (int i = 0; i < 20; i++)
                    {
                        if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wCK_FPGrid.grid) != sCheckLabelName)
                        {
                            ////////////Mouse.Click(this.wRetirementStudio.wCK_FPGrid.grid, new Point(iXPos, iYPos - 5 + i));
                            ////////////Keyboard.SendKeys(this.wRetirementStudio.wCK_FPGrid.grid, "{Down}");
                            _gLib._SetSyncUDWin("Check Grid", this.wRetirementStudio.wCK_FPGrid.grid, "Click", 0, false, iXPos, iYPos - 20 + i);
                            _gLib._SendKeysUDWin("Check Grid", this.wRetirementStudio.wCK_FPGrid.grid, "{Down}");

                        }
                        else
                            bExpanded = true;
                    }

                    if (!bExpanded)
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to expand  node <" + sGroupName + ">");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> failed because fail to expand  node <" + sGroupName + ">");
                    }

                }


            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2015-Mar-18
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pData._ts_UpdateIncludedVOs("Jub1", true);
        ///    pData._ts_UpdateIncludedVOs("Jub1", false);
        /// </summary>
        /// <param name="sVOShortName"></param>
        /// <param name="bInclude"></param>
        public void _ts_UpdateIncludedVOs(string sVOShortName, Boolean bInclude)
        {
            string sFunctionName = "_ts_UpdateIncludedVOs";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("VOsIncludedForService", this.wRetirementStudio.wFPGrid_VOsIncludedForService.grid, "Click", 0, false, 100, 30);
            _gLib._SendKeysUDWin("VOsIncludedForService", this.wRetirementStudio.wFPGrid_VOsIncludedForService.grid, "{Home}{PageUp}{Right}");

            int iDownNumMax = 10;
            Boolean bFind = false;


            for (int i = 0; i <= iDownNumMax; i++)
            {
                if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wFPGrid_VOsIncludedForService.grid) == sVOShortName)
                {
                    bFind = true;
                    break;
                }
                _gLib._SendKeysUDWin("VOsIncludedForService", this.wRetirementStudio.wFPGrid_VOsIncludedForService.grid, "{Down}");
            }

            if (!bFind)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to find expected VOShortName <" + sVOShortName + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail because fail to find expected VOShortName <" + sVOShortName + ">");
            }


            string sAct = "";
            _gLib._SendKeysUDWin("VOsIncludedForService", this.wRetirementStudio.wFPGrid_VOsIncludedForService.grid, "{Left}");
            Clipboard.Clear();
            _gLib._SendKeysUDWin("VOsIncludedForService", this.wRetirementStudio.wFPGrid_VOsIncludedForService.grid, "C", 0, ModifierKeys.Control, false);
            sAct = Clipboard.GetText().ToUpper();
            if(!sAct.Contains("TRUE") && bInclude)
                _gLib._SendKeysUDWin("VOsIncludedForService", this.wRetirementStudio.wFPGrid_VOsIncludedForService.grid, "{Space}");
            if (sAct.Contains("TRUE") && !bInclude)
                _gLib._SendKeysUDWin("VOsIncludedForService", this.wRetirementStudio.wFPGrid_VOsIncludedForService.grid, "{Space}");


            //// verify the results
            _gLib._SendKeysUDWin("VOsIncludedForService", this.wRetirementStudio.wFPGrid_VOsIncludedForService.grid, "{Right}{Left}");

            Clipboard.Clear();
            _gLib._SendKeysUDWin("VOsIncludedForService", this.wRetirementStudio.wFPGrid_VOsIncludedForService.grid, "C", 0, ModifierKeys.Control, false);
            sAct = Clipboard.GetText().ToUpper();
            if (!sAct.Contains("TRUE") && bInclude)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to set TRUE to VO <" + sVOShortName + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail because fail to set TRUE to VO  <" + sVOShortName + ">");
            }
            if (sAct.Contains("TRUE") && !bInclude)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to set FALSE to VO <" + sVOShortName + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail because fail to set FALSE to VO  <" + sVOShortName + ">");
            }

            _gLib._SetSyncUDWin("UpdateIncludedVOs", this.wRetirementStudio.wUpdateIncludedVOs.btn, "Click",0);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends");
        }



        /// <summary>
        /// 2015-Mar-22 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Client", Config.sClientName);
        ///    dic.Add("Plan", Config.sPlanName);
        ///    dic.Add("Service", "Data2012");
        ///    dic.Add("OK", "");
        ///    pData._PopVerify_DG_CopyDerivations(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DG_CopyDerivations(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_DG_CopyDerivations";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Client", this.wDG_CopyDerivations.wClient.cbo, dic["Client"], 0);
                _gLib._SetSyncUDWin("Plan", this.wDG_CopyDerivations.wPlan.cbo, dic["Plan"], 0);
                _gLib._SetSyncUDWin("Service", this.wDG_CopyDerivations.wService.cbo, dic["Service"], 0);
                _gLib._SetSyncUDWin("OK", this.wDG_CopyDerivations.wOK.btn, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Client", this.wDG_CopyDerivations.wClient.cbo, dic["Client"], 0);
                _gLib._VerifySyncUDWin("Plan", this.wDG_CopyDerivations.wPlan.cbo, dic["Plan"], 0);
                _gLib._VerifySyncUDWin("Service", this.wDG_CopyDerivations.wService.cbo, dic["Service"], 0);
                _gLib._VerifySyncUDWin("OK", this.wDG_CopyDerivations.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Oct-22 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Import", "ImportRFActives");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_IP_CopyMappings(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_CopyMappings(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_CopyMappings";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Import", this.wIP_CopyMappings.wList.list, dic["Import"], 0);
                _gLib._SetSyncUDWin("OK", this.wIP_CopyMappings.wOK.btn, dic["OK"], 0);

                ///// 2017-04-01 detected this message box no longer exists
                //////if(dic["OK"]!="")
                //////    _gLib._SetSyncUDWin("OK", this.wIP_CopyMappings_Popup.btn, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._SetSyncUDWin("Import", this.wIP_CopyMappings.wList.list, dic["Import"], 0);
                _gLib._VerifySyncUDWin("OK", this.wDG_CopyDerivations.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-July-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "All");
        ///    dic.Add("Level_2", "Import Data");
        ///    pData._TreeViewSelect_CopyImports(dic, true);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewSelect_CopyImports(MyDictionary dic, Boolean bChecked)
        {
            string sFunctionName = "_TreeViewSelect_CopyImports";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewCheckBoxSelectWin(0, this.wIP_CopyImports.tv, dic, bChecked);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Mar-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "All");
        ///    dic.Add("Level_2", "Set Jubilee Benefit 1");
        ///    pData._TreeViewSelect_CopyDerivations(dic, true);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewSelect_CopyDerivations(MyDictionary dic, Boolean bChecked)
        {
            string sFunctionName = "_TreeViewSelect_CopyDerivations";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewCheckBoxSelectWin(0, this.wDG_CopyDerivations.wDerivationGroups.tv, dic, bChecked);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2015-Mar-22 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Copy", "click");
        ///    pData._PopVerify_CopyValidationErrors(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CopyValidationErrors(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_CopyValidationErrors";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Copy", this.wCopyValidationErrors.wCopy.btn, dic["Copy"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Copy", this.wCopyValidationErrors.wCopy.btn, dic["Copy"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2015-Mar-22 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "click");
        ///    pData._PopVerify_DataAcquisitions(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DataAcquisitions(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_DataAcquisitions";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wDataAcquisition.wOK.btn, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wDataAcquisition.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-June-27
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ViewSetName", "");
        ///    dic.Add("SelectLabelsToView", "");
        ///    dic.Add("Filter", "");
        ///    dic.Add("SimpleQuery", "");
        ///    dic.Add("SimpleQuery_Field", "");
        ///    dic.Add("SimpleQuery_Operator", "");
        ///    dic.Add("Simplequery_Value", "");
        ///    dic.Add("Apply", "Click");
        ///    dic.Add("GenerateSummary", "");
        ///    dic.Add("PrintAll", "");
        ///    dic.Add("PrintToFile", "");
        ///    dic.Add("ViewAllManualChanges", "");
        ///    pData._PopVerify_ViewUpdate(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ViewUpdate(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_ViewUpdate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ViewSetName", this.wRetirementStudio.wVU_ViewSetName.txt, dic["ViewSetName"], 0);
                _gLib._SetSyncUDWin("SelectLabelsToView", this.wRetirementStudio.wVU_SelectLabelsToView.btn, dic["SelectLabelsToView"], 0);
                _gLib._SetSyncUDWin("Filter", this.wRetirementStudio.wVU_Filter.cbo, dic["Filter"], 0);
                
                _gLib._SetSyncUDWin("SimpleQuery", this.wRetirementStudio.wVU_SimpleQuery.rd, dic["SimpleQuery"], 0);
                _gLib._SetSyncUDWin("SimpleQuery_Field", this.wRetirementStudio.wVU_SimpleQuery_Field.cbo, dic["SimpleQuery_Field"], 0);
                _gLib._SetSyncUDWin("SimpleQuery_Operator", this.wRetirementStudio.wVU_SimpleQuery_Operator.cbo, dic["SimpleQuery_Operator"], 0);
                _gLib._SetSyncUDWin("Simplequery_Value", this.wRetirementStudio.wVU_Simplequery_Value.txt, dic["Simplequery_Value"], 0);
                _gLib._SetSyncUDWin("Apply", this.wRetirementStudio.wVU_Apply.btn, dic["Apply"], 0);
                _gLib._SetSyncUDWin("GenerateSummary", this.wRetirementStudio.wVU_GenerateSummary.btn, dic["GenerateSummary"], 0);
                _gLib._SetSyncUDWin("PrintAll", this.wRetirementStudio.wVU_PrintAll.btn, dic["PrintAll"], 0);
                _gLib._SetSyncUDWin("PrintToFile", this.wRetirementStudio.wVU_PrintToFile.btn, dic["PrintToFile"], 0);
                _gLib._SetSyncUDWin("ViewAllManualChanges", this.wRetirementStudio.wVU_ViewAllManualChanges.btn, dic["ViewAllManualChanges"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("ViewSetName", this.wRetirementStudio.wVU_ViewSetName.txt, dic["ViewSetName"], 0);
                _gLib._VerifySyncUDWin("SelectLabelsToView", this.wRetirementStudio.wVU_SelectLabelsToView.btn, dic["SelectLabelsToView"], 0);
                _gLib._VerifySyncUDWin("Filter", this.wRetirementStudio.wVU_Filter.cbo, dic["Filter"], 0);
                _gLib._VerifySyncUDWin("SimpleQuery", this.wRetirementStudio.wVU_SimpleQuery.rd, dic["SimpleQuery"], 0);
                _gLib._VerifySyncUDWin("SimpleQuery_Field", this.wRetirementStudio.wVU_SimpleQuery_Field.cbo, dic["SimpleQuery_Field"], 0);
                _gLib._VerifySyncUDWin("SimpleQuery_Operator", this.wRetirementStudio.wVU_SimpleQuery_Operator.cbo, dic["SimpleQuery_Operator"], 0);
                _gLib._VerifySyncUDWin("Simplequery_Value", this.wRetirementStudio.wVU_Simplequery_Value.txt, dic["Simplequery_Value"], 0);
                _gLib._VerifySyncUDWin("Apply", this.wRetirementStudio.wVU_Apply.btn, dic["Apply"], 0);
                _gLib._VerifySyncUDWin("GenerateSummary", this.wRetirementStudio.wVU_GenerateSummary.btn, dic["GenerateSummary"], 0);
                _gLib._VerifySyncUDWin("PrintAll", this.wRetirementStudio.wVU_PrintAll.btn, dic["PrintAll"], 0);
                _gLib._VerifySyncUDWin("PrintToFile", this.wRetirementStudio.wVU_PrintToFile.btn, dic["PrintToFile"], 0);
                _gLib._VerifySyncUDWin("ViewAllManualChanges", this.wRetirementStudio.wVU_ViewAllManualChanges.btn, dic["ViewAllManualChanges"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Aug-20 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Yes", "");
        ///    pData._PopVerify_CK_Warning_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CK_Warning_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_CK_Warning_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wCK_Warning_Popup.wOK.btn, dic["OK"], 0);
                _gLib._SetSyncUDWin("Yes", this.wCK_Warning_Popup.wYes.btn, dic["Yes"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wCK_Warning_Popup.wOK.btn, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Yes", this.wCK_Warning_Popup.wYes.btn, dic["Yes"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Aug-20 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Yes", "click");
        ///    pData._PopVerify_IP_ClearMapping(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_ClearMapping(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_ClearMapping";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Yes", this.wIP_ClearMappings.wYes.btn, dic["Yes"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Yes", this.wIP_ClearMappings.wYes.btn, dic["Yes"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Oct-20 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_Complete_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Complete_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_Complete_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._Exists("", this.wComplete_Popup, Config.iTimeout * 20);
                _gLib._SetSyncUDWin("OK", this.wComplete_Popup.wOK.btn, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wComplete_Popup.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Oct-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Derivation", "All");
        ///    dic.Add("Calculate", "Click");
        ///    pData._PopVerify_DG_RunDerivationsInBatch(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DG_RunDerivationsInBatch(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_DG_RunDerivationsInBatch";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

          
            if (dic["PopVerify"] == "Pop")
            {


                if (dic["Derivation"].ToUpper().Equals("ALL"))
                {
                    try
                    {

                        this.wDG_RunDerivationsinBatch.tvDerivations.chkAll.Checked = true;
                    }
                    catch (Exception ex)
                    {
                        _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to check on CheckBox <" + dic["Derivation"] + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to check on CheckBox <" + dic["Derivation"] + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    }
                }

                _gLib._SetSyncUDWin("Calculate", this.wDG_RunDerivationsinBatch.wCalculate.btn, dic["Calculate"], 0);
 

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("OK", this.wUndo_Popup.wYes.btn, dic["Yes"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2015-Oct-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_DG_DerivationsBatchRun(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DG_DerivationsBatchRun(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_DG_DerivationsBatchRun";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("OK", this.wDG_DerivationBatchRun.wOK.btn, dic["OK"], 0);


            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wDG_DerivationBatchRun.wOK.btn, dic["OK"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-Sep-17 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Service", "");
        ///    dic.Add("Pay", "");
        ///    dic.Add("Pension", "");
        ///    dic.Add("ApplyPctContinuedtoPen", "");
        ///    dic.Add("CashBalance", "");
        ///    dic.Add("OK", "");
        ///    dic.Add("Cancel", "");
        ///    pData._PopVerify_SP_DataSummaryReportsParam(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SP_DataSummaryReportsParam(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_SP_DataSummaryReportsParam";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Service", this.wSP_DataSummaryReportsParam.wService.cbo, dic["Service"], 0);
                _gLib._SetSyncUDWin("Pay", this.wSP_DataSummaryReportsParam.wPay.cbo, dic["Pay"], 0);
                _gLib._SetSyncUDWin("Pension", this.wSP_DataSummaryReportsParam.wPension.cbo, dic["Pension"], 0);
                _gLib._SetSyncUDWin("ApplyPctContinuedtoPen", this.wSP_DataSummaryReportsParam.wApplyPctContinuedtoPen.chk, dic["ApplyPctContinuedtoPen"], 0);
                _gLib._SetSyncUDWin("CashBalance", this.wSP_DataSummaryReportsParam.wCashBalance.cbo, dic["CashBalance"], 0);
                _gLib._SetSyncUDWin("OK", this.wSP_DataSummaryReportsParam.wOK.btn, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wSP_DataSummaryReportsParam.wCancel.btn, dic["Cancel"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Preview", this.wRetirementStudio.wIP_Mapping_Preview.btnPreview, dic["Preview"], 0);
                _gLib._VerifySyncUDWin("Service", this.wSP_DataSummaryReportsParam.wService.cbo, dic["Service"], 0);
                _gLib._VerifySyncUDWin("Pay", this.wSP_DataSummaryReportsParam.wPay.cbo, dic["Pay"], 0);
                _gLib._VerifySyncUDWin("Pension", this.wSP_DataSummaryReportsParam.wPension.cbo, dic["Pension"], 0);
                _gLib._VerifySyncUDWin("ApplyPctContinuedtoPen", this.wSP_DataSummaryReportsParam.wApplyPctContinuedtoPen.chk, dic["ApplyPctContinuedtoPen"], 0);
                _gLib._VerifySyncUDWin("CashBalance", this.wSP_DataSummaryReportsParam.wCashBalance.cbo, dic["CashBalance"], 0);
                _gLib._VerifySyncUDWin("OK", this.wSP_DataSummaryReportsParam.wOK.btn, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wSP_DataSummaryReportsParam.wCancel.btn, dic["Cancel"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Oct-28 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("R1C1", "");
        ///    dic.Add("R1C2", "");
        ///    dic.Add("R2C1", "");
        ///    dic.Add("R2C2", "");
        ///    dic.Add("R3C1", "");
        ///    dic.Add("R3C2", "");
        ///    dic.Add("R4C1", "");
        ///    dic.Add("R4C2", "");
        ///    dic.Add("R5C1", "");
        ///    dic.Add("R5C2", "");
        ///    dic.Add("R6C1", "");
        ///    dic.Add("R6C2", "");
        ///    dic.Add("OK", "");
        ///    dic.Add("Cancel", "");
        ///    pData._PopVerify_IP_Status_2Column(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Status_2Column(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_Status_2Column";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                if (dic["R1C1"]!="")
                    this.wIP_Mapping_Status2Column.wMapView.wTable.cell_11.cell.Value = dic["R1C1"];
                if (dic["R1C2"] != "")
                    this.wIP_Mapping_Status2Column.wMapView.wTable.cell_12.cell.Value = dic["R1C2"];
                if (dic["R2C1"] != "")
                    this.wIP_Mapping_Status2Column.wMapView.wTable.cell_21.cell.Value = dic["R2C1"];
                if (dic["R2C2"] != "")
                    this.wIP_Mapping_Status2Column.wMapView.wTable.cell_22.cell.Value = dic["R2C2"];
                if (dic["R3C1"] != "")
                    this.wIP_Mapping_Status2Column.wMapView.wTable.cell_31.cell.Value = dic["R3C1"];
                if (dic["R3C2"] != "")
                    this.wIP_Mapping_Status2Column.wMapView.wTable.cell_32.cell.Value = dic["R3C2"];
                if (dic["R4C1"] != "")
                    this.wIP_Mapping_Status2Column.wMapView.wTable.cell_41.cell.Value = dic["R4C1"];
                if (dic["R4C2"] != "")
                    this.wIP_Mapping_Status2Column.wMapView.wTable.cell_42.cell.Value = dic["R4C2"];
                if (dic["R5C1"] != "")
                    this.wIP_Mapping_Status2Column.wMapView.wTable.cell_51.cell.Value = dic["R5C1"];
                if (dic["R5C2"] != "")
                    this.wIP_Mapping_Status2Column.wMapView.wTable.cell_52.cell.Value = dic["R5C2"];
                if (dic["R6C1"] != "")
                    this.wIP_Mapping_Status2Column.wMapView.wTable.cell_61.cell.Value = dic["R6C1"];
                if (dic["R6C2"] != "")
                    this.wIP_Mapping_Status2Column.wMapView.wTable.cell_62.cell.Value = dic["R6C2"];


                _gLib._SetSyncUDWin("OK", this.wIP_Mapping_Status2Column.wOK.btn, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wIP_Mapping_Status2Column.wCancel.btn, dic["Cancel"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {


                _gLib._MsgBox("warning", "No Verify codes here!");

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2015-Oct-28 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("R1C1", "");
        ///    dic.Add("R1C2", "");
        ///    dic.Add("R1C3", "");
        ///    dic.Add("R2C1", "");
        ///    dic.Add("R2C2", "");
        ///    dic.Add("R2C3", "");
        ///    dic.Add("R3C1", "");
        ///    dic.Add("R3C2", "");
        ///    dic.Add("R3C3", "");
        ///    dic.Add("R4C1", "");
        ///    dic.Add("R4C2", "");
        ///    dic.Add("R4C3", "");
        ///    dic.Add("R5C1", "");
        ///    dic.Add("R5C2", "");
        ///    dic.Add("R5C3", "");
        ///    dic.Add("R6C1", "");
        ///    dic.Add("R6C2", "");
        ///    dic.Add("R6C3", "");
        ///    dic.Add("OK", "");
        ///    dic.Add("Cancel", "");
        ///    pData._PopVerify_IP_Status_3Column(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IP_Status_3Column(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_IP_Status_3Column";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                if (dic["R1C1"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_11.cell.Value = dic["R1C1"];
                if (dic["R1C2"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_12.cell.Value = dic["R1C2"];
                if (dic["R1C3"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_13.cell.Value = dic["R1C3"];
                if (dic["R2C1"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_21.cell.Value = dic["R2C1"];
                if (dic["R2C2"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_22.cell.Value = dic["R2C2"];
                if (dic["R2C3"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_23.cell.Value = dic["R2C3"];
                if (dic["R3C1"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_31.cell.Value = dic["R3C1"];
                if (dic["R3C2"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_32.cell.Value = dic["R3C2"];
                if (dic["R3C3"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_33.cell.Value = dic["R3C3"];
                if (dic["R4C1"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_41.cell.Value = dic["R4C1"];
                if (dic["R4C2"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_42.cell.Value = dic["R4C2"];
                if (dic["R4C3"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_43.cell.Value = dic["R4C3"];
                if (dic["R5C1"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_51.cell.Value = dic["R5C1"];
                if (dic["R5C2"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_52.cell.Value = dic["R5C2"];
                if (dic["R5C3"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_53.cell.Value = dic["R5C3"];
                if (dic["R6C1"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_61.cell.Value = dic["R6C1"];
                if (dic["R6C2"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_62.cell.Value = dic["R6C2"];
                if (dic["R6C3"] != "")
                    this.wIP_Mapping_Status3Column.wMapView.wTable.cell_63.cell.Value = dic["R6C3"];

                _gLib._SetSyncUDWin("OK", this.wIP_Mapping_Status2Column.wOK.btn, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wIP_Mapping_Status2Column.wCancel.btn, dic["Cancel"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {


                _gLib._MsgBox("warning", "No Verify codes here!");

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Oct-28 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("R1C1", "");
        ///    dic.Add("R1C2", "");
        ///    dic.Add("R2C1", "");
        ///    dic.Add("R2C2", "");
        ///    dic.Add("R3C1", "");
        ///    dic.Add("R3C2", "");
        ///    dic.Add("R4C1", "");
        ///    dic.Add("R4C2", "");
        ///    dic.Add("R5C1", "");
        ///    dic.Add("R5C2", "");
        ///    dic.Add("R6C1", "");
        ///    dic.Add("R6C2", "");
        ///    dic.Add("R7C1", "");
        ///    dic.Add("R7C2", "");
        ///    dic.Add("R8C1", "");
        ///    dic.Add("R8C2", "");
        ///    dic.Add("R9C1", "");
        ///    dic.Add("R9C2", "");
        ///    dic.Add("R10C1", "");
        ///    dic.Add("R10C2", "");
        ///    dic.Add("R11C1", "");
        ///    dic.Add("R11C2", "");
        ///    dic.Add("R12C1", "");
        ///    dic.Add("R12C2", "");
        ///    dic.Add("R13C1", "");
        ///    dic.Add("R13C2", "");
        ///    dic.Add("R14C1", "");
        ///    dic.Add("R14C2", "");
        ///    dic.Add("OK", "");
        ///    pData._PopVerify_CV_StatusUSCTable(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CV_StatusUSCTable(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_CV_StatusUSCTable";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                if (dic["R1C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_11.cell.Value = dic["R1C1"];
                if (dic["R1C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_12.cell.Value = dic["R1C2"];
                if (dic["R2C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_21.cell.Value = dic["R2C1"];
                if (dic["R2C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_22.cell.Value = dic["R2C2"];
                if (dic["R3C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_31.cell.Value = dic["R3C1"];
                if (dic["R3C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_32.cell.Value = dic["R3C2"];
                if (dic["R4C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_41.cell.Value = dic["R4C1"];
                if (dic["R4C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_42.cell.Value = dic["R4C2"];
                if (dic["R5C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_51.cell.Value = dic["R5C1"];
                if (dic["R5C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_52.cell.Value = dic["R5C2"];
                if (dic["R6C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_61.cell.Value = dic["R6C1"];
                if (dic["R6C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_62.cell.Value = dic["R6C2"];

                if (dic["R7C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_71.cell.Value = dic["R7C1"];
                if (dic["R7C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_72.cell.Value = dic["R7C2"];
                if (dic["R8C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_81.cell.Value = dic["R8C1"];
                if (dic["R8C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_82.cell.Value = dic["R8C2"];
                if (dic["R9C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_91.cell.Value = dic["R9C1"];
                if (dic["R9C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_92.cell.Value = dic["R9C2"];


                if (dic["R10C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_101.cell.Value = dic["R10C1"];
                if (dic["R10C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_102.cell.Value = dic["R10C2"];
                if (dic["R11C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_111.cell.Value = dic["R11C1"];
                if (dic["R11C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_112.cell.Value = dic["R11C2"];
                if (dic["R12C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_121.cell.Value = dic["R12C1"];
                if (dic["R12C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_122.cell.Value = dic["R12C2"];
                if (dic["R13C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_131.cell.Value = dic["R13C1"];
                if (dic["R13C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_132.cell.Value = dic["R13C2"];
                if (dic["R14C1"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_141.cell.Value = dic["R14C1"];
                if (dic["R14C2"] != "")
                    this.wCV_StatusUSCTable.wLookUp.wTable.cell_142.cell.Value = dic["R14C2"];


                _gLib._SetSyncUDWin("OK", this.wCV_StatusUSCTable.wOK.btn, dic["OK"], 0);

                if(dic["OK"]!="")
                    _gLib._SetSyncUDWin("OK", this.wConfirm_Popup.wOK.btn, "Click", 0);


            }

            if (dic["PopVerify"] == "Verify")
            {


                _gLib._MsgBox("warning", "No Verify codes here!");

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Oct-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ActuarialTable", "");
        ///    dic.Add("Index1_V", "");
        ///    dic.Add("Index1_C", "");
        ///    dic.Add("Index2_V", "");
        ///    dic.Add("Index2_C", "");
        ///    dic.Add("Index1_cbo", "");
        ///    dic.Add("Index1_txt", "");
        ///    dic.Add("Index2_cbo", "");
        ///    dic.Add("Index2_txt", "");
        ///    dic.Add("Gender", "");
        ///    dic.Add("OK", "Click");
        ///    pData._PopVerify_DG_ActuarialTableFunctionDefinition(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DG_ActuarialTableFunctionDefinition(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_DG_ActuarialTableFunctionDefinition";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iIndex_cbo = 2;
            int iIndex_txt = 1;

           


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ActuarialTable", this.wDG_ActuarialTableFunctionDefinition.wActuarialTable.cbo, dic["ActuarialTable"], 0);
                _gLib._SetSyncUDWin("Index1_V", this.wDG_ActuarialTableFunctionDefinition.wIndex1_V.btn, dic["Index1_V"], 0);
                _gLib._SetSyncUDWin("Index1_C", this.wDG_ActuarialTableFunctionDefinition.wIndex1_C.btn, dic["Index1_C"], 0);
                _gLib._SetSyncUDWin("Index2_V", this.wDG_ActuarialTableFunctionDefinition.wIndex2_V.btn, dic["Index2_V"], 0);
                _gLib._SetSyncUDWin("Index2_C", this.wDG_ActuarialTableFunctionDefinition.wIndex2_C.btn, dic["Index2_C"], 0);

                if (dic["Index1_cbo"] != "")
                {
                    this.wDG_ActuarialTableFunctionDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iIndex_cbo.ToString());
                    _gLib._SetSyncUDWin("Index1_cbo", this.wDG_ActuarialTableFunctionDefinition.wCommon_cbo.cbo, dic["Index1_cbo"], 0);
                    iIndex_cbo = iIndex_cbo - 1;
                }
                if (dic["Index1_txt"] != "")
                {
                    this.wDG_ActuarialTableFunctionDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iIndex_txt.ToString());
                    _gLib._SetSyncUDWin("Index1_txt", this.wDG_ActuarialTableFunctionDefinition.wCommon_txt.txt, dic["Index1_txt"], 0);
                    iIndex_txt = iIndex_txt + 1;
                }
                if (dic["Index2_cbo"] != "")
                {
                    this.wDG_ActuarialTableFunctionDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iIndex_cbo.ToString());
                    _gLib._SetSyncUDWin("Index2_cbo", this.wDG_ActuarialTableFunctionDefinition.wCommon_cbo.cbo, dic["Index2_cbo"], 0);
        
                }
                if (dic["Index2_txt"] != "")
                {
                    this.wDG_ActuarialTableFunctionDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iIndex_txt.ToString());
                    _gLib._SetSyncUDWin("Index2_txt", this.wDG_ActuarialTableFunctionDefinition.wCommon_txt.txt, dic["Index2_txt"], 0);
               
                }

                _gLib._SetSyncUDWin("Gender", this.wDG_ActuarialTableFunctionDefinition.wGender.cbo, dic["Gender"], 0);
                _gLib._SetSyncUDWin("OK", this.wDG_ActuarialTableFunctionDefinition.wOK.btn, dic["OK"], 0);


            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("warning", "No verify code here!");

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Oct-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");  
        ///    dic.Add("Label", "");
        ///    dic.Add("UpdatedValue", "");
        ///    dic.Add("OK", "click");
        ///    pData._PopVerify_VU_IR_MannualUpdate(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_VU_IR_MannualUpdate(MyDictionary dic)
        {
            
            string sFunctionName = "_PopVerify_VU_IR_MannualUpdate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

         
            if (dic["PopVerify"] == "Pop")
            {
                _gLib._Wait(2);
                
                for (int i = 1; i <= 20; i++)
                {                 
                    this.wRetirementStudio.wVU_IR_Grid.wTable.wRow.SearchProperties.Add(WinRow.PropertyNames.Instance, i.ToString());

                    string sTemp = this.wRetirementStudio.wVU_IR_Grid.wTable.wRow.Value.ToString();

                    if (sTemp.Contains(dic["Label"]))
                    {
                        try
                        {
                            Mouse.DoubleClick(this.wRetirementStudio.wVU_IR_Grid.wTable.wRow.wCol);
                        }
                        catch (Exception e)
                        {
                            _gLib._MsgBoxYesNo("", "fail to double click the value of label: " + dic["Label"]);
                        }
                        break;
                    }
                }

                _gLib._SetSyncUDWin("Label", this.wVU_IR_ManualCorrection.wUpdatedValue.txt, dic["lable"], 0);
                _gLib._SetSyncUDWin("UpdatedValue", this.wVU_IR_ManualCorrection.wUpdatedValue.txt, dic["UpdatedValue"], 0);
                _gLib._SetSyncUDWin("UpdatedValue", this.wVU_IR_ManualCorrection.wComments.txt, dic["UpdatedValue"], 0);
                _gLib._SetSyncUDWin("OK", this.wVU_IR_ManualCorrection.wOK.btn, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("warning", "No verify code here!");

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2019-Apr-12 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// pData._VU_FPGrid_Click(0, "YearsCertain1_C"); 
        /// 
        /// </summary>
        /// <param name="iRow"></param>
        /// <param name="sCol"></param>
        public void _VU_FPGrid_Click(int iRow, string sCol)
        {
            string sFunctionName = "_PopVerify_VU_IR_MannualUpdate";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            WinTable wTBL = new WinTable(this.wRetirementStudio.wVU_FPGrid);
            WinRow wRow = new WinRow(wTBL);
            wRow.SearchProperties.Add(WinRow.PropertyNames.Name, "Row " + iRow.ToString());
            WinCell cell = new WinCell(wRow);
            cell.SearchProperties.Add(WinRow.PropertyNames.Name, sCol + " Row " + iRow.ToString());

            _gLib._SetSyncUDWin(sCol + " " + iRow.ToString(), cell, "click", 0);
            Mouse.DoubleClick(cell, new Point(3, 3));

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Oct-08 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");  
        ///    dic.Add("Plug", "True");
        ///    dic.Add("Correction", "");
        ///    dic.Add("UpdatedValue", "1");
        ///    dic.Add("Comments", "1");
        ///    dic.Add("OK", "click");
        ///    pData._PopVerify_VU_MannualCorrection(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_VU_MannualCorrection(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_VU_MannualCorrection";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Plug", this.wVU_IR_ManualCorrection.wPlug.rd, dic["Plug"], 0);
                _gLib._SetSyncUDWin("Correction", this.wVU_IR_ManualCorrection.wCorrection.rd, dic["Correction"], 0);
                _gLib._SetSyncUDWin("UpdatedValue", this.wVU_IR_ManualCorrection.wUpdatedValue.txt, dic["UpdatedValue"], 0);
                _gLib._SetSyncUDWin("Comments", this.wVU_IR_ManualCorrection.wComments.txt, dic["UpdatedValue"], 0);
                _gLib._SetSyncUDWin("OK", this.wVU_IR_ManualCorrection.wOK.btn, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Plug", this.wVU_IR_ManualCorrection.wPlug.rd, dic["Plug"], 0);
                _gLib._VerifySyncUDWin("Correction", this.wVU_IR_ManualCorrection.wCorrection.rd, dic["Correction"], 0);
                _gLib._VerifySyncUDWin("UpdatedValue", this.wVU_IR_ManualCorrection.wUpdatedValue.txt, dic["UpdatedValue"], 0);
                _gLib._VerifySyncUDWin("Comments", this.wVU_IR_ManualCorrection.wComments.txt, dic["UpdatedValue"], 0);
                _gLib._VerifySyncUDWin("OK", this.wVU_IR_ManualCorrection.wOK.btn, dic["OK"], 0);


            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 
        /// pData._VU_SelectTotalFields("USC", 7, false, true, true, false, false);
        /// </summary>
        /// <param name="sLabel"></param>
        /// <param name="iDownNum"></param>
        /// <param name="bTotal"></param>
        /// <param name="bBreak"></param>
        /// <param name="bLaunchDialg"></param>
        /// <param name="bClickOK"></param>
        public void _VU_SelectTotalFields(string sLabel, int iDownNum, bool bTotal, bool bBreak, bool bLaunchDialg, bool bClickOK, bool bContinueOnCurrent=true)
        {

            string sFunctionName = "_VU_SelectTotalFields";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if(bLaunchDialg)
                _gLib._SetSyncUDWin("Plug", this.wRetirementStudio.wVU_DataSummary_SelectTotalFields.btn, "click", 0);


            if(!bContinueOnCurrent)
                _gLib._SetSyncUDWin("Grid", this.wVU_SelectTotalsFields.FPGrid.gird, "click", 0, false, 30, 30);


            bool bFind = false;
            string sSkipDownKey = "";

            for (int i = 0; i < iDownNum; i++)
                sSkipDownKey = sSkipDownKey + "{Down}";
            if (sSkipDownKey != "")
                _gLib._SendKeysUDWin("FPGrid", this.wVU_SelectTotalsFields.FPGrid.gird, sSkipDownKey);


            for (int i = 0; i <= 100; i++)
            {
                if (this._fp._ReturnSelectRowContent(this.wVU_SelectTotalsFields.FPGrid.gird) == sLabel)
                {
                    bFind = true;
                    break;
                }
                _gLib._SendKeysUDWin("FPGrid", this.wVU_SelectTotalsFields.FPGrid.gird, "{Down}");
            }

            if (!bFind)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to find expected node <" + sLabel + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail because fail to find expected node <" + sLabel + ">");
            }
            else
            {

                string sRight = "";
                if (bTotal)
                    sRight = "{Right}";
                if (bBreak)
                    sRight = "{Right}{Right}";


                _gLib._SendKeysUDWin("FPGrid", this.wVU_SelectTotalsFields.FPGrid.gird, sRight);
                _gLib._SendKeysUDWin("FPGrid", this.wVU_SelectTotalsFields.FPGrid.gird, "{Space}");

                _gLib._SendKeysUDWin("FPGrid", this.wVU_SelectTotalsFields.FPGrid.gird, "{Home}");
                _gLib._SendKeysUDWin("FPGrid", this.wVU_SelectTotalsFields.FPGrid.gird, sRight);

                string sStatus = this._fp._ReturnSelectRowContent(this.wVU_SelectTotalsFields.FPGrid.gird);

                if (sStatus != "True")
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed because fail to check on  <" + sLabel + ">");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail because fail to check on  <" + sLabel + ">");
                }

            }


            _gLib._SendKeysUDWin("FPGrid", this.wVU_SelectTotalsFields.FPGrid.gird, "{Home}");


            if (bClickOK)
                _gLib._SetSyncUDWin("Plug", this.wVU_SelectTotalsFields.wOK.btn, "click", 0);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }

    }
}
