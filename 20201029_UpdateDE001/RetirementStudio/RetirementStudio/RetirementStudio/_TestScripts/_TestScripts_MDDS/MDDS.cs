using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

using RetirementStudio._Libraries;
using RetirementStudio._Config;
using RetirementStudio._UIMaps;
using RetirementStudio._UIMaps_MDDS.LoginClasses;
using RetirementStudio._UIMaps_MDDS.InternalClasses;
using RetirementStudio._UIMaps_MDDS.Internal_Step1Classes;
using RetirementStudio._UIMaps_MDDS.Internal_Step2Classes;
using RetirementStudio._UIMaps_MDDS.ExternalClasses;


namespace RetirementStudio._TestScripts
{
    /// <summary>
    /// Summary description for Web
    /// </summary>
    [CodedUITest]
    public class MDDS
    {


        public MDDS()
        {

            #region Initialization

            _gLibWeb._TestSetup();

            #endregion

        }

        #region Fields

        public string sURL = "http://mddsqa.mercer.com/DDSUS10LB/DDS";

        public MyDictionary dic = new MyDictionary();
        public GenericLib_Win _gLib = new GenericLib_Win();
        public GenericLib_Web _gLibWeb = new GenericLib_Web();

        public Login pLogin = new Login();
        public Internal pInternal = new Internal();
        public Internal_Step1 pInternal_Step1 = new Internal_Step1();
        public Internal_Step2 pInternal_Step2 = new Internal_Step2();
        public External pExternal = new External();


        #endregion

        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void test_MDDS()
        {

          


            _gLibWeb._KillAllBrowsers();

            _gLibWeb._LaunchURL(this.sURL);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Username", "June-Jia");
            dic.Add("Password", "");
            dic.Add("Login", "Click");
            pLogin._PopVerify_Login(dic);

            _gLibWeb._Navigate("Administration", true);

            _gLibWeb._Navigate("User", false);

            _gLibWeb._Navigate("Internal", true);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddUser", "Click");
            dic.Add("RemoveUser", "");
            dic.Add("ModifyUser", "");
            pInternal._PopVerify_Internal(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LastName", "Haskins");
            dic.Add("FirstName", "Michelle");
            dic.Add("Search", "Click");
            dic.Add("Submit", "");
            pInternal_Step1._PopVerify_Internal_Step1(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("iRow", "2");
            dic.Add("iCol", "1");
            dic.Add("sData", "Haskins, Michelle");
            dic.Add("ClickCell", "Click");
            pInternal_Step1._PopVerify_SearchResults(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("LastName", "");
            dic.Add("FirstName", "");
            dic.Add("Search", "");
            dic.Add("Submit", "Click");
            pInternal_Step1._PopVerify_Internal_Step1(dic);


            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("TeamAssignment", "Client Solutions");
            dic.Add("Check", "True");
            dic.Add("Submit", "Click");
            pInternal_Step2._PopVerify_Internal_Step2(dic);

            _gLibWeb._Navigate("External", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddUser", "Click");
            dic.Add("RemoveUser", "");
            dic.Add("ModifyUser", "");
            pExternal._PopVerify_External(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("FirstName", "Haskins");
            dic.Add("LastName", "Michelle");
            dic.Add("EmailAddress", "Haskins.Michelle@mercer.com");
            dic.Add("CompanyName", "Mercer");
            dic.Add("ClientsPlans", "Isuzu North America Corporation > Retirement Trust");
            dic.Add("ClientsPlans_Check", "True");
            dic.Add("Submit", "Click");
            pExternal._PopVerify_External_Step2(dic);

            _gLibWeb._NavigateByID("Logout", false);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("Username", "shazma-butt");
            dic.Add("Password", "");
            dic.Add("Login", "Click");
            pLogin._PopVerify_Login(dic);

            _gLibWeb._Navigate("Administration", true);

            _gLibWeb._Navigate("User", false);

            _gLibWeb._Navigate("External", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sRow", "Haskins Michelle");
            dic.Add("iCol", "1");
            dic.Add("sData", "Haskins Michelle");
            dic.Add("ClickCell", "Click");
            pExternal._PopVerify_ExternalUsersTBL(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddUser", "");
            dic.Add("RemoveUser", "");
            dic.Add("ModifyUser", "Click");
            pExternal._PopVerify_External(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("ApproveReject", "Click");
            dic.Add("ApproveWindow_Approve", "Click");
            dic.Add("ApproveWindow_Reject", "");
            dic.Add("ApprovePendingItem_OK", "Click");
            pExternal._PopVerify_ModifyExternalUser(dic);


            _gLibWeb._Navigate("Internal", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sRow", "michelle-haskins");
            dic.Add("iCol", "1");
            dic.Add("sData", "michelle-haskins");
            dic.Add("ClickCell", "Click");
            pInternal._PopVerify_InternalUsersTBL(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddUser", "");
            dic.Add("RemoveUser", "Click");
            dic.Add("ModifyUser", "");
            pInternal._PopVerify_Internal(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pInternal._PopVerify_ConfirmUserRemove(dic);

            _gLibWeb._Navigate("External", true);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("sRow", "Haskins Michelle");
            dic.Add("iCol", "1");
            dic.Add("sData", "Haskins Michelle");
            dic.Add("ClickCell", "Click");
            pExternal._PopVerify_ExternalUsersTBL(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("AddUser", "");
            dic.Add("RemoveUser", "Click");
            dic.Add("ModifyUser", "");
            pExternal._PopVerify_External(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            dic.Add("Cancel", "");
            pExternal._PopVerify_ConfirmUserRemove(dic);

            _gLibWeb._NavigateByID("Logout", false);

            Environment.Exit(1);
        
        
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
