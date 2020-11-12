namespace RetirementStudio._UIMaps.Methods_UKClasses
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


    public partial class Methods_UK
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();
        private FarPoint _fp = new FarPoint();

        /// <summary>
        /// 2013-May-13
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("GMPAdjustmentsToUse_AddRow", "");
        ///    dic.Add("GMPAdjustmentsToUse_DeleteRow", "");
        ///    dic.Add("AdditionalCalcRequest_AddRow", "Click");
        ///    dic.Add("AdditionalCalcRequest_DeleteRow", "");
        ///    pMethods_UK._PopVerify_Methods(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Methods(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_Methods";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("GMPAdjustmentsToUse_AddRow", this.wRetirementStudio.wGMPAdjustmentsToUse_AddRow.btn, dic["GMPAdjustmentsToUse_AddRow"], 0);
                _gLib._SetSyncUDWin("GMPAdjustmentsToUse_DeleteRow", this.wRetirementStudio.wGMPAdjustmentsToUse_DeleteRow.btn, dic["GMPAdjustmentsToUse_DeleteRow"], 0);
                _gLib._SetSyncUDWin("AdditionalCalcRequest_AddRow", this.wRetirementStudio.wAdditionalCalcRequest_AddRow.btn, dic["AdditionalCalcRequest_AddRow"], 0);
                _gLib._SetSyncUDWin("AdditionalCalcRequest_DeleteRow", this.wRetirementStudio.wAdditionalCalcRequest_DeleteRow.btn, dic["AdditionalCalcRequest_DeleteRow"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("GMPAdjustmentsToUse_AddRow", this.wRetirementStudio.wGMPAdjustmentsToUse_AddRow.btn, dic["GMPAdjustmentsToUse_AddRow"], 0);
                _gLib._VerifySyncUDWin("GMPAdjustmentsToUse_DeleteRow", this.wRetirementStudio.wGMPAdjustmentsToUse_DeleteRow.btn, dic["GMPAdjustmentsToUse_DeleteRow"], 0);
                _gLib._VerifySyncUDWin("AdditionalCalcRequest_AddRow", this.wRetirementStudio.wAdditionalCalcRequest_AddRow.btn, dic["AdditionalCalcRequest_AddRow"], 0);
                _gLib._VerifySyncUDWin("AdditionalCalcRequest_DeleteRow", this.wRetirementStudio.wAdditionalCalcRequest_DeleteRow.btn, dic["AdditionalCalcRequest_DeleteRow"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-June-29
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("BenefitSet", "AllMembers");
        ///    dic.Add("GMPAdjustment", "GMP_Adj");
        ///    pMethods_UK._GMPAdjustmentsToUse_Grid(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _GMPAdjustmentsToUse_Grid(MyDictionary dic)
        {
            string sFunctionName = "_GMPAdjustmentsToUse_Grid";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRow = Convert.ToInt32(dic["iRow"]);
            string sRowKeys = "";

            for (int i = 1; i < iRow; i++)
                sRowKeys = sRowKeys + "{Tab}{Tab}";

            string sBackKeys = "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}";

            _gLib._SetSyncUDWin("grid", this.wRetirementStudio.wGMPAdjustmentsToUse_FPGrid.grid, "Click", 0, false, 15, 15);
            _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wGMPAdjustmentsToUse_FPGrid.grid, "{Tab}");


            if (dic["BenefitSet"] != "")
            {
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wGMPAdjustmentsToUse_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wGMPAdjustmentsToUse_FPGrid.grid, sRowKeys);
                setcommonbox("BenefitSet", dic["BenefitSet"]);
            }

            if (dic["GMPAdjustment"] != "")
            {
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wGMPAdjustmentsToUse_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);
                _gLib._SendKeysUDWin("grid", this.wRetirementStudio.wGMPAdjustmentsToUse_FPGrid.grid, sRowKeys + "{Tab}");
                setcommonbox("GMPAdjustment", dic["GMPAdjustment"]);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-June-29
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("BenefitSet", "AllMembers");
        ///    dic.Add("PayProjection", "");
        ///    dic.Add("EmployeeContribution", "");
        ///    dic.Add("StopPVFuture", "");
        ///    pMethods_UK._AdditionalCalcuationRequest_Grid(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _AdditionalCalcuationRequest_Grid(MyDictionary dic)
        {
            string sFunctionName = "_AdditionalCalcuationRequest_Grid";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRow = Convert.ToInt32(dic["iRow"]);


            int iX_BenefitSet = 58;
            int iX_PayProjection = 290;
            int iX_EmployeeContribution = 492;
            int iX_StopPVFuture = 700;

            int iY_Step = 20;
            int iY_Start = 57;

            if (iRow == 4)
                iRow = 3;
            int iY = iY_Start + iY_Step * (iRow - 1);


            _gLib._SetSyncUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, "Click", 0, false, 100, 26);

            string sBackKeys = "";
            for (int i = 0; i < 50; i++)
                sBackKeys = sBackKeys + "{Tab}";
            _gLib._SendKeysUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);



            if (dic["BenefitSet"] != "")
            {
                if (Convert.ToInt32(dic["iRow"]) == 4)
                    _gLib._SendKeysUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, sBackKeys);

                _gLib._SetSyncUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, "Click", 0, false, iX_BenefitSet, iY);
                
                //_gLib._SetSyncUDWin("BenefitSet", this.wCommon_SubWin.wList.list, dic["BenefitSet"], 0, false);
                //_gLib._VerifySyncUDWin("BenefitSet", this.wRetirementStudio.wCommon_cbo_instance2.cbo, dic["BenefitSet"], 0);
                setcommonbox("BenefitSet", dic["BenefitSet"]);
            }

            if (dic["PayProjection"] != "")
            {
                if (Convert.ToInt32(dic["iRow"]) == 4)
                    _gLib._SendKeysUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, sBackKeys);

                _gLib._SetSyncUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, "Click", 0, false, iX_PayProjection, iY);

                this.wCommon_SubWin.wList.list.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["PayProjection"], PropertyExpressionOperator.EqualTo);
                _gLib._SetSyncUDWin("PayProjection", this.wCommon_SubWin.wList.list.chk, "True", 0);
            }

            if (dic["EmployeeContribution"] != "")
            {
                if (Convert.ToInt32(dic["iRow"]) == 4)
                    _gLib._SendKeysUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, sBackKeys);

                _gLib._SetSyncUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, "Click", 0, false, iX_EmployeeContribution, iY);

                this.wCommon_SubWin.wList.list.chk.SearchProperties.Add(WinWindow.PropertyNames.Name, dic["EmployeeContribution"], PropertyExpressionOperator.EqualTo);

                _gLib._SetSyncUDWin("EmployeeContribution", this.wCommon_SubWin.wList.list.chk, "True", 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

            ////////int iRow = Convert.ToInt32(dic["iRow"]);

            ////////int iX_BenefitSet = 58;
            ////////int iX_PayProjection = 290;
            ////////int iX_EmployeeContribution = 492;
            ////////int iX_StopPVFuture = 700;

            ////////int iY_Step = 20;
            ////////int iY_Start = 57;

            ////////if (iRow == 4)
            ////////    iRow = 3;
            ////////int iY = iY_Start + iY_Step * (iRow - 1);


            ////////_gLib._SetSyncUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, "Click", 0, false, 100, 26);

            ////////string sBackKeys = "";
            ////////for (int i = 0; i < 50; i++)
            ////////    sBackKeys = sBackKeys + "{Tab}";

            ////////_gLib._SendKeysUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, sBackKeys, 0, ModifierKeys.Shift, false);



            ////////if (dic["BenefitSet"] != "")
            ////////{
            ////////    if (Convert.ToInt32(dic["iRow"])==4)
            ////////        _gLib._SendKeysUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, sBackKeys);

            ////////    _gLib._SetSyncUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, "Click", 0, false, iX_BenefitSet, iY);
            ////////    string sStartChar = dic["BenefitSet"].Substring(0, 1);
            ////////    _gLib._SendKeysUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, sStartChar);

            ////////    string sSelected = this.wRetirementStudio.wCommon_cbo.cbo.GetProperty("SelectedItem").ToString();

            ////////    if(!sSelected.Equals(dic["BenefitSet"]))
            ////////        _gLib._SendKeysUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, sStartChar);

            ////////    sSelected = this.wRetirementStudio.wCommon_cbo.cbo.GetProperty("SelectedItem").ToString();
            ////////    if(!sSelected.Equals(dic["BenefitSet"]))
            ////////        _gLib._SendKeysUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, sStartChar);

            ////////    _gLib._VerifySyncUDWin("BenefitSet", this.wRetirementStudio.wCommon_cbo_instance2.cbo, dic["BenefitSet"], 0);
            ////////}

            ////////if (dic["PayProjection"] != "")
            ////////{
            ////////    if (Convert.ToInt32(dic["iRow"]) == 4)
            ////////        _gLib._SendKeysUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, sBackKeys);

            ////////    _gLib._SetSyncUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, "Click", 0, false, iX_PayProjection, iY);

            ////////    this.wCommon_SubWin.wList.list.chk.SearchProperties.Add(WinCheckBox.PropertyNames.Name, dic["PayProjection"], PropertyExpressionOperator.EqualTo);
            ////////    _gLib._SetSyncUDWin("PayProjection", this.wCommon_SubWin.wList.list.chk, "True", 0);
            ////////}

            ////////if (dic["EmployeeContribution"] != "")
            ////////{
            ////////    if (Convert.ToInt32(dic["iRow"]) == 4)
            ////////        _gLib._SendKeysUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, sBackKeys);

            ////////    _gLib._SetSyncUDWin("AdditionalCalcRequest_FPGrid", this.wRetirementStudio.wAdditionalCalcRequest_FPGrid.grid, "Click", 0, false, iX_EmployeeContribution, iY);

            ////////    this.wCommon_SubWin.wList.list.chk.SearchProperties.Add(WinWindow.PropertyNames.Name, dic["EmployeeContribution"], PropertyExpressionOperator.EqualTo);

            ////////    _gLib._SetSyncUDWin("EmployeeContribution", this.wCommon_SubWin.wList.list.chk, "True", 0);

            ////////}


            ////////_gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        private void setcommonbox(string description, string value)
        {
            UITestControlCollection uilist = this.wRetirementStudio.wCommon_cbo.FindMatchingControls();
            //_gLib._MsgBoxYesNo("", "" + uilist.Count);
            WinComboBox cbo = null;
            for (int i = 0; i < uilist.Count; i++)
            {
                if (uilist[i].FriendlyName != "cboCostMethods")
                {
                    cbo = new WinComboBox(uilist[i]);
                    break;
                }
            }
            _gLib._SetSyncUDWin(description, cbo, value, 0, false);
        }


    }
}
