namespace RetirementStudio._UIMaps_MDDS.InternalClasses
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

    public partial class Internal
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
        ///    dic.Add("AddUser", "Click");
        ///    dic.Add("RemoveUser", "");
        ///    dic.Add("ModifyUser", "");
        ///    pInternal._PopVerify_Internal(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Internal(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Internal";
            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            this.wInternal.pInternal.WaitForControlReady();
            _gLib._CaptureScreen_PopVerify(sFunctionName);

            if (dic["PopVerify"] == "Pop")
            {
                _gLibWeb._SetSyncUDWeb("AddUser", this.wInternal.pInternal.btnAddUser, dic["AddUser"], 0);
                _gLibWeb._SetSyncUDWeb("RemoveUser", this.wInternal.pInternal.btnRemoveUser, dic["RemoveUser"], 0);
                _gLibWeb._SetSyncUDWeb("ModifyUser", this.wInternal.pInternal.btnModifyUser, dic["ModifyUser"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLibWeb._VerifySyncUDWeb("AddUser", this.wInternal.pInternal.btnAddUser, dic["AddUser"], 0);
                _gLibWeb._VerifySyncUDWeb("RemoveUser", this.wInternal.pInternal.btnRemoveUser, dic["RemoveUser"], 0);
                _gLibWeb._VerifySyncUDWeb("ModifyUser", this.wInternal.pInternal.btnModifyUser, dic["ModifyUser"], 0);

            }


            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-June-23
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("sRow", "michelle-haskins");
        ///    dic.Add("iCol", "1");
        ///    dic.Add("sData", "michelle-haskins");
        ///    dic.Add("ClickCell", "Click");
        ///    pInternal._PopVerify_InternalUsersTBL(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_InternalUsersTBL(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_InternalUsersTBL";
            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            this.wInternal.pInternal.WaitForControlReady();
            _gLib._CaptureScreen_PopVerify(sFunctionName);

            int iCol = Convert.ToInt32(dic["iCol"]);
            string sRow = dic["sRow"];

            if (dic["PopVerify"] == "Pop")
            {

                if (dic["ClickCell"] != "")
                    _gLibWeb._TBL_Table("ExternalUsers Table", this.wInternal.pInternal.pnPane.tblUsers, sRow, iCol, dic["sData"], 0, true, false, false, false);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLibWeb._TBL_Table("ExternalUsers Table", this.wInternal.pInternal.pnPane.tblUsers, sRow, iCol, dic["sData"], 0, false, false, true, false);
            }


            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");

        }

        /// <summary>
        /// 2013-June-23
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("OK", "Click");
        ///    dic.Add("Cancel", "");
        ///    pInternal._PopVerify_ConfirmUserRemove(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ConfirmUserRemove(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ConfirmUserRemove";
            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            this.wInternal.pInternal.WaitForControlReady();
            _gLib._CaptureScreen_PopVerify(sFunctionName);

            if (dic["PopVerify"] == "Pop")
            {
                _gLibWeb._SetSyncUDWeb("OK", this.wInternal.pInternal.btnConfirmUserRemove_OK, dic["OK"], 0);
                _gLibWeb._SetSyncUDWeb("Cancel", this.wInternal.pInternal.btnConfirmUserRemove_Cancel, dic["Cancel"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLibWeb._VerifySyncUDWeb("OK", this.wInternal.pInternal.btnConfirmUserRemove_OK, dic["OK"], 0);
                _gLibWeb._VerifySyncUDWeb("Cancel", this.wInternal.pInternal.btnConfirmUserRemove_Cancel, dic["Cancel"], 0);

            }


            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
