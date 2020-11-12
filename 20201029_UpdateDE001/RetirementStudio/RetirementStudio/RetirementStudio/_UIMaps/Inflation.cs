namespace RetirementStudio._UIMaps.InflationClasses
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
    
    
    public partial class Inflation
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2013-May-12
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("CPIRate_V", "");
        ///    dic.Add("CPIRate_P", "Click");
        ///    dic.Add("CPIRate_T", "");
        ///    dic.Add("CPIRate_cbo_V", "");
        ///    dic.Add("CPIRate_txt", "1.0");
        ///    dic.Add("CPIRate_cbo_T", "");
        ///    dic.Add("RPIRate_V", "");
        ///    dic.Add("RPIRate_P", "Click");
        ///    dic.Add("RPIRate_T", "");
        ///    dic.Add("RPIRate_cbo_V", "");
        ///    dic.Add("RPIRate_txt", "1.5");
        ///    dic.Add("RPIRate_cbo_T", "");
        ///    pInflation._PopVerify_SameStructureForAll(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_SameStructureForAll(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_SameStructureForAll";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            if (dic["PopVerify"] == "Pop")
            {

                _gLib._SetSyncUDWin("SameStructureForAllPeriods", this.wRetirementStudio.wSameStructureForAll.rd, "True", 0);

                _gLib._SetSyncUDWin("CPIRate_V", this.wRetirementStudio.wCPIRate_V.btn, dic["CPIRate_V"], 0);
                _gLib._SetSyncUDWin("CPIRate_P", this.wRetirementStudio.wCPIRate_P.btn, dic["CPIRate_P"], 0);
                _gLib._SetSyncUDWin("CPIRate_T", this.wRetirementStudio.wCPIRate_T.btn, dic["CPIRate_T"], 0);
                _gLib._SetSyncUDWin("RPIRate_V", this.wRetirementStudio.wRPIRate_V.btn, dic["RPIRate_V"], 0);
                _gLib._SetSyncUDWin("RPIRate_P", this.wRetirementStudio.wRPIRate_P.btn, dic["RPIRate_P"], 0);
                _gLib._SetSyncUDWin("RPIRate_T", this.wRetirementStudio.wRPIRate_T.btn, dic["RPIRate_T"], 0);

                _gLib._SetSyncUDWin("CPIRate_cbo_V", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["CPIRate_cbo_V"], 0);
                if (dic["CPIRate_txt"] != "")
                {
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wCPIRate_V.btn, "{Tab}", 0, ModifierKeys.Shift, false);
                    _gLib._SetSyncUDWin_ByClipboard("CPIRate_txt", this.wRetirementStudio.wCommon_txt.txt, dic["CPIRate_txt"], 0);
                }
                _gLib._SetSyncUDWin("CPIRate_cbo_T", this.wRetirementStudio.wCommon_cbo_T.cbo, dic["CPIRate_cbo_T"], 0);


                if (dic["CPIRate_V"] != "")
                    this.wRetirementStudio.wCommon_cbo_V.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                if (dic["CPIRate_P"] != "")
                    this.wRetirementStudio.wCommon_txt.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");
                if (dic["CPIRate_T"] != "")
                    this.wRetirementStudio.wCommon_cbo_T.SearchProperties.Add(WinWindow.PropertyNames.Instance, "2");

                _gLib._SetSyncUDWin("RPIRate_cbo_V", this.wRetirementStudio.wCommon_cbo_V.cbo, dic["RPIRate_cbo_V"], 0);
                if (dic["RPIRate_txt"] != "")
                    _gLib._SendKeysUDWin("", this.wRetirementStudio.wRPIRate_V.btn, "{Tab}", 0, ModifierKeys.Shift, false);
                _gLib._SetSyncUDWin_ByClipboard("RPIRate_txt", this.wRetirementStudio.wCommon_txt.txt, dic["RPIRate_txt"], 0);
                _gLib._SetSyncUDWin("RPIRate_cbo_T", this.wRetirementStudio.wCommon_cbo_T.cbo, dic["RPIRate_cbo_T"], 0);

            }


            if (dic["PopVerify"] == "Verify")
            {

                _gLib._MsgBox("Warning!", "No Verify!");

            }


            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2016-Jan-29
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("AddRow", "click");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("NumberOfYears", "10");
        ///    dic.Add("Rate", "4.75");
        ///    pInflation._CPI_TimeBased_Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _CPI_TimeBased_Table(MyDictionary dic)
        {
            string sFunctionName = "_CPI_TimeBased_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._SetSyncUDWin("AddRow", this.wRetirementStudio.wCPI_AddRow.btn, dic["AddRow"], 0);

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCPI_grid.grid, "Click", 0, false, 94, 28);
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wCPI_grid.grid, "Click", 0, false, 94, 28);


            int iRow = Convert.ToInt32(dic["iRow"]);
            string sRow = "";
            for (int i = 1; i < iRow; i++)
                sRow = sRow + "{Down}";
        
            
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCPI_grid.grid, "{PageUp}{PageUp}{Home}" + sRow );

         
            if (dic["NumberOfYears"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCPI_grid.grid, "{space}");
                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": NumberOfYears", this.wRetirementStudio.wCom_txt.txt.UICtlNumEditorEdit1, dic["NumberOfYears"], 0);
            }

            if (dic["Rate"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wCPI_grid.grid, "{Tab}{space}");
                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": Rate", this.wRetirementStudio.wCom_txt.txt.UICtlNumEditorEdit1, dic["Rate"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }




        /// <summary>
        /// 2016-Jan-29
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("AddRow", "click");
        ///    dic.Add("iRow", "1");
        ///    dic.Add("NumberOfYears", "10");
        ///    dic.Add("Rate", "4.75");
        ///    pInflation._RPI_TimeBased_Table(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _RPI_TimeBased_Table(MyDictionary dic)
        {
            string sFunctionName = "_RPI_TimeBased_Table";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._SetSyncUDWin("AddRow", this.wRetirementStudio.wRPI_AddRow.btn, dic["AddRow"], 0);

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wRPI_grid.grid, "Click", 0, false, 94, 28);
            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wRPI_grid.grid, "Click", 0, false, 94, 28);


            int iRow = Convert.ToInt32(dic["iRow"]);
            string sRow = "";
            for (int i = 1; i < iRow; i++)
                sRow = sRow + "{Down}";
        
            
            _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRPI_grid.grid, "{PageUp}{PageUp}{Home}" + sRow );

         
            if (dic["NumberOfYears"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRPI_grid.grid, "{space}");
                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": NumberOfYears", this.wRetirementStudio.wCom_txt.txt.UICtlNumEditorEdit1, dic["NumberOfYears"], 0);
            }

            if (dic["Rate"] != "")
            {
                _gLib._SendKeysUDWin("FPGrid", this.wRetirementStudio.wRPI_grid.grid, "{Tab}{space}");
                _gLib._SetSyncUDWin_ByClipboard(iRow.ToString() + ": Rate", this.wRetirementStudio.wCom_txt.txt.UICtlNumEditorEdit1, dic["Rate"], 0);

            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
