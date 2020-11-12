namespace RetirementStudio._UIMaps.MainClasses
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

    public partial class Main
    {

        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private GenericLib_Web _gwLib = new GenericLib_Web();
        private FarPoint _fp = new FarPoint();


        public void _Debugging()
        {


            int i = this.wRetirementStudio.wFlowTree.flowTree.BoundingRectangle.Width;
            int j = this.wRetirementStudio.wFlowTree.flowTree.BoundingRectangle.Height;

            var aaa = _fp._ReturnSelectRowContent(this.wRetirementStudio.wAsset_WorkSapce_FPGrid.grid);

            var a = 0;



        }

        public void _SetLanguageAndRegional()
        {

            _gLib._Cmd("intl.cpl");

            string sFormat = "";
            string sCurrentFormat = "";

            switch (Config.eCountry)
            {
                case _Country.US:
                case _Country.ANZ:
                    sFormat = "English (United States)";
                    break;
                case _Country.CA:
                    sFormat = "English (Canada)";
                    break;
                case _Country.UK:
                    sFormat = "English (United Kingdom)";
                    break;
                case _Country.DE:
                    sFormat = "German (Germany)";
                    break;
                case _Country.NL:
                    sFormat = "Dutch (Netherlands)";
                    break;
                case _Country.IR:
                    sFormat = "English (Ireland)";
                    break;
                case _Country.BR:
                    sFormat = "Portuguese (Brazil)";
                    break;
                default:
                    break;
            }


            if (System.Environment.OSVersion.VersionString.IndexOf("6.1") != -1) // win7 system
            {
                sCurrentFormat = this.wRegionAndLanguage.wFormat.cbo.SelectedItem.ToString();

                if (!sCurrentFormat.Equals(sFormat))
                    _gLib._SetSyncUDWin("Format", this.wRegionAndLanguage.wFormat.cbo, sFormat, 0);

                _gLib._SetSyncUDWin("OK", this.wRegionAndLanguage.wOK.btn, "Click", 0);

                if (!sCurrentFormat.Equals(sFormat) && !Config.bBatchRun)
                    _gLib._MsgBox("Warning!", "Current Language Setting <" + sCurrentFormat + "> is different from Expected <" + sFormat + ">. Please restrat Studio!");

            }

            if (System.Environment.OSVersion.VersionString.IndexOf("6.3") != -1) // win10 system
            {
                sCurrentFormat = this.wRegionAndLanguage_Win10.wFormat.cbo.SelectedItem.ToString();

                if (!sCurrentFormat.Equals(sFormat))
                    _gLib._SetSyncUDWin("Format", this.wRegionAndLanguage_Win10.wFormat.cbo, sFormat, 0);
                if (sFormat.Equals("English (Canada)"))
                    _gLib._SetSyncUDWin("wShortDate", this.wRegionAndLanguage_Win10.wShortDate.cbo, "dd/MM/yyyy", 0);

                _gLib._SetSyncUDWin("OK", this.wRegionAndLanguage_Win10.wOK.btn, "Click", 0);

                if (!sCurrentFormat.Equals(sFormat) && !Config.bBatchRun)
                    _gLib._MsgBox("Warning!", "Current Language Setting <" + sCurrentFormat + "> is different from Expected <" + sFormat + ">. Please restrat Studio!");

            }



        }

        public void _Initialize()
        {

            _gLib._SetSyncUDWin("Home_TitleBar", this.wRetirementStudio.tbHome_TitleBar, "Click", 0);
            this._SelectTab("Home");
            _gLib._SetSyncUDWin("ToolBar.PMTools", this.wRetirementStudio.wHome_ServiceTab.tlbToolBar.btnPMTools, "Click", 0);
            this._SelectTab("Home");
        }

        public void _SelectTab(string sTabName)
        {
            string sFunctionName = "_SelectTab";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (sTabName == "Output Manager")
            {
                OutputManager pOutputManager = new OutputManager();
                if (_gLib._Exists("Output Manager Setup", pOutputManager.wOutputManagerSetup, 1, false))
                {
                    if (_gLib._Enabled("Add All", pOutputManager.wOutputManagerSetup.wAddAll, 1, false))
                        _gLib._SetSyncUDWin("Add All", pOutputManager.wOutputManagerSetup.wAddAll.btnAddAll, "Click", 0);
                    _gLib._SetSyncUDWin("OK", pOutputManager.wOutputManagerSetup.wOK.btnOK, "Click", 0);
                }

                ////////////_gLib._SetSyncUDWin("Doer", pOutputManager.wRetirementStudio.wDoer.rdDoer, "True", 0);
            }

            _gLib._Enabled("RetirementStudio", this.wRetirementStudio, Config.iTimeout * 10);

            _gLib._TabPageSelectWin(sTabName, this.wRetirementStudio.wHome_Tab, Config.iTimeout * 3);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-Apr-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Country", Config.eCountry.ToString());
        ///    dic.Add("Level_1", "_abc");
        ///    dic.Add("Level_2", "DATA");
        ///    dic.Add("Level_3", "ParticipantData");
        ///    pMain._HomeTreeViewSelect(900, dic);
        ///
        ///    dic.Clear();
        ///    dic.Add("Level_1", _Config.sClientName);
        ///    dic.Add("Level_2", _Config.sPlanName);
        ///    dic.Add("Level_3", "ParticipantData");
        ///    pMain._HomeTreeViewSelect(0, dic);
        ///
        ///    dic.Clear();
        ///    dic.Add("Level_1", _Config.sClientName);
        ///    dic.Add("Level_2", _Config.sPlanName);
        ///    dic.Add("Level_3", "FundingValuations");
        ///    pMain._HomeTreeViewSelect(0, dic);
        ///
        ///    dic.Clear();
        ///    dic.Add("Level_1", _Config.sClientName);
        ///    dic.Add("Level_2", _Config.sPlanName);
        ///    dic.Add("Level_3", "AccountingValuations");
        ///    pMain._HomeTreeViewSelect(0, dic);
        ///    
        ///    dic.Clear();
        ///    dic.Add("Country", Config.eCountry.ToString());
        ///    dic.Add("Level_1", _Config.sClientName);
        ///    dic.Add("Level_2", _Config.sPlanName);
        ///    dic.Add("Level_3", "AssetData");
        ///    pMain._HomeTreeViewSelect(0, dic);
        /// 
        /// </summary>
        /// <param name="iSearchTimeout"></param>
        /// <param name="dic"></param>
        public void _HomeTreeViewSelect(int iSearchTimeout, MyDictionary dic)
        {

            string sFunctionName = "_HomeTreeViewSelect";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            #region old codes under Debug mode



            string sCountry = dic["Country"];

            _gLib._SetSyncUDWin("ClientName", this.wRetirementStudio.wHome_TypeClientName.txtClientName, dic["Level_1"], 0);

            if ((Config.eEnv == _TestingEnv.QA1) || (Config.eEnv == _TestingEnv.QA2) || (Config.eEnv == _TestingEnv.QA3) || (Config.eEnv == _TestingEnv.QA4) || (Config.eEnv == _TestingEnv.QA5) || (Config.eEnv == _TestingEnv.Preprod_EU) || (Config.eEnv == _TestingEnv.Preprod_US) || (Config.eEnv == _TestingEnv.Preprod_CA))
            {
                int iDownNum = 0;

                Keyboard.SendKeysDelay = 2;

                // case: the newly client is at the bottom
                if (_gLib._Exists("PMTools", this.wRetirementStudio.wHome_Tab.tabPMTools, 1, false))
                {

                    // make sure collapse all
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wHome_AllServices, "{End}");
                    _gLib._SendKeysUDWin("Services", this.wRetirementStudio.wHome_AllServices, "{End}");

                    for (int i = 0; i < 5; i++)
                        _gLib._SendKeysUDWin("Services", this.wRetirementStudio.wHome_AllServices, "{Left}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wHome_AllServices, "{Left}");

                    // expand all
                    for (int i = 0; i < 5; i++)
                        _gLib._SendKeysUDWin("Services", this.wRetirementStudio.wHome_AllServices, "{Right}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wHome_AllServices, "{Right}");



                    switch (dic["Level_3"])
                    {
                        case "":
                            break;
                        case "ParticipantData":
                            break;
                        case "AssetData":
                        case "PensionValuations":
                            {
                                iDownNum = 1;
                                break;
                            }
                        case "FundingValuations":
                            {
                                if (sCountry.Equals("NL") || sCountry.Equals("IR") || sCountry.Equals("BR") || sCountry.Equals("ANZ"))
                                    iDownNum = 1;
                                else
                                    iDownNum = 2;
                                break;
                            }
                        case "JubileeValuations":
                            {
                                iDownNum = 2;
                                break;
                            }
                        case "AccountingValuations":
                            {
                                if (sCountry.Equals("NL") || sCountry.Equals("IR") || sCountry.Equals("BR") || sCountry.Equals("ANZ"))
                                    iDownNum = 2;
                                else
                                    iDownNum = 3;
                                break;
                            }
                        case "ValuationProcessControl":
                            {
                                iDownNum = 5;  //// UK
                                break;
                            }
                        default:
                            {
                                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail. Please check input parameter!");
                                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail. Please check input parameter!");
                                break;
                            }
                    }
                }
                else // case the client is NOT at the bottom
                {
                    this.wRetirementStudio.wHome_AllServices.SetFocus();
                    this.wRetirementStudio.wHome_AllServices.SetFocus();


                    // make sure collapse all
                    for (int i = 0; i < 5; i++)
                        _gLib._SendKeysUDWin("Services", this.wRetirementStudio.wHome_AllServices, "{Left}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wHome_AllServices, "{Left}");

                    // expand all
                    for (int i = 0; i < 5; i++)
                        _gLib._SendKeysUDWin("Services", this.wRetirementStudio.wHome_AllServices, "{Right}");
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wHome_AllServices, "{Right}");


                    switch (dic["Level_3"])
                    {
                        case "":
                            break;
                        case "ParticipantData":
                            break;
                        case "AssetData":
                        case "PensionValuations":
                            {
                                iDownNum = 1;
                                break;
                            }
                        case "FundingValuations":
                            {
                                if (sCountry.Equals("NL") || sCountry.Equals("IR") || sCountry.Equals("BR") || sCountry.Equals("ANZ"))
                                    iDownNum = 1;
                                else
                                    iDownNum = 2;
                                break;
                            }
                        case "JubileeValuations":
                            {
                                iDownNum = 2;
                                break;
                            }
                        case "AccountingValuations":
                            {
                                if (sCountry.Equals("NL") || sCountry.Equals("IR") || sCountry.Equals("BR") || sCountry.Equals("ANZ"))
                                    iDownNum = 2;
                                else
                                    iDownNum = 3;
                                break;
                            }
                        case "ValuationProcessControl":
                            {
                                if (sCountry.Equals("UK"))
                                    iDownNum = 5;  //// UK
                                break;
                            }
                        default:
                            {
                                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail. Please check input parameter!");
                                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail. Please check input parameter!");
                                break;
                            }
                    }

                }

                if (dic["Level_3"].Equals("") && !dic["Level_2"].Equals(""))  // need to select plan
                    _gLib._SendKeysUDWin("Services", this.wRetirementStudio.wHome_AllServices, "{Up}");
                else
                    for (int i = 0; i < iDownNum; i++)
                        _gLib._SendKeysUDWin("Services", this.wRetirementStudio.wHome_AllServices, "{Down}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wHome_AllServices, "{Down}");

                Keyboard.SendKeysDelay = 0;

            }
            else
            {
                //Dictionary<string, WinTreeItem> dicObj = new Dictionary<string, WinTreeItem>();

                //if (dic["Level_1"] != "")
                //{
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.SearchProperties.Add(WinTreeItem.PropertyNames.MaxDepth, "0");
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.SearchProperties["Value"] = "0";
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.SearchProperties.Add(WinTreeItem.PropertyNames.Name, dic["Level_1"]);
                //    dicObj.Add("obj_Level_1", this.wRetirementStudio.wHome_AllServices.tvTreeItem);
                //}
                //if (dic["Level_2"] != "")
                //{
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.tvTreeItemSub1.SearchConfigurations.Add(SearchConfiguration.NextSibling);
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.tvTreeItemSub1.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.tvTreeItemSub1.SearchProperties.Add(WinTreeItem.PropertyNames.MaxDepth, "0");
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.tvTreeItemSub1.SearchProperties["Value"] = "1";
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.tvTreeItemSub1.SearchProperties.Add(WinTreeItem.PropertyNames.Name, dic["Level_2"]);
                //    dicObj.Add("obj_Level_2", this.wRetirementStudio.wHome_AllServices.tvTreeItem.tvTreeItemSub1);
                //}
                //if (dic["Level_3"] != "")
                //{
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.tvTreeItemSub1.tvTreeItemSub2.SearchConfigurations.Add(SearchConfiguration.NextSibling);
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.tvTreeItemSub1.tvTreeItemSub2.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.tvTreeItemSub1.tvTreeItemSub2.SearchProperties.Add(WinTreeItem.PropertyNames.MaxDepth, "0");
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.tvTreeItemSub1.tvTreeItemSub2.SearchProperties["Value"] = "2";
                //    this.wRetirementStudio.wHome_AllServices.tvTreeItem.tvTreeItemSub1.tvTreeItemSub2.SearchProperties.Add(WinTreeItem.PropertyNames.Name, dic["Level_3"]);
                //    dicObj.Add("obj_Level_3", this.wRetirementStudio.wHome_AllServices.tvTreeItem.tvTreeItemSub1.tvTreeItemSub2);
                //}

                MyDictionary mydic = new MyDictionary();
                mydic.Clear();
                mydic.Add("Level_1", dic["Level_1"]);
                mydic.Add("Level_2", dic["Level_2"]);
                mydic.Add("Level_3", dic["Level_3"]);
                _gLib._TreeViewSelectWin(iSearchTimeout, this.wRetirementStudio.wHome_AllServices, mydic);
            }


            #endregion



            #region new codes under Run Test mode

            ////////_gLib._SetSyncUDWin("ClientName", this.wRetirementStudio.wHome_TypeClientName.txtClientName, dic["Level_1"], 0);


            ////////MyDictionary mydic = new MyDictionary();
            ////////mydic.Clear();
            ////////mydic.Add("Level_1", dic["Level_1"]);
            ////////mydic.Add("Level_2", dic["Level_2"]);
            ////////if (dic["Level_3"] != "")
            ////////    mydic.Add("Level_3", dic["Level_3"]);
            ////////_gLib._TreeViewSelectWin(iSearchTimeout, true, this.wRetirementStudio.wHome_AllServices, mydic);

            #endregion


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        public string _HomeTreeViewSelect_Favorites(int iSearchTimeout, MyDictionary dic)
        {

            string sFunctionName = "_HomeTreeViewSelect_Favorites";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string returnValue = "";


            MyDictionary mydic = new MyDictionary();
            mydic.Clear();
            mydic.Add("Level_1", dic["Level_1"]);
            mydic.Add("Level_2", dic["Level_2"]);
            mydic.Add("Level_3", dic["Level_3"]);
            returnValue = _gLib._TreeViewSelectWin(iSearchTimeout, true, this.wRetirementStudio.wHome_Favorites, mydic);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

            return returnValue;
        }


        public string _HomeTreeViewSelect_AllServices(int iSearchTimeout, MyDictionary dic)
        {

            string sFunctionName = "_HomeTreeViewSelect_Favorites";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string returnValue = "";


            MyDictionary mydic = new MyDictionary();
            mydic.Clear();
            mydic.Add("Level_1", dic["Level_1"]);
            mydic.Add("Level_2", dic["Level_2"]);
            mydic.Add("Level_3", dic["Level_3"]);
            returnValue = _gLib._TreeViewSelectWin(iSearchTimeout, true, this.wRetirementStudio.wHome_AllServices, mydic);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

            return returnValue;
        }


        /// <summary>
        /// 2013-Nov-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// pMain._HomeTreeViewSelect_US017(Config.sClientName, 1, 2);
        /// pMain._HomeTreeViewSelect_US017(Config.sClientName, 2, 2);
        /// </summary>
        /// <param name="sClientName"></param>
        /// <param name="iPlan1_Plan2"></param>
        /// <param name="iData1_Funding2_Accounting3"></param>
        public void _HomeTreeViewSelect_US017(string sClientName, int iPlan1_Plan2, int iData1_Funding2_Accounting3)
        {
            string sFunctionName = "_HomeTreeViewSelect";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("ClientName", this.wRetirementStudio.wHome_TypeClientName.txtClientName, sClientName, 0);

            this.wRetirementStudio.wHome_AllServices.SetFocus();
            this.wRetirementStudio.wHome_AllServices.SetFocus();


            ////// if PMTools exists ==> it is create new, navigate to last node
            if (_gLib._Exists("PM Tools", this.wRetirementStudio.wHome_Tab.tabPMTools, 1, false))
                _gLib._SendKeysUDWin("Services", this.wRetirementStudio.wHome_AllServices, "{End}");
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wHome_AllServices, "{End}");

            string skeys = "";
            // make sure collapse all
            for (int i = 0; i < 10; i++)
                _gLib._SendKeysUDWin("Services", this.wRetirementStudio.wHome_AllServices, "{Left}");
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wHome_AllServices, "{Left}");

            if (iPlan1_Plan2 == 1)
            {
                switch (iData1_Funding2_Accounting3)
                {
                    case 1:
                        skeys = "{Right}{Down}{Right}{Down}";
                        break;
                    case 2:
                        skeys = "{Right}{Down}{Right}{Down}{Down}{Down}";
                        break;
                    case 3:
                        skeys = "{Right}{Down}{Right}{Down}{Down}{Down}{Down}";
                        break;
                    default:
                        break;
                }
            }
            if (iPlan1_Plan2 == 2)
            {
                switch (iData1_Funding2_Accounting3)
                {
                    case 1:
                        skeys = "{Right}{Down}{Down}{Right}{Down}";
                        break;
                    case 2:
                        skeys = "{Right}{Down}{Down}{Right}{Down}{Down}{Down}";
                        break;
                    case 3:
                        skeys = "{Right}{Down}{Down}{Right}{Down}{Down}{Down}{Down}";
                        break;
                    default:
                        break;
                }
            }

            Keyboard.SendKeysDelay = 2;
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wHome_AllServices, skeys);
            _gLib._SendKeysUDWin("Services", this.wRetirementStudio.wHome_AllServices, skeys);

            Keyboard.SendKeysDelay = 0;

        }


        //public void _TreeViewSelect_HomeAllServices(int iSearchTimeout, MyDictionary dic)
        //{

        //    this._SearchTimeout_SetNew(iSearchTimeout);

        //    // type the client name to narrow down the search range and make object visible
        //    Keyboard.SendKeys(this.wRetirementStudio.wHome_TypeClientName.txtClientName, dic["Level_1"]);

        //    if (dic["Level_1"] != "")
        //    {
        //        this.wRetirementStudio.wHome_AllServices.tvTreeItem.SearchProperties["Value"] = "0";
        //        this.wRetirementStudio.wHome_AllServices.tvTreeItem.SearchProperties.Add(WinTreeItem.PropertyNames.MaxDepth, "5000");
        //        this.wRetirementStudio.wHome_AllServices.tvTreeItem.SearchProperties.Add(WinTreeItem.PropertyNames.Name, dic["Level_1"]);

        //        this._SetSyncUDWin(dic["Level_1"], this.wRetirementStudio.wHome_AllServices.tvTreeItem, "Click", iSearchTimeout);
        //        //this.RetirementStudio.Home_AllServices.TreeItem.SetFocus();
        //        //Mouse.Click(this.RetirementStudio.Home_AllServices.TreeItem, new Point(this._iClickPos_X, this._iClickPos_Y));
        //    }

        //    // expand tree items using keyboard
        //    for (int i = 0; i < 3; i++)
        //        Keyboard.SendKeys(this.wRetirementStudio.wHome_AllServices, "{Right}");

        //    WinTreeItem client = this.wRetirementStudio.wHome_AllServices.tvTreeItem;
        //    WinTreeItem plan1 = (WinTreeItem)(client.Nodes[0]);
        //    WinTreeItem participantData1 = (WinTreeItem)(plan1.Nodes[0]);
        //    WinTreeItem assetData1 = (WinTreeItem)(plan1.Nodes[1]);
        //    WinTreeItem fundingValuations1 = (WinTreeItem)(plan1.Nodes[2]);
        //    WinTreeItem accountingValuations1 = (WinTreeItem)(plan1.Nodes[3]);

        //    if (dic["Level_2"] != "")
        //    {
        //        this._SetSyncUDWin(dic["Level_2"], plan1, "Click", 0);
        //        //Mouse.Click(plan1, new Point(this._iClickPos_X, this._iClickPos_Y));
        //    }

        //    this._SetSyncUDWin(dic["Level_3"], participantData1, "Click", 0);
        //    this._SetSyncUDWin(dic["Level_3"], fundingValuations1, "Click", 0);
        //    //Mouse.Click(participantData1, new Point(this._iClickPos_X, this._iClickPos_Y));
        //    //Mouse.Click(fundingValuations1, new Point(this._iClickPos_X, this._iClickPos_Y));

        //    this._SearchTimeout_RestoreDefault();
        //    return;

        //}


        //public void _HomeSelectTab(string sTabName)
        //{
        //    string sFunctionName = "_HomeSelectTab";
        //    this._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

        //    switch (sTabName)
        //    {
        //        case "Home":
        //            this._SetSyncUDWin("TabHome", this.wRetirementStudio.wHome_Tab.tabHome, "Click", 0);
        //            break;
        //        case "PM Tools":
        //            this._SetSyncUDWin("TabPMTools", this.wRetirementStudio.wHome_Tab.tabPMTools, "Click", 0);
        //            break;

        //        default:
        //            {
        //                this._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  select Tab <" + sTabName + ">. Please check input name!");
        //                this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to select Tab <" + sTabName + ">. Please check input name!");
        //                break;
        //            }
        //    }

        //    this._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        //}



        /// <summary>
        /// 2013-Apr-10 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CustomClient", "True");
        ///    dic.Add("MetrixClient", "");
        ///    dic.Add("ClientName", "cuitUS008");
        ///    dic.Add("ClientCode", "US008Update");
        ///    dic.Add("FiscalYearEnd", "12/31");
        ///    dic.Add("MeasurementDate", "12/31");
        ///    dic.Add("Notes", "Client Owner: Karen Lanctot. Original client: KJL - Updated US008");
        ///    dic.Add("DataCenter", "Franklin");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Cancel", "");
        ///    pMain._PopVerify_PMToolClient(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PMTool_Client(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PMTool_Client";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("CustomClient", this.wPMTool_Client.wCustomClient.rdCustomClient, dic["CustomClient"], 0);
                _gLib._SetSyncUDWin("MetrixClient", this.wPMTool_Client.wMetrixClient.rdMetrixClient, dic["MetrixClient"], 0);
                if (dic["MetrixClient"].ToString().ToUpper().Equals("TRUE"))
                    _gLib._MsgBox("Manual Interaction", "Please manually select client <" + dic["ClientName"] + ">!");
                else
                    _gLib._SetSyncUDWin("ClientName", this.wPMTool_Client.wClientName.txtClientName, dic["ClientName"], 0);
                _gLib._SetSyncUDWin("ClientCode", this.wPMTool_Client.wClientCode.txtClientCode, dic["ClientCode"], 0);
                _gLib._SetSyncUDWin("FiscalYearEnd", this.wPMTool_Client.wFiscalYearEnd.txtFiscalYearEnd, dic["FiscalYearEnd"], 0);
                _gLib._SetSyncUDWin("MeasurementDate", this.wPMTool_Client.wMeasurementDate.txtMeasurementDate, dic["MeasurementDate"], 0);
                _gLib._SetSyncUDWin("Notes", this.wPMTool_Client.wNotes.txtNotes, dic["Notes"], 0);
                _gLib._SetSyncUDWin("DataCenter", this.wPMTool_Client.wDataCenter.cboDataCenter, dic["DataCenter"], 0);
                _gLib._SetSyncUDWin("OK", this.wPMTool_Client.wOK.btnOK, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wPMTool_Client.wCancel.btnCancel, dic["Cancel"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("CustomClient", this.wPMTool_Client.wCustomClient.rdCustomClient, dic["CustomClient"], 0);
                _gLib._VerifySyncUDWin("MetrixClient", this.wPMTool_Client.wMetrixClient.rdMetrixClient, dic["MetrixClient"], 0);
                _gLib._VerifySyncUDWin("ClientName", this.wPMTool_Client.wClientName.txtClientName, dic["ClientName"], 0);
                _gLib._VerifySyncUDWin("ClientCode", this.wPMTool_Client.wClientCode.txtClientCode, dic["ClientCode"], 0);
                _gLib._VerifySyncUDWin("FiscalYearEnd", this.wPMTool_Client.wFiscalYearEnd.txtFiscalYearEnd, dic["FiscalYearEnd"], 0);
                _gLib._VerifySyncUDWin("MeasurementDate", this.wPMTool_Client.wMeasurementDate.txtMeasurementDate, dic["MeasurementDate"], 0);
                _gLib._VerifySyncUDWin("Notes", this.wPMTool_Client.wNotes.txtNotes, dic["Notes"], 0);
                _gLib._VerifySyncUDWin("DataCenter", this.wPMTool_Client.wDataCenter.cboDataCenter, dic["DataCenter"], 0);
                _gLib._VerifySyncUDWin("OK", this.wPMTool_Client.wOK.btnOK, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wPMTool_Client.wCancel.btnCancel, dic["Cancel"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Apr-10 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("TypeClientName", "");
        ///    dic.Add("TreeViewClientName", "");
        ///    dic.Add("AddClient", "Click");
        ///    dic.Add("Title", "");
        ///    dic.Add("DeleteClient", "");
        ///    dic.Add("AddPlan", "");
        ///    pMain._PopVerify_PMTool(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("TypeClientName", "");
        ///    dic.Add("TreeViewClientName", "");
        ///    dic.Add("AddClient", "");
        ///    dic.Add("Title", "Client: zzzWebber");
        ///    dic.Add("DeleteClient", "");
        ///    dic.Add("AddPlan", "");
        ///    pMain._PopVerify_PMTool(dic);
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PMTool(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PMToolClient";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("TypeClientName", this.wRetirementStudio.wPMTool_TypeClientName.txtTypeClientName, dic["TypeClientName"], 0);
                if (dic["TreeViewClientName"] != "")
                {
                    MyDictionary dicTmp = new MyDictionary();
                    dicTmp.Clear();
                    dicTmp.Add("Level_1", dic["TreeViewClientName"]);
                    _gLib._TreeViewSelectWin(0, this.wRetirementStudio.wPMTool_TreeView, dicTmp);

                    //this.wRetirementStudio.wPMTool_TreeView.tvTreeViewitem.SearchProperties.Add(WinTreeItem.PropertyNames.Name, dic["TreeViewClientName"]);
                    //_gLib._SetSyncUDWin(dic["TreeViewClientName"], this.wRetirementStudio.wPMTool_TreeView.tvTreeViewitem, "Click", 0);

                }
                _gLib._SetSyncUDWin("AddClient", this.wRetirementStudio.wPMTool_AddClient.btnAddClient, dic["AddClient"], 0);
                _gLib._SetSyncUDWin("DeleteClient", this.wRetirementStudio.wPMTool_DeleteClient.btnDeleteClient, dic["DeleteClient"], 0);
                _gLib._SetSyncUDWin("AddPlan", this.wRetirementStudio.wPMTool_AddPlan.btnAddPlan, dic["AddPlan"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("TypeClientName", this.wRetirementStudio.wPMTool_TypeClientName.txtTypeClientName, dic["TypeClientName"], 0);
                _gLib._VerifySyncUDWin("AddClient", this.wRetirementStudio.wPMTool_AddClient.btnAddClient, dic["AddClient"], 0);
                _gLib._VerifySyncUDWin("Title", this.wRetirementStudio.wPMTool_RightPane.txtTitle, dic["Title"], 0);
                _gLib._VerifySyncUDWin("DeleteClient", this.wRetirementStudio.wPMTool_DeleteClient.btnDeleteClient, dic["DeleteClient"], 0);
                _gLib._VerifySyncUDWin("AddPlan", this.wRetirementStudio.wPMTool_AddPlan.btnAddPlan, dic["AddPlan"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Apr-10 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Yes", "Click");
        ///    dic.Add("No", "");
        ///    pMain._PopVerify_DeleteClient(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DeleteClient(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_DeleteClient";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("Yes", this.wPMTool_DeleteClient.wYes.btnYes, dic["Yes"], 0);
                _gLib._SetSyncUDWin("No", this.wPMTool_DeleteClient.wNo.btnNo, dic["No"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Yes", this.wPMTool_DeleteClient.wYes.btnYes, dic["Yes"], 0);
                _gLib._VerifySyncUDWin("No", this.wPMTool_DeleteClient.wNo.btnNo, dic["No"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        public void _DeleteClientIfExists(string sClient, int iTimeout)
        {

            this._SelectTab("PM Tools");

            this.wRetirementStudio.wPMTool_TreeView.tvTreeViewitem.SearchProperties.Add(WinTreeItem.PropertyNames.Name, sClient);

            _gLib._SearchTimeout_SetNew(iTimeout);

            if (_gLib._Exists(sClient, this.wRetirementStudio.wPMTool_TreeView.tvTreeViewitem, iTimeout, false))
            {
                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("TypeClientName", sClient);
                dic.Add("TreeViewClientName", sClient);
                dic.Add("AddClient", "");
                dic.Add("Title", "");
                dic.Add("DeleteClient", "Click");
                dic.Add("AddPlan", "");
                this._PopVerify_PMTool(dic);

                dic.Clear();
                dic.Add("PopVerify", "Verify");
                dic.Add("TypeClientName", "");
                dic.Add("TreeViewClientName", "");
                dic.Add("AddClient", "");
                dic.Add("Title", "Client: " + sClient);
                dic.Add("DeleteClient", "");
                dic.Add("AddPlan", "");
                this._PopVerify_PMTool(dic);

                dic.Clear();
                dic.Add("PopVerify", "Pop");
                dic.Add("Yes", "Click");
                dic.Add("No", "");
                this._PopVerify_DeleteClient(dic);
            }

            _gLib._SearchTimeout_RestoreDefault();
        }


        /// <summary>
        /// 2013-Apr-10 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Country", "United States of America");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Cancel", "");
        ///    pMain._PopVerify_PMTool_CountrySelection(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PMTool_CountrySelection(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PMTool_CountrySelection";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("Country", this.wPMTool_CountrySelection.wCountry.cboCountry, dic["Country"], 0);
                _gLib._SetSyncUDWin("OK", this.wPMTool_CountrySelection.wOK.btnOK, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wPMTool_CountrySelection.wCancel.btnCancel, dic["Cancel"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Country", this.wPMTool_CountrySelection.wCountry.cboCountry, dic["Country"], 0);
                _gLib._VerifySyncUDWin("OK", this.wPMTool_CountrySelection.wOK.btnOK, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wPMTool_CountrySelection.wCancel.btnCancel, dic["Cancel"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Apr-10 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PlanName", "planABC");
        ///    dic.Add("PlanYearBegin", "01/01");
        ///    dic.Add("Jurisdiction", "Ontario");
        ///    dic.Add("RevCanadaRegistrationNum", "111111");
        ///    dic.Add("ProvincialRegistrationNum", "5555555");
        ///    dic.Add("Union", "");
        ///    dic.Add("NonUnion", "");
        ///    dic.Add("Salaried", "Click");
        ///    dic.Add("Hourly", "Click");
        ///    dic.Add("AdministrationPlan", "");
        ///    dic.Add("AllowDerivationVersion", "");
        ///    dic.Add("PublicSectorProjection", "");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_PMTool_Plan(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PMTool_Plan(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PMTool_Plan";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                //Main.wPMTool_Plan.wPublicScetorProjection.chk
                _gLib._SetSyncUDWin("PlanName", this.wPMTool_Plan.wPlanName.txtPlanName, dic["PlanName"], 0);
                _gLib._SetSyncUDWin("PlanYearBegin", this.wPMTool_Plan.wPlanYearBegin.txtPlanYearBegin, dic["PlanYearBegin"], 0);
                _gLib._SetSyncUDWin("Jurisdiction", this.wPMTool_Plan.wJurisdiction.cbo, dic["Jurisdiction"], 0);
                _gLib._SetSyncUDWin("RevCanadaRegistrationNum", this.wPMTool_Plan.wRevCanadaRegistrationNum.txt, dic["RevCanadaRegistrationNum"], 0);
                _gLib._SetSyncUDWin("ProvincialRegistrationNum", this.wPMTool_Plan.wProvincialRegistrationNum.txt, dic["ProvincialRegistrationNum"], 0);
                _gLib._SetSyncUDWin("Union", this.wPMTool_Plan.wGroupsCovered.liUnion, dic["Union"], 0);
                _gLib._SetSyncUDWin("NonUnion", this.wPMTool_Plan.wGroupsCovered.liNonUnion, dic["NonUnion"], 0);
                _gLib._SetSyncUDWin("Salaried", this.wPMTool_Plan.wGroupsCovered.liSalaried, dic["Salaried"], 0);
                _gLib._SetSyncUDWin("Hourly", this.wPMTool_Plan.wGroupsCovered.liHourly, dic["Hourly"], 0);
                _gLib._SetSyncUDWin("AdministrationPlan", this.wPMTool_PlanCanada.wAdministrationPlan.chk, dic["AdministrationPlan"], 0);
                _gLib._SetSyncUDWin("AllowDerivationVersion", this.wPMTool_PlanCanada.wAllowDerivationVersion.chk, dic["AllowDerivationVersion"], 0);
                _gLib._SetSyncUDWin("PublicSectorProjection", this.wPMTool_Plan.wPublicScetorProjection.chk, dic["PublicSectorProjection"], 0);

                _gLib._SetSyncUDWin("OK", this.wPMTool_Plan.wOK.btnOK, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("PlanName", this.wPMTool_Plan.wPlanName.txtPlanName, dic["PlanName"], 0);
                _gLib._VerifySyncUDWin("PlanYearBegin", this.wPMTool_Plan.wPlanYearBegin.txtPlanYearBegin, dic["PlanYearBegin"], 0);
                _gLib._VerifySyncUDWin("Jurisdiction", this.wPMTool_Plan.wJurisdiction.cbo, dic["Jurisdiction"], 0);
                _gLib._VerifySyncUDWin("RevCanadaRegistrationNum", this.wPMTool_Plan.wRevCanadaRegistrationNum.txt, dic["RevCanadaRegistrationNum"], 0);
                _gLib._VerifySyncUDWin("ProvincialRegistrationNum", this.wPMTool_Plan.wProvincialRegistrationNum.txt, dic["ProvincialRegistrationNum"], 0);
                _gLib._VerifySyncUDWin("Union", this.wPMTool_Plan.wGroupsCovered.liUnion, dic["Union"], 0);
                _gLib._VerifySyncUDWin("NonUnion", this.wPMTool_Plan.wGroupsCovered.liNonUnion, dic["NonUnion"], 0);
                _gLib._VerifySyncUDWin("Salaried", this.wPMTool_Plan.wGroupsCovered.liSalaried, dic["Salaried"], 0);
                _gLib._VerifySyncUDWin("Hourly", this.wPMTool_Plan.wGroupsCovered.liHourly, dic["Hourly"], 0);
                _gLib._VerifySyncUDWin("AdministrationPlan", this.wPMTool_PlanCanada.wAdministrationPlan.chk, dic["AdministrationPlan"], 0);
                _gLib._VerifySyncUDWin("AllowDerivationVersion", this.wPMTool_PlanCanada.wAllowDerivationVersion.chk, dic["AllowDerivationVersion"], 0);

                _gLib._VerifySyncUDWin("OK", this.wPMTool_Plan.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-June-10 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PlanName", Config.sPlanName);
        ///    dic.Add("PlanYearBegin", "01/01");
        ///    dic.Add("PSOReferenceNumber", "123456");
        ///    dic.Add("SCON", "654321");
        ///    dic.Add("TaxRegistrationStatus", "");
        ///    dic.Add("FRS17", "True");
        ///    dic.Add("FAS87", "True");
        ///    dic.Add("IAS19", "True");
        ///    dic.Add("Works", "True");
        ///    dic.Add("Staff", "True");
        ///    dic.Add("Execs", "True");
        ///    dic.Add("PublicSectorProjection", "");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_PMTool_Plan_UK(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PMTool_Plan_UK(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PMTool_Plan_UK";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("PlanName", this.wPMTool_Plan.wPlanName.txtPlanName, dic["PlanName"], 0);
                _gLib._SetSyncUDWin("PlanYearBegin", this.wPMTool_Plan.wPlanYearBegin.txtPlanYearBegin_UK, dic["PlanYearBegin"], 0);
                _gLib._SetSyncUDWin("PSOReferenceNumber", this.wPMTool_Plan_UK.wPSOReferenceNumber.txt, dic["PSOReferenceNumber"], 0);
                _gLib._SetSyncUDWin("SCON", this.wPMTool_Plan_UK.wSCON.txt, dic["SCON"], 0);
                _gLib._SetSyncUDWin("TaxRegistrationStatus", this.wPMTool_Plan_UK.wTaxRegistrationStatus.cbo, dic["TaxRegistrationStatus"], 0);
                _gLib._SetSyncUDWin("FRS17", this.wPMTool_Plan_UK.wFRS17.chk, dic["FRS17"], 0);
                _gLib._SetSyncUDWin("FAS87", this.wPMTool_Plan_UK.wFAS87.chk, dic["FAS87"], 0);
                _gLib._SetSyncUDWin("IAS19", this.wPMTool_Plan_UK.wIAS19.chk, dic["IAS19"], 0);
                _gLib._SetSyncUDWin("Works", this.wPMTool_Plan_UK.wWorks.chk, dic["Works"], 0);
                _gLib._SetSyncUDWin("Staff", this.wPMTool_Plan_UK.wStaff.chk, dic["Staff"], 0);
                _gLib._SetSyncUDWin("Execs", this.wPMTool_Plan_UK.wExecs.chk, dic["Execs"], 0);
                _gLib._SetSyncUDWin("PublicSectorProjection", this.wPMTool_Plan_UK.wPublicSectorProjection.chk, dic["PublicSectorProjection"], 0);

                _gLib._SetSyncUDWin("OK", this.wPMTool_Plan.wOK.btnOK, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("PlanName", this.wPMTool_Plan.wPlanName.txtPlanName, dic["PlanName"], 0);
                _gLib._VerifySyncUDWin("PlanYearBegin", this.wPMTool_Plan.wPlanYearBegin.txtPlanYearBegin_UK, dic["PlanYearBegin"], 0);
                _gLib._VerifySyncUDWin("PSOReferenceNumber", this.wPMTool_Plan_UK.wPSOReferenceNumber.txt, dic["PSOReferenceNumber"], 0);
                _gLib._VerifySyncUDWin("SCON", this.wPMTool_Plan_UK.wSCON.txt, dic["SCON"], 0);
                _gLib._VerifySyncUDWin("TaxRegistrationStatus", this.wPMTool_Plan_UK.wTaxRegistrationStatus.cbo, dic["TaxRegistrationStatus"], 0);
                _gLib._VerifySyncUDWin("FRS17", this.wPMTool_Plan_UK.wFRS17.chk, dic["FRS17"], 0);
                _gLib._VerifySyncUDWin("FAS87", this.wPMTool_Plan_UK.wFAS87.chk, dic["FAS87"], 0);
                _gLib._VerifySyncUDWin("IAS19", this.wPMTool_Plan_UK.wIAS19.chk, dic["IAS19"], 0);
                _gLib._VerifySyncUDWin("Works", this.wPMTool_Plan_UK.wWorks.chk, dic["Works"], 0);
                _gLib._VerifySyncUDWin("Staff", this.wPMTool_Plan_UK.wStaff.chk, dic["Staff"], 0);
                _gLib._VerifySyncUDWin("Execs", this.wPMTool_Plan_UK.wExecs.chk, dic["Execs"], 0);
                _gLib._VerifySyncUDWin("PublicSectorProjection", this.wPMTool_Plan_UK.wPublicSectorProjection.chk, dic["PublicSectorProjection"], 0);

                _gLib._VerifySyncUDWin("OK", this.wPMTool_Plan.wOK.btnOK, dic["OK"], 0);
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
        ///    dic.Add("Name", "Conversion 2010");
        ///    dic.Add("EffectiveDate", "01/01/2010");
        ///    dic.Add("PlanYearEndIn", "");
        ///    dic.Add("Parent", "");
        ///    dic.Add("RSC", "True");
        ///    dic.Add("LocalMarket", "");
        ///    dic.Add("Shared", "");
        ///    dic.Add("GeneralUse", "");
        ///    dic.Add("Conversion", "True");
        ///    dic.Add("CopyDataService", "");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Cancel", "");
        ///    pMain._PopVerify_Home_DataServicePropeties(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Home_DataServicePropeties(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Home_DataServicePropeties";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("Name", this.wHome_DataServiceProperties.wName.txtName, dic["Name"], 0);
                _gLib._SetSyncUDWin("EffectiveDate", this.wHome_DataServiceProperties.wEffectiveDate.txtEffectiveDate, dic["EffectiveDate"], 0);
                _gLib._SetSyncUDWin("Parent", this.wHome_DataServiceProperties.wParent.cboParent, dic["Parent"], 0);
                _gLib._SetSyncUDWin("RSC", this.wHome_DataServiceProperties.wRSC.rdRSC, dic["RSC"], 0);
                _gLib._SetSyncUDWin("LocalMarket", this.wHome_DataServiceProperties.wLocalMarket.rd, dic["LocalMarket"], 0);
                _gLib._SetSyncUDWin("Shared", this.wHome_DataServiceProperties.wShared.rdShared, dic["Shared"], 0);
                _gLib._SetSyncUDWin("GeneralUse", this.wHome_DataServiceProperties.wGeneralUse.rdGeneralUse, dic["GeneralUse"], 0);
                _gLib._SetSyncUDWin("Conversion", this.wHome_DataServiceProperties.wConversion.rdConversion, dic["Conversion"], 0);
                _gLib._SetSyncUDWin("CopyDataService", this.wHome_DataServiceProperties.wCopyDataService.btnCopyDataService, dic["CopyDataService"], 0);
                _gLib._SetSyncUDWin("OK", this.wHome_DataServiceProperties.wOK.btnOK, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wHome_DataServiceProperties.wCancel.btnCancel, dic["Cancel"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Name", this.wHome_DataServiceProperties.wName.txtName, dic["Name"], 0);
                _gLib._VerifySyncUDWin("EffectiveDate", this.wHome_DataServiceProperties.wEffectiveDate.txtEffectiveDate, dic["EffectiveDate"], 0);
                _gLib._VerifySyncUDWin("Parent", this.wHome_DataServiceProperties.wParent.cboParent, dic["Parent"], 0);
                _gLib._VerifySyncUDWin("RSC", this.wHome_DataServiceProperties.wRSC.rdRSC, dic["RSC"], 0);
                _gLib._VerifySyncUDWin("Shared", this.wHome_DataServiceProperties.wShared.rdShared, dic["Shared"], 0);
                _gLib._VerifySyncUDWin("GeneralUse", this.wHome_DataServiceProperties.wGeneralUse.rdGeneralUse, dic["GeneralUse"], 0);
                _gLib._VerifySyncUDWin("Conversion", this.wHome_DataServiceProperties.wConversion.rdConversion, dic["Conversion"], 0);
                _gLib._VerifySyncUDWin("CopyDataService", this.wHome_DataServiceProperties.wCopyDataService.btnCopyDataService, dic["CopyDataService"], 0);
                _gLib._VerifySyncUDWin("OK", this.wHome_DataServiceProperties.wOK.btnOK, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wHome_DataServiceProperties.wCancel.btnCancel, dic["Cancel"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-Apr-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AddServiceInstance", "");
        ///    dic.Add("AddVOtoRegistry", "");
        ///    dic.Add("ServiceToOpen", "Data 2011");
        ///    dic.Add("CheckPopup", "False");
        ///    pMain._PopVerify_Home_RightPane(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Home_RightPane(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_Home_RightPane";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("AddServiceInstance", this.wRetirementStudio.wHome_AddServiceInstance.btnAddServiceInstance, dic["AddServiceInstance"], 0);
                _gLib._SetSyncUDWin("AddVOtoRegistry", this.wRetirementStudio.wAddVOtoRegistry.btn, dic["AddVOtoRegistry"], 0);

                if (dic["ServiceToOpen"] != "")
                {
                    Boolean bServiceSelected = false;

                    int ixPos = 80;
                    int iyPos = 30;
                    int iyStep = 20;

                    for (int i = 1; i <= 6; i++)
                    {


                        this._SelectTab("Home");
                        ////////////_gLib._SetSyncUDWin("Home - Right Pane", this.wRetirementStudio.wHome_TableView.cHome_TableView, "Click", 0, false, ixPos, iyPos + iyStep * (i - 1));


                        #region check service note to identify the expected server to open
                        try
                        {
                            Mouse.Click(this.wRetirementStudio.wHome_TableView.cHome_TableView, MouseButtons.Right, ModifierKeys.None, new Point(ixPos, iyPos + iyStep * (i - 1)));
                        }
                        catch (Exception ex)
                        {
                            _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to Right click on <Home Service Pane>. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                            _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right click on <Home Service Pane>. Because of Exception thrown: " + Environment.NewLine + ex.Message);
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
                            dicTmp.Add("Level_1", "Service Notes");
                            _gLib._MenuSelectWin(0, wWin, dicTmp);

                        }
                        else
                        {
                            _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because context menu does NOT exist");
                            _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because context menu does NOT exist");
                        }


                        string sInfo = this.wHome_ServiceNotes.wServiceInfo.txt.GetProperty("Name").ToString();
                        _gLib._SetSyncUDWin("ServiceNotes", this.wHome_ServiceNotes.wCancel.btn, "Click", 0);
                        if (sInfo.Contains(">>" + dic["ServiceToOpen"]))
                            _gLib._SetSyncUDWin("Home - Right Pane", this.wRetirementStudio.wHome_TableView.cHome_TableView, "Click", 0, false, ixPos, iyPos + iyStep * (i - 1));
                        else
                            continue;


                        #endregion




                        if (dic["CheckPopup"].ToUpper() != "FALSE")
                        {
                            if (_gLib._Exists("Parent Node PFVS Modified", this.wParentNodePFVSModified, 1, false))
                                _gLib._SetSyncUDWin("Parent Node PFVS Modified", this.wParentNodePFVSModified.wOK.btnOK, "Click", 0);

                            if (_gLib._Exists("Confirm", this.wHome_Confirm, 2, false))
                            {
                                MyDictionary dicTmp = new MyDictionary();
                                dicTmp.Clear();
                                dicTmp.Add("PopVerify", "Pop");
                                dicTmp.Add("Yes", "");
                                dicTmp.Add("No", "Click");
                                this._PopVerify_Home_Confrim(dicTmp);
                            }

                            if (_gLib._Exists("Snapshot Republished", this.wSnapshotRepublished, 1, false))
                            {
                                _gLib._SetSyncUDWin("", this.wSnapshotRepublished.wOK.btnOK, "Click", 0);
                            }
                        }

                        this._SelectTab("Home");

                        WinTabPage wTP = new WinTabPage(this.wRetirementStudio.wHome_Tab);
                        wTP.SearchProperties.Add(WinTabPage.PropertyNames.Name, dic["ServiceToOpen"]);

                        if (_gLib._Exists(dic["ServiceToOpen"], wTP, 3, false))
                        {
                            //_gLib._TabPageSelectWin(dic["ServiceToOpen"], this.wRetirementStudio.wHome_ServiceTab, 0);
                            ////////////Mouse.Click(wTP, new Point(Config.iClickPos_X, Config.iClickPos_Y));
                            _gLib._SetSyncUDWin("Tab", wTP, "Click", 0, false, Config.iClickPos_X, Config.iClickPos_Y);
                            bServiceSelected = true;
                            break;
                        }
                    }

                    if (!bServiceSelected)
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  open service  <" + dic["ServiceToOpen"] + ">. Please check input name!");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to open service <" + dic["ServiceToOpen"] + ">. Please check input name!");
                        return;
                    }
                }
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("AddServiceInstance", this.wRetirementStudio.wHome_AddServiceInstance.btnAddServiceInstance, dic["AddServiceInstance"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2015-Aug-10 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_DeleteValuationNode(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_DeleteValuationNode(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_DeleteValuationNode";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("OK", this.wDeleteValuationNode.wOK.btn, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wDeleteValuationNode.wOK.btn, dic["OK"], 0);

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
        ///    dic.Add("Yes", "Click");
        ///    dic.Add("No", "");
        ///    dic.Add("Message", "");
        ///    dic.Add("OK", "");
        ///    pMain._PopVerify_Home_Confrim(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("Yes", "");
        ///    dic.Add("No", "");
        ///    dic.Add("Message", "ASC 960 reconciliation run completed.");
        ///    dic.Add("OK", "");
        ///    pMain._PopVerify_Home_Confrim(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Home_Confrim(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Home_Confrim";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Yes", this.wHome_Confirm.wYes.btnYes, dic["Yes"], 0);
                _gLib._SetSyncUDWin("No", this.wHome_Confirm.wNo.btnNo, dic["No"], 0);
                _gLib._SetSyncUDWin("OK", this.wHome_Confirm.wOK.btnOK, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Yes", this.wHome_Confirm.wYes.btnYes, dic["Yes"], 0);
                _gLib._VerifySyncUDWin("No", this.wHome_Confirm.wNo.btnNo, dic["No"], 0);
                _gLib._VerifySyncUDWin("Message", this.wHome_Confirm.wMessage.txtMessage, dic["Message"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        public void _Home_ToolbarClick_Top(Boolean bSaveTure_CloseFalse)
        {
            string sFunctionName = "_Home_ToolbarClick_Top";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (bSaveTure_CloseFalse)
                _gLib._SetSyncUDWin("Save", this.wRetirementStudio.wHome_ToolBar_Top.btnSave, "Click", 0);
            else
            {
                _gLib._SetSyncUDWin("Close", this.wRetirementStudio.wHome_ToolBar_Top.btnClose, "Click", Config.iTimeout * 5);
                if (_gLib._Exists("Confirm Save", this.wHome_Confirm, 1, false))
                    _gLib._SetSyncUDWin("Yes", this.wHome_Confirm.wYes.btnYes, "Click", 0);
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
        ///    dic.Add("FileName", @"c:\test.xls");
        ///    dic.Add("Open", "Click");
        ///    dic.Add("Cancel", "");
        ///    pMain._PopVerify_FileOpen(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_FileOpen(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FileOpen";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                //_gLib._SetSyncUDWin("FileName", this.wFileOpen.wFileName.txtFileName, dic["FileName"], 0);
                _gLib._SetSyncUDWin_ByClipboard("FileName", this.wFileOpen.wFileName.txtFileName, dic["FileName"], 0);
                //////_gLib._SetSyncUDWin("Open", this.wFileOpen.wOpen.btnOpen, dic["Open"], 0);

                if (dic["Open"] != "")
                {
                    _gLib._SendKeysUDWin("btnOpen", this.wFileOpen, "O", 0, ModifierKeys.Alt, false);
                    for (int i = 0; i < Config.iTimeout / 2; i++)
                    {
                        if (_gLib._Exists("File Open Dialog", this.wFileOpen, 1, false))
                            _gLib._Wait(1);
                        else
                            break;
                    }
                }
                _gLib._SetSyncUDWin("Cancel", this.wFileOpen.wCancel.btnCancel, dic["Cancel"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("FileName", this.wFileOpen.wFileName.txtFileName, dic["FileName"], 0);
                _gLib._VerifySyncUDWin("Open", this.wFileOpen.wOpen.btnOpen, dic["Open"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wFileOpen.wCancel.btnCancel, dic["Cancel"], 0);
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
        ///    dic.Add("Cancel", "");
        ///    pMain._PopVerify_GRSLogin(dic); 
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
                _gLib._SetSyncUDWin("Cancel", this.wGRSLogin.wCancel.btnCancel, dic["Cancel"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("cboGRSServer", this.wGRSLogin.wGRSServer.cboGRSServer, dic["cboGRSServer"], 0);
                _gLib._VerifySyncUDWin("LoginID", this.wGRSLogin.wLoginID.txtLoginID, dic["LoginID"], 0);
                _gLib._VerifySyncUDWin("Password", this.wGRSLogin.wPassword.txtPassword, dic["Password"], 0);
                _gLib._VerifySyncUDWin("OK", this.wGRSLogin.wOK.btnOK, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wGRSLogin.wCancel.btnCancel, dic["Cancel"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-Apr-24 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "GRS Clients");
        ///    dic.Add("Level_2", "L281 - QA US Benchmark 008 Data Source");
        ///    dic.Add("Level_3", "QA US Benchmark 008 Data Plan");
        ///    dic.Add("Level_4", "Data for Retirement Studio");
        ///    dic.Add("Level_5", "Update Data to 2010");
        ///    dic.Add("Level_6", "Unload for 2010 Data Conversion");
        ///    pMain._GRSDataInput_TreeViewSelect(0, dic);
        /// 
        /// </summary>
        /// <param name="iSearchTimeout"></param>
        /// <param name="dic"></param>
        public void _GRSDataInput_TreeViewSelect(int iSearchTimeout, MyDictionary dic)
        {
            string sFunctionName = "_GRSDataInput_TreeViewSelect";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewSelectWin(iSearchTimeout, this.wGRSDataInput.tvGRSClient, dic);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-Apr-24 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Cancel", "");
        ///    pMain._PopVerify_GRSDataInput(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GRSDataInput(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GRSDataInput";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("OK", this.wGRSDataInput.wOK.btnOK, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wGRSDataInput.wCancel.btnCancel, dic["Cancel"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("OK", this.wGRSDataInput.wOK.btnOK, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wGRSDataInput.wCancel.btnCancel, dic["Cancel"], 0);
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
        ///    dic.Add("ConversionService", "True");
        ///    dic.Add("Name", "");
        ///    dic.Add("Parent", "");
        ///    dic.Add("ParentFinalValuationSet", "");
        ///    dic.Add("PlanYearBeginningIn", "");
        ///    dic.Add("FiscalYearEndingIn_Accounting", "");   
        ///    dic.Add("FirstYearPlanUnderPPA", "");
        ///    dic.Add("PlanYearEndingIn_DE", "");
        ///    dic.Add("RSC", "True");
        ///    dic.Add("LocalMarket", "");
        ///    dic.Add("Shared", "");
        ///    dic.Add("SelectAllVO", "");
        ///    dic.Add("DeselectAll", "");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Cancel", "");
        ///    dic.Add("Check_FundingCalculatorNotRunComplete", "False");
        ///    pMain._PopVerify_Home_ServicePropeties(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Home_ServicePropeties(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Home_ServicePropeties";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ConversionService", this.wHome_ServiceProperties.wConversionService.chkConversionService, dic["ConversionService"], 0);
                _gLib._SetSyncUDWin("Name", this.wHome_ServiceProperties.wName.txtName, dic["Name"], 0);
                _gLib._SetSyncUDWin("Parent", this.wHome_ServiceProperties.wParent.cboParent, dic["Parent"], 0);
                _gLib._SetSyncUDWin("ParentFinalValuationSet", this.wHome_ServiceProperties.wParentFinalValuationSet.cboParentFinalValuationSet, dic["ParentFinalValuationSet"], 0);
                _gLib._SetSyncUDWin("PlanYearBeginningIn", this.wHome_ServiceProperties.wPlanYearBeginingIn.cboPlanYearBeginningIn, dic["PlanYearBeginningIn"], 0);
                _gLib._SetSyncUDWin("FiscalYearEndingIn_Accounting", this.wHome_ServiceProperties.wPlanYearBeginingIn.cboFiscalYearEndingIn_Accounting, dic["FiscalYearEndingIn_Accounting"], 0);
                _gLib._SetSyncUDWin("PlanYearEndingIn_DE", this.wHome_ServiceProperties.wPlanYearBeginingIn.cboPlanYearEndingIn_DE_Jubi, dic["PlanYearEndingIn_DE"], 0);
                _gLib._SetSyncUDWin("FirstYearPlanUnderPPA", this.wHome_ServiceProperties.wFirstPlanYearUnderPPA.cboFirstYearPlanUnderPPA, dic["FirstYearPlanUnderPPA"], 0);
                _gLib._SetSyncUDWin("RSC", this.wHome_ServiceProperties.wRSC.rdRSC, dic["RSC"], 0);
                _gLib._SetSyncUDWin("LocalMarket", this.wHome_ServiceProperties.wLocalMarket.rdLocalMarket, dic["LocalMarket"], 0);
                _gLib._SetSyncUDWin("Shared", this.wHome_ServiceProperties.wShared.rdShared, dic["Shared"], 0);
                _gLib._SetSyncUDWin("SelectAllVO", this.wHome_ServiceProperties.wSelectAllVO.btn, dic["SelectAllVO"], 0);
                _gLib._SetSyncUDWin("DeselectAll", this.wHome_ServiceProperties.wDeselectAll.btn, dic["DeselectAll"], 0);
                _gLib._SetSyncUDWin("OK", this.wHome_ServiceProperties.wOK.btnOK, dic["OK"], 0);

                bool bCheck_FundingCalculatorNotRunComplete = false;

                if (dic["Check_FundingCalculatorNotRunComplete"].ToUpper() != "FALSE")
                    bCheck_FundingCalculatorNotRunComplete = true;

                if (bCheck_FundingCalculatorNotRunComplete)
                    if (_gLib._Enabled("FundingCalculatorNotRunComplete_OK", this.wWord_Popup.wOK.btnOK, 1, false))
                        _gLib._SetSyncUDWin("FundingCalculatorNotRunComplete_OK", this.wWord_Popup.wOK.btnOK, "click", 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("ConversionService", this.wHome_ServiceProperties.wConversionService.chkConversionService, dic["ConversionService"], 0);
                _gLib._VerifySyncUDWin("Name", this.wHome_ServiceProperties.wName.txtName, dic["Name"], 0);
                _gLib._VerifySyncUDWin("Parent", this.wHome_ServiceProperties.wParent.cboParent, dic["Parent"], 0);
                _gLib._VerifySyncUDWin("ParentFinalValuationSet", this.wHome_ServiceProperties.wParentFinalValuationSet.cboParentFinalValuationSet, dic["ParentFinalValuationSet"], 0);
                _gLib._VerifySyncUDWin("PlanYearBeginningIn", this.wHome_ServiceProperties.wPlanYearBeginingIn.cboPlanYearBeginningIn, dic["PlanYearBeginningIn"], 0);
                _gLib._VerifySyncUDWin("FiscalYearEndingIn_Accounting", this.wHome_ServiceProperties.wPlanYearBeginingIn.cboFiscalYearEndingIn_Accounting, dic["FiscalYearEndingIn_Accounting"], 0);
                _gLib._VerifySyncUDWin("FirstYearPlanUnderPPA", this.wHome_ServiceProperties.wFirstPlanYearUnderPPA.cboFirstYearPlanUnderPPA, dic["FirstYearPlanUnderPPA"], 0);
                _gLib._VerifySyncUDWin("PlanYearEndingIn_DE", this.wHome_ServiceProperties.wPlanYearBeginingIn.cboPlanYearEndingIn_DE_Jubi, dic["PlanYearEndingIn_DE"], 0);
                _gLib._VerifySyncUDWin("RSC", this.wHome_ServiceProperties.wRSC.rdRSC, dic["RSC"], 0);
                _gLib._VerifySyncUDWin("LocalMarket", this.wHome_ServiceProperties.wLocalMarket.rdLocalMarket, dic["LocalMarket"], 0);
                _gLib._VerifySyncUDWin("Shared", this.wHome_ServiceProperties.wShared.rdShared, dic["Shared"], 0);
                _gLib._VerifySyncUDWin("SelectAllVO", this.wHome_ServiceProperties.wSelectAllVO.btn, dic["wSelectAllVOSelectAllVO"], 0);
                _gLib._VerifySyncUDWin("DeselectAll", this.wHome_ServiceProperties.wDeselectAll.btn, dic["DeselectAll"], 0);
                _gLib._VerifySyncUDWin("OK", this.wHome_ServiceProperties.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        ////public void _FlowTreeInitialize()
        ////{

        ////    _gLib._MsgBox("Need Manual Iteraction", "Please expand the Flow Tree window to make it wide enough for all Nodes visible!");

        ////    ////Mouse.StartDragging(this.wRetirementStudio.wFlowTreeWin.wWin, new Point(-1, 233));
        ////    ////Mouse.StopDragging(this.wRetirementStudio.wFlowTreeWin.wWin, 491, 24);
        ////}



        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iMaxRowNum", "");
        ///    dic.Add("iMaxColNum", "");
        ///    dic.Add("iSelectRowNum", "1");
        ///    dic.Add("iSelectColNum", "1");
        ///    dic.Add("MenuItem_1", "View Run Status");
        ///    dic.Add("MenuItem_2", "");
        ///    pMain._FlowTreeRightSelect(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("iMaxRowNum", "");
        ///    dic.Add("iMaxColNum", "");
        ///    dic.Add("iSelectRowNum", "1");
        ///    dic.Add("iSelectColNum", "1");
        ///    dic.Add("MenuItem_1", "Data");
        ///    dic.Add("MenuItem_2", "Edit Parameters");
        ///    pMain._FlowTreeRightSelect(dic); 
        ///    
        ///    
        ///    dic.Clear();
        ///    dic.Add("iMaxRowNum", "");
        ///    dic.Add("iMaxColNum", "");
        ///    dic.Add("iSelectRowNum", "");
        ///    dic.Add("iSelectColNum", "");
        ///    dic.Add("iPosX", "404");
        ///    dic.Add("iPosY", "95");
        ///    dic.Add("MenuItem_1", "Data");
        ///    dic.Add("MenuItem_2", "Edit Parameters");
        ///    dic.Add("CheckOMSetupPopup", "False");
        ///    pMain._FlowTreeRightSelect(dic); 
        /// 
        ///    dic.Clear();
        ///    dic.Add("iMaxRowNum", "");
        ///    dic.Add("iMaxColNum", "");
        ///    dic.Add("iSelectRowNum", "");
        ///    dic.Add("iSelectColNum", "");
        ///    dic.Add("iPosX", sPosX_Valuation2012_MethodScreenChange);
        ///    dic.Add("iPosY", sPosY_Valuation2012_MethodScreenChange);
        ///    dic.Add("MenuItem_1", "Run");
        ///    dic.Add("MenuItem_2", "Future Valuation Population Projection");
        ///    dic.Add("FVPopulationProjectionRunOption_Pop", "true");
        ///    pMain._FlowTreeRightSelect(dic);
        ///    
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _FlowTreeRightSelect(MyDictionary dic)
        {
            string sFunctionName = "_Home_FlowTreeRightSelect";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            int iMaxRowNum = 0;
            int iMaxColNum = 0;
            int iSelectRowNum = 0;
            int iSelectColNum = 0;

            int iStartX = 0;
            int iEndX = 0;
            int iStartY = 0;
            int iStepY = 0;
            int iEndY = 0;
            int iPosX = 0;
            int iPosY = 0;


            if ((dic["iPosX"] != "") && (dic["iPosY"] != ""))  // user input position
            {
                iPosX = Convert.ToInt32(dic["iPosX"]);
                iPosY = Convert.ToInt32(dic["iPosY"]);
            }
            else // code calculate position using row/column index, but only support 2 columns max
            {

                iSelectRowNum = Convert.ToInt32(dic["iSelectRowNum"]);
                iSelectColNum = Convert.ToInt32(dic["iSelectColNum"]);

                if (dic["iMaxRowNum"] != "") iMaxRowNum = Convert.ToInt32(dic["iMaxRowNum"]);
                if (dic["iMaxColNum"] != "") iMaxColNum = Convert.ToInt32(dic["iMaxColNum"]);


                if ((iMaxColNum == 0) || (iMaxColNum == 1)) // only one column 
                {
                    iStartX = 115;
                    iEndX = 225;
                }
                else // multiple columns
                {
                    if (iMaxColNum == 2)
                    {
                        if (iSelectColNum == 1) // select column 1
                        {
                            iStartX = 58;
                            iEndX = 168;
                        }
                        if (iSelectColNum == 2) // select column 2
                        {
                            iStartX = 228;
                            iEndX = 338;
                        }
                    }

                }

                iStartY = 20;
                iStepY = 22 + 35; // 35 is the hight of one node, 22 is the space between two nodes
                iEndY = iStartY + iStepY * (iSelectRowNum - 1);
                iPosX = iStartX + (iEndX - iStartX) / 2;
                iPosY = iEndY + 35 / 2;


            }


            int iFlowTreeWinMax = this.wRetirementStudio.wFlowTree.flowTree.BoundingRectangle.Width;

            if (iPosX > iFlowTreeWinMax)
                _gLib._MsgBox("Need Manual Iteraction", "Code detect the given X Postion <" + iPosX + "> exceeds the Flow Tree Window width <" + iFlowTreeWinMax + ">. Please expand the Flow Tree window to make it wide enough for all Nodes visible!");

            //////_gLib._Enabled("Flow Tree", this.wRetirementStudio.wFlowTree.flowTree, Config.iTimeout);
            //////Mouse.Click(this.wRetirementStudio.wFlowTree.flowTree, MouseButtons.Left, ModifierKeys.None, new Point(iPosX, iPosY));
            _gLib._SetSyncUDWin("Flow Tree", this.wRetirementStudio.wFlowTree.flowTree, "Click", Config.iTimeout, false, iPosX, iPosY);

            try
            {
                Mouse.Click(this.wRetirementStudio.wFlowTree.flowTree, MouseButtons.Right, ModifierKeys.None, new Point(iPosX, iPosY));
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
            dicTmp.Add("Level_1", dic["MenuItem_1"]);
            if (dic["MenuItem_2"] != "")
                dicTmp.Add("Level_2", dic["MenuItem_2"]);
            _gLib._MenuSelectWin(0, wWin, dicTmp);


            if (dic["MenuItem_1"] == "View Output")
            {
                OutputManager pOutputManager = new OutputManager();

                if (dic["CheckOMSetupPopup"].ToUpper() != "FALSE")
                {
                    if (_gLib._Exists("Output Manager Setup", pOutputManager.wOutputManagerSetup, 10, false))
                    {
                        if (_gLib._Enabled("Add All", pOutputManager.wOutputManagerSetup.wAddAll, 1, false))
                            _gLib._SetSyncUDWin("Add All", pOutputManager.wOutputManagerSetup.wAddAll.btnAddAll, "Click", 0);
                        _gLib._SetSyncUDWin("OK", pOutputManager.wOutputManagerSetup.wOK.btnOK, "Click", 0);
                    }
                }

            }






            if (dic["MenuItem_2"] == "Future Valuation Population Projection")
            {
                if (dic["FVPopulationProjectionRunOption_Pop"].ToUpper() == "TRUE")
                    _gLib._SetSyncUDWin("RunFVPopulationProjection", this.wFVPopulationProjectRunOption.runFVPP.btn, "Click", 0);
                else
                    _gLib._SetSyncUDWin("Future Val Submission - OK", this.wFutureValSubmission.wOK.btn, "Click", 0);
            }




            ////if (_gLib._Exists("Flow Tree Context Menu", wWin, 0, true)) // check MenuItem parent exists or not
            ////{

            ////    WinMenuItem mi_1 = new WinMenuItem(wWin);
            ////    mi_1.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
            ////    mi_1.SearchProperties.Add(WinMenuItem.PropertyNames.Name, dic["MenuItem_1"]);

            ////    _gLib._SetSyncUDWin("MenuItem: " + dic["MenuItem_1"], mi_1, "Click", 0);


            ////    if (dic["MenuItem_2"] != "")
            ////    {
            ////        WinMenuItem mi_2 = new WinMenuItem(mi_1);
            ////        mi_2.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
            ////        mi_2.SearchProperties.Add(WinMenuItem.PropertyNames.Name, dic["MenuItem_2"]);
            ////        _gLib._SetSyncUDWin("MenuItem: " + dic["MenuItem_2"], mi_2, "Click", 0);
            ////    }

            ////}

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }


        /// <summary>
        /// 2013-May-15 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("GL_GoingConcern", "");
        ///    dic.Add("GL_Solvency", "");
        ///    dic.Add("GL_WindUp", "");
        ///    dic.Add("Acc_GL_PBO", "");
        ///    dic.Add("Acc_GL_ABO", "");
        ///    dic.Add("GL_PPANAR_Min", "");
        ///    dic.Add("GL_PPANAR_Max", "");
        ///    dic.Add("GL_EAN", "");
        ///    dic.Add("EstimateNextYearLiabilityForAFTAP", "");
        ///    dic.Add("PayoutProjection", "True");
        ///    dic.Add("IncludeIOE", "True");
        ///    dic.Add("GenerateParameterPrint", "True");
        ///    dic.Add("GenerateTestCaseOutput", "True");
        ///    dic.Add("2DPayoutProjection", "");
        ///    dic.Add("GL_FundingLiabilities", "");
        ///    dic.Add("GL_Liabilities_Pension", "");
        ///    dic.Add("IncludeGainLossResult", "");
        ///    dic.Add("IncludeGainLossAgeGroupReportFields", "");
        ///    dic.Add("Service", "VestingService");
        ///    dic.Add("Pay", "PayProjection1");
        ///    dic.Add("CurrentYear", "");
        ///    dic.Add("PriorYear", "True");
        ///    dic.Add("CashBanlance", "AccruedBenefit1");
        ///    dic.Add("Pension", "BenefitInPayment");
        ///    dic.Add("AllLiabilityTypes", "");
        ///    dic.Add("GoingConcernLiability", "");
        ///    dic.Add("SolvencyLiability", "");
        ///    dic.Add("WindUpLiability", "");
        ///    dic.Add("PBGCPlanTermination", "");
        ///    dic.Add("PPANotAtRiskLiabilityForMinimum", "True");
        ///    dic.Add("PPANotAtRiskLiabilityForMaximum", "True");
        ///    dic.Add("PPANotAtRishPresentValueOfVestedBenefits", "True");
        ///    dic.Add("PBGCNotAtRiskPresentValueOfVestedBenefits", "True");
        ///    dic.Add("FAS35PresentValueOfAccumulatedBenefits", "True");
        ///    dic.Add("FAS35PresentValueOfVestedBenefits", "True");
        ///    dic.Add("PPAAtRiskLiabilityForMinimum", "False");
        ///    dic.Add("PPAAtRiskLiabilityForMaximum", "False");
        ///    dic.Add("PPAAtRiskPresentValueOfVestedBenefits", "False");
        ///    dic.Add("PBGCAtRiskPresentValueOfVestedBenefits", "False");
        ///    dic.Add("EntryAgeNormal", "False");
        ///    dic.Add("Nondiscrimination", "");
        ///    dic.Add("Acc_ProjectedBenefitObligation", "");
        ///    dic.Add("Acc_AccumulatedBenefitObligation", "");
        ///    dic.Add("PayoutProjectionCustomGroup", "HourlyFlag");
        ///    dic.Add("RunValuation", "Click");
        ///    dic.Add("OK", "");
        ///    pMain._PopVerify_RunOptions(dic); 
        ///    
        /// 
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("GL_GoingConcern", "");
        ///    dic.Add("PayoutProjection", "True");
        ///    dic.Add("IncludeIOE", "True");
        ///    dic.Add("GenerateParameterPrint", "True");
        ///    dic.Add("GenerateTestCaseOutput", "True");
        ///    dic.Add("IncludeGainLossResult", "");
        ///    dic.Add("CalcIncreCostSolvencyWindup", "");
        ///    dic.Add("Service", "Credited");
        ///    dic.Add("Pay", "ProjPay");
        ///    dic.Add("CurrentYear", "True");
        ///    dic.Add("PriorYear", "");
        ///    dic.Add("CashBanlance", "ContribsWInterest1");
        ///    dic.Add("Pension", "AccruedBenefit1");
        ///    dic.Add("AllLiabilityTypes", "");
        ///    dic.Add("GoingConcernLiability", "True");
        ///    dic.Add("SolvencyLiability", "True");
        ///    dic.Add("WindUpLiability", "True");
        ///    dic.Add("Acc_ProjectedBenefitObligation", "True");
        ///    dic.Add("Acc_AccumulatedBenefitObligation", "True");
        ///    dic.Add("PayoutProjectionCustomGroup", "");
        ///    dic.Add("RunValuation", "Click");
        ///    pMain._PopVerify_RunOptions(dic);
        /// 
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PayoutProjection", "True");
        ///    dic.Add("PayoutProjection_2DCashFlow", "True");
        ///    dic.Add("PayoutProjection_PayoutProjectionByParticpant", "True");
        ///    
        ///    dic.Add("ApplyWithdrawalAdjustment", "True");
        ///    dic.Add("IncludeIOE", "");
        ///    dic.Add("GenerateParameterPrint", "True");
        ///    dic.Add("GenerateTestCaseOutput", "True");
        ///    dic.Add("SaveResultsforAuditReport", "");
        ///    dic.Add("ApplyOverrides", "");
        ///    dic.Add("RunLocally", "");
        ///    dic.Add("Pay", "NetPayCurrentYear");
        ///    dic.Add("CurrentYear", "True");
        ///    dic.Add("PriorYear", "");
        ///    dic.Add("BreaksBasedOnData", "");
        ///    dic.Add("BreakByFundingVehicle", "False");
        ///    dic.Add("UseReportBreaks", "True");
        ///    dic.Add("AllLiabilityTypes", "");
        ///    dic.Add("Tax", "True");
        ///    dic.Add("Trade", "True");
        ///    dic.Add("AltTradeProjInt", "True");
        ///    dic.Add("InternationalAccountingABO", "True");
        ///    dic.Add("InternationalAccountingPBO", "True");
        ///    dic.Add("SelectVOs_AllVOs", "");
        ///    dic.Add("SelectVOs_VO1", "Pen1");
        ///    dic.Add("SelectVOs_VO2", "");
        ///    dic.Add("SelectVOs_VO3", "");
        ///    dic.Add("SelectVOs_VO4", "");
        ///    dic.Add("SelectVOs_VO5", "");
        ///    dic.Add("SelectVOs_VO6", "");
        ///    dic.Add("RunValuation", "Click");
        ///    pMain._PopVerify_RunOptions(dic);
        /// 
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PayoutProjection", "True");
        ///    dic.Add("ApplyWithdrawalAdjustment", "");
        ///    dic.Add("IncludeIOE", "True");
        ///    dic.Add("GenerateParameterPrint", "True");
        ///    dic.Add("GenerateTestCaseOutput", "True");
        ///    dic.Add("Pay", "NewPayProjection1");
        ///    dic.Add("CurrentYear", "True");
        ///    dic.Add("PriorYear", "");
        ///    dic.Add("PayoutProjectionCustomGroup", "#1#");
        ///    dic.Add("Major", "");
        ///    dic.Add("Intermediate", "");
        ///    dic.Add("Minor", "");
        ///    dic.Add("AllLiabilityTypes", "");
        ///    dic.Add("Funding", "True");
        ///    dic.Add("AltFunding1", "False");
        ///    dic.Add("AltFunding2", "False");
        ///    dic.Add("AltFunding3", "False");
        ///    dic.Add("Solvency", "True");
        ///    dic.Add("PPFS179", "True");
        ///    dic.Add("SelectVOs_AllVOs", "");
        ///    dic.Add("SelectVOs_VOOFF", "");
        ///    dic.Add("SelectVOs_VO1", "AllMembers");
        ///    dic.Add("SelectVOs_VO2", "");
        ///    dic.Add("SelectVOs_VO3", "");
        ///    dic.Add("SelectVOs_VO4", "");
        ///    dic.Add("SelectVOs_VOOFF", "");
        ///    dic.Add("SelectRecords", "");
        ///    dic.Add("SelectNodes", "");
        ///    dic.Add("Validate", "");
        ///    dic.Add("CheckPopup", "");
        ///    dic.Add("FC_IncludeSPC", "");
        ///    dic.Add("RunValuation", "Click");
        ///    pMain._PopVerify_RunOptions(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_RunOptions(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_RunOptions";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Boolean bCheckPopup = false;
            if (dic["CheckPopup"].ToUpper() == "TRUE")
                bCheckPopup = true;

            if (dic["PopVerify"] == "Pop")
            {

                /**
                 * liability type
                 */
                _gLib._SetSyncUDWin("AllLiabilityTypes", this.wRunOptions.wLiabilityTypes.chkAllLiabilityTypes, dic["AllLiabilityTypes"], 0);
                _gLib._SetSyncUDWin("GoingConcernLiability", this.wRunOptions.wLiabilityTypes.chkGoingConcernLiability, dic["GoingConcernLiability"], 0);
                _gLib._SetSyncUDWin("SolvencyLiability", this.wRunOptions.wLiabilityTypes.chkSolvencyLiability, dic["SolvencyLiability"], 0);
                _gLib._SetSyncUDWin("WindUpLiability", this.wRunOptions.wLiabilityTypes.chkWindUpLiability, dic["WindUpLiability"], 0);
                _gLib._SetSyncUDWin("PBGCPlanTermination", this.wRunOptions.wLiabilityTypes.chkPBGCPlanTermination, dic["PBGCPlanTermination"], 0);
                _gLib._SetSyncUDWin("PPANotAtRiskLiabilityForMinimum", this.wRunOptions.wLiabilityTypes.chkPPANotAtRiskLiabilityForMinimum, dic["PPANotAtRiskLiabilityForMinimum"], 0);
                _gLib._SetSyncUDWin("PPANotAtRiskLiabilityForMaximum", this.wRunOptions.wLiabilityTypes.chkPPANotAtRiskLiabilityForMaximum, dic["PPANotAtRiskLiabilityForMaximum"], 0);
                _gLib._SetSyncUDWin("PPANotAtRishPresentValueOfVestedBenefits", this.wRunOptions.wLiabilityTypes.chkPPANotAtRishPresentValueOfVestedBenefits, dic["PPANotAtRishPresentValueOfVestedBenefits"], 0);
                _gLib._SetSyncUDWin("PBGCNotAtRiskPresentValueOfVestedBenefits", this.wRunOptions.wLiabilityTypes.chkPBGCNotAtRiskPresentValueOfVestedBenefits, dic["PBGCNotAtRiskPresentValueOfVestedBenefits"], 0);
                _gLib._SetSyncUDWin("FAS35PresentValueOfAccumulatedBenefits", this.wRunOptions.wLiabilityTypes.chkFAS35PresentValueOfAccumulatedBenefits, dic["FAS35PresentValueOfAccumulatedBenefits"], 0);
                _gLib._SetSyncUDWin("FAS35PresentValueOfVestedBenefits", this.wRunOptions.wLiabilityTypes.chkFAS35PresentValueOfVestedBenefits, dic["FAS35PresentValueOfVestedBenefits"], 0);
                _gLib._SetSyncUDWin("PPAAtRiskLiabilityForMinimum", this.wRunOptions.wLiabilityTypes.chkPPAAtRiskLiabilityForMinimum, dic["PPAAtRiskLiabilityForMinimum"], 0);
                _gLib._SetSyncUDWin("PPAAtRiskLiabilityForMaximum", this.wRunOptions.wLiabilityTypes.chkPPAAtRiskLiabilityForMaximum, dic["PPAAtRiskLiabilityForMaximum"], 0);
                _gLib._SetSyncUDWin("PPAAtRiskPresentValueOfVestedBenefits", this.wRunOptions.wLiabilityTypes.chkPPAAtRiskPresentValueOfVestedBenefits, dic["PPAAtRiskPresentValueOfVestedBenefits"], 0);
                _gLib._SetSyncUDWin("PBGCAtRiskPresentValueOfVestedBenefits", this.wRunOptions.wLiabilityTypes.chkPBGCAtRiskPresentValueOfVestedBenefits, dic["PBGCAtRiskPresentValueOfVestedBenefits"], 0);
                _gLib._SetSyncUDWin("EntryAgeNormal", this.wRunOptions.wLiabilityTypes.chkEntryAgeNormal, dic["EntryAgeNormal"], 0);
                _gLib._SetSyncUDWin("Nondiscrimination", this.wRunOptions.wLiabilityTypes.chkNondiscrimination, dic["Nondiscrimination"], 0);
                _gLib._SetSyncUDWin("Acc_ProjectedBenefitObligation", this.wRunOptions.wLiabilityTypes.chkProjectedBenefitObligation, dic["Acc_ProjectedBenefitObligation"], 0);
                _gLib._SetSyncUDWin("Acc_AccumulatedBenefitObligation", this.wRunOptions.wLiabilityTypes.chkAccumulatedBenefitObligation, dic["Acc_AccumulatedBenefitObligation"], 0);
                _gLib._SetSyncUDWin("Tax", this.wRunOptions.wLiabilityTypes.chkTax, dic["Tax"], 0);
                _gLib._SetSyncUDWin("Trade", this.wRunOptions.wLiabilityTypes.chkTrade, dic["Trade"], 0);
                _gLib._SetSyncUDWin("AltTradeProjInt", this.wRunOptions.wLiabilityTypes.chkAltTradeProjIntCheck, dic["AltTradeProjInt"], 0);
                _gLib._SetSyncUDWin("InternationalAccountingABO", this.wRunOptions.wLiabilityTypes.chkInternationalAccountingABO, dic["InternationalAccountingABO"], 0);
                _gLib._SetSyncUDWin("InternationalAccountingPBO", this.wRunOptions.wLiabilityTypes.chkInternationalAccountingPBO, dic["InternationalAccountingPBO"], 0);
                _gLib._SetSyncUDWin("Funding", this.wRunOptions.wLiabilityTypes.chkFunding, dic["Funding"], 0);
                _gLib._SetSyncUDWin("AltFunding1", this.wRunOptions.wLiabilityTypes.chkAltFunding1, dic["AltFunding1"], 0);
                _gLib._SetSyncUDWin("AltFunding2", this.wRunOptions.wLiabilityTypes.chkAltFunding2, dic["AltFunding2"], 0);
                _gLib._SetSyncUDWin("AltFunding3", this.wRunOptions.wLiabilityTypes.chkAltFunding3, dic["AltFunding3"], 0);
                _gLib._SetSyncUDWin("Solvency", this.wRunOptions.wLiabilityTypes.chkSolvency, dic["Solvency"], 0);
                _gLib._SetSyncUDWin("PPFS179", this.wRunOptions.wLiabilityTypes.chkPPFS179, dic["PPFS179"], 0);


                /**
                 * options
                 */
                _gLib._SetSyncUDWin("GL_GoingConcern", this.wRunOptions.wGL_GoingConcern.chkGL_GoingConcern, dic["GL_GoingConcern"], 0);
                _gLib._SetSyncUDWin("GL_Solvency", this.wRunOptions.wGL_Solvency.chx, dic["GL_Solvency"], 0);
                _gLib._SetSyncUDWin("GL_WindUp", this.wRunOptions.wGL_WindUp.chk, dic["GL_WindUp"], 0);
                _gLib._SetSyncUDWin("Acc_GL_PBO", this.wRunOptions.wGL_PBO.chkGL_PBO, dic["Acc_GL_PBO"], 0);
                _gLib._SetSyncUDWin("Acc_GL_ABO", this.wRunOptions.wGL_ABO.chkGL_ABO, dic["Acc_GL_ABO"], 0);
                _gLib._SetSyncUDWin("GL_PPANAR_Min", this.wRunOptions.wGL_PPANAR_Min.chkGL_PPANAR_Min, dic["GL_PPANAR_Min"], 0);
                _gLib._SetSyncUDWin("GL_PPANAR_Max", this.wRunOptions.wGL_PPANAR_Max.chkGL_PPANAR_Max, dic["GL_PPANAR_Max"], 0);
                _gLib._SetSyncUDWin("GL_EAN", this.wRunOptions.wGL_EAN.chkGL_EAN, dic["GL_EAN"], 0);
                _gLib._SetSyncUDWin("EstimateNextYearLiabilityForAFTAP", this.wRunOptions.wEstimateNextYearLiabilityForAFTAP.chkEstimateNextYearLiabilityForAFTAP, dic["EstimateNextYearLiabilityForAFTAP"], 0);

                //
                _gLib._SetSyncUDWin("PayoutProjection", this.wRunOptions.wPayoutProjection.chkPayoutProjection, dic["PayoutProjection"], 0);
                _gLib._SetSyncUDWin("PayoutProjection_2DCashFlow", this.wRunOptions.w2DCashflowProjection.chk, dic["PayoutProjection_2DCashFlow"], 0);
                if (dic["PayoutProjection_2DCashFlow"].ToLower() == "true")
                    if (_gLib._Exists("", this.w2DCashflows.wOK.btn, 3, false))
                        _gLib._SetSyncUDWin("PayoutProjection_2DCashFlow_OK", this.w2DCashflows.wOK.btn, "click", 0);

                _gLib._SetSyncUDWin("PayoutProjection_PayoutProjectionByParticpant", this.wRunOptions.wPayoutProjectionbyParticipant.chk, dic["PayoutProjection_PayoutProjectionByParticpant"], 0);
                if (dic["PayoutProjection_PayoutProjectionByParticpant"].ToLower() == "true")
                    if (_gLib._Exists("", this.wPayoutProjectionbyPa.wOK.btn, 3, false))
                    {
                        _gLib._SetSyncUDWin("PayoutProjection_PayoutProjectionByParticpant_OK", this.wPayoutProjectionbyPa.wOK.btn, "click", 0);
                    }

                _gLib._SetSyncUDWin("IncludeIOE", this.wRunOptions.wIncludeIOE.chkIncludeIOE, dic["IncludeIOE"], 0);
                _gLib._SetSyncUDWin("GenerateParameterPrint", this.wRunOptions.wGenerateParameterPrint.chkGenerateParameterPrint, dic["GenerateParameterPrint"], 0);
                _gLib._SetSyncUDWin("GenerateTestCaseOutput", this.wRunOptions.wGenerateTestCaseOutput.chkGenerateTestCaseOutput, dic["GenerateTestCaseOutput"], 0);
                _gLib._SetSyncUDWin("2DPayoutProjection", this.wRunOptions.w2DPayoutProjection.chk, dic["2DPayoutProjection"], 0);
                _gLib._SetSyncUDWin("GL_FundingLiabilities", this.wRunOptions.wGL_FundingLiabilities.chk, dic["GL_FundingLiabilities"], 0);
                _gLib._SetSyncUDWin("GL_Liabilities_Pension", this.wRunOptions.wGainLossLiabilities_pension.chk, dic["GL_Liabilities_Pension"], 0);

                _gLib._SetSyncUDWin("IncludeGainLossResult", this.wRunOptions.wIncludeGainLossResult.chkIncludeGainLossResult, dic["IncludeGainLossResult"], 0);
                _gLib._SetSyncUDWin("IncludeGainLossAgeGroupReportFields", this.wRunOptions.wIncludeGainLossAgeGroupReportField.chx, dic["IncludeGainLossAgeGroupReportFields"], 0);
                if (_gLib._Exists("CalcIncreCostSolvencyWindup", this.wRunOptions.wCalcIncreCostSolvencyWindup.chk, 1, false) && (dic["CalcIncreCostSolvencyWindup"] == "") && Config.eCountry == _Country.CA)
                    _gLib._SetSyncUDWin("CalcIncreCostSolvencyWindup", this.wRunOptions.wCalcIncreCostSolvencyWindup.chk, "True", 0);
                else
                    _gLib._SetSyncUDWin("CalcIncreCostSolvencyWindup", this.wRunOptions.wCalcIncreCostSolvencyWindup.chk, dic["CalcIncreCostSolvencyWindup"], 0);
                _gLib._SetSyncUDWin("ApplyWithdrawalAdjustment", this.wRunOptions.wApplyWithdrawalAdjustment.chk, dic["ApplyWithdrawalAdjustment"], 0);
                _gLib._SetSyncUDWin("SaveResultsforAuditReport", this.wRunOptions.wSaveResultsforAuditReport.chk, dic["SaveResultsforAuditReport"], 0);
                _gLib._SetSyncUDWin("ApplyOverrides", this.wRunOptions.wApplyOverrides.chk, dic["ApplyOverrides"], 0);
                _gLib._SetSyncUDWin("RunLocally", this.wRunOptions.wRunLocally.chk, dic["RunLocally"], 0);
                _gLib._SetSyncUDWin("BreaksBasedOnData", this.wFutureValuationRunOptions.wBreaksType.cbo, dic["BreaksBasedOnData"], 0);
                _gLib._SetSyncUDWin("BreakByFundingVehicle", this.wRunOptions.wBreakByFundingVehicle.chk, dic["BreakByFundingVehicle"], 0);
                _gLib._SetSyncUDWin("UseReportBreaks", this.wRunOptions.wUseReportBreaks.chk, dic["UseReportBreaks"], 0);


                /**
                 * output member statistics
                 */
                _gLib._SetSyncUDWin("Service", this.wRunOptions.wService.cboService, dic["Service"], 0);
                _gLib._SetSyncUDWin("Pay", this.wRunOptions.wPay.cboPay, dic["Pay"], 0);
                _gLib._SetSyncUDWin("CurrentYear", this.wRunOptions.wCurrentYear.rdCurrentYear, dic["CurrentYear"], 0);
                _gLib._SetSyncUDWin("PriorYear", this.wRunOptions.wPriorYear.rdPriorYear, dic["PriorYear"], 0);
                _gLib._SetSyncUDWin("CashBanlance", this.wRunOptions.wCashBanlance.cboCashBanlance, dic["CashBanlance"], 0);
                _gLib._SetSyncUDWin("Pension", this.wRunOptions.wPension.cboPension, dic["Pension"], 0);

                _gLib._SetSyncUDWin("PayoutProjectionCustomGroup", this.wRunOptions.wPayoutProjectionCustomGroup.cboPayoutProjectionCustomGroup, dic["PayoutProjectionCustomGroup"], 0);
                _gLib._SetSyncUDWin("Major", this.wRunOptions.wMajor.cbo, dic["Major"], 0);
                _gLib._SetSyncUDWin("Intermediate", this.wRunOptions.wIntermediate.cbo, dic["Intermediate"], 0);
                _gLib._SetSyncUDWin("Minor", this.wRunOptions.wMinor.cbo, dic["Minor"], 0);
                _gLib._SetSyncUDWin_ByClipboard("SelectRecords", this.wRunOptions.wSelectRecords.txt, dic["SelectRecords"], 0, false, false);
                _gLib._SetSyncUDWin("SelectNodes", this.wRunOptions.wSelectNodes.btn, dic["SelectNodes"], 0);
                _gLib._SetSyncUDWin("Validate", this.wRunOptions.wValidate.btn, dic["Validate"], 0);
                _gLib._SetSyncUDWin("FC_IncludeSPC", this.wRunOptions.wIncludeSpecialPayment.chk, dic["FC_IncludeSPC"], 0);


                string sVO = dic["SelectVOs_AllVOs"] + dic["SelectVOs_VO1"] + dic["SelectVOs_VO2"] + dic["SelectVOs_VO3"] + dic["SelectVOs_VO4"] + dic["SelectVOs_VO5"] + dic["SelectVOs_VO6"];

                if (sVO != "")
                {
                    _gLib._SetSyncUDWin("SelectVOs_AllVOs", this.wRunOptions.wSelectVOs.chkAllVOs, dic["SelectVOs_AllVOs"], 0);

                    if (dic["SelectVOs_AllVOs"].ToUpper() != "TRUE")
                    {
                        if (_gLib._Exists("AllVOs", this.wRunOptions.wSelectVOs.chkAllVOs, 1, false))
                        {
                            _gLib._SetSyncUDWin("SelectVOs_AllVOs", this.wRunOptions.wSelectVOs.chkAllVOs, "True", 0);
                            _gLib._SetSyncUDWin("SelectVOs_AllVOs", this.wRunOptions.wSelectVOs.chkAllVOs, "False", 0);
                        }


                        WinCheckBox chk = new WinCheckBox(this.wRunOptions.wSelectVOs);

                        if (dic["SelectVOs_VOOFF"] != "")
                        {
                            chk.SearchProperties["Name"] = dic["SelectVOs_VOOFF"];
                            _gLib._SetSyncUDWin(dic["SelectVOs_VOOFF"], chk, "False", 0);
                        }

                        if (dic["SelectVOs_VO1"] != "")
                        {
                            chk.SearchProperties["Name"] = dic["SelectVOs_VO1"];
                            _gLib._SetSyncUDWin(dic["SelectVOs_VO1"], chk, "True", 0);
                        }
                        if (dic["SelectVOs_VO2"] != "")
                        {
                            chk.SearchProperties["Name"] = dic["SelectVOs_VO2"];
                            _gLib._SetSyncUDWin(dic["SelectVOs_VO2"], chk, "True", 0);
                        }
                        if (dic["SelectVOs_VO3"] != "")
                        {
                            chk.SearchProperties["Name"] = dic["SelectVOs_VO3"];
                            _gLib._SetSyncUDWin(dic["SelectVOs_VO3"], chk, "True", 0);
                        }
                        if (dic["SelectVOs_VO4"] != "")
                        {
                            chk.SearchProperties["Name"] = dic["SelectVOs_VO4"];
                            _gLib._SetSyncUDWin(dic["SelectVOs_VO4"], chk, "True", 0);
                        }
                        if (dic["SelectVOs_VO5"] != "")
                        {
                            chk.SearchProperties["Name"] = dic["SelectVOs_VO5"];
                            _gLib._SetSyncUDWin(dic["SelectVOs_VO5"], chk, "True", 0);
                        }
                        if (dic["SelectVOs_VO6"] != "")
                        {
                            chk.SearchProperties["Name"] = dic["SelectVOs_VO6"];
                            _gLib._SetSyncUDWin(dic["SelectVOs_VO6"], chk, "True", 0);
                        }
                    }
                }



                _gLib._SetSyncUDWin("RunValuation", this.wRunOptions.wRunValuation.btnRunValuation, dic["RunValuation"], 0);
                if (dic["RunValuation"] != "")
                {
                    if (!bCheckPopup)//// wait short time
                    {
                        if (_gLib._Exists("Save Parameter Confirm", this.wHome_Confirm, Config.iTimeout / 60, false))
                        {
                            _gLib._VerifySyncUDWin("Confirm Message", this.wHome_Confirm.wMessage.txtMessage, "Parameters must be saved before an Enterprise Run can be submitted.", 0);
                            _gLib._SetSyncUDWin("Confirm - OK", this.wHome_Confirm.wOK.btnOK, "Click", 0);
                        }
                    }
                    else//// wait long time
                    {
                        if (_gLib._Exists("Save Parameter Confirm", this.wHome_Confirm, Config.iTimeout, false))
                        {
                            _gLib._VerifySyncUDWin("Confirm Message", this.wHome_Confirm.wMessage.txtMessage, "Parameters must be saved before an Enterprise Run can be submitted.", 0);
                            _gLib._SetSyncUDWin("Confirm - OK", this.wHome_Confirm.wOK.btnOK, "Click", 0);
                        }
                    }

                }
                _gLib._SetSyncUDWin("RunValuation", this.wRunOptions.wRunValuation.btnOK, dic["OK"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("GL_GoingConcern", this.wRunOptions.wGL_GoingConcern.chkGL_GoingConcern, dic["GL_GoingConcern"], 0);
                _gLib._VerifySyncUDWin("GL_WindUp", this.wRunOptions.wGL_WindUp.chk, dic["GL_WindUp"], 0);
                _gLib._VerifySyncUDWin("Acc_GL_PBO", this.wRunOptions.wGL_PBO.chkGL_PBO, dic["Acc_GL_PBO"], 0);
                _gLib._VerifySyncUDWin("Acc_GL_ABO", this.wRunOptions.wGL_ABO.chkGL_ABO, dic["Acc_GL_ABO"], 0);
                _gLib._VerifySyncUDWin("GL_PPANAR_Min", this.wRunOptions.wGL_PPANAR_Min.chkGL_PPANAR_Min, dic["GL_PPANAR_Min"], 0);
                _gLib._VerifySyncUDWin("GL_PPANAR_Max", this.wRunOptions.wGL_PPANAR_Max.chkGL_PPANAR_Max, dic["GL_PPANAR_Max"], 0);
                _gLib._VerifySyncUDWin("GL_EAN", this.wRunOptions.wGL_EAN.chkGL_EAN, dic["GL_EAN"], 0);
                _gLib._VerifySyncUDWin("EstimateNextYearLiabilityForAFTAP", this.wRunOptions.wEstimateNextYearLiabilityForAFTAP.chkEstimateNextYearLiabilityForAFTAP, dic["EstimateNextYearLiabilityForAFTAP"], 0);
                _gLib._VerifySyncUDWin("PayoutProjection", this.wRunOptions.wPayoutProjection.chkPayoutProjection, dic["PayoutProjection"], 0);
                _gLib._VerifySyncUDWin("IncludeIOE", this.wRunOptions.wIncludeIOE.chkIncludeIOE, dic["IncludeIOE"], 0);
                _gLib._VerifySyncUDWin("GenerateParameterPrint", this.wRunOptions.wGenerateParameterPrint.chkGenerateParameterPrint, dic["GenerateParameterPrint"], 0);
                _gLib._VerifySyncUDWin("GenerateTestCaseOutput", this.wRunOptions.wGenerateTestCaseOutput.chkGenerateTestCaseOutput, dic["GenerateTestCaseOutput"], 0);
                _gLib._VerifySyncUDWin("IncludeGainLossResult", this.wRunOptions.wIncludeGainLossResult.chkIncludeGainLossResult, dic["IncludeGainLossResult"], 0);
                _gLib._VerifySyncUDWin("CalcIncreCostSolvencyWindup", this.wRunOptions.wCalcIncreCostSolvencyWindup.chk, dic["CalcIncreCostSolvencyWindup"], 0);
                _gLib._VerifySyncUDWin("ApplyWithdrawalAdjustment", this.wRunOptions.wApplyWithdrawalAdjustment.chk, dic["ApplyWithdrawalAdjustment"], 0);
                _gLib._VerifySyncUDWin("SaveResultsforAuditReport", this.wRunOptions.wSaveResultsforAuditReport.chk, dic["SaveResultsforAuditReport"], 0);
                _gLib._VerifySyncUDWin("ApplyOverrides", this.wRunOptions.wApplyOverrides.chk, dic["ApplyOverrides"], 0);
                _gLib._VerifySyncUDWin("RunLocally", this.wRunOptions.wRunLocally.chk, dic["RunLocally"], 0);
                _gLib._VerifySyncUDWin("BreakByFundingVehicle", this.wRunOptions.wBreakByFundingVehicle.chk, dic["BreakByFundingVehicle"], 0);
                _gLib._VerifySyncUDWin("UseReportBreaks", this.wRunOptions.wUseReportBreaks.chk, dic["UseReportBreaks"], 0);

                _gLib._VerifySyncUDWin("Service", this.wRunOptions.wService.cboService, dic["Service"], 0);
                _gLib._VerifySyncUDWin("Pay", this.wRunOptions.wPay.cboPay, dic["Pay"], 0);
                _gLib._VerifySyncUDWin("CurrentYear", this.wRunOptions.wCurrentYear.rdCurrentYear, dic["CurrentYear"], 0);
                _gLib._VerifySyncUDWin("PriorYear", this.wRunOptions.wPriorYear.rdPriorYear, dic["PriorYear"], 0);
                _gLib._VerifySyncUDWin("CashBanlance", this.wRunOptions.wCashBanlance.cboCashBanlance, dic["CashBanlance"], 0);
                _gLib._VerifySyncUDWin("Pension", this.wRunOptions.wPension.cboPension, dic["Pension"], 0);
                _gLib._VerifySyncUDWin("AllLiabilityTypes", this.wRunOptions.wLiabilityTypes.chkAllLiabilityTypes, dic["AllLiabilityTypes"], 0);
                _gLib._VerifySyncUDWin("PBGCPlanTermination", this.wRunOptions.wLiabilityTypes.chkPBGCPlanTermination, dic["PBGCPlanTermination"], 0);
                _gLib._VerifySyncUDWin("PPANotAtRiskLiabilityForMinimum", this.wRunOptions.wLiabilityTypes.chkPPANotAtRiskLiabilityForMinimum, dic["PPANotAtRiskLiabilityForMinimum"], 0);
                _gLib._VerifySyncUDWin("PPANotAtRiskLiabilityForMaximum", this.wRunOptions.wLiabilityTypes.chkPPANotAtRiskLiabilityForMaximum, dic["PPANotAtRiskLiabilityForMaximum"], 0);
                _gLib._VerifySyncUDWin("PPANotAtRishPresentValueOfVestedBenefits", this.wRunOptions.wLiabilityTypes.chkPPANotAtRishPresentValueOfVestedBenefits, dic["PPANotAtRishPresentValueOfVestedBenefits"], 0);
                _gLib._VerifySyncUDWin("PBGCNotAtRiskPresentValueOfVestedBenefits", this.wRunOptions.wLiabilityTypes.chkPBGCNotAtRiskPresentValueOfVestedBenefits, dic["PBGCNotAtRiskPresentValueOfVestedBenefits"], 0);
                _gLib._VerifySyncUDWin("FAS35PresentValueOfAccumulatedBenefits", this.wRunOptions.wLiabilityTypes.chkFAS35PresentValueOfAccumulatedBenefits, dic["FAS35PresentValueOfAccumulatedBenefits"], 0);
                _gLib._VerifySyncUDWin("FAS35PresentValueOfVestedBenefits", this.wRunOptions.wLiabilityTypes.chkFAS35PresentValueOfVestedBenefits, dic["FAS35PresentValueOfVestedBenefits"], 0);
                _gLib._VerifySyncUDWin("PPAAtRiskLiabilityForMinimum", this.wRunOptions.wLiabilityTypes.chkPPAAtRiskLiabilityForMinimum, dic["PPAAtRiskLiabilityForMinimum"], 0);
                _gLib._VerifySyncUDWin("PPAAtRiskLiabilityForMaximum", this.wRunOptions.wLiabilityTypes.chkPPAAtRiskLiabilityForMaximum, dic["PPAAtRiskLiabilityForMaximum"], 0);
                _gLib._VerifySyncUDWin("PPAAtRiskPresentValueOfVestedBenefits", this.wRunOptions.wLiabilityTypes.chkPPAAtRiskPresentValueOfVestedBenefits, dic["PPAAtRiskPresentValueOfVestedBenefits"], 0);
                _gLib._VerifySyncUDWin("PBGCAtRiskPresentValueOfVestedBenefits", this.wRunOptions.wLiabilityTypes.chkPBGCAtRiskPresentValueOfVestedBenefits, dic["PBGCAtRiskPresentValueOfVestedBenefits"], 0);
                _gLib._VerifySyncUDWin("EntryAgeNormal", this.wRunOptions.wLiabilityTypes.chkEntryAgeNormal, dic["EntryAgeNormal"], 0);
                _gLib._VerifySyncUDWin("Nondiscrimination", this.wRunOptions.wLiabilityTypes.chkNondiscrimination, dic["Nondiscrimination"], 0);
                _gLib._VerifySyncUDWin("Acc_ProjectedBenefitObligation", this.wRunOptions.wLiabilityTypes.chkProjectedBenefitObligation, dic["Acc_ProjectedBenefitObligation"], 0);
                _gLib._VerifySyncUDWin("Acc_AccumulatedBenefitObligation", this.wRunOptions.wLiabilityTypes.chkAccumulatedBenefitObligation, dic["Acc_AccumulatedBenefitObligation"], 0);
                _gLib._VerifySyncUDWin("Tax", this.wRunOptions.wLiabilityTypes.chkTax, dic["Tax"], 0);
                _gLib._VerifySyncUDWin("Trade", this.wRunOptions.wLiabilityTypes.chkTrade, dic["Trade"], 0);
                _gLib._VerifySyncUDWin("InternationalAccountingABO", this.wRunOptions.wLiabilityTypes.chkInternationalAccountingABO, dic["InternationalAccountingABO"], 0);
                _gLib._VerifySyncUDWin("InternationalAccountingPBO", this.wRunOptions.wLiabilityTypes.chkInternationalAccountingPBO, dic["InternationalAccountingPBO"], 0);
                _gLib._VerifySyncUDWin("Funding", this.wRunOptions.wLiabilityTypes.chkFunding, dic["Funding"], 0);
                _gLib._VerifySyncUDWin("AltFunding1", this.wRunOptions.wLiabilityTypes.chkAltFunding1, dic["AltFunding1"], 0);
                _gLib._VerifySyncUDWin("AltFunding2", this.wRunOptions.wLiabilityTypes.chkAltFunding2, dic["AltFunding2"], 0);
                _gLib._VerifySyncUDWin("AltFunding3", this.wRunOptions.wLiabilityTypes.chkAltFunding3, dic["AltFunding3"], 0);
                _gLib._VerifySyncUDWin("Solvency", this.wRunOptions.wLiabilityTypes.chkSolvency, dic["Solvency"], 0);
                _gLib._VerifySyncUDWin("PPFS179", this.wRunOptions.wLiabilityTypes.chkPPFS179, dic["PPFS179"], 0);
                _gLib._VerifySyncUDWin("PayoutProjectionCustomGroup", this.wRunOptions.wPayoutProjectionCustomGroup.cboPayoutProjectionCustomGroup, dic["PayoutProjectionCustomGroup"], 0);
                _gLib._VerifySyncUDWin("Major", this.wRunOptions.wMajor.cbo, dic["Major"], 0);
                _gLib._VerifySyncUDWin("Intermediate", this.wRunOptions.wIntermediate.cbo, dic["Intermediate"], 0);
                _gLib._VerifySyncUDWin("Minor", this.wRunOptions.wMinor.cbo, dic["Minor"], 0);
                _gLib._VerifySyncUDWin("SelectRecords", this.wRunOptions.wSelectRecords.txt, dic["SelectRecords"], 0);
                _gLib._VerifySyncUDWin("Validate", this.wRunOptions.wValidate.btn, dic["Validate"], 0);
                _gLib._VerifySyncUDWin("RunValuation", this.wRunOptions.wRunValuation.btnRunValuation, dic["RunValuation"], 0);
                _gLib._VerifySyncUDWin("OK", this.wRunOptions.wRunValuation.btnOK, dic["OK"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2019-May-28 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("StandardisedMethod", "true");
        ///    dic.Add("CustomisedApproach", "true");
        ///    dic.Add("RunFVPopulationProjection", "Click");
        ///    pMain._PopVerify_FVPopulationProjectionRunOption(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_FVPopulationProjectionRunOption(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FVPopulationProjectionRunOption";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("StandardisedMethod", this.wFVPopulationProjectRunOption.standard.rd, dic["StandardisedMethod"], 0);
                _gLib._SetSyncUDWin("CustomisedApproach", this.wFVPopulationProjectRunOption.custom.rd, dic["CustomisedApproach"], 0);
                _gLib._SetSyncUDWin("RunFVPopulationProjection", this.wFVPopulationProjectRunOption.runFVPP.btn, dic["RunFVPopulationProjection"], 0);

            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }
        /// 2013-May-15 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("isANZ", "true");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_EnterpriseRunSubmitted(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_EnterpriseRunSubmitted(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_EnterpriseRunSubmitted";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Boolean bSubmitted = false;

            for (int i = 0; i < Config.iER_SubmitTime / 2; i++)
            {

                //// added for anz fv more than 2 hours warning msgbox .
                if (dic["isANZ"].ToLower() == "true")
                    if (_gLib._Exists("more than 2 hours warning", this.wFuturevaluationRun.wOK.btn, 1, false))
                        _gLib._SetSyncUDWin("more than 2 hours warning", this.wFuturevaluationRun.wOK.btn, "click", 0);


                bSubmitted = _gLib._Exists("Enterprise Run Submitted", this.wEnterpriseRunSubmitted, 1, false);
                if (bSubmitted)
                    break;
                else
                    _gLib._Wait(1);
            }


            if (!bSubmitted)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to get <Enterprise Run Submitted> msgbox within: <" + Config.iER_SubmitTime + "> seconds! ");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to get <Enterprise Run Submitted> msgbox within: <" + Config.iER_SubmitTime + "> seconds! ");
            }
            else
            {

                string sActMsg = this.wEnterpriseRunSubmitted.wMessage.txtMessage.Name;
                if (!sActMsg.Contains("SUBMITTED"))
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail because Parameter Print failed! ");
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail because Parameter Print failed! ");
                }


                _gLib._SetSyncUDWin("OK", this.wEnterpriseRunSubmitted.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        public void _EnterpriseRun(string sCompleteMessage, Boolean bEqualTrue_ContainFalse, string sRunType)
        {

            if (sRunType == "")
                sRunType = "Val Liab";

            string sFunctionName = "_EnterpriseRun";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            string sActMsg = "";
            Boolean bERCompleted = false;
            int iRefreshTime = 60;
            int iIteration = Config.iER_CompleteTime / iRefreshTime;
            this._SelectTab("Run Status");
            _gLib._SetSyncUDWin("Refresh", this.wRetirementStudio.wRunStatus_Refresh.btnRefresh, "Click", 0);
            this._SelectTab("Run Status");

            for (int i = 0; i < iIteration; i++)
            {
                _gLib._SetSyncUDWin("Refresh", this.wRetirementStudio.wRunStatus_Refresh.btnRefresh, "Click", 0);

                _gLib._SetSyncUDWin("ER - FPGrid", this.wRetirementStudio.wRunStatus_FPGrid, "Click", 0, false, 50, 27);
                ////Mouse.Click(this.wRetirementStudio.wRunStatus_FPGrid, new Point(50, 27));

                if (sRunType != "")
                {
                    ////////////Keyboard.SendKeys(this.wRetirementStudio.wRunStatus_FPGrid.grid, "{End}");
                    _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRunStatus_FPGrid.grid, "{End}{left}");

                    string sActRunType = _fp._ReturnSelectRowContent(this.wRetirementStudio.wRunStatus_FPGrid.grid);
                    if (!sRunType.Equals(sActRunType))
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail because Run Type NOT correct, Expected <" + sRunType + ">, Act Run Type: <" + sActRunType + ">! ");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Function <" + sFunctionName + "> fail because Run Type NOT correct, Expected <" + sRunType + ">, Act Run Type: <" + sActRunType + ">! ");
                    }
                }

                //////////////Keyboard.SendKeys(this.wRetirementStudio.wRunStatus_FPGrid.grid, "{End}{Left}{Left}{Left}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRunStatus_FPGrid.grid, "{Home}{Home}{Right}{Right}{Right}{Right}{Right}{Right}{Right}{Right}{Right}");

                sActMsg = _fp._ReturnSelectRowContent(this.wRetirementStudio.wRunStatus_FPGrid.grid);

                if (bEqualTrue_ContainFalse)
                {
                    if (sCompleteMessage == sActMsg)
                    {
                        bERCompleted = true;
                        break;
                    }
                }
                else
                {
                    if (sActMsg.Contains(sCompleteMessage))
                    {
                        bERCompleted = true;
                        break;
                    }
                }

                _gLib._Wait(iRefreshTime);
            }

            if (!bERCompleted)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail within <" + Config.iER_CompleteTime + "> seconds, Expected Complete Msg: <" + sCompleteMessage + ">, Actual Complete Msg: <" + sActMsg + ">! ");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail within <" + Config.iER_CompleteTime + "> seconds, Expected Complete Msg: <" + sCompleteMessage + ">, Actual Complete Msg: <" + sActMsg + ">! ");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

            //////_gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRunStatus_FPGrid.grid, "{End}{Left}{Left}");
            //////sSuccessTime = _fp._ReturnSelectRowContent(this.wRetirementStudio.wRunStatus_FPGrid.grid);

            //////return sSuccessTime;



        }


        public string _ER_ReturnRunStatus_TopGrid(int iCol)
        {
            string sInfo = "";
            _gLib._SetSyncUDWin("ER - FPGrid", this.wRetirementStudio.wRunStatus_FPGrid.grid, "Click", 0, false, 50, 27);

            string sKeys = "{Home}";

            for (int i = 1; i < iCol; i++)
                sKeys += "{Right}";
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRunStatus_FPGrid.grid, sKeys);


            sInfo = _fp._ReturnSelectRowContent(this.wRetirementStudio.wRunStatus_FPGrid.grid);

            return sInfo;
        }



        /// <summary>
        /// sample:
        /// 
        /// pMain._ER_ReturnRunStatus_BottomGrid("Job State History", 4, 5)
        /// 
        /// </summary>
        /// <param name="sTabName"></param>
        /// <param name="iRow"></param>
        /// <param name="iCol"></param>
        /// <returns></returns>
        public string _ER_ReturnRunStatus_BottomGrid(string sTabName, int iRow, int iCol)
        {
            string sInfo = "";

            int iPos_X = 0;
            int iPos_Y = 0;

            if (iCol == 5)  // job state history
                iPos_X = 940;
            if (iCol == 3)  // job status info
                iPos_X = 225;
            if (iCol == 12)  // job status info
                iPos_X = 1200;


            iPos_Y = iRow * 20 + 10;

            _gLib._TabPageSelectWin(sTabName, this.wRetirementStudio.wRunStatus_Tab, 0);


            _gLib._SetSyncUDWin("ER - FPGrid - Bottom", this.wRetirementStudio.wRunStatus_FPGrid_Bottom.grid, "Click", 0, false, iPos_X, iPos_Y);

            //string sKeys = "{Home}{PageUp}";

            //for (int i = 1; i < iRow; i++)
            //    sKeys += "{Down}";

            //for (int i = 1; i < iCol; i++)
            //    sKeys += "{Right}";

            //_gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRunStatus_FPGrid_Bottom.grid, sKeys);


            sInfo = _fp._ReturnSelectRowContent(this.wRetirementStudio.wRunStatus_FPGrid_Bottom.grid);

            return sInfo;
        }


        public void _EnterpriseRun(string sCompleteMessage, Boolean bEqualTrue_ContainFalse)
        {
            this._EnterpriseRun(sCompleteMessage, bEqualTrue_ContainFalse, "");
        }


        public void _CancelRun()
        {
            _gLib._SetSyncUDWin("Refresh", this.wRetirementStudio.wRunStatus_Refresh.btnRefresh, "Click", 0);
            _gLib._SetSyncUDWin("ER - FPGrid", this.wRetirementStudio.wRunStatus_FPGrid, "Click", 0, false, 50, 27);


            //_gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRunStatus_FPGrid.grid, "{End}{Left}{Left}{Left}");
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRunStatus_FPGrid.grid, "{Home}{Right}{Right}{Right}{Right}{Right}{Right}{Right}{Right}{Right}{Right}");
            string sActMsg = _fp._ReturnSelectRowContent(this.wRetirementStudio.wRunStatus_FPGrid.grid);


            _gLib._SetSyncUDWin("", this.wRetirementStudio.wRunStatus_FPGrid.grid, "Click", 0, false, 30, 30);
            _gLib._Wait(2);
            _gLib._SetSyncUDWin("", this.wRetirementStudio.wRunStatus_FPGrid.grid, "Click", 0, false, 30, 30);


            if ("<Group Job Submit Complete><Group Job Execution Started>".Contains(sActMsg))
                _gLib._SetSyncUDWin("wCancelRun", this.wRetirementStudio.wCancelRun.btn, "Click", 0);
            else
                _gLib._MsgBoxYesNo("", "Please check run status, and if here needs rerun ER");

            _gLib._SetSyncUDWin("Yes", this.wWord_Popup.wYes.btn, "Click", 0);
            _gLib._SetSyncUDWin("OK", this.wWord_Popup.wOK.btnOK, "Click", 0);

        }


        /// <summary>
        /// 2013-May-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ValNodeName", "Match with RS Data");
        ///    dic.Add("LiabilityValuationDate", "");
        ///    dic.Add("Data_AddNew", "True");
        ///    dic.Add("Data_Name", "");
        ///    dic.Add("Data_Edit", "");
        ///    dic.Add("Assumptions_AddNew", "");
        ///    dic.Add("Assumptions_Name", "");
        ///    dic.Add("Assumptions_Edit", "");
        ///    dic.Add("MethodsLiabilities_AddNew", "");
        ///    dic.Add("MethodsLiabilities_Name", "");
        ///    dic.Add("MethodsLiabilities_Edit", "");
        ///    dic.Add("Provisions_AddNew", "");
        ///    dic.Add("Provisions_Name", "");
        ///    dic.Add("Provisions_Edit", "");
        ///    dic.Add("Need_ActuarialReport", "");
        ///    dic.Add("FundingInformation_AddNew", "");
        ///    dic.Add("FundingInformation_Name", "");
        ///    dic.Add("FundingInformation_Edit", "");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Cancel", "");
        ///    pMain._PopVerify_ValuationNodeProperties(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ValuationNodeProperties(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_ValuationNodeProperties";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                if (dic["ValNodeName"] != "")
                {
                    _gLib._SendKeysUDWin("ValNodeName", this.wValNodeProperties.wValNodeName.txtValNodeName, "A", 0, ModifierKeys.Control, false);
                    _gLib._SendKeysUDWin("ValNodeName", this.wValNodeProperties.wValNodeName.txtValNodeName, "{Back}", 0);
                }
                _gLib._SetSyncUDWin_ByClipboard("ValNodeName", this.wValNodeProperties.wValNodeName.txtValNodeName, dic["ValNodeName"], 0);
                _gLib._SetSyncUDWin_ByClipboard("LiabilityValuationDate", this.wValNodeProperties.wLiabilityValuationDate.txtLiabilityValuationDate, dic["LiabilityValuationDate"], 0);
                _gLib._SetSyncUDWin("Data_AddNew", this.wValNodeProperties.wData_AddNew.chkData_AddNew, dic["Data_AddNew"], 0);
                _gLib._SetSyncUDWin("Data_Name", this.wValNodeProperties.wData_Name.txtData_Name, dic["Data_Name"], 0);
                _gLib._SetSyncUDWin("Data_Edit", this.wValNodeProperties.wData_Edit.btnData_Edit, dic["Data_Edit"], 0);
                _gLib._SetSyncUDWin("Assumptions_AddNew", this.wValNodeProperties.wAssumptions_AddNew.chkAssumptions_AddNew, dic["Assumptions_AddNew"], 0);
                _gLib._SetSyncUDWin("Assumptions_Name", this.wValNodeProperties.wAssumptions_Name.txtAssumptions_Name, dic["Assumptions_Name"], 0);
                _gLib._SetSyncUDWin("Assumptions_Edit", this.wValNodeProperties.wAssumptions_Edit.btnAssumptions_Edit, dic["Assumptions_Edit"], 0);
                _gLib._SetSyncUDWin("MethodsLiabilities_AddNew", this.wValNodeProperties.wMethodsLiabilities_AddNew.chkMethodsLiabilities_AddNew, dic["MethodsLiabilities_AddNew"], 0);
                _gLib._SetSyncUDWin("MethodsLiabilities_Name", this.wValNodeProperties.wMethodsLiabilities_Name.txtMethodsLiabilities_Name, dic["MethodsLiabilities_Name"], 0);
                _gLib._SetSyncUDWin("MethodsLiabilities_Edit", this.wValNodeProperties.wMethodsLiabilities_Edit.btnMethodsLiabilities_Edit, dic["MethodsLiabilities_Edit"], 0);
                _gLib._SetSyncUDWin("Provisions_AddNew", this.wValNodeProperties.wProvisions_AddNew.chkProvisions_AddNew, dic["Provisions_AddNew"], 0);
                _gLib._SetSyncUDWin("Provisions_Name", this.wValNodeProperties.wProvisions_Name.txtProvisions_Name, dic["Provisions_Name"], 0);
                _gLib._SetSyncUDWin("Provisions_Edit", this.wValNodeProperties.wProvisions_Edit.btnProvisions_Edit, dic["Provisions_Edit"], 0);

                if (dic["Need_ActuarialReport"].ToLower().Equals("true"))
                {
                    _gLib._SetSyncUDWin("FundingInformation_AddNew", this.wValNodeProperties.wFundingInformation_AddNew.chkFundingInformation_AddNew, dic["FundingInformation_AddNew"], 0);
                    _gLib._SetSyncUDWin("FundingInformation_Name", this.wValNodeProperties.wFundingInformation_Name.txtFundingInformation_Name, dic["FundingInformation_Name"], 0);
                    _gLib._SetSyncUDWin("FundingInformation_Edit", this.wValNodeProperties.wFundingInformation_Edit.btnFundingInformation_Edit, dic["FundingInformation_Edit"], 0);
                }

                _gLib._SetSyncUDWin("OK", this.wValNodeProperties.wOK.btnOK, dic["OK"], 0);

                //////////if (true)
                //////////{
                //////////    if (_gLib._Enabled("FundingCalculatorNotRunComplete_OK", this.wWord_Popup.wOK.btnOK, 2, false))
                //////////        _gLib._SetSyncUDWin("FundingCalculatorNotRunComplete_OK", this.wWord_Popup.wOK.btnOK, "click", 0);
                //////////    ////////_gLib._SetSyncUDWin("FundingCalculatorNotRunComplete_OK", this.wWord_Popup.wOK.btnOK, dic["FundingCalculatorNotRunComplete_OK"], 0);
                //////////}

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("ValNodeName", this.wValNodeProperties.wValNodeName.txtValNodeName, dic["ValNodeName"], 0);
                _gLib._VerifySyncUDWin("LiabilityValuationDate", this.wValNodeProperties.wLiabilityValuationDate.txtLiabilityValuationDate, dic["LiabilityValuationDate"], 0);
                _gLib._VerifySyncUDWin("Data_AddNew", this.wValNodeProperties.wData_AddNew.chkData_AddNew, dic["Data_AddNew"], 0);
                _gLib._VerifySyncUDWin("Data_Name", this.wValNodeProperties.wData_Name.txtData_Name, dic["Data_Name"], 0);
                _gLib._VerifySyncUDWin("Data_Edit", this.wValNodeProperties.wData_Edit.btnData_Edit, dic["Data_Edit"], 0);
                _gLib._VerifySyncUDWin("Assumptions_AddNew", this.wValNodeProperties.wAssumptions_AddNew.chkAssumptions_AddNew, dic["Assumptions_AddNew"], 0);
                _gLib._VerifySyncUDWin("Assumptions_Name", this.wValNodeProperties.wAssumptions_Name.txtAssumptions_Name, dic["Assumptions_Name"], 0);
                _gLib._VerifySyncUDWin("Assumptions_Edit", this.wValNodeProperties.wAssumptions_Edit.btnAssumptions_Edit, dic["Assumptions_Edit"], 0);
                _gLib._VerifySyncUDWin("MethodsLiabilities_AddNew", this.wValNodeProperties.wMethodsLiabilities_AddNew.chkMethodsLiabilities_AddNew, dic["MethodsLiabilities_AddNew"], 0);
                _gLib._VerifySyncUDWin("MethodsLiabilities_Name", this.wValNodeProperties.wMethodsLiabilities_Name.txtMethodsLiabilities_Name, dic["MethodsLiabilities_Name"], 0);
                _gLib._VerifySyncUDWin("MethodsLiabilities_Edit", this.wValNodeProperties.wMethodsLiabilities_Edit.btnMethodsLiabilities_Edit, dic["MethodsLiabilities_Edit"], 0);
                _gLib._VerifySyncUDWin("Provisions_AddNew", this.wValNodeProperties.wProvisions_AddNew.chkProvisions_AddNew, dic["Provisions_AddNew"], 0);
                _gLib._VerifySyncUDWin("Provisions_Name", this.wValNodeProperties.wProvisions_Name.txtProvisions_Name, dic["Provisions_Name"], 0);
                _gLib._VerifySyncUDWin("Provisions_Edit", this.wValNodeProperties.wProvisions_Edit.btnProvisions_Edit, dic["Provisions_Edit"], 0);
                _gLib._VerifySyncUDWin("FundingInformation_AddNew", this.wValNodeProperties.wFundingInformation_AddNew.chkFundingInformation_AddNew, dic["FundingInformation_AddNew"], 0);
                _gLib._VerifySyncUDWin("FundingInformation_Name", this.wValNodeProperties.wFundingInformation_Name.txtFundingInformation_Name, dic["FundingInformation_Name"], 0);
                _gLib._VerifySyncUDWin("FundingInformation_Edit", this.wValNodeProperties.wFundingInformation_Edit.btnFundingInformation_Edit, dic["FundingInformation_Edit"], 0);
                _gLib._VerifySyncUDWin("OK", this.wValNodeProperties.wOK.btnOK, dic["OK"], 0);


            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("LiabilityType", "PPA");
        ///    dic.Add("ReasonforChange", "Baseline");
        ///    dic.Add("OK", "");
        ///    pMain._ValuationNodeProperties_ChangeReasons(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _ValuationNodeProperties_ChangeReasons(MyDictionary dic)
        {
            string sFunctionName = "_ValuationNodeProperties_ChangeReasons";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sAct;
            int iPosX = 100;
            int iStartY = 20;
            int iStepY = 20;

            int iRow = 1;
            Boolean bFindLiabilityType = false;
            // search expected Liability Type row number
            _gLib._SendKeysUDWin("FPGrid", this.wValNodeProperties.wChangeReason_FPGrid.grid, "{Down}{PageUp}{Down}{Up}");
            ////////_gLib._SetSyncUDWin("FPGrid", this.wValNodeProperties.wChangeReason_FPGrid.grid, "Click", 0, false, iPosX, iStartY + iStepY / 2);

            for (int i = 1; i < 10; i++)
            {
                sAct = _fp._ReturnSelectRowContent(this.wValNodeProperties.wChangeReason_FPGrid.grid);

                if (sAct == dic["LiabilityType"])
                {
                    bFindLiabilityType = true;
                    break;
                }

                ////////////Keyboard.SendKeys(this.wValNodeProperties.wChangeReason_FPGrid.grid, "{Down}");
                _gLib._SendKeysUDWin("FPGrid", this.wValNodeProperties.wChangeReason_FPGrid.grid, "{Down}");
                iRow++;
            }

            if (!bFindLiabilityType)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to find Liability Type <" + dic["LiabilityType"] + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to find Liability Type <" + dic["LiabilityType"] + ">");
            }



            iPosX = 350;
            int iPosY = (iRow - 1) * iStepY + iStepY / 2 + iStartY;
            ////////////Mouse.Click(this.wValNodeProperties.wChangeReason_FPGrid.grid, new Point(iPosX, iPosY));
            _gLib._SetSyncUDWin("FPGrid", this.wValNodeProperties.wChangeReason_FPGrid.grid, "Click", 0, false, iPosX, iPosY);


            WinWindow wWin = new WinWindow();
            wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "Desktop 1", PropertyExpressionOperator.EqualTo);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "#32769", PropertyExpressionOperator.EqualTo);
            WinWindow wWin1 = new WinWindow(wWin);
            wWin1.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.LISTBOX", PropertyExpressionOperator.Contains);
            WinList wList = new WinList(wWin1);


            WinListItem item = new WinListItem(wList);
            item.SearchProperties.Add(WinListItem.PropertyNames.Name, dic["ReasonforChange"]);
            _gLib._SetSyncUDWin("" + dic["ReasonforChange"], item, "click", 0);
            ////////////////Keyboard.SendKeys(wList, dic["ReasonforChange"].Substring(0,1));
            ////_gLib._SendKeysUDWin("ReasonforChange", wList, dic["ReasonforChange"].Substring(0, 1));

            ////_gLib._SetSyncUDWin("Reason for Change", wList, dic["ReasonforChange"], 0, false);

            ////////////Keyboard.SendKeys(this.wValNodeProperties.wChangeReason_FPGrid.grid, "{Tab}", ModifierKeys.Shift);
            ////////////Keyboard.SendKeys(this.wValNodeProperties.wChangeReason_FPGrid.grid, "{End}");
            _gLib._SendKeysUDWin("FPGrid", this.wValNodeProperties.wChangeReason_FPGrid.grid, "{Tab}", 0, ModifierKeys.Shift, false);
            _gLib._SendKeysUDWin("FPGrid", this.wValNodeProperties.wChangeReason_FPGrid.grid, "{End}");

            sAct = _fp._ReturnSelectRowContent(this.wValNodeProperties.wChangeReason_FPGrid.grid);
            if (sAct != dic["ReasonforChange"])
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set Reason for Change: <" + dic["ReasonforChange"] + "> to Liability Type <" + dic["LiabilityType"] + ">, actual value: <" + sAct + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set Reason for Change: <" + dic["ReasonforChange"] + "> to Liability Type <" + dic["LiabilityType"] + ">, actual value: <" + sAct + ">");
            }


            _gLib._SetSyncUDWin("OK", this.wValNodeProperties.wOK.btnOK, dic["OK"], 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> End:");
        }


        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        /// 
        /// pMain._ValuationNodeProperties_ChangeReasons_Initialize(); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _ValuationNodeProperties_ChangeReasons_Initialize()
        {
            string sFunctionName = "_ValuationNodeProperties_ChangeReasons_Initialize";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iPosX = 100;
            int iStartY = 20;
            int iStepY = 20;

            ////////////Mouse.Click(this.wValNodeProperties.wChangeReason_FPGrid.grid, new Point(iPosX, iStartY + iStepY / 2));
            ////////////Keyboard.SendKeys(this.wValNodeProperties.wChangeReason_FPGrid.grid, "{Right}{Enter}");
            ////////////Mouse.Click(this.wValNodeProperties.wChangeReason_FPGrid.grid, new Point(iPosX, iStartY + iStepY / 2));
            ////////////Keyboard.SendKeys(this.wValNodeProperties.wChangeReason_FPGrid.grid, "{PageUp}{Home}");

            _gLib._SetSyncUDWin("FPGrid", this.wValNodeProperties.wChangeReason_FPGrid.grid, "Click", 0, false, iPosX, iStartY + iStepY / 2);
            _gLib._SendKeysUDWin("FPGrid", this.wValNodeProperties.wChangeReason_FPGrid.grid, "{Right}{Enter}");
            _gLib._SetSyncUDWin("FPGrid", this.wValNodeProperties.wChangeReason_FPGrid.grid, "Click", 0, false, iPosX, iStartY + iStepY / 2);
            _gLib._SendKeysUDWin("FPGrid", this.wValNodeProperties.wChangeReason_FPGrid.grid, "{PageUp}{Home}");

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> End:");
        }


        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("WorkspaceName", "Assets2011");
        ///    pMain._Assets_AddWorkSpace(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Assets_AddWorkSpace(MyDictionary dic)
        {
            string sFunctionName = "_Assets_AddWorkSpace";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("New WorkSapce", this.wRetirementStudio.wAsset_NewWorkSpace.btnNewWorkSpace, "Click", 0);
            _gLib._Wait(6);


            int iRow = Convert.ToInt32(dic["iRow"]);

            int iPosX = 80;
            int iStepY = 18;
            int iStartY = 20 + iStepY / 2;
            int iPosY = (iRow - 1) * iStepY + iStartY;

            ////////////Mouse.Click(this.wRetirementStudio.wAsset_WorkSapce_FPGrid.grid, new Point(iPosX, iPosY));
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wAsset_WorkSapce_FPGrid.grid, "Click", 0, false, iPosX, iPosY);
            _gLib._Wait(1);

            try
            {
                Mouse.Click(this.wRetirementStudio.wAsset_WorkSapce_FPGrid.grid, MouseButtons.Right, ModifierKeys.None, new Point(iPosX, iPosY));
            }
            catch (Exception ex)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to Right Click on Asset Workspace. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right Click on Asset Workspace. Because of Exception thrown: " + Environment.NewLine + ex.Message);
            }

            MyDictionary dicTmp = new MyDictionary();
            dicTmp.Clear();
            dicTmp.Add("Level_1", "Rename");
            _gLib._MenuSelectWin(0, this.wFlowTree_ContextMenu, dicTmp);

            WinWindow wWin = new WinWindow(this.wRetirementStudio);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.EDIT", PropertyExpressionOperator.Contains);
            WinEdit wEdit = new WinEdit(wWin);


            ////////////Keyboard.SendKeys(wEdit, dic["WorkspaceName"]);
            ////////////Keyboard.SendKeys(wEdit, "{Enter}");
            _gLib._SendKeysUDWin("WorkspaceName", wEdit, dic["WorkspaceName"]);
            _gLib._SendKeysUDWin("WorkspaceName", wEdit, "{Enter}");

            string sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wAsset_WorkSapce_FPGrid.grid);

            if (sAct != dic["WorkspaceName"])
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to add new Workspace <" + dic["WorkspaceName"] + ">, Actual Workspace name: <" + sAct + ">! ");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to add new Workspace <" + dic["WorkspaceName"] + ">, Actual Workspace name: <" + sAct + ">! ");
            }

            try
            {
                Mouse.DoubleClick(this.wRetirementStudio.wAsset_WorkSapce_FPGrid.grid, new Point(iPosX, iPosY));
            }
            catch (Exception ex)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to Double Click on Asset Workspace. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Double Click on Asset Workspace. Because of Exception thrown: " + Environment.NewLine + ex.Message);
            }

            this._SelectTab(dic["WorkspaceName"]);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-24 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_FundingCalculationRunCompleted(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_FundingCalculationRunCompleted(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FundingCalculationRunCompleted";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wFundingCalculationRunCompleted.wOK.btnOK, dic["OK"], Config.iTimeout * 2);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wFundingCalculationRunCompleted.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-24 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_FundingCalculationRunCompleted_UK(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_FundingCalculationRunCompleted_UK(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_FundingCalculationRunCompleted_UK";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wFundingCalculationRun.wOK.btn, dic["OK"], Config.iTimeout * 3);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wFundingCalculationRun.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-22 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    
        ///    dic.Clear();
        ///    dic.Add("MenuItem_1", "Actuarial Report");
        ///    dic.Add("MenuItem_2", "New");
        ///    dic.Add("MenuItem_3", "PPA Funding Valuation Report");
        ///    pMain._MenuSelect(dic); 
        /// 
        ///    dic.Clear();
        ///    dic.Add("MenuItem_1", "File");
        ///    dic.Add("MenuItem_2", "Import Tables");
        ///    pMain._MenuSelect(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("MenuItem_1", "Asset Snapshots");
        ///    pMain._MenuSelect(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _MenuSelect(MyDictionary dic)
        {
            string sFunctionName = "_MenuSelect";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            MyDictionary dicTmp = new MyDictionary();
            dicTmp.Clear();

            for (int i = 1; i <= dic.Count; i++)
            {
                if (dic["MenuItem_" + i.ToString()] != "")
                    dicTmp.Add("Level_" + i.ToString(), dic["MenuItem_" + i.ToString()]);
            }
            _gLib._MenuSelectWin(0, this.wRetirementStudio.wMenuBar, dicTmp);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }


        /// <summary>
        /// 2013-May-22 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    
        /// pMain._GenerateNewReport(sOutputFunding_Valuation2012_UpdateAssumptionDates, "PPA Funding Valuation Report", 3);
        /// </summary>
        /// <param name="dic"></param>
        /// 


        public void _GenerateNewReport(string sReportDirctory, string sReportName, int iNodeIndex)
        {
            this._GenerateNewReport(sReportDirctory, sReportName, iNodeIndex, false, "");
        }

        public void _GenerateNewReport(string sReportDirctory, string sReportName, int iNodeIndex, string ReportStandard)
        {
            this._GenerateNewReport(sReportDirctory, sReportName, iNodeIndex, false, ReportStandard);
        }

        public void _GenerateNewReport(string sReportDirctory, string sReportName, int iNodeIndex, Boolean bPPT)
        {
            this._GenerateNewReport(sReportDirctory, sReportName, iNodeIndex, bPPT, "");
        }

        public void _GenerateNewReport(string sReportDirctory, string sReportName, int iNodeIndex, Boolean bPPT, string sReportStandard)
        {
            string sFunctionName = "_GenerateNewReport";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            string sFileName = sReportDirctory + "AR_" + sReportName.Replace(" ", "") + ".docx";
            string sFormat = "Word";

            if (bPPT)
            {
                sFileName = sReportDirctory + sReportName.Replace(" ", "") + ".pptX";
                sFormat = "PowerPoint";
            }

            MyDictionary dicTmp = new MyDictionary();
            dicTmp.Clear();
            dicTmp.Add("MenuItem_1", "Actuarial Report");
            dicTmp.Add("MenuItem_2", "New");
            dicTmp.Add("MenuItem_3", sReportName);
            this._MenuSelect(dicTmp);


            int iStartX = 115;
            int iEndX = 225;
            int iStartY = 18;
            int iStepY = 19 + 38; // 38 is the hight of one node, 20 is the space between two nodes
            int iEndY = iStartY + iStepY * (iNodeIndex - 1);


            int iPosX = iStartX + (iEndX - iStartX) / 2;
            int iPosY = iEndY + 38 / 2;

            ////////////Mouse.Click(this.wGenerateNewReport.wFlowTree.flowTree, new Point(iPosX, iPosY));
            _gLib._SetSyncUDWin("FlowTree", this.wGenerateNewReport.wFlowTree.flowTree, "Click", 0, false, iPosX, iPosY);

            string sUniqueReportName = sReportName.Replace(" ", "");

            sUniqueReportName = sUniqueReportName + "_" + _gLib._ReturnDateStampYYYYMMDDHHMMSS();

            _gLib._SetSyncUDWin("Report Standard", this.wGenerateNewReport.wReportStandard.cbo, sReportStandard, 0);

            if (_gLib._Exists("ReportFormat", this.wGenerateNewReport.wReportFormat, Config.iTimeout / 30, false))
                _gLib._SetSyncUDWin("Report Format", this.wGenerateNewReport.wReportFormat.cbo, sFormat, 0);

            _gLib._SetSyncUDWin("Report Name", this.wGenerateNewReport.wReportName.txtReportName, sUniqueReportName, 0);

            _gLib._SetSyncUDWin("OK", this.wGenerateNewReport.wOK.btnOK, "Click", 0);

            if (sReportName == "PPA Funding Valuation Report")
            {
                //////if (_gLib._Exists("Confirm Redate", this.wConfirmRedate, Config.iTimeout/10, false))
                //////    _gLib._SetSyncUDWin("Confirm Redate - Yes", this.wConfirmRedate.wYes.btnYes, "Click", 0);

                ////if (_gLib._Exists("No Current Profile", this.wWord_NoCurrentProfile, Config.iTimeout, false))
                ////    _gLib._SetSyncUDWin("No Current Profile - OK", this.wWord_NoCurrentProfile.wOK.btn, "Click", 0);

                ////if (_gLib._Exists("Profiles", this.wWord_Profiles, Config.iTimeout / 10, false))
                ////    _gLib._SetSyncUDWin("Profiles - Close", this.wWord_Profiles.wClose.btn, "Click", 0);

                //if (_gLib._Exists("MMCOATemplateFailure", this.wMMCOATemplateFailure, Config.iTimeout / 10, false))
                //    _gLib._SetSyncUDWin("MMCOATemplateFailure - OK", this.wMMCOATemplateFailure.wOK.btn, "Click", 0);
            }



            if (sReportName == "ASC 960 Letter")
            {
                //if (_gLib._Exists("No Current Profile", this.wWord_NoCurrentProfile, Config.iTimeout / 10, false))
                //    _gLib._SetSyncUDWin("No Current Profile - OK", this.wWord_NoCurrentProfile.wOK.btn, "Click", 0);

                //if (_gLib._Exists("Profiles", this.wWord_Profiles, Config.iTimeout / 10, false))
                //    _gLib._SetSyncUDWin("Profiles - Close", this.wWord_Profiles.wClose.btn, "Click", 0);

                //if (_gLib._Exists("MMCOATemplateFailure", this.wMMCOATemplateFailure, Config.iTimeout / 10, false))
                //    _gLib._SetSyncUDWin("MMCOATemplateFailure - OK", this.wMMCOATemplateFailure.wOK.btn, "Click", 0);
            }




            _gLib._SetSyncUDWin("Word - File Tab", this.wWord.wMenuBar.wFileTab.btnFile, "Click", 0);
            /////_gLib._SetSyncUDWin("Word - SaveAs", this.wWord.wFileMenuBar.miSaveAs, "Click", 0);

            _gLib._Wait(1);

            try
            {
                _gLib._SendKeysUDWin("wWord", this.wWord, "f", 0, ModifierKeys.Alt, false);
                _gLib._SendKeysUDWin("wWord", this.wWord, "a", false);
                _gLib._SendKeysUDWin("wWord", this.wWord, "o", false);
                ////////////Keyboard.SendKeys("F", ModifierKeys.Alt);
                ////////////_gLib._Wait(1);
                ////////////Keyboard.SendKeys("a", ModifierKeys.None);

            }
            catch (Exception ex)
            { }



            if (_gLib._Exists("Word Popup", this.wWord_Popup, Config.iTimeout / 30, false))
                _gLib._SetSyncUDWin("Word Popup - OK", this.wWord_Popup.wOK.btnOK, "Click", 0);

            //if (sReportName == "ASC 960 Letter")
            //{
            //    _gLib._SetSyncUDWin("SaveAs - FileName", this.wWord_SaveAs.wFileName.txt, sFileName, 0);
            //    _gLib._SetSyncUDWin("SaveAs - Save", this.wWord_SaveAs.wSave.btn, "Click", 0);
            //}
            _gLib._SetSyncUDWin("SaveAs - FileName", this.wWord_SaveAs.wFileName.txt, sFileName, 0);
            _gLib._SetSyncUDWin("SaveAs - Save", this.wWord_SaveAs.wSave.btn, "Click", 0);


            if (_gLib._Exists("btnOK", this.wMicrosoftWord.wDialog.btnOK, 3, false))
            {
                _gLib._SetSyncUDWin("SaveAs - Save", this.wMicrosoftWord.wDialog.btnOK, "Click", 0);
            }

            _gLib._FileExists(sFileName, 10, true);
            _gLib._SetSyncUDWin("Word - Close", this.wWord.wTitleBar.btnClose, "Click", 0);



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");
        }



        /// <summary>
        /// 2013-Sep-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Name", "RetirementScale07");
        ///    dic.Add("Type", "");
        ///    dic.Add("Description", "");
        ///    dic.Add("Ultimate", "");
        ///    dic.Add("Generational", "");
        ///    dic.Add("TwoDimensional", "");
        ///    dic.Add("Index1_Index", "");
        ///    dic.Add("Index1_From", "");
        ///    dic.Add("Index1_To", "");
        ///    dic.Add("Extend", "");
        ///    dic.Add("Zero", "");
        ///    dic.Add("SameRatesUsed", "");
        ///    dic.Add("Format", "");
        ///    dic.Add("DecimalPlaces", "");
        ///    dic.Add("OK", "");
        ///    pMain._PopVerify_Parameters(dic); 
        /// </summary>
        /// <param name="dic"></param>
        private void _PopVerify_Parameters(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Parameters";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Name", this.wParameters.wName.txtName, dic["Name"], 0);
                _gLib._SetSyncUDWin("Type", this.wParameters.wType.cboType, dic["Type"], 0);
                _gLib._SetSyncUDWin("Description", this.wParameters.wDescription.txtDescription, dic["Description"], 0);
                _gLib._SetSyncUDWin("Ultimate", this.wParameters.wUltimate.rdUltimate, dic["Ultimate"], 0);
                _gLib._SetSyncUDWin("Generational", this.wParameters.wGenerational.rdGenerational, dic["Generational"], 0);
                _gLib._SetSyncUDWin("TwoDimensional", this.wParameters.wTwoDimensional.rdTwoDimensional, dic["TwoDimensional"], 0);
                _gLib._SetSyncUDWin("Index1_Index", this.wParameters.wIndex1_Index.cbo, dic["Index1_Index"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Index1_From", this.wParameters.wIndex1_From.txt, dic["Index1_From"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Index1_To", this.wParameters.wIndex1_To.txt, dic["Index1_To"], 0);
                _gLib._SetSyncUDWin("Extend", this.wParameters.wExtend.rdExtend, dic["Extend"], 0);
                _gLib._SetSyncUDWin("Zero", this.wParameters.wZero.rdZero, dic["Zero"], 0);
                _gLib._SetSyncUDWin("SameRatesUsed", this.wParameters.wSameRatesUsed.chkSameRatesUsed, dic["SameRatesUsed"], 0);
                _gLib._SetSyncUDWin("Format", this.wParameters.wFormat.cboFormat, dic["Format"], 0);
                _gLib._SetSyncUDWin_ByClipboard("DecimalPlaces", this.wParameters.wDecimalPlaces.txt, dic["DecimalPlaces"], 0);
                _gLib._SetSyncUDWin("OK", this.wParameters.wOK.btnOK, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Name", this.wParameters.wName.txtName, dic["Name"], 0);
                _gLib._VerifySyncUDWin("Type", this.wParameters.wType.cboType, dic["Type"], 0);
                _gLib._VerifySyncUDWin("Description", this.wParameters.wDescription.txtDescription, dic["Description"], 0);
                _gLib._VerifySyncUDWin("Ultimate", this.wParameters.wUltimate.rdUltimate, dic["Ultimate"], 0);
                _gLib._VerifySyncUDWin("Generational", this.wParameters.wGenerational.rdGenerational, dic["Generational"], 0);
                _gLib._VerifySyncUDWin("TwoDimensional", this.wParameters.wTwoDimensional.rdTwoDimensional, dic["TwoDimensional"], 0);
                _gLib._VerifySyncUDWin("Index1_Index", this.wParameters.wIndex1_Index.cbo, dic["Index1_Index"], 0);
                _gLib._VerifySyncUDWin("Index1_From", this.wParameters.wIndex1_From.txt, dic["Index1_From"], 0);
                _gLib._VerifySyncUDWin("Index1_To", this.wParameters.wIndex1_To.txt, dic["Index1_To"], 0);
                _gLib._VerifySyncUDWin("Extend", this.wParameters.wExtend.rdExtend, dic["Extend"], 0);
                _gLib._VerifySyncUDWin("Zero", this.wParameters.wZero.rdZero, dic["Zero"], 0);
                _gLib._VerifySyncUDWin("SameRatesUsed", this.wParameters.wSameRatesUsed.chkSameRatesUsed, dic["SameRatesUsed"], 0);
                _gLib._VerifySyncUDWin("Format", this.wParameters.wFormat.cboFormat, dic["Format"], 0);
                _gLib._VerifySyncUDWin("DecimalPlaces", this.wParameters.wDecimalPlaces.txt, dic["DecimalPlaces"], 0);
                _gLib._VerifySyncUDWin("OK", this.wParameters.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Oct-30 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("IAgreeToUnlock", "True");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_CascadingUnlock(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CascadingUnlock(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_CascadingUnlock";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("IAgreeToUnlock", this.wCascadingUnlock.wIAgreeToUnlock.chkIAgreeToUnlock, dic["IAgreeToUnlock"], 0);
                _gLib._SetSyncUDWin("OK", this.wCascadingUnlock.wOK.btnOK, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("IAgreeToUnlock", this.wCascadingUnlock.wIAgreeToUnlock.chkIAgreeToUnlock, dic["IAgreeToUnlock"], 0);
                _gLib._VerifySyncUDWin("OK", this.wCascadingUnlock.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Feb-25 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_UnlockFundingCalculator(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_UnlockFundingCalculator(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_UnlockFundingCalculator";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("OK", this.wUnlockFundingCalculator.wOK.btn, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("OK", this.wUnlockFundingCalculator.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }





        /// <summary>
        /// 2013-Sep-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Name", "RetirementScale07");
        ///    dic.Add("Type", "Retirement Decrements");
        ///    dic.Add("Description", "Copy from Canadian Sample Client");
        ///    dic.Add("Ultimate", "");
        ///    dic.Add("Generational", "");
        ///    dic.Add("TwoDimensional", "");
        ///    dic.Add("Index1_Index", "Age");
        ///    dic.Add("Index1_From", "55");
        ///    dic.Add("Index1_To", "65");
        ///    dic.Add("Extend", "");
        ///    dic.Add("Zero", "");
        ///    dic.Add("SameRatesUsed", "");
        ///    dic.Add("Format", "");
        ///    dic.Add("DecimalPlaces", "");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("sUnisexRates", "");
        ///    dic.Add("sMaleRates", "");
        ///    dic.Add("sFemaleRates", "");
        ///    pMain._ts_AddTable(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _ts_AddTable(MyDictionary dic)
        {
            string sFunctionName = "_ts_AddTable";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            MyDictionary dicTmp = new MyDictionary();
            dicTmp.Clear();
            dicTmp.Add("MenuItem_1", "File");
            dicTmp.Add("MenuItem_2", "Table Manager");
            this._MenuSelect(dicTmp);

            _gLib._SetSyncUDWin("Table Setup", this.wRetirementStudio.wTableSetup_FPGrid.grid, "Click", 0, false, 100, 30);

            Mouse.Click(this.wRetirementStudio.wTableSetup_FPGrid.grid, MouseButtons.Right, ModifierKeys.None, new Point(100, 30));
            WinWindow wWin = new WinWindow();
            wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "DropDown");
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains);
            wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

            if (_gLib._Exists("DropDown Menu Parent Win", wWin, 0))
            {
                dicTmp.Clear();
                dicTmp.Add("Level_1", "Add");
                _gLib._MenuSelectWin(0, wWin, dicTmp);

            }

            this._PopVerify_Parameters(dic);

            if (dic["sUnisexRates"] != "")
            {
                _gLib._TabPageSelectWin("Unisex Rates", this.wRetirementStudio.wEntrySetup_Tab, 0);
                this._EntrySetup_PasteRates(dic["sUnisexRates"]);
            }
            if (dic["sMaleRates"] != "")
            {
                _gLib._TabPageSelectWin("Male Rates", this.wRetirementStudio.wEntrySetup_Tab, 0);
                this._EntrySetup_PasteRates(dic["sMaleRates"]);
            }
            if (dic["sFemaleRates"] != "")
            {
                _gLib._TabPageSelectWin("Female Rates", this.wRetirementStudio.wEntrySetup_Tab, 0);
                this._EntrySetup_PasteRates(dic["sFemaleRates"]);
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        private void _EntrySetup_PasteRates(string sRates)
        {
            string sFunctionName = "_EntrySetup_PasteRates";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("EntrySetup table", this.wRetirementStudio.wEntrySetup_FPGrid.grid, "Click", 0, false, 90, 27);
            if (_gLib._Exists("Rates edit", this.wRetirementStudio.wEntrySetup_Rates.txtRates, 1, false))
            {
                _gLib._SetSyncUDWin_ByClipboard("Rates edit", this.wRetirementStudio.wEntrySetup_Rates.txtRates, sRates, 0, false, false);
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
        ///    dic.Add("OK", "click");
        ///    this._PopVerify_wSnapshotRepublished_Popup(dic); 
        /// </summary>
        /// <param name="dic"></param>
        private void _PopVerify_wSnapshotRepublished_Popup(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_wSnapshotRepublished_Popup";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wSnapshotRepublished.wOK.btnOK, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wSnapshotRepublished.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Nov-16 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "click");
        ///    pMain._PopVerify_RunSpecialPaymentTool_CA(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_RunSpecialPaymentTool_CA(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_RunSpecialPaymentTool_CA";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wFundingCalculationRunCompleted.wOK.btnOK, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wRunSpecialPaymentTool_CA.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Dec-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Client", "");
        ///    dic.Add("Plan", "");
        ///    dic.Add("ServiceType", "FundingValuations");
        ///    dic.Add("ServiceInstance", "July 2006 Valuation");
        ///    dic.Add("iTableItemIndex", "1");
        ///    dic.Add("CopyAllParameters", "");
        ///    dic.Add("CopyParameterChanges", "");
        ///    dic.Add("OK", "click");
        ///    pMain._PopVerify_CopyProvisionSet(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CopyProvisionSet(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_CopyProvisionSet";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Client", this.wCopyProvisionSet.wClient.cbo, dic["Client"], 0);
                _gLib._SetSyncUDWin("Plan", this.wCopyProvisionSet.wPlan.cbo, dic["Plan"], 0);
                _gLib._SetSyncUDWin("ServiceType", this.wCopyProvisionSet.wServiceType.cbo, dic["ServiceType"], 0);
                _gLib._SetSyncUDWin("ServiceInstance", this.wCopyProvisionSet.wServiceInstance.cbo, dic["ServiceInstance"], 0);

                if (dic["iTableItemIndex"] != "")
                {
                    int iIndex = Convert.ToInt32(dic["iTableItemIndex"]);
                    int iPosX = 15;
                    int iPosY = iIndex * 20 + 10;
                    _gLib._SetSyncUDWin("Table", this.wCopyProvisionSet.wService_FPGrid.grid, "Click", 0, false, iPosX, iPosY);
                }

                _gLib._SetSyncUDWin("CopyAllParameters", this.wCopyProvisionSet.wCopyAllParameters.rd, dic["CopyAllParameters"], 0);
                _gLib._SetSyncUDWin("CopyParameterChanges", this.wCopyProvisionSet.wCopyParameterChanges.rd, dic["CopyParameterChanges"], 0);
                _gLib._SetSyncUDWin("OK", this.wCopyProvisionSet.wOK.btn, dic["OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("OK", this.wSnapshotRepublished.wOK.btnOK, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Apr-2 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Client", Config.sClientName);
        ///    dic.Add("Plan", Config.sPlanName);
        ///    dic.Add("ServiceInstance", "Val2012");
        ///    dic.Add("ValuationNode", "Baseline");
        ///    dic.Add("VOShortName", "Jub1");
        ///    dic.Add("OK", "click");
        ///    pMain._PopVerify_CopyProvisionSet_DE(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CopyProvisionSet_DE(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_CopyProvisionSet_DE";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Client", this.wCopyProvisionSet.wClient_DE.cbo, dic["Client"], 0);
                _gLib._SetSyncUDWin("Plan", this.wCopyProvisionSet.wPlan_DE.cbo, dic["Plan"], 0);
                _gLib._SetSyncUDWin("ServiceInstance", this.wCopyProvisionSet.wServiceInstance_DE.cbo, dic["ServiceInstance"], 0);
                _gLib._SetSyncUDWin("ValuationNode", this.wCopyProvisionSet.wValuationNode_DE.cbo, dic["ValuationNode"], 0);
                _gLib._SetSyncUDWin("VOShortName", this.wCopyProvisionSet.wVOShortName_DE.cbo, dic["VOShortName"], 0);
                _gLib._SetSyncUDWin("OK", this.wCopyProvisionSet.wOK.btn, dic["OK"], 0);

                for (int i = 1; i < 30; i++)
                    if (_gLib._Exists("CopyProvisionSet", this.wCopyProvisionSet, 3, false))
                        _gLib._Wait(1);
                    else
                        break;
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Client", this.wCopyProvisionSet.wClient_DE.cbo, dic["Client"], 0);
                _gLib._VerifySyncUDWin("Plan", this.wCopyProvisionSet.wPlan_DE.cbo, dic["Plan"], 0);
                _gLib._VerifySyncUDWin("ServiceInstance", this.wCopyProvisionSet.wServiceInstance_DE.cbo, dic["ServiceInstance"], 0);
                _gLib._VerifySyncUDWin("ValuationNode", this.wCopyProvisionSet.wValuationNode_DE.cbo, dic["ValuationNode"], 0);
                _gLib._VerifySyncUDWin("VOShortName", this.wCopyProvisionSet.wVOShortName_DE.cbo, dic["VOShortName"], 0);
                _gLib._VerifySyncUDWin("OK", this.wCopyProvisionSet.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-June-26
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Client", Config.sClientName);
        ///    dic.Add("Plan", Config.sPlanName);
        ///    dic.Add("ServiceType", "");
        ///    dic.Add("ServiceInstance", "");
        ///    dic.Add("ValuationNode", "");
        ///    dic.Add("BenefitSet", "AllMembers");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_CopyProvisionSet_UK(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CopyProvisionSet_UK(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_CopyProvisionSet_UK";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Client", this.wCopyProvisionSet.wClient_UK.cbo, dic["Client"], 0);
                _gLib._SetSyncUDWin("Plan", this.wCopyProvisionSet.wPlan_UK.cbo, dic["Plan"], 0);
                _gLib._SetSyncUDWin("ServiceType", this.wCopyProvisionSet.wServiceType_UK.cbo, dic["ServiceType"], 0);
                _gLib._SetSyncUDWin("ServiceInstance", this.wCopyProvisionSet.wServiceInstance_UK.cbo, dic["ServiceInstance"], 0);
                _gLib._SetSyncUDWin("ValuationNode", this.wCopyProvisionSet.wValuationNode_UK.cbo, dic["ValuationNode"], 0);
                _gLib._SetSyncUDWin("BenefitSet", this.wCopyProvisionSet.wBenefitSet_UK.cbo, dic["BenefitSet"], 0);
                _gLib._SetSyncUDWin("OK", this.wCopyProvisionSet.wOK.btn, dic["OK"], 0);

                for (int i = 1; i < 30; i++)
                    if (_gLib._Exists("CopyProvisionSet", this.wCopyProvisionSet, 3, false))
                        _gLib._Wait(1);
                    else
                        break;
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Client", this.wCopyProvisionSet.wClient_UK.cbo, dic["Client"], 0);
                _gLib._VerifySyncUDWin("Plan", this.wCopyProvisionSet.wPlan_UK.cbo, dic["Plan"], 0);
                _gLib._VerifySyncUDWin("ServiceType", this.wCopyProvisionSet.wServiceType_UK.cbo, dic["ServiceType"], 0);
                _gLib._VerifySyncUDWin("ServiceInstance", this.wCopyProvisionSet.wServiceInstance_UK.cbo, dic["ServiceInstance"], 0);
                _gLib._VerifySyncUDWin("ValuationNode", this.wCopyProvisionSet.wValuationNode_UK.cbo, dic["ValuationNode"], 0);
                _gLib._VerifySyncUDWin("BenefitSet", this.wCopyProvisionSet.wBenefitSet_UK.cbo, dic["BenefitSet"], 0);
                _gLib._VerifySyncUDWin("OK", this.wCopyProvisionSet.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Dec-25
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Yes", "Click");
        ///    pMain._PopVerify_ActuarialReport(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ActuarialReport(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ActuarialReport";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Yes", this.wActuarialReport.wYes.btn, dic["Yes"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Yes", this.wActuarialReport.wYes.btn, dic["Yes"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2014-Aug-25
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Object", "Main.RunOption");
        ///    dic.Add("optiTimeout", "");
        ///    pMain._ObjectExist(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public Boolean _ObjectExist(MyDictionary dic)
        {
            Boolean bExist = false;
            int iTimeout = 600;
            WinControl wctl = null;

            if (dic["optiTimeout"] != "")
                iTimeout = Int32.Parse(dic["optiTimeout"]);

            switch (dic["Object"])
            {
                case "Main.RunOption":
                    wctl = this.wRunOptions;
                    break;
                case "Main.ValNodeProperties":
                    wctl = this.wValNodeProperties;
                    break;
                default:
                    break;
            }


            bExist = _gLib._Exists(dic["Object"], wctl, iTimeout);

            return bExist;

        }

        /// <summary>
        /// 2014-ASepug-25
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Object", "TestCaseLibrary.TestCaseViewer.ViewTestCaseInExcel");
        ///    dic.Add("optiTimeout", "");
        ///    pMain._ObjectEnabled(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public Boolean _ObjectEnabled(MyDictionary dic)
        {
            Boolean bEnabled = false;
            int iTimeout = 600;
            WinControl wctl = null;


            if (dic["optiTimeout"] != "")
                iTimeout = Int32.Parse(dic["optiTimeout"]);

            switch (dic["Object"])
            {
                case "TestCaseLibrary.TestCaseViewer.ViewTestCaseInExcel":
                    TestCaseLibrary tcl = new TestCaseLibrary();
                    wctl = tcl.wTestCaseViewer.wViewTestCaseInExcel.txt.link;
                    break;
                default:
                    break;
            }

            bEnabled = _gLib._Enabled(dic["Object"], wctl, iTimeout);

            return bEnabled;
        }


        /// <summary>
        /// 2015-Marr-18
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("TeilbereichName", "DEPlan");
        ///    dic.Add("DefaultValuationDate", "31.12");
        ///    dic.Add("Memo", "");
        ///    dic.Add("Confidential", "");
        ///    dic.Add("PublicSectorProjection", "");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_PMTool_TeilbereichAlle(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PMTool_TeilbereichAlle(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PMTool_TeilbereichAlle";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("TeilbereichName", this.wPMTool_TeilbereichAlle.wTeilbereichName.txt, dic["TeilbereichName"], 0);
                _gLib._SetSyncUDWin("DefaultValuationDate", this.wPMTool_TeilbereichAlle.wDefaultValuationDate.txt, dic["DefaultValuationDate"], 0);
                _gLib._SetSyncUDWin("Memo", this.wPMTool_TeilbereichAlle.wMemo.txt, dic["Memo"], 0);
                _gLib._SetSyncUDWin("Confidential", this.wPMTool_TeilbereichAlle.wConfidential.chk, dic["Confidential"], 0);
                _gLib._SetSyncUDWin("PublicSectorProjection", this.wPMTool_TeilbereichAlle.wPublicSectorProjection.chk, dic["PublicSectorProjection"], 0);
                _gLib._SetSyncUDWin("OK", this.wPMTool_TeilbereichAlle.wOK.btn, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("TeilbereichName", this.wPMTool_TeilbereichAlle.wTeilbereichName.txt, dic["TeilbereichName"], 0);
                _gLib._VerifySyncUDWin("DefaultValuationDate", this.wPMTool_TeilbereichAlle.wDefaultValuationDate.txt, dic["DefaultValuationDate"], 0);
                _gLib._VerifySyncUDWin("Memo", this.wPMTool_TeilbereichAlle.wMemo.txt, dic["Memo"], 0);
                _gLib._VerifySyncUDWin("Confidential", this.wPMTool_TeilbereichAlle.wConfidential.chk, dic["Confidential"], 0);
                _gLib._VerifySyncUDWin("PublicSectorProjection", this.wPMTool_TeilbereichAlle.wPublicSectorProjection.chk, dic["PublicSectorProjection"], 0);
                _gLib._VerifySyncUDWin("OK", this.wPMTool_TeilbereichAlle.wOK.btn, dic["OK"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Marr-18
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("EnterVOShortName", "Jub1");
        ///    dic.Add("ConfirmVOShortName", "Jub1");
        ///    dic.Add("VOLongName", "Jubilee 1");
        ///    dic.Add("VOClass", "Jubilee");
        ///    dic.Add("FundingVehicle", "Direct Promise");
        ///    dic.Add("TypeOfPromise", "Defined Benefit");
        ///    dic.Add("Sponsor", "Employer");
        ///    dic.Add("PSVCoverage", "True");
        ///    dic.Add("ExculdeWidowers", "");
        ///    dic.Add("Tax", "True");
        ///    dic.Add("Trade", "True");
        ///    dic.Add("InternationalAccounting", "True");
        ///    dic.Add("Apply30g", "True");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_CreateNewVO(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CreateNewVO(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_CreateNewVO";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("EnterVOShortName", this.wCreateNewVO.wEnterVOShortName.txt, dic["EnterVOShortName"], 0);
                _gLib._SetSyncUDWin("ConfirmVOShortName", this.wCreateNewVO.wConfirmVOShortName.txt, dic["ConfirmVOShortName"], 0);
                _gLib._SetSyncUDWin("VOLongName", this.wCreateNewVO.wVOLongName.txt, dic["VOLongName"], 0);
                _gLib._SetSyncUDWin("VOClass", this.wCreateNewVO.wVOClass.cbo, dic["VOClass"], 0);
                _gLib._SetSyncUDWin("FundingVehicle", this.wCreateNewVO.wFundingVehicle.cbo, dic["FundingVehicle"], 0);
                _gLib._SetSyncUDWin("TypeOfPromise", this.wCreateNewVO.wTypeOfPromise.cbo, dic["TypeOfPromise"], 0);
                _gLib._SetSyncUDWin("Sponsor", this.wCreateNewVO.wSponsor.cbo, dic["Sponsor"], 0);
                _gLib._SetSyncUDWin("PSVCoverage", this.wCreateNewVO.wPSVCoverage.chk, dic["PSVCoverage"], 0);
                _gLib._SetSyncUDWin("ExculdeWidowers", this.wCreateNewVO.wExculdeWidowers.chk, dic["ExculdeWidowers"], 0);
                _gLib._SetSyncUDWin("Tax", this.wCreateNewVO.wTax.chk, dic["Tax"], 0);
                _gLib._SetSyncUDWin("Trade", this.wCreateNewVO.wTrade.chk, dic["Trade"], 0);
                _gLib._SetSyncUDWin("InternationalAccounting", this.wCreateNewVO.wInternationalAccounting.chk, dic["InternationalAccounting"], 0);
                _gLib._SetSyncUDWin("Apply30g", this.wCreateNewVO.wApply30g.chk, dic["Apply30g"], 0);
                _gLib._SetSyncUDWin("OK", this.wCreateNewVO.wOK.btn, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("EnterVOShortName", this.wCreateNewVO.wEnterVOShortName.txt, dic["EnterVOShortName"], 0);
                _gLib._VerifySyncUDWin("ConfirmVOShortName", this.wCreateNewVO.wConfirmVOShortName.txt, dic["ConfirmVOShortName"], 0);
                _gLib._VerifySyncUDWin("VOLongName", this.wCreateNewVO.wVOLongName.txt, dic["VOLongName"], 0);
                _gLib._VerifySyncUDWin("VOClass", this.wCreateNewVO.wVOClass.cbo, dic["VOClass"], 0);
                _gLib._VerifySyncUDWin("FundingVehicle", this.wCreateNewVO.wFundingVehicle.cbo, dic["FundingVehicle"], 0);
                _gLib._VerifySyncUDWin("TypeOfPromise", this.wCreateNewVO.wTypeOfPromise.cbo, dic["TypeOfPromise"], 0);
                _gLib._VerifySyncUDWin("Sponsor", this.wCreateNewVO.wSponsor.cbo, dic["Sponsor"], 0);
                _gLib._VerifySyncUDWin("PSVCoverage", this.wCreateNewVO.wPSVCoverage.chk, dic["PSVCoverage"], 0);
                _gLib._VerifySyncUDWin("ExculdeWidowers", this.wCreateNewVO.wExculdeWidowers.chk, dic["ExculdeWidowers"], 0);
                _gLib._VerifySyncUDWin("Tax", this.wCreateNewVO.wTax.chk, dic["Tax"], 0);
                _gLib._VerifySyncUDWin("Trade", this.wCreateNewVO.wTrade.chk, dic["Trade"], 0);
                _gLib._VerifySyncUDWin("InternationalAccounting", this.wCreateNewVO.wInternationalAccounting.chk, dic["InternationalAccounting"], 0);
                _gLib._VerifySyncUDWin("Apply30g", this.wCreateNewVO.wApply30g.chk, dic["Apply30g"], 0);
                _gLib._VerifySyncUDWin("OK", this.wCreateNewVO.wOK.btn, dic["OK"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-June-10
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("EnterShortName", "AllMembers");
        ///    dic.Add("ConfirmShortName", "AllMembers");
        ///    dic.Add("LongName", "AllMembers");
        ///    pMain._ts_CreateNewBenefitSet(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _ts_CreateNewBenefitSet(MyDictionary dic)
        {
            string sFunctionName = "_ts_CreateNewBenefitSet";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("AddVOtoRegistry", this.wRetirementStudio.wAddVOtoRegistry.btn_UK, "Click", 0);
            _gLib._SetSyncUDWin("EnterShortName", this.wCreateNewBenefitSet.wEnterShortName.txt, dic["EnterShortName"], 0);
            _gLib._SetSyncUDWin("ConfirmShortName", this.wCreateNewBenefitSet.wConfirmShortName.txt, dic["ConfirmShortName"], 0);
            _gLib._SetSyncUDWin("LongName", this.wCreateNewBenefitSet.wLongName.txt, dic["LongName"], 0);
            _gLib._SetSyncUDWin("OK", this.wCreateNewBenefitSet.wOK.btn, "Click", 0);




            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2013-Apr-12 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("VerifyExists", "False");
        ///    pMain._Handle_DependencyManager(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Handle_DependencyManager(MyDictionary dic)
        {
            string sFunctionName = "_Handle_DependencyManager";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["VerifyExists"].ToUpper() == "TRUE")
            {
                _gLib._SetSyncUDWin("ClearAll", this.wDependencyManager.wClearAll.btn, "Click", 0);
                _gLib._SetSyncUDWin("OK", this.wDependencyManager.wOK.btn, "Click", 0);
                _gLib._SetSyncUDWin("OK", this.wDependencyManager_Popup.wOK.btn, "Click", 0);
            }
            else
            {
                if (_gLib._Exists("DependencyManager", this.wDependencyManager.wOK.btn, 5, false))
                {
                    _gLib._SetSyncUDWin("ClearAll", this.wDependencyManager.wClearAll.btn, "Click", 0);
                    _gLib._SetSyncUDWin("", this.wDependencyManager.wOK.btn, "Click", 0);
                    _gLib._SetSyncUDWin("OK", this.wDependencyManager_Popup.wOK.btn, "Click", 0);
                }

            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2015-June-28
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ServiceType", "");
        ///    dic.Add("ServiceInstance", "");
        ///    dic.Add("iItemIndex", "1");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_CopyParticipantDataSet(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CopyParticipantDataSet(MyDictionary dic)
        {


            string sFunctionName = "_PopVerify_CopyParticipantDataSet";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iIndex = Convert.ToInt32(dic["iItemIndex"]);

            int iX = 40;
            int iY = 10 + iIndex * 20;

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("ServiceType", this.wCopyParticipantDataSet.wServiceType.cbo, dic["ServiceType"], 0);
                _gLib._SetSyncUDWin("ServiceInstance", this.wCopyParticipantDataSet.wServiceInstance.cbo, dic["ServiceInstance"], 0);
                _gLib._SetSyncUDWin("CopyParticipantData", this.wCopyParticipantDataSet.wCopyParticipantData.chk, "True", 0);
                _gLib._SetSyncUDWin("FPGrid", this.wCopyParticipantDataSet.wFPGrid.grid, "Click", 0, false, iX, iY);

                _gLib._SetSyncUDWin("OK", this.wCopyProvisionSet.wOK.btn, dic["OK"], 0);

                if (_gLib._Exists("CopyParticipantDataSetWarning", this.wCopyParticipantDataWarning, 3, false))
                    _gLib._SetSyncUDWin("OK", this.wCopyParticipantDataWarning.wOK.btn, "Click", 0);


                for (int i = 1; i < 30; i++)
                    if (_gLib._Exists("CopyParticipantDataSet", this.wCopyParticipantDataSet, 3, false))
                        _gLib._Wait(1);
                    else
                        break;
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Client", this.wCopyProvisionSet.wClient_UK.cbo, dic["Client"], 0);
                _gLib._VerifySyncUDWin("Plan", this.wCopyProvisionSet.wPlan_UK.cbo, dic["Plan"], 0);
                _gLib._VerifySyncUDWin("ServiceType", this.wCopyProvisionSet.wServiceType_UK.cbo, dic["ServiceType"], 0);
                _gLib._VerifySyncUDWin("ServiceInstance", this.wCopyProvisionSet.wServiceInstance_UK.cbo, dic["ServiceInstance"], 0);
                _gLib._VerifySyncUDWin("ValuationNode", this.wCopyProvisionSet.wValuationNode_UK.cbo, dic["ValuationNode"], 0);
                _gLib._VerifySyncUDWin("BenefitSet", this.wCopyProvisionSet.wBenefitSet_UK.cbo, dic["BenefitSet"], 0);
                _gLib._VerifySyncUDWin("OK", this.wCopyProvisionSet.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Julu-17 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Client", "QA DE Benchmark 001 Existing DNT");
        ///    dic.Add("Plan", "Alle - QA DE Benchmark 001 Existing DNT Plan");
        ///    dic.Add("Service", "Conversion 2008");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_CopyServiceSchemaAndProperties(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_CopyServiceSchemaAndProperties(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_CopyServiceSchemaAndProperties";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Client", this.wCopyServiceSchemaAndProperties.wClients.cbo, dic["Client"], 0);
                _gLib._SetSyncUDWin("Plan", this.wCopyServiceSchemaAndProperties.wPlans.cbo, dic["Plan"], 0);

                switch (dic["Service"])
                {
                    case "Jubilee 2009":
                        _gLib._SetSyncUDWin("Jubilee 2009", this.wCopyServiceSchemaAndProperties.wService_Grid.tbl.row1.cellJubilee2009, "Click", 0, false, 100, 6);
                        break;
                    case "Jubilee 2008":
                        _gLib._SetSyncUDWin("Jubilee 2008", this.wCopyServiceSchemaAndProperties.wService_Grid.tbl.row2.cellJubilee2008, "Click", 0, false, 100, 6);
                        break;
                    case "Pension 2009":
                        _gLib._SetSyncUDWin("Pension 2009", this.wCopyServiceSchemaAndProperties.wService_Grid.tbl.row3.cellPension2009, "Click", 0, false, 100, 6);
                        break;
                    case "Conversion 2008":
                        _gLib._SetSyncUDWin("Conversion 2008", this.wCopyServiceSchemaAndProperties.wService_Grid.tbl.row4.cellConversion2008, "Click", 0, false, 100, 6);
                        break;
                    default:
                        _gLib._MsgBoxYesNo("Warning!", "Input Service <" + dic["Service"] + "> Not available in coding! Please contact Webber.ling@mercer.com");
                        break;

                }

                _gLib._SetSyncUDWin("OK", this.wCopyServiceSchemaAndProperties.wOK.btn, dic["OK"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("Warning", "No Verify codes.");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 
        /// 2015-July-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("sTableType", "Interest");
        ///    dic.Add("AssumptionDefinition", "Interest");
        ///    dic.Add("sIntAcc", "True");
        ///    dic.Add("sTrade", "True");
        ///    dic.Add("sTax", "True");
        ///    pMain._TBL_Sensitivity(dic); 
        /// </summary>
        /// <param name="?"></param>
        public void _TBL_Sensitivity(MyDictionary dic)
        {
            string sFunctionName = "_BenefitsToValueForWindUp";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            WinClient grid = new WinClient();

            switch (dic["sTableType"])
            {
                case "Interest":
                    grid = this.wAddSensitivityValuationNode.wInterest_FPGrid.grid;
                    break;
                case "Pay":
                    grid = this.wAddSensitivityValuationNode.wPay_FPGrid.grid;
                    break;
                case "Pension":
                    grid = this.wAddSensitivityValuationNode.wPension_FPGrid.grid;
                    break;
                case "Mortality":
                    grid = this.wAddSensitivityValuationNode.wMortality_FPGrid.grid;
                    break;
                default:
                    _gLib._MsgBox("Warning!", "Input TableType <" + dic["sTableType"] + "> is NOT valid!");
                    break;

            }

            _gLib._SetSyncUDWin("table", grid, "Click", 0, false, 100, 28);

            if (dic["AssumptionDefinition"] != "")
            {
                string sFirstChar = dic["AssumptionDefinition"].Substring(0, 1);
                _gLib._SendKeysUDWin("table", grid, sFirstChar);
                _gLib._SetSyncUDWin("AssumptionDefinition", this.wAddSensitivityValuationNode.wCommon_cbo.cbo, dic["AssumptionDefinition"], 0);

                _gLib._SendKeysUDWin("", grid, "{Tab}", 0, ModifierKeys.Shift, false);
            }

            if (dic["sIntAcc"] != "")
            {

                _gLib._SendKeysUDWin("table", grid, "{Tab}");
                string sAct = _fp._ReturnSelectRowContent(grid);
                if (sAct.ToUpper() != dic["sIntAcc"].ToUpper())
                {
                    _gLib._SendKeysUDWin("table", grid, "{Space}");
                    _gLib._Wait(1);
                    sAct = _fp._ReturnSelectRowContent(grid);
                }
                if (sAct.ToUpper() != dic["sIntAcc"].ToUpper())
                {
                    _gLib._MsgBoxYesNo("Continue Testing?", "Failed to set <" + dic["sIntAcc"] + "> to <IntAcc> in table <" + dic["sTableType"] + ">.");
                    _gLib._Report(_PassFailStep.Fail, "Failed to set <" + dic["sIntAcc"] + "> to <IntAcc> in table <" + dic["sTableType"] + ">.");
                }
                _gLib._SendKeysUDWin("", grid, "{Tab}", 0, ModifierKeys.Shift, false);
            }
            if (dic["sTrade"] != "")
            {

                _gLib._SendKeysUDWin("table", grid, "{Tab}{Tab}");
                string sAct = _fp._ReturnSelectRowContent(grid);
                if (sAct.ToUpper() != dic["sTrade"].ToUpper())
                {
                    _gLib._SendKeysUDWin("table", grid, "{Space}");
                    _gLib._Wait(1);
                    sAct = _fp._ReturnSelectRowContent(grid);
                }
                if (sAct.ToUpper() != dic["sTrade"].ToUpper())
                {
                    _gLib._MsgBoxYesNo("Continue Testing?", "Failed to set <" + dic["sTrade"] + "> to <Trade> in table <" + dic["sTableType"] + ">.");
                    _gLib._Report(_PassFailStep.Fail, "Failed to set <" + dic["sTrade"] + "> to <Trade> in table <" + dic["sTableType"] + ">.");
                }
                _gLib._SendKeysUDWin("", grid, "{Tab}{Tab}", 0, ModifierKeys.Shift, false);
            }
            if (dic["sTax"] != "")
            {

                _gLib._SendKeysUDWin("table", grid, "{Tab}{Tab}{Tab}");
                string sAct = _fp._ReturnSelectRowContent(grid);
                if (sAct.ToUpper() != dic["sTax"].ToUpper())
                {
                    _gLib._SendKeysUDWin("table", grid, "{Space}");
                    _gLib._Wait(1);
                    sAct = _fp._ReturnSelectRowContent(grid);
                }
                if (sAct.ToUpper() != dic["sTax"].ToUpper())
                {
                    _gLib._MsgBoxYesNo("Continue Testing?", "Failed to set <" + dic["sTax"] + "> to <Tax> in table <" + dic["sTableType"] + ">.");
                    _gLib._Report(_PassFailStep.Fail, "Failed to set <" + dic["sTax"] + "> to <Tax> in table <" + dic["sTableType"] + ">.");
                }
                _gLib._SendKeysUDWin("", grid, "{Tab}{Tab}{Tab}", 0, ModifierKeys.Shift, false);
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends");

        }



        /// <summary>
        /// 2015-July-27
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Interest_IncreaseBy", "0,50");
        ///    dic.Add("Interest_DecreseBy", "0,50");
        ///    dic.Add("Pay_IncreaseBy", "0,50");
        ///    dic.Add("Pay_DecreseBy", "0,50");
        ///    dic.Add("Pension_IncreaseBy", "0,50");
        ///    dic.Add("Pension_DecreseBy", "0,50");
        ///    dic.Add("Mortality_IncreaseFactor", "");
        ///    dic.Add("Mortality_DecreseFactor", "");
        ///    dic.Add("Mortality_IncreaseSetBack", "");
        ///    dic.Add("Mortality_DecreseSetBack", "");
        ///    dic.Add("AddSensitivityNodes", "");
        ///    pMain._PopVerify_AddSensitivityValuationNode(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_AddSensitivityValuationNode(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_AddSensitivityValuationNode";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                this.wAddSensitivityValuationNode.wCommon_txt.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                if (dic["Interest_IncreaseBy"] != "")
                {
                    this.wAddSensitivityValuationNode.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "6");
                    _gLib._SetSyncUDWin_ByClipboard("Interest_IncreaseBy", this.wAddSensitivityValuationNode.wCommon_txt.txt, dic["Interest_IncreaseBy"], 0);
                }
                if (dic["Interest_DecreseBy"] != "")
                {
                    this.wAddSensitivityValuationNode.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "3");
                    _gLib._SetSyncUDWin_ByClipboard("Interest_DecreseBy", this.wAddSensitivityValuationNode.wCommon_txt.txt, dic["Interest_DecreseBy"], 0);
                }
                if (dic["Pay_IncreaseBy"] != "")
                {
                    this.wAddSensitivityValuationNode.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "4");
                    _gLib._SetSyncUDWin_ByClipboard("Pay_IncreaseBy", this.wAddSensitivityValuationNode.wCommon_txt.txt, dic["Pay_IncreaseBy"], 0);
                }
                if (dic["Pay_DecreseBy"] != "")
                {
                    this.wAddSensitivityValuationNode.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "1");
                    _gLib._SetSyncUDWin_ByClipboard("Pay_DecreseBy", this.wAddSensitivityValuationNode.wCommon_txt.txt, dic["Pay_DecreseBy"], 0);
                }
                if (dic["Pension_IncreaseBy"] != "")
                {
                    this.wAddSensitivityValuationNode.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "5");
                    _gLib._SetSyncUDWin_ByClipboard("Pension_IncreaseBy", this.wAddSensitivityValuationNode.wCommon_txt.txt, dic["Pension_IncreaseBy"], 0);
                }
                if (dic["Pension_DecreseBy"] != "")
                {
                    this.wAddSensitivityValuationNode.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                    _gLib._SetSyncUDWin_ByClipboard("Pension_DecreseBy", this.wAddSensitivityValuationNode.wCommon_txt.txt, dic["Pension_DecreseBy"], 0);
                }
                if (dic["Mortality_IncreaseFactor"] != "")
                {
                    this.wAddSensitivityValuationNode.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "7");
                    _gLib._SetSyncUDWin_ByClipboard("Mortality_IncreaseFactor", this.wAddSensitivityValuationNode.wCommon_txt.txt, dic["Mortality_IncreaseFactor"], 0);
                }
                if (dic["Mortality_DecreseFactor"] != "")
                {
                    this.wAddSensitivityValuationNode.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "8");
                    _gLib._SetSyncUDWin_ByClipboard("Mortality_DecreseFactor", this.wAddSensitivityValuationNode.wCommon_txt.txt, dic["Mortality_DecreseFactor"], 0);
                }
                if (dic["Mortality_IncreaseSetBack"] != "")
                {
                    this.wAddSensitivityValuationNode.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "9");
                    _gLib._SetSyncUDWin_ByClipboard("Mortality_IncreaseSetBack", this.wAddSensitivityValuationNode.wCommon_txt.txt, dic["Mortality_IncreaseSetBack"], 0);
                }
                if (dic["Mortality_DecreseSetBack"] != "")
                {
                    this.wAddSensitivityValuationNode.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "10");
                    _gLib._SetSyncUDWin_ByClipboard("Mortality_DecreseSetBack", this.wAddSensitivityValuationNode.wCommon_txt.txt, dic["Mortality_DecreseSetBack"], 0);
                }



                _gLib._SetSyncUDWin("AddSensitivityNodes", this.wAddSensitivityValuationNode.wAddSensitivityNodes.btn, dic["AddSensitivityNodes"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._MsgBox("warning!", "No Verify codes!");


            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-July-31 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AllLiabilityTypes", "False");
        ///    dic.Add("Funding", "True");
        ///    dic.Add("AddRow", "Click");
        ///    dic.Add("OK", "");
        ///    pMain._PopVerify_IndividualOutputFieldDefinition(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IndividualOutputFieldDefinition(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_IndividualOutputFieldDefinition";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("AllLiabilityTypes", this.wIndividualOutputFieldDefinition.wLiabilityTypes.list.chkAllLiabilityTypes, dic["AllLiabilityTypes"], 0);
                _gLib._SetSyncUDWin("Funding", this.wIndividualOutputFieldDefinition.wLiabilityTypes.list.chkFunding, dic["Funding"], 0);
                _gLib._SetSyncUDWin("AddRow", this.wIndividualOutputFieldDefinition.wAddRow.btn, dic["AddRow"], 0);
                _gLib._SetSyncUDWin("OK", this.wIndividualOutputFieldDefinition.wOK.btn, dic["OK"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("AllLiabilityTypes", this.wIndividualOutputFieldDefinition.wLiabilityTypes.list.chkAllLiabilityTypes, dic["AllLiabilityTypes"], 0);
                _gLib._VerifySyncUDWin("Funding", this.wIndividualOutputFieldDefinition.wLiabilityTypes.list.chkFunding, dic["Funding"], 0);
                _gLib._VerifySyncUDWin("AddRow", this.wIndividualOutputFieldDefinition.wAddRow.btn, dic["AddRow"], 0);
                _gLib._VerifySyncUDWin("OK", this.wIndividualOutputFieldDefinition.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-July-31 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("BenefitSet", "All");
        ///    dic.Add("OutputLabel", "PU1pcPayroll");
        ///    pMain._TBL_IndividualOututFieldDefinition_OutputFields(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _TBL_IndividualOututFieldDefinition_OutputFields(MyDictionary dic)
        {
            string sFunctionName = "_TBL_IndividualOututFieldDefinition_OutputFields";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("Grid", this.wIndividualOutputFieldDefinition.wFPGrid_OutputFields.grid, "Click", 0, false, 100, 30);

            if (dic["BenefitSet"] != "")
                _gLib._SetSyncUDWin("BenefitSet", this.wIndividualOutputFieldDefinition.wCommon_cbo.cbo, dic["BenefitSet"], 0);

            if (dic["OutputLabel"] != "")
            {
                string sKeys = "";
                for (int i = 1; i <= 17; i++)
                    sKeys = sKeys + "{Up}";

                _gLib._SendKeysUDWin("Grid", this.wIndividualOutputFieldDefinition.wFPGrid_OutputFields.grid, "{Tab}", false);
                _gLib._SetSyncUDWin("Grid", this.wIndividualOutputFieldDefinition.wFPGrid_OutputFields.grid, "Click", 0, false, 360, 30);
                _gLib._SendKeysUDWin("Grid", this.wIndividualOutputFieldDefinition.wCommon_cbo.cbo, "Q", false);
                _gLib._SendKeysUDWin("Grid", this.wIndividualOutputFieldDefinition.wCommon_cbo.cbo, sKeys, false);
                _gLib._SetSyncUDWin("OutputLabel", this.wIndividualOutputFieldDefinition.wCommon_cbo.cbo, dic["OutputLabel"], 0);
                _gLib._VerifySyncUDWin("OutputLabel", this.wIndividualOutputFieldDefinition.wCommon_cbo.cbo, dic["OutputLabel"], 0);
                _gLib._SendKeysUDWin("Grid", this.wIndividualOutputFieldDefinition.wFPGrid_OutputFields.grid, "{Tab}", false);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }





        /// <summary>
        /// 2015-Aug-03 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Process", "Click");
        ///    dic.Add("OK", "");
        ///    pMain._PopVerify_ParameterPrintComparison(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ParameterPrintComparison(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ParameterPrintComparison";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Process", this.wParameterPrintComparison.wProcess.btn, dic["Process"], 0);
                _gLib._SetSyncUDWin("OK", this.wParameterPrintComparison.wOK.btn, dic["OK"], 0);
                ////if (dic["OK"] != "")
                ////{

                ////    if (_gLib._Exists("PDFMustBeCreated", this.wPDFMustBeCreated, Config.iTimeout / 3, false))
                ////    {

                ////        dic.Clear();
                ////        dic.Add("PopVerify", "Pop");
                ////        dic.Add("OK", "Click");
                ////        dic.Add("Cancel", "");
                ////        this._PopVerify_PDFMustBeCreated(dic);

                ////    }
                ////}


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Process", this.wParameterPrintComparison.wProcess.btn, dic["Process"], 0);
                _gLib._VerifySyncUDWin("OK", this.wParameterPrintComparison.wOK.btn, dic["OK"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-Aug-03 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", Config.sPlanName);
        ///    dic.Add("Level_2", "FundingValuations");
        ///    dic.Add("Level_3", "Valuation2012");
        ///    dic.Add("Level_4", "Fix Solv age diff");
        ///    pMain._ParameterPrint_TreeviewSelect(dic, "Node2"); 
        /// </summary>
        /// <param name="dic"></param>
        public void _ParameterPrint_TreeviewSelect(MyDictionary dic, string sNode)
        {
            string sFunctionName = "_ParameterPrint_TreeviewSelect";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            UITestControl wTreeView;

            if (sNode.ToUpper().Equals("NODE1"))
                wTreeView = this.wParameterPrintComparison.wTreeNode1;
            else
                wTreeView = this.wParameterPrintComparison.wTreeNode2_;


            _gLib._TreeViewSelectWin(0, wTreeView, dic);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }



        /// <summary>
        /// 2015-Aug-03 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Cancel", "");
        ///    pMain._PopVerify_PDFMustBeCreated(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PDFMustBeCreated(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PDFMustBeCreated";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("OK", this.wPDFMustBeCreated.wOK.btn, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wPDFMustBeCreated.wCancel.btn, dic["Cancel"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("OK", this.wPDFMustBeCreated.wOK.btn, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wPDFMustBeCreated.wCancel.btn, dic["Cancel"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2015-Aug-03 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iX", "");
        ///    dic.Add("iY", "");
        ///    dic.Add("AddNode", "");
        ///    dic.Add("NodeName", "");
        ///    dic.Add("OK", "");
        ///    pMain._PopVerify_ProvisionsProperties(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ProvisionsProperties(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ProvisionsProperties";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                int iX = Convert.ToInt32(dic["iX"]);
                int iY = Convert.ToInt32(dic["iY"]);

                _gLib._SetSyncUDWin("wFlowTree", this.wProvisionsProperties.wFlowTree.grid, "click", 0, false, iX, iY);


                if (dic["AddNode"] != "")
                {
                    Mouse.Click(this.wProvisionsProperties.wFlowTree.grid, MouseButtons.Right, ModifierKeys.None, new Point(iX, iY));

                    WinWindow wWin = new WinWindow();
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "DropDown");
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains);
                    wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

                    MyDictionary dicTmp = new MyDictionary();
                    dicTmp.Clear();
                    dicTmp.Add("Level_1", "Add Node");
                    _gLib._MenuSelectWin(0, wWin, dicTmp);

                    _gLib._SetSyncUDWin_ByClipboard("NodeName", this.wValNodeProperties.wValNodeName.BoxNodeName, dic["NodeName"], 0);
                    _gLib._SetSyncUDWin("OK", this.wValNodeProperties.wOK.btnOK, "click", 0);
                }

                _gLib._SetSyncUDWin("OK", this.wProvisionsProperties.wOK.btn, dic["OK"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-Mar-23 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iX", "");
        ///    dic.Add("iY", "");
        ///    dic.Add("OK", "");
        ///    pMain._PopVerify_MultipleNodeSelection(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_MultipleNodeSelection(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_MultipleNodeSelection";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                if (_gLib._Exists("", this.wMultipleNodeSelectio.wMultipleNodeSelectioTitleBar.btn, 3, false))
                    _gLib._SetSyncUDWin("", this.wMultipleNodeSelectio.wMultipleNodeSelectioTitleBar.btn, "click", 0);


                if (dic["iX"] != "" && dic["iY"] != "")
                {
                    int iX = Convert.ToInt32(dic["iX"]);
                    int iY = Convert.ToInt32(dic["iY"]);

                    _gLib._SetSyncUDWin("wFlowTree", this.wMultipleNodeSelectio.wFlowTree.grid, "click", 0, false, iX, iY);
                }


                _gLib._SetSyncUDWin("OK", this.wMultipleNodeSelectio.wOK.btn, dic["OK"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "function is not complete");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2016-Dec-15
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CheckCompatibility", "False");
        ///    dic.Add("Coninue", "Click");
        ///    pMain._PopVerify_MicrosoftExcelCompatibility(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_MicrosoftExcelCompatibility(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_MicrosoftExcelCompatibility";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("CheckCompatibility", this.wMicrosoftExcelCompatibility.w.chkCheckCompatibility, dic["CheckCompatibility"], 0);
                _gLib._SetSyncUDWin("Coninue", this.wMicrosoftExcelCompatibility.w.btnConinue, dic["Coninue"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("CheckCompatibility", this.wMicrosoftExcelCompatibility.w.chkCheckCompatibility, dic["CheckCompatibility"], 0);
                _gLib._VerifySyncUDWin("Coninue", this.wMicrosoftExcelCompatibility.w.btnConinue, dic["Coninue"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2016-Mar-23 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///     dic.Clear();
        ///     dic.Add("OK", "click");
        ///     pMain._SensitivityWaringHandle(dic); 
        ///     
        /// </summary>
        /// <param name="dic"></param>
        public void _SensitivityWaringHandle(MyDictionary dic)
        {
            _gLib._MsgBox("", "click OK to continue code, and even you can spy element add to code");
            //_gLib._SetSyncUDWin("SensitivityWaring", this.wSensitivityWarning.wOK.btn, dic["OK"], 0);
        }



        /// <summary>
        /// 2016-Mar-23 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///        dic.Clear();
        ///     dic.Add("OK", "click");
        ///     pMain._HandleRemoved(dic);
        ///     
        /// </summary>
        /// <param name="dic"></param>
        public void _HandleRemoved(MyDictionary dic)
        {
            _gLib._SetSyncUDWin("OK", this.wWord_Popup.wOK.btnOK, dic["OK"], 0);
        }



        public void _DeleteValService(MyDictionary dic)
        {

            string sFunctionName = "_DeleteValService";

            //////////dic.Clear();
            //////////dic.Add("Level_1", dic["Level_1"]);
            //////////dic.Add("Level_2", dic["Level_2"]);
            //////////dic.Add("Level_3", dic["Level_3"]);
            this._HomeTreeViewSelect_Favorites(0, dic);

            if (dic["ServiceToDelete"] != "")
            {
                Boolean bServiceSelected = false;

                int ixPos = 80;
                int iyPos = 30;
                int iyStep = 20;

                for (int i = 1; i <= 2; i++)
                {


                    this._SelectTab("Home");
                    ////////////_gLib._SetSyncUDWin("Home - Right Pane", this.wRetirementStudio.wHome_TableView.cHome_TableView, "Click", 0, false, ixPos, iyPos + iyStep * (i - 1));



                    try
                    {
                        Mouse.Click(this.wRetirementStudio.wHome_TableView.cHome_TableView, MouseButtons.Right, ModifierKeys.None, new Point(ixPos, iyPos + iyStep * (i - 1)));
                    }
                    catch (Exception ex)
                    {
                        _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to Right click on <Home Service Pane>. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right click on <Home Service Pane>. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    }

                    WinWindow wWin = new WinWindow();
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "DropDown");
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains);
                    wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

                    if (_gLib._Exists("DropDown Menu Parent Win", wWin, 2, false))
                    {
                        MyDictionary dicTmp = new MyDictionary();
                        dicTmp.Clear();
                        dicTmp.Add("Level_1", "Service Notes");
                        _gLib._MenuSelectWin(0, wWin, dicTmp);





                        string sInfo = this.wHome_ServiceNotes.wServiceInfo.txt.GetProperty("Name").ToString();
                        _gLib._SetSyncUDWin("ServiceNotes", this.wHome_ServiceNotes.wCancel.btn, "Click", 0);

                        if (sInfo.Contains(">>" + dic["ServiceToDelete"]))
                        {
                            bServiceSelected = true;


                            try
                            {
                                Mouse.Click(this.wRetirementStudio.wHome_TableView.cHome_TableView, MouseButtons.Right, ModifierKeys.None, new Point(ixPos, iyPos + iyStep * (i - 1)));
                            }
                            catch (Exception ex)
                            {
                                _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to Right click on <Home Service Pane>. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right click on <Home Service Pane>. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                            }

                            if (_gLib._Exists("DropDown Menu Parent Win", wWin, 0, true))
                            {

                                dicTmp.Clear();
                                dicTmp.Add("Level_1", "Delete");
                                _gLib._MenuSelectWin(0, wWin, dicTmp);

                                if (_gLib._Exists("Confirm", this.wHome_Confirm, 2, false))
                                {
                                    if (_gLib._Exists("Confirm", this.wHome_Confirm.wOK.btnOK, 1, false))
                                    {
                                        dicTmp.Clear();
                                        dicTmp.Add("PopVerify", "Pop");
                                        dicTmp.Add("OK", "Click");
                                        this._PopVerify_Home_Confrim(dicTmp);
                                    }
                                    if (_gLib._Exists("Confirm", this.wHome_Confirm.wYes.btnYes, 1, false))
                                    {
                                        dicTmp.Clear();
                                        dicTmp.Add("PopVerify", "Pop");
                                        dicTmp.Add("Yes", "Click");
                                        this._PopVerify_Home_Confrim(dicTmp);
                                    }
                                }
                                this._SelectTab("Home");
                                return;
                            }


                        }
                        else
                            continue;
                    }
                }
                if (!bServiceSelected)
                {
                    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  find  <" + dic["ServiceToDelete"] + ">. Please check input name!");
                    //////////////////_gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to find service <" + dic["ServiceToDelete"] + ">. Please check input name!");
                    return;
                }


            }

        }

        /// <summary>
        /// 2018-Oct-15 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("VerifyMsg", "True");
        ///    pMain._PopVerify_GroupJobSuccessfullyComplete(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GroupJobSuccessfullyComplete(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GroupJobSuccessfullyComplete";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            Boolean bCompleted = false;

            for (int i = 0; i < Config.iER_CompleteTime / 2; i++)
            {

                bCompleted = _gLib._Exists("GroupJobSuccessfullyComplete", this.wRetirementStudio_ERComplete, 1, false);
                if (bCompleted)
                    break;
                else
                    _gLib._Wait(1);
            }


            if (!bCompleted)
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to get <GroupJobSuccessfullyComplete> msgbox within: <" + Config.iER_SubmitTime + "> seconds! ");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to get <GroupJobSuccessfullyComplete> msgbox within: <" + Config.iER_SubmitTime + "> seconds! ");
            }
            else
            {
                _gLib._SetSyncUDWin("wRetirementStudio_ERComplete", this.wRetirementStudio_ERComplete.wDialog, "Click", 0);

                if (dic["VerifyMsg"].Equals("True"))
                {
                    string sActMsg = this.wRetirementStudio_ERComplete.wMessage.txtMessage.Name;
                    if (!sActMsg.Contains("Group Job Successfully Complete"))
                    {
                        _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail because ER complete message not correct! ");
                        _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail because ER complete message not correct! ");
                    }

                    _gLib._SetSyncUDWin("wRetirementStudio_ERComplete", this.wRetirementStudio_ERComplete.wMessage.txtMessage, "Click", 0);

                }

                _gLib._SetSyncUDWin("OK", this.wRetirementStudio_ERComplete.wOK.btn, dic["OK"], 0);
                _gLib._Wait(2);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2018-Oct-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("rdBlankData", "");
        ///    dic.Add("rdDataforSelected", "True");
        ///    dic.Add("cboDataforSelected", "");
        ///    dic.Add("OK", "Click");
        ///    pMain._PopVerify_ReportBuilderDataSource(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ReportBuilderDataSource(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ReportBuilderDataSource";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("rdBlankData", this.wReportBuilderDataSource.wBlankData.rd, dic["rdBlankData"], 0);
                _gLib._SetSyncUDWin("rdDataforSelected", this.wReportBuilderDataSource.wDataforSelected.rd, dic["rdDataforSelected"], 0);
                _gLib._SetSyncUDWin("cboDataforSelected", this.wReportBuilderDataSource.cboDataforSelected.cbo, dic["cboDataforSelected"], 0);
                _gLib._SetSyncUDWin("OK", this.wReportBuilderDataSource.wOK.btn, dic["OK"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2018-Oct-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Allow", "Click");
        ///    pMain._PopVerify_IE_ReportBuilder_Warning(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IE_ReportBuilder_Warning(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_IE_ReportBuilder_Warning";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gwLib._SetSyncUDWeb("OK", this.wIE.wIE_Title, "Click", 0);
                _gwLib._SetSyncUDWeb("Allow", this.wIE.wAllow.btn, dic["Allow"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2018-Oct-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Close", "Click");
        ///    pMain._PopVerify_sQLReportBuilder(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SQLReportBuilder(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_SQLReportBuilder";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("SQLReportBuilder.wTitle", this.wSQLReportBuilder.wTitle.toolbar, "Click", 0);
                _gLib._SetSyncUDWin("Close", this.wSQLReportBuilder.wClose.btn, dic["Close"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




    }
}