namespace RetirementStudio._UIMaps.FundingInformationClasses
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



    public partial class FundingInformation
    {
        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();


        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Funding Calculations");
        ///    dic.Add("Level_2", "Contributions");
        ///    pFundingInformation._TreeViewSelect(dic);
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
        ///    dic.Add("iRow", "1");
        ///    dic.Add("Date", "");
        ///    dic.Add("Category", "");
        ///    dic.Add("Amount", "");
        ///    dic.Add("PlanYear", "2010");
        ///    dic.Add("TaxYear", "2010");
        ///    dic.Add("Year2013", "");
        ///    dic.Add("MinimumRequiredContribution", "Yes");
        ///    dic.Add("ContributedByPBGC", "");
        ///    dic.Add("DeductedButNotIncluded", "");
        ///    dic.Add("IncludedButNotDeducted", "");
        ///    dic.Add("IncludeInPrefundingCreditBalance", "");
        ///    dic.Add("LateQuarterlyContribution", "Yes");
        ///    pFundingInformation._Contributions_Employer(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _Contributions_Employer(MyDictionary dic)
        {
            string sFunctionName = "_Contributions_Employer";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRow = Convert.ToInt32(dic["iRow"]);
            string sKeys = "";
            string sAct;
            int iPosX = 70;
            int iStartY = 20;
            int iStepY = 20;
            int iPosY = (iRow - 1) * iStepY + iStepY / 2 + iStartY;

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, "Click", 0, false, iPosX, iPosY);
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, "{Tab}{Home}{PageUp}{PageUp}{Home}");

            for (int i = 1; i < iRow; i++)
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, "{Down}");


            if (dic["Date"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, "{Tab}{Space}");
                _gLib._SetSyncUDWin_ByClipboard("Date", this.wRetirementStudio.wContributions_Date.txt, dic["Date"], 0);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, "{Tab}{Home}");
            }


            if (dic["Category"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, "{Home}{Tab}{Tab}{Space}");
                _gLib._SetSyncUDWin("Category", this.wRetirementStudio.wContributions_Employer_Category.cbo, dic["Category"], 0);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, "{Tab}{Home}");
            }

            if (dic["Amount"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, "{Home}{Tab}{Tab}{Tab}{Space}");
                _gLib._SetSyncUDWin_ByClipboard("Amount", this.wRetirementStudio.wContributions_Com_txt.txt, dic["Amount"], 0);
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, "{Tab}{Home}");
            }


            if (dic["PlanYear"] != "")
            {
                sKeys = "{Home}";
                for (int i = 1; i < 5; i++)
                    sKeys = sKeys + "{Right}";
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, sKeys + "{Enter}{Enter}");

                _gLib._SetSyncUDWin("PlanYear", this.wComBox.wbox.wList, dic["PlanYear"], 0, false);


                //this.wComBox.wbox.wList.item.SearchProperties.Add(WinListItem.PropertyNames.Name, dic["PlanYear"]);
                //_gLib._SetSyncUDWin("PlanYear", this.wComBox.wbox.wList.item, "click", 0, false);


                //_gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, sKeys);
                //sAct = _fp._ReturnSelectRowContent(this.wRetirementStudio.wContributions_Employer_FPGrid.grid);

                //if (sAct != dic["PlanYear"])
                //{
                //    _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to set PlanYear  <" + dic["PlanYear"] + "> at row < " + iRow + ">");
                //    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set PlanYear  <" + dic["PlanYear"] + "> at row < " + iRow + ">");
                //}
            }


            if (dic["TaxYear"] != "")
            {
                sKeys = "{Home}";
                for (int i = 1; i < 6; i++)
                    sKeys = sKeys + "{Right}";
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, sKeys + "{Enter}{Enter}");

                _gLib._SetSyncUDWin("TaxYear", this.wComBox.wbox.wList, dic["TaxYear"], 0, false);
            }


            if (dic["MinimumRequiredContribution"] != "")
            {
                sKeys = "{Home}";
                for (int i = 1; i < 7; i++)
                    sKeys = sKeys + "{Right}";
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, sKeys + "{Enter}{Enter}");

                _gLib._SetSyncUDWin("MinimumRequiredContribution", this.wComBox.wbox.wList, dic["MinimumRequiredContribution"], 0, false);
            }



            if (dic["ContributedByPBGC"] != "")
            {
                sKeys = "{Home}";
                for (int i = 1; i < 8; i++)
                    sKeys = sKeys + "{Right}";
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, sKeys + "{Enter}{Enter}");

                _gLib._SetSyncUDWin("ContributedByPBGC", this.wComBox.wbox.wList, dic["ContributedByPBGC"], 0, false);
            }


            if (dic["DeductedButNotIncluded"] != "")
            {
                sKeys = "{Home}";
                for (int i = 1; i < 9; i++)
                    sKeys = sKeys + "{Right}";
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, sKeys + "{Enter}{Enter}");

                _gLib._SetSyncUDWin("DeductedButNotIncluded", this.wComBox.wbox.wList, dic["DeductedButNotIncluded"], 0, false);
            }


            if (dic["IncludedButNotDeducted"] != "")
            {
                sKeys = "{Home}";
                for (int i = 1; i < 10; i++)
                    sKeys = sKeys + "{Right}";
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, sKeys + "{Enter}{Enter}");

                _gLib._SetSyncUDWin("IncludedButNotDeducted", this.wComBox.wbox.wList , dic["IncludedButNotDeducted"], 0, false);
            }




            if (dic["IncludeInPrefundingCreditBalance"] != "")
            {
                sKeys = "{Home}";
                for (int i = 1; i < 11; i++)
                    sKeys = sKeys + "{Right}";
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, sKeys + "{Enter}{Enter}");

                _gLib._SetSyncUDWin("IncludeInPrefundingCreditBalance", this.wComBox.wbox.wList, dic["IncludeInPrefundingCreditBalance"], 0, false);
            }


            if (dic["LateQuarterlyContribution"] != "")
            {
                sKeys = "{Home}";
                for (int i = 1; i < 13; i++)
                    sKeys = sKeys + "{Right}";
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, sKeys + "{Enter}{Enter}");

                _gLib._SetSyncUDWin("LateQuarterlyContribution", this.wComBox.wbox.wList,  dic["LateQuarterlyContribution"], 0, false);
            }

            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wContributions_Employer_FPGrid.grid, "{Home}");
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 2013-May-19 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("PlanYearBeginDate", "01/01/2012");
        ///    dic.Add("PlanYearEndDate", "12/31/2012");
        ///    dic.Add("CurrentYareNumOfParcipants", "131");
        ///    dic.Add("YearsForShortfallAmortization", "");
        ///    pFundingInformation._PopVerify_GI_GeneralInformation(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GI_GeneralInformation(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GI_GeneralInformation";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("PlanYearBeginDate", this.wRetirementStudio.wGI_PlanYearBeginDate.cboPlanYearBeginDate.txtPlanYearBeginDate, dic["PlanYearBeginDate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PlanYearEndDate", this.wRetirementStudio.wGI_PlanYearEndDate.cboPlanYearEndDate.txtPlanYearEndDate, dic["PlanYearEndDate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("CurrentYareNumOfParcipants", this.wRetirementStudio.wGI_CurrentYareNumOfParcipants.txtCurrentYareNumOfParcipants, dic["CurrentYareNumOfParcipants"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("YearsForShortfallAmortization", this.wRetirementStudio.wGI_YearsForShortfallAmortization.txtYearsForShortfallAmortization, dic["YearsForShortfallAmortization"], true, 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("PlanYearBeginDate", this.wRetirementStudio.wGI_PlanYearBeginDate.cboPlanYearBeginDate.txtPlanYearBeginDate, dic["PlanYearBeginDate"], 0);
                _gLib._VerifySyncUDWin("PlanYearEndDate", this.wRetirementStudio.wGI_PlanYearEndDate.cboPlanYearEndDate.txtPlanYearEndDate, dic["PlanYearEndDate"], 0);
                _gLib._VerifySyncUDWin("CurrentYareNumOfParcipants", this.wRetirementStudio.wGI_CurrentYareNumOfParcipants.txtCurrentYareNumOfParcipants, dic["CurrentYareNumOfParcipants"], 0);
                _gLib._VerifySyncUDWin("YearsForShortfallAmortization", this.wRetirementStudio.wGI_YearsForShortfallAmortization.txtYearsForShortfallAmortization, dic["YearsForShortfallAmortization"], 0);


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
        ///    dic.Add("UseStablized", "");
        ///    dic.Add("UseUnstablized", "");
        ///    dic.Add("ExpenseLoad_None", "");
        ///    dic.Add("ExpenseLoad_Percent", "");
        ///    dic.Add("ExpenseLoad_Constant", "");
        ///    pFundingInformation._PopVerify_GI_MaximumDeductible(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GI_MaximumDeductible(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GI_MaximumDeductible";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("UseStablized", this.wRetirementStudio.wGI_MaxDeductible_UseStablized.rdMaxDeductible_UseStablized, dic["UseStablized"], 0);
                _gLib._SetSyncUDWin("UseUnstablized", this.wRetirementStudio.wGI_MaxDeductible_UseUnstablized.rdMaxDeductible_UseUnstablized, dic["UseUnstablized"], 0);
                _gLib._SetSyncUDWin("ExpenseLoad_None", this.wRetirementStudio.wGI_ExpenseLoad_None.rdExpenseLoad_None, dic["ExpenseLoad_None"], 0);
                _gLib._SetSyncUDWin("ExpenseLoad_Percent", this.wRetirementStudio.wGI_ExpenseLoad_Percent.rdExpenseLoad_Percent, dic["ExpenseLoad_Percent"], 0);
                _gLib._SetSyncUDWin("ExpenseLoad_Constant", this.wRetirementStudio.wGI_ExpenseLoad_Constant.rdExpenseLoad_Constant, dic["ExpenseLoad_Constant"], 0);



            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("UseStablized", this.wRetirementStudio.wGI_MaxDeductible_UseStablized.rdMaxDeductible_UseStablized, dic["UseStablized"], 0);
                _gLib._VerifySyncUDWin("UseUnstablized", this.wRetirementStudio.wGI_MaxDeductible_UseUnstablized.rdMaxDeductible_UseUnstablized, dic["UseUnstablized"], 0);
                _gLib._VerifySyncUDWin("ExpenseLoad_None", this.wRetirementStudio.wGI_ExpenseLoad_None.rdExpenseLoad_None, dic["ExpenseLoad_None"], 0);
                _gLib._VerifySyncUDWin("ExpenseLoad_Percent", this.wRetirementStudio.wGI_ExpenseLoad_Percent.rdExpenseLoad_Percent, dic["ExpenseLoad_Percent"], 0);
                _gLib._VerifySyncUDWin("ExpenseLoad_Constant", this.wRetirementStudio.wGI_ExpenseLoad_Constant.rdExpenseLoad_Constant, dic["ExpenseLoad_Constant"], 0);

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
        ///    dic.Add("ExpectedEEContrib", "");
        ///    pFundingInformation._PopVerify_GI_TimeWeighting(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GI_TimeWeighting(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GI_TimeWeighting";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ExpectedEEContrib", this.wRetirementStudio.wGI_TimeWeighting_ExpectedEEContrib.txtTimeWeighting_ExpectedEEContrib, dic["ExpectedEEContrib"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("ExpectedEEContrib", this.wRetirementStudio.wGI_TimeWeighting_ExpectedEEContrib.txtTimeWeighting_ExpectedEEContrib, dic["ExpectedEEContrib"], 0);
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
        ///    dic.Add("Amount", "");
        ///    dic.Add("YearsOfAmortization", "");
        ///    pFundingInformation._PopVerify_GI_WaivedFunding(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GI_WaivedFunding(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GI_WaivedFunding";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Amount", this.wRetirementStudio.wGI_WaivedFunding_Amount.txtWaivedFunding_Amount, dic["Amount"], 0);
                _gLib._SetSyncUDWin("YearsOfAmortization", this.wRetirementStudio.wGI_WaivedFunding_YearsOfAmortization.txtWaivedFunding_YearsOfAmortization, dic["YearsOfAmortization"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Amount", this.wRetirementStudio.wGI_WaivedFunding_Amount.txtWaivedFunding_Amount, dic["Amount"], 0);
                _gLib._VerifySyncUDWin("YearsOfAmortization", this.wRetirementStudio.wGI_WaivedFunding_YearsOfAmortization.txtWaivedFunding_YearsOfAmortization, dic["YearsOfAmortization"], 0);

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
        ///    dic.Add("VoluntaryCOB", "");
        ///    dic.Add("ApplyCalculated_Yes", "");
        ///    dic.Add("ApplyCalculated_No", "");
        ///    dic.Add("ClientDecision_Yes", "");
        ///    dic.Add("ClientDecision_No", "");
        ///    dic.Add("ClientDecision_Unknown", "");
        ///    dic.Add("PBGCAgreement_Yes", "");
        ///    dic.Add("PBGCAgreement_No", "");
        ///    dic.Add("PBGCAgreement_Unknown", "");
        ///    pFundingInformation._PopVerify_GI_CarryoverBalance(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GI_CarryoverBalance(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GI_CarryoverBalance";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("VoluntaryCOB", this.wRetirementStudio.wGI_CarryoverBalance_VoluntaryCOB.txtCarryoverBalance_VoluntaryCOB, dic["VoluntaryCOB"], true, 0);
                _gLib._SetSyncUDWin("ApplyCalculated_Yes", this.wRetirementStudio.wGI_CarryoverBalance_ApplyCalculated_Yes.rdCarryoverBalance_ApplyCalculated_Yes, dic["ApplyCalculated_Yes"], 0);
                _gLib._SetSyncUDWin("ApplyCalculated_No", this.wRetirementStudio.wGI_CarryoverBalance_ApplyCalculated_No.rdCarryoverBalance_ApplyCalculated_No, dic["ApplyCalculated_No"], 0);
                _gLib._SetSyncUDWin("ClientDecision_Yes", this.wRetirementStudio.wGI_CarryoverBalance_ClientDecision_Yes.rdCarryoverBalance_ClientDecision_Yes, dic["ClientDecision_Yes"], 0);
                _gLib._SetSyncUDWin("ClientDecision_No", this.wRetirementStudio.wGI_CarryoverBalance_ClientDecision_No.rdCarryoverBalance_ClientDecision_No, dic["ClientDecision_No"], 0);
                _gLib._SetSyncUDWin("ClientDecision_Unknown", this.wRetirementStudio.wGI_CarryoverBalance_ClientDecision_Unknown.rdCarryoverBalance_ClientDecision_Unknown, dic["ClientDecision_Unknown"], 0);
                _gLib._SetSyncUDWin("PBGCAgreement_Yes", this.wRetirementStudio.wGI_CarryoverBalance_PBGCAgreement_Yes.rdCarryoverBalance_PBGCAgreement_Yes, dic["PBGCAgreement_Yes"], 0);
                _gLib._SetSyncUDWin("PBGCAgreement_No", this.wRetirementStudio.wGI_CarryoverBalance_PBGCAgreement_No.rdCarryoverBalance_PBGCAgreement_No, dic["PBGCAgreement_No"], 0);
                _gLib._SetSyncUDWin("PBGCAgreement_Unknown", this.wRetirementStudio.wGI_CarryoverBalance_PBGCAgreement_Unknown.rdCarryoverBalance_PBGCAgreement_Unknown, dic["PBGCAgreement_Unknown"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("VoluntaryCOB", this.wRetirementStudio.wGI_CarryoverBalance_VoluntaryCOB.txtCarryoverBalance_VoluntaryCOB, dic["VoluntaryCOB"], 0);
                _gLib._VerifySyncUDWin("ApplyCalculated_Yes", this.wRetirementStudio.wGI_CarryoverBalance_ApplyCalculated_Yes.rdCarryoverBalance_ApplyCalculated_Yes, dic["ApplyCalculated_Yes"], 0);
                _gLib._VerifySyncUDWin("ApplyCalculated_No", this.wRetirementStudio.wGI_CarryoverBalance_ApplyCalculated_No.rdCarryoverBalance_ApplyCalculated_No, dic["ApplyCalculated_No"], 0);
                _gLib._VerifySyncUDWin("ClientDecision_Yes", this.wRetirementStudio.wGI_CarryoverBalance_ClientDecision_Yes.rdCarryoverBalance_ClientDecision_Yes, dic["ClientDecision_Yes"], 0);
                _gLib._VerifySyncUDWin("ClientDecision_No", this.wRetirementStudio.wGI_CarryoverBalance_ClientDecision_No.rdCarryoverBalance_ClientDecision_No, dic["ClientDecision_No"], 0);
                _gLib._VerifySyncUDWin("ClientDecision_Unknown", this.wRetirementStudio.wGI_CarryoverBalance_ClientDecision_Unknown.rdCarryoverBalance_ClientDecision_Unknown, dic["ClientDecision_Unknown"], 0);
                _gLib._VerifySyncUDWin("PBGCAgreement_Yes", this.wRetirementStudio.wGI_CarryoverBalance_PBGCAgreement_Yes.rdCarryoverBalance_PBGCAgreement_Yes, dic["PBGCAgreement_Yes"], 0);
                _gLib._VerifySyncUDWin("PBGCAgreement_No", this.wRetirementStudio.wGI_CarryoverBalance_PBGCAgreement_No.rdCarryoverBalance_PBGCAgreement_No, dic["PBGCAgreement_No"], 0);
                _gLib._VerifySyncUDWin("PBGCAgreement_Unknown", this.wRetirementStudio.wGI_CarryoverBalance_PBGCAgreement_Unknown.rdCarryoverBalance_PBGCAgreement_Unknown, dic["PBGCAgreement_Unknown"], 0);

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
        ///    dic.Add("VoluntaryCOB", "");
        ///    dic.Add("ApplyCalculated_Yes", "");
        ///    dic.Add("ApplyCalculated_No", "");
        ///    dic.Add("ClientDecision_Yes", "");
        ///    dic.Add("ClientDecision_No", "");
        ///    dic.Add("ClientDecision_Unknown", "");
        ///    dic.Add("PBGCAgreement_Yes", "");
        ///    dic.Add("PBGCAgreement_No", "");
        ///    dic.Add("PBGCAgreement_Unknown", "");
        ///    pFundingInformation._PopVerify_GI_PrefundingBalance(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GI_PrefundingBalance(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GI_PrefundingBalance";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("VoluntaryCOB", this.wRetirementStudio.wGI_PrefundingBalance_VoluntaryPFB.txtPrefundingBalance_VoluntaryPFB, dic["VoluntaryCOB"], true, 0);
                _gLib._SetSyncUDWin("ApplyCalculated_Yes", this.wRetirementStudio.wGI_PrefundingBalance_ApplyCalcuted_Yes.rdPrefundingBalance_ApplyCalcuted_Yes, dic["ApplyCalculated_Yes"], 0);
                _gLib._SetSyncUDWin("ApplyCalculated_No", this.wRetirementStudio.wGI_PrefundingBalance_ApplyCalcuted_No.rdPrefundingBalance_ApplyCalcuted_No, dic["ApplyCalculated_No"], 0);
                _gLib._SetSyncUDWin("ClientDecision_Yes", this.wRetirementStudio.wGI_PrefundingBalance_ClientDecision_Yes.rdPrefundingBalance_ClientDecision_Yes, dic["ClientDecision_Yes"], 0);
                _gLib._SetSyncUDWin("ClientDecision_No", this.wRetirementStudio.wGI_PrefundingBalance_ClientDecision_No.rdPrefundingBalance_ClientDecision_No, dic["ClientDecision_No"], 0);
                _gLib._SetSyncUDWin("ClientDecision_Unknown", this.wRetirementStudio.wGI_PrefundingBalance_ClientDecision_Unknown.rdPrefundingBalance_ClientDecision_Unknown, dic["ClientDecision_Unknown"], 0);
                _gLib._SetSyncUDWin("PBGCAgreement_Yes", this.wRetirementStudio.wGI_PrefundingBalance_PBGCAgreement_Yes.rdPrefundingBalance_PBGCAgreement_Yes, dic["PBGCAgreement_Yes"], 0);
                _gLib._SetSyncUDWin("PBGCAgreement_No", this.wRetirementStudio.wGI_PrefundingBalance_PBGCAgreement_No.rdPrefundingBalance_PBGCAgreement_No, dic["PBGCAgreement_No"], 0);
                _gLib._SetSyncUDWin("PBGCAgreement_Unknown", this.wRetirementStudio.wGI_PrefundingBalance_PBGCAgreement_Unknown.rdPrefundingBalance_PBGCAgreement_Unknown, dic["PBGCAgreement_Unknown"], 0);


            }

            if (dic["PopVerify"] == "Verify")
            {


                _gLib._VerifySyncUDWin("VoluntaryCOB", this.wRetirementStudio.wGI_PrefundingBalance_VoluntaryPFB.txtPrefundingBalance_VoluntaryPFB, dic["VoluntaryCOB"], 0);
                _gLib._VerifySyncUDWin("ApplyCalculated_Yes", this.wRetirementStudio.wGI_PrefundingBalance_ApplyCalcuted_Yes.rdPrefundingBalance_ApplyCalcuted_Yes, dic["ApplyCalculated_Yes"], 0);
                _gLib._VerifySyncUDWin("ApplyCalculated_No", this.wRetirementStudio.wGI_PrefundingBalance_ApplyCalcuted_No.rdPrefundingBalance_ApplyCalcuted_No, dic["ApplyCalculated_No"], 0);
                _gLib._VerifySyncUDWin("ClientDecision_Yes", this.wRetirementStudio.wGI_PrefundingBalance_ClientDecision_Yes.rdPrefundingBalance_ClientDecision_Yes, dic["ClientDecision_Yes"], 0);
                _gLib._VerifySyncUDWin("ClientDecision_No", this.wRetirementStudio.wGI_PrefundingBalance_ClientDecision_No.rdPrefundingBalance_ClientDecision_No, dic["ClientDecision_No"], 0);
                _gLib._VerifySyncUDWin("ClientDecision_Unknown", this.wRetirementStudio.wGI_PrefundingBalance_ClientDecision_Unknown.rdPrefundingBalance_ClientDecision_Unknown, dic["ClientDecision_Unknown"], 0);
                _gLib._VerifySyncUDWin("PBGCAgreement_Yes", this.wRetirementStudio.wGI_PrefundingBalance_PBGCAgreement_Yes.rdPrefundingBalance_PBGCAgreement_Yes, dic["PBGCAgreement_Yes"], 0);
                _gLib._VerifySyncUDWin("PBGCAgreement_No", this.wRetirementStudio.wGI_PrefundingBalance_PBGCAgreement_No.rdPrefundingBalance_PBGCAgreement_No, dic["PBGCAgreement_No"], 0);
                _gLib._VerifySyncUDWin("PBGCAgreement_Unknown", this.wRetirementStudio.wGI_PrefundingBalance_PBGCAgreement_Unknown.rdPrefundingBalance_PBGCAgreement_Unknown, dic["PBGCAgreement_Unknown"], 0);

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
        ///    dic.Add("PlanSponsor_Yes", "");
        ///    dic.Add("PlanSponsor_No", "");
        ///    dic.Add("PlanSponsor_Unknown", "");
        ///    dic.Add("IncreaseDueToPlanAmendment", "");
        ///    dic.Add("ExemptFrom_Yes", "");
        ///    dic.Add("ExemptFrom_No", "");
        ///    dic.Add("ExemptFrom_Unknown", "");
        ///    dic.Add("IncreaseDueToShutdown", "");
        ///    dic.Add("OriginalPlanEffectiveDate", "");
        ///    dic.Add("PlanWasFrozen_Yes", "");
        ///    dic.Add("PlanWasFrozen_No", "");
        ///    dic.Add("PlanWasFrozen_Unknown", "");
        ///    pFundingInformation._PopVerify_GI_BenefitRestriction(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GI_BenefitRestriction(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GI_BenefitRestriction";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("PlanSponsor_Yes", this.wRetirementStudio.wGI_BenefitRestriction_PlanSponsor_Yes.rdBenefitRestriction_PlanSponsor_Yes, dic["PlanSponsor_Yes"], 0);
                _gLib._SetSyncUDWin("PlanSponsor_No", this.wRetirementStudio.wGI_BenefitRestriction_PlanSponsor_No.rdBenefitRestriction_PlanSponsor_No, dic["PlanSponsor_No"], 0);
                _gLib._SetSyncUDWin("PlanSponsor_Unknown", this.wRetirementStudio.wGI_BenefitRestriction_PlanSponsor_Unknown.rdBenefitRestriction_PlanSponsor_Unknown, dic["PlanSponsor_Unknown"], 0);
                _gLib._SetSyncUDWin_ByClipboard("IncreaseDueToPlanAmendment", this.wRetirementStudio.wGI_BenefitRestriction_IncreaseDueToPlanAmendment.txtBenefitRestriction_IncreaseDueToPlanAmendment, dic["IncreaseDueToPlanAmendment"], true, 0);
                _gLib._SetSyncUDWin("ExemptFrom_Yes", this.wRetirementStudio.wGI_BenefitRestriction_ExemptFrom_Yes.rdBenefitRestriction_ExemptFrom_Yes, dic["ExemptFrom_Yes"], 0);
                _gLib._SetSyncUDWin("ExemptFrom_No", this.wRetirementStudio.wGI_BenefitRestriction_ExemptFrom_No.rdBenefitRestriction_ExemptFrom_No, dic["ExemptFrom_No"], 0);
                _gLib._SetSyncUDWin("ExemptFrom_Unknown", this.wRetirementStudio.wGI_BenefitRestriction_ExemptFrom_Unknown.rdBenefitRestriction_ExemptFrom_Unknown, dic["ExemptFrom_Unknown"], 0);
                _gLib._SetSyncUDWin_ByClipboard("IncreaseDueToShutdown", this.wRetirementStudio.wGI_BenefitRestriction_IncreaseDueToShutdown.txtBenefitRestriction_IncreaseDueToShutdown, dic["IncreaseDueToShutdown"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("OriginalPlanEffectiveDate", this.wRetirementStudio.wGI_BenefitRestriction_OriginalPlanEffectiveDate.cboBenefitRestriction_OriginalPlanEffectiveDate.txtBenefitRestriction_OriginalPlanEffectiveDate, dic["OriginalPlanEffectiveDate"], 0);
                _gLib._SetSyncUDWin("PlanWasFrozen_Yes", this.wRetirementStudio.wGI_BenefitRestriction_PlanWasFrozen_Yes.rdBenefitRestriction_PlanWasFrozen_Yes, dic["PlanWasFrozen_Yes"], 0);
                _gLib._SetSyncUDWin("PlanWasFrozen_No", this.wRetirementStudio.wGI_BenefitRestriction_PlanWasFrozen_No.rdBenefitRestriction_PlanWasFrozen_No, dic["PlanWasFrozen_No"], 0);
                _gLib._SetSyncUDWin("PlanWasFrozen_Unknown", this.wRetirementStudio.wGI_BenefitRestriction_PlanWasFrozen_Unknown.rdBenefitRestriction_PlanWasFrozen_Unknown, dic["PlanWasFrozen_Unknown"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("PlanSponsor_Yes", this.wRetirementStudio.wGI_BenefitRestriction_PlanSponsor_Yes.rdBenefitRestriction_PlanSponsor_Yes, dic["PlanSponsor_Yes"], 0);
                _gLib._VerifySyncUDWin("PlanSponsor_No", this.wRetirementStudio.wGI_BenefitRestriction_PlanSponsor_No.rdBenefitRestriction_PlanSponsor_No, dic["PlanSponsor_No"], 0);
                _gLib._VerifySyncUDWin("PlanSponsor_Unknown", this.wRetirementStudio.wGI_BenefitRestriction_PlanSponsor_Unknown.rdBenefitRestriction_PlanSponsor_Unknown, dic["PlanSponsor_Unknown"], 0);
                _gLib._VerifySyncUDWin("IncreaseDueToPlanAmendment", this.wRetirementStudio.wGI_BenefitRestriction_IncreaseDueToPlanAmendment.txtBenefitRestriction_IncreaseDueToPlanAmendment, dic["IncreaseDueToPlanAmendment"], 0);
                _gLib._VerifySyncUDWin("ExemptFrom_Yes", this.wRetirementStudio.wGI_BenefitRestriction_ExemptFrom_Yes.rdBenefitRestriction_ExemptFrom_Yes, dic["ExemptFrom_Yes"], 0);
                _gLib._VerifySyncUDWin("ExemptFrom_No", this.wRetirementStudio.wGI_BenefitRestriction_ExemptFrom_No.rdBenefitRestriction_ExemptFrom_No, dic["ExemptFrom_No"], 0);
                _gLib._VerifySyncUDWin("ExemptFrom_Unknown", this.wRetirementStudio.wGI_BenefitRestriction_ExemptFrom_Unknown.rdBenefitRestriction_ExemptFrom_Unknown, dic["ExemptFrom_Unknown"], 0);
                _gLib._VerifySyncUDWin("IncreaseDueToShutdown", this.wRetirementStudio.wGI_BenefitRestriction_IncreaseDueToShutdown.txtBenefitRestriction_IncreaseDueToShutdown, dic["IncreaseDueToShutdown"], 0);
                _gLib._VerifySyncUDWin("OriginalPlanEffectiveDate", this.wRetirementStudio.wGI_BenefitRestriction_OriginalPlanEffectiveDate.cboBenefitRestriction_OriginalPlanEffectiveDate.txtBenefitRestriction_OriginalPlanEffectiveDate, dic["OriginalPlanEffectiveDate"], 0);
                _gLib._VerifySyncUDWin("PlanWasFrozen_Yes", this.wRetirementStudio.wGI_BenefitRestriction_PlanWasFrozen_Yes.rdBenefitRestriction_PlanWasFrozen_Yes, dic["PlanWasFrozen_Yes"], 0);
                _gLib._VerifySyncUDWin("PlanWasFrozen_No", this.wRetirementStudio.wGI_BenefitRestriction_PlanWasFrozen_No.rdBenefitRestriction_PlanWasFrozen_No, dic["PlanWasFrozen_No"], 0);
                _gLib._VerifySyncUDWin("PlanWasFrozen_Unknown", this.wRetirementStudio.wGI_BenefitRestriction_PlanWasFrozen_Unknown.rdBenefitRestriction_PlanWasFrozen_Unknown, dic["PlanWasFrozen_Unknown"], 0);

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
        ///    dic.Add("CompanyName", "");
        ///    dic.Add("Telephone", "");
        ///    dic.Add("AddressLine1", "");
        ///    dic.Add("AddressLine2", "");
        ///    dic.Add("AddressLine3", "");
        ///    dic.Add("Signer1Name", "");
        ///    dic.Add("Signer1Credential", "");
        ///    dic.Add("Signer2Name", "");
        ///    dic.Add("Signer2Credential", "");
        ///    dic.Add("PeerReviewName", "");
        ///    dic.Add("PeerReviewCredentials", "");
        ///    dic.Add("RoundingScalingOptions_Thousands69470000", "");
        ///    pFundingInformation._PopVerify_GI_ActuarialReport(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GI_ActuarialReport(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GI_ActuarialReport";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("CompanyName", this.wRetirementStudio.wGI_CompanyName.txtCompanyName, dic["CompanyName"], 0);
                _gLib._SetSyncUDWin("Telephone", this.wRetirementStudio.wGI_Telephone.txtTelephone, dic["Telephone"], 0);
                _gLib._SetSyncUDWin("AddressLine1", this.wRetirementStudio.wGI_AddressLine1.txtAddressLine1, dic["AddressLine1"], 0);
                _gLib._SetSyncUDWin("AddressLine2", this.wRetirementStudio.wGI_AddressLine2.txtAddressLine2, dic["AddressLine2"], 0);
                _gLib._SetSyncUDWin("AddressLine3", this.wRetirementStudio.wGI_AddressLine3.txtAddressLine3, dic["AddressLine3"], 0);
                _gLib._SetSyncUDWin("Signer1Name", this.wRetirementStudio.wGI_Signer1Name.txtSigner1Name, dic["Signer1Name"], 0);
                _gLib._SetSyncUDWin("Signer1Credential", this.wRetirementStudio.wGI_Signer1Credential.txtSigner1Credential, dic["Signer1Credential"], 0);
                _gLib._SetSyncUDWin("Signer2Name", this.wRetirementStudio.wGI_Signer2Name.txtSigner2Name, dic["Signer2Name"], 0);
                _gLib._SetSyncUDWin("Signer2Credential", this.wRetirementStudio.wGI_Signer2Credential.txtSigner2Credential, dic["Signer2Credential"], 0);
                _gLib._SetSyncUDWin("PeerReviewName", this.wRetirementStudio.wGI_PeerReviewName.txtPeerReviewName, dic["PeerReviewName"], 0);
                _gLib._SetSyncUDWin("PeerReviewCredentials", this.wRetirementStudio.wGI_PeerReviewCredentials.txtPeerReviewCredentials, dic["PeerReviewCredentials"], 0);
                _gLib._SetSyncUDWin("RoundingScalingOptions_Thousands69470000", this.wRetirementStudio.wGP_RoundingScalingOptions_Thousands69470000.rd, dic["RoundingScalingOptions_Thousands69470000"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("CompanyName", this.wRetirementStudio.wGI_CompanyName.txtCompanyName, dic["CompanyName"], 0);
                _gLib._VerifySyncUDWin("Telephone", this.wRetirementStudio.wGI_Telephone.txtTelephone, dic["Telephone"], 0);
                _gLib._VerifySyncUDWin("AddressLine1", this.wRetirementStudio.wGI_AddressLine1.txtAddressLine1, dic["AddressLine1"], 0);
                _gLib._VerifySyncUDWin("AddressLine2", this.wRetirementStudio.wGI_AddressLine2.txtAddressLine2, dic["AddressLine2"], 0);
                _gLib._VerifySyncUDWin("AddressLine3", this.wRetirementStudio.wGI_AddressLine3.txtAddressLine3, dic["AddressLine3"], 0);
                _gLib._VerifySyncUDWin("Signer1Name", this.wRetirementStudio.wGI_Signer1Name.txtSigner1Name, dic["Signer1Name"], 0);
                _gLib._VerifySyncUDWin("Signer1Credential", this.wRetirementStudio.wGI_Signer1Credential.txtSigner1Credential, dic["Signer1Credential"], 0);
                _gLib._VerifySyncUDWin("Signer2Name", this.wRetirementStudio.wGI_Signer2Name.txtSigner2Name, dic["Signer2Name"], 0);
                _gLib._VerifySyncUDWin("Signer2Credential", this.wRetirementStudio.wGI_Signer2Credential.txtSigner2Credential, dic["Signer2Credential"], 0);
                _gLib._VerifySyncUDWin("PeerReviewName", this.wRetirementStudio.wGI_PeerReviewName.txtPeerReviewName, dic["PeerReviewName"], 0);
                _gLib._VerifySyncUDWin("PeerReviewCredentials", this.wRetirementStudio.wGI_PeerReviewCredentials.txtPeerReviewCredentials, dic["PeerReviewCredentials"], 0);
                _gLib._VerifySyncUDWin("RoundingScalingOptions_Thousands69470000", this.wRetirementStudio.wGP_RoundingScalingOptions_Thousands69470000.rd, dic["RoundingScalingOptions_Thousands69470000"], 0);

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
        ///    dic.Add("SummaryView", "");
        ///    dic.Add("DetailView", "True");
        ///    dic.Add("TabName", "Preliminary Results and PGBC Premiums");
        ///    pFundingInformation._PopVerify_PriorYearResults_Main(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PriorYearResults_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PriorYearResults_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("SummaryView", this.wRetirementStudio.wPYR_SummaryView.rdSummaryView, dic["SummaryView"], 0);
                _gLib._SetSyncUDWin("DetailView", this.wRetirementStudio.wPYR_DetailView.rdDetailView, dic["DetailView"], 0);
                if (dic["TabName"] != "")
                {
                    this.wRetirementStudio.wPYR_Tab.listTab.item.SearchProperties.Add(WinTabPage.PropertyNames.Name, dic["TabName"], PropertyExpressionOperator.Contains);
                    _gLib._SetSyncUDWin("Tab:  " + dic["TabName"], this.wRetirementStudio.wPYR_Tab.listTab.item, "Click", 0);
                }
            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("SummaryView", this.wRetirementStudio.wPYR_SummaryView.rdSummaryView, dic["SummaryView"], 0);
                _gLib._VerifySyncUDWin("DetailView", this.wRetirementStudio.wPYR_DetailView.rdDetailView, dic["DetailView"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }



        /// <summary>
        /// 2013-May-28
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("UseEstimatedLiabilities", "");
        ///    dic.Add("FundingService", "");
        ///    dic.Add("ValuationNode", "");
        ///    dic.Add("EstimatedGL", "");
        ///    dic.Add("KnownWorkforceChanges", "");
        ///    dic.Add("Other", "");
        ///    pFundingInformation._PopVerify_EstimatedLiabilities(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_EstimatedLiabilities(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_EstimatedLiabilities";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("UseEstimatedLiabilities", this.wRetirementStudio.wEL_UseEstimatedLiabilities.chkUseEstimatedLiabilities, dic["UseEstimatedLiabilities"], 0);
                _gLib._SetSyncUDWin("FundingService", this.wRetirementStudio.wEL_FundingService.cboFundingService, dic["FundingService"], 0);
                _gLib._SetSyncUDWin("ValuationNode", this.wRetirementStudio.wEL_ValuationNode.cboValuationNode, dic["ValuationNode"], 0);
                _gLib._SetSyncUDWin_ByClipboard("EstimatedGL", this.wRetirementStudio.wGI_PrefundingBalance_VoluntaryPFB.txtPrefundingBalance_VoluntaryPFB, dic["EstimatedGL"], 0);
                _gLib._SetSyncUDWin_ByClipboard("KnownWorkforceChanges", this.wRetirementStudio.wGI_BenefitRestriction_IncreaseDueToShutdown.txtBenefitRestriction_IncreaseDueToShutdown, dic["KnownWorkforceChanges"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Other", this.wRetirementStudio.wGI_BenefitRestriction_IncreaseDueToPlanAmendment.txtBenefitRestriction_IncreaseDueToPlanAmendment, dic["Other"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {


                _gLib._VerifySyncUDWin("UseEstimatedLiabilities", this.wRetirementStudio.wEL_UseEstimatedLiabilities.chkUseEstimatedLiabilities, dic["UseEstimatedLiabilities"], 0);
                _gLib._VerifySyncUDWin("FundingService", this.wRetirementStudio.wEL_FundingService.cboFundingService, dic["FundingService"], 0);
                _gLib._VerifySyncUDWin("ValuationNode", this.wRetirementStudio.wEL_ValuationNode.cboValuationNode, dic["ValuationNode"], 0);
                _gLib._VerifySyncUDWin("EstimatedGL", this.wRetirementStudio.wGI_PrefundingBalance_VoluntaryPFB.txtPrefundingBalance_VoluntaryPFB, dic["EstimatedGL"], 0);
                _gLib._VerifySyncUDWin("KnownWorkforceChanges", this.wRetirementStudio.wGI_BenefitRestriction_IncreaseDueToShutdown.txtBenefitRestriction_IncreaseDueToShutdown, dic["KnownWorkforceChanges"], 0);
                _gLib._VerifySyncUDWin("Other", this.wRetirementStudio.wGI_BenefitRestriction_IncreaseDueToPlanAmendment.txtBenefitRestriction_IncreaseDueToPlanAmendment, dic["Other"], 0);


            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 
        /// 2013-May-29
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("SnapshotName", "Dec 31 2007 MV");
        ///    pFundingInformation._AssetSnapshot(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _AssetSnapshot(MyDictionary dic)
        {
            string sFunctionName = "_AssetSnapshot";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRow = Convert.ToInt32(dic["iRow"]);

            int xPos = 50;
            int yPos = 10 + iRow * 20;
            _gLib._SetSyncUDWin("AssetSnapshot_grid", this.wRetirementStudio.wAssets_AssetsSnapshots_FPGrid.grid, "Click", 0, false, xPos, yPos);

            string sContent = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wAssets_AssetsSnapshots_FPGrid.grid);
            if (!sContent.Contains(dic["SnapshotName"]))
            {
                _gLib._MsgBoxYesNo("Continue Testing?", "Function <" + sFunctionName + "> failed to select snapshot <" + dic["SnapshotName"] + "> !");
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed to select snapshot <" + dic["SnapshotName"] + "> !");
            }
            else
                _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully  selected snapshot <" + dic["SnapshotName"] + "> !");

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");


        }


        /// <summary>
        /// 
        /// 2013-May-29
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "4");
        ///    dic.Add("sRow", "WithDrawalFromActive");
        ///    dic.Add("iCol", "4");
        ///    dic.Add("sCol", "PriorYear-Lumpsum");
        ///    dic.Add("sData", "550,548");
        ///    pFundingInformation._Assets_ActualBenefitPayments(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _Assets_ActualBenefitPayments(MyDictionary dic)
        {
            string sFunctionName = "_Assets_ActualBenefitPayments";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRow = Convert.ToInt32(dic["iRow"]);
            int iCol = Convert.ToInt32(dic["iCol"]);

            string sBack = "{Tab}{Home}{PageUp}";
            string sKeys = "";

            for (int i = 1; i < iRow; i++)
                sKeys = sKeys + "{Down}";
            for (int j = 1; j < iCol; j++)
                sKeys = sKeys + "{Right}";


            int xPos = 180;
            int yPos = 58;

            _gLib._SetSyncUDWin("", this.wRetirementStudio.wAssets_ActualBenefitPayments_FPGrid.grid, "Click", 0, false, xPos, yPos);
            _gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wAssets_ActualBenefitPayments_FPGrid.grid, sBack);

            _gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wAssets_ActualBenefitPayments_FPGrid.grid, sKeys);
            _gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wAssets_ActualBenefitPayments_FPGrid.grid, dic["sData"]);
            _gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wAssets_ActualBenefitPayments_FPGrid.grid, "{Tab}");


            _gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wAssets_ActualBenefitPayments_FPGrid.grid, sBack);
            _gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wAssets_ActualBenefitPayments_FPGrid.grid, sKeys);

            string sActData = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wAssets_ActualBenefitPayments_FPGrid.grid);

            if (!sActData.Contains(dic["sData"]))
            {
                _gLib._MsgBoxYesNo("Continue Testing?", "Function <" + sFunctionName + "> failed to set value <" + dic["sData"] + "> to Row <" + dic["sRow"] + ">, Column <" + dic["sCol"] + ">");
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed to set value <" + dic["sData"] + "> to Row <" + dic["sRow"] + ">, Column <" + dic["sCol"] + ">");
            }
            else
                _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> Successfully set value <" + dic["sData"] + "> to Row <" + dic["sRow"] + ">, Column <" + dic["sCol"] + ">");


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        /// <summary>
        /// 
        /// 2013-May-29
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "26");
        ///    dic.Add("sRow", "LumpSumToNewInactiveWithdrawalFromActiveValues");
        ///    dic.Add("iCol", "1");
        ///    dic.Add("sCol", "PriorYear");
        ///    dic.Add("sData", "0.80000");
        ///    pFundingInformation._Assets_WeightsForAccsetGainLoss(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _Assets_WeightsForAccsetGainLoss(MyDictionary dic)
        {
            string sFunctionName = "_Assets_WeightsForAccsetGainLoss";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            int iRow = Convert.ToInt32(dic["iRow"]);
            int iCol = Convert.ToInt32(dic["iCol"]);

            string sBack = "{Tab}{Home}{PageUp}{PageUp}{PageUp}";
            string sKeys = "";

            for (int i = 1; i < iRow; i++)
                sKeys = sKeys + "{Down}";
            for (int j = 1; j < iCol; j++)
                sKeys = sKeys + "{Right}";


            int xPos = 386;
            int yPos = 26;

            // focus table
            _gLib._SetSyncUDWin("", this.wRetirementStudio.wAssets_WeightsForAssetsGL_FPGrid.grid, "Click", 0, false, xPos, yPos);
           
            // locate cell
            _gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wAssets_WeightsForAssetsGL_FPGrid.grid, sBack + sKeys);
            //////_gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wAssets_WeightsForAssetsGL_FPGrid.grid, sKeys);

            // clear cell and input values
            string valueKeys = "{Space}" + dic["sData"] + "{Tab}";
            _gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wAssets_WeightsForAssetsGL_FPGrid.grid,valueKeys );
            //////_gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wCommon_txt.txt, dic["sData"], 0);
            //////_gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wAssets_WeightsForAssetsGL_FPGrid.grid, "{Tab}");

            // re-go to cell and verify
            _gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wAssets_WeightsForAssetsGL_FPGrid.grid, sBack + sKeys);
            //////////////_gLib._SendKeysUDWin("ActualBenefitPayments_Grid", this.wRetirementStudio.wAssets_WeightsForAssetsGL_FPGrid.grid, sKeys);

            string sActData = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wAssets_WeightsForAssetsGL_FPGrid.grid);
            if (!sActData.Contains(dic["sData"]))
            {
                _gLib._MsgBoxYesNo("Continue Testing?", "Function <" + sFunctionName + "> failed to set value <" + dic["sData"] + "> to Row <" + dic["sRow"] + ">, Column <" + dic["sCol"] + ">");
                _gLib._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> failed to set value <" + dic["sData"] + "> to Row <" + dic["sRow"] + ">, Column <" + dic["sCol"] + ">");
            }
            else
                _gLib._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> Successfully set value <" + dic["sData"] + "> to Row <" + dic["sRow"] + ">, Column <" + dic["sCol"] + ">");


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2018-Sep-18 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("MarketValue", "");
        ///    dic.Add("Average", "");
        ///    dic.Add("Custom", "");
        ///    pFundingInformation._PopVerify_ActuarialValueOfAssets_Main(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ActuarialValueOfAssets_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ActuarialValueOfAssets_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("MarketValue", this.wRetirementStudio.wActuarialValueOfAssets_MarketValue.rdMarketValue, dic["MarketValue"], 0);
                _gLib._SetSyncUDWin("Average", this.wRetirementStudio.wActuarialValueOfAssets_Average.rdAverage, dic["Average"], 0);
                _gLib._SetSyncUDWin("Custom", this.wRetirementStudio.wActuarialValueOfAssets_Custom.rdCustom, dic["Custom"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("MarketValue", this.wRetirementStudio.wActuarialValueOfAssets_MarketValue.rdMarketValue, dic["MarketValue"], 0);
                _gLib._VerifySyncUDWin("Average", this.wRetirementStudio.wActuarialValueOfAssets_Average.rdAverage, dic["Average"], 0);
                _gLib._VerifySyncUDWin("Custom", this.wRetirementStudio.wActuarialValueOfAssets_Custom.rdCustom, dic["Custom"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2018-Sep-18 
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ActuarialValueOfAssets", "");
        ///    dic.Add("ApplyMarketValueCorridor", "");
        ///    pFundingInformation._PopVerify_ActuarialValueOfAssets_Custom(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ActuarialValueOfAssets_Custom(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ActuarialValueOfAssets_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("ActuarialValueOfAssets", this.wRetirementStudio.wActuarialValueOfAssets.txtActuarialValueOfAssets.txt, dic["ActuarialValueOfAssets"], 0);
                _gLib._SetSyncUDWin("ApplyMarketValueCorridor", this.wRetirementStudio.wApplyMarketValueCorridor.chkApplyMarketValueCorridor, dic["ApplyMarketValueCorridor"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("ActuarialValueOfAssets", this.wRetirementStudio.wActuarialValueOfAssets.txtActuarialValueOfAssets.txt, dic["ActuarialValueOfAssets"], 0);
                _gLib._VerifySyncUDWin("ApplyMarketValueCorridor", this.wRetirementStudio.wApplyMarketValueCorridor.chkApplyMarketValueCorridor, dic["ApplyMarketValueCorridor"], 0);

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
        ///    dic.Add("PlanYearBeginDate", "01/01/2008");
        ///    dic.Add("PlanYearEndDate", "31/12/2008");
        ///    dic.Add("InterestRates_Rate_GC", "");
        ///    dic.Add("InterestRates_Rate_Slv", "");
        ///    dic.Add("InterestRates_AsOfDate_GC", "");
        ///    dic.Add("InterestRates_AsOfDate_Slv", "");
        ///    dic.Add("InterestRates_YearsForShortFall_GC", "");
        ///    dic.Add("InterestRates_YearsForShortFall_Slv", "");
        ///    dic.Add("Expense_Solvency_Termination_chk", "");
        ///    dic.Add("Expense_Solvency_Termination_C", "");
        ///    dic.Add("Expense_Solvency_Termination_P", "");
        ///    dic.Add("Expense_Solvency_Termination_C_txt", "");
        ///    dic.Add("Expense_Windup_Termination_chk", "");
        ///    dic.Add("Expense_Windup_Termination_C", "");
        ///    dic.Add("Expense_Windup_Termination_P", "");
        ///    dic.Add("Expense_Windup_Termination_P_txt", "");
        ///    dic.Add("OtherLiabilities_DifferenceInCircumstance", "");
        ///    dic.Add("OtherLiabilities_ValueOfExcludedBenefits", "");
        ///    pFundingInformation._PopVerify_GeneralParameters(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_GeneralParameters(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_GeneralParameters";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin_ByClipboard("PlanYearBeginDate", this.wRetirementStudio.wGI_PlanYearBeginDate.cboPlanYearBeginDate.txtPlanYearBeginDate, dic["PlanYearBeginDate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PlanYearEndDate", this.wRetirementStudio.wGI_PlanYearEndDate.cboPlanYearEndDate.txtPlanYearEndDate, dic["PlanYearEndDate"], 0);
                _gLib._SetSyncUDWin_ByClipboard("InterestRates_Rate_GC", this.wRetirementStudio.wGP_InterestRates_Rate_GC.txt, dic["InterestRates_Rate_GC"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("InterestRates_Rate_Slv", this.wRetirementStudio.wGP_InterestRates_Rate_Slv.txt, dic["InterestRates_Rate_Slv"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("InterestRates_AsOfDate_GC", this.wRetirementStudio.wGP_InterestRates_AsOfDate_GC.cbo.txt, dic["InterestRates_AsOfDate_GC"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("InterestRates_AsOfDate_Slv", this.wRetirementStudio.wGP_InterestRates_AsOfDate_Slv.cbo.txt, dic["InterestRates_AsOfDate_Slv"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("InterestRates_YearsForShortFall_GC", this.wRetirementStudio.wGP_InterestRates_YearsForShortFall_GC.txt, dic["InterestRates_YearsForShortFall_GC"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("InterestRates_YearsForShortFall_Slv", this.wRetirementStudio.wGP_InterestRates_YearsForShortFall_Slv.txt, dic["InterestRates_YearsForShortFall_Slv"], true, 0);


                _gLib._SetSyncUDWin("Expense_Solvency_Termination_chk", this.wRetirementStudio.wGP_Expense_Solvency_Termination_chk.chk, dic["Expense_Solvency_Termination_chk"], 0);
                _gLib._SetSyncUDWin("Expense_Solvency_Termination_C", this.wRetirementStudio.wGP_Expense_Solvency_Termination_C.btn, dic["Expense_Solvency_Termination_C"], 0);
                _gLib._SetSyncUDWin("Expense_Solvency_Termination_P", this.wRetirementStudio.wGP_Expense_Solvency_Termination_P.btn, dic["Expense_Solvency_Termination_P"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Expense_Solvency_Termination_C_txt", this.wRetirementStudio.wGP_Expense_Common_txt_C.txt, dic["Expense_Solvency_Termination_C_txt"], true, 0);

                _gLib._SetSyncUDWin("Expense_Windup_Termination_chk", this.wRetirementStudio.wGP_Expense_Windup_Termination_chk.chk, dic["Expense_Windup_Termination_chk"], 0);
                _gLib._SetSyncUDWin("Expense_Windup_Termination_C", this.wRetirementStudio.wGP_Expense_Windup_Termination_C.btn, dic["Expense_Windup_Termination_C"], 0);
                _gLib._SetSyncUDWin("Expense_Windup_Termination_P", this.wRetirementStudio.wGP_Expense_Windup_Termination_P.btn, dic["Expense_Windup_Termination_P"], 0);
                _gLib._SetSyncUDWin_ByClipboard("Expense_Windup_Termination_P_txt", this.wRetirementStudio.wGP_Expense_Common_txt_P.txt, dic["Expense_Windup_Termination_P_txt"], true, 0);

                _gLib._SetSyncUDWin_ByClipboard("OtherLiabilities_DifferenceInCircumstance", this.wRetirementStudio.wGP_OtherLiabilities_DifferenceInCircumstance.txt, dic["OtherLiabilities_DifferenceInCircumstance"], true, 0);
                _gLib._SetSyncUDWin_ByClipboard("OtherLiabilities_ValueOfExcludedBenefits", this.wRetirementStudio.wGP_OtherLiabilities_ValueOfExcludedBenefits.txt, dic["OtherLiabilities_ValueOfExcludedBenefits"], true, 0);



            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("PlanYearBeginDate", this.wRetirementStudio.wGI_PlanYearBeginDate.cboPlanYearBeginDate.txtPlanYearBeginDate, dic["PlanYearBeginDate"], 0);
                _gLib._VerifySyncUDWin("PlanYearEndDate", this.wRetirementStudio.wGI_PlanYearEndDate.cboPlanYearEndDate.txtPlanYearEndDate, dic["PlanYearEndDate"], 0);
                _gLib._VerifySyncUDWin("InterestRates_Rate_GC", this.wRetirementStudio.wGP_InterestRates_Rate_GC.txt, dic["InterestRates_Rate_GC"], 0);
                _gLib._VerifySyncUDWin("InterestRates_Rate_Slv", this.wRetirementStudio.wGP_InterestRates_Rate_Slv.txt, dic["InterestRates_Rate_Slv"], 0);
                _gLib._VerifySyncUDWin("InterestRates_AsOfDate_GC", this.wRetirementStudio.wGP_InterestRates_AsOfDate_GC.cbo.txt, dic["InterestRates_AsOfDate_GC"], 0);
                _gLib._VerifySyncUDWin("InterestRates_AsOfDate_Slv", this.wRetirementStudio.wGP_InterestRates_AsOfDate_Slv.cbo.txt, dic["InterestRates_AsOfDate_Slv"], 0);
                _gLib._VerifySyncUDWin("InterestRates_YearsForShortFall_GC", this.wRetirementStudio.wGP_InterestRates_YearsForShortFall_GC.txt, dic["InterestRates_YearsForShortFall_GC"], 0);
                _gLib._VerifySyncUDWin("InterestRates_YearsForShortFall_Slv", this.wRetirementStudio.wGP_InterestRates_YearsForShortFall_Slv.txt, dic["InterestRates_YearsForShortFall_Slv"], 0);


                _gLib._VerifySyncUDWin("Expense_Solvency_Termination_chk", this.wRetirementStudio.wGP_Expense_Solvency_Termination_chk.chk, dic["Expense_Solvency_Termination_chk"], 0);
                _gLib._VerifySyncUDWin("Expense_Solvency_Termination_C", this.wRetirementStudio.wGP_Expense_Solvency_Termination_C.btn, dic["Expense_Solvency_Termination_C"], 0);
                _gLib._VerifySyncUDWin("Expense_Solvency_Termination_P", this.wRetirementStudio.wGP_Expense_Solvency_Termination_P.btn, dic["Expense_Solvency_Termination_P"], 0);
                _gLib._VerifySyncUDWin("Expense_Solvency_Termination_C_txt", this.wRetirementStudio.wGP_Expense_Common_txt_C.txt, dic["Expense_Solvency_Termination_C_txt"], 0);

                _gLib._VerifySyncUDWin("Expense_Windup_Termination_chk", this.wRetirementStudio.wGP_Expense_Windup_Termination_chk.chk, dic["Expense_Windup_Termination_chk"], 0);
                _gLib._VerifySyncUDWin("Expense_Windup_Termination_C", this.wRetirementStudio.wGP_Expense_Windup_Termination_C.btn, dic["Expense_Windup_Termination_C"], 0);
                _gLib._VerifySyncUDWin("Expense_Windup_Termination_P", this.wRetirementStudio.wGP_Expense_Windup_Termination_P.btn, dic["Expense_Windup_Termination_P"], 0);
                _gLib._VerifySyncUDWin("Expense_Windup_Termination_P_txt", this.wRetirementStudio.wGP_Expense_Common_txt_P.txt, dic["Expense_Windup_Termination_P_txt"], 0);

                _gLib._VerifySyncUDWin("OtherLiabilities_DifferenceInCircumstance", this.wRetirementStudio.wGP_OtherLiabilities_DifferenceInCircumstance.txt, dic["OtherLiabilities_DifferenceInCircumstance"], 0);
                _gLib._VerifySyncUDWin("OtherLiabilities_ValueOfExcludedBenefits", this.wRetirementStudio.wGP_OtherLiabilities_ValueOfExcludedBenefits.txt, dic["OtherLiabilities_ValueOfExcludedBenefits"], 0);



            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 
        /// 2013-May-29
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("sLable", "Old Fund 1");
        ///    dic.Add("sMarketValue", "10,000");
        ///    pFundingInformation._GP_OtherAssets(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _GP_OtherAssets(MyDictionary dic)
        {
            string sFunctionName = "_GP_OtherAssets";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            int iRow = Convert.ToInt32(dic["iRow"]);
            string sActLabel = "";
            string sActMarketValue = "";

            string skeys = "";
            for (int i = 1; i < iRow; i++)
                skeys = skeys + "{Down}";

            string sDeletekeys = "{Home}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Home}";

            int xPos = 50;
            int yPos = 30;



            if (dic["sLable"] != "")
            {
                _gLib._SetSyncUDWin("OtherAssets_FPGrid", this.wRetirementStudio.wGP_OtherAssets_FPGrid.grid, "Click", 0, false, xPos, yPos);
                _gLib._SendKeysUDWin("OtherAssets_FPGrid", this.wRetirementStudio.wGP_OtherAssets_FPGrid.grid, skeys);

                _gLib._SendKeysUDWin("OtherAssets_FPGrid", this.wRetirementStudio.wGP_OtherAssets_FPGrid.grid, "{Space}" + sDeletekeys);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wGP_FPGrid_Common_txt.txt, dic["sLable"], 0);
                _gLib._SendKeysUDWin("OtherAssets_FPGrid", this.wRetirementStudio.wGP_OtherAssets_FPGrid.grid, "{Tab}");
            }
            if (dic["sMarketValue"] != "")
            {
                _gLib._SetSyncUDWin("OtherAssets_FPGrid", this.wRetirementStudio.wGP_OtherAssets_FPGrid.grid, "Click", 0, false, xPos, yPos);
                _gLib._SendKeysUDWin("OtherAssets_FPGrid", this.wRetirementStudio.wGP_OtherAssets_FPGrid.grid, skeys);

                _gLib._SendKeysUDWin("OtherAssets_FPGrid", this.wRetirementStudio.wGP_OtherAssets_FPGrid.grid, "{Tab}{Space}" + sDeletekeys);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wGP_FPGrid_Common_txt.txt, dic["sMarketValue"], 0);
                _gLib._SendKeysUDWin("OtherAssets_FPGrid", this.wRetirementStudio.wGP_OtherAssets_FPGrid.grid, "{Tab}");
            }

            ////////////sActLabel = _fp._ReturnSelectRowContentByClipboard(this.wRetirementStudio.wGP_OtherAssets_FPGrid.grid);
            ////////////if (!sActLabel.Contains(dic["sLable"]))
            ////////////{
            ////////////    _gLib._MsgBoxYesNo("Continue Testing?", "Fucntion <" + sFunctionName + "> failed to find lable <" + dic["slable"] + "> at row <" + dic["iRow"] + ">");
            ////////////    _gLib._Report(_PassFailStep.Fail, "Fucntion <" + sFunctionName + "> failed to find lable <" + dic["slable"] + "> at row <" + dic["iRow"] + ">");
            ////////////}
            ////////////else
            ////////////{
            ////////////    _gLib._Report(_PassFailStep.Pass, "Fucntion <" + sFunctionName + "> successfully find lable <" + dic["slable"] + "> at row <" + dic["iRow"] + ">");
            ////////////    _gLib._SendKeysUDWin("OtherAssets_FPGrid", this.wRetirementStudio.wGP_OtherAssets_FPGrid.grid, "{Tab}{Space}");
            ////////////    _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wGP_FPGrid_Common_txt.txt, dic["sMarketValue"], 0);
            ////////////    _gLib._SendKeysUDWin("OtherAssets_FPGrid", this.wRetirementStudio.wGP_OtherAssets_FPGrid.grid, "{Tab}");

            ////////////}


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 
        /// 2015-June-5
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("iRow", "1");
        ///    dic.Add("sLable", "GF Liab 1");
        ///    dic.Add("GoingConcern", "10,000");
        ///    dic.Add("Solvency", "15,000");
        ///    dic.Add("WindUp", "12,000");
        ///    pFundingInformation._GP_OtherLiabilities(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _GP_OtherLiabilities(MyDictionary dic)
        {
            string sFunctionName = "_GP_OtherLiabilities";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");



            int iRow = Convert.ToInt32(dic["iRow"]);
            string sActLabel = "";


            string skeys = "";
            for (int i = 1; i < iRow; i++)
                skeys = skeys + "{Down}";

            string sDeletekeys = "{Home}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Delete}{Home}";


            int xPos = 50;
            int yPos = 30;

            _gLib._SetSyncUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "Click", 0, false, xPos, yPos);
            _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, skeys);

            if (dic["sLable"] != "")
            {
                _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "{Home}");
                _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "{Space}" + sDeletekeys);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wGP_FPGrid_Common_txt.txt, dic["sLable"], 0);
                _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "{Tab}");
            }

            if (dic["GoingConcern"] != "")
            {
                _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "{Home}");
                _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "{Tab}{Space}" + sDeletekeys);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wGP_FPGrid_Common_txt.txt, dic["GoingConcern"], 0);
                _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "{Tab}");
            }
            if (dic["Solvency"] != "")
            {
                _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "{Home}");
                _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "{Tab}{Tab}{Space}" + sDeletekeys);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wGP_FPGrid_Common_txt.txt, dic["Solvency"], 0);
                _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "{Tab}");
            }
            if (dic["WindUp"] != "")
            {
                _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "{Home}");
                _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "{Tab}{Tab}{Tab}{Space}" + sDeletekeys);
                _gLib._SetSyncUDWin_ByClipboard("", this.wRetirementStudio.wGP_FPGrid_Common_txt.txt, dic["WindUp"], 0);
                _gLib._SendKeysUDWin("OtherLiabilities_FPGrid", this.wRetirementStudio.wGP_OtherLiabilities_FPGrid.grid, "{Tab}");
            }




            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2015-June-5
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OriginalPlanEffectiveDate", "");
        ///    dic.Add("BeginningOfPlanYear", "");
        ///    dic.Add("EndOfPlanYear", "");
        ///    dic.Add("ValuationDate", "");
        ///    dic.Add("ValuationYear", "");
        ///    pFundingInformation._PopVerify_PVR_PlanDates(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PVR_PlanDates(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PVR_PlanDates";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                string valuekeys = "{End}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}{Back}" + dic["OriginalPlanEffectiveDate"] + "{Tab}{Tab}";
                _gLib._SendKeysUDWin("OriginalPlanEffectiveDate", this.wRetirementStudio.wPVR_PlanDates_OriginalPlanEffectiveDate.cbo.txt, valuekeys, 0, ModifierKeys.None, false);
                string sActVal = this.wRetirementStudio.wPVR_PlanDates_OriginalPlanEffectiveDate.cbo.txt.Text;
                if (sActVal.Trim() != dic["OriginalPlanEffectiveDate"])
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Verify Object: < OriginalPlanEffectiveDate > with expected value: <" + dic["OriginalPlanEffectiveDate"] + ">. Actual Value: <" + sActVal.Trim() + "> ");

                // update this element property on 2020Jan21th
                _gLib._SetSyncUDWin_ByClipboard("BeginningOfPlanYear", this.wRetirementStudio.wPVR_PlanDates_BeginningOfPlanYear.cbo.txt, dic["BeginningOfPlanYear"], 0);
                _gLib._SetSyncUDWin_ByClipboard("EndOfPlanYear", this.wRetirementStudio.wPVR_PlanDates_EndOfPlanYear.cbo.txt, dic["EndOfPlanYear"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ValuationDate", this.wRetirementStudio.wPVR_PlanDates_ValuationDate.cbo.txt, dic["ValuationDate"], 0);
                _gLib._SetSyncUDWin("ValuationYear", this.wRetirementStudio.wPVR_PlanDates_ValuationYear.cbo, dic["ValuationYear"], 0);
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-June-5
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("SolvencyTerm", "");
        ///    dic.Add("WindUpTerm", "");
        ///    pFundingInformation._PopVerify_PVR_LiabilityMeasures(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PVR_LiabilityMeasures(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PVR_LiabilityMeasures";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin_ByClipboard("SolvencyTerm", this.wRetirementStudio.wPVR_LiabilityMeasures_SolvencyTerm.txt, dic["SolvencyTerm"], 0);
                _gLib._SetSyncUDWin_ByClipboard("WindUpTerm", this.wRetirementStudio.wPVR_LiabilityMeasures_WindUpTerm.txt, dic["WindUpTerm"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("SolvencyTerm", this.wRetirementStudio.wPVR_LiabilityMeasures_SolvencyTerm.txt, dic["SolvencyTerm"], 0);
                _gLib._VerifySyncUDWin("WindUpTerm", this.wRetirementStudio.wPVR_LiabilityMeasures_WindUpTerm.txt, dic["WindUpTerm"], 0);


            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-June-5
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("MarketValueOfAssets", "");
        ///    dic.Add("BenefitPayments", "");
        ///    dic.Add("PensionPayments", "");
        ///    dic.Add("ActuarialValueOfAssets", "");
        ///    pFundingInformation._PopVerify_PVR_Assets(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PVR_Assets(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PVR_Assets";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin_ByClipboard("MarketValueOfAssets", this.wRetirementStudio.wPVR_Assets_MarketValueOfAssets.txt, dic["MarketValueOfAssets"], 0);
                _gLib._SetSyncUDWin_ByClipboard("BenefitPayments", this.wRetirementStudio.wPVR_Assets_BenefitPayments.txt, dic["BenefitPayments"], 0);
                _gLib._SetSyncUDWin_ByClipboard("PensionPayments", this.wRetirementStudio.wPVR_Assets_PensionPayments.txt, dic["PensionPayments"], 0);
                _gLib._SetSyncUDWin_ByClipboard("ActuarialValueOfAssets", this.wRetirementStudio.wPVR_Assets_ActuarialValueOfAssets.txt, dic["ActuarialValueOfAssets"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("MarketValueOfAssets", this.wRetirementStudio.wPVR_Assets_MarketValueOfAssets.txt, dic["MarketValueOfAssets"], 0);
                _gLib._VerifySyncUDWin("BenefitPayments", this.wRetirementStudio.wPVR_Assets_BenefitPayments.txt, dic["BenefitPayments"], 0);
                _gLib._VerifySyncUDWin("PensionPayments", this.wRetirementStudio.wPVR_Assets_PensionPayments.txt, dic["PensionPayments"], 0);
                _gLib._VerifySyncUDWin("ActuarialValueOfAssets", this.wRetirementStudio.wPVR_Assets_ActuarialValueOfAssets.txt, dic["ActuarialValueOfAssets"], 0);


            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2015-June-5
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Refresh", "Click");
        ///    pFundingInformation._PopVerify_PVR_NormalCost(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PVR_NormalCost(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PVR_NormalCost";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("Refresh", this.wRetirementStudio.wPVR_NormalCost_Refresh.txt.link, dic["Refresh"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("Refresh", this.wRetirementStudio.wPVR_NormalCost_Refresh.txt.link, dic["Refresh"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
