namespace RetirementStudio._UIMaps.AssumptionsClasses
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
    using System.Windows.Forms;

    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    
    public partial class Assumptions
    {


        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        public void _Debugging()
        {

            var sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wProvision_CustomCode_FPGrid.grid);
            var c = 1;




            //object[] native = this.wRetirementStudio.wCurrentView.gridCurrentView.NativeElement as object[];
            //IAccessible a = native[0] as IAccessible;




        }


        /// <summary>
        /// 2015-Mar-31 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pAssumptions._TreeView_SelectTab("Trade");
        ///    pAssumptions._TreeView_SelectTab("Solvency/ Wind-Up");
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeView_SelectTab(string sTabName)
        {
            string sFunctionName = "_TreeView_SelectTab";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TabPageSelectWin(sTabName, this.wRetirementStudio.wTreeViewTab, 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Assumptions");
        ///    dic.Add("Level_2", "Interest Rate");
        ///    dic.Add("MenuItem", "Add New Liability Type/Projection Folder");
        ///    pAssumptions._TreeViewRightSelect(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewRightSelect(MyDictionary dic)
        {
            string sFunctionName = "_TreeViewRightSelect";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TreeViewRightSelectWin(0, this.wRetirementStudio.tvNaviTree, dic, false);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Assumptions");
        ///    dic.Add("Level_2", "Pay Increase");
        ///    dic.Add("MenuItem", "Add Pay Increase");
        ///    pAssumptions._TreeViewRightSelect(dic, "PayIncrease1");
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewRightSelect(MyDictionary dic, string sNewItemName)
        {
            string sFunctionName = "_TreeViewRightSelect";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TreeViewRightSelectWin(0, this.wRetirementStudio.tvNaviTree, dic, false);

            if (sNewItemName != "")
            {
                //this.wRetirementStudio.wTreeViewEdit.SearchProperties.Add(WinWindow.PropertyNames.Name, "NewPayIncrease1");
                _gLib._SetSyncUDWin(sNewItemName, this.wRetirementStudio.wTreeViewEdit.txtName, sNewItemName, 0);
                ////////////Keyboard.SendKeys(this.wRetirementStudio.wTreeViewEdit.txtName, "{Enter}");
                _gLib._SendKeysUDWin(sNewItemName, this.wRetirementStudio.wTreeViewEdit.txtName, "{Enter}");
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
        /// dic.Add("FolderName", "FAS35Int");
        /// dic.Add("EAN", "");
        /// dic.Add("FAS35PVAB", "True");
        /// dic.Add("FAS35PVVB", "True");
        /// dic.Add("Nondiscrimination", "");
        /// dic.Add("PBGCARPVVB", "");
        /// dic.Add("PBGCNARPVVB", "");
        /// dic.Add("PBGCPlanTerm", "");
        /// dic.Add("PPAARMax", "");
        /// dic.Add("PPAARMin", "");
        /// dic.Add("PPAARPVVB", "");
        /// dic.Add("PPANARMax", "");
        /// dic.Add("PPANARMin", "");
        /// dic.Add("PPANARPVVB", "");
        /// dic.Add("Projection", "");
        /// dic.Add("IntlAccountingABO", "");
        /// dic.Add("IntlAccountingABO", "");
        /// dic.Add("Tax", "");
        /// dic.Add("Trade", "");
        /// dic.Add("OK", "Click");
        /// pAssumptions._PopVerify_NewLiabilityTypeFolder(dic); 
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("FolderName", "IntAcctRev");
        /// dic.Add("IntlAccountingABO", "True");
        /// dic.Add("IntlAccountingPBO", "True");
        /// dic.Add("Tax", "");
        /// dic.Add("Trade", "");
        /// dic.Add("OK", "Click");
        /// pAssumptions._PopVerify_NewLiabilityTypeFolder(dic); 
        /// 
        /// sample:
        /// dic.Clear();
        /// dic.Add("PopVerify", "Pop");
        /// dic.Add("FolderName", "Solvency");
        /// dic.Add("Solvency", "True");
        /// dic.Add("Funding", "True");
        /// dic.Add("OK", "Click");
        /// pAssumptions._PopVerify_NewLiabilityTypeFolder(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_NewLiabilityTypeFolder(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_NewLiabilityTypeFolder";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("FolderName", this.wNewLiabilityTypeFolder.wFolderName.txtFolderName, dic["FolderName"], 0);
                _gLib._SetSyncUDWin("EAN", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkEAN, dic["EAN"], 0);
                _gLib._SetSyncUDWin("FAS35PVAB", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkFAS35PVAB, dic["FAS35PVAB"], 0);
                _gLib._SetSyncUDWin("FAS35PVVB", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkFAS35PVVB, dic["FAS35PVVB"], 0);
                _gLib._SetSyncUDWin("Nondiscrimination", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkNondiscrimination, dic["Nondiscrimination"], 0);
                _gLib._SetSyncUDWin("PBGCARPVVB", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPBGCARPVVB, dic["PBGCARPVVB"], 0);
                _gLib._SetSyncUDWin("PBGCNARPVVB", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPBGCNARPVVB, dic["PBGCNARPVVB"], 0);
                _gLib._SetSyncUDWin("PBGCPlanTerm", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPBGCPlanTerm, dic["PBGCPlanTerm"], 0);
                _gLib._SetSyncUDWin("PPAARMax", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPPAARMax, dic["PPAARMax"], 0);
                _gLib._SetSyncUDWin("PPAARMin", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPPAARMin, dic["PPAARMin"], 0);
                _gLib._SetSyncUDWin("PPAARPVVB", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPPAARPVVB, dic["PPAARPVVB"], 0);
                _gLib._SetSyncUDWin("PPANARMax", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPPANARMax, dic["PPANARMax"], 0);
                _gLib._SetSyncUDWin("PPANARMin", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPPANARMin, dic["PPANARMin"], 0);
                _gLib._SetSyncUDWin("PPANARPVVB", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPPANARPVVB, dic["PPANARPVVB"], 0);
                _gLib._SetSyncUDWin("Projection", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkProjection, dic["Projection"], 0);
                _gLib._SetSyncUDWin("IntlAccountingABO", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkIntlAccountingABO, dic["IntlAccountingABO"], 0);
                _gLib._SetSyncUDWin("IntlAccountingPBO", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkIntlAccountingPBO, dic["IntlAccountingPBO"], 0);
                _gLib._SetSyncUDWin("Tax", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkTax, dic["Tax"], 0);
                _gLib._SetSyncUDWin("Trade", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkTrade, dic["Trade"], 0);
                _gLib._SetSyncUDWin("Solvency", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkSolvency, dic["Solvency"], 0);
                _gLib._SetSyncUDWin("Funding", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkFunding, dic["Funding"], 0);
                _gLib._SetSyncUDWin("OK", this.wNewLiabilityTypeFolder.wOK.btnOK, dic["OK"], 0);
            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("FolderName", this.wNewLiabilityTypeFolder.wFolderName.txtFolderName, dic["FolderName"], 0);
                _gLib._VerifySyncUDWin("EAN", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkEAN, dic["EAN"], 0);
                _gLib._VerifySyncUDWin("FAS35PVAB", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkFAS35PVAB, dic["FAS35PVAB"], 0);
                _gLib._VerifySyncUDWin("FAS35PVVB", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkFAS35PVVB, dic["FAS35PVVB"], 0);
                _gLib._VerifySyncUDWin("Nondiscrimination", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkNondiscrimination, dic["Nondiscrimination"], 0);
                _gLib._VerifySyncUDWin("PBGCARPVVB", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPBGCARPVVB, dic["PBGCARPVVB"], 0);
                _gLib._VerifySyncUDWin("PBGCNARPVVB", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPBGCNARPVVB, dic["PBGCNARPVVB"], 0);
                _gLib._VerifySyncUDWin("PBGCPlanTerm", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPBGCPlanTerm, dic["PBGCPlanTerm"], 0);
                _gLib._VerifySyncUDWin("PPAARMax", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPPAARMax, dic["PPAARMax"], 0);
                _gLib._VerifySyncUDWin("PPAARMin", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPPAARMin, dic["PPAARMin"], 0);
                _gLib._VerifySyncUDWin("PPAARPVVB", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPPAARPVVB, dic["PPAARPVVB"], 0);
                _gLib._VerifySyncUDWin("PPANARMax", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPPANARMax, dic["PPANARMax"], 0);
                _gLib._VerifySyncUDWin("PPANARMin", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPPANARMin, dic["PPANARMin"], 0);
                _gLib._VerifySyncUDWin("PPANARPVVB", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkPPANARPVVB, dic["PPANARPVVB"], 0);
                _gLib._VerifySyncUDWin("Projection", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkProjection, dic["Projection"], 0);
                _gLib._VerifySyncUDWin("IntlAccountingABO", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkIntlAccountingABO, dic["IntlAccountingABO"], 0);
                _gLib._VerifySyncUDWin("IntlAccountingPBO", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkIntlAccountingPBO, dic["IntlAccountingPBO"], 0);
                _gLib._VerifySyncUDWin("Tax", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkTax, dic["Tax"], 0);
                _gLib._VerifySyncUDWin("Trade", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkTrade, dic["Trade"], 0);
                _gLib._VerifySyncUDWin("Solvency", this.wNewLiabilityTypeFolder.wListLiabilityTypes.chkSolvency, dic["Solvency"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Assumptions");
        ///    dic.Add("Level_2", "Interest Rate");
        ///    dic.Add("Level_3", "FAS35Int");
        ///    dic.Add("Level_4", "Default");
        ///    pAssumptions._TreeViewSelect(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>

        public void _TreeViewSelect(MyDictionary dic, Boolean bClickItem = false)
        {
            string sFunctionName = "_TreeViewSelect";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TreeViewSelectWin(0, bClickItem, this.wRetirementStudio.tvNaviTree, dic);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2014-Aug-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Assumptions");
        ///    dic.Add("Level_2", "Interest Rate");
        ///    pAssumptions._Collapse(dic);
        ///    
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Provisions");
        ///    dic.Add("Level_2", "Formulae");
        ///    pAssumptions._Collapse(dic);
        /// 
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Participant Info");
        ///    pAssumptions._Collapse(dic);
        /// 
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Provisions");
        ///    pAssumptions._Collapse(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _Collapse(MyDictionary dic)
        {
            string sFunctionName = "_Collapse";

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TreeViewSelectWin(0, this.wRetirementStudio.tvNaviTree, dic);

            _gLib._SendKeysUDWin("Tree View", this.wRetirementStudio.tvNaviTree, "{Left}", false);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        public void _SelectTab(string sTabName)
        {
            string sFunctionName = "_SelectTab";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TabPageSelectWin(sTabName, this.wRetirementStudio.wTab, 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-12 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Other", "");
        ///    dic.Add("Adjustments", "");
        ///    dic.Add("RetWithdrawDis", "NHG3464");
        ///    dic.Add("Service", "");
        ///    dic.Add("AdjustmentOperator", "");
        ///    dic.Add("Adjustment_C", "");  
        ///    dic.Add("Adjustment_P", "");
        ///    dic.Add("Adjustment_T", "");
        ///    dic.Add("Adjustment_txt", "");
        ///    dic.Add("Adjustment_Tcbo", "");
        ///    dic.Add("Adjustment_Tcbo_extend", "");
        ///    pAssumptions._PopVerify_Assmp_Decrement_Parameters(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Assmp_Decrement_Parameters(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Assmp_Decrement_Parameters";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Other", this.wRetirementStudio.wAssmp_Decrement_Other.rd, dic["Other"], 0);
                _gLib._SetSyncUDWin("Adjustments", this.wRetirementStudio.wAssmp_Decrement_Para_Adjustments.chkAdjustments, dic["Adjustments"], 0);
                _gLib._SetSyncUDWin("RetWithdrawDis", this.wRetirementStudio.wAssmp_Decrement_Para_RetWithdrawDis_cbo.cbo_RetWithdrawDis, dic["RetWithdrawDis"], 0);
                _gLib._SetSyncUDWin("Service", this.wRetirementStudio.wAssmp_Decrement_Para_Service_cbo.cbo, dic["Service"], 0);
                _gLib._SetSyncUDWin("AdjustmentOperator", this.wRetirementStudio.wAssmp_Decrement_AdjustmentOperat.cbo, dic["AdjustmentOperator"], 0);
                _gLib._SetSyncUDWin("Adjustment_C", this.wRetirementStudio.wAssump_Decrement_Adjustment_C.btn, dic["Adjustment_C"], 0);
                _gLib._SetSyncUDWin("Adjustment_P", this.wRetirementStudio.wAssump_Decrement_Adjustment_P.btn, dic["Adjustment_P"], 0);
                _gLib._SetSyncUDWin("Adjustment_T", this.wRetirementStudio.wCommT.btn, dic["Adjustment_T"], 0);
                _gLib._SetSyncUDWin("Adjustment_Tcbo", this.wRetirementStudio.wAdjustment_Tcbo.cbo, dic["Adjustment_Tcbo"], 0);
                _gLib._SetSyncUDWin("Adjustment_Tcbo_extend", this.wRetirementStudio.wAdjustment_T_extend.cbo, dic["Adjustment_Tcbo_extend"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Adjustment_txt", this.wRetirementStudio.wAssmp_Decrement_Adjustment_txt.Edit.txt, dic["Adjustment_txt"], 0);
           
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Adjustments", this.wRetirementStudio.wAssmp_Decrement_Para_Adjustments.chkAdjustments, dic["Adjustments"], 0);
                _gLib._VerifySyncUDWin("RetWithdrawDis", this.wRetirementStudio.wAssmp_Decrement_Para_RetWithdrawDis_cbo.cbo_RetWithdrawDis, dic["RetWithdrawDis"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-12 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Month", "");
        ///    dic.Add("Year", "");
        ///    dic.Add("SolvencyBasis", "");
        ///    pAssumptions._PopVerify_Assmp_Solvency_UK(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Assmp_Solvency_UK(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Assmp_Solvency_UK";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Month", this.wRetirementStudio.wAssumption_Month_UK.cbo, dic["Month"], 0);
                _gLib._SetSyncUDWin("Year", this.wRetirementStudio.wAssumption_Year_UK.cbo, dic["Year"], 0);
                _gLib._SetSyncUDWin("SolvencyBasis", this.wRetirementStudio.wAssumption_SolvencyBasis_UK.cbo, dic["SolvencyBasis"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Month", this.wRetirementStudio.wAssumption_Month_UK.cbo, dic["Month"], 0);
                _gLib._VerifySyncUDWin("Year", this.wRetirementStudio.wAssumption_Year_UK.cbo, dic["Year"], 0);
                _gLib._VerifySyncUDWin("SolvencyBasis", this.wRetirementStudio.wAssumption_SolvencyBasis_UK.cbo, dic["SolvencyBasis"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-12 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PreDefinedEligibility", "True");
        ///    dic.Add("cboPreDefinedEligibility", "RetElig");
        ///    dic.Add("LocalEligibility", "");
        ///    dic.Add("txtLocalEligibility", "");
        ///    dic.Add("AddToEligibilities", "");
        ///    dic.Add("EligibilityCondition", "");
        ///    dic.Add("Validate", "");
        ///    pAssumptions._PopVerify_Assmp_Decrement_Conditions(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Assmp_Decrement_Conditions(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Assmp_Decrement_Conditions";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("PreDefinedEligibility", this.wRetirementStudio.wAssmp_Decrement_Cond_PreDefinedEligibility_rd.rdPreDefinedEligibility, dic["PreDefinedEligibility"], 0);
                _gLib._SetSyncUDWin("cboPreDefinedEligibility", this.wRetirementStudio.wAssmp_Decrement_Cond_PrdefinedEligibility_cbo.cboPreDefinedEligibility, dic["cboPreDefinedEligibility"], 0);
                _gLib._SetSyncUDWin("LocalEligibility", this.wRetirementStudio.wAssmp_Decrement_Cond_LocalEligibility_rd.rdLocalEligibility, dic["LocalEligibility"], 0);
                _gLib._SetSyncUDWin("txtLocalEligibility", this.wRetirementStudio.wAssmp_Decrement_Cond_LocalEligibility_txt.txtLocalEligibility, dic["txtLocalEligibility"], 0);
                _gLib._SetSyncUDWin("AddToEligibilities", this.wRetirementStudio.wAssmp_Decrement_Cond_AddToEligibilities.btnAddToEligibilities, dic["AddToEligibilities"], 0);
                _gLib._SetSyncUDWin_ByClipboard("EligibilityCondition", this.wRetirementStudio.wAssmp_Decrement_Cond_EligibilityCondition.txtEligibilityCondition, dic["EligibilityCondition"], 0);
                _gLib._SetSyncUDWin("Validate", this.wRetirementStudio.wValidate.btnValidate, dic["Validate"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Adjustments", this.wRetirementStudio.wAssmp_Decrement_Para_Adjustments.chkAdjustments, dic["Adjustments"], 0);
                _gLib._VerifySyncUDWin("RetWithdrawDis", this.wRetirementStudio.wAssmp_Decrement_Para_RetWithdrawDis_cbo.cbo_RetWithdrawDis, dic["RetWithdrawDis"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-12 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("Name", "");
        ///    dic.Add("Expression", "Max((0.01 * 6600.00 + 0.015*($PayAverage1 - 6600.00))* $BenefitService, $emp.AccruedBenefit1)");
        ///    dic.Add("Validate", "Click");
        ///    dic.Add("isInputName", "True");
        ///    pAssumptions._PopVerify_Provision_CustomCode(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Provision_CustomCode(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Provision_CustomCode";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (_gLib._Exists("Custom Code Radio Button", this.wRetirementStudio.wProvision_CustomCode_rd.rdCustomCode, 1, false))
                _gLib._SetSyncUDWin("Custom Code Radio Button", this.wRetirementStudio.wProvision_CustomCode_rd.rdCustomCode, "True", 0);

            _gLib._SetSyncUDWin("Validate", this.wRetirementStudio.wValidate.btnValidate, dic["Validate"], 0);

            if (dic["PopVerify"] == "Pop")
            {
                if (dic["iRow"] == "") // by default and most situations, it only has one row and focus on the Expression txt field
                {
                    _gLib._SetSyncUDWin("", this.wRetirementStudio.wProvision_CustomCode_FPGrid.grid, "Click", 0, false, 100, 50);
                    
                    if (!_gLib._Exists("text area", this.wRetirementStudio.wAssmp_Decrement_Cond_EligibilityCondition.txtEligibilityCondition, 1, false))
                        _gLib._SendKeysUDWin("text area", this.wRetirementStudio.wValidate.btnValidate, "{Tab}");

                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wAssmp_Decrement_Cond_EligibilityCondition.txtEligibilityCondition, "{Home}{Up}{Up}{Up}{Up}{Up}{Up}");
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wAssmp_Decrement_Cond_EligibilityCondition.txtEligibilityCondition, "{Down}{Down}{Down}{Down}{Down}{Down}{Down}{End}", 0, ModifierKeys.Shift, false);
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wAssmp_Decrement_Cond_EligibilityCondition.txtEligibilityCondition, "{Delete}");
                    _gLib._SetSyncUDWin_ByClipboard("Expression", this.wRetirementStudio.wAssmp_Decrement_Cond_EligibilityCondition.txtEligibilityCondition, dic["Expression"], 0);
                }
                else
                {
                    int iRow = Convert.ToInt32(dic["iRow"]);

                     /// for input name
                    if (dic["isInputName"].ToUpper() == "TRUE" && dic["Name"] != "")
                    {
                        int iHeight = 0;


                        _gLib._SetSyncUDWin("", this.wRetirementStudio.wProvision_CustomCode_FPGrid.grid, "Click", 0, false, 400, 15);
                        _gLib._SendKeysUDWin("text area", this.wRetirementStudio.wValidate.btnValidate, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}", 0, ModifierKeys.Shift, false);
                 

                        /// using difference methods for difference lines,
                        if (iRow <= 4)
                            iHeight = (this.wRetirementStudio.wProvision_CustomCode_FPGrid.grid.Height / 4) * (iRow - 1) + 30;
                        else
                        {
                            iHeight = (this.wRetirementStudio.wProvision_CustomCode_FPGrid.grid.Height / 4) * 3;
                            _gLib._SendKeysUDWin("text area", this.wRetirementStudio.wValidate.btnValidate, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}", 0);
                        }


                        _gLib._SetSyncUDWin("", this.wRetirementStudio.wProvision_CustomCode_FPGrid.grid, "Click", 0, false, 100, iHeight);
                        _gLib._SendKeysUDWin("name", this.wRetirementStudio.wInputTextBox_Internal.Edit, "{PageUp}{PageUp}{PageUp}{PageUp}{PageUp}", 0);
               
                        for (int i = 1; i <= 200; i++)
                        {
                            _gLib._SendKeysUDWin("name", this.wRetirementStudio.wInputTextBox_Internal.Edit, dic["Name"].Substring(0, 1), 0);
                            string sAct = this.wRetirementStudio.wInputTextBox_Internal.Edit.Text.Trim();

                            if (sAct == dic["Name"])
                            {
                                _gLib._SendKeysUDWin("", this.wRetirementStudio.wProvision_CustomCode_FPGrid.grid, "{Tab}", 0);
                                break;
                            }
                        }
                    }


                    _gLib._SetSyncUDWin("", this.wRetirementStudio.wProvision_CustomCode_FPGrid.grid, "Click", 0, false, 400, 15);
                    _gLib._SendKeysUDWin("text area", this.wRetirementStudio.wValidate.btnValidate, "{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}{Tab}", 0, ModifierKeys.Shift, false);
                
                    if (!_gLib._Exists("text area", this.wRetirementStudio.wAssmp_Decrement_Cond_EligibilityCondition.txtEligibilityCondition, 1, false))
                        _gLib._SendKeysUDWin("text area", this.wRetirementStudio.wValidate.btnValidate, "{Tab}");


                    for (int i = 1; i < iRow; i++)
                        _gLib._SendKeysUDWin("", this.wRetirementStudio.wProvision_CustomCode_FPGrid, "{Tab}");
                    _gLib._SetSyncUDWin_ByClipboard("Expression", this.wRetirementStudio.wAssmp_Decrement_Cond_EligibilityCondition.txtEligibilityCondition, dic["Expression"], 0);

                }


                _gLib._SetSyncUDWin("Validate", this.wRetirementStudio.wValidate.btnValidate, dic["Validate"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Expression", this.wRetirementStudio.wAssmp_Decrement_Cond_EligibilityCondition.txtEligibilityCondition, dic["Expression"], 0);
                _gLib._VerifySyncUDWin("Validate", this.wRetirementStudio.wValidate.btnValidate, dic["Validate"], 0);

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
