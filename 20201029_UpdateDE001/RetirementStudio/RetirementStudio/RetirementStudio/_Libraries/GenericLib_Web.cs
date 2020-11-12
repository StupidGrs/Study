using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

using System.CodeDom.Compiler;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
using MouseButtons = System.Windows.Forms.MouseButtons;

using RetirementStudio._Config;

namespace RetirementStudio._Libraries
{
    public class GenericLib_Web : GenericLib
    {

        private Stopwatch stopwatch = new Stopwatch();


        public void _KillAllBrowsers()
        {
            foreach (Process proc in Process.GetProcessesByName("iexplore"))
            {
                proc.Kill();
            }
        }


        public void _LaunchURL(string sURL)
        {
            BrowserWindow.Launch(sURL);

        }

        /// <summary>
        ///  for future usage
        /// </summary>
        //public void SearchhyperLinks()
        //{
        //    //Search for the Div which has the list of hyperlinks we are searching
        //    HtmlDiv div = new HtmlDiv();
        //    div.SearchProperties[HtmlDiv.PropertyNames.Name] = "HeaderContent";
        //    //Pass the instance of Div to HtmlControl class
        //    HtmlControl controls = new HtmlControl(div);
        //    controls.SearchProperties.Add(HtmlControl.PropertyNames.ClassName, "HtmlHyperlink");
        //    UITestControlCollection collection = controls.FindMatchingControls();
        //    foreach (UITestControl links in collection)
        //    {
        //        //cast the item to HtmlHyperlink type
        //        HtmlHyperlink mylink = (HtmlHyperlink)links;
        //        //get the innertext from the link, which inturn returns the link value itself
        //        Console.WriteLine(mylink.InnerText);
        //    }
        //}


        /// <summary>
        /// 2013-June-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    UITestControl control = _gLibWeb._ReturnElement(_SearchType.CheckBox, _SearchBy.LabeledBy, "Client Solutions", 1, true)
        /// </summary>
        /// <param name=""></param>
        public UITestControl _ReturnElement(_SearchType eType, _SearchBy eSearchBy, string sValue, int iIndex, Boolean bEqualTrue_ContainFalse)
        {
            string sFunctionName = "_ReturnElement";
            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to search and return object with Type <" + eType.ToString() + ">, Property <" + eSearchBy.ToString() + ">, Value <" + sValue + ">");


            BrowserWindow wBrowser = new BrowserWindow();
            wBrowser.SearchConfigurations.Add("VisibleOnly");
            wBrowser.SearchProperties.Add(BrowserWindow.PropertyNames.ClassName, "IEFrame");

            wBrowser.WaitForControlReady();
            UITestControl document = wBrowser.CurrentDocumentWindow;
            HtmlControl control = new HtmlControl(document);
            
            switch (eType)
            {
                case _SearchType.CheckBox:
                    {
                        control.SearchProperties.Add(HtmlControl.PropertyNames.ClassName, "HtmlCheckBox");
                        break;
                    }
                case _SearchType.HyperLink:
                    {
                        control.SearchProperties.Add(HtmlControl.PropertyNames.ClassName, "HtmlHyperLink");
                        break;
                    }
                default:
                    {
                        this._Report(_PassFailStep.Fail, "\t\t\tFunction <" + sFunctionName + "> failed Because input object Type <" + eType.ToString() + "> is NOT supported.");
                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed Because input object Type <" + eType.ToString() + "> is NOT supported.");
                        return null;
                    }
                    
            }

            Boolean bSearchByCatched = false;
            switch (eSearchBy)
            {
                case _SearchBy.InnerText:
                    if(bEqualTrue_ContainFalse)
                        control.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, sValue, PropertyExpressionOperator.EqualTo);
                    else
                        control.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, sValue, PropertyExpressionOperator.Contains);
                    bSearchByCatched = true;
                    break;

                default:
                    break;
            }

            switch (eSearchBy)
            {
                case _SearchBy.LabeledBy:
                    {
                        switch (eType)
                        {
                            case _SearchType.CheckBox:
                                if (bEqualTrue_ContainFalse)
                                    control.SearchProperties.Add(HtmlCheckBox.PropertyNames.LabeledBy, sValue, PropertyExpressionOperator.EqualTo);
                                else
                                    control.SearchProperties.Add(HtmlCheckBox.PropertyNames.LabeledBy, sValue, PropertyExpressionOperator.Contains);
                                bSearchByCatched = true;
                                break;
                            default:
                                break;
                        }

                        break;
                    }
                default:
                    break;
            }


            if(!bSearchByCatched)
            {
                this._Report(_PassFailStep.Fail, "\t\t\tFunction <" + sFunctionName + "> failed Because input object search property <" + eSearchBy.ToString() + "> is NOT supported.");
                this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed Because input search property <" + eSearchBy.ToString() + "> is NOT supported.");
                return null;
            }



            UITestControlCollection controlCollection = control.FindMatchingControls();

