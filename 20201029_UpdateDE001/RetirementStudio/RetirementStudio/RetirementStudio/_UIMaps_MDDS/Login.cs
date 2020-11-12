namespace RetirementStudio._UIMaps_MDDS.LoginClasses
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
    

    public partial class Login
    {

        //////public Login()
        //////{
        //////    this.wLogin.pLogin.WaitForControlReady();
        //////    _gLibWeb._Report(_PassFailStep.Step, "Function <" +  "> Starts:");
        //////}


        public MyDictionary dic = new MyDictionary();
        public GenericLib_Win _gLib = new GenericLib_Win();
        public GenericLib_Web _gLibWeb = new GenericLib_Web();


        /// <summary>
        /// 2013-June-18
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Username", "June-Jia");
        ///    dic.Add("Password", "");
        ///    dic.Add("Login", "Click");
        ///    pLogin._PopVerify_Login(dic); 
        ///    
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Verify");
        ///    dic.Add("Username", "June-Jia");
        ///    dic.Add("Password", "");
        ///    dic.Add("Login", "");
        ///    pLogin._PopVerify_Login(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Login(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Login";
            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            this.wLogin.pLogin.WaitForControlReady();
            _gLib._CaptureScreen_PopVerify(sFunctionName);

            if (dic["PopVerify"] == "Pop")
            {
                _gLibWeb._SetSyncUDWeb("Username", this.wLogin.pLogin.txtUserName, dic["Username"], 0);
                _gLibWeb._SetSyncUDWeb("Password", this.wLogin.pLogin.txtPassword, dic["Password"], 0);
                _gLibWeb._SetSyncUDWeb("Login", this.wLogin.pLogin.btnLogin, dic["Login"], 0);
            }


            if (dic["PopVerify"] == "Verify")
            {
                _gLibWeb._VerifySyncUDWeb("Username", this.wLogin.pLogin.txtUserName, dic["Username"], 0);
                _gLibWeb._VerifySyncUDWeb("Password", this.wLogin.pLogin.txtPassword, dic["Password"], 0);
                _gLibWeb._VerifySyncUDWeb("Login", this.wLogin.pLogin.btnLogin, dic["Login"], 0);

            }


            _gLibWeb._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



    }
}
