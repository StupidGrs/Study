namespace RetirementStudio._UIMaps.IndividualOuputFieldDefinitionClasses
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
    
    public partial class IndividualOuputFieldDefinition
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2013-May-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AddRow", "Click");
        ///    dic.Add("RemoveRow", "");
        ///    dic.Add("OK", "");
        ///    dic.Add("Cancel", "");
        ///    pIndividualOuputFieldDefinition._PopVerify_IndividualOuputFieldDefinition(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_IndividualOuputFieldDefinition(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_IndividualOuputFieldDefinition";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("AddRow", this.wIndividualOutputFieldDefinition.wAddRow.btn, dic["AddRow"], 0);
                _gLib._SetSyncUDWin("RemoveRow", this.wIndividualOutputFieldDefinition.wRemoveRow.btn, dic["RemoveRow"], 0);
                _gLib._SetSyncUDWin("OK", this.wIndividualOutputFieldDefinition.wOK.btn, dic["OK"], 0);
                _gLib._SetSyncUDWin("Cancel", this.wIndividualOutputFieldDefinition.wCancel.btn, dic["Cancel"], 0);

            }
            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("AddRow", this.wIndividualOutputFieldDefinition.wAddRow.btn, dic["AddRow"], 0);
                _gLib._VerifySyncUDWin("RemoveRow", this.wIndividualOutputFieldDefinition.wRemoveRow.btn, dic["RemoveRow"], 0);
                _gLib._VerifySyncUDWin("OK", this.wIndividualOutputFieldDefinition.wOK.btn, dic["OK"], 0);
                _gLib._VerifySyncUDWin("Cancel", this.wIndividualOutputFieldDefinition.wCancel.btn, dic["Cancel"], 0);
            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-May-21 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("VOShortName", "Pen1");
        ///    dic.Add("OutputLabel", "AccruedBenefit");
        ///    dic.Add("Index_V", "Click");
        ///    dic.Add("Index", "$ValAge");
        ///    dic.Add("Index_C", "");
        ///    dic.Add("Index_txt", "");
        ///    pIndividualOuputFieldDefinition._Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _Table(MyDictionary dic)
        {
            string sFunctionName = "_Table";
            _gLib._Report(_PassFailStep.Step, "Funcon <" + sFunctionName + "> Starts:");

            int iRow = Convert.ToInt32(dic["iRow"]);

            int iPos_Y = iRow * 20 + 10;

            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("FP Grid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, "Click", 0, false, 11, iPos_Y);

                if (dic["VOShortName"]!="")
                {
                    string sChar = dic["VOShortName"].Substring(0, 1);
                    _gLib._SendKeysUDWin("FPGrid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, sChar);
                    
                    ////////////_gLib._SetSyncUDWin("FP Grid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, "Click", 0, false, 30, iPos_Y);
                    if(!_gLib._Exists("VOShortName_cbo", this.wIndividualOutputFieldDefinition.wCommon_cbo.cbo, 1, false))
                        _gLib._SetSyncUDWin("FP Grid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, "Click", 0, false, 30, iPos_Y);

                    _gLib._SetSyncUDWin("VOShortName", this.wIndividualOutputFieldDefinition.wCommon_cbo.cbo, dic["VOShortName"], 0);
                    ////_gLib._SetSyncUDWin("VOShortName", this.wIndividualOutputFieldDefinition.wCommon_cbo.cbo, dic["VOShortName"], 0);
 
                }
                _gLib._SetSyncUDWin("FP Grid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, "Click", 0, false, 11, iPos_Y);
                if (dic["OutputLabel"] != "")
                {
                    string sChar = dic["OutputLabel"].Substring(0, 1);
                    if (dic["VOShortName"] != "")
                        _gLib._SendKeysUDWin("FPGrid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, "{Tab}");

                    _gLib._SendKeysUDWin("FPGrid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, sChar);

                    //////////_gLib._SetSyncUDWin("FP Grid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, "Click", 0, false, 320, iPos_Y);
                    if (!_gLib._Exists("OutputLabel", this.wIndividualOutputFieldDefinition.wCommon_cbo.cbo, 1, false))
                        _gLib._SetSyncUDWin("FP Grid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, "Click", 0, false, 320, iPos_Y);

                    _gLib._SetSyncUDWin("OutputLabel", this.wIndividualOutputFieldDefinition.wCommon_cbo.cbo, dic["OutputLabel"], 0);
                    ////_gLib._SetSyncUDWin("OutputLabel", this.wIndividualOutputFieldDefinition.wCommon_cbo.cbo, dic["OutputLabel"], 0);

                }
                _gLib._SetSyncUDWin("FP Grid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, "Click", 0, false, 11, iPos_Y);
                if (dic["Index"] != "" || dic["Index_txt"] != "")
                {
                    string sChar = dic["OutputLabel"].Substring(0, 1);
                    if (dic["VOShortName"] != "")
                        _gLib._SendKeysUDWin("FPGrid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, "{Tab}{Tab}");
                    else
                        _gLib._SendKeysUDWin("FPGrid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, "{Tab}");

                    _gLib._SendKeysUDWin("FPGrid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, sChar);

                    ////////_gLib._SetSyncUDWin("FP Grid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, "Click", 0, false, 600, iPos_Y);
                    if (!_gLib._Exists("Index", this.wIndividualOutputFieldDefinition.wIndex_V.btn, 1, false))
                        _gLib._SetSyncUDWin("FP Grid", this.wIndividualOutputFieldDefinition.wOutputFields_FPGrid.grid, "Click", 0, false, 600, iPos_Y);

                    if (dic["Index"] != "")
                    { 
                        _gLib._SetSyncUDWin("Index_V", this.wIndividualOutputFieldDefinition.wIndex_V.btn, dic["Index_V"], 0);
                        _gLib._SetSyncUDWin("Index", this.wIndividualOutputFieldDefinition.wIndex.cbo, dic["Index"], 0);
                    }
                    if (dic["Index_txt"] != "")
                    { 
                        _gLib._SetSyncUDWin("Index_C", this.wIndividualOutputFieldDefinition.wIndex_C.btn, dic["Index_C"], 0);
                        _gLib._SetSyncUDWin_ByClipboard("Index_txt", this.wIndividualOutputFieldDefinition.wIndex_txt.txt, dic["Index_txt"], 0);
                    }


                }


            }



            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
