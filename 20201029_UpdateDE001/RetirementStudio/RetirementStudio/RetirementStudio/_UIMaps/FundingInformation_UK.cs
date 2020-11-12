namespace RetirementStudio._UIMaps.FundingInformation_UKClasses
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
    using System.Diagnostics;
    using RetirementStudio._UIMaps.OutputManagerClasses;



    public partial class FundingInformation_UK
    {


        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        /// 
        ///    pFundingInformation_UK._SelectTab("");
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _SelectTab(String sName)
        {
            string sFunctionName = "_PopVerify_NetAssets";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TabPageSelectWin(sName, this.wRetirementStudio.wTab.wTabList, Config.iTimeout);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        /// 
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("VPCServiceContainingBasis", "");
        ///    pFundingInformation_UK._RegularValuation_GeneralParameters(dic);
        ///    
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_GeneralParameters(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_GeneralParameters";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("", this.wRetirementStudio.wGP_VPCServiceContainingBasis.cbo, dic["VPCServiceContainingBasis"], 0);

            if (_gLib._Exists("", this.wSelectVPC.wOK.btn, 5, false))
                _gLib._SetSyncUDWin("", this.wSelectVPC.wOK.btn, "click", 0);

        }


        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Col1", "");
        ///    dic.Add("Col2", "");
        ///    dic.Add("Col3", "");
        ///    pFundingInformation_UK._RegularValuation_DataMovements_Actives(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_DataMovements_Actives(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_DataMovements_Actives";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";


                //////WinWindow wWin = new WinWindow(this.wRetirementStudio.wDM_ActivesTable.grid);
                //////wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.EDIT", PropertyExpressionOperator.Contains);
                WinEdit wEdit = new WinEdit(this.wRetirementStudio.wDM_ActivesTable.grid);


                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wDM_ActivesTable.grid, "Click", 0, false, 10, 35);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDM_ActivesTable.grid, sRowKeys, 0);


                if (dic["Col1"] != "")
                {
                    _gLib._SendKeysUDWin("Row" + iRowNum, this.wRetirementStudio.wDM_ActivesTable.grid, "{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("Row" + iRowNum, wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("Row:" + iRowNum, wEdit, dic["Col1"], 0);

                }


                if (dic["Col2"] != "")
                {
                    _gLib._SendKeysUDWin("Row" + iRowNum, this.wRetirementStudio.wDM_ActivesTable.grid, "{Tab}{Home}{Tab}{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("Row" + iRowNum, wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("Row:" + iRowNum, wEdit, dic["Col2"], 0);
                }


                if (dic["Col3"] != "")
                {
                    _gLib._SendKeysUDWin("Row" + iRowNum, this.wRetirementStudio.wDM_ActivesTable.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("Row" + iRowNum, wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("Row:" + iRowNum, wEdit, dic["Col3"], 0);
                }


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Col1", "");
        ///    dic.Add("Col2", "");
        ///    dic.Add("Col3", "");
        ///    pFundingInformation_UK._RegularValuation_DataMovements_Deferreds(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_DataMovements_Deferreds(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_DataMovements_Deferreds";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";


                //////WinWindow wWin = new WinWindow(this.wRetirementStudio.wDM_ActivesTable.grid);
                //////wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.EDIT", PropertyExpressionOperator.Contains);
                WinEdit wEdit = new WinEdit(this.wRetirementStudio.wDM_DeferredsTable.grid);


                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wDM_DeferredsTable.grid, "Click", 0, false, 10, 35);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDM_DeferredsTable.grid, sRowKeys, 0);


                if (dic["Col1"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDM_DeferredsTable.grid, "{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("FPGrid", wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", wEdit, dic["Col1"], 0);

                }


                if (dic["Col2"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDM_DeferredsTable.grid, "{Tab}{Home}{Tab}{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("FPGrid", wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", wEdit, dic["Col2"], 0);
                }


                if (dic["Col3"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDM_DeferredsTable.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("FPGrid", wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", wEdit, dic["Col3"], 0);
                }


            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Col1", "");
        ///    dic.Add("Col2", "");
        ///    dic.Add("Col3", "");
        ///    pFundingInformation_UK._RegularValuation_DataMovements_Pensions(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_DataMovements_Pensions(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_DataMovements_Pensions";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";

                WinEdit wEdit = new WinEdit(this.wRetirementStudio.wDM_PensionersTable.grid);

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wDM_PensionersTable.grid, "Click", 0, false, 10, 35);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDM_PensionersTable.grid, sRowKeys, 0);


                if (dic["Col1"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDM_PensionersTable.grid, "{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("FPGrid", wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", wEdit, dic["Col1"], 0);

                }


                if (dic["Col2"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDM_PensionersTable.grid, "{Tab}{Home}{Tab}{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("FPGrid", wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", wEdit, dic["Col2"], 0);
                }


                if (dic["Col3"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wDM_PensionersTable.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("FPGrid", wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", wEdit, dic["Col3"], 0);
                }


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ThisValuation", "");
        ///    dic.Add("LastValuation", "");
        ///    pFundingInformation_UK._RegularValuation_DataSummaries(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_DataSummaries(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_DataSummaries";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wDS_ThisValuaiton.cbo, dic["ThisValuation"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wDS_LastValuation.cbo, dic["LastValuation"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("FPGrid", this.wRetirementStudio.wDS_ThisValuaiton.cbo, dic["ThisValuation"], 0);
                _gLib._VerifySyncUDWin("FPGrid", this.wRetirementStudio.wDS_ThisValuaiton.cbo, dic["LastValuation"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SnapshotName", "");
        ///    pFundingInformation_UK._RegularValuation_Assets_Snapshot_TableSelect(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Assets_Snapshot_TableSelect(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Assets_Snapshot_TableSelect";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wSelectSnapshots.grid, "Click", 0, false, 50, 30);

                for (int i = 1; i <= 5; i++)
                {
                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wSelectSnapshots.grid).Equals(dic["SnapshotName"]))
                        break;
                    else
                    {
                        _gLib._SendKeysUDWin("", this.wRetirementStudio.wSelectSnapshots.grid, "{Down}", 0);
                        _gLib._MsgBox("", "there is no snapshot which we wanted");
                    }
                }

            }

            if (dic["PopVerify"] == "Verify")
            {
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("IntervaluationPeriodContribution_Employer", "");
        ///    dic.Add("IntervaluationPeriodContribution_Employee", "");
        ///    dic.Add("IntervaluationPeriodPension_DataAwarded", "");
        ///    pFundingInformation_UK._RegularValuation_Assets(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Assets(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Assets";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                if (dic["IntervaluationPeriodContribution_Employer"] != "")
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wAssets_IntervaluationPriod_Employer.Edit.txt, "{End}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}");
                _gLib._SetSyncUDWin_ByClipboard("Employer", this.wRetirementStudio.wAssets_IntervaluationPriod_Employer.Edit.txt, dic["IntervaluationPeriodContribution_Employer"], 0);
                _gLib._SetSyncUDWin("Employee", this.wRetirementStudio.wAssets_IntervaluationPriod_Employee.Edit.txt, dic["IntervaluationPeriodContribution_Employee"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DataAwarded", this.wRetirementStudio.wAssets_IntervaluationPriod_DataAwarded.Edit.txt, dic["IntervaluationPeriodPension_DataAwarded"], 0);
            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Employer", this.wRetirementStudio.wAssets_IntervaluationPriod_Employer.Edit.txt, dic["IntervaluationPeriodContribution_Employer"], 0);
                _gLib._VerifySyncUDWin("Employee", this.wRetirementStudio.wAssets_IntervaluationPriod_Employee.Edit.txt, dic["IntervaluationPeriodContribution_Employee"], 0);
                _gLib._VerifySyncUDWin("DataAwarded", this.wRetirementStudio.wAssets_IntervaluationPriod_DataAwarded.Edit.txt, dic["IntervaluationPeriodPension_DataAwarded"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Col1", "");
        ///    dic.Add("Col2", "");
        ///    dic.Add("Col3", "");
        ///    pFundingInformation_UK._RegularValuation_Assets_RateofPensionIncrease_Table(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Assets_RateofPensionIncrease_Table(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Assets_RateofPensionIncrease_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";

                WinEdit wEdit = new WinEdit(this.wRetirementStudio.wAssets_Intervaluation_Table.grid);

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wAssets_Intervaluation_Table.grid, "Click", 0, false, 160, 39);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAssets_Intervaluation_Table.grid, sRowKeys, 0);


                if (dic["Col1"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAssets_Intervaluation_Table.grid, "{Tab}{Home}{space}", 0);

                    _gLib._SendKeysUDWin("FPGrid", wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", wEdit, dic["Col1"], 0);

                }


                if (dic["Col2"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAssets_Intervaluation_Table.grid, "{Tab}{Home}{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("FPGrid", wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", wEdit, dic["Col2"], 0);
                }


                if (dic["Col3"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAssets_Intervaluation_Table.grid, "{Tab}{Home}{Tab}{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("FPGrid", wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", wEdit, dic["Col3"], 0);
                }


            }
            //if (dic["PopVerify"] == "Pop")
            //{

            //    int iRowNum = Convert.ToInt32(dic["iRow"]);
            //    String sRowKeys = "";

            //    for (int i = 1; i < iRowNum; i++)
            //        sRowKeys = sRowKeys + "{Down}";

            //    WinEdit wEdit = new WinEdit(this.wRetirementStudio.wAssets_Intervaluation_Table.grid);

            //    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wAssets_Intervaluation_Table.grid, "Click", 0, false, 160, 39);
            //    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAssets_Intervaluation_Table.grid, sRowKeys, 0);


            //    if (dic["Col1"] != "")
            //    {
            //        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAssets_Intervaluation_Table.grid, "{Tab}{Home}{space}{End}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}", 0);
            //        _gLib._SendKeysUDWin("FPGrid", wEdit, dic["Col1"].Substring(0, dic["Col1"].Length - 1), 0);
            //        _gLib._VerifySyncUDWin("", wEdit, dic["Col1"], 0);
            //    }


            //    if (dic["Col2"] != "")
            //    {
            //        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAssets_Intervaluation_Table.grid, "{Tab}{Home}{Tab}{space}{End}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}", 0);

            //        _gLib._SendKeysUDWin("FPGrid", wEdit, dic["Col2"].Substring(0, dic["Col2"].Length - 1), 0);
            //        _gLib._VerifySyncUDWin("", wEdit, dic["Col2"], 0);
            //    }


            //    if (dic["Col3"] != "")
            //    {
            //        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAssets_Intervaluation_Table.grid, "{Tab}{Home}{Tab}{Tab}{space}{End}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}", 0);

            //        _gLib._SendKeysUDWin("FPGrid", wEdit, dic["Col3"].Substring(0, dic["Col3"].Length - 1), 0);
            //        _gLib._VerifySyncUDWin("", wEdit, dic["Col3"], 0);
            //    }


            //}

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Col1", "");
        ///    dic.Add("Col2", "");
        ///    dic.Add("Col3", "");
        ///    pFundingInformation_UK._RegularValuation_Assets_EnvestermentReport(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Assets_EnvestermentReport(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Assets_EnvestermentReport";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";

                WinEdit wEdit = new WinEdit(this.wRetirementStudio.wAssets_ActualRateof_Table.grid);

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wAssets_ActualRateof_Table.grid, "Click", 0, false, 160, 39);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAssets_ActualRateof_Table.grid, sRowKeys, 0);


                if (dic["Col1"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAssets_ActualRateof_Table.grid, "{Tab}{Home}{space}", 0);

                    _gLib._SendKeysUDWin("FPGrid", wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", wEdit, dic["Col1"], 0);

                }


                if (dic["Col2"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAssets_ActualRateof_Table.grid, "{Tab}{Home}{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("FPGrid", wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", wEdit, dic["Col2"], 0);
                }


                if (dic["Col3"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAssets_ActualRateof_Table.grid, "{Tab}{Home}{Tab}{Tab}{space}", 0);

                    _gLib._SendKeysUDWin("FPGrid", wEdit, "A", 0, ModifierKeys.Control, false);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", wEdit, dic["Col3"], 0);
                }

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("ValuationNode", "");
        ///    dic.Add("LiabilityType", "");
        ///    pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Table(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Liabilities_LiabilityResults_Table(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Liabilities_LiabilityResults_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";
                string sFirstChar;

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Scenarios.grid, "Click", 0, false, 160, 33);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Scenarios.grid, sRowKeys + "{Tab}", 0);


                if (dic["ValuationNode"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Scenarios.grid, "{Enter}{Enter}", 0);
                    _gLib._SetSyncUDWin("ValuationNode", this.wSelectItem.wSelect.wList, dic["ValuationNode"], 0, false);

                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Scenarios.grid, "{Home}{Tab}", 0);
                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_Liab_Scenarios.grid) == dic["ValuationNode"])
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully selected: " + dic["ValuationNode"]);
                    else
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["ValuationNode"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_Liab_Scenarios.grid) + ">" + Environment.NewLine);
                }



                if (dic["LiabilityType"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Scenarios.grid, "{Tab}{Home}{Tab}{Tab}{Enter}{Enter}", 0);
                    _gLib._SetSyncUDWin("LiabilityType", this.wSelectItem.wSelect.wList, dic["LiabilityType"], 0, false);

                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Scenarios.grid, "{Home}{Tab}{Tab}", 0);
                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_Liab_Scenarios.grid) == dic["LiabilityType"])
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully selected: " + dic["LiabilityType"]);
                    else
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["LiabilityType"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_Liab_Scenarios.grid) + ">" + Environment.NewLine);
                }

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("ValuationNode", "");
        ///    dic.Add("LiabilityType", "");
        ///    pFundingInformation_UK._RegularValuation_Liabilities_LiabilityResults_Additionalscenarios_Table(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Liabilities_LiabilityResults_Additionalscenarios_Table(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Liabilities_LiabilityResults_Additionalscenarios_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";
                string sFirstChar;

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Additional.grid, "Click", 0, false, 160, 33);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Additional.grid, sRowKeys + "{Tab}", 0);


                if (dic["ValuationNode"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Additional.grid, "{Enter}{Enter}", 0);

                    this.wSelectItem.wSelect.wList.item.SearchProperties.Add(WinControl.PropertyNames.Name, dic["ValuationNode"]);
                    _gLib._SetSyncUDWin("", this.wSelectItem.wSelect.wList.item, "click", 0);


                    ////// verify
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Additional.grid, "{Left}{Right}");
                    string sAct = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_Liab_Additional.grid);

                    if (sAct == dic["ValuationNode"])
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully selected: " + dic["ValuationNode"]);
                    else
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["ParticipantGroup"] + "> but,the Actual value is <" + sAct + ">");
                }



                if (dic["LiabilityType"] != "")
                {

                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Additional.grid, "{Tab}{Home}{Tab}{Tab}", 0);

                    sFirstChar = dic["LiabilityType"].Substring(0, 1);

                    for (int i = 1; i <= 8; i++)
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Additional.grid, sFirstChar + "{Left}{Right}", 0);
                        if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_Liab_Additional.grid) == dic["LiabilityType"])
                            break;
                    }

                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_Liab_Additional.grid, "{Left}{Right}");

                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_Liab_Additional.grid) == dic["LiabilityType"])
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully selected: " + dic["LiabilityType"]);
                    else
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["LiabilityType"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_Liab_Scenarios.grid) + ">" + Environment.NewLine);
                }

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Name", "");
        ///    dic.Add("Value_P", "");
        ///    dic.Add("Value_C", "");
        ///    dic.Add("ApplytoPast", "");
        ///    dic.Add("ApplytoFuture", "");
        ///    dic.Add("ApplytoPPF", "");
        ///    pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Liabilities_MiscellaneousAdjustments_ActivesTable";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "Click", 0, false, 160, 33);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, sRowKeys, 0);

                if (dic["Name"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "{Space}" + dic["Name"]);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "{Tab}{Home}");

                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Actives.grid) == dic["Name"])
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully selected: " + dic["Name"]);
                    else
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["Name"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Actives.grid) + ">" + Environment.NewLine);
                }


                if (dic["Value_P"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "{Tab}{Home}{Tab}{Space}");
                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wbtn_P.btn, "click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", this.wRetirementStudio.wTableItem.txt, dic["Value_P"], 0);
                }


                if (dic["Value_C"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "{Tab}{Home}{Tab}{Space}");
                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wbtn_C.btn, "click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", this.wRetirementStudio.wTableItem.txt, dic["Value_C"], 0);

                }

                if (dic["ApplytoPast"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "{Home}{Tab}{Tab}");

                    string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Actives.grid);
                    if (sAct.ToLower() != dic["ApplytoPast"].ToLower())
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "{space}{Home}{Tab}{Tab}");

                        sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Actives.grid);
                        if (sAct.ToLower() != dic["ApplytoPast"].ToLower())
                            _gLib._MsgBoxYesNo("", "Function fail! ApplytoFuture: Expectd value is " + dic["ApplytoPast"] + ", but the actual valueis " + sAct);
                    }
                }


                if (dic["ApplytoFuture"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "{Tab}{Home}{Tab}{Tab}{Tab}");

                    string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Actives.grid);
                    if (sAct.ToLower() != dic["ApplytoFuture"].ToLower())
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "{space}{Home}{Tab}{Tab}{Tab}");

                        sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Actives.grid);
                        if (sAct.ToLower() != dic["ApplytoFuture"].ToLower())
                            _gLib._MsgBoxYesNo("", "Function fail! ApplytoFuture: Expectd value is " + dic["ApplytoFuture"] + ", but the actual valueis " + sAct);
                    }
                }

                if (dic["ApplytoPPF"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "{Home}{Tab}{Tab}{Tab}{Tab}");

                    string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Actives.grid);
                    if (sAct.ToLower() != dic["ApplytoPPF"].ToLower())
                    {
                        _gLib._SendKeysUDWin("ApplytoPPF", this.wRetirementStudio.wLiabilities_MA_Actives.grid, "{space}{Home}{Tab}{Tab}{Tab}{Tab}");

                        sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Actives.grid);
                        if (sAct.ToLower() != dic["ApplytoPPF"].ToLower())
                            _gLib._MsgBoxYesNo("", "Function fail! ApplytoPPF: Expectd value is " + dic["ApplytoPPF"] + ", but the actual valueis " + sAct);
                    }
                }


                if (dic["PopVerify"] == "Verify")
                {
                    _gLib._MsgBox("", "This verify Function is not complete");
                }

                _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
            }
        }


        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Name", "");
        ///    dic.Add("Value_P", "");
        ///    dic.Add("Value_C", "");
        ///    dic.Add("ApplytoPPF", "");
        ///    pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Liabilities_MiscellaneousAdjustments_Deferreds";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";

                _gLib._SetSyncUDWin("FPGrid-Deferreds", this.wRetirementStudio.wLiabilities_MA_Deferreds.grid, "Click", 0, false, 160, 33);
                _gLib._SendKeysUDWin("FPGrid-Deferreds", this.wRetirementStudio.wLiabilities_MA_Deferreds.grid, sRowKeys, 0);

                if (dic["Name"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid-Deferreds", this.wRetirementStudio.wLiabilities_MA_Deferreds.grid, "{Space}{Space}{Back}" + dic["Name"]);
                    _gLib._SendKeysUDWin("FPGrid-Deferreds", this.wRetirementStudio.wLiabilities_MA_Deferreds.grid, "{Tab}{Home}");

                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Deferreds.grid) == dic["Name"])
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully selected: " + dic["Name"]);
                    else
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["Name"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Deferreds.grid) + ">" + Environment.NewLine);
                }


                if (dic["Value_P"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid-Deferreds", this.wRetirementStudio.wLiabilities_MA_Deferreds.grid, "{Tab}{Home}{Tab}{Space}");
                    _gLib._SendKeysUDWin("FPGrid-Deferreds", this.wRetirementStudio.wLiabilities_MA_Deferreds.grid, "{Space}{Space}{back}");
                    _gLib._SetSyncUDWin("Value_P", this.wRetirementStudio.wbtn_P.btn, "click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("Value_P", this.wRetirementStudio.wTableItem.txt, dic["Value_P"], 0);
                }

                if (dic["Value_C"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Deferreds.grid, "{Tab}{Home}{Tab}{Space}{Space}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Deferreds.grid, "{Space}{Space}{back}");
                    _gLib._SetSyncUDWin("Value_C", this.wRetirementStudio.wbtn_C.btn, "click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("Value_C", this.wRetirementStudio.wTableItem.txt, dic["Value_C"], 0);
                }


                if (dic["ApplytoPPF"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Deferreds.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Deferreds.grid, "{Home}{Tab}{Tab}");

                    string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Deferreds.grid);
                    if (sAct.ToLower() != dic["ApplytoPPF"].ToLower())
                    {
                        _gLib._SendKeysUDWin("ApplytoPPF", this.wRetirementStudio.wLiabilities_MA_Deferreds.grid, "{space}{Home}{Tab}{Tab}");

                        sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Deferreds.grid);
                        if (sAct.ToLower() != dic["ApplytoPPF"].ToLower())
                            _gLib._MsgBoxYesNo("", "Function fail! ApplytoPPF: Expectd value is " + dic["ApplytoPPF"] + ", but the actual valueis " + sAct);
                    }
                }
            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Name", "");
        ///    dic.Add("Value_P", "");
        ///    dic.Add("Value_C", "");
        ///    dic.Add("ApplytoPPF", "");
        ///    pFundingInformation_UK._RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Liabilities_MiscellaneousAdjustments_Pensioners";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";

                _gLib._SetSyncUDWin("FPGrid-Pensioners", this.wRetirementStudio.wLiabilities_MA_Pensions.grid, "Click", 0, false, 160, 33);
                _gLib._SendKeysUDWin("FPGrid-Pensioners", this.wRetirementStudio.wLiabilities_MA_Pensions.grid, "{PageUp}" + sRowKeys, 0);

                if (dic["Name"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid-Pensioners", this.wRetirementStudio.wLiabilities_MA_Pensions.grid, "{Space}" + dic["Name"]);
                    _gLib._SendKeysUDWin("FPGrid-Pensioners", this.wRetirementStudio.wLiabilities_MA_Pensions.grid, "{Tab}{Home}");

                    if (this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Pensions.grid) == dic["Name"])
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully selected: " + dic["Name"]);
                    else
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["Name"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Pensions.grid) + ">" + Environment.NewLine);
                }


                if (dic["Value_P"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid-Pensioners", this.wRetirementStudio.wLiabilities_MA_Pensions.grid, "{Tab}{Home}{Tab}{Space}");
                    _gLib._SendKeysUDWin("FPGrid-Pensioners", this.wRetirementStudio.wLiabilities_MA_Pensions.grid, "{Space}{Enter}{Space}{back}");
                    _gLib._SetSyncUDWin("Value_P", this.wRetirementStudio.wbtn_P.btn, "click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("Value_P", this.wRetirementStudio.wTableItem.txt, dic["Value_P"], 0);
                }

                if (dic["Value_C"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid-Pensioners", this.wRetirementStudio.wLiabilities_MA_Pensions.grid, "{Tab}{Home}{Tab}{Space}{Space}");
                    _gLib._SendKeysUDWin("FPGrid-Pensioners", this.wRetirementStudio.wLiabilities_MA_Pensions.grid, "{Space}{Enter}{Space}{back}");
                    _gLib._SetSyncUDWin("Value_C", this.wRetirementStudio.wbtn_C.btn, "click", 0);
                    _gLib._SetSyncUDWin_ByClipboard("Value_C", this.wRetirementStudio.wTableItem.txt, dic["Value_C"], 0);
                }


                if (dic["ApplytoPPF"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Pensions.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Pensions.grid, "{Home}{Tab}{Tab}");

                    string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Pensions.grid);
                    if (sAct.ToLower() != dic["ApplytoPPF"].ToLower())
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabilities_MA_Pensions.grid, "{space}{Home}{Tab}{Tab}");

                        sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabilities_MA_Pensions.grid);
                        if (sAct.ToLower() != dic["ApplytoPPF"].ToLower())
                            _gLib._MsgBoxYesNo("", "Function fail! ApplytoPPF: Expectd value is " + dic["ApplytoPPF"] + ", but the actual valueis " + sAct);
                    }
                }

            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ImportFSMSensitivities", "");
        ///    pFundingInformation_UK._RegularValuation_Liabilities_FSMSensitivities(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Liabilities_FSMSensitivities(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Liabilities_FSMSensitivities";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ImportFSMSensitivities", this.wRetirementStudio.wImportFSMSensitivities.btn, "Click", 0, false);
            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FundingExpenses_Fixed_rd", "");
        ///    dic.Add("FundingExpenses_Fixed_txt", "");
        ///    dic.Add("FundingInsurance_Fixed_rd", "");
        ///    dic.Add("FundingInsurance_Fixed_txt", "");
        ///    dic.Add("Solvency_Fixed_rd", "");
        ///    dic.Add("Solvency_Fixed_txt", "");
        ///    dic.Add("Actives", "");
        ///    dic.Add("Deferreds", "");
        ///    dic.Add("PensionersUnder60", "");
        ///    dic.Add("Pensioners6069", "");
        ///    dic.Add("Pensioners7079", "");
        ///    dic.Add("PensionersOver80", "");
        ///    pFundingInformation_UK._RegularValuation_ResultsSummary(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_ResultsSummary(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_ResultsSummary";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iTxt = 0;

                _gLib._SendKeysUDWin("", this.wRetirementStudio.wRS_FundingExpenses_Fixed.rd, dic["FundingExpenses_Fixed_rd"], 0);
                _gLib._SendKeysUDWin("", this.wRetirementStudio.wRS_FundingInsuranceCosts_Fixed.rd, dic["FundingInsurance_Fixed_rd"], 0);
                _gLib._SendKeysUDWin("", this.wRetirementStudio.wRS_Solvency_Fixed.rd, dic["Solvency_Fixed_rd"], 0);

                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["FundingExpenses_Fixed_txt"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["FundingInsurance_Fixed_txt"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "3", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["Solvency_Fixed_txt"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "4", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["Actives"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "5", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["Deferreds"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "6", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["PensionersUnder60"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "7", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["Pensioners6069"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "8", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["Pensioners7079"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "9", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["PensionersOver80"], 0);

            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SFOResults", "");
        ///    dic.Add("LastTimesResults", "");
        ///    dic.Add("SolvencyResults", "");
        ///    dic.Add("PPFResults", "");
        ///    dic.Add("Actives", "");
        ///    dic.Add("Deferreds", "");
        ///    dic.Add("Pensioners", "");
        ///    dic.Add("Expenses", "");
        ///    dic.Add("SalaryIncreaseforStayers", "");
        ///    pFundingInformation_UK._RegularValuation_Reports_Liabilities(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Reports_Liabilities(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Reports_Liabilities";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("", this.wRetirementStudio.wReports_Liab_SFOResults.cbo, dic["SFOResults"], 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wReports_Liab_LastTimesResults.cbo, dic["LastTimesResults"], 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wReports_Liab_SolvencyResults.cbo, dic["SolvencyResults"], 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wReports_Liab_PPFResults.cbo, dic["PPFResults"], 0);


                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "5");
                _gLib._SetSyncUDWin("Actives", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 22, 22);
                _gLib._SetSyncUDWin_ByClipboard("Actives", this.wRetirementStudio.wCommEdit.Edit.txt, dic["Actives"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "4");
                _gLib._SetSyncUDWin("Deferreds", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 22, 22);
                _gLib._SetSyncUDWin_ByClipboard("Deferreds", this.wRetirementStudio.wCommEdit.Edit.txt, dic["Deferreds"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "3");
                _gLib._SetSyncUDWin("Pensioners", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 22, 22);
                _gLib._SetSyncUDWin_ByClipboard("Pensioners", this.wRetirementStudio.wCommEdit.Edit.txt, dic["Pensioners"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2");
                _gLib._SetSyncUDWin("Expenses", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 22, 22);
                _gLib._SetSyncUDWin_ByClipboard("Expenses", this.wRetirementStudio.wCommEdit.Edit.txt, dic["Expenses"], 0);

                _gLib._SetSyncUDWin("SalaryIncreaseforStayers", this.wRetirementStudio.wReport_Liab_SalaryIncreaseForStayers.Edit.txt, "Click", 0, false, 22, 22);
                _gLib._SetSyncUDWin_ByClipboard("SalaryIncreaseforStayers", this.wRetirementStudio.wReport_Liab_SalaryIncreaseForStayers.Edit.txt, dic["SalaryIncreaseforStayers"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Amount", "");
        ///    dic.Add("Date", "");
        ///    pFundingInformation_UK._RegularValuation_Reports_RecoveryPlan_Table(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Reports_RecoveryPlan_Table(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Reports_RecoveryPlan_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wReports_ContributionSchedule.grid, "Click", 0, false, 150, 28);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wReports_ContributionSchedule.grid, "{PageUp}{PageUp}" + sRowKeys, 0);

                if (dic["Amount"] != "")
                {
                    string sActual = "";
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wReports_ContributionSchedule.grid, "{tab}{Home}{space}{space}", 0);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit, "{Home}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}" + dic["Amount"], 0);

                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wReports_ContributionSchedule.grid, "{Tab}{Home}{PageUp}{PageUp}" + sRowKeys, 0);

                    sActual = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wReports_ContributionSchedule.grid).Trim().ToString();
                    if (sActual != dic["Amount"])
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Verify Object: <" + sFunctionName + "> with expected value: <" + dic["Amount"] + ">. Actual Value: <" + sActual + "> ");
                }


                if (dic["Date"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wReports_ContributionSchedule.grid, "{tab}{Home}{Tab}{space}", 0);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wReport_RecovercyPlan_Contribution_DataComb.cbo, "{Home}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Home}", 0);

                    Clipboard.Clear();
                    Clipboard.SetText(dic["Date"]);
                    Keyboard.SendKeys("v", ModifierKeys.Control);
                    _gLib._VerifySyncUDWin("FPGrid", this.wRetirementStudio.wReport_RecovercyPlan_Contribution_DataComb.cbo, dic["Date"], 0);
                }
            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Preretiremrnt", "");
        ///    dic.Add("Pstretirement", "");
        ///    dic.Add("Inflation", "");
        ///    dic.Add("SalaryGrowth", "");
        ///    dic.Add("Mortality", "");
        ///    dic.Add("EquityMarkets", "");
        ///    dic.Add("GiltYields", "");
        ///    pFundingInformation_UK._RegularValuation_Reports_Sensitivities(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Reports_Sensitivities(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Reports_Sensitivities";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "7", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 30, 5);
                _gLib._SetSyncUDWin_ByClipboard("Preretiremrnt", this.wRetirementStudio.wCommEdit.Edit, dic["Preretiremrnt"], 0);


                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "6", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 30, 5);
                _gLib._SetSyncUDWin_ByClipboard("Pstretirement", this.wRetirementStudio.wCommEdit.Edit, dic["Pstretirement"], 0);


                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "5", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 30, 5);
                _gLib._SetSyncUDWin_ByClipboard("Inflation", this.wRetirementStudio.wCommEdit.Edit, dic["Inflation"], 0);


                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "4", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 30, 5);
                _gLib._SetSyncUDWin_ByClipboard("SalaryGrowth", this.wRetirementStudio.wCommEdit.Edit, dic["SalaryGrowth"], 0);


                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "3", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 30, 5);
                _gLib._SetSyncUDWin_ByClipboard("Mortality", this.wRetirementStudio.wCommEdit.Edit, dic["Mortality"], 0);


                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 30, 5);
                _gLib._SetSyncUDWin_ByClipboard("EquityMarkets", this.wRetirementStudio.wCommEdit.Edit, dic["EquityMarkets"], 0);


                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "1", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 30, 5);
                _gLib._SetSyncUDWin_ByClipboard("GiltYields", this.wRetirementStudio.wCommEdit.Edit, dic["GiltYields"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Description", "");
        ///    dic.Add("Value", "");
        ///    pFundingInformation_UK._RegularValuation_Reports_AOS_Table(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Reports_AOS_Table(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Reports_AOS_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";


                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wReports_AOS.grid, "Click", 0, false, 70, 33);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wReports_AOS.grid, "{PageUp}" + sRowKeys, 0);

                if (dic["Description"] != "")
                {
                    _gLib._SendKeysUDWin("Description", this.wRetirementStudio.wReports_AOS.grid, "{Tab}{Home}{space}", 0);
                    WinComboBox cbo = new WinComboBox(this.wRetirementStudio.wReports_AOS.grid);
                    _gLib._SetSyncUDWin("Description", cbo, dic["Description"], 0);
                }


                if (dic["Value"] != "")
                {
                    _gLib._SendKeysUDWin("Value", this.wRetirementStudio.wReports_AOS.grid, "{Tab}{Space}", 0);
                    _gLib._SetSyncUDWin_ByClipboard("Value", this.wRetirementStudio.wTableItem.txt, dic["Value"], 0);
                }
            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FundingSurplus", "");
        ///    dic.Add("FundingLevel", "");
        ///    dic.Add("SolvencyShortfall", "");
        ///    dic.Add("Solvencylevel", "");
        ///    pFundingInformation_UK._RegularValuation_Reports_Projection(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Reports_Projection(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Reports_Projection";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "4", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 30, 5);
                _gLib._SetSyncUDWin_ByClipboard("FundingSurplus", this.wRetirementStudio.wCommEdit.Edit, dic["FundingSurplus"], 0);


                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "3", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 30, 5);
                _gLib._SetSyncUDWin_ByClipboard("FundingLevel", this.wRetirementStudio.wCommEdit.Edit, dic["FundingLevel"], 0);


                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 30, 5);
                _gLib._SetSyncUDWin_ByClipboard("SolvencyShortfall", this.wRetirementStudio.wCommEdit.Edit, dic["SolvencyShortfall"], 0);


                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "1", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 30, 5);
                _gLib._SetSyncUDWin_ByClipboard("Solvencylevel", this.wRetirementStudio.wCommEdit.Edit, dic["Solvencylevel"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Value", "");
        ///    pFundingInformation_UK._RegularValuation_Reports_InvStrategy_MainAsset_Table(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Reports_InvStrategy_MainAsset_Table(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Reports_InvStrategy_MainAsset_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wReports_IS_Main.grid, "Click", 0, false, 80, 33);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wReports_IS_Main.grid, "{PageUp}" + sRowKeys + "{Tab}{Space}", 0);

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, dic["Value"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("AssetCategory", "");
        ///    dic.Add("Value", "");
        ///    pFundingInformation_UK._RegularValuation_Reports_InvStrategy_OtherAsset_Table(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Reports_InvStrategy_OtherAsset_Table(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Reports_InvStrategy_OtherAsset_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wReports_IS_Other.grid, "Click", 0, false, 30, 33);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wReports_IS_Other.grid, "{PageUp}" + sRowKeys, 0);


                if (dic["AssetCategory"] != "")
                {
                    _gLib._SendKeysUDWin("AssetCategory", this.wRetirementStudio.wReports_IS_Other.grid, "{Tab}{Home}{space}", 0);
                    _gLib._SendKeysUDWin("AssetCategory", this.wRetirementStudio.wAssetCategory.cbo, dic["AssetCategory"], 0);
                }


                if (dic["Value"] != "")
                {
                    _gLib._SendKeysUDWin("Value", this.wRetirementStudio.wReports_IS_Other.grid, "{Tab}{Space}", 0);
                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCommEdit.Edit.txt, "Click", 0, false, 5, 5);
                    _gLib._SetSyncUDWin_ByClipboard("Value", this.wRetirementStudio.wCommEdit.Edit.txt, dic["Value"], 0);
                }
            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("NameofSection", "");
        ///    dic.Add("SchemeRegistrationNumber", "");
        ///    dic.Add("SchemeAddressLine1", "");
        ///    dic.Add("Line2", "");
        ///    dic.Add("Line3", "");
        ///    dic.Add("Line4", "");
        ///    dic.Add("GuidanceUsed", "");
        ///    dic.Add("AssumptionUsed", "");
        ///    dic.Add("ExternalLiabilities", "");
        ///    dic.Add("ActivesInsured", "");
        ///    dic.Add("DeferredsInsured", "");
        ///    pFundingInformation_UK._RegularValuation_Reports_PPFS179Cert(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Reports_PPFS179Cert(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Reports_PPFS179Cert";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wReport_PPF_NameOfSection.Edit, dic["NameofSection"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wReport_PPF_SchemeRegistrationNumber.Edit, dic["SchemeRegistrationNumber"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLine1.Edit, dic["SchemeAddressLine1"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLine2.Edit, dic["Line2"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLine3.Edit, dic["Line3"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLine4.Edit, dic["Line4"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wGuidanceUsed.Edit, dic["GuidanceUsed"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wAssumptionsUsed.Edit, dic["AssumptionUsed"], 0);

                if (dic["ExternalLiabilities"] != "")
                {
                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wAssets_IntervaluationPriod_Employer.Edit.txt, "Click", 0, false, 30, 10);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", this.wRetirementStudio.wAssets_IntervaluationPriod_Employer.Edit.txt, dic["ExternalLiabilities"], 0);
                }

                if (dic["ActivesInsured"] != "")
                {
                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wAssets_IntervaluationPriod_Employee.Edit.txt, "Click", 0, false, 30, 10);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", this.wRetirementStudio.wAssets_IntervaluationPriod_Employee.Edit.txt, dic["ActivesInsured"], 0);
                }

                if (dic["DeferredsInsured"] != "")
                {
                    _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wDeferredsInsured.Edit.txt, "Click", 0, false, 30, 10);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", this.wRetirementStudio.wDeferredsInsured.Edit.txt, dic["DeferredsInsured"], 0);
                }
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SchemeActuary", "");
        ///    dic.Add("ConsultingOfficeAddressLine1", "");
        ///    dic.Add("Line2", "");
        ///    dic.Add("Line3", "");
        ///    dic.Add("Line4", "");
        ///    dic.Add("EmployerName", "");
        ///    dic.Add("CurrencyUnit", "");
        ///    pFundingInformation_UK._RegularValuation_Reports_GeneralInfo(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RegularValuation_Reports_GeneralInfo(MyDictionary dic)
        {
            string sFunctionName = "_RegularValuation_Reports_GeneralInfo";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wSchemeActuary.Edit, dic["SchemeActuary"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLine1.Edit, dic["ConsultingOfficeAddressLine1"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLine2.Edit, dic["Line2"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLine3.Edit, dic["Line3"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLine4.Edit, dic["Line4"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wEmployerName.Edit, dic["EmployerName"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCurrencyUnit.cbo, dic["CurrencyUnit"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Scenario", "Last Time Val");
        ///    dic.Add("ValuationNode", "");
        ///    dic.Add("ValuationType", "");
        ///    dic.Add("LiabilityType", "");
        ///    dic.Add("AssetValue", "");
        ///    pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table(MyDictionary dic)
        {
            string sFunctionName = "_FundingUpdate_LiabilitiesandAssets_LiabilityandAssetResults_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                int iRowNum = Convert.ToInt32(dic["iRow"]);
                String sRowKeys = "";
                string sFirstChar;


                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Down}";

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLiabAndAssets_Liab.grid, "Click", 0, false, 30, 20);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabAndAssets_Liab.grid, sRowKeys + "{Tab}", 0);

                if (dic["Scenario"] != "")
                {
                    WinEdit edit = new WinEdit(this.wRetirementStudio.wLiabAndAssets_Liab.grid);

                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabAndAssets_Liab.grid, "{Tab}{Home}{Space}", 0);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", edit, dic["Scenario"], 0);
                }


                if (dic["ValuationNode"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabAndAssets_Liab.grid, "{Tab}{Home}{Tab}{Enter}{Enter}", 0);

                    this.wSelectItem.wSelect.wList.item.SearchProperties.Add(WinControl.PropertyNames.Name, dic["ValuationNode"]);
                    _gLib._SetSyncUDWin("", this.wSelectItem.wSelect.wList.item, "click", 0);


                    ////// verify
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabAndAssets_Liab.grid, "{Left}{Right}");

                    string sAct = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabAndAssets_Liab.grid);
                    if (sAct == dic["ValuationNode"])
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully selected: " + dic["ValuationNode"]);
                    else
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["ParticipantGroup"] + "> but,the Actual value is <" + sAct + ">");
                }



                if (dic["ValuationType"] != "")
                {

                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabAndAssets_Liab.grid, "{Tab}{Home}{Tab}{Tab}{Enter}{Enter}", 0);

                    this.wSelectItem.wSelect.wList.item.SearchProperties.Add(WinControl.PropertyNames.Name, dic["ValuationType"]);
                    _gLib._SetSyncUDWin("", this.wSelectItem.wSelect.wList.item, "click", 0);


                    ////// verify
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabAndAssets_Liab.grid, "{Left}{Right}");

                    string sAct = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabAndAssets_Liab.grid);
                    if (sAct == dic["ValuationType"])
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully selected: " + dic["ValuationType"]);
                    else
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["ParticipantGroup"] + "> but,the Actual value is <" + sAct + ">");

                }



                if (dic["LiabilityType"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabAndAssets_Liab.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{Enter}{Enter}", 0);

                    this.wSelectItem.wSelect.wList.item.SearchProperties.Add(WinControl.PropertyNames.Name, dic["LiabilityType"]);
                    _gLib._SetSyncUDWin("", this.wSelectItem.wSelect.wList.item, "click", 0);


                    ////// verify
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabAndAssets_Liab.grid, "{Left}{Right}");

                    string sAct = this._fp._ReturnSelectRowContent(this.wRetirementStudio.wLiabAndAssets_Liab.grid);
                    if (sAct == dic["LiabilityType"])
                        _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully selected: " + dic["LiabilityType"]);
                    else
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["ParticipantGroup"] + "> but,the Actual value is <" + sAct + ">");

                }


                if (dic["AssetValue"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wLiabAndAssets_Liab.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{Tab}{Space}", 0);

                    WinEdit edit = new WinEdit(this.wRetirementStudio.wLiabAndAssets_Liab.grid);
                    _gLib._SetSyncUDWin_ByClipboard("FPGrid", edit, dic["AssetValue"], 0);
                }
            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Col1", "");
        ///    dic.Add("Col2", "");
        ///    pFundingInformation_UK._FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table(MyDictionary dic)
        {
            string sFunctionName = "_FundingUpdate_LiabilitiesandAssets_AdjustmentforLiability_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iRowNum = Convert.ToInt32(dic["iRow"]) * 2 - 1;
                string sRowKeys = "";

                for (int i = 1; i < iRowNum; i++)
                    sRowKeys = sRowKeys + "{Tab}";

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wAdjustmentForLiab.grid, "Click", 0, false, 10, 10);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAdjustmentForLiab.grid, "{Tab}{Home}{PageUp}{PageUp}{Tab}{Home}", 0);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAdjustmentForLiab.grid, sRowKeys, 0);

                if (dic["Col1"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAdjustmentForLiab.grid, "{Space}", 0);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAdjustment_Item.Edit, dic["Col1"], 0);
                }


                if (dic["Col2"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAdjustmentForLiab.grid, "{Tab}{Space}", 0);
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wAdjustment_Item.Edit, dic["Col2"], 0);
                }
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CurrentUpdateFunding", "");
        ///    dic.Add("CurrentUpdateSolvency", "");
        ///    dic.Add("CurrentUpdatePPF", "");
        ///    dic.Add("LastFullValuation", "");
        ///    dic.Add("SolvencyFundingLevel", "");
        ///    pFundingInformation_UK._FundingUpdate_Reports(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _FundingUpdate_Reports(MyDictionary dic)
        {
            string sFunctionName = "_FundingUpdate_Reports";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCurrentFunding.cbo, dic["CurrentUpdateFunding"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCurentSolvency.cbo, dic["CurrentUpdateSolvency"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wReports_Liab_CurrentUpdatePPF.cbo, dic["CurrentUpdatePPF"], 0);
                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wLastFullValuationFunding.cbo, dic["LastFullValuation"], 0);

                _gLib._SetSyncUDWin("SolvencyFundingLevel", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("SolvencyFundingLevel", this.wRetirementStudio.wCommEdit.Edit.txt, dic["SolvencyFundingLevel"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("EmployeeContributionRate", "");
        ///    dic.Add("EmployerContributionRate", "");
        ///    dic.Add("FTSEAllShareTRI_PreviousUpdate", "");
        ///    dic.Add("FTSEAllShareTRI_CurrentUpdate", "");
        ///    dic.Add("FTGovtFixed_PreviousUpdate", "");
        ///    dic.Add("FTGovtFixed_CurrentUpdate", "");
        ///    dic.Add("FTGovIL_PreviousUpdate", "");
        ///    dic.Add("FTGovIL_CurrentUpdate", "");
        ///    dic.Add("IBoxxCorpBondAA_PreviousUpdate", "");
        ///    dic.Add("IBoxxCorpBondAA_CurrentUpdate", "");
        ///    dic.Add("DurationForGiltYields_PreviousUpdate", "");
        ///    dic.Add("FixedGiltYield_PreviousUpdate", "");
        ///    dic.Add("FixedGiltYield_CurrentUpdate", "");
        ///    dic.Add("IndexLinkedGilt_PreviousUpdate", "");
        ///    dic.Add("IndexLinkedGilt_CurrentUpdate", "");
        ///    dic.Add("ImpliedInflation_PreviousUpdate", "");
        ///    dic.Add("ImpliedInflation_CurrentUpdate", "");
        ///    dic.Add("AssetReturn", "");
        ///    pFundingInformation_UK._FundingUpdate_Reports_Experience(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _FundingUpdate_Reports_Experience(MyDictionary dic)
        {
            string sFunctionName = "_FundingUpdate_Reports_Experience";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "18", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["EmployeeContributionRate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "17", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["EmployerContributionRate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "16", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["FTSEAllShareTRI_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "15", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["FTSEAllShareTRI_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "14", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["FTGovtFixed_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "13", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["FTGovtFixed_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "12", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["FTGovIL_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "11", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["FTGovIL_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "10", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["IBoxxCorpBondAA_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "9", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["IBoxxCorpBondAA_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "8", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["DurationForGiltYields_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "7", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["FixedGiltYield_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "6", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["FixedGiltYield_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "5", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["IndexLinkedGilt_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "4", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["IndexLinkedGilt_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "3", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["ImpliedInflation_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["ImpliedInflation_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "1", 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["AssetReturn"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("InvestmentReturnPre_PreviousUpdate", "");
        ///    dic.Add("InvestmentReturnPre_CurrentUpdate", "");
        ///    dic.Add("InvestmentReturnPost_PreviousUpdate", "");
        ///    dic.Add("InvestmentReturnPost_CurrentUpdate", "");
        ///    dic.Add("InflationRPI_PreviousUpdate", "");
        ///    dic.Add("InflationRPI_CurrentUpdate", "");
        ///    dic.Add("InflationCPI_PreviousUpdate", "");
        ///    dic.Add("InflationCPI_CurrentUpdate", "");
        ///    dic.Add("SalaryGrowth_PreviousUpdate", "");
        ///    dic.Add("SalaryGrowth_CurrentUpdate", "");
        ///    dic.Add("DeferredRevaluation_PreviousUpdate", "");
        ///    dic.Add("DeferredRevaluation_CurrentUpdate", "");
        ///    dic.Add("PensionIncrease5_0_PreviousUpdate", "");
        ///    dic.Add("PensionIncrease5_0_CurrentUpdate", "");
        ///    dic.Add("PensionIncrease2_5_PreviousUpdate", "");
        ///    dic.Add("PensionIncrease2_5_CurrentUpdate", "");
        ///    dic.Add("MortalityBaseTable_PreviousUpdate", "");
        ///    dic.Add("MortalityBaseTable_CurrentUpdate", "");
        ///    dic.Add("MortalityFutureImprovements_PreviousUpdate", "");
        ///    dic.Add("MortalityFutureImprovements_CurrentUpdate", "");
        ///    pFundingInformation_UK._FundingUpdate_Reports_Basis(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _FundingUpdate_Reports_Basis(MyDictionary dic)
        {
            string sFunctionName = "_FundingUpdate_Reports_Basis";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "16", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["InvestmentReturnPre_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "15", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["InvestmentReturnPre_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "14", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["InvestmentReturnPost_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "13", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["InvestmentReturnPost_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "12", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["InflationRPI_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "11", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["InflationRPI_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "10", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["InflationCPI_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "9", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["InflationCPI_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "8", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["SalaryGrowth_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "7", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["SalaryGrowth_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "6", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["DeferredRevaluation_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "5", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["DeferredRevaluation_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "4", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["PensionIncrease5_0_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "3", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["PensionIncrease5_0_CurrentUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["PensionIncrease2_5_PreviousUpdate"], 0);

                this.wRetirementStudio.wCommEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "1", 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCommEdit.Edit.txt, "click", 0, false, 5, 5);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wCommEdit.Edit.txt, dic["PensionIncrease2_5_CurrentUpdate"], 0);

                _gLib._SetSyncUDWin("", this.wRetirementStudio.wLastMortalityBase.Edit, dic["MortalityBaseTable_PreviousUpdate"], 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCurrentMortalityBase.Edit, dic["MortalityBaseTable_CurrentUpdate"], 0);

                _gLib._SetSyncUDWin("", this.wRetirementStudio.wLastMortalityFuture.Edit, dic["MortalityFutureImprovements_PreviousUpdate"], 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCurrentMortalityFuture.Edit, dic["MortalityFutureImprovements_CurrentUpdate"], 0);

            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Nov-16 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AssetMethod", "");
        ///    dic.Add("AOSMethod", "");
        ///    dic.Add("VARChartMethod", "");
        ///    dic.Add("ConsultingOfficeAddressLine1", "");
        ///    dic.Add("Line2", "");
        ///    dic.Add("Line3", "");
        ///    dic.Add("Line4", "");
        ///    dic.Add("TelephoneNumber", "");
        ///    dic.Add("SFPDate", "");
        ///    dic.Add("NextFullValuationDate", "");
        ///    dic.Add("CurrencyUnit", "");
        ///    pFundingInformation_UK._FundingUpdate_Reports_GeneralInfo(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _FundingUpdate_Reports_GeneralInfo(MyDictionary dic)
        {
            string sFunctionName = "_FundingUpdate_Reports_GeneralInfo";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("", this.wRetirementStudio.wReports_General_AssetMethod.cbo, dic["AssetMethod"], 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wReports_General_AOS.cbo, dic["AOSMethod"], 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wReports_General_VAR.cbo, dic["VARChartMethod"], 0);

                _gLib._SetSyncUDWin("", this.wRetirementStudio.wLine1.Edit, dic["ConsultingOfficeAddressLine1"], 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wLine2.Edit, dic["Line2"], 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wLine3.Edit, dic["Line3"], 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wLine4.Edit, dic["Line4"], 0);

                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wTelephoneNumber.Edit, dic["TelephoneNumber"], 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wSFPDate.cbo.Edit, dic["SFPDate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wNextFullValuationDate.cbo.Edit, dic["NextFullValuationDate"], 0);
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wCurrencyUnit.cbo, dic["CurrencyUnit"], 0);

            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "This verify Function is not complete");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
