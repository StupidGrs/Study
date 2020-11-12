namespace RetirementStudio._UIMaps.AssetsClasses
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


    public partial class Assets
    {

        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();


        public void _Debugging()
        {
            var i = _fp._ReturnSelectRowContent(this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid);

            var a = 0;
        }

        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Data Entry");
        ///    dic.Add("Level_2", "General Information");
        ///    pAssets._TreeViewSelect(dic);
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

        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("TrustPeriodStartDate", "01/01/2011");
        ///    dic.Add("TrustPeriodEndDate", "12/31/2011");
        ///    dic.Add("Restated", "");
        ///    dic.Add("NotRestated", "True");
        ///    dic.Add("Audited", "True");
        ///    dic.Add("Unaudited", "");
        ///    dic.Add("Piror2YearsOfNHCE", "");
        ///    dic.Add("iSelectAssetSnapshot", "");
        ///    pAssets._PopVerify_GerneralInformation(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GerneralInformation(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_GerneralInformation";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("TrustPeriodStartDate", this.wRetirementStudio.wGI_TrustPeriodStartDate.cboTrustPeriodStartDate.txtTrustPeriodStartDate, dic["TrustPeriodStartDate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("TrustPeriodEndDate", this.wRetirementStudio.wGI_TrustPeriodEndDate.cboTrustPeriodEndDate.txtTrustPeriodEndDate, dic["TrustPeriodEndDate"], 0);
                _gLib._SetSyncUDWin("Restated", this.wRetirementStudio.wGI_Restated.rdRestated, dic["Restated"], 0);
                _gLib._SetSyncUDWin("NotRestated", this.wRetirementStudio.wGI_NotRestated.rdNotRestated, dic["NotRestated"], 0);
                _gLib._SetSyncUDWin("Audited", this.wRetirementStudio.wGI_Audited.rdAudited, dic["Audited"], 0);
                _gLib._SetSyncUDWin("Unaudited", this.wRetirementStudio.wGI_Unaudited.rdUnaudited, dic["Unaudited"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Piror2YearsOfNHCE", this.wRetirementStudio.wGI_Piror2YearsOfNHCE.txtPiror2YearsOfNHCE, dic["Piror2YearsOfNHCE"], true, 0);

                if (dic["iSelectAssetSnapshot"] != "")
                {
                    int iPosX = 50;
                    int iStartY = 20;
                    int iStepY = 20;
                    int iRow = Convert.ToInt32(dic["iSelectAssetSnapshot"]);
                    int iPosY = (iRow - 1) * iStepY + iStepY / 2 + iStartY;
                    //////Mouse.Click(this.wRetirementStudio.wGI_SelectAssetSnapshot_FPGrid.grid, new Point(iPosX, iPosY));
                    _gLib._SetSyncUDWin("Asset Snapshot - " + dic["iSelectAssetSnapshot"], this.wRetirementStudio.wGI_SelectAssetSnapshot_FPGrid.grid, "Click", 0, false, iPosX, iPosY);

                }

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("TrustPeriodStartDate", this.wRetirementStudio.wGI_TrustPeriodStartDate.cboTrustPeriodStartDate.txtTrustPeriodStartDate, dic["TrustPeriodStartDate"], 0);
                _gLib._VerifySyncUDWin("TrustPeriodEndDate", this.wRetirementStudio.wGI_TrustPeriodEndDate.cboTrustPeriodEndDate.txtTrustPeriodEndDate, dic["TrustPeriodEndDate"], 0);
                _gLib._VerifySyncUDWin("Restated", this.wRetirementStudio.wGI_Restated.rdRestated, dic["Restated"], 0);
                _gLib._VerifySyncUDWin("NotRestated", this.wRetirementStudio.wGI_NotRestated.rdNotRestated, dic["NotRestated"], 0);
                _gLib._VerifySyncUDWin("Audited", this.wRetirementStudio.wGI_Audited.rdAudited, dic["Audited"], 0);
                _gLib._VerifySyncUDWin("Unaudited", this.wRetirementStudio.wGI_Unaudited.rdUnaudited, dic["Unaudited"], 0);
                _gLib._VerifySyncUDWin("Piror2YearsOfNHCE", this.wRetirementStudio.wGI_Piror2YearsOfNHCE.txtPiror2YearsOfNHCE, dic["Piror2YearsOfNHCE"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }



        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iAssetCategory", "1");
        ///    dic.Add("sAssetCategory", "Common Corporate Stocks");
        ///    dic.Add("Value", "5,060,171.00");
        ///    pAssets._SMV_TimePeriodEndDate_FPGrid_Add(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("iAssetCategory", "2");
        ///    dic.Add("sAssetCategory", "Other Corporate Bonds");
        ///    dic.Add("Value", "1,323,795.00");
        ///    pAssets._SMV_TimePeriodEndDate_FPGrid_Add(dic); 
        /// 
        ///    dic.Clear();
        ///    dic.Add("iAssetCategory", "3");
        ///    dic.Add("sAssetCategory", "Other Receivables");
        ///    dic.Add("Value", "408.00");
        ///    pAssets._SMV_TimePeriodEndDate_FPGrid_Add(dic); 
        /// 
        ///    dic.Clear();
        ///    dic.Add("iAssetCategory", "4");
        ///    dic.Add("sAssetCategory", "Interest Bearing Cash");
        ///    dic.Add("Value", "64,894.00");
        ///    pAssets._SMV_TimePeriodEndDate_FPGrid_Add(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _SMV_TimePeriodEndDate_FPGrid_Add(MyDictionary dic)
        {
            string sFunctionName = "_SMV_TimePeriodEndDate_FPGrid_Add";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sAct;
            int iPosX = 192;

            int iRow = Convert.ToInt32(dic["iAssetCategory"]);

            String sRow = "";

            for (int i = 1; i < iRow; i++)
                sRow = sRow + "{Down}";

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "Click", 0, false, iPosX, 20);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{PageUp}{PageUp}" + sRow);


            WinWindow wWin = new WinWindow(this.wRetirementStudio);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{Space}");
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{Space}");
            wWin = new WinWindow(this.wRetirementStudio);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.COMBOBOX", PropertyExpressionOperator.Contains);
            WinComboBox wCombo = new WinComboBox(wWin);
            ////////////Keyboard.SendKeys(wCombo, dic["sAssetCategory"]);
            ////////////_gLib._VerifySyncUDWin("AssetCategory", wCombo, dic["sAssetCategory"], 0);
            _gLib._SendKeysUDWin("sAssetCategory", wCombo, dic["sAssetCategory"], true);

            ////////////Keyboard.SendKeys(wCombo, "{Tab}");
            _gLib._SendKeysUDWin("ComboBox", wCombo, "{Tab}");


            Keyboard.SendKeys(this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{Space}");
            wWin = new WinWindow(this.wRetirementStudio);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.EDIT", PropertyExpressionOperator.Contains);
            WinEdit wEdit = new WinEdit(wWin);
            ////////////Keyboard.SendKeys(wEdit, dic["Value"]);
            ////////////_gLib._VerifySyncUDWin("Value", wEdit, dic["Value"], 0);
            _gLib._SendKeysUDWin("Value", wEdit, dic["Value"], true);
            //////////Keyboard.SendKeys(wEdit, "{Tab}");
            _gLib._SendKeysUDWin("Value", wEdit, "{Tab}");

            ////sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid);


            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{PageUp}{PageUp}");

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }


        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iAssetCategory", "1");
        ///    dic.Add("sAssetCategory", "Common Corporate Stocks");
        ///    dic.Add("Value", "5,060,171.00");
        ///    pAssets._SMV_TimePeriodEndDate_FPGrid_Add_bySelect(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _SMV_TimePeriodEndDate_FPGrid_Add_bySelect(MyDictionary dic)
        {
            string sFunctionName = "_SMV_TimePeriodEndDate_FPGrid_Add";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sAct;
            int iPosX = 192;

            int iRow = Convert.ToInt32(dic["iAssetCategory"]);

            String sRow = "";
            WinWindow wWin = new WinWindow(this.wRetirementStudio);

            for (int i = 1; i < iRow; i++)
                sRow = sRow + "{Down}";


            if (dic["sAssetCategory"] != "")
            {
                WinComboBox wComb = new WinComboBox(wWin);

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "Click", 0, false, iPosX, 20);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{PageUp}{PageUp}" + sRow + "{Space}");

                _gLib._SetSyncUDWin("sAssetCategory", wComb, dic["sAssetCategory"], 0);
                _gLib._SendKeysUDWin("Value", wComb, "{Tab}{PageUp}{PageUp}");
            }


            if (dic["sAssetCategory"] != "")
            {
                wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.EDIT", PropertyExpressionOperator.Contains);
                WinEdit wEdit = new WinEdit(wWin);

                _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "Click", 0, false, iPosX, 20);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{PageUp}{PageUp}" + sRow + "{Tab}{Space}");

                _gLib._SetSyncUDWin_ByClipboard("Value", wEdit, dic["Value"], 0);
                _gLib._SendKeysUDWin("Value", wEdit, "{Tab}{PageUp}{PageUp}");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iAssetCategory", "1");
        ///    dic.Add("sAssetCategory", "Common Corporate Stocks");
        ///    dic.Add("Value", "6,214,573.00");
        ///    pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("iAssetCategory", "2");
        ///    dic.Add("sAssetCategory", "Other Corporate Bonds");
        ///    dic.Add("Value", "1,257,894.00");
        ///    pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic); 
        /// 
        ///    dic.Clear();
        ///    dic.Add("iAssetCategory", "3");
        ///    dic.Add("sAssetCategory", "Other Receivables");
        ///    dic.Add("Value", "501.75");
        ///    pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic); 
        /// 
        ///    dic.Clear();
        ///    dic.Add("iAssetCategory", "4");
        ///    dic.Add("sAssetCategory", "Interest Bearing Cash");
        ///    dic.Add("Value", "72,154.89");
        ///    pAssets._SMV_TimePeriodEndDate_FPGrid_EditExisting(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _SMV_TimePeriodEndDate_FPGrid_EditExisting(MyDictionary dic)
        {
            string sFunctionName = "_SMV_TimePeriodEndDate_FPGrid_EditExisting";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sAct;
            int iPosX = 192;
            int iStartY = 20;
            int iStepY = 20;
            string sKeys = "";
            int iRow = Convert.ToInt32(dic["iAssetCategory"]);
            int iPosY = (iRow - 1) * iStepY + iStepY / 2 + iStartY;

            //// select the first column data in first row
            ////////////Mouse.Click(this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, new Point(120, 30));
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "Click", 0, false, 120, 30);
            ////////////Keyboard.SendKeys(this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{PageUp}{PageUp}{Home}");
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{PageUp}{PageUp}{Home}");

            for (int i = 1; i < iRow; i++)
                sKeys = sKeys + "{Down}";
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, sKeys);

            sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid);
            if (sAct != dic["sAssetCategory"])
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to find Categor <" + dic["sAssetCategory"] + "> at Expected Row <" + dic["iAssetCategory"] + ">. Actual value <" + sAct + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to find Categor <" + dic["sAssetCategory"] + "> at Expected Row <" + dic["iAssetCategory"] + ">. Actual value <" + sAct + ">");
            }
            else
            {
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{Right}");
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{Space}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{Right}");
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wSMV_TimePeriodEndDate_FPGrid.grid, "{Space}");
                WinWindow wWin = new WinWindow(this.wRetirementStudio);
                wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.EDIT", PropertyExpressionOperator.Contains);
                WinEdit wEdit = new WinEdit(wWin);
                ////////////Keyboard.SendKeys(wEdit, dic["Value"]);
                ////////////_gLib._VerifySyncUDWin("Value", wEdit, dic["Value"], 0);
                _gLib._SendKeysUDWin("AssetCategory", wEdit, dic["Value"], true);
                ////////////Keyboard.SendKeys(wEdit, "{Tab}");
                _gLib._SendKeysUDWin("AssetCategory", wEdit, "{Tab}");
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }



        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("Date", "7/1/2011");
        ///    dic.Add("Category", "Cash");
        ///    dic.Add("Amount", "900,000.00");
        ///    dic.Add("HasDate", "False");
        ///    dic.Add("OK", "");
        ///    pAssets._RMV_EmployerContributions(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RMV_EmployerContributions(MyDictionary dic)
        {
            string sFunctionName = "_RMV_EmployerContributions";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sAct;
            int iPosX = 50;
            int iStartY = 20;
            int iStepY = 20;
            string sKeys = "";
            int iRow = Convert.ToInt32(dic["iRow"]);
            int iPosY = (iRow - 1) * iStepY + iStepY / 2 + iStartY;

            // Select the first row first column, navigate to the expected row
            ////////////Mouse.Click(this.wEmployerContribution.FPGrid.grid, new Point(iPosX, iPosY));
            ////////////Keyboard.SendKeys(this.wEmployerContribution.FPGrid.grid, "{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{Home}");
            _gLib._SetSyncUDWin("FPGrid", this.wEmployerContribution.FPGrid.grid, "Click", 0, false, iPosX, iPosY);
            _gLib._SendKeysUDWin("FPGrid", this.wEmployerContribution.FPGrid.grid, "{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{Home}");

            for (int i = 1; i < iRow; i++)
                sKeys = sKeys + "{Down}";

            ////////////Keyboard.SendKeys(this.wEmployerContribution.FPGrid.grid, sKeys);
            _gLib._SendKeysUDWin("FPGrid", this.wEmployerContribution.FPGrid.grid, sKeys);

            // Populate and Verify Date
            ////////////Keyboard.SendKeys(this.wEmployerContribution.FPGrid.grid, "{Space}");
            _gLib._SendKeysUDWin("FPGrid", this.wEmployerContribution.FPGrid.grid, "{Space}");
            WinWindow wWin = new WinWindow(this.wEmployerContribution);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ControlName, "ctlDateEditor", PropertyExpressionOperator.EqualTo);
            WinComboBox wCombo = new WinComboBox(wWin);
            ////////////Keyboard.SendKeys(wCombo, dic["Date"]);
            ////////////Keyboard.SendKeys(this.wEmployerContribution.FPGrid.grid, "{Tab}");
            ////////////Keyboard.SendKeys(this.wEmployerContribution.FPGrid.grid, "{Home}");
            _gLib._SendKeysUDWin("Date", wCombo, dic["Date"]);
            _gLib._SendKeysUDWin("FPGrid", this.wEmployerContribution.FPGrid.grid, "{Tab}{Home}");
            sAct = _fp._ReturnSelectRowContent(this.wEmployerContribution.FPGrid.grid);
            if (sAct != dic["Date"])
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set <" + dic["Date"] + "> to Row <" + dic["iRow"] + ">. Actual value <" + sAct + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set <" + dic["Date"] + "> to Row <" + dic["iRow"] + ">. Actual value <" + sAct + ">");
            }


            // Populate and Verify Category
            ////////////Keyboard.SendKeys(this.wEmployerContribution.FPGrid.grid, "{Right}");
            ////////////Keyboard.SendKeys(this.wEmployerContribution.FPGrid.grid, "{Space}");
            _gLib._SendKeysUDWin("FPGrid", this.wEmployerContribution.FPGrid.grid, "{Right}{Space}");
            wWin = new WinWindow(this.wEmployerContribution);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.COMBOBOX", PropertyExpressionOperator.Contains);
            wCombo = new WinComboBox(wWin);
            _gLib._SetSyncUDWin("Category", wCombo, dic["Category"], 0);
            ////////////Keyboard.SendKeys(this.wEmployerContribution.FPGrid.grid, "{Tab}");
            _gLib._SendKeysUDWin("FPGrid", this.wEmployerContribution.FPGrid.grid, "{Tab}");

            // Populate and Verify Amount
            ////////////Keyboard.SendKeys(this.wEmployerContribution.FPGrid.grid, "{Home}");
            ////////////Keyboard.SendKeys(this.wEmployerContribution.FPGrid.grid, "{Right}{Right}");
            ////////////Keyboard.SendKeys(this.wEmployerContribution.FPGrid.grid, "{Space}");
            _gLib._SendKeysUDWin("FPGrid", this.wEmployerContribution.FPGrid.grid, "{Home}{Right}{Right}{Space}");

            wWin = new WinWindow(this.wEmployerContribution);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.EDIT", PropertyExpressionOperator.Contains);
            WinEdit wEdit = new WinEdit(wWin);
            ////////////Keyboard.SendKeys(wEdit, dic["Amount"]);
            ////////////_gLib._VerifySyncUDWin("Amount", wEdit, dic["Amount"], 0);
            _gLib._SendKeysUDWin("Amount", wEdit, dic["Amount"], true);

            _gLib._SetSyncUDWin("OK", this.wEmployerContribution.wOK.btnOK, dic["OK"], 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("Category", "Cash");
        ///    dic.Add("Amount", "900,000.00");
        ///    dic.Add("OK", "");
        ///    pAssets._RMV_EmployerContributions_UK(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RMV_EmployerContributions_UK(MyDictionary dic)
        {
            string sFunctionName = "_RMV_EmployerContributions";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sKeys = "";
            int iRow = Convert.ToInt32(dic["iRow"]);

            for (int i = 1; i < iRow; i++)
                sKeys = sKeys + "{Down}";

            ////  click first line and verify iRow
            _gLib._SetSyncUDWin("FPGrid", this.wEmployerContribution.FPGrid.grid, "Click", 0, false, 25, 30);
            _gLib._SendKeysUDWin("FPGrid", this.wEmployerContribution.FPGrid.grid, "{PageUp}{PageUp}{PageUp}{Right}{Home}" + sKeys);


            WinWindow wWin = new WinWindow(this.wEmployerContribution);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.COMBOBOX", PropertyExpressionOperator.Contains);
            WinComboBox wCombo = new WinComboBox(wWin);

            _gLib._SendKeysUDWin("FPGrid", this.wEmployerContribution.FPGrid.grid, "{space}");
            _gLib._SetSyncUDWin("Category", wCombo, dic["Category"], 0);


            ////
            wWin = new WinWindow(this.wEmployerContribution);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.EDIT", PropertyExpressionOperator.Contains);
            WinEdit wEdit = new WinEdit(wWin);

            _gLib._SendKeysUDWin("FPGrid", this.wEmployerContribution.FPGrid.grid, "{Tab}{Home}{Right}{Space}");
            _gLib._SendKeysUDWin("Amount", wEdit, dic["Amount"], true);


            _gLib._SetSyncUDWin("OK", this.wEmployerContribution.wOK.btnOK, dic["OK"], 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("Date", "7/1/2011");
        ///    dic.Add("Category", "Cash");
        ///    dic.Add("Amount", "900,000.00");
        ///    dic.Add("OK", "");
        ///    pAssets._RMV_BenefitPayments(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RMV_BenefitPayments(MyDictionary dic)
        {
            string sFunctionName = "_RMV_BenefitPayments";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sAct;
            int iPosX = 50;
            int iStartY = 20;
            int iStepY = 20;
            string sKeys = "";

            int iRow = Convert.ToInt32(dic["iRow"]);
            int iPosY = (iRow - 1) * iStepY + iStepY / 2 + iStartY;

            // Select the first row first column, navigate to the expected row
            ////////////Mouse.Click(this.wBenefitPayments.FPGrid.grid, new Point(iPosX, iPosY));
            ////////////Keyboard.SendKeys(this.wBenefitPayments.FPGrid.grid, "{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{Home}");
            _gLib._SetSyncUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "Click", 0, false, iPosX, iPosY);
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{Home}");

            for (int i = 1; i < iRow; i++)
                sKeys = sKeys + "{Down}";
            ////////////Keyboard.SendKeys(this.wBenefitPayments.FPGrid.grid, sKeys);
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, sKeys);

            // Populate and Verify Date
            //////////////Keyboard.SendKeys(this.wBenefitPayments.FPGrid.grid, "{Space}");
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Tab}{Home}{Space}");
            WinWindow wWin = new WinWindow(this.wBenefitPayments);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ControlName, "ctlDateEditor", PropertyExpressionOperator.EqualTo);
            WinComboBox wCombo = new WinComboBox(wWin);
            ////////////Keyboard.SendKeys(wCombo, dic["Date"]);
            ////////////Keyboard.SendKeys(this.wBenefitPayments.FPGrid.grid, "{Tab}");
            ////////////Keyboard.SendKeys(this.wBenefitPayments.FPGrid.grid, "{Home}");
            _gLib._SendKeysUDWin("Date", wCombo, dic["Date"]);
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Tab}{Home}");

            sAct = _fp._ReturnSelectRowContent(this.wBenefitPayments.FPGrid.grid);
            if (sAct != dic["Date"])
            {
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set <" + dic["Date"] + "> to Row <" + dic["iRow"] + ">. Actual value <" + sAct + ">");
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set <" + dic["Date"] + "> to Row <" + dic["iRow"] + ">. Actual value <" + sAct + ">");
            }


            // Populate and Verify Category
            ////////////Keyboard.SendKeys(this.wBenefitPayments.FPGrid.grid, "{Right}");
            ////////////Keyboard.SendKeys(this.wBenefitPayments.FPGrid.grid, "{Space}");
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Right}{Space}");
            wWin = new WinWindow(this.wBenefitPayments);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.COMBOBOX", PropertyExpressionOperator.Contains);
            wCombo = new WinComboBox(wWin);
            _gLib._SetSyncUDWin("Category", wCombo, dic["Category"], 0);
            ////////////Keyboard.SendKeys(this.wBenefitPayments.FPGrid.grid, "{Tab}");
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Tab}");

            // Populate and Verify Amount
            ////////////Keyboard.SendKeys(this.wBenefitPayments.FPGrid.grid, "{Home}");
            ////////////Keyboard.SendKeys(this.wBenefitPayments.FPGrid.grid, "{Right}{Right}");
            ////////////Keyboard.SendKeys(this.wBenefitPayments.FPGrid.grid, "{Space}");
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Home}{Right}{Right}");
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Space}");
            wWin = new WinWindow(this.wBenefitPayments);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.EDIT", PropertyExpressionOperator.Contains);
            WinEdit wEdit = new WinEdit(wWin);
            ////////////Keyboard.SendKeys(wEdit, dic["Amount"]);
            ////////////_gLib._VerifySyncUDWin("Amount", wEdit, dic["Amount"], 0);
            _gLib._SendKeysUDWin("Amount", wEdit, dic["Amount"], true);

            _gLib._SetSyncUDWin("OK", this.wBenefitPayments.wOK.btnOK, dic["OK"], 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("MVPeriodBegin", "");
        ///    dic.Add("Contributions_Employer_Itemize", "Click");
        ///    dic.Add("Contributions_Participant_Itemize", "");
        ///    dic.Add("Contributions_Other_Itemize", "");
        ///    dic.Add("Transfers_TransfersToPlan_Itemize", "");
        ///    dic.Add("OtherAdditions_OtherAdditions_Itemize", "");
        ///    dic.Add("Withdrawal_LeaverPayments_Participant_Itemize", "");
        ///    dic.Add("Withdrawals_OtherPayments_Itemize", "");
        ///    dic.Add("ReturnonInvestments_ReturnsonInvestments_Itemize", "");
        ///    dic.Add("Disburse_BenefitPayments_Itemize", "");
        ///    dic.Add("Disburse_Expenses_Itemize", "");
        ///  
        ///    dic.Add("MV_Adjustment", "");
        ///    dic.Add("InvestEarnings_Interest", "");
        ///    dic.Add("InvestEarnings_Dividends", "");
        ///    dic.Add("InvestEarnings_Realized", "");
        ///    dic.Add("InvestEarnings_Unrealized", "");
        ///    dic.Add("InvestEarnings_OtherGainLoss", "");
        ///    dic.Add("InvestEarnings_OtherIncome", "");
        ///    
        ///    dic.Add("Disburse_BenefitPayments", "");
        ///    dic.Add("Disburse_Expenses", "");
        ///    dic.Add("Disburse_Others", "");
        ///    dic.Add("CreateAssetSnapshot", "");
        ///    pAssets._PopVerify_ReconciliationOfMarketValue(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ReconciliationOfMarketValue(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ReconciliationOfMarketValue";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin_ByClipboard("MVPeriodBegin", this.wRetirementStudio.wRMV_MVPeriodBegin.txtMVPeriodBegin, dic["MVPeriodBegin"], 0);
                _gLib._SetSyncUDWin("Contributions_Employer_Itemize", this.wRetirementStudio.wRMV_Contributions_Employer_Itemize.txtContributions_Employer_Itemize.linkContributions_Employer_Itemize, dic["Contributions_Employer_Itemize"], 0);
                _gLib._SetSyncUDWin("Contributions_Participant_Itemize", this.wRetirementStudio.wRMV_Contributions_Participant_Itemize.txtContributions_Participant_Itemize.link, dic["Contributions_Participant_Itemize"], 0);
                _gLib._SetSyncUDWin("Transfers_TransfersToPlan_Itemize", this.wRetirementStudio.wRMV_Tansfers_TransferToPlan_Itemize.txt.link, dic["Transfers_TransfersToPlan_Itemize"], 0);
                _gLib._SetSyncUDWin("Withdrawal_LeaverPayments_Participant_Itemize", this.wRetirementStudio.wRMV_Withdrawals_LeavePayments_Itemize.txt.link, dic["Withdrawal_LeaverPayments_Participant_Itemize"], 0);
                _gLib._SetSyncUDWin("Withdrawals_OtherPayments_Itemize", this.wRetirementStudio.wRMV_Withdrawal_OtherPayment_Itemize.txt.link, dic["Withdrawals_OtherPayments_Itemize"], 0);
                _gLib._SetSyncUDWin("OtherAdditions_OtherAdditions_Itemize", this.wRetirementStudio.wRMV_OtherAdditions_OtherAdditons_Itemize.txt.link, dic["OtherAdditions_OtherAdditions_Itemize"], 0);
                _gLib._SetSyncUDWin("ReturnonInvestments_ReturnsonInvestments_Itemize", this.wRetirementStudio.wRMV_InvestmentReturn_InvestmentReturn_Itemize.txt.link, dic["ReturnonInvestments_ReturnsonInvestments_Itemize"], 0);
                _gLib._SetSyncUDWin("Disburse_Expenses_Itemize", this.wRetirementStudio.wRMV_Withdrawals_AdministrationExpense_Itemize.txt.link, dic["Disburse_Expenses_Itemize"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MV_Adjustment", this.wRetirementStudio.wMV_Adjustment_1.Edit.txt, dic["MV_Adjustment"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InvestEarnings_Interest", this.wRetirementStudio.wRMV_InvestEarnings_Interest.txtInterest, dic["InvestEarnings_Interest"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InvestEarnings_Dividends", this.wRetirementStudio.wRMV_InvestEarnings_Dividends.txtDividends, dic["InvestEarnings_Dividends"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InvestEarnings_Realized", this.wRetirementStudio.wRMV_InvestEarnings_Realized.txt, dic["InvestEarnings_Realized"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InvestEarnings_Unrealized", this.wRetirementStudio.wRMV_InvestEarnings_Unrealized.txtUnrealized, dic["InvestEarnings_Unrealized"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InvestEarnings_OtherGainLoss", this.wRetirementStudio.wRMV_InvestEarnings_OtherGainLoss.txt, dic["InvestEarnings_OtherGainLoss"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InvestEarnings_OtherIncome", this.wRetirementStudio.wRMV_InvestEarings_OthersIncome.Edit.txt, dic["InvestEarnings_OtherIncome"], 0);
                _gLib._SetSyncUDWin("Disburse_BenefitPayments_Itemize", this.wRetirementStudio.wRMV_Disburse_BenefitPayments_Itemize.txtDisburse_BenefitPayments_Itemize.linkDisburse_BenefitPayments_Itemize, dic["Disburse_BenefitPayments_Itemize"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Disburse_BenefitPayments", this.wRetirementStudio.wRMV_Disburse_BenefitPayments.txtBenefitPayments, dic["Disburse_BenefitPayments"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Disburse_Expenses", this.wRetirementStudio.wRMV_Disburse_Expenses.txt, dic["Disburse_Expenses"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Disburse_Others", this.wRetirementStudio.wRMV_Disbursements_OtherDisbursement.Edit.txt, dic["Disburse_Others"], 0);
                _gLib._SetSyncUDWin("CreateAssetSnapshot", this.wRetirementStudio.wRMV_CreateAssetSnapshot.txtCreateAssetSnapshot.linkCreateAssetSnapshot, dic["CreateAssetSnapshot"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("MVPeriodBegin", this.wRetirementStudio.wRMV_MVPeriodBegin.txtMVPeriodBegin, dic["MVPeriodBegin"], 0);
                _gLib._VerifySyncUDWin("Contributions_Employer_Itemize", this.wRetirementStudio.wRMV_Contributions_Employer_Itemize.txtContributions_Employer_Itemize.linkContributions_Employer_Itemize, dic["Contributions_Employer_Itemize"], 0);
                _gLib._VerifySyncUDWin("Contributions_Participant_Itemize", this.wRetirementStudio.wRMV_Contributions_Participant_Itemize.txtContributions_Participant_Itemize.link, dic["Contributions_Participant_Itemize"], 0);
                _gLib._VerifySyncUDWin("InvestEarnings_Interest", this.wRetirementStudio.wRMV_InvestEarnings_Interest.txtInterest, dic["InvestEarnings_Interest"], 0);
                _gLib._VerifySyncUDWin("InvestEarnings_Dividends", this.wRetirementStudio.wRMV_InvestEarnings_Dividends.txtDividends, dic["InvestEarnings_Dividends"], 0);
                _gLib._VerifySyncUDWin("InvestEarnings_Realized", this.wRetirementStudio.wRMV_InvestEarnings_Realized.txt, dic["InvestEarnings_Realized"], 0);
                _gLib._VerifySyncUDWin("InvestEarnings_Unrealized", this.wRetirementStudio.wRMV_InvestEarnings_Unrealized.txtUnrealized, dic["InvestEarnings_Unrealized"], 0);
                _gLib._VerifySyncUDWin("InvestEarnings_OtherGainLoss", this.wRetirementStudio.wRMV_InvestEarnings_OtherGainLoss.txt, dic["InvestEarnings_OtherGainLoss"], 0);
                _gLib._VerifySyncUDWin("Disburse_BenefitPayments_Itemize", this.wRetirementStudio.wRMV_Disburse_BenefitPayments_Itemize.txtDisburse_BenefitPayments_Itemize.linkDisburse_BenefitPayments_Itemize, dic["Disburse_BenefitPayments_Itemize"], 0);
                _gLib._VerifySyncUDWin("Disburse_BenefitPayments", this.wRetirementStudio.wRMV_Disburse_BenefitPayments.txtBenefitPayments, dic["Disburse_BenefitPayments"], 0);
                _gLib._VerifySyncUDWin("Disburse_Expenses", this.wRetirementStudio.wRMV_Disburse_Expenses.txt, dic["Disburse_Expenses"], 0);
                _gLib._VerifySyncUDWin("CreateAssetSnapshot", this.wRetirementStudio.wRMV_CreateAssetSnapshot.txtCreateAssetSnapshot.linkCreateAssetSnapshot, dic["CreateAssetSnapshot"], 0);

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
        ///    dic.Add("SnapshotName", "Dec 31 2005 MV");
        ///    dic.Add("OK", "Click");
        ///    pAssets._PopVerify_AssetSnapshotProperties(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_AssetSnapshotProperties(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_AssetSnapshotProperties";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("SnapshotName", this.wAssetSnapshotProperties.wSnapshotName.txt, dic["SnapshotName"], 0);
                _gLib._SetSyncUDWin("OK", this.wAssetSnapshotProperties.wOK.btnOK, dic["OK"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("SnapshotName", this.wAssetSnapshotProperties.wSnapshotName.txt, dic["SnapshotName"], 0);
                _gLib._VerifySyncUDWin("OK", this.wAssetSnapshotProperties.wOK.btnOK, dic["OK"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");



        }

        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("Category", "");
        ///    dic.Add("Amount", "");
        ///    dic.Add("WeightingFactor", "");
        ///    dic.Add("OK", "");
        ///    pAssets._RMV_BenefitPayments_Disbusement(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _RMV_BenefitPayments_Disbusement(MyDictionary dic)
        {
            string sFunctionName = "_RMV_BenefitPayments_Disbusement";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            string sAct;
            int iPosX = 50;
            int iStartY = 20;
            int iStepY = 20;
            string sKeys = "";

            int iRow = Convert.ToInt32(dic["iRow"]);
            int iPosY = (iRow - 1) * iStepY + iStepY / 2 + iStartY;

            // Select the first row first column, navigate to the expected row

            _gLib._SetSyncUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "Click", 0, false, iPosX, iPosY);
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}{Home}");

            for (int i = 1; i < iRow; i++)
                sKeys = sKeys + "{Down}";

            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, sKeys);



            WinWindow wWin = new WinWindow(this.wBenefitPayments);
            WinComboBox wCombo = new WinComboBox(wWin);

            // Populate and Verify Category
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Tab}{Home}");
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Space}");
            wWin = new WinWindow(this.wBenefitPayments);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.COMBOBOX", PropertyExpressionOperator.Contains);
            wCombo = new WinComboBox(wWin);
            _gLib._SetSyncUDWin("Category", wCombo, dic["Category"], 0);
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Tab}");

            // Populate and Verify Amount

            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Home}{Right}");
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Space}");
            wWin = new WinWindow(this.wBenefitPayments);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.EDIT", PropertyExpressionOperator.Contains);
            WinEdit wEdit = new WinEdit(wWin);
            _gLib._SendKeysUDWin("Amount", wEdit, dic["Amount"], true);

            // Populate and WeightingFactor

            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Home}{Right}{Right}");
            _gLib._SendKeysUDWin("FPGrid", this.wBenefitPayments.FPGrid.grid, "{Space}");
            wWin = new WinWindow(this.wBenefitPayments);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.EDIT", PropertyExpressionOperator.Contains);
            wEdit = new WinEdit(wWin);
            _gLib._SendKeysUDWin("WeightingFactor", wEdit, dic["WeightingFactor"], true);


            _gLib._SetSyncUDWin("OK", this.wBenefitPayments.wOK.btnOK, dic["OK"], 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Contributions_Employer", "");
        ///    pAssets._PopVerify_InTransitAmounts(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_InTransitAmounts(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_InTransitAmounts";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin_ByClipboard("Contributions_Employer", this.wRetirementStudio.wRMV_Contributions_Employer.txt, dic["Contributions_Employer"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Contributions_Employer", this.wRetirementStudio.wRMV_Contributions_Employer.txt, dic["Contributions_Employer"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");



        }




    }
}
