namespace RetirementStudio._UIMaps.TestCaseLibraryClasses
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


    public partial class TestCaseLibrary
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        /// <summary>
        /// 2013-May-13
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("SelectionCriteria", "$emp.BirthDate=\"9/26/1944\"  and $emp.HireDate1=\"6/2/1996\"");
        ///    dic.Add("iResultRow", "1");
        ///    pTestCaseLibrary._AddTestCase(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _AddTestCase(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_TestCaseLibrary";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            ////////_gLib._SetSyncUDWin("Selection Criteria", this.wRetirementStudio.wSearchCriteria.txtSearchCriteria, dic["SelectionCriteria"], 0);
            _gLib._SetSyncUDWin_ByClipboard("Selection Criteria", this.wRetirementStudio.wSearchCriteria.txtSearchCriteria, dic["SelectionCriteria"], 0);
            _gLib._SetSyncUDWin("Apply", this.wRetirementStudio.wApply.btnApply, "Click", 0);

            int iPosX = 20;
            int iPos_Start_Y = 8;
            int iStepY = 22;

            int iPosY = Convert.ToInt32(dic["iResultRow"]) * iStepY + iPos_Start_Y;
            ////////////Mouse.Click(this.wRetirementStudio.wFPGrid_Results.grid, new Point(iPosX, iPosY));
            _gLib._SetSyncUDWin("", this.wRetirementStudio.wFPGrid_Results.grid, "Click", 0, false, iPosX, iPosY); 

            _gLib._SetSyncUDWin("Apply", this.wRetirementStudio.wAddSelectedToLibrary.btnAddSelectedToLibrary, "Click", 0);


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2014-Sep-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("RunSelectedTestLife", "Click");
        ///    pTestCaseLibrary._PopVerify_TestCaseLibrary(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_TestCaseLibrary(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_TestCaseLibrary";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("RunSelectedTestLife", this.wRetirementStudio.wRunSelectedTestLife.btn, dic["RunSelectedTestLife"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("RunSelectedTestLife", this.wRetirementStudio.wRunSelectedTestLife.btn, dic["RunSelectedTestLife"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2014-Sep-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    pTestCaseLibrary._FPGrid_TestCaseLibrary_SelectTestCase(1); 
        /// </summary>
        /// <param name="dic"></param>
        public void _FPGrid_TestCaseLibrary_SelectTestCase(int iIndex)
        {

            string sFunctionName = "_FPGrid_TestCaseLibrary_SelectTestCase";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            int iPosX = 20;
            int iPos_Start_Y = 8;
            int iStepY = 22;

            int iPosY = iIndex * iStepY + iPos_Start_Y;
            
            _gLib._SetSyncUDWin("", this.wRetirementStudio.wFPGrid_TestCaseLibrary.grid, "Click", 0, false, iPosX, iPosY);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }



        /// <summary>
        /// 2014-Sep-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AllLiabilityTypes", "");
        ///    dic.Add("PPA_NAR_Min", "True");
        ///    dic.Add("PPA_NAR_Max", "True");
        ///    dic.Add("PPA_NAR_PVVB", "True");
        ///    dic.Add("PBGC_NAR_PVVB", "True");
        ///    dic.Add("FAS35_PVAB", "True");
        ///    dic.Add("FAS35_PVVB", "True");
        ///    dic.Add("Funding", "True");
        ///    dic.Add("PayoutProjection", "False");
        ///    dic.Add("RunSelected", "Click");
        ///    pTestCaseLibrary._PopVerify_TestCaseRunOption(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_TestCaseRunOption(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_TestCaseRunOption";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("AllLiabilityTypes", this.wTestCaseRunOptions.wLiabilityTypes.chkAllLiabilityTypes, "True", 0);
                _gLib._SetSyncUDWin("AllLiabilityTypes", this.wTestCaseRunOptions.wLiabilityTypes.chkAllLiabilityTypes, "False", 0);
                _gLib._SetSyncUDWin("AllLiabilityTypes", this.wTestCaseRunOptions.wLiabilityTypes.chkAllLiabilityTypes, dic["AllLiabilityTypes"], 0);
                _gLib._SetSyncUDWin("PPA_NAR_Min", this.wTestCaseRunOptions.wLiabilityTypes.chkPPA_NAR_Min, dic["PPA_NAR_Min"], 0);
                _gLib._SetSyncUDWin("PPA_NAR_Max", this.wTestCaseRunOptions.wLiabilityTypes.chkPPA_NAR_Max, dic["PPA_NAR_Max"], 0);
                _gLib._SetSyncUDWin("PPA_NAR_PVVB", this.wTestCaseRunOptions.wLiabilityTypes.chkPPA_NAR_PVVB, dic["PPA_NAR_PVVB"], 0);
                _gLib._SetSyncUDWin("PBGC_NAR_PVVB", this.wTestCaseRunOptions.wLiabilityTypes.chkPBGC_NAR_PVVB, dic["PBGC_NAR_PVVB"], 0);
                _gLib._SetSyncUDWin("FAS35_PVAB", this.wTestCaseRunOptions.wLiabilityTypes.chkFAS35_PVAB, dic["FAS35_PVAB"], 0);
                _gLib._SetSyncUDWin("FAS35_PVVB", this.wTestCaseRunOptions.wLiabilityTypes.chkFAS35_PVVB, dic["FAS35_PVVB"], 0);
                _gLib._SetSyncUDWin("Funding", this.wTestCaseRunOptions.wLiabilityTypes.chkFunding, dic["Funding"], 0);
                _gLib._SetSyncUDWin("PayoutProjection", this.wTestCaseRunOptions.wPayoutProjection.chk, dic["PayoutProjection"], 0);
                _gLib._SetSyncUDWin("RunSelected", this.wTestCaseRunOptions.wRunSelected.btn, dic["RunSelected"], 0);
          
            }

            if (dic["PopVerify"] == "Verify")
            {
                
                _gLib._VerifySyncUDWin("PPA_NAR_Min", this.wTestCaseRunOptions.wLiabilityTypes.chkPPA_NAR_Min, dic["PPA_NAR_Min"], 0);
                _gLib._VerifySyncUDWin("PPA_NAR_Max", this.wTestCaseRunOptions.wLiabilityTypes.chkPPA_NAR_Max, dic["PPA_NAR_Max"], 0);
                _gLib._VerifySyncUDWin("PPA_NAR_PVVB", this.wTestCaseRunOptions.wLiabilityTypes.chkPPA_NAR_PVVB, dic["PPA_NAR_PVVB"], 0);
                _gLib._VerifySyncUDWin("PBGC_NAR_PVVB", this.wTestCaseRunOptions.wLiabilityTypes.chkPBGC_NAR_PVVB, dic["PBGC_NAR_PVVB"], 0);
                _gLib._VerifySyncUDWin("FAS35_PVAB", this.wTestCaseRunOptions.wLiabilityTypes.chkFAS35_PVAB, dic["FAS35_PVAB"], 0);
                _gLib._VerifySyncUDWin("FAS35_PVVB", this.wTestCaseRunOptions.wLiabilityTypes.chkFAS35_PVVB, dic["FAS35_PVVB"], 0);
                _gLib._VerifySyncUDWin("Funding", this.wTestCaseRunOptions.wLiabilityTypes.chkFunding, dic["Funding"], 0);
                _gLib._VerifySyncUDWin("PayoutProjection", this.wTestCaseRunOptions.wPayoutProjection.chk, dic["PayoutProjection"], 0);
                _gLib._VerifySyncUDWin("RunSelected", this.wTestCaseRunOptions.wRunSelected.btn, dic["RunSelected"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }


        /// <summary>
        /// 2014-Sep-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("ViewTestCaseInExcel", "Click");
        ///    dic.Add("Close", "");
        ///    pTestCaseLibrary._PopVerify_TestCaseViewer(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_TestCaseViewer(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_TestCaseViewer";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("ViewTestCaseInExcel", this.wTestCaseViewer.wViewTestCaseInExcel.txt.link, dic["ViewTestCaseInExcel"], 0);
                _gLib._SetSyncUDWin("Close", this.wTestCaseViewer.wClose.btn, dic["Close"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("ViewTestCaseInExcel", this.wTestCaseViewer.wViewTestCaseInExcel.txt.link, dic["ViewTestCaseInExcel"], 0);
                _gLib._VerifySyncUDWin("Close", this.wTestCaseViewer.wClose.btn, dic["Close"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }



        /// <summary>
        /// 2014-Sep-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("RemoveSelectedfromLibrary", "Click");
        ///    pTestCaseLibrary._PopVerify_RemoveSelectedfromLibrary(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_RemoveSelectedfromLibrary(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_RemoveSelectedfromLibrary";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("RemoveSelectedfromLibrary", this.wRetirementStudio.wRemoveSelectedfromLi.btn, dic["RemoveSelectedfromLibrary"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("RemoveSelectedfromLibrary", this.wRetirementStudio.wRemoveSelectedfromLi.btn, dic["RemoveSelectedfromLibrary"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2014-Sep-23 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Yes", "Click");
        ///    pTestCaseLibrary._PopVerify_RecodeDelection(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_RecodeDelection(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_RecodeDelection";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Yes", this.wConfirmRecordDeletion.wYes.btn, dic["Yes"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("Yes", this.wConfirmRecordDeletion.wYes.btn, dic["Yes"], 0);
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

    }
}
