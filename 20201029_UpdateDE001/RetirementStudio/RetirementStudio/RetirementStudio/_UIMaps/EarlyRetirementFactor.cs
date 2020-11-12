namespace RetirementStudio._UIMaps.EarlyRetirementFactorClasses
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
    using System.Threading;
    using System.Diagnostics;

    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using RetirementStudio._ThridParty;
    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._UIMaps.OutputManagerClasses;
    using RetirementStudio._UIMaps.TestCaseLibraryClasses;
    
    public partial class EarlyRetirementFactor
    {
        private FarPoint _fp = new FarPoint();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();

        /// <summary>
        /// 2013-Sep-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AgeInterval", "True");
        ///    dic.Add("YearInterval", "");
        ///    dic.Add("TabularOrActuarially", "");
        ///    dic.Add("CustomCode", "");
        ///    pEarlyRetirementFactor._PopVerify_Main(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_Main(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_Main";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("AgeInterval", this.wRetirementStudio.wAgeInterval.rdAgeInterval, dic["AgeInterval"], 0);
                _gLib._SetSyncUDWin("YearInterval", this.wRetirementStudio.wYearInterval.rdYearInterval, dic["YearInterval"], 0);
                _gLib._SetSyncUDWin("TabularOrActuarially", this.wRetirementStudio.wTabularOrActuarially.rdTabularOrActuarially, dic["TabularOrActuarially"], 0);
                _gLib._SetSyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._VerifySyncUDWin("AgeInterval", this.wRetirementStudio.wAgeInterval.rdAgeInterval, dic["AgeInterval"], 0);
                _gLib._VerifySyncUDWin("YearInterval", this.wRetirementStudio.wYearInterval.rdYearInterval, dic["YearInterval"], 0);
                _gLib._VerifySyncUDWin("TabularOrActuarially", this.wRetirementStudio.wTabularOrActuarially.rdTabularOrActuarially, dic["TabularOrActuarially"], 0);
                _gLib._VerifySyncUDWin("CustomCode", this.wRetirementStudio.wCustomCode.rdCustomCode, dic["CustomCode"], 0);


            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        /// <summary>
        /// 2013-Sep-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Button_V", "Click");
        ///    dic.Add("Button_C", "");
        ///    dic.Add("AgeAtWhichReductionEnds_cbo", "UnreducedAge");
        ///    dic.Add("AgeAtWhichReductionEnds_txt", "");
        ///    pEarlyRetirementFactor._PopVerify_AgeYearInterval(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_AgeYearInterval(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_AgeYearInterval";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("Button_V", this.wRetirementStudio.wButton_V.btnV, dic["Button_V"], 0);
                _gLib._SetSyncUDWin("Button_C", this.wRetirementStudio.wButton_C.btnC, dic["Button_C"], 0);
                _gLib._SetSyncUDWin("AgeAtWhichReductionEnds_cbo", this.wRetirementStudio.wAgeAtWhichReductionEnds_cbo.cbo, dic["AgeAtWhichReductionEnds_cbo"], 0);
                _gLib._SetSyncUDWin_ByClipboard("AgeAtWhichReductionEnds_txt", this.wRetirementStudio.wAgeAtWhichReductionEnds_txt.txt, dic["AgeAtWhichReductionEnds_txt"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                
                _gLib._VerifySyncUDWin("Button_V", this.wRetirementStudio.wButton_V.btnV, dic["Button_V"], 0);
                _gLib._VerifySyncUDWin("Button_C", this.wRetirementStudio.wButton_C.btnC, dic["Button_C"], 0);
                _gLib._VerifySyncUDWin("AgeAtWhichReductionEnds_cbo", this.wRetirementStudio.wAgeAtWhichReductionEnds_cbo.cbo, dic["AgeAtWhichReductionEnds_cbo"], 0);
                _gLib._VerifySyncUDWin("AgeAtWhichReductionEnds_txt", this.wRetirementStudio.wAgeAtWhichReductionEnds_txt.txt, dic["AgeAtWhichReductionEnds_txt"], 0);


            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2013-Sep-22
        /// webber.ling@mercer.com
        /// sample:
        /// pEarlyRetirementFactor._TBL_ReductionDefinition(1, "55", "3.0" );
        /// pEarlyRetirementFactor._TBL_ReductionDefinition(1, "55", "3.0", true);
        /// 
        /// </summary>
        /// <param name="iRow"></param>
        /// <param name="sTo"></param>
        /// <param name="sReduction"></param>
        public void _TBL_ReductionDefinition(int iRow, string sTo, string sReduction, Boolean bAddRow = false, Boolean bUK = false )
        {

            string sFunctionName = "_TBL_ReductionDefinition";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if(bAddRow)
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wAddRow.btn, "click", 0);

            /// initialize by focus on first cell
            _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 270, 30);
            _gLib._SendKeysUDWin("", this.wRetirementStudio.wFPGrid.grid, "{PageUp}{PageUp}", 0);

            Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);

            string sKeys = "";

            for (int i = 1; i < iRow; i++)
            {
                if (bUK)
                    sKeys = sKeys + "{Tab}{Tab}{Tab}{Tab}";
                else
                    sKeys = sKeys + "{Tab}{Tab}";
            }


            if (sKeys != "")
                Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKeys);

            int iInstance = 1;
            if (_gLib._Exists("", this.wRetirementStudio.wAgeAtWhichReductionEnds_txt.txt, 1, false))
                iInstance = 2;
            this.wRetirementStudio.wCommonTXT_FPGrid.txt.SearchProperties.Add("Instance", iInstance.ToString());

            if (sTo != "")
            {
                _gLib._SetSyncUDWin_ByClipboard("ReductionDefinition table", this.wRetirementStudio.wCommonTXT_FPGrid.txt, sTo, 0);
                Keyboard.SendKeys(this.wRetirementStudio.wCommonTXT_FPGrid.txt, "{Tab}{Tab}{Tab}");
            }
            if (sReduction != "")
            {
                _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 10, 30);
                _gLib._SetSyncUDWin_ByClipboard("ReductionDefinition table", this.wRetirementStudio.wCommonTXT_FPGrid_Reduction.txt, sReduction, 0);
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

        public void _TBL_ReductionDefinition_YearInterval_UK(int iRow, string sTo, string sReduction, Boolean bAddRow = false)
        {

            string sFunctionName = "_TBL_ReductionDefinition";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (bAddRow)
                _gLib._SetSyncUDWin("", this.wRetirementStudio.wAddRow.btn, "click", 0);

            /// initialize by focus on first cell
            _gLib._SetSyncUDWin("Table", this.wRetirementStudio.wFPGrid.grid, "Click", 0, false, 80, 30);
            _gLib._SendKeysUDWin("", this.wRetirementStudio.wFPGrid.grid, "{PageUp}{PageUp}", 0);

            Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, "{Home}", ModifierKeys.Control);

            string sKeys = "";

            for (int i = 1; i < iRow; i++)
                sKeys = sKeys + "{Tab}{Tab}";



            if (sKeys != "")
                Keyboard.SendKeys(this.wRetirementStudio.wFPGrid.grid, sKeys);
            

            if (sTo != "")
            {
                _gLib._SetSyncUDWin_ByClipboard("ReductionDefinition table", this.wRetirementStudio.wCommonTXT_FPGrid_YearInterval_UK.txt, sTo, 0);
                Keyboard.SendKeys(this.wRetirementStudio.wCommonTXT_FPGrid_YearInterval_UK.txt, "{Tab}");
            }
            if (sReduction != "")
            {
                _gLib._SetSyncUDWin_ByClipboard("ReductionDefinition table", this.wRetirementStudio.wCommonTXT_FPGrid_Reduction.txt, sReduction, 0);
            }
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }



        //public void _TBL_ReductionDefinition(int iRow, string sTo, string sReduction)
        //{
        //    this._TBL_ReductionDefinition(iRow, sTo, sReduction, 1);
        // }


        /// <summary>
        /// 2013-Sep-22
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("AgeAtWhichReductionEnds_C", "");
        ///    dic.Add("AgeAtWhichReductionEnds_txt", "");
        ///    dic.Add("AgeAtWhichReductionEnds_V", "");
        ///    dic.Add("AgeAtWhichReductionEnds_cbo", "");
        ///    dic.Add("ReductionBasis_V", "");
        ///    dic.Add("ReductionBasis_Vcbo", "");
        ///    dic.Add("ReductionBasis_T", "");
        ///    dic.Add("ReductionBasis_Tcbo", "");
        ///    pEarlyRetirementFactor._TabularOrActuarially(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _TabularOrActuarially(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_AgeYearInterval";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("btn", this.wRetirementStudio.wButton_C.btnC, dic["AgeAtWhichReductionEnds_C"], 0);
                _gLib._SetSyncUDWin("btn", this.wRetirementStudio.wButton_V.btnV, dic["ReductionBasis_V"], 0);

                if (dic["AgeAtWhichReductionEnds_V"] != "")
                    this.wRetirementStudio.wButton_V.SearchProperties.Add(WinButton.PropertyNames.Instance, "2");
                _gLib._SetSyncUDWin("btn", this.wRetirementStudio.wButton_V.btnV, dic["AgeAtWhichReductionEnds_V"], 0);
                _gLib._SetSyncUDWin("btn", this.wRetirementStudio.wButton_T.btn, dic["ReductionBasis_T"], 0);
             

                 _gLib._SetSyncUDWin_ByClipboard("AgeAtWhichReductionEnds_txt", this.wRetirementStudio.wAgeAtWhichReductionEnds_txt.txt.UI_numEditConstantEdit1, dic["AgeAtWhichReductionEnds_txt"], 0);
                 _gLib._SetSyncUDWin("AgeAtWhichReductionEnds_cbo", this.wRetirementStudio.wCboVariableWindow.cbo, dic["AgeAtWhichReductionEnds_cbo"], 0);
                 _gLib._SetSyncUDWin("ReductionBasis_Vcbo", this.wRetirementStudio.wAgeAtWhichReductionEnds_cbo.cbo, dic["ReductionBasis_Vcbo"], 0);
                 _gLib._SetSyncUDWin("ReductionBasis_Tcbo", this.wRetirementStudio.wTableName.cbo, dic["ReductionBasis_Tcbo"], 0);

            }

            if (dic["PopVerify"] == "Verify")
            {
                _gLib._MsgBox("", "Verify is not completed");
            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


    }
}
