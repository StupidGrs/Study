namespace RetirementStudio._UIMaps_MDDS.Internal_Step1Classes
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
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System.Threading;
    using System.Windows.Forms;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;



    public partial class Internal_Step1
    {

        public MyDictionary dic = new MyDictionary();
        public GenericLib_Win _gLib = new GenericLib_Win();
        public GenericLib_Web _gLibWeb = new GenericLib_Web();


        /// <summary>
        /// 2013-June-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("LastName", "Haskins");
        ///    dic.Add("FirstName", "Michelle");
        ///    dic.Add("Search", "Click");
        ///    dic.Add("Submit", "");
        ///    pInternal_Step1._PopVerify_Internal_Step1(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Internal_Step1(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Internal_Step1";
            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            this.wInternal_Step1.pInternal_Step1.WaitForControlReady();
            _gLib._CaptureScreen_PopVerify(sFunctionName);

            if (dic["PopVerify"] == "Pop")
            {
                _gLibWeb._SetSyncUDWeb("LastName", this.wInternal_Step1.pInternal_Step1.txtLastName, dic["LastName"], 0);
                _gLibWeb._SetSyncUDWeb("FirstName", this.wInternal_Step1.pInternal_Step1.txtFirstName, dic["FirstName"], 0);
                _gLibWeb._SetSyncUDWeb("Search", this.wInternal_Step1.pInternal_Step1.btnSearch, dic["Search"], 0);
                _gLibWeb._SetSyncUDWeb("Submit", this.wInternal_Step1.pInternal_Step1.btnSubmit, dic["Submit"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                
                _gLibWeb._VerifySyncUDWeb("LastName", this.wInternal_Step1.pInternal_Step1.txtLastName, dic["LastName"], 0);
                _gLibWeb._VerifySyncUDWeb("FirstName", this.wInternal_Step1.pInternal_Step1.txtFirstName, dic["FirstName"], 0);
                _gLibWeb._VerifySyncUDWeb("Search", this.wInternal_Step1.pInternal_Step1.btnSearch, dic["Search"], 0);
                _gLibWeb._VerifySyncUDWeb("Submit", this.wInternal_Step1.pInternal_Step1.btnSubmit, dic["Submit"], 0);

            }


            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-June-21
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "2");
        ///    dic.Add("iCol", "1");
        ///    dic.Add("sData", "Haskins, Michelle");
        ///    dic.Add("ClickCell", "Click");
        ///    pInternal_Step1._PopVerify_SearchResults(dic); 
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("iRow", "2");
        ///    dic.Add("iCol", "1");
        ///    dic.Add("sData", "Haskins, Michelle");
        ///    dic.Add("ClickCell", "");
        ///    pInternal_Step1._PopVerify_SearchResults(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SearchResults(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_SearchResults";
            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            this.wInternal_Step1.pInternal_Step1.WaitForControlReady();
            _gLib._CaptureScreen_PopVerify(sFunctionName);

            int iCol = Convert.ToInt32(dic["iCol"]);
            int iRow = Convert.ToInt32(dic["iRow"]);

            if (dic["PopVerify"] == "Pop")
            {

                _gLibWeb._TBL_Table("SearchResult Table", this.wInternal_Step1.pInternal_Step1.pnPane.tblSearchResults, iRow, iCol, dic["sData"], 0, false, false, true, false);

                if(dic["ClickCell"]!="")
                    _gLibWeb._TBL_Table("SearchResult Table", this.wInternal_Step1.pInternal_Step1.pnPane.tblSearchResults, iRow, iCol, dic["sData"], 0, true, false, false, false);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLibWeb._TBL_Table("SearchResult Table", this.wInternal_Step1.pInternal_Step1.pnPane.tblSearchResults, iRow, iCol, dic["sData"], 0, false, false, true, false);
            }


            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

    }
}
