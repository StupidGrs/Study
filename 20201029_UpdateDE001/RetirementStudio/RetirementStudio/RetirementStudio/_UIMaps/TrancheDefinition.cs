namespace RetirementStudio._UIMaps.TrancheDefinitionClasses
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
    
    
    public partial class TrancheDefinition
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();




        /// <summary>
        /// 2015-June-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Active_Service", "");
        ///    dic.Add("Deferred_Service", "");
        ///    dic.Add("Deferred_ApplyTrancheSplits", "");
        ///    dic.Add("Pensioner_Service", "");
        ///    dic.Add("Pensioner_ApplyTrancheSplits", "");
        ///    pTrancheDefinition._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Active_Service", this.wRetirementStudio.wActive_Service.cbo, dic["Active_Service"], 0);
                _gLib._SetSyncUDWin("Deferred_Service", this.wRetirementStudio.wDeferred_Service.cbo, dic["Deferred_Service"], 0);
                _gLib._SetSyncUDWin("Deferred_ApplyTrancheSplits", this.wRetirementStudio.wDeferred_ApplyTrancheSplits.chk, dic["Deferred_ApplyTrancheSplits"], 0);
                _gLib._SetSyncUDWin("Pensioner_Service", this.wRetirementStudio.wPensioner_Service.cbo, dic["Pensioner_Service"], 0);
                _gLib._SetSyncUDWin("Pensioner_ApplyTrancheSplits", this.wRetirementStudio.wPensioner_ApplyTrancheSplits.chk, dic["Pensioner_ApplyTrancheSplits"], 0);
           

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Active_Service", this.wRetirementStudio.wActive_Service.cbo, dic["Active_Service"], 0);
                _gLib._VerifySyncUDWin("Deferred_Service", this.wRetirementStudio.wDeferred_Service.cbo, dic["Deferred_Service"], 0);
                _gLib._VerifySyncUDWin("Deferred_ApplyTrancheSplits", this.wRetirementStudio.wDeferred_ApplyTrancheSplits.chk, dic["Deferred_ApplyTrancheSplits"], 0);
                _gLib._VerifySyncUDWin("Pensioner_Service", this.wRetirementStudio.wPensioner_Service.cbo, dic["Pensioner_Service"], 0);
                _gLib._VerifySyncUDWin("Pensioner_ApplyTrancheSplits", this.wRetirementStudio.wPensioner_ApplyTrancheSplits.chk, dic["Pensioner_ApplyTrancheSplits"], 0);
           
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2015-June-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", "Add new Tranche"); 
        ///    pTrancheDefinition._DefinitionFPGrid_RightSelect("Deferred", "Add new Tranche"); 
        ///    pTrancheDefinition._DefinitionFPGrid_RightSelect("Pensioner", "Add new Tranche"); 
        /// </summary>
        /// <param name="sType"></param>
        /// <param name="sMenuItem"></param>
        public void _DefinitionFPGrid_RightSelect(string sType, string sMenuItem)
        {
            string sFunctionName = "_DefinitionFPGrid_RightSelect";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            WinClient grid = new WinClient();
            switch (sType)
            {
                case "Active":
                    grid = this.wRetirementStudio.wActive_Definitions_FPGrid.grid;
                    break;
                case "Deferred":
                    grid = this.wRetirementStudio.wDeferred_Definitions_FPGrid.grid;
                    break;
                case "Pensioner":
                    grid = this.wRetirementStudio.wPensioner_Definitions_FPGrid.grid;
                    break;
                default:
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because input Type does NOT exists.");
                    break;
            }


            try
            {
                Mouse.Click(grid, MouseButtons.Right, ModifierKeys.None, new Point(30, 40));
            }
            catch (Exception ex)
            {
                _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to Right click ongrid <" + sType + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right click on TreeView item <" + sType + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
            }


            WinWindow wWin = new WinWindow();
            wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "DropDown");
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains);
            wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

            if (_gLib._Exists("DropDown Menu Parent Win", wWin, 0))
            {
                MyDictionary dicTmp = new MyDictionary();
                dicTmp.Clear();
                dicTmp.Add("Level_1", sMenuItem);
                _gLib._MenuSelectWin(0, wWin, dicTmp);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }



        /// <summary>
        /// 2015-June-26
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pTrancheDefinition._DefinitionFPGrid_RightSelect("Active", 1, "Pre1997", "Edit Tranche"); 
        ///    pTrancheDefinition._DefinitionFPGrid_RightSelect("Deferred", 1, "Pre1997", "Edit Tranche"); 
        ///    pTrancheDefinition._DefinitionFPGrid_RightSelect("Pensioner", 1, "Pre1997", "Edit Tranche"); 
        ///    pTrancheDefinition._DefinitionFPGrid_RightSelect("Pensioner", 3, "Pst2005", "Edit Tranche"); 
        /// </summary>
        /// <param name="sType"></param>
        /// <param name="sMenuItem"></param>
        public void _DefinitionFPGrid_RightSelect(string sType, int iRow, string sLabel, string sMenuItem)
        {
            string sFunctionName = "_DefinitionFPGrid_RightSelect";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sActLabel = "";
            string sDownKeys = "{PageUp}";
            for (int i = 1; i < iRow; i++)
                sDownKeys = sDownKeys + "{Down}";


            WinClient grid = new WinClient();
            switch (sType)
            {
                case "Active":
                    grid = this.wRetirementStudio.wActive_Definitions_FPGrid.grid;
                    break;
                case "Deferred":
                    grid = this.wRetirementStudio.wDeferred_Definitions_FPGrid.grid;
                    break;
                case "Pensioner":
                    grid = this.wRetirementStudio.wPensioner_Definitions_FPGrid.grid;
                    break;
                default:
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because input Type does NOT exists.");
                    break;
            }

            _gLib._SetSyncUDWin(sType, grid, "Click", 0, false, 30, 40);
            _gLib._SendKeysUDWin(sType, grid, sDownKeys);

            sActLabel = _fp._ReturnSelectRowContentByClipboard(grid);
            if (!sActLabel.ToUpper().Contains(sLabel.ToUpper()))
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to find label <" + sLabel + "> at row <" + iRow + "> on grid <" + sType + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to find label <" + sLabel + "> at row <" + iRow + "> on grid <" + sType + ">");
           
            }
            else
            { 
                try
                {
                    Mouse.Click(grid, MouseButtons.Right, ModifierKeys.None, new Point(30, 40+(iRow-1)*20));
                }
                catch (Exception ex)
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to Right click ongrid <" + sType + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right click on TreeView item <" + sType + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
           
                }


                WinWindow wWin = new WinWindow();
                wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "DropDown");
                wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains);
                wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

                if (_gLib._Exists("DropDown Menu Parent Win", wWin, 0))
                {
                    MyDictionary dicTmp = new MyDictionary();
                    dicTmp.Clear();
                    dicTmp.Add("Level_1", sMenuItem);
                    _gLib._MenuSelectWin(0, wWin, dicTmp);

                }
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }




        /// <summary>
        /// 2015-June-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Name", "");
        ///    dic.Add("Actives", "");
        ///    dic.Add("Deferred", "");
        ///    dic.Add("Pensioner", "");
        ///    dic.Add("StartDate", "");
        ///    dic.Add("EndDate", "");
        ///    dic.Add("GMPApplies", "");
        ///    dic.Add("Active_PPFTranche", "");
        ///    dic.Add("Active_MalePPF_V", "");
        ///    dic.Add("Active_MalePPF_C", "");
        ///    dic.Add("Active_FemalePPF_V", "");
        ///    dic.Add("Active_FemalePPF_C", "");
        ///    dic.Add("Active_MaleSolvency_V", "");
        ///    dic.Add("Active_MaleSolvency_C", "");
        ///    dic.Add("Active_FemaleSolvency_V", "");
        ///    dic.Add("Active_FemaleSolvency_C", "");
        ///    dic.Add("Active_FullySalaryRelated", "");
        ///    dic.Add("Active_MalePPF_cbo", "");
        ///    dic.Add("Active_MalePPF_txt", "");
        ///    dic.Add("Active_FemalePPF_cbo", "");
        ///    dic.Add("Active_FemalePPF_txt", "");
        ///    dic.Add("Active_MaleSolvency_cbo", "");
        ///    dic.Add("Active_MaleSolvency_txt", "");
        ///    dic.Add("Active_FemaleSolvency_cbo", "");
        ///    dic.Add("Active_FemaleSolvency_txt", "");
        ///    dic.Add("Def_PPFTranche", "");
        ///    dic.Add("Def_MalePPF_V", "");
        ///    dic.Add("Def_MalePPF_C", "");
        ///    dic.Add("Def_FemalePPF_V", "");
        ///    dic.Add("Def_FemalePPF_C", "");
        ///    dic.Add("Def_MaleSolvency_V", "");
        ///    dic.Add("Def_MaleSolvency_C", "");
        ///    dic.Add("Def_FemaleSolvency_V", "");
        ///    dic.Add("Def_FemaleSolvency_C", "");
        ///    dic.Add("Def_MalePPF_cbo", "");
        ///    dic.Add("Def_MalePPF_txt", "");
        ///    dic.Add("Def_FemalePPF_cbo", "");
        ///    dic.Add("Def_FemalePPF_txt", "");
        ///    dic.Add("Def_MaleSolvency_cbo", "");
        ///    dic.Add("Def_MaleSolvency_txt", "");
        ///    dic.Add("Def_FemaleSolvency_cbo", "");
        ///    dic.Add("Def_FemaleSolvency_txt", "");
        ///    dic.Add("Pen_PPFTranche", "");
        ///    dic.Add("Pen_MalePPF_V", "");
        ///    dic.Add("Pen_MalePPF_C", "");
        ///    dic.Add("Pen_FemalePPF_V", "");
        ///    dic.Add("Pen_FemalePPF_C", "");
        ///    dic.Add("Pen_MaleSolvency_V", "");
        ///    dic.Add("Pen_MaleSolvency_C", "");
        ///    dic.Add("Pen_FemaleSolvency_V", "");
        ///    dic.Add("Pen_FemaleSolvency_C", "");
        ///    dic.Add("Pen_MalePPF_cbo", "");
        ///    dic.Add("Pen_MalePPF_txt", "");
        ///    dic.Add("Pen_FemalePPF_cbo", "");
        ///    dic.Add("Pen_FemalePPF_txt", "");
        ///    dic.Add("Pen_MaleSolvency_cbo", "");
        ///    dic.Add("Pen_MaleSolvency_txt", "");
        ///    dic.Add("Pen_FemaleSolvency_cbo", "");
        ///    dic.Add("Pen_FemaleSolvency_txt", "");
        ///    dic.Add("OK", "");
        ///    pTrancheDefinition._PopVerify_TrancheDefinition(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_TrancheDefinition(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_TrancheDefinition";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            int iTxt = 0;
            int iCbo = 0;

    

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Name", this.wTrancheDefinition.wName.txt, dic["Name"], 0);
                _gLib._SetSyncUDWin("Actives", this.wTrancheDefinition.wActives.chk, dic["Actives"], 0);
                _gLib._SetSyncUDWin("Deferred", this.wTrancheDefinition.wDeferred.chk, dic["Deferred"], 0);
                _gLib._SetSyncUDWin("Pensioner", this.wTrancheDefinition.wPensioner.chk, dic["Pensioner"], 0);
                if (dic["StartDate"] == "{Delete}")
                    _gLib._SetSyncUDWin_ByClipboard("StartDate", this.wTrancheDefinition.wStartDate.cbo.txt, dic["StartDate"], 0, false, false);
                else
                    _gLib._SetSyncUDWin_ByClipboard("StartDate", this.wTrancheDefinition.wStartDate.cbo.txt, dic["StartDate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("EndDate", this.wTrancheDefinition.wEndDate.cbo.txt, dic["EndDate"], 0);
                _gLib._SetSyncUDWin("GMPApplies", this.wTrancheDefinition.wGMPApplies.chk, dic["GMPApplies"], 0);

                _gLib._SetSyncUDWin("Active_PPFTranche", this.wTrancheDefinition.wActive_PPFTranche.cbo, dic["Active_PPFTranche"], 0);
                _gLib._SetSyncUDWin("Active_MalePPF_V", this.wTrancheDefinition.wActive_MalePPF_V.btn, dic["Active_MalePPF_V"], 0);
                _gLib._SetSyncUDWin("Active_MalePPF_C", this.wTrancheDefinition.wActive_MalePPF_C.btn, dic["Active_MalePPF_C"], 0);
                _gLib._SetSyncUDWin("Active_FemalePPF_V", this.wTrancheDefinition.wActive_FemalePPF_V.btn, dic["Active_FemalePPF_V"], 0);
                _gLib._SetSyncUDWin("Active_FemalePPF_C", this.wTrancheDefinition.wActive_FemalePPF_C.btn, dic["Active_FemalePPF_C"], 0);
                _gLib._SetSyncUDWin("Active_MaleSolvency_V", this.wTrancheDefinition.wActive_MaleSolvency_V.btn, dic["Active_MaleSolvency_V"], 0);
                _gLib._SetSyncUDWin("Active_MaleSolvency_C", this.wTrancheDefinition.wActive_MaleSolvency_C.btn, dic["Active_MaleSolvency_C"], 0);
                _gLib._SetSyncUDWin("Active_FemaleSolvency_V", this.wTrancheDefinition.wActive_FemaleSolvency_V.btn, dic["Active_FemaleSolvency_V"], 0);
                _gLib._SetSyncUDWin("Active_FemaleSolvency_C", this.wTrancheDefinition.wActive_FemaleSolvency_C.btn, dic["Active_FemaleSolvency_C"], 0);

                if (dic["Active_MalePPF_V"] != "") iCbo++;
                this.wTrancheDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo.ToString());
                _gLib._SetSyncUDWin("Active_MalePPF_cbo", this.wTrancheDefinition.wCommon_cbo.cbo, dic["Active_MalePPF_cbo"], 0);
                if (dic["Active_MalePPF_C"] != "") iTxt++;
                this.wTrancheDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Active_MalePPF_txt", this.wTrancheDefinition.wCommon_txt.txt, dic["Active_MalePPF_txt"], 0);

                if (dic["Active_FemalePPF_V"] != "") iCbo++;
                this.wTrancheDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo.ToString());
                _gLib._SetSyncUDWin("Active_FemalePPF_cbo", this.wTrancheDefinition.wCommon_cbo.cbo, dic["Active_FemalePPF_cbo"], 0);
                if (dic["Active_FemalePPF_C"] != "") iTxt++;
                this.wTrancheDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Active_FemalePPF_txt", this.wTrancheDefinition.wCommon_txt.txt, dic["Active_FemalePPF_txt"], 0);

                if (dic["Active_MaleSolvency_V"] != "") iCbo++;
                this.wTrancheDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo.ToString());
                _gLib._SetSyncUDWin("Active_MaleSolvency_cbo", this.wTrancheDefinition.wCommon_cbo.cbo, dic["Active_MaleSolvency_cbo"], 0);
                if (dic["Active_MaleSolvency_C"] != "") iTxt++;
                this.wTrancheDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Active_MaleSolvency_txt", this.wTrancheDefinition.wCommon_txt.txt, dic["Active_MaleSolvency_txt"], 0);


                if (dic["Active_FemaleSolvency_V"] != "") iCbo++;
                this.wTrancheDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo.ToString());
                _gLib._SetSyncUDWin("Active_FemaleSolvency_cbo", this.wTrancheDefinition.wCommon_cbo.cbo, dic["Active_FemaleSolvency_cbo"], 0);
                if (dic["Active_FemaleSolvency_C"] != "") iTxt++;
                this.wTrancheDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Active_FemaleSolvency_txt", this.wTrancheDefinition.wCommon_txt.txt, dic["Active_FemaleSolvency_txt"], 0);

                




                

                _gLib._SetSyncUDWin("Active_FullySalaryRelated", this.wTrancheDefinition.wActive_FullySalaryRelated.chk, dic["Active_FullySalaryRelated"], 0);

                _gLib._SetSyncUDWin("Def_PPFTranche", this.wTrancheDefinition.wDef_PPFTranche.cbo, dic["Def_PPFTranche"], 0);
                _gLib._SetSyncUDWin("Def_MalePPF_V", this.wTrancheDefinition.wDef_MalePPF_V.btn, dic["Def_MalePPF_V"], 0);
                _gLib._SetSyncUDWin("Def_MalePPF_C", this.wTrancheDefinition.wDef_MalePPF_C.btn, dic["Def_MalePPF_C"], 0);
                _gLib._SetSyncUDWin("Def_FemalePPF_V", this.wTrancheDefinition.wDef_FemalePPF_V.btn, dic["Def_FemalePPF_V"], 0);
                _gLib._SetSyncUDWin("Def_FemalePPF_C", this.wTrancheDefinition.wDef_FemalePPF_C.btn, dic["Def_FemalePPF_C"], 0);
                _gLib._SetSyncUDWin("Def_MaleSolvency_V", this.wTrancheDefinition.wDef_MaleSolvency_V.btn, dic["Def_MaleSolvency_V"], 0);
                _gLib._SetSyncUDWin("Def_MaleSolvency_C", this.wTrancheDefinition.wDef_MaleSolvency_C.btn, dic["Def_MaleSolvency_C"], 0);
                _gLib._SetSyncUDWin("Def_FemaleSolvency_V", this.wTrancheDefinition.wDef_FemaleSolvency_V.btn, dic["Def_FemaleSolvency_V"], 0);
                _gLib._SetSyncUDWin("Def_FemaleSolvency_C", this.wTrancheDefinition.wDef_FemaleSolvency_C.btn, dic["Def_FemaleSolvency_C"], 0);


                if (dic["Def_MalePPF_V"] != "") iCbo++;
                this.wTrancheDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo.ToString());
                _gLib._SetSyncUDWin("Def_MalePPF_cbo", this.wTrancheDefinition.wCommon_cbo.cbo, dic["Def_MalePPF_cbo"], 0);
                if (dic["Def_MalePPF_C"] != "") iTxt++;
                this.wTrancheDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Def_MalePPF_txt", this.wTrancheDefinition.wCommon_txt.txt, dic["Def_MalePPF_txt"], 0);

                if (dic["Def_FemalePPF_V"] != "") iCbo++;
                this.wTrancheDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo.ToString());
                _gLib._SetSyncUDWin("Def_FemalePPF_cbo", this.wTrancheDefinition.wCommon_cbo.cbo, dic["Def_FemalePPF_cbo"], 0);
                if (dic["Def_FemalePPF_C"] != "") iTxt++;
                this.wTrancheDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Def_FemalePPF_txt", this.wTrancheDefinition.wCommon_txt.txt, dic["Def_FemalePPF_txt"], 0);

                if (dic["Def_MaleSolvency_V"] != "") iCbo++;
                this.wTrancheDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo.ToString());
                _gLib._SetSyncUDWin("Def_MaleSolvency_cbo", this.wTrancheDefinition.wCommon_cbo.cbo, dic["Def_MaleSolvency_cbo"], 0);
                if (dic["Def_MaleSolvency_C"] != "") iTxt++;
                this.wTrancheDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Def_MaleSolvency_txt", this.wTrancheDefinition.wCommon_txt.txt, dic["Def_MaleSolvency_txt"], 0);

                if (dic["Def_FemaleSolvency_V"] != "") iCbo++;
                this.wTrancheDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo.ToString());
                _gLib._SetSyncUDWin("Def_FemaleSolvency_cbo", this.wTrancheDefinition.wCommon_cbo.cbo, dic["Def_FemaleSolvency_cbo"], 0);
                if (dic["Def_FemaleSolvency_C"] != "") iTxt++;
                this.wTrancheDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Def_FemaleSolvency_txt", this.wTrancheDefinition.wCommon_txt.txt, dic["Def_FemaleSolvency_txt"], 0);




                _gLib._SetSyncUDWin("Pen_PPFTranche", this.wTrancheDefinition_Pen.wPen_PPFTranche.cbo, dic["Pen_PPFTranche"], 0);
                _gLib._SetSyncUDWin("Pen_MalePPF_V", this.wTrancheDefinition_Pen.wPen_MalePPF_V.btn, dic["Pen_MalePPF_V"], 0);
                _gLib._SetSyncUDWin("Pen_MalePPF_C", this.wTrancheDefinition_Pen.wPen_MalePPF_C.btn, dic["Pen_MalePPF_C"], 0);
                _gLib._SetSyncUDWin("Pen_FemalePPF_V", this.wTrancheDefinition_Pen.wPen_FemalePPF_V.btn, dic["Pen_FemalePPF_V"], 0);
                _gLib._SetSyncUDWin("Pen_FemalePPF_C", this.wTrancheDefinition_Pen.wPen_FemalePPF_C.btn, dic["Pen_FemalePPF_C"], 0);
                _gLib._SetSyncUDWin("Pen_MaleSolvency_V", this.wTrancheDefinition_Pen.wPen_MaleSolvency_V.btn, dic["Pen_MaleSolvency_V"], 0);
                _gLib._SetSyncUDWin("Pen_MaleSolvency_C", this.wTrancheDefinition_Pen.wPen_MaleSolvency_C.btn, dic["Pen_MaleSolvency_C"], 0);
                _gLib._SetSyncUDWin("Pen_FemaleSolvency_V", this.wTrancheDefinition_Pen.wPen_FemaleSolvency_V.btn, dic["Pen_FemaleSolvency_V"], 0);
                _gLib._SetSyncUDWin("Pen_FemaleSolvency_C", this.wTrancheDefinition_Pen.wPen_FemaleSolvency_C.btn, dic["Pen_FemaleSolvency_C"], 0);


                if (dic["Pen_MalePPF_V"] != "") iCbo++;
                this.wTrancheDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo.ToString());
                _gLib._SetSyncUDWin("Pen_MalePPF_cbo", this.wTrancheDefinition.wCommon_cbo.cbo, dic["Pen_MalePPF_cbo"], 0);
                if (dic["Pen_MalePPF_C"] != "") iTxt++;
                this.wTrancheDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Pen_MalePPF_txt", this.wTrancheDefinition.wCommon_txt.txt, dic["Pen_MalePPF_txt"], 0);

                if (dic["Pen_FemalePPF_V"] != "") iCbo++;
                this.wTrancheDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo.ToString());
                _gLib._SetSyncUDWin("Pen_FemalePPF_cbo", this.wTrancheDefinition.wCommon_cbo.cbo, dic["Pen_FemalePPF_cbo"], 0);
                if (dic["Pen_FemalePPF_C"] != "") iTxt++;
                this.wTrancheDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Pen_FemalePPF_txt", this.wTrancheDefinition.wCommon_txt.txt, dic["Pen_FemalePPF_txt"], 0);

                if (dic["Pen_MaleSolvency_V"] != "") iCbo++;
                this.wTrancheDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo.ToString());
                _gLib._SetSyncUDWin("Pen_MaleSolvency_cbo", this.wTrancheDefinition.wCommon_cbo.cbo, dic["Pen_MaleSolvency_cbo"], 0);
                if (dic["Pen_MaleSolvency_C"] != "") iTxt++;
                this.wTrancheDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Pen_MaleSolvency_txt", this.wTrancheDefinition.wCommon_txt.txt, dic["Pen_MaleSolvency_txt"], 0);


                if (dic["Pen_FemaleSolvency_V"] != "") iCbo++;
                this.wTrancheDefinition.wCommon_cbo.SearchProperties.Add(WinWindow.PropertyNames.Instance, iCbo.ToString());
                _gLib._SetSyncUDWin("Pen_FemaleSolvency_cbo", this.wTrancheDefinition.wCommon_cbo.cbo, dic["Pen_FemaleSolvency_cbo"], 0);
                if (dic["Pen_FemaleSolvency_C"] != "") iTxt++;
                this.wTrancheDefinition.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, iTxt.ToString());
                _gLib._SetSyncUDWin_ByClipboard("Pen_FemaleSolvency_txt", this.wTrancheDefinition.wCommon_txt.txt, dic["Pen_FemaleSolvency_txt"], 0);



                
                _gLib._SetSyncUDWin("OK", this.wTrancheDefinition.wOK.btn, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._MsgBox("Warning", "No verify function here!");


            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 
        /// 2015-June-26
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("DataField", "Benefit1DB");
        ///    dic.Add("Tranches", "All");
        ///    dic.Add("TrueOrFalse", "True");
        ///    pTrancheDefinition._TBL_SelecctTotalBenefitFields(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _TBL_SelecctTotalBenefitFields(MyDictionary dic)
        {
            string sFunctionName = "_TBL_SelecctTotalBenefitFields";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRow = Convert.ToInt32(dic["iRow"]);

            _gLib._SetSyncUDWin("SelectTotalBenefitField", this.wRetirementStudio.wSelectTotalBenefitField_FPGrid_Deferred.grid, "Click", 0, false, 40, 26);

            int iPos_X = 78;
            int iPos_Y = 11 + iRow * 20;

            string sKeyDown = "";
            for (int i = 1; i < iRow; i++)
                sKeyDown = sKeyDown + "{Down}";

            if(dic["DataField"]!="")
            {
                _gLib._SendKeysUDWin("", this.wRetirementStudio.wSelectTotalBenefitField_FPGrid_Deferred.grid, sKeyDown + "{Tab}");
                string sChar = dic["DataField"].Substring(0, 1);
                _gLib._SendKeysUDWin("", this.wRetirementStudio.wSelectTotalBenefitField_FPGrid_Deferred.grid, sChar);
                _gLib._SetSyncUDWin("DataField", this.wRetirementStudio.wCommon_cbo.cbo, dic["DataField"], 0);

            }

            if (dic["Tranches"] != "")
            {
                _gLib._SetSyncUDWin("SelectTotalBenefitField", this.wRetirementStudio.wSelectTotalBenefitField_FPGrid_Deferred.grid, "Click", 0, false, 270, iPos_Y);

                ////////////_gLib._SendKeysUDWin("", this.wRetirementStudio.wSelectTotalBenefitField_FPGrid_Deferred.grid, sKeyDown + "{Tab}{Tab}{Enter}");
                ////////////_gLib._SetSyncUDWin("SelectTotalBenefitField", this.wRetirementStudio.wCommon_txt_Internal.txt, "Click", 0, false, iPos_X, iPos_Y);

                _gLib._SetSyncUDWin("All", this.wFPGrid_Common_List.wlist.list.chkAll, dic["TrueOrFalse"], 0);
                _gLib._SetSyncUDWin("SelectTotalBenefitField", this.wRetirementStudio.wSelectTotalBenefitField_FPGrid_Deferred.grid, "Click", 0, false, 40, 26);
                 
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        
    }
}