            if (controlCollection.Count <= 0)
            {
                this._Report(_PassFailStep.Fail, "\t\t\tFunction <" + sFunctionName + "> failed to find object with Type <" + eType.ToString() + ">, Property <" + eSearchBy.ToString() + ">, Value <" + sValue + ">");
                this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to find object with Type <" + eType.ToString() + ">, Property <" + eSearchBy.ToString() + ">, Value <" + sValue + ">");
                return null;
            }
            else
            {
                this._Report(_PassFailStep.Pass, "\t\t\tFunction <" + sFunctionName + "> successfuly find and return object with Type <" + eType.ToString() + ">, Property <" + eSearchBy.ToString() + ">, Value <" + sValue + ">");
                return controlCollection[iIndex - 1];
            }

        }

        /// <summary>
        /// 2013-June-20
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    _gLibWeb._Navigate("Administration", true);
        ///    _gLibWeb._Navigate("Users", false);
        /// </summary>
        /// <param name="sInnerText"></param>
        public void _Navigate(string sInnerText, Boolean bEqualTrue_ContainFalse)
        {

            string sFunctionName = "_Navigate";
            this._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> is going to click Hyperlink with InnerText <" + sInnerText + ">");

            
            BrowserWindow wBrowser = new BrowserWindow();
            wBrowser.SearchConfigurations.Add("VisibleOnly");
            wBrowser.SearchProperties.Add(BrowserWindow.PropertyNames.ClassName, "IEFrame");

            wBrowser.WaitForControlReady();
            UITestControl document = wBrowser.CurrentDocumentWindow;
            document.WaitForControlReady();
            HtmlControl control = new HtmlControl(document);
            control.SearchProperties.Add(HtmlControl.PropertyNames.ClassName, "HtmlHyperlink");
            if (bEqualTrue_ContainFalse)
                control.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, sInnerText, PropertyExpressionOperator.EqualTo);
            else
                control.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, sInnerText, PropertyExpressionOperator.Contains);

            UITestControlCollection controlcollection = control.FindMatchingControls();
            List<string> names = new List<string>();
            Boolean bFindLink = false;
            HtmlHyperlink link = new HtmlHyperlink();
            foreach (UITestControl x in controlcollection)
            {
                if (x is HtmlHyperlink)
                {
                    link = (HtmlHyperlink)x;
                    ////names.Add(s.Href);
                    ////names.Add(s.InnerText);
                    
                    if (bEqualTrue_ContainFalse)
                    {
                        if (String.Equals(link.InnerText, sInnerText, StringComparison.OrdinalIgnoreCase))
                        {
                            bFindLink = true;
                            break;
                        }
                    }
                    else 
                    {
                        if (!String.IsNullOrEmpty(link.InnerText) && link.InnerText.ToUpper().Contains(sInnerText.ToUpper()))
                        {
                            bFindLink = true;
                            break;
                        }
                    }
                }
            }

            if (bFindLink)
            {
                
                this._SetSyncUDWeb("Link: " + sInnerText, link, "Click", 0);
                this._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully click Link with InnerText <" + sInnerText + ">");
            }
            else
            {
                this._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  find Link with InnerText <" + sInnerText + ">!");
                this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  find Link with InnerText <" + sInnerText + ">!");
            }

            wBrowser.WaitForControlReady();
        }

        /// <summary>
        /// 2013-June-23
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    _gLibWeb._NavigateByID("dnn_topLogout_cmdLogin", true);
        ///    _gLibWeb._NavigateByID("Logout", false);
        ///    
        /// </summary>
        /// <param name="sID"></param>
        public void _NavigateByID(string sID, Boolean bEqualTrue_ContainFalse)
        {

            string sFunctionName = "_Navigate";
            this._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> is going to click Link with ID <" + sID + ">");


            BrowserWindow wBrowser = new BrowserWindow();
            wBrowser.SearchConfigurations.Add("VisibleOnly");
            wBrowser.SearchProperties.Add(BrowserWindow.PropertyNames.ClassName, "IEFrame");

            wBrowser.WaitForControlReady();
            UITestControl document = wBrowser.CurrentDocumentWindow;
            document.WaitForControlReady();
            HtmlControl control = new HtmlControl(document);
            control.SearchProperties.Add(HtmlControl.PropertyNames.ClassName, "HtmlHyperlink");
            if (bEqualTrue_ContainFalse)
                control.SearchProperties.Add(HtmlControl.PropertyNames.Id, sID, PropertyExpressionOperator.EqualTo);
            else
                control.SearchProperties.Add(HtmlControl.PropertyNames.Id, sID, PropertyExpressionOperator.Contains);

            UITestControlCollection controlcollection = control.FindMatchingControls();
            List<string> names = new List<string>();
            Boolean bFindLink = false;
            HtmlHyperlink link = new HtmlHyperlink();
            foreach (UITestControl x in controlcollection)
            {
                if (x is HtmlHyperlink)
                {
                    link = (HtmlHyperlink)x;
                    ////names.Add(s.Href);
                    ////names.Add(s.InnerText);

                    if (bEqualTrue_ContainFalse)
                    {
                        if (String.Equals(link.Id, sID, StringComparison.OrdinalIgnoreCase))
                        {
                            bFindLink = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(link.Id) && link.Id.ToUpper().Contains(sID.ToUpper()))
                        {
                            bFindLink = true;
                            break;
                        }
                    }
                }
            }

            if (bFindLink)
            {

                this._SetSyncUDWeb("Link: " + sID, link, "Click", 0);
                this._Report(_PassFailStep.Pass, "Function <" + sFunctionName + "> successfully click Link with ID <" + sID + ">");
            }
            else
            {
                this._Report(_PassFailStep.Fail, "Function <" + sFunctionName + "> fail to  find Link with ID <" + sID + ">!");
                this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  find Link with ID <" + sID + ">!");
            }

        }

        public void _SearchTimeout_SetNew(int iSearchTimeout)
        {
            Playback.PlaybackSettings.SearchTimeout = iSearchTimeout * 1000;
        }

        public void _SearchTimeout_RestoreDefault()
        {
            Playback.PlaybackSettings.SearchTimeout = Config.iTimeout * 1000;
        }

        public void _TestSetup()
        {
            Playback.PlaybackSettings.WaitForReadyTimeout = Config.iTimeout * 1000;
            Playback.PlaybackSettings.SearchTimeout = Config.iTimeout * 1000;
            //Playback.PlaybackSettings.ContinueOnError = true;
        }

        public void _SetSyncUDWeb(string sDesp, object obj, string sVal)
        {
            this._SetSyncUDWeb(sDesp, obj, sVal, 0, true);

        }

        public void _SetSyncUDWeb(string sDesp, object obj, string sVal, int iTimeout)
        {
            this._SetSyncUDWeb(sDesp, obj, sVal, iTimeout, true);

        }

        public void _SetSyncUDWeb(string sDesp, object obj, string sVal, int iTimeout, Boolean bVerify)
        {
            this._SetSyncUDWeb(sDesp, obj, sVal, iTimeout, bVerify, 0, 0);
        }

        public void _SetSyncUDWeb(string sDesp, object obj, string sVal, int iTimeout, Boolean bVerify, int ixPos, int iyPos)
        {
            string sFunctionName = "_SetSyncUDWeb";

            /// if nothing set to this object, exit function
            if (sVal == "")
                return;
            string objType = ((UITestControl)obj).ControlType.ToString();
            
            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> is going to set <" + sVal + "> to " + objType +" <" + sDesp + ">.");

            
            string sActVal = "";
            int iListIndex = 1000;
            Boolean bUseListIndex = false;

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;



            if (this._Exists(sDesp, obj, iTimeout, Config.iSearchInterval, true))
            {
                if (this._Enabled(sDesp, obj, iTimeout))
                {

                    // setfocus on object to make it visible, several type of objects NOT suitable for this method
                    switch (objType)
                    {
                        //case "Button":
                        //case "RadioButton":
                        //case "TitleBar":
                        //case "MenuItem":
                        //case "CheckBox":
                        //case "ComboBox":
                        //    break;
                        default:
                            try                            
                            {
                                ((UITestControl)obj).SetFocus();
                            }
                            catch (Exception ex)
                            {
                                this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set focus on <" + sDesp + "> Because exception threw out: " + Environment.NewLine + ex.Message);
                                this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set focus on <" + sDesp + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                            }
                            break;
                          
                    }


                    if (sVal.ToUpper() == "CLICK")
                    {
                        try 
                        {
                                if (ixPos == 0 && iyPos == 0)
                                    Mouse.Click((UITestControl)obj, new Point(Config.iClickPos_X, Config.iClickPos_Y));
                                else
                                    Mouse.Click((UITestControl)obj, new Point(ixPos, iyPos));
                         }
                        catch (Exception ex)
                        {
                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to click object <" + sDesp + "> with xPos <" + ixPos + ">, yPos <" + iyPos + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                            this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to click object <" + sDesp + "> with xPos <" + ixPos + ">, yPos <" + iyPos + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                        }

                        this._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> successfully set <" + sVal + "> to  " + objType +" <" + sDesp + ">.");
                        return;
                    }

                    /// set the value into the object
                    switch (objType)
                    {
                        case "Button": case "Hypelink":
                            break; // do nothing since Click is already set to object and Click is the only action for HtmlButton
                        case "Edit":
                            {
                                if (((HtmlEdit)obj).Text == sVal)
                                    break;
                                try
                                {
                                    ((HtmlEdit)obj).Text = String.Empty;
                                    Keyboard.SendKeys((HtmlEdit)obj, sVal);
                                }
                                catch (Exception ex)
                                {
                                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set Edit object <" + sDesp + "> with Value <" + sVal + "> Because exception threw out: " + Environment.NewLine + ex.Message);
                                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set Edit object <" + sDesp + "> with Value <" + sVal + ">.  Because exception threw out: " + Environment.NewLine + ex.Message);
                                }

                                break;
                            }
                        case "RadioButton":
                            {
                                try
                                {
                                    if (sVal.ToUpper() == "TRUE")
                                        ((HtmlRadioButton)obj).Selected = true;
                                }
                                catch (Exception ex)
                                {
                                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set value to Radio Button <" + sDesp + "> with <" + sVal.ToUpper() + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set value to Radio Button <" + sDesp + "> with <" + sVal.ToUpper() + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                                }

                                break;
                            }
                        case "CheckBox":
                            {

                                try
                                {
                                    if (sVal.ToUpper() == "TRUE")
                                        ((HtmlCheckBox)obj).Checked = true;
                                    if (sVal.ToUpper() == "FALSE")
                                        ((HtmlCheckBox)obj).Checked = false;
                                }
                                catch (Exception ex)
                                {
                                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set value to CheckBox <" + sDesp + "> with <" + sVal.ToUpper() + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set value to CheckBox <" + sDesp + "> with <" + sVal.ToUpper() + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                                }
                                break;
                            }
                        case "List":
                            {
                                UITestControlCollection uc;

                                Boolean bItemFound = false;
                                HtmlListItem wli = new HtmlListItem((HtmlList)obj);

                                int iFirstOccur = 1000;
                                int iLastOccur = 1000;
                                string sListIndex = "";

                                iFirstOccur = sVal.IndexOf("#");
                                iLastOccur = sVal.LastIndexOf("#");

                                // user uses index to select item
                                if ((iFirstOccur == 0) && (iLastOccur == sVal.Length - 1))
                                {


                                    bUseListIndex = true;
                                    sListIndex = sVal.Substring(1, sVal.Length - 2);
                                    iListIndex = Convert.ToInt32(sListIndex);

                                    if (iListIndex == 0)
                                    {
                                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to  " + objType + " <" + sDesp + ">. Because value: <" + iListIndex + "> less than the minumn index: <1>. ");
                                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to  " + objType + " <" + sDesp + ">. Because value: <" + iListIndex + "> less than the minumn index: <1>. ");
                                    }

                                    uc = ((HtmlList)obj).Items;
                                    if (iListIndex <= uc.Count)
                                    {

                                        wli = (HtmlListItem)uc[iListIndex - 1];
                                        //////this._SetSyncUDWeb(sVal, wli, "Click", 0);
                                        this._SetSyncUDWeb(sVal, wli, "Click", 0, false, 0, 0);
                                        this._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> successfully select item with Index <" + iListIndex + "> to  " + objType + " <" + sDesp + ">.");
                                        return;
                                    }
                                    else
                                    {
                                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to  " + objType + " <" + sDesp + ">. Because value: <" + iListIndex + "> exceeds the Maximum index: <" + uc.Count + ">. ");
                                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to  " + objType + " <" + sDesp + ">. Because value: <" + iListIndex + "> exceeds the Maximum index: <" + uc.Count + ">. ");
                                    }


                                }
                                else
                                {

                                    // 2013-06-07 webber updated the code to improve performance
                                    wli.SearchProperties.Add(HtmlListItem.PropertyNames.Name, sVal);

                                    if (wli.Selected == true)
                                    {
                                        this._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> successfully set <" + sVal + "> to object <" + sDesp + ">. Because value: <" + sVal + "> is alrady selected in the list");
                                        return;
                                    }

                                    try
                                    {
                                        this._SetSyncUDWeb(sVal, wli, "Click", 0, false, 0, 0);
                                    }
                                    catch (Exception ex)
                                    {
                                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + sVal + "> to  " + objType + " <" + sDesp + ">. Because value: <" + sVal + "> does NOT exist in the list");
                                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set <" + sVal + "> to  " + objType + " <" + sDesp + ">. Because value: <" + sVal + "> does NOT exist in the list! Or: " + Environment.NewLine + ex.Message);
                                    }


                                    ////uc = ((HtmlList)obj).Items;
                                    ////for (int i = 0; i < uc.Count; i++)
                                    ////{
                                    ////    wli = (HtmlListItem)uc[i];
                                    ////    if (wli.Name == sVal)
                                    ////    {
                                    ////        bItemFound = true;
                                    ////        break;
                                    ////    }
                                    ////}

                                    ////if (bItemFound)
                                    ////    this._SetSyncUDHtml(sVal, wli, "Click", 0);
                                    ////else
                                    ////{
                                    ////    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + sVal + "> to object <" + sDesp + ">. Because value: <" + sVal + "> does NOT exist in the list");
                                    ////    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set <" + sVal + "> to object <" + sDesp + ">. Because value: <" + sVal + "> does NOT exist in the list");
                                    ////}
                                }




                                break;
                            }
                        case "ComboBox":
                            {

                                UITestControlCollection uc;

                                string sItem = "";
                                Boolean bItemFound = false;

                                int iFirstOccur = 1000;
                                int iLastOccur = 1000;
                                string sListIndex = "";

                                iFirstOccur = sVal.IndexOf("#");
                                iLastOccur = sVal.LastIndexOf("#");

                                // user uses index to select item
                                if ((iFirstOccur == 0) && (iLastOccur == sVal.Length - 1))
                                {
                                    bUseListIndex = true;
                                    sListIndex = sVal.Substring(1, sVal.Length - 2);
                                    iListIndex = Convert.ToInt32(sListIndex);

                                    if (iListIndex == 0)
                                    {
                                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to  " + objType + " <" + sDesp + ">. Because value: <" + iListIndex + "> less than the minumn index: <1>. ");
                                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to  " + objType + " <" + sDesp + ">. Because value: <" + iListIndex + "> less than the minumn index: <1>. ");
                                    }

                                    uc = ((HtmlComboBox)obj).Items;
                                    if (iListIndex <= uc.Count)
                                    {
                                        

                                        try
                                        {
                                            ((HtmlComboBox)obj).SelectedIndex = iListIndex - 1;
                                        }
                                        catch (Exception ex)
                                        {
                                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to select item with Index <" + iListIndex + "> to  " + objType + " <" + sDesp + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                                            this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to select item with Index <" + iListIndex + "> to   " + objType + " <" + sDesp + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                                        }
                                    
                                    }
                                    else
                                    {
                                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to  " + objType + " <" + sDesp + ">. Because value: <" + iListIndex + "> exceeds the Maximum index: <" + uc.Count + ">. ");
                                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to  " + objType + " <" + sDesp + ">. Because value: <" + iListIndex + "> exceeds the Maximum index: <" + uc.Count + ">. ");
                                    }


                                }
                                else // use regular selection by name
                                {

                                    if (((HtmlComboBox)obj).SelectedItem != null && ((HtmlComboBox)obj).SelectedItem.ToString() == sVal)
                                    {
                                        // default item same as user input
                                    }
                                    else
                                    {
                                        try
                                        {
                                            ((HtmlComboBox)obj).SelectedItem = sVal;
                                        }
                                        catch (Exception ex)
                                        {
                                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + sVal + "> to  " + objType + " <" + sDesp + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                                            this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set <" + sVal + "> to  " + objType + " <" + sDesp + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                                        }

                                        // 2013-5-10, webber: below codes are commented because its poor performance
                                        ////uc = ((HtmlComboBox)obj).Items;
                                        ////bUseListIndex = false;
                                        ////for (int i = 0; i < uc.Count; i++)
                                        ////{
                                        ////    sItem = uc[i].Name.ToString();
                                        ////    if (sVal == sItem)
                                        ////    {
                                        ////        bItemFound = true;
                                        ////        break;
                                        ////    }
                                        ////}

                                        ////if (bItemFound)
                                        ////{
                                        ////    ((HtmlComboBox)obj).SelectedItem = sVal;
                                        ////}
                                        ////else
                                        ////{
                                        ////    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + sVal + "> to object <" + sDesp + ">. Because value: <" + sVal + "> does NOT exist in the list");
                                        ////    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set <" + sVal + "> to object <" + sDesp + ">. Because value: <" + sVal + "> does NOT exist in the list");
                                        ////}
                                    }


                                }

                                break;
                            }
                        default:
                            break;
                    }

                    if (bVerify) /// verify the value from object
                    {
                        switch (objType)
                        {
                            case "Edit":
                                {
                                    sActVal = ((HtmlEdit)obj).GetProperty("Text").ToString();
                                    break;
                                }
                            case "RadioButton":
                                {
                                    sActVal = ((HtmlRadioButton)obj).GetProperty("Selected").ToString();
                                    break;
                                }
                            case "CheckBox":
                                {
                                    sActVal = ((HtmlCheckBox)obj).GetProperty("Checked").ToString();
                                    break;
                                }
                            case "ComboBox":
                                {
                                    if (bUseListIndex)
                                        sActVal = "#" + (Convert.ToInt32(((HtmlComboBox)obj).GetProperty("SelectedIndex")) + 1).ToString() + "#";
                                    else
                                        sActVal = ((HtmlComboBox)obj).GetProperty("SelectedItem").ToString();
                                    break;
                                }
                            case "List":
                                {
                                    if (bUseListIndex)
                                    {
                                        int[] il = ((HtmlList)obj).SelectedIndices;
                                        if (il.Length == 1)
                                        {
                                            sActVal = "#" + (il[0] + 1).ToString() + "#";
                                        }
                                        else
                                        {
                                            sActVal = "Multi Item selected!";
                                        }

                                    }

                                    else
                                    {
                                        string[] sl = ((HtmlList)obj).SelectedItems;
                                        if (sl.Length == 1)
                                        {
                                            sActVal = sl[0];
                                        }
                                        else
                                        {
                                            sActVal = "Multi Item selected!";
                                        }

                                    }
                                    break;
                                }
                            default:
                                break;
                        }


                        if (sActVal == sVal)
                        {
                            this._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> successfully set <" + sVal + "> to  " + objType + " <" + sDesp + ">.");
                        }
                        else
                        {
                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + sVal + "> to  " + objType + " <" + sDesp + ">. Actual Value: <" + sActVal + "> ");
                            this._MsgBoxYesNo("Continue Testing?", "Fail: Verify  " + objType + " <" + sDesp + "> with expected value: <" + sVal + ">. Actual Value: <" + sActVal + "> ");
                        }


                    }
                }
            }



            return;


        }

        public void _VerifySyncUDWeb(string sDesp, object obj, string sVal)
        {
            this._VerifySyncUDWeb(sDesp, obj, sVal, 0);

        }

        public void _VerifySyncUDWeb(string sDesp, object obj, string sVal, int iTimeout)
        {

            /// if nothing set to this object, exit function
            if (sVal == "")
                return;

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;

            string sFunctionName = "_VerifySyncUDWeb";
            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> is going to Verify Object: <" + sDesp + "> with expected value: <" + sVal + ">.");

            string objType = ((UITestControl)obj).ControlType.ToString();
            string sActVal = "";

            Boolean bUseListIndex = false;




            if (this._Exists(sDesp, obj, iTimeout))
            {

                // setfocus on object, several type of objects NOT suitable for this method
                switch (objType)
                {
                    case "RadioButton":
                    case "TitleBar":
                    case "MenuItem":
                    case "CheckBox":
                    case "Edit":
                        break;
                    default:
                        ((UITestControl)obj).SetFocus();
                        break;

                }



                switch (objType)
                {
                    case "Button":
                        break; // do nothing, becaue Exist property is already checked with above codes
                    case "Edit":
                        {
                            sActVal = ((HtmlControl)obj).GetProperty("Text").ToString();
                            break;
                        }
                    case "RadioButton":
                        {
                            sActVal = ((HtmlRadioButton)obj).GetProperty("Selected").ToString();
                            break;
                        }
                    case "CheckBox":
                        {
                            sActVal = ((HtmlCheckBox)obj).GetProperty("Checked").ToString();
                            break;
                        }
                    case "Text":
                        {

                            sActVal = ((HtmlTextArea)obj).GetProperty("Name").ToString();
                            break;
                        }
                    case "ComboBox":
                        {

                            int iFirstOccur = 1000;
                            int iLastOccur = 1000;

                            iFirstOccur = sVal.IndexOf("#");
                            iLastOccur = sVal.LastIndexOf("#");

                            if ((iFirstOccur == 0) && (iLastOccur == sVal.Length - 1))
                            {
                                bUseListIndex = true;
                            }


                            if (bUseListIndex)
                                sActVal = "#" + (Convert.ToInt32(((HtmlComboBox)obj).GetProperty("SelectedIndex")) + 1).ToString() + "#";
                            else
                                sActVal = ((HtmlComboBox)obj).GetProperty("SelectedItem").ToString();

                            break;
                        }
                    case "List":
                        {
                            int iFirstOccur = 1000;
                            int iLastOccur = 1000;

                            iFirstOccur = sVal.IndexOf("#");
                            iLastOccur = sVal.LastIndexOf("#");

                            if ((iFirstOccur == 0) && (iLastOccur == sVal.Length - 1))
                            {
                                bUseListIndex = true;
                            }

                            if (bUseListIndex)
                            {
                                int[] il = ((HtmlList)obj).SelectedIndices;
                                if (il.Length == 1)
                                {
                                    sActVal = "#" + (il[0] + 1).ToString() + "#";
                                }
                                else
                                {
                                    sActVal = "Multi Item selected!";
                                }

                            }

                            else
                            {
                                string[] sl = ((HtmlList)obj).SelectedItems;
                                if (sl.Length == 1)
                                {
                                    sActVal = sl[0];
                                }
                                else
                                {
                                    sActVal = "Multi Item selected!";
                                }

                            }
                            break;
                        }
                    default:
                        break;

                }

                if (sVal == sActVal)
                {
                    this._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> Pass: Verify Object: <" + sDesp + "> with expected value: <" + sVal + ">. Actual Value: <" + sActVal + "> ");
                }
                else
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> Fail: Verify Object: <" + sDesp + "> with expected value: <" + sVal + ">. Actual Value: <" + sActVal + "> ");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Verify Object: <" + sDesp + "> with expected value: <" + sVal + ">. Actual Value: <" + sActVal + "> ");
                }
            }





        }


        public Boolean _Exists(string sDesp, Object obj, int iTimeout)
        {
            return this._Exists(sDesp, obj, iTimeout, true);

        }

        public Boolean _Exists(string sDesp, Object obj, int iTimeout, Boolean bVerify)
        {
            return this._Exists(sDesp, obj, iTimeout, 0, bVerify);
        }

        public Boolean _Exists(string sDesp, Object obj, int iTimeout, int iSearchInterval, Boolean bVerify)
        {
            string sFunctionName = "_Exists";
            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to check if object <" + sDesp + "> exists.");




            if (iSearchInterval == 0)
                iSearchInterval = Config.iSearchInterval;

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;


            Boolean bExist = false;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int i = 0;


            try
            {
                /// Check if object exist and ready for input
                for (; i <= iTimeout; )
                {

                    this._SearchTimeout_SetNew(iSearchInterval);
                    bExist = ((UITestControl)obj).Exists;
                    this._SearchTimeout_RestoreDefault();
                    if (bExist)
                        break;

                    //Thread.Sleep(1000);
                    stopwatch.Stop();
                    i = i + (int)(stopwatch.ElapsedMilliseconds / 1000);


                    stopwatch.Restart();
                }
            }
            catch (Exception ex)
            {
                this._MsgBoxYesNo("", ex.Message);
                // do nothing here because the msgbox function will give user option to quit or keep testing
            }
            if (bExist)
            {
                if (Config.bDrawHighlight)
                    ((UITestControl)obj).DrawHighlight();

                this._Report(_PassFailStep.Pass, "\t\t\tFunction <" + sFunctionName + ">: object <" + sDesp + "> exists.");
            }
            else
            {
                if (bVerify)
                {
                    this._Report(_PassFailStep.Fail, "\t\t\tFunction <" + sFunctionName + ">: object <" + sDesp + "> does NOT exist within <" + iTimeout + "> seconds!");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Object: <" + sDesp + "> does NOT exists within <" + iTimeout + "> seconds!");
                }
            }

            return bExist;

        }

        public Boolean _Enabled(string sDesp, Object obj, int iTimeout)
        {
            return this._Enabled(sDesp, obj, iTimeout, true);
        }

        public Boolean _Enabled(string sDesp, Object obj, int iTimeout, Boolean bVerify)
        {
            string sFunctionName = "_Enabled";
            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to check if object <" + sDesp + "> is enabled.");

            Boolean bEnable = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int i = 0;

            try
            {
                /// Check if object enabled and ready for input
                for (; i <= iTimeout; )
                {

                    bEnable = ((UITestControl)obj).Enabled;

                    if (bEnable)
                        break;

                    Thread.Sleep(1000);
                    stopwatch.Stop();
                    i = i + (int)(stopwatch.ElapsedMilliseconds / 1000);


                    stopwatch.Restart();
                }
            }
            catch (Exception ex)
            {
                // do nothing here because the msgbox function will give user option to quit or keep testing
            }

            if (bEnable)
            {
                this._Report(_PassFailStep.Pass, "\t\t\tFunction <" + sFunctionName + ">: object <" + sDesp + "> is enabled.");
            }
            else
            {
                if (bVerify)
                {
                    this._Report(_PassFailStep.Fail, "\t\t\tFunction <" + sFunctionName + ">: object <" + sDesp + "> is disabled.");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Object: <" + sDesp + "> is NOT enabled within <" + iTimeout + "> seconds!");
                }
            }

            return bEnable;

        }



        public int _TBL_ReturnIndex_Row(string sDesp, HtmlTable tbl, string sRow, string sCol, int iTimeout)
        {
            string sFunctionName = "_TBL_ReturnIndex_Row";
            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to return Row index on table <" + sDesp
                + "> at Row <" + sRow + ">, Col <" + sCol + ">");

            int iCol = this._TBL_ReturnHeaderIndex_Col(sDesp, tbl, sCol, iTimeout);
            int iRow = this._TBL_ReturnIndex_Row(sDesp, tbl, sRow, iCol, iTimeout);

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> finished interacting on table <" + sDesp
                + "> at Row <" + sRow + ">, Col <" + sRow + ">");

            return iRow;
        }


        public int _TBL_ReturnIndex_Row(string sDesp, HtmlTable tbl, string sRow, int iCol, int iTimeout)
        {
            string sFunctionName = "_TBL_ReturnIndex_Row";
            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to return Row index on table <" + sDesp
                + "> at Row <" + sRow + ">, Col <" + iCol + ">");

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;
            int iTotalRow, iTotalCol, iTotalCell;
            int iRow = 0;


            if (this._Exists(sDesp, tbl, iTimeout))
            {

                HtmlCell objCell;
                Boolean bFindCell = false;


                iTotalCell = tbl.Cells.Count;
                iTotalRow = tbl.RowCount;
                iTotalCol = tbl.ColumnCount;

                if (iCol > iTotalCol)
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because input Colum index <" + iCol + "> exceed maximum Col Number <" + iTotalCol + ">");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because input Colum index <" + iCol + "> exceed maximum Col Number <" + iTotalCol + ">");
                }


                string sAct = "";


                for (int i = 1; i <= iTotalCell/iTotalCol; i++)
                {

                    objCell = (HtmlCell)tbl.Cells[(i-1 )* (iTotalCol + iCol - 1)];
                    sAct = objCell.FriendlyName;

                    if (String.Equals(sRow, sAct, StringComparison.OrdinalIgnoreCase))
                    {
                        bFindCell = true;
                        iRow = i;
                        break;
                    }

                }

                if (!bFindCell)
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed to find Row  <" + sRow
                       + "> in column <" + iCol + ">");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to find Row  <" + sRow
                       + "> in column <" + iCol + ">");
                    return 10000;
                }
                else
                    this._Report(_PassFailStep.Pass, "\t\t\tFunction <" + sFunctionName + "> successfully find Row  <" + sRow
                       + "> in column <" + iCol + ">, return Row Index <" + iRow + ">");

            }

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> finished interacting on table <" + sDesp
                + "> at Row <" + sRow + ">, Col <" + iCol + ">");

            return iRow;

        }


        public int _TBL_ReturnHeaderIndex_Col(string sDesp, HtmlTable tbl, string sCol, int iTimeout)
        {
            string sFunctionName = "_TBL_ReturnHeaderIndex_Col";
            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to return Column Header <" +
                sCol + ">'s Index on table <" + sDesp + ">");

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;

            int iTotalCol;
            string sAct;
            int iCol = 0;
            HtmlCell objCell;
            Boolean bFindCell = false;

            if (this._Exists(sDesp, tbl, iTimeout))
            {
                iTotalCol = tbl.ColumnCount;

                for (int i = 0; i < iTotalCol; i++)
                {
                    objCell = (HtmlCell)tbl.Cells[i];
                    sAct = objCell.FriendlyName;

                    if (String.Equals(sCol, sAct, StringComparison.OrdinalIgnoreCase))
                    {
                        bFindCell = true;
                        iCol = i;
                        break;
                    }
                }

                if (!bFindCell)
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed to find Column  <" + sCol + ">");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed to find Column  <" + sCol + ">");
                    return 10000;
                }
                else
                    this._Report(_PassFailStep.Pass, "\t\t\tFunction <" + sFunctionName + "> successfully find Column  <" + sCol
                        + ">, return Column Index <" + (iCol + 1).ToString() + ">");

            }

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> finished interacting on table <" + sDesp
                + ">");

            return iCol + 1;
        }



        public string _TBL_Table(string sDesp, HtmlTable tbl, string sRow, string sCol, string sData, int iTimeout, Boolean bClick, Boolean bSetData, Boolean bVerify, Boolean bReturn)
        {
            string sFunctionName = "_TBL_Table";
            string sActContent;

            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> is going to interact on table <" + sDesp
                + "> at Row <" + sRow + ">, Col <" + sCol + "> using Data <" + sData + ">");

            int iRow = this._TBL_ReturnIndex_Row(sDesp, tbl, sRow, sCol, iTimeout);
            int iCol = this._TBL_ReturnHeaderIndex_Col(sDesp, tbl, sCol, iTimeout);
            sActContent = this._TBL_Table(sDesp, tbl, iRow, iCol, sData, iTimeout, bClick, bSetData, bVerify, bReturn);


            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> finished interacting on table <" + sDesp
                + "> at Row <" + sRow + ">, Col <" + sCol + "> using Data <" + sData + ">");

            return sActContent;

        }

        public string _TBL_Table(string sDesp, HtmlTable tbl, string sRow, int iCol, string sData, int iTimeout, Boolean bClick, Boolean bSetData, Boolean bVerify, Boolean bReturn)
        {
            string sFunctionName = "_TBL_Table";
            string sActContent;

            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> is going to interact on table <" + sDesp
                + "> at Row <" + sRow + ">, Col <" + iCol + "> using Data <" + sData + ">");

            int iRow = this._TBL_ReturnIndex_Row(sDesp, tbl, sRow, iCol, iTimeout);
            sActContent = this._TBL_Table(sDesp, tbl, iRow, iCol, sData, iTimeout, bClick, bSetData, bVerify, bReturn);


            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> finished interacting on table <" + sDesp
                + "> at Row <" + sRow + ">, Col <" + iCol + "> using Data <" + sData + ">");

            return sActContent;

        }

        public string _TBL_Table(string sDesp, HtmlTable tbl, int iRow, int iCol, string sData, int iTimeout, Boolean bClick, Boolean bSetData, Boolean bVerify, Boolean bReturn)
        {
            string sFunctionName = "_TBL_Table";
            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> is going to interact on table <" + sDesp
                + "> at Row <" + iRow + ">, Col <" + iCol + "> using Data <" + sData + ">");



            if (iTimeout == 0)
                iTimeout = Config.iTimeout;

            int iTotalRow, iTotalCol;
            string sActContent = "";


            if (this._Exists(sDesp, tbl, iTimeout))
            {

                HtmlCell objCell;


                iTotalRow = tbl.RowCount;
                iTotalCol = tbl.ColumnCount;

                if (iRow > iTotalRow)
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because input Row index <" + iRow
                        + "> exceeds maximum table maximum Row number <" + iTotalRow + ">");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because input Row index <" + iRow
                        + "> exceeds maximum table maximum Row number <" + iTotalRow + ">");
                }
                else if (iCol > iTotalCol)
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because input Col index <" + iCol
                        + "> exceeds maximum table maximum Col number <" + iTotalCol + ">");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because input Col index <" + iCol
                        + "> exceeds maximum table maximum Col number <" + iTotalCol + ">");
                }
                else
                {


                    objCell = (HtmlCell)tbl.Cells[(iRow - 1) * (iTotalCol + iCol - 1)];

                    sActContent = objCell.FriendlyName;

                    if (bClick)
                        this._SetSyncUDWeb("Cell<" + iRow + "," + iCol + ">", objCell, "Click", 0);
                    //if (bSetData) // to do

                    if (bVerify)
                    {

                        if (sData == sActContent)
                        {
                            this._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> succesfully verified value: "
                                + sData + " in Row index <" + iRow + ">, Col index <" + iCol + ">");
                        }
                        else
                        {
                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> Failed in verifying value: "
                                + sData + " in Row index <" + iRow + ">, Col index <" + iCol + ">. Expected <" + sData
                                + ">, Actual <" + sActContent + ">.");
                            this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> Failed in verifying value: "
                                + sData + " in Row index <" + iRow + ">, Col index <" + iCol + ">. Expected <" + sData
                                + ">, Actual <" + sActContent + ">.");
                        }
                    }

                    if (bReturn)
                    {
                        // do nothing, function will return at the end 
                    }
                }
            }

            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> finished interacting on table <" + sDesp
                + "> at Row <" + iRow + ">, Col <" + iCol + "> using Data <" + sData + ">");

            return sActContent;

        }

   
    }
}
