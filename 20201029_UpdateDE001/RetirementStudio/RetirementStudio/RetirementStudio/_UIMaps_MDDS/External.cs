namespace RetirementStudio._UIMaps_MDDS.ExternalClasses
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

    public partial class External
    {
        public MyDictionary dic = new MyDictionary();
        public GenericLib_Win _gLib = new GenericLib_Win();
        public GenericLib_Web _gLibWeb = new GenericLib_Web();

        /// <summary>
        /// 2013-June-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AddUser", "Click");
        ///    dic.Add("RemoveUser", "");
        ///    dic.Add("ModifyUser", "");
        ///    pExternal._PopVerify_External(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_External(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_External";
            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            this.wExternal.pExternal.WaitForControlReady();
            _gLib._CaptureScreen_PopVerify(sFunctionName);

            if (dic["PopVerify"] == "Pop")
            {
                _gLibWeb._SetSyncUDWeb("AddUser", this.wExternal.pExternal.btnAddUser, dic["AddUser"], 0);
                _gLibWeb._SetSyncUDWeb("RemoveUser", this.wExternal.pExternal.btnRemoveUser, dic["RemoveUser"], 0);
                _gLibWeb._SetSyncUDWeb("ModifyUser", this.wExternal.pExternal.btnModifyUser, dic["ModifyUser"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLibWeb._VerifySyncUDWeb("AddUser", this.wExternal.pExternal.btnAddUser, dic["AddUser"], 0);
                _gLibWeb._VerifySyncUDWeb("RemoveUser", this.wExternal.pExternal.btnRemoveUser, dic["RemoveUser"], 0);
                _gLibWeb._VerifySyncUDWeb("ModifyUser", this.wExternal.pExternal.btnModifyUser, dic["ModifyUser"], 0);

            }


            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-June-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("FirstName", "Haskins");
        ///    dic.Add("LastName", "Michelle");
        ///    dic.Add("EmailAddress", "Haskins.Michelle@mercer.com");
        ///    dic.Add("CompanyName", "Mercer");
        ///    dic.Add("ClientsPlans", "Isuzu North America Corporation > Retirement Trust");
        ///    dic.Add("ClientsPlans_Check", "True");
        ///    dic.Add("Submit", "Click");
        ///    pExternal._PopVerify_External_Step2(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_External_Step2(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_External_Step2";
            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            this.wExternal.pExternalStep2.WaitForControlReady();
            _gLib._CaptureScreen_PopVerify(sFunctionName);

            if (dic["PopVerify"] == "Pop")
            {
                _gLibWeb._SetSyncUDWeb("FirstName", this.wExternal.pExternalStep2.txtFirstName, dic["FirstName"], 0);
                _gLibWeb._SetSyncUDWeb("LastName", this.wExternal.pExternalStep2.txtLastName, dic["LastName"], 0);
                _gLibWeb._SetSyncUDWeb("EmailAddress", this.wExternal.pExternalStep2.txtEmailAddress, dic["EmailAddress"], 0);
                _gLibWeb._SetSyncUDWeb("CompanyName", this.wExternal.pExternalStep2.txtCompanyName, dic["CompanyName"], 0);

                if (dic["ClientsPlans"] != "")
                    _gLibWeb._SetSyncUDWeb(dic["ClientsPlans"], _gLibWeb._ReturnElement(_SearchType.CheckBox, _SearchBy.LabeledBy, dic["ClientsPlans"], 1, true), dic["ClientsPlans_Check"], 0);

                _gLibWeb._SetSyncUDWeb("Submit", this.wExternal.pExternalStep2.btnSubmit, dic["Submit"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLibWeb._VerifySyncUDWeb("FirstName", this.wExternal.pExternalStep2.txtFirstName, dic["FirstName"], 0);
                _gLibWeb._VerifySyncUDWeb("LastName", this.wExternal.pExternalStep2.txtLastName, dic["LastName"], 0);
                _gLibWeb._VerifySyncUDWeb("EmailAddress", this.wExternal.pExternalStep2.txtEmailAddress, dic["EmailAddress"], 0);
                _gLibWeb._VerifySyncUDWeb("CompanyName", this.wExternal.pExternalStep2.txtCompanyName, dic["CompanyName"], 0);
                _gLibWeb._VerifySyncUDWeb("Submit", this.wExternal.pExternalStep2.btnSubmit, dic["Submit"], 0);

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
        ///    dic.Add("sRow", "Haskins Michelle");
        ///    dic.Add("iCol", "1");
        ///    dic.Add("sData", "Haskins Michelle");
        ///    dic.Add("ClickCell", "Click");
        ///    pExternal._PopVerify_ExternalUsersTBL(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ExternalUsersTBL(MyDictionary dic)
        {

            string sFunctionName = "_PopVerify_ExternalUsersTBL";
            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            this.wExternal.pExternal.WaitForControlReady();
            _gLib._CaptureScreen_PopVerify(sFunctionName);

            int iCol = Convert.ToInt32(dic["iCol"]);
            string sRow = dic["sRow"];

            if (dic["PopVerify"] == "Pop")
            {

                if (dic["ClickCell"] != "")
                    _gLibWeb._TBL_Table("ExternalUsers Table", this.wExternal.pExternal.pnPane.tblUsers, sRow, iCol, dic["sData"], 0, true, false, false, false);
            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLibWeb._TBL_Table("ExternalUsers Table", this.wExternal.pExternal.pnPane.tblUsers, sRow, iCol, dic["sData"], 0, false, false, true, false);
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
        ///    dic.Add("ApproveReject", "Click");
        ///    dic.Add("ApproveWindow_Approve", "Click");
        ///    dic.Add("ApproveWindow_Reject", "");
        ///    dic.Add("ApprovePendingItem_OK", "Click");
        ///    pExternal._PopVerify_ModifyExternalUser(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ModifyExternalUser(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ModifyExternalUser";
            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            this.wExternal.pExternalModify.WaitForControlReady();
            _gLib._CaptureScreen_PopVerify(sFunctionName);

            if (dic["PopVerify"] == "Pop")
            {
                _gLibWeb._SetSyncUDWeb("ApproveReject", this.wExternal.pExternalModify.btnApproveReject, dic["ApproveReject"], 0);
                _gLibWeb._SetSyncUDWeb("ApproveWindow_Approve", this.wExternal.pExternalModify.btnApproveWin_Approve, dic["ApproveWindow_Approve"], 0);
                _gLibWeb._SetSyncUDWeb("ApproveWindow_Reject", this.wExternal.pExternalModify.btnApproveWin_Reject, dic["ApproveWin_Reject"], 0);
                _gLibWeb._SetSyncUDWeb("ApprovePendingItem_OK", this.wExternal.pExternalModify.btnApprovePendingItem_OK, dic["ApprovePendingItem_OK"], 0);
            }

            if (dic["PopVerify"] == "Verify")
            {

                _gLibWeb._VerifySyncUDWeb("ApproveReject", this.wExternal.pExternalModify.btnApproveReject, dic["ApproveReject"], 0);
                _gLibWeb._VerifySyncUDWeb("ApproveWindow_Approve", this.wExternal.pExternalModify.btnApproveWin_Approve, dic["ApproveWindow_Approve"], 0);
                _gLibWeb._VerifySyncUDWeb("ApproveWindow_Reject", this.wExternal.pExternalModify.btnApproveWin_Reject, dic["ApproveWindow_Reject"], 0);
                _gLibWeb._VerifySyncUDWeb("ApprovePendingItem_OK", this.wExternal.pExternalModify.btnApprovePendingItem_OK, dic["ApprovePendingItem_OK"], 0);
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
        ///    pExternal._PopVerify_ConfirmUserRemove(dic); 
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_ConfirmUserRemove(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_ConfirmUserRemove";
            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            this.wExternal.pExternal.WaitForControlReady();
            _gLib._CaptureScreen_PopVerify(sFunctionName);

            if (dic["PopVerify"] == "Pop")
            {
                _gLibWeb._SetSyncUDWeb("OK", this.wExternal.pExternal.btnConfirmUserRemove_OK, dic["OK"], 0);
                _gLibWeb._SetSyncUDWeb("Cancel", this.wExternal.pExternal.btnConfirmUserRemove_Cancel, dic["Cancel"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLibWeb._VerifySyncUDWeb("OK", this.wExternal.pExternal.btnConfirmUserRemove_OK, dic["OK"], 0);
                _gLibWeb._VerifySyncUDWeb("Cancel", this.wExternal.pExternal.btnConfirmUserRemove_Cancel, dic["Cancel"], 0);

            }


            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }
    }
}
