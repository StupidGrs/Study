namespace RetirementStudio._UIMaps.ValuationProcessControlClasses
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

    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using RetirementStudio._ThridParty;
    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._UIMaps.OutputManagerClasses;
    using RetirementStudio._UIMaps.TestCaseLibraryClasses;


    public partial class ValuationProcessControl
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        
        /// <summary>
        /// 2016-Feb-25
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Name", "");
        ///    dic.Add("Planyearbegins", "");
        ///    dic.Add("Planyearends", "");
        ///    dic.Add("Valuationdate", "");
        ///    dic.Add("Outsidestudio", "");
        ///    dic.Add("Fundingservice", "");
        ///    dic.Add("OK", "");
        ///    pValuationProcessControl._AddNewService(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _AddNewService(MyDictionary dic)
        {
            string sFunctionName = "_AddNewService";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("Name", this.wValuationProcessCont.wName.txt, dic["Name"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Planyearbegins", this.wValuationProcessCont.wPlanYearBegins.cbo.UIDtPlanYearBeginsEdit, dic["Planyearbegins"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Planyearends", this.wValuationProcessCont.wPlanYearEnds.cbo.UIDtPlanYearEndsEdit, dic["Planyearends"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Valuationdate", this.wValuationProcessCont.wValuationDate.cbo.UIDtValuationDateEdit, dic["Valuationdate"], 0);

                _gLib._SetSyncUDWin("Outsidestudio", this.wValuationProcessCont.wOutsidestudio.rd, dic["Outsidestudio"], 0);
                _gLib._SetSyncUDWin("Fundingservice", this.wValuationProcessCont.wFundingService.cbo, dic["Fundingservice"], 0);
                _gLib._SetSyncUDWin("OK", this.wValuationProcessCont.wOK.btn, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }
        }


        public void _OpenVPC(string sName, int iIndex = 1 )
        {
            string sFunctionName = "_OpenVPC";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            Boolean bServiceSelected = false;

            int ixPos = 60;
            int iyPos = 30;
            int iyStep = 20;

            for (int i = 1; i <= 6; i++)
            {
                _gLib._SetSyncUDWin("Home", this.wRetirementStudio.wTab.wHome, "Click", 0);
                _gLib._SetSyncUDWin("click service", this.wRetirementStudio.wVPCServicesManage.grid, "Click", 0, false, ixPos, iyPos + iyStep * (i - 1));

                WinTabPage wTP = new WinTabPage(this.wRetirementStudio.wTab);
                wTP.SearchProperties.Add(WinTabPage.PropertyNames.Name, sName);

                if (_gLib._Exists(sName, wTP, 3, false))
                {
                    _gLib._SetSyncUDWin("Tab", wTP, "Click", 0, false, Config.iClickPos_X, Config.iClickPos_Y);
                    bServiceSelected = true;
                    break;
                }
             
            }

            if (!bServiceSelected)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  open service  <" + dic["ServiceName"] + ">. Please check input name!");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to open service <" + dic["ServiceName"] + ">. Please check input name!");
                return;
            }
            if (dic["PopVerify"] == "Verify")
            {
            }

        }

        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Phase");
        ///    dic.Add("Level_2", "Planning");
        ///    dic.Add("Level_3", "Basis");
        ///    pValuationProcessControl._TreeViewSelect(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>

        public void _TreeViewSelect(MyDictionary dic, Boolean bClickItem = false)
        {
            string sFunctionName = "_TreeViewSelect";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TreeViewSelectWin(0, bClickItem, this.wRetirementStudio.TvExplorer, dic);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-Feb-25
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ExportCheckListstoExcel", "Click");
        ///    dic.Add("FileName", "");
        ///    dic.Add("Save", "");
        ///    pValuationProcessControl._ExportCheckListstoExcel(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _ExportCheckListstoExcel(MyDictionary dic)
        {
            string sFunctionName = "_AddNewService";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ExportCheckListstoExcel", this.wRetirementStudio.wCheckListstoEeport.btn, dic["ExportCheckListstoExcel"], 0, false, 15, 5);
                if (_gLib._Exists("", this.wRetirementStudio.wCheckListstoEeport.btn, 3, false))
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wCheckListstoEeport.btn, "{Enter}", 0);
                _gLib._SetSyncUDWin_ByClipboard("FileName", this.wSaveAs.wFileName.txt, dic["FileName"], 0);
                _gLib._SetSyncUDWin("Save", this.wSaveAs.wSave.btn, dic["Save"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }
        }















    
    }
}
