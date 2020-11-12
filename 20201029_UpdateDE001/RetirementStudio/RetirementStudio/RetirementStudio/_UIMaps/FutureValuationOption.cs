namespace RetirementStudio._UIMaps.FutureValuationOptionClasses
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

    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using RetirementStudio._ThridParty;
    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._UIMaps.OutputManagerClasses;
    using RetirementStudio._UIMaps.TestCaseLibraryClasses;


    public partial class FutureValuationOption
    {

        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2015-Oct-15 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        /// 
        ///    pFutureValuationOption._SelectTab("Population size");
        /// 
        /// </summary>
        /// <param name="dic"></param>
        /// 
        public void _SelectTab(String sTabName)
        {

            string sFunctionName = "_PopVerify_FutureSelectTab";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TabPageSelectWin(sTabName, this.wFutureValuationOption.wTab, Config.iTimeout);

        }


        //<summary>
        //2015-Oct-14 
        //ruiyang.song@mercer.com
        //sample:
        //    dic.Clear();
        //    dic.Add("PopVerify", "Pop");
        //    dic.Add("ModelPopulationSizePerParticipantGroup", "true");
        //    dic.Add("iRowNum", "");
        //    dic.Add("ParticipantGroup", "");
        //    dic.Add("PopulationSizeOption", "");
        //    dic.Add("iColName", "");
        //    dic.Add("iColValue", "");
        //    pFutureValuationOption._PropulationSize(dic);
        //</summary>
        //<param name="dic"></param>
        public void _PropulationSize(MyDictionary dic)
        {

            if (dic["PopVerify"] == "Pop")
            {
                int iRow = Convert.ToInt32(dic["iRowNum"]);
                String sRowKeys = "";
                  
                _gLib._SetSyncUDWin("ModelPopulationSizePerParticipantGroup", this.wFutureValuationOption.wModelPopulationSizePerParticipantGroup.chx, dic["ModelPopulationSizePerParticipantGroup"], 0);


                for (int i = 1; i < iRow; i++)
                    sRowKeys = sRowKeys + "{Down}";
                _gLib._SetSyncUDWin("", this.wFutureValuationOption.wPopulationSizeGrid.grid, "click", 0, false, 20, 25);
                _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeGrid.grid, "{Right}{Home}" + sRowKeys);


                if (dic["ParticipantGroup"] != "")
                    if (this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wPopulationSizeGrid.grid) != dic["ParticipantGroup"])
                        _gLib._MsgBoxYesNo("Continue Testing?", "ParticipantGroup is not mattched");


                if (dic["PopulationSizeOption"] != "")
                {
                    _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeGrid.grid, "{Home}{Tab}{Enter}");

                    string sAct = this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wPopulationSizeGrid.grid);
                    if (sAct != dic["PopulationSizeOption"])
                    {
                        _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeGrid.grid, "{Home}{Tab}{Enter}{Enter}");
                        this.wCommmonWindow.wListBox.wList.item.SearchProperties.Add(WinListItem.PropertyNames.Name, dic["PopulationSizeOption"]);
                        _gLib._SetSyncUDWin("PopulationSizeOption", this.wCommmonWindow.wListBox.wList.item, "click", 0);
                       
                        // check
                        _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeGrid.grid, "{Home}{Tab}{Enter}");
                        sAct = this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wPopulationSizeGrid.grid);
                        if (sAct != dic["PopulationSizeOption"])
                        {
                            _gLib._MsgBoxYesNo("", "PopulationSizeOption=> the expected value is <" + dic["PopulationSizeOption"] + ">, but the act value is <" + sAct + ">");
                        }
                    }
                }


                if (dic["iColName"] != "")
                {
                    int iCol = Convert.ToInt32(dic["iColName"]);
                    string sRightkeys = "{Home}";

                    for (int i = 1; i <= iCol; i++)
                        sRightkeys = sRightkeys + "{Right}";

                    _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeGrid.grid, sRightkeys + "{Space}");
                    _gLib._SendKeysUDWin("Edit", this.wFutureValuationOption.wPopulationSizeEdit.txt, "A", 0, ModifierKeys.Control, false);
                    _gLib._SendKeysUDWin("Edit", this.wFutureValuationOption.wPopulationSizeEdit.txt, "{Delete}", 0);


                    if (dic["iColValue"] != "")
                    {
                        //// modified by DE
                        _gLib._SetSyncUDWin("", this.wFutureValuationOption.wPopulationSizeEdit.txt, dic["iColValue"], 0);
                    
                        //_gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeGrid.grid, "{Tab}", 0, ModifierKeys.Shift, false );
                        //_gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeGrid.grid, "{Home}" + sRightkeys );
                        //string sAct = this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wPopulationSizeGrid.grid);
                        //if (sAct != dic["iColValue"])
                        //    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["iColValue"] + "> but,the Actual value is <" + sAct + ">");
                    }

                    _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeGrid.grid, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeGrid.grid, "{Home}", 0, ModifierKeys.Control, false);
                }
            }
        }


        //<summary>
        //2015-Oct-15
        //ruiyang.song@mercer.com

        //sample:
        //    dic.Clear();
        //    dic.Add("PopVerify", "Pop");
        //    dic.Add("SelectionCriteria", "");
        //    dic.Add("iResultRow", "1");
        //    pFutureValuationOption._AddTestCase(dic);
        //</summary>
        //<param name="dic"></param>
        public void _AddTestCase(MyDictionary dic)
        {

            string sFunctionName = "_AddTestCase";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("Restore Apply", this.wFutureValuationOption.wRestoredefault.btn, "Click", 0);
            _gLib._SetSyncUDWin_ByClipboard("Selection Criteria", this.wFutureValuationOption.wSelectionCriteria.txt, dic["SelectionCriteria"], 0);
            _gLib._SetSyncUDWin("Apply", this.wFutureValuationOption.wApply.btn, "Click", 0);

            int iPosX = 20;
            int iPos_Start_Y = 8;
            int iStepY = 22;

            int iPosY = Convert.ToInt32(dic["iResultRow"]) * iStepY + iPos_Start_Y;
            ////////////Mouse.Click(this.wRetirementStudio.wFPGrid_Results.grid, new Point(iPosX, iPosY));
            _gLib._SetSyncUDWin("Selection Results", this.wFutureValuationOption.wSelectionResults.grid, "Click", 0, false, iPosX, iPosY);

            _gLib._SetSyncUDWin("Add Selection To Library", this.wFutureValuationOption.wAddSelectedToLibrary.btn, "Click", 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        //<summary>
         //2015-Oct-15 
         //ruiyang.song@mercer.com
         
         //sample:
           //dic.Clear();
           // dic.Add("PopVerify", "Pop");
           // dic.Add("RemoveAllFromLibrary", "click");
           // dic.Add("iRowNum", "");
           // dic.Add("ParticipantGroup", "");
           // dic.Add("iColNum", "");
           // dic.Add("VOShortName", "");
           // dic.Add("iColValue", "");
           //pFutureValuationOption._NewEntrants_TestCaseLibrary(dic);
         //</summary>
         //<param name="dic"></param>
        public void _NewEntrants_TestCaseLibrary(MyDictionary dic)
        {

            string sFunctionName = "_NewEntrants_TestCaseLibrary";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                String sFirst = "";
                String sRowKeys = "";

                if (dic["RemoveAllFromLibrary"].ToUpper() == "CLICK")
                {
                    _gLib._SetSyncUDWin("RemoveAllFromLibrary", this.wFutureValuationOption.wRemoveAllfromLibrary.btn, "click", 0);
                    _gLib._SetSyncUDWin("RemoveAllFromLibrary", this.wConfirmRecordDeletio.wYes.btn, "click", 0);
                }


                int xPos = 20;
                int yPos = 25;

                this._fp._ClickFirstRow(this.wFutureValuationOption.wTestCaseLibrary.grid, xPos, yPos);


                if (dic["iRowNum"] != "" && Convert.ToInt32(dic["iRowNum"]) > 1)
                    for (int i = 2; i <= Convert.ToInt32(dic["iRowNum"]); i++)
                        sRowKeys = sRowKeys + "{Down}";

                _gLib._SendKeysUDWin("iRow", this.wFutureValuationOption.wTestCaseLibrary.grid, sRowKeys);



                if (dic["ParticipantGroup"] != "")
                {
                    sFirst = dic["ParticipantGroup"].Substring(0, 1);

                    for (int i = 1; i <= 20; i++)
                    {
                        _gLib._SendKeysUDWin("item", this.wFutureValuationOption.wTestCaseLibrary.grid, "{Home}{Right}" + sFirst + "{Left}{Right}");
                        if (this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wTestCaseLibrary.grid) == dic["ParticipantGroup"])
                            break;
                    }

                    _gLib._SendKeysUDWin("item", this.wFutureValuationOption.wTestCaseLibrary.grid, "{Home}{Right}");

                    if (this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wTestCaseLibrary.grid) != dic["ParticipantGroup"])
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["ParticipantGroup"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wTestCaseLibrary.grid) + ">" + Environment.NewLine);
                }


                if (dic["VOShortName"] != "")
                {
                    sFirst = dic["VOShortName"].Substring(0, 1);

                    for (int i = 1; i <= 20; i++)
                    {
                        _gLib._SendKeysUDWin("item", this.wFutureValuationOption.wTestCaseLibrary.grid, "{Home}{Right}{Right}" + sFirst + "{Left}{Right}");
                        if (this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wTestCaseLibrary.grid) == dic["VOShortName"])
                            break;
                    }

                    _gLib._SendKeysUDWin("item", this.wFutureValuationOption.wTestCaseLibrary.grid, "{Home}{Right}{Right}");
                    if (this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wTestCaseLibrary.grid) != dic["VOShortName"])
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["VOShortName"] + "> but,the Actual value is <" + this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wTestCaseLibrary.grid) + ">" + Environment.NewLine);
                }


                if (dic["iColNum"] != "")
                {

                    int iColNum = Convert.ToInt32(dic["iColNum"]) - 1;
                    String sRightKeys = "";

                    for (int i = 1; i <= iColNum; i++)
                        sRightKeys = sRightKeys + "{Right}";

                    _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wTestCaseLibrary.grid, "{Home}" + sRightKeys);
                    
                    _gLib._SendKeysUDWin("Edit", this.wFutureValuationOption.wTestCaseLibrary.grid, "{Space}", false);
                    _gLib._SendKeysUDWin("Edit", this.wFutureValuationOption.wPopulationSizeEdit.txt, "A", 0, ModifierKeys.Control, false);
                    _gLib._SendKeysUDWin("Edit", this.wFutureValuationOption.wPopulationSizeEdit.txt, "{Delete}", 0);


                    if (dic["iColValue"] != "")
                    {                     
                        _gLib._SetSyncUDWin("", this.wFutureValuationOption.wPopulationSizeEdit.txt, dic["iColValue"], 0, false);

                        _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeEdit.txt, "{Tab}", 0, ModifierKeys.Shift, false);
                        _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeGrid.grid, "{Tab}{space}" );
                        string sAct = this.wFutureValuationOption.wPopulationSizeEdit.txt.Text.Trim() ;
                        if (sAct != dic["iColValue"])
                            _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail !, Beause the exception Value is <" + dic["iColValue"] + "> but,the Actual value is <" + sAct + ">");
                    }
                    _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wTestCaseLibrary.grid, "{Home}");
                }

            }
        }


        //<summary>
         //2015-Oct-15 
         //ruiyang.song@mercer.com
         
         //sample:
         //   dic.Clear();
         //   dic.Add("PopVerify", "Pop");
         //   dic.Add("UsingRates_P", "");
         //   dic.Add("UsingRates_T", "");
         //   dic.Add("UsingRates_txt", "");
         //   dic.Add("UsingRates_cbo", "");
         //   pFutureValuationOption._NewEntrants_UsingRates(dic);
         //</summary>
         //<param name="dic"></param>
        public void _NewEntrants_UsingRates(MyDictionary dic)
        {

            string sFunctionName = "_NewEntrants_UsingRates";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                if (dic["UsingRates_txt"] != "")
                {
                    _gLib._SetSyncUDWin("UsingRates", this.wFutureValuationOption.wUsingRates_P.btn, dic["UsingRates_P"], 0);
                    _gLib._SetSyncUDWin_ByClipboard("UsingRates_txt", this.wFutureValuationOption.wUsingRates_txt.Edit, dic["UsingRates_txt"], true, 0);
                }


                if (dic["UsingRates_cbo"] != "")
                {
                    _gLib._SetSyncUDWin("UsingRates", this.wFutureValuationOption.wUsingRates_T.btn, dic["UsingRates_T"], 0);
                    _gLib._SetSyncUDWin("UsingRates_cbo", this.wFutureValuationOption.wUsingRates_cbo.cbo, dic["UsingRates_cbo"], 0);
                }

            }
        }


        /// <summary>
        /// 2015-Oct-15 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        /// 
        ///   dic.Clear();
        ///   dic.Add("PopVerify", "Pop");
        ///   dic.Add("AllBenfitDefinitionsInOneGroup", "");
        ///   dic.Add("ByDecrement", "");
        ///   dic.Add("CustomGroupingByBenefitDefinitions", "");
        ///   dic.Add("AddRow", "");
        ///   dic.Add("GroupName", "");
        ///   dic.Add("Includes_DeathLiab", "true");
        ///   dic.Add("Includes_DisabilityLiab", "");
        ///   dic.Add("Includes_InactiveLiab", "");
        ///   dic.Add("Includes_RetirementLiab", "");
        ///   dic.Add("Includes_WithDrawalLiab", "");
        ///   dic.Add("Includes_WithDrawalLiab_US015", "");
        ///   dic.Add("OK", "");
        ///   pFutureValuationOption._AnnuityBen_And_LumpSum(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _AnnuityBen_And_LumpSum(MyDictionary dic)
        {

            string sFunctionName = "_AnnuityBen_And_LumpSum";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("_AnnuityBen_And_LumpSum", this.wFutureValuationOption.wAllBenefitDefinition.rd, dic["AllBenfitDefinitionsInOneGroup"], 0);
                _gLib._SetSyncUDWin("_AnnuityBen_And_LumpSum", this.wFutureValuationOption.wByDecrement.rd, dic["ByDecrement"], 0);
                _gLib._SetSyncUDWin("_AnnuityBen_And_LumpSum", this.wFutureValuationOption.wCustomGroupingByBenefit.rd, dic["CustomGroupingByBenefitDefinitions"], 0);

                _gLib._SetSyncUDWin("AddRow", this.wFutureValuationOption.wAddRow.btn, dic["AddRow"], 0);
                _gLib._SetSyncUDWin("GroupName", this.wAnnuityBenefitGroup.wGroupName.Edit, dic["GroupName"], 0);

                if (dic["GroupName"] != "")
                    _gLib._SetSyncUDWin("Includes_DeathLiab", this.wAnnuityBenefitGroup.wIncludingBenefitDefinitions, "click", 0);

                _gLib._SetSyncUDWin("Includes_DeathLiab", this.wAnnuityBenefitGroup.wDeathLiab.chk, dic["Includes_DeathLiab"], 0);
                _gLib._SetSyncUDWin("Includes_DisabilityLiab", this.wAnnuityBenefitGroup.wDisabilityLiab.chk, dic["Includes_DisabilityLiab"], 0);
                _gLib._SetSyncUDWin("Includes_InactiveLiab", this.wAnnuityBenefitGroup.wInactiveLiab.chk, dic["Includes_InactiveLiab"], 0);
                _gLib._SetSyncUDWin("Includes_RetirementLiab", this.wAnnuityBenefitGroup.wRetirementLiab.chk, dic["Includes_RetirementLiab"], 0);
                _gLib._SetSyncUDWin("Includes_WithDrawalLiab", this.wAnnuityBenefitGroup.wWithDrawalLiab.chk, dic["Includes_WithDrawalLiab"], 0);
                _gLib._SetSyncUDWin("Includes_WithDrawalLiab_US015", this.wAnnuityBenefitGroup.wWithDrawalLiab_US015.chk, dic["Includes_WithDrawalLiab_US015"], 0);
                _gLib._SetSyncUDWin("OK", this.wAnnuityBenefitGroup.wOK.btn, dic["OK"], 0);

            }

        }


        //<summary>
         //2015-Oct-15 
         //ruiyang.song@mercer.com
         
         //sample:
         
         //  dic.Clear();
         //  dic.Add("PopVerify", "Pop");
         //  dic.Add("GroupingByStatusCodes", "");
         //  dic.Add("CustomGroupingByBreakField", "");
         //  dic.Add("CustomGroupingByBreakField_Cbo", "");
         //  dic.Add("CustomGroupingBySelectionCriteria", "");

         //  dic.Add("AddRow", "");
         //  dic.Add("iRowNum", "");
         //  dic.Add("Group", "");
         //  dic.Add("SelectionCriteria", "");
         //  dic.Add("Remove", "");
         //  dic.Add("Validate", "");
         //  dic.Add("MoveUp", "");
         //  dic.Add("MoveDown", "");
         //  pFutureValuationOption._ParticipantGrouping(dic);
         
         //</summary>
         //<param name="dic"></param>
        public void _ParticipantGrouping(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_DeleteValuationNode";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("GroupingByStatusCodes", this.wFutureValuationOption.wGroupByStatusCodes.rd, dic["GroupingByStatusCodes"], 0);
                _gLib._SetSyncUDWin("CustomGroupingByBreakField", this.wFutureValuationOption.wCustomGroupingByBreakField.rd, dic["CustomGroupingByBreakField"], 0);
                _gLib._SetSyncUDWin("CustomGroupingByBreakField_Cbo", this.wFutureValuationOption.wCboCustomGroupingByBreakField.cbo, dic["CustomGroupingByBreakField_Cbo"], 0);
                _gLib._SetSyncUDWin("CustomGroupingBySelectionCriteria", this.wFutureValuationOption.wCustomGroupingBySelectionCriteria.rd, dic["CustomGroupingBySelectionCriteria"], 0);
                _gLib._SetSyncUDWin("AddRow", this.wFutureValuationOption.wAddRow.btn, dic["AddRow"], 0);


                int xPos = 10;
                int yPos = 25;

                this._fp._ClickFirstRow(this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid, xPos, yPos);
                _gLib._SendKeysUDWin("Group", this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid, "{Right}{Home}", 0);


                String sRowNum = "";

                if (dic["iRowNum"] != "" && Convert.ToInt32(dic["iRowNum"]) > 1)
                    for (int i = 2; i <= 2; i++)
                        sRowNum = sRowNum + "{Down}";

                if (dic["Group"] != "")
                {
                    //// Set Group
                    _gLib._SendKeysUDWin("Group", this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid, sRowNum + "{Space}", 0);
                    _gLib._SendKeysUDWin("Group", this.wFutureValuationOption.wEditSelectionCriteria.txt, "A", 0, ModifierKeys.Control, false);
                    _gLib._SendKeysUDWin("Group", this.wFutureValuationOption.wEditSelectionCriteria.txt, "{Delete}", 0);

                    _gLib._SendKeysUDWin("Group", this.wFutureValuationOption.wEditSelectionCriteria.txt, dic["Group"], 0);


                    this._fp._ClickFirstRow(this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid, xPos, yPos);
                    _gLib._SendKeysUDWin("SelectRow", this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid, sRowNum + "{Home}", 0);

                    if (this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid) != dic["Group"])
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail !! The Except value is <" + dic["Group"] + ">,but the Actual value is <" + this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid) + ">");
                    

                    if (dic["SelectionCriteria"] != "")
                    {
                        this._fp._ClickFirstRow(this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid, xPos, yPos);
                        _gLib._SendKeysUDWin("SelectionCriteria", this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid, sRowNum + "{Home}{Right}{Space}", 0);

                        _gLib._SendKeysUDWin("SelectionCriteria", this.wFutureValuationOption.wEditSelectionCriteria.txt, "A", 0, ModifierKeys.Control, false);
                        _gLib._SendKeysUDWin("SelectionCriteria", this.wFutureValuationOption.wEditSelectionCriteria.txt, "{back}{Delete}{back}", 0);
                        _gLib._SendKeysUDWin("SelectionCriteria", this.wFutureValuationOption.wEditSelectionCriteria.txt, "{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}{back}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{back}", 0);
                        _gLib._SendKeysUDWin("SelectionCriteria", this.wFutureValuationOption.wEditSelectionCriteria.txt, dic["SelectionCriteria"], 0);


                        this._fp._ClickFirstRow(this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid, xPos, yPos);
                        _gLib._SendKeysUDWin("SelectRow", this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid, sRowNum + "{Home}{Right}", 0);

                        if (this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid) == dic["SelectionCriteria"])
                            _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully selected: " + dic["SelectionCriteria"]);

                        else
                        {
                            _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> Ends");
                            _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function: <" + sFunctionName + "> Fail !! The Except value is <" + dic["SelectionCriteria"] + ">,but the Actual value is <" + this._fp._ReturnSelectRowContent(this.wFutureValuationOption.wGridCustomGroupingBySelectionCriteria.grid) + ">");
                        }
                    }

                }

                _gLib._SetSyncUDWin("Remove", this.wFutureValuationOption.wRemove.btn, dic["Remove"], 0);
                _gLib._SendKeysUDWin("Validate", this.wFutureValuationOption.wValidate.btn, dic["Validate"], 0);
                _gLib._SendKeysUDWin("MoveUp", this.wFutureValuationOption.wMoveUp.btn, dic["MoveUp"], 0);
                _gLib._SendKeysUDWin("MoveDown", this.wFutureValuationOption.wMoveDown.btn, dic["MoveDown"], 0);

            }
        }


        //<summary>
        //2015-Oct-15 
        //ruiyang.song@mercer.com
         
        //sample:
         
            //   dic.Clear();
            //   dic.Add("PopVerify", "Pop");
            //   dic.Add("EveryYearForTheFirst", "");
            //   dic.Add("AndEvery", "");
            //   dic.Add("UpToincludingProjectionYear", "");
            //   dic.Add("ProjectionYears", "");
            //   dic.Add("NumberOfRuns", "");
            //   dic.Add("RandomNumDismissed", "");
            //   dic.Add("FundingUpdateDate_UK", "");
            //   pFutureValuationOption._ProjectionYears(dic);
         
         
            //   dic.Clear();
            //   dic.Add("PopVerify", "Verify");
            //   dic.Add("EveryYearForTheFirst", "");
            //   dic.Add("AndEvery", "");
            //   dic.Add("UpToincludingProjectionYear", "");
            //   dic.Add("ProjectionYears", "");
            //   pFutureValuationOption._ProjectionYears(dic);
           
        //Annuity benefit grouping
        //</summary>
        //<param name="dic"></param>
        public void _ProjectionYears(MyDictionary dic)
        {

            string sFunctionName = "_ProjectionYears";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SendKeysUDWin_byPaste("EveryYearForTheFirst", this.wFutureValuationOption.wEveryYearForTheFirst.Edit, dic["EveryYearForTheFirst"], 0, true);
                _gLib._SetSyncUDWin("AndEvery", this.wFutureValuationOption.wAndEvery.cbo, dic["AndEvery"], 0);
                _gLib._SetSyncUDWin("UpToincludingProjectionYear", this.wFutureValuationOption.wUpToIncluding.cbo, dic["UpToincludingProjectionYear"], 0);
                _gLib._SetSyncUDWin("ProjectionYears", this.wFutureValuationOption.wProjectYears.Edit, dic["ProjectionYears"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FundingUpdateDate_UK", this.wFutureValuationOption.wFundingUpdateDate_UK.cbo.Edit, dic["FundingUpdateDate_UK"], 0);
                _gLib._SetSyncUDWin_ByClipboard("NumberOfRuns", this.wFutureValuationOption.wNudNumberOfRuns.Edit.txt, dic["NumberOfRuns"], 0);
                _gLib._SetSyncUDWin_ByClipboard("RandomNumDismissed", this.wFutureValuationOption.wNudRandomNumDismiss.Edit.txt, dic["RandomNumDismissed"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("EveryYearForTheFirst", this.wFutureValuationOption.wEveryYearForTheFirst.Edit, dic["EveryYearForTheFirst"], 0);
                _gLib._VerifySyncUDWin("AndEvery", this.wFutureValuationOption.wAndEvery.cbo, dic["AndEvery"], 0);
                if (_gLib._Enabled("", this.wFutureValuationOption.wUpToIncluding.cbo, 0, false))
                    _gLib._VerifySyncUDWin("UpToincludingProjectionYear", this.wFutureValuationOption.wUpToIncluding.cbo, dic["UpToincludingProjectionYear"], 0);
                _gLib._VerifySyncUDWin("ProjectionYears", this.wFutureValuationOption.wProjectYears.Edit, dic["ProjectionYears"], 0);

            }

        }



        /// <summary>
        /// 2015-Oct-15 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///   dic.Clear();
        ///   dic.Add("PopVerify", "Pop");
        ///   dic.Add("AlignRatesWithCurrent", "");
        ///   dic.Add("AlignRatesWithEach", "true");
        ///   dic.Add("EstimatedPPAMortality", "2008 Basis for all years");
        ///   pFutureValuationOption._FutureAssumptions(dic);
        /// 
        ///   dic.Clear();
        ///   dic.Add("PopVerify", "Verify");
        ///   dic.Add("AlignRatesWithCurrent", "");
        ///   dic.Add("AlignRatesWithEach", "");
        ///   dic.Add("EstimatedPPAMortality", "2008 Basis after 2017");
        ///   pFutureValuationOption._FutureAssumptions(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _FutureAssumptions(MyDictionary dic)
        {

            string sFunctionName = "_FutureAssumptions";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("AlignRatesWithCurrent", this.wFutureValuationOption.wAlignRatesWithCurrent.rd, dic["AlignRatesWithCurrent"], 0);
                _gLib._SetSyncUDWin("AlignRatesWithEach", this.wFutureValuationOption.wAlignRatesWithEach.rd, dic["AlignRatesWithEach"], 0);
                _gLib._SetSyncUDWin("EstimatedPPAMortality", this.wFutureValuationOption.wEstimatedPPAMortality.cbo, dic["EstimatedPPAMortality"], 0);
            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("AlignRatesWithCurrent", this.wFutureValuationOption.wAlignRatesWithCurrent.rd, dic["AlignRatesWithCurrent"], 0);
                _gLib._VerifySyncUDWin("AlignRatesWithEach", this.wFutureValuationOption.wAlignRatesWithEach.rd, dic["AlignRatesWithEach"], 0);
                _gLib._VerifySyncUDWin("EstimatedPPAMortality", this.wFutureValuationOption.wEstimatedPPAMortality.cbo, dic["EstimatedPPAMortality"], 0);
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


          //<summary>
        //2015-Oct-15 
        //ruiyang.song@mercer.com

        //sample:
        //dic.Clear();
        // dic.Add("PopVerify", "Pop");
        // dic.Add("sColName", "");
        // dic.Add("iRowNum", "");
        // dic.Add("iColValue", "");
        //pFutureValuationOption._NewEntrants_TestCaseLibrary_ComboSelection(dic);
        //</summary>
        //<param name="dic"></param>
        public void _NewEntrants_TestCaseLibrary_ComboSelection(MyDictionary dic)
        {

            string sFunctionName = "_NewEntrants_TestCaseLibrary_ComboSelection";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                int iRow = Convert.ToInt32(dic["iRowNum"]);
                string sRow = "";
                for (int i = 1; i < iRow; i++)
                    sRow = sRow + "{Down}";
                //_gLib._SendKeysUDWin("", this.wFutureValuationOption.UITestCaseLibraryFindCWindow.UIFindColumnComboBox, dic["sColName"].Substring(0, 1), 0);

                _gLib._SetSyncUDWin("", this.wFutureValuationOption.UITestCaseLibraryFindCWindow.UIFindColumnComboBox, dic["sColName"], 0);
                _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.UITestCaseLibraryFindCWindow.UIFindColumnComboBox, "{Tab}", 0);

                _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeGrid.grid, "{PageUP}" + sRow + "{space}");

                _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeEdit.txt, "A", 0, ModifierKeys.Control, false);
                _gLib._SendKeysUDWin("FPGrid", this.wFutureValuationOption.wPopulationSizeEdit.txt, "{Delete}", 0);

                _gLib._SetSyncUDWin("", this.wFutureValuationOption.wPopulationSizeEdit.txt, dic["iColValue"], 0, true);
            }
        }


        //<summary>
        //2015-Oct-15 
        //ruiyang.song@mercer.com

        //sample:
        // dic.Clear();
        // dic.Add("PopVerify", "Verify");
        // dic.Add("iCount", "");
        // dic.Add("iColumn", "");
        // dic.Add("sColumn", "");
        // pFutureValuationOption._NewEntrants_VerifyColnum(dic);
        // 
        //   the first item "" is included. 
        // 
        //</summary>
        //<param name="dic"></param>
        public void _NewEntrants_VerifyColnum(MyDictionary dic)
        {

            string sFunctionName = "_NewEntrants_VerifyColnum";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Verify")
            {
                if (dic["iCount"] != "")
                {
                    int iCount = Convert.ToInt32(dic["iCount"]);
                    int iTemp = this.wFutureValuationOption.UITestCaseLibraryFindCWindow.UIFindColumnComboBox.Items.Count;

                    if (iCount != iTemp)
                        _gLib._MsgBoxYesNo("", "Function Failed!!  the expected value is < " + iCount + " >, but the actual value is < " + iTemp  + " >.");
                }

                if (dic["iColumn"] != "")
                {
                    int iColumn = Convert.ToInt32(dic["iColumn"]);
                    string sActuColnumName;
                    
                    _gLib._SetSyncUDWin("", this.wFutureValuationOption.UITestCaseLibraryFindCWindow.UIFindColumnComboBox, "#" + dic["iColumn"] + "#", 0);


                    sActuColnumName = this.wFutureValuationOption.UITestCaseLibraryFindCWindow.UIFindColumnComboBox.SelectedItem;

                    if (sActuColnumName != dic["sColumn"])
                    { }// updated on Lori, we do nothing temparameter
                    //_gLib._MsgBoxYesNo("", "Function Failed!! For index: " + dic["iColumn"] + ", the expected value is < " + dic["sColumn"] + " >, but the actual value is < " + sActuColnumName + " >.");
                                   
                }
            }
        }



        /// <summary>
        /// 2015-Oct-15 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///   dic.Clear();
        ///   dic.Add("PopVerify", "Pop");
        ///   dic.Add("OK", "");
        ///   pFutureValuationOption._PopVerify_OK(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_OK(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_OK";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
                _gLib._SetSyncUDWin("OK", this.wFutureValuationOption.wOK.btn, "click", 0);   

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


    }
}
