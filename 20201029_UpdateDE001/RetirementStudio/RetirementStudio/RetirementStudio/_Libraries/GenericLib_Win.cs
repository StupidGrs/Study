using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
using MouseButtons = System.Windows.Forms.MouseButtons;

using System.Windows.Forms;
using RetirementStudio._Config;

namespace RetirementStudio._Libraries
{
    public class GenericLib_Win : GenericLib
    {

        private Stopwatch stopwatch = new Stopwatch();

        public void _SearchTimeout_SetNew(double iSearchTimeout)
        {
            Playback.PlaybackSettings.SearchTimeout = Convert.ToInt32(iSearchTimeout * 1000);
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


        public void _SetSyncUDWin(string sDesp, object obj, string sVal, int iTimeout)
        {
            this._SetSyncUDWin(sDesp, obj, sVal, iTimeout, true);

        }


        public void _SetSyncUDWin(string sDesp, object obj, string sVal, int iTimeout, Boolean bVerify)
        {
            this._SetSyncUDWin(sDesp, obj, sVal, iTimeout, bVerify, 0, 0);
        }


        public void _SetSyncUDWin(string sDesp, object obj, string sVal, int iTimeout, Boolean bVerify, int ixPos, int iyPos)
        {
            string sFunctionName = "_SetSyncUDWin";

            /// if nothing set to this object, exit function
            if (sVal == "")
                return;


            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> is going to set <" + sVal + "> to object <" + sDesp + ">.");

            string objType = ((UITestControl)obj).ControlType.ToString();
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
                        case "Button":
                        case "Edit":
                        case "RadioButton":
                        case "TitleBar":
                        case "MenuItem":
                        case "CheckBox":
                        case "ComboBox":
                        case "List":
                        case "ListItem":
                            break;
                        default:
                            try
                            {
                                ((WinControl)obj).SetFocus();
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
                        if (ixPos == 0 && iyPos == 0)
                        {
                            ixPos = Config.iClickPos_X;
                            iyPos = Config.iClickPos_Y;
                        }
                        try
                        {
                            Mouse.Click((UITestControl)obj, new Point(ixPos, iyPos));
                        }
                        catch (Exception ex)
                        {
                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to click object <" + sDesp + "> with xPos <" + ixPos + ">, yPos <" + iyPos + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                            this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to click object <" + sDesp + "> with xPos <" + ixPos + ">, yPos <" + iyPos + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                        }

                        this._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> successfully set <" + sVal + "> to object <" + sDesp + ">.");
                        return;
                    }

                    /// set the value into the object
                    switch (objType)
                    {
                        case "Button":
                            break; // do nothing since Click is already set to object and Click is the only action for WinButton
                        case "Edit":
                            {
                                if (((WinEdit)obj).Text == sVal)
                                    break;
                                try
                                {
                                    ((WinEdit)obj).Text = String.Empty;
                                    Keyboard.SendKeys((WinEdit)obj, sVal);
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
                                        ((WinRadioButton)obj).Selected = true;
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
                                        ((WinCheckBox)obj).Checked = true;
                                    if (sVal.ToUpper() == "FALSE")
                                        ((WinCheckBox)obj).Checked = false;
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
                                WinListItem wli = new WinListItem((WinList)obj);

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
                                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to object <" + sDesp + ">. Because value: <" + iListIndex + "> less than the minumn index: <1>. ");
                                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to object <" + sDesp + ">. Because value: <" + iListIndex + "> less than the minumn index: <1>. ");
                                    }

                                    uc = ((WinList)obj).Items;
                                    if (iListIndex <= uc.Count)
                                    {

                                        wli = (WinListItem)uc[iListIndex - 1];
                                        this._SetSyncUDWin(sVal, wli, "Click", 0);
                                        ////this._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> successfully select item with Index <" + iListIndex + "> to object <" + sDesp + ">.");
                                    }
                                    else
                                    {
                                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to object <" + sDesp + ">. Because value: <" + iListIndex + "> exceeds the Maximum index: <" + uc.Count + ">. ");
                                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to object <" + sDesp + ">. Because value: <" + iListIndex + "> exceeds the Maximum index: <" + uc.Count + ">. ");
                                    }


                                }
                                else
                                {

                                    // 2013-06-07 webber updated the code to improve performance
                                    wli.SearchProperties.Add(WinListItem.PropertyNames.Name, sVal);



                                    try
                                    {
                                        if (wli.Selected == true)
                                        {
                                            this._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> successfully set <" + sVal + "> to object <" + sDesp + ">. Because value: <" + sVal + "> is alrady selected in the list");
                                            return;
                                        }

                                        this._SetSyncUDWin(sVal, wli, "Click", 0);
                                    }
                                    catch (Exception ex)
                                    {
                                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + sVal + "> to object <" + sDesp + ">. Because value: <" + sVal + "> does NOT exist in the list");
                                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set <" + sVal + "> to object <" + sDesp + ">. Because value: <" + sVal + "> does NOT exist in the list! Or: " + Environment.NewLine + ex.Message);
                                    }


                                    ////uc = ((WinList)obj).Items;
                                    ////for (int i = 0; i < uc.Count; i++)
                                    ////{
                                    ////    wli = (WinListItem)uc[i];
                                    ////    if (wli.Name == sVal)
                                    ////    {
                                    ////        bItemFound = true;
                                    ////        break;
                                    ////    }
                                    ////}

                                    ////if (bItemFound)
                                    ////    this._SetSyncUDWin(sVal, wli, "Click", 0);
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
                                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to object <" + sDesp + ">. Because value: <" + iListIndex + "> less than the minumn index: <1>. ");
                                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to object <" + sDesp + ">. Because value: <" + iListIndex + "> less than the minumn index: <1>. ");
                                    }

                                    uc = ((WinComboBox)obj).Items;
                                    if (iListIndex <= uc.Count)
                                    {
                                        ((WinComboBox)obj).SelectedIndex = iListIndex - 1;
                                        ////this._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> successfully select item with Index <" + iListIndex + "> to object <" + sDesp + ">.");

                                    }
                                    else
                                    {
                                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to object <" + sDesp + ">. Because value: <" + iListIndex + "> exceeds the Maximum index: <" + uc.Count + ">. ");
                                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to  select item with Index <" + iListIndex + "> to object <" + sDesp + ">. Because value: <" + iListIndex + "> exceeds the Maximum index: <" + uc.Count + ">. ");
                                    }


                                }
                                else // use regular selection by name
                                {
                                    //////////this._MsgBox(((WinComboBox)obj).SelectedItem.ToString(), sVal);

                                    if (((WinComboBox)obj).SelectedItem != null && ((WinComboBox)obj).SelectedItem.ToString() == sVal)
                                    {
                                        // default item same as user input
                                    }
                                    else
                                    {
                                        try
                                        {
                                            ((WinComboBox)obj).SelectedItem = sVal;
                                        }
                                        catch (Exception ex)
                                        {
                                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + sVal + "> to object <" + sDesp + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                                            this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set <" + sVal + "> to object <" + sDesp + ">. Because exception threw out: " + Environment.NewLine + ex.Message);
                                        }

                                        // 2013-5-10, webber: below codes are commented because its poor performance
                                        ////uc = ((WinComboBox)obj).Items;
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
                                        ////    ((WinComboBox)obj).SelectedItem = sVal;
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
                        try
                        {
                            switch (objType)
                            {
                                case "Edit":
                                    {
                                        sActVal = ((WinEdit)obj).GetProperty("Text").ToString();
                                        break;
                                    }
                                case "RadioButton":
                                    {
                                        sActVal = ((WinRadioButton)obj).GetProperty("Selected").ToString();
                                        break;
                                    }
                                case "CheckBox":
                                    {
                                        sActVal = ((WinCheckBox)obj).GetProperty("Checked").ToString();
                                        break;
                                    }
                                case "ComboBox":
                                    {
                                        if (bUseListIndex)
                                            sActVal = "#" + (Convert.ToInt32(((WinComboBox)obj).GetProperty("SelectedIndex")) + 1).ToString() + "#";
                                        else
                                            sActVal = ((WinComboBox)obj).GetProperty("SelectedItem").ToString();
                                        break;
                                    }
                                case "List":
                                    {
                                        if (bUseListIndex)
                                        {
                                            int[] il = ((WinList)obj).SelectedIndices;
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
                                            string[] sl = ((WinList)obj).SelectedItems;
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
                        }
                        catch (Exception ex)
                        {
                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> Not able to get object <" + objType + ">  <" + sDesp + ">'s Actual Value. Because exception threw out: " + Environment.NewLine + ex.Message);
                            this._MsgBoxYesNo("Continue Testing?", "Fail: Not able to get object <" + objType + ">  <" + sDesp + ">'s Actual Value. Because exception threw out: " + Environment.NewLine + ex.Message);
                        }

                        if (sActVal.ToUpper() == sVal.ToUpper())
                        {
                            this._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> successfully set <" + sVal + "> to object <" + sDesp + ">.");
                        }
                        else
                        {
                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + sVal + "> to object <" + sDesp + ">. Actual Value: <" + sActVal + "> ");
                            this._MsgBoxYesNo("Continue Testing?", "Fail: Verify Object: <" + sDesp + "> with expected value: <" + sVal + ">. Actual Value: <" + sActVal + "> ");
                        }


                    }
                }
            }



            return;


        }


        public void _VerifySyncUDWin(string sDesp, object obj, string sVal, int iTimeout)
        {

            /// if nothing set to this object, exit function
            if (sVal == "")
                return;

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;

            string sFunctionName = "_VerifySyncUDWin";
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
                        ((WinControl)obj).SetFocus();
                        break;

                }



                switch (objType)
                {
                    case "Button":
                        break; // do nothing, becaue Exist property is already checked with above codes
                    case "Edit":
                        {
                            sActVal = ((WinControl)obj).GetProperty("Text").ToString().TrimStart(' ').TrimEnd(' ');
                            break;
                        }
                    case "RadioButton":
                        {
                            sActVal = ((WinRadioButton)obj).GetProperty("Selected").ToString();
                            break;
                        }
                    case "CheckBox":
                        {
                            sActVal = ((WinCheckBox)obj).GetProperty("Checked").ToString();
                            break;
                        }
                    case "Text":
                        {

                            sActVal = ((WinText)obj).GetProperty("Name").ToString();
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
                                sActVal = "#" + ((Convert.ToInt32(((WinComboBox)obj).GetProperty("SelectedIndex")) + 1).ToString()) + "#";
                            else
                                try
                                {
                                    sActVal = ((WinComboBox)obj).GetProperty("SelectedItem").ToString();
                                }
                                catch (Exception ex)
                                {
                                    {
                                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> Not able to get object <" + objType + ">  <" + sDesp + ">'s Actual Value. Because exception threw out: " + Environment.NewLine + ex.Message);
                                        this._MsgBoxYesNo("Continue Testing?", "Fail: Not able to get object <" + objType + ">  <" + sDesp + ">'s Actual Value. Because exception threw out: " + Environment.NewLine + ex.Message);
                                    }
                                }

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
                                int[] il = ((WinList)obj).SelectedIndices;
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
                                string[] sl = ((WinList)obj).SelectedItems;
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


        //public void _TreeViewSelectWin_(int iSearchTimeout, Dictionary<string, WinTreeItem> dic)
        //{
        //    string sFunctionName = "_TreeViewSelectWin";

        //    if (iSearchTimeout == 0)
        //        iSearchTimeout = _Config._iTimeout;

        //    this._SearchTimeout_SetNew(iSearchTimeout);

        //    int iNum = dic.Count;

        //    for (int i = 1; i <= iNum; i++)
        //    {
        //        if (this._Exists("Level_" + i.ToString(), dic["obj_Level_" + i.ToString()], iSearchTimeout))
        //        {
        //            try
        //            {
        //                dic["obj_Level_" + i.ToString()].SetFocus();
        //                Mouse.Click(dic["obj_Level_" + i.ToString()], new Point(_Config._iClickPos_X, _Config._iClickPos_Y));
        //            }
        //            catch (Exception ex)
        //            {
        //                // need add msgbox to give user error info and option
        //            }
        //        }
        //    }

        //    this._SearchTimeout_RestoreDefault();


        //}


        public Boolean _Exists(string sDesp, Object obj, double iTimeout)
        {
            return this._Exists(sDesp, obj, iTimeout, true);

        }

        public Boolean _Exists(string sDesp, Object obj, double iTimeout, Boolean bVerify)
        {
            return this._Exists(sDesp, obj, iTimeout, 0, bVerify);
        }

        public Boolean _Exists(string sDesp, Object obj, double iTimeout, double iSearchInterval, Boolean bVerify)
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
            double i = 0;


            try
            {
                /// Check if object exist and ready for input
                for (; i <= iTimeout; )
                {

                    this._SearchTimeout_SetNew(iSearchInterval);
                    bExist = ((WinControl)obj).Exists;

                    this._SearchTimeout_RestoreDefault();
                    if (bExist)
                    {
                        // add to highlight
                        if (Config.bHighlight)
                            ((WinControl)obj).DrawHighlight();

                        break;
                    }

                    //Thread.Sleep(1000);
                    stopwatch.Stop();
                    i = i + stopwatch.ElapsedMilliseconds / 1000;


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

                    bEnable = ((WinControl)obj).Enabled;

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


        public void _TreeViewSelectWin(int iSearchTimeout, Object objParent, MyDictionary dic)
        {
            this._TreeViewSelectWin(iSearchTimeout, true, objParent, dic);
        }


        public string _TreeViewSelectWin(int iSearchTimeout, bool bClickItem, Object objParent, MyDictionary dic)
        {
            string sFunctionName = "_TreeViewSelectWin";
            string sFullTreeItemPath = "";

            if (iSearchTimeout == 0)
                iSearchTimeout = Config.iTimeout / 30;  //// Need to adjust for 250 clients in Prod

            this._SearchTimeout_SetNew(iSearchTimeout);

            int iNum = dic.Count;

            for (int i = 1; i <= iNum; i++)
                sFullTreeItemPath = sFullTreeItemPath + dic["Level_" + i.ToString()] + "->";

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to select tree item <" + sFullTreeItemPath + ">.");


            WinTreeItem wTvi = new WinTreeItem((UITestControl)objParent);

            if (this._Exists("TreeViewParent", objParent, iSearchTimeout))
            {
                for (int i = 1; i <= iNum; i++)
                {

                    if (dic["Level_" + i.ToString()] != "")
                    {
                        ////wTvi.SearchProperties.Add(WinTreeItem.PropertyNames.MaxDepth, "0");
                        wTvi.SearchProperties.Add(WinTreeItem.PropertyNames.MaxDepth, (i - 1).ToString());
                        wTvi.SearchProperties.Add(WinTreeItem.PropertyNames.Name, dic["Level_" + i.ToString()]);
                        wTvi.SearchProperties["Value"] = (i - 1).ToString();
                        wTvi.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);


                        if (i > 1) wTvi.SearchConfigurations.Add(SearchConfiguration.NextSibling);

                        if (this._Exists(dic["Level_" + i.ToString()], wTvi, iSearchTimeout, iSearchTimeout, false))
                        {
                            if ((i == iNum - 1) && bClickItem)
                                this._SetSyncUDWin(dic["Level_" + i.ToString()], wTvi, "Click", 0, false, Config.iClickPos_X, Config.iClickPos_Y);

                            if (i == iNum)
                            {
                                wTvi.SetFocus();
                                //////Mouse.Click(wTvi, new Point(Config.iClickPos_X, Config.iClickPos_Y));

                                if (bClickItem)
                                {
                                    this._SetSyncUDWin(dic["Level_" + i.ToString()], wTvi, "Click", 0, false, Config.iClickPos_X, Config.iClickPos_Y);

                                }

                            }

                            wTvi = new WinTreeItem((UITestControl)wTvi);
                        }
                        else
                            return "E_CP_NOT_Found";
                    }
                }

            }

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> successfully select tree item <" + sFullTreeItemPath + ">.");
            return "";

        }


        public void _TabPageSelectWin(string sTabName, Object objParent, int iTimeout)
        {
            string sFunctionName = "_TabPageSelectWin";
            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to select tab page <" + sTabName + ">.");

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;

            WinTabPage wTP = new WinTabPage((UITestControl)objParent);
            wTP.SearchProperties.Add(WinTabPage.PropertyNames.Name, sTabName);

            if (this._Exists(sTabName, wTP, iTimeout) && this._Enabled(sTabName, wTP, iTimeout))
            {
                this._SetSyncUDWin("Tab", wTP, "Click", iTimeout);
                //////Mouse.Click(wTP, new Point(Config.iClickPos_X, Config.iClickPos_Y));
            }
            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> successfully select tab page <" + sTabName + ">.");
        }


        public string _TBL_Table(string sDesp, Object obj, int iRow, int iCol, string sData, int iTimeout, Boolean bClick, Boolean bSetData, Boolean bVerify, Boolean bReturn)
        {
            string sFunctionName = "_TBL_Table";
            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to interact on table <" + sDesp
                + "> at Row <" + iRow + ">, Col <" + iCol + "> using Data <" + sData + ">");



            if (iTimeout == 0)
                iTimeout = Config.iTimeout;

            int iTotalRow, iTotalCol;
            string sActContent = "";
            string objType = ((UITestControl)obj).ControlType.ToString();

            if (this._Exists(sDesp, obj, iTimeout))
            {
                UITestControlCollection uicRows;
                UITestControlCollection uicCells;
                WinRow objRow;
                WinCell objCell;

                if (objType != "Table")
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because object <" + sDesp + "> is NOT a WinTable.");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because object <" + sDesp + "> is NOT a WinTable.");
                }

                uicRows = ((WinTable)obj).Rows;
                iTotalRow = uicRows.Count;

                if (iRow > iTotalRow)
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because input Row index <" + iRow
                        + "> exceeds maximum table maximum Row number <" + iTotalRow + ">");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because input Row index <" + iRow
                        + "> exceeds maximum table maximum Row number <" + iTotalRow + ">");
                }
                else
                {
                    objRow = (WinRow)uicRows[iRow - 1];
                    uicCells = objRow.Cells;

                    iTotalCol = uicCells.Count;

                    if (iCol > iTotalCol)
                    {
                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because input Col index <" + iCol
                            + "> exceeds maximum table maximum Col number <" + iTotalCol + ">");
                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because input Col index <" + iCol
                            + "> exceeds maximum table maximum Col number <" + iTotalCol + ">");
                    }
                    else
                    {
                        objCell = (WinCell)uicCells[iCol - 1];



                        if (bClick)
                            this._SetSyncUDWin("Cell<" + iRow + "," + iCol + ">", objCell, "Click", 0);
                        if (bSetData)
                        {
                            objCell.SetFocus();

                            try
                            {
                                if (sData.ToUpper() == "TRUE")
                                {
                                    ////Keyboard.SendKeys("{Space}");
                                    ////objCell.Checked = true;
                                    string sCurrent = objCell.FriendlyName;
                                    if (sCurrent.ToUpper() != sData.ToUpper())
                                        Mouse.Click(objCell);
                                    objCell.Checked = true;
                                }
                                else if (sData.ToUpper() == "FALSE")
                                {
                                    ////Keyboard.SendKeys("{Space}");
                                    ////objCell.Checked = false;
                                    string sCurrent = objCell.FriendlyName;
                                    if (sCurrent.ToUpper() != sData.ToUpper())
                                        Mouse.Click(objCell);
                                    objCell.Checked = false;
                                }
                                else
                                {
                                    objCell.Value = sData;
                                    Keyboard.SendKeys("{Enter}");
                                }
                            }
                            catch (Exception ex)
                            {
                                this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> Failed because of Exception thrown: " + Environment.NewLine + ex.Message);
                                this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> Failed because of Exception thrown: " + Environment.NewLine + ex.Message);
                            }

                        }

                        objCell.SetFocus();
                        sActContent = objCell.FriendlyName;

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

            }

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> finished interacting on table <" + sDesp
                + "> at Row <" + iRow + ">, Col <" + iCol + "> using Data <" + sData + ">");

            return sActContent;

        }


        public int _TBL_ReturnIndex_Row(string sDesp, Object obj, string sRow, int iCol, int iTimeout, Boolean bReverseSearch)
        {
            string sFunctionName = "_TBL_ReturnIndex_Row";
            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to return Row index on table <" + sDesp
                + "> at Row <" + sRow + ">, Col <" + iCol + ">");

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;
            int iTotalRow;
            int iRow = 0;
            string objType = ((UITestControl)obj).ControlType.ToString();

            if (this._Exists(sDesp, obj, iTimeout))
            {
                UITestControlCollection uicRows;
                UITestControlCollection uicCells;
                WinRow objRow;
                WinCell objCell;
                Boolean bFindCell = false;


                if (objType != "Table")
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because object <" + sDesp + "> is NOT a WinTable.");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because object <" + sDesp + "> is NOT a WinTable.");
                }

                uicRows = ((WinTable)obj).Rows;
                iTotalRow = uicRows.Count;

                string sAct = "";

                if (bReverseSearch)
                {
                    for (int i = iTotalRow - 1; i >= 0; i--)
                    {
                        objRow = (WinRow)uicRows[i];
                        uicCells = objRow.Cells;
                        objCell = (WinCell)uicCells[iCol - 1];
                        sAct = objCell.FriendlyName;

                        if (sRow == sAct)
                        {
                            bFindCell = true;
                            iRow = i + 1;
                            break;
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < iTotalRow; i++)
                    {
                        objRow = (WinRow)uicRows[i];
                        uicCells = objRow.Cells;
                        objCell = (WinCell)uicCells[iCol - 1];
                        sAct = objCell.FriendlyName;

                        if (sRow == sAct)
                        {
                            bFindCell = true;
                            iRow = i + 1;
                            break;
                        }

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

            }

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> finished interacting on table <" + sDesp
                + "> at Row <" + sRow + ">, Col <" + iCol + ">");

            return iRow;

        }


        public int _TBL_ReturnTotalNumer_Row(string sDesp, Object obj, int iTimeout)
        {
            string sFunctionName = "_TBL_ReturnTotalNumer_Row";
            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to return Total Row Number on table <" + sDesp + ">");

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;
            string objType = ((UITestControl)obj).ControlType.ToString();

            int iTotalRow = 0;

            if (this._Exists(sDesp, obj, iTimeout))
            {
                UITestControlCollection uicRows;
                UITestControlCollection uicCells;
                WinRow objRow;
                WinCell objCell;
                Boolean bFindCell = false;


                if (objType != "Table")
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because object <" + sDesp + "> is NOT a WinTable.");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because object <" + sDesp + "> is NOT a WinTable.");
                }

                uicRows = ((WinTable)obj).Rows;

                iTotalRow = uicRows.Count;
            }

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> successfully return Total Row Number <" + iTotalRow + "> on table <" + sDesp + ">");

            return iTotalRow;
        }

        public int _TBL_ReturnTotalNumber_Col(string sDesp, Object obj, int iTimeout)
        {
            string sFunctionName = "_TBL_ReturnTotalNumber_Col";
            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to return Total Column Number on table <" + sDesp + ">");

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;
            string objType = ((UITestControl)obj).ControlType.ToString();

            int iTotalRow = 0;
            int iTotalCol = 0;

            if (this._Exists(sDesp, obj, iTimeout))
            {
                UITestControlCollection uicRows;
                UITestControlCollection uicCells;
                WinRow objRow;
                WinCell objCell;
                Boolean bFindCell = false;


                if (objType != "Table")
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because object <" + sDesp + "> is NOT a WinTable.");
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because object <" + sDesp + "> is NOT a WinTable.");
                }

                uicCells = ((WinTable)obj).Cells;
                uicRows = ((WinTable)obj).Rows;

                iTotalRow = uicRows.Count;
                iTotalCol = uicCells.Count / iTotalRow;
            }

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> successfully return Total Column Number <" + iTotalCol + "> on table <" + sDesp + ">");

            return iTotalCol;
        }

        public void _TreeViewRightSelectWin(int iSearchTimeout, Object objParent, MyDictionary dic)
        {

            this._TreeViewRightSelectWin(iSearchTimeout, objParent, dic, true);

            ////string sFunctionName = "_TreeViewRightSelectWin";
            ////string sFullTreeItemPath = "";

            ////if (iSearchTimeout == 0)
            ////    iSearchTimeout = _Config.iTimeout;

            ////this._SearchTimeout_SetNew(iSearchTimeout);

            ////int iNum = dic.Count;

            ////for (int i = 1; i <= iNum; i++)
            ////    sFullTreeItemPath = sFullTreeItemPath + dic["Level_" + i.ToString()] + "->";

            ////this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> is going to select tree item <" + sFullTreeItemPath + "> with context menu item <" + dic["MenuItem"] + ">");



            ////WinTreeItem wTvi = new WinTreeItem((UITestControl)objParent);

            ////if (this._Exists("TreeViewParent", objParent, iSearchTimeout))
            ////{
            ////    for (int i = 1; i < iNum; i++)
            ////    {
            ////        wTvi.SearchProperties["Value"] = (i - 1).ToString();
            ////        //wTvi.SearchProperties["Value"] = "0";
            ////        wTvi.SearchProperties.Add(WinTreeItem.PropertyNames.Name, dic["Level_" + i.ToString()]);
            ////        wTvi.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);

            ////        if (i > 1) wTvi.SearchConfigurations.Add(SearchConfiguration.NextSibling);

            ////        if (this._Exists(dic["Level_" + i.ToString()], wTvi, iSearchTimeout))
            ////        {
            ////            wTvi.SetFocus();
            ////            //Mouse.Click(wTvi, new Point(_Config.iClickPos_X, _Config.iClickPos_Y));
            ////            wTvi = new WinTreeItem((UITestControl)wTvi);
            ////        }
            ////    }

            ////    Mouse.Click(wTvi, MouseButtons.Right, ModifierKeys.None, new Point(_Config.iClickPos_X, _Config.iClickPos_Y));

            ////    WinWindow wWin = new WinWindow();
            ////    wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "Context");
            ////    wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "#32768");
            ////    wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            ////    wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

            ////    if(this._Exists("Context Menu Parent Win", wWin, 0))
            ////    {
            ////        WinMenu objMenu = new WinMenu(wWin);
            ////        objMenu.SearchProperties.Add(WinMenu.PropertyNames.Name, "Context");
            ////        //wWin.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
            ////        objMenu.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            ////        objMenu.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

            ////        if (this._Exists("Menu", objMenu, 0))
            ////        {
            ////            WinMenuItem mi = new WinMenuItem((WinMenu)objMenu);
            ////            mi.SearchProperties.Add(WinMenuItem.PropertyNames.Name, dic["MenuItem"]);
            ////            this._SetSyncUDWin("MenuItem: " + dic["MenuItem"], mi, "Click", 0);
            ////        }
            ////        else
            ////        {
            ////            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because context menu does NOT exist");
            ////            this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because context menu does NOT exist");
            ////        }
            ////    }



            ////}


            ////this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> End selecting tree item <" + sFullTreeItemPath + "> with context menu item <" + dic["MenuItem"] + ">");


        }




        /// <summary>
        /// 2013-May-29 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "Assumptions");
        ///    dic.Add("Level_2", "Interest Rate");
        ///    dic.Add("MenuItem", "Add New Liability Type/Projection Folder");
        ///    _gLib._TreeViewRightSelectWin(0, this.wRetirementStudio.tvNaviTree, dic, false);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewRightSelectWin(int iSearchTimeout, Object objParent, MyDictionary dic, Boolean bContextTrue_DropDownFalse)
        {
            //////if (this._Exists("TreeViewParent", objParent, iSearchTimeout))
            //////{
            //////    for (int i = 1; i <= iNum; i++)
            //////    {
            //////        wTvi.SearchProperties.Add(WinTreeItem.PropertyNames.MaxDepth, (i - 1).ToString());
            //////        wTvi.SearchProperties.Add(WinTreeItem.PropertyNames.Name, dic["Level_" + i.ToString()]);
            //////        wTvi.SearchProperties["Value"] = (i - 1).ToString();
            //////        wTvi.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);


            //////        if (i > 1) wTvi.SearchConfigurations.Add(SearchConfiguration.NextSibling);

            //////        if (this._Exists(dic["Level_" + i.ToString()], wTvi, iSearchTimeout, iSearchTimeout, false))
            //////        {

            //////            if (i == iNum)
            //////            {
            //////                wTvi.SetFocus();
            //////                //////Mouse.Click(wTvi, new Point(Config.iClickPos_X, Config.iClickPos_Y));
            //////                this._SetSyncUDWin(dic["Level_" + i.ToString()], wTvi, "Click", 0, false, Config.iClickPos_X, Config.iClickPos_Y);
            //////            }

            //////            wTvi = new WinTreeItem((UITestControl)wTvi);
            //////        }
            //////    }
            //////}

            string sFunctionName = "_TreeViewRightSelectWin";
            string sFullTreeItemPath = "";

            if (iSearchTimeout == 0)
                iSearchTimeout = Config.iTimeout;

            this._SearchTimeout_SetNew(iSearchTimeout);

            int iNum = dic.Count;

            for (int i = 1; i <= iNum; i++)
                sFullTreeItemPath = sFullTreeItemPath + dic["Level_" + i.ToString()] + "->";

            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> is going to select tree item <" + sFullTreeItemPath + "> with context menu item <" + dic["MenuItem"] + ">");

            WinTreeItem wTvi = new WinTreeItem((UITestControl)objParent);

            if (this._Exists("TreeViewParent", objParent, iSearchTimeout))
            {
                for (int i = 1; i < iNum; i++)
                {
                    wTvi.SearchProperties.Add(WinTreeItem.PropertyNames.MaxDepth, (i - 1).ToString());
                    wTvi.SearchProperties.Add(WinTreeItem.PropertyNames.Name, dic["Level_" + i.ToString()]);
                    wTvi.SearchProperties["Value"] = (i - 1).ToString();
                    wTvi.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);


                    if (i > 1) wTvi.SearchConfigurations.Add(SearchConfiguration.NextSibling);

                    if (this._Exists(dic["Level_" + i.ToString()], wTvi, iSearchTimeout, iSearchTimeout, true))
                    {
                        if (i == iNum - 2) // only focus on last item to increase performance
                        {
                            wTvi.SetFocus();
                            //Mouse.Click(wTvi, new Point(_Config.iClickPos_X, _Config.iClickPos_Y));
                        }

                        wTvi = new WinTreeItem((UITestControl)wTvi);
                    }
                }

                try
                {
                    Mouse.Click(wTvi, MouseButtons.Right, ModifierKeys.None, new Point(Config.iClickPos_X, Config.iClickPos_Y));
                }
                catch (Exception ex)
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to Right click on TreeView item <" + dic["Level_" + (iNum - 1).ToString()] + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right click on TreeView item <" + dic["Level_" + (iNum - 1).ToString()] + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                }

                if (bContextTrue_DropDownFalse)
                {
                    WinWindow wWin = new WinWindow();
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "Context");
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "#32768");
                    wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);


                    WinMenu objMenu = new WinMenu(wWin);
                    objMenu.SearchProperties.Add(WinMenu.PropertyNames.Name, "Context");
                    //wWin.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    objMenu.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    objMenu.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);


                    if (this._Exists("Context Menu Parent Win", wWin, 3, Config.iSearchInterval, false) && this._Exists("Menu", objMenu, 3, 1, false))
                    {
                        WinMenuItem mi = new WinMenuItem((WinMenu)objMenu);
                        mi.SearchProperties.Add(WinMenuItem.PropertyNames.Name, dic["MenuItem"]);
                        this._SetSyncUDWin("MenuItem: " + dic["MenuItem"], mi, "Click", 0);

                    }
                    else ////// do right-click again if the context menu does not exist
                    {
                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because context menu does NOT exist");
                        //this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because context menu does NOT exist");

                        try
                        {
                            Mouse.Click(wTvi, MouseButtons.Right, ModifierKeys.None, new Point(Config.iClickPos_X, Config.iClickPos_Y));
                        }
                        catch (Exception ex)
                        {
                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to Right click on TreeView item <" + dic["Level_" + (iNum - 1).ToString()] + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                            this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right click on TreeView item <" + dic["Level_" + (iNum - 1).ToString()] + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                        }
                        if (this._Exists("Context Menu Parent Win", wWin, 3, Config.iSearchInterval, false) && this._Exists("Menu", objMenu, 3, 1, false))
                        {
                            WinMenuItem mi = new WinMenuItem((WinMenu)objMenu);
                            mi.SearchProperties.Add(WinMenuItem.PropertyNames.Name, dic["MenuItem"]);
                            this._SetSyncUDWin("MenuItem: " + dic["MenuItem"], mi, "Click", 0);

                        }
                        else
                        {
                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> failed because context menu does NOT exist");
                            this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> failed because context menu does NOT exist");
                        }

                    }

                }
                else
                {
                    WinWindow wWin = new WinWindow();
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "DropDown");
                    wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains);
                    wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

                    if (this._Exists("DropDown Menu Parent Win", wWin, 0))
                    {
                        MyDictionary dicTmp = new MyDictionary();
                        dicTmp.Clear();
                        dicTmp.Add("Level_1", dic["MenuItem"]);
                        this._MenuSelectWin(0, wWin, dicTmp);

                    }

                }


            }


            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> End selecting tree item <" + sFullTreeItemPath + "> with context menu item <" + dic["MenuItem"] + ">");


        }


        public void _TreeViewCheckBoxSelectWin(int iSearchTimeout, Object objParent, MyDictionary dic, Boolean bChecked)
        {
            string sFunctionName = "_TreeViewSelectWin";
            string sFullTreeItemPath = "";

            if (iSearchTimeout == 0)
                iSearchTimeout = Config.iTimeout;

            this._SearchTimeout_SetNew(iSearchTimeout);

            int iNum = dic.Count;

            for (int i = 1; i <= iNum; i++)
                sFullTreeItemPath = sFullTreeItemPath + dic["Level_" + i.ToString()] + "->";

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to select tree item <" + sFullTreeItemPath + ">.");



            WinCheckBoxTreeItem wTvi = new WinCheckBoxTreeItem((UITestControl)objParent);

            if (this._Exists("TreeViewParent", objParent, iSearchTimeout))
            {
                for (int i = 1; i <= iNum; i++)
                {
                    wTvi.SearchProperties["Value"] = (i - 1).ToString();
                    //wTvi.SearchProperties["Value"] = "0";
                    wTvi.SearchProperties.Add(WinCheckBoxTreeItem.PropertyNames.Name, dic["Level_" + i.ToString()]);
                    wTvi.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);

                    if (i > 1) wTvi.SearchConfigurations.Add(SearchConfiguration.NextSibling);

                    if (this._Exists(dic["Level_" + i.ToString()], wTvi, iSearchTimeout, iSearchTimeout / 3, true))
                    {
                        //wTvi.SetFocus();
                        if (i == iNum)
                        {
                            try
                            {
                                wTvi.Checked = bChecked;
                            }
                            catch (Exception ex)
                            {
                                this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to check on CheckBox <" + dic["Level_" + i.ToString()] + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                                this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to check on CheckBox <" + dic["Level_" + i.ToString()] + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                            }

                        }
                        wTvi = new WinCheckBoxTreeItem((UITestControl)wTvi);
                    }
                }
            }

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> successfully select tree item <" + sFullTreeItemPath + ">.");


        }


        public void _MenuSelectWin(int iSearchTimeout, Object objParent, MyDictionary dic)
        {
            string sFunctionName = "_MenuSelectWin";
            string sFullMenuItemPath = "";

            if (iSearchTimeout == 0)
                iSearchTimeout = Config.iTimeout;

            this._SearchTimeout_SetNew(iSearchTimeout);

            int iNum = dic.Count;

            for (int i = 1; i <= iNum; i++)
                sFullMenuItemPath = sFullMenuItemPath + dic["Level_" + i.ToString()] + "->";

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> is going to select tree item <" + sFullMenuItemPath + ">.");



            WinMenuItem mi = new WinMenuItem((UITestControl)objParent);

            if (this._Exists("Menu Parent", objParent, iSearchTimeout))
            {
                for (int i = 1; i <= iNum; i++)
                {

                    mi.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    mi.SearchProperties.Add(WinMenuItem.PropertyNames.Name, dic["Level_" + i.ToString()]);

                    if (this._Exists(dic["Level_" + i.ToString()], mi, iSearchTimeout, iSearchTimeout / 3, true))
                    {
                        if (i == iNum)
                            this._SetSyncUDWin(dic["Level_" + i.ToString()], mi, "Click", 0, false, Config.iClickPos_X, Config.iClickPos_Y);
                        //////Mouse.Click(mi, new Point(Config.iClickPos_X, Config.iClickPos_Y));

                        mi = new WinMenuItem((UITestControl)mi);
                    }

                }
            }

            this._Report(_PassFailStep.Step, "\t\t\tFunction <" + sFunctionName + "> successfully select Menu item <" + sFullMenuItemPath + ">.");


        }


        public void _SetSyncUDWin_ByClipboard(string sDesp, WinEdit obj, string sVal, int iTimeout)
        {
            this._SetSyncUDWin_ByClipboard(sDesp, obj, sVal, 0, true, false);
        }

        public void _SetSyncUDWin_ByClipboard(string sDesp, WinEdit obj, string sVal, Boolean bTrickyVerify, int iTimeout)
        {
            this._SetSyncUDWin_ByClipboard(sDesp, obj, sVal, 0, true, true);
        }

        public void _SetSyncUDWin_ByClipboard(string sDesp, WinEdit obj, string sVal, int iTimeout, Boolean bVerify, bool bTrickyVerify)
        {
            string sFunctionName = "_SetSyncUDWin_ByClipboard";

            /// if nothing set to this object, exit function
            if (sVal == "")
                return;

            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> is going to set <" + sVal + "> to object <" + sDesp + ">.");

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;

            if (this._Exists(sDesp, obj, iTimeout, Config.iSearchInterval, true))
            {
                if (this._Enabled(sDesp, obj, iTimeout))
                {
                    //Keyboard.SendKeys(obj, "{Delete}{Back}");

                    Clipboard.Clear();
                    Clipboard.SetText(sVal);

                    if (sVal.Equals("#Clear#"))
                        bVerify = false;

                    //obj.GetParent().SetFocus();

                    try
                    {
                        obj.SetFocus();
                        ////Keyboard.SendKeys(obj, "{Home}", ModifierKeys.None);
                        //////////Keyboard.SendKeys(obj, "{Home}", ModifierKeys.Shift);
                        //////////Keyboard.SendKeys(obj, "{End}", ModifierKeys.Shift);
                        ////Keyboard.SendKeys(obj, "{End}", ModifierKeys.Shift);
                        if (sVal.Equals("#Clear#"))
                        {
                            Keyboard.SendKeys(obj, "{Delete}{Delete}{Delete}{Backspace}{Backspace}{Backspace}", ModifierKeys.None);
                        }
                        else
                            Keyboard.SendKeys(obj, "v", ModifierKeys.Control);

                    }
                    catch (Exception ex)
                    {
                        this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + sVal + "> to object <" + sDesp + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                        this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to set <" + sVal + "> to object <" + sDesp + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    }

                    if (bVerify && bTrickyVerify)
                    {
                        //////////////Keyboard.SendKeys(obj, "{Tab}");
                        this._SendKeysUDWin(sDesp, obj, "{Tab}");
                    }

                    if (bVerify)
                    {

                        try
                        {
                            string sActVal = obj.Text;

                            if (sActVal.Trim() == sVal)
                            {
                                this._Report(_PassFailStep.Pass, "\t\tFunction <" + sFunctionName + "> successfully set <" + sVal + "> to object <" + sDesp + ">.");
                            }
                            else
                            {
                                this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to set <" + sVal + "> to object <" + sDesp + ">. Actual Value: <" + sActVal.Trim() + "> ");
                                this._MsgBoxYesNo("Continue Testing?", "Fail: Verify Object: <" + sDesp + "> with expected value: <" + sVal + ">. Actual Value: <" + sActVal.Trim() + "> ");
                            }
                        }

                        catch (Exception ex)
                        {
                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to verify <" + sVal + "> from object <" + sDesp + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                            this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to verify <" + sVal + "> from object <" + sDesp + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                        }
                    }


                }


            }

        }

        public void _SendKeysUDWin(string sDesp, object obj, string sVal, int iTimeout, ModifierKeys modifierKeys, Boolean bVerify)
        {
            string sFunctionName = "_SendKeysUDWin";

            /// if nothing set to this object, exit function
            if (sVal == "")
                return;
            string objType = ((UITestControl)obj).ControlType.ToString();
            string sActVal = "";

            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> is going to send Keys <" + sVal + "> to object <" + objType + ": " + sDesp + ">.");

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;




            if (this._Exists(sDesp, obj, iTimeout, Config.iSearchInterval, true) && this._Enabled(sDesp, obj, iTimeout))
            {

                try
                {
                    Keyboard.SendKeys((UITestControl)obj, sVal, modifierKeys);
                }
                catch (Exception ex)
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to send Keys <" + sVal + "> to object <" + objType + ": " + sDesp + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to send Keys <" + sVal + "> to object <" + objType + ": " + sDesp + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                }


                if (bVerify)
                {
                    switch (objType)
                    {
                        case "Edit":
                        case "ComboBox":
                            {
                                this._VerifySyncUDWin(sDesp, obj, sVal, iTimeout);
                                break;
                            }
                        default:

                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> NOT able to Verify text property on object type <" + objType + ">.");
                            this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> NOT able to Verify text property on object type <" + objType + ">.");
                            break;
                    }
                }


            }


            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> finish send Keys <" + sVal + "> to object <" + objType + ": " + sDesp + ">.");

        }


        public void _SendKeysUDWin(string sDesp, object obj, string sVal, Boolean bVerify)
        {
            this._SendKeysUDWin(sDesp, obj, sVal, 0, ModifierKeys.None, bVerify);
        }

        public void _SendKeysUDWin(string sDesp, object obj, string sVal)
        {
            this._SendKeysUDWin(sDesp, obj, sVal, 0, ModifierKeys.None, false);
        }

        public void _SendKeysUDWin(string sDesp, object obj, string sVal, int iTimeout)
        {
            this._SendKeysUDWin(sDesp, obj, sVal, iTimeout, ModifierKeys.None, false);
        }


        public void _SendKeysUDWin_byPaste(string sDesp, object obj, string sVal, int iTimeout, Boolean bVerify)
        {
            string sFunctionName = "_SendKeysUDWin_byPaste";

            /// if nothing set to this object, exit function
            if (sVal == "")
                return;
            string objType = ((UITestControl)obj).ControlType.ToString();
            string sActVal = "";

            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> is going to send Keys <" + sVal + "> to object <" + objType + ": " + sDesp + ">.");

            if (iTimeout == 0)
                iTimeout = Config.iTimeout;




            if (this._Exists(sDesp, obj, iTimeout, Config.iSearchInterval, true) && this._Enabled(sDesp, obj, iTimeout))
            {
                Clipboard.Clear();
                Clipboard.SetText(sVal);
                try
                {
                    Keyboard.SendKeys((UITestControl)obj, "v", ModifierKeys.Control);
                }
                catch (Exception ex)
                {
                    this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to send Keys <" + sVal + "> to object <" + objType + ": " + sDesp + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to send Keys <" + sVal + "> to object <" + objType + ": " + sDesp + ">. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                }


                if (bVerify)
                {
                    switch (objType)
                    {
                        case "Edit":
                        case "ComboBox":
                            {
                                this._VerifySyncUDWin(sDesp, obj, sVal, iTimeout);
                                break;
                            }
                        default:

                            this._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> NOT able to Verify text property on object type <" + objType + ">.");
                            this._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> NOT able to Verify text property on object type <" + objType + ">.");
                            break;
                    }
                }


            }


            this._Report(_PassFailStep.Step, "\t\tFunction <" + sFunctionName + "> finish send Keys <" + sVal + "> to object <" + objType + ": " + sDesp + ">.");

        }






    }




}
