namespace RetirementStudio._UIMaps.DataSummaryFieldsClasses
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

    using Accessibility;
    using System.Threading;
    using System.Windows.Forms;
    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using RetirementStudio._ThridParty;
    using RetirementStudio._UIMaps.FarPointClasses;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

    public partial class DataSummaryFields
    {

        private GenericLib_Win _gLib = new GenericLib_Win();
        private MyDictionary dic = new MyDictionary();


        /// <summary>
        /// 2015-Nov-11 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///  
        ///  pDataSummaryFields._SelectTab("");
        ///  
        /// </summary>
        /// <param name="dic"></param>
        /// 
        public void _SelectTab(String sTabName)
        {
            string sFunctionName = "_SelectTab";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            _gLib._TabPageSelectWin(sTabName, this.wRetirementStudio.wTab , 0);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        
        }


        /// <summary>
        /// 2015-Nov-11 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("BenefitSet", "");
        ///    dic.Add("PensionablePay", "");
        ///    dic.Add("PensionableService", "");
        ///    dic.Add("TransferredinPension", "");
        ///    dic.Add("AlternatePay1", "");
        ///    dic.Add("AlternatePay2", "");
        ///    pDataSummaryFields._MemberSummaries_Actives(dic); 
        /// </summary>
        /// <param name="dic"></param>
        /// 

        public void _MemberSummaries_Actives(MyDictionary dic)
        {
           
            int iRowNum = Convert.ToInt32(dic["iRow"]);
            String sRowKeys = "";

            for (int i = 1; i < iRowNum; i ++  )
                sRowKeys = sRowKeys + "{Down}";

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wActives.grid, "Click", 0, false, 5, 5);
            _gLib._SendKeysUDWin("RowNum", this.wRetirementStudio.wActives.grid, "{Tab}{PageUp}{Home}" + sRowKeys);


            WinWindow wWin = new WinWindow(this.wRetirementStudio );
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.COMBOBOX", PropertyExpressionOperator.Contains);
            WinComboBox wCombo;

            if (dic["BenefitSet"] != "")
            {
                _gLib._SendKeysUDWin("BenefitSet", this.wRetirementStudio.wActives.grid, "{Tab}{Home}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("BenefitSet", wCombo, dic["BenefitSet"], 0);
            }


            if (dic["PensionablePay"] != "")
            {
                _gLib._SendKeysUDWin("PensionablePay", this.wRetirementStudio.wActives.grid, "{Tab}{Home}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("PensionablePay", wCombo, dic["PensionablePay"], 0);
            }


            if (dic["PensionableService"] != "")
            {
                _gLib._SendKeysUDWin("PensionableService", this.wRetirementStudio.wActives.grid, "{Tab}{Home}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("PensionableService", wCombo, dic["PensionableService"], 0);
            }

            if (dic["TransferredinPension"] != "")
            {
                _gLib._SendKeysUDWin("TransferredinPension", this.wRetirementStudio.wActives.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("TransferredinPension", wCombo, dic["TransferredinPension"], 0);
            }

            if (dic["AlternatePay1"] != "")
            {
                _gLib._SendKeysUDWin("AlternatePay1", this.wRetirementStudio.wActives.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("AlternatePay1", wCombo, dic["AlternatePay1"], 0);
            }

            if (dic["AlternatePay2"] != "")
            {
                _gLib._SendKeysUDWin("AlternatePay2", this.wRetirementStudio.wActives.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("AlternatePay2", wCombo, dic["AlternatePay2"], 0);
            }

        }


        /// <summary>
        /// 2015-Nov-11 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("BenefitSet", "");
        ///    dic.Add("DeferredPension", "");
        ///    dic.Add("TransferredinPension", "");
        ///    pDataSummaryFields._MemberSummaries_Deferreds(dic); 
        /// </summary>
        /// <param name="dic"></param>
        /// 

        public void _MemberSummaries_Deferreds(MyDictionary dic)
        {
            int iRowNum = Convert.ToInt32(dic["iRow"]);
            String sRowKeys = "";

            for (int i = 1; i < iRowNum; i++)
                sRowKeys = sRowKeys + "{Down}";

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wDeferreds.grid, "Click", 0, false, 5, 5);
            _gLib._SendKeysUDWin("RowNum", this.wRetirementStudio.wDeferreds.grid, "{Tab}{PageUp}{Home}" + sRowKeys);


            WinWindow wWin = new WinWindow(this.wRetirementStudio);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.COMBOBOX", PropertyExpressionOperator.Contains);
            WinComboBox wCombo;

            if (dic["BenefitSet"] != "")
            {
                _gLib._SendKeysUDWin("BenefitSet", this.wRetirementStudio.wDeferreds.grid, "{Tab}{Home}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("BenefitSet", wCombo, dic["BenefitSet"], 0);
            }

            if (dic["DeferredPension"] != "")
            {
                _gLib._SendKeysUDWin("DeferredPension", this.wRetirementStudio.wDeferreds.grid, "{Tab}{Home}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("DeferredPension", wCombo, dic["DeferredPension"], 0);
            }

            if (dic["TransferredinPension"] != "")
            {
                _gLib._SendKeysUDWin("TransferredinPension", this.wRetirementStudio.wDeferreds.grid, "{Tab}{Home}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("TransferredinPension", wCombo, dic["TransferredinPension"], 0);
            }

        }



        /// <summary>
        /// 2015-Nov-11 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("BenefitSet", "");
        ///    dic.Add("InsuredPen", "");
        ///    dic.Add("InsuredSpousePen", "");
        ///    dic.Add("FundedPen", "");
        ///    dic.Add("FundedSpousePen", "");
        ///    pDataSummaryFields._MemberSummaries_Pensions(dic); 
        /// </summary>
        /// <param name="dic"></param>
        /// 

        public void _MemberSummaries_Pensions(MyDictionary dic)
        {

            int iRowNum = Convert.ToInt32(dic["iRow"]);
            String sRowKeys = "";

            for (int i = 1; i < iRowNum; i++)
                sRowKeys = sRowKeys + "{Down}";

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wPensioners.grid, "Click", 0, false, 5, 5);
            _gLib._SendKeysUDWin("RowNum", this.wRetirementStudio.wPensioners.grid, "{Tab}{PageUp}{Home}" + sRowKeys);


            WinWindow wWin = new WinWindow(this.wRetirementStudio);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.COMBOBOX", PropertyExpressionOperator.Contains);
            WinComboBox wCombo;

            if (dic["BenefitSet"] != "")
            {
                _gLib._SendKeysUDWin("BenefitSet", this.wRetirementStudio.wPensioners.grid, "{Tab}{Home}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("BenefitSet", wCombo, dic["BenefitSet"], 0);
            }

            if (dic["InsuredPen"] != "")
            {
                _gLib._SendKeysUDWin("InsuredPen", this.wRetirementStudio.wPensioners.grid, "{Tab}{Home}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("InsuredPen", wCombo, dic["InsuredPen"], 0);
            }


            if (dic["InsuredSpousePen"] != "")
            {
                _gLib._SendKeysUDWin("InsuredSpousePen", this.wRetirementStudio.wPensioners.grid, "{Tab}{Home}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("InsuredSpousePen", wCombo, dic["InsuredSpousePen"], 0);
            }

            if (dic["FundedPen"] != "")
            {
                _gLib._SendKeysUDWin("FundedPen", this.wRetirementStudio.wPensioners.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("FundedPen", wCombo, dic["FundedPen"], 0);
            }

            if (dic["FundedSpousePen"] != "")
            {
                _gLib._SendKeysUDWin("FundedSpousePen", this.wRetirementStudio.wPensioners.grid, "{Tab}{Home}{Tab}{Tab}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("FundedSpousePen", wCombo, dic["FundedSpousePen"], 0);
            }

        }



        /// <summary>
        /// 2015-Nov-11 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("BenefitSet", "");
        ///    dic.Add("AccruedPension", "");
        ///    dic.Add("OtherPension1", "");
        ///    dic.Add("OtherPension2", "");
        ///    dic.Add("OtherPension3", "");
        ///    pDataSummaryFields._BenefitSplits_ActivesPensionSplits(dic); 
        /// </summary>
        /// <param name="dic"></param>
        /// 

        public void _BenefitSplits_ActivesPensionSplits(MyDictionary dic)
        {

            int iRowNum = Convert.ToInt32(dic["iRow"]);
            String sRowKeys = "";

            for (int i = 1; i < iRowNum; i++)
                sRowKeys = sRowKeys + "{Down}";

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wActives.gridActivespensionsplits, "Click", 0, false, 5, 5);
            _gLib._SendKeysUDWin("RowNum", this.wRetirementStudio.wActives.gridActivespensionsplits, "{Tab}{PageUp}{Home}" + sRowKeys);


            WinWindow wWin = new WinWindow(this.wRetirementStudio);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.COMBOBOX", PropertyExpressionOperator.Contains);
            WinComboBox wCombo;

            if (dic["BenefitSet"] != "")
            {
                _gLib._SendKeysUDWin("BenefitSet", this.wRetirementStudio.wActives.gridActivespensionsplits, "{Tab}{Home}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("BenefitSet", wCombo, dic["BenefitSet"], 0);
            }

            if (dic["AccruedPension"] != "")
            {
                _gLib._SendKeysUDWin("AccruedPension", this.wRetirementStudio.wActives.gridActivespensionsplits, "{Tab}{Home}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("AccruedPension", wCombo, dic["AccruedPension"], 0);
            }

            if (dic["OtherPension1"] != "")
            {
                _gLib._SendKeysUDWin("OtherPension1", this.wRetirementStudio.wActives.gridActivespensionsplits, "{Tab}{Home}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("OtherPension1", wCombo, dic["OtherPension1"], 0);
            }

            if (dic["OtherPension2"] != "")
            {
                _gLib._SendKeysUDWin("OtherPension2", this.wRetirementStudio.wActives.gridActivespensionsplits, "{Tab}{Home}{Tab}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("OtherPension2", wCombo, dic["OtherPension2"], 0);
            }

            if (dic["OtherPension3"] != "")
            {
                _gLib._SendKeysUDWin("OtherPension3", this.wRetirementStudio.wActives.gridActivespensionsplits, "{Tab}{Home}{Tab}{Tab}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("OtherPension3", wCombo, dic["OtherPension3"], 0);
            }

        }


        /// <summary>
        /// 2015-Nov-11 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("BenefitSet", "");
        ///    dic.Add("OtherPension1", "");
        ///    dic.Add("OtherPension2", "");
        ///    dic.Add("OtherPension3", "");
        ///    pDataSummaryFields._BenefitSplits_DeferredsPensionSplits(dic); 
        /// </summary>
        /// <param name="dic"></param>
        /// 

        public void _BenefitSplits_DeferredsPensionSplits(MyDictionary dic)
        {

            int iRowNum = Convert.ToInt32(dic["iRow"]);
            String sRowKeys = "";

            for (int i = 1; i < iRowNum; i++)
                sRowKeys = sRowKeys + "{Down}";

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wDeferreds.gridDeferredspensionsplits, "Click", 0, false, 5, 5);
            _gLib._SendKeysUDWin("RowNum", this.wRetirementStudio.wDeferreds.gridDeferredspensionsplits, "{Tab}{PageUp}{Home}" + sRowKeys);


            WinWindow wWin = new WinWindow(this.wRetirementStudio);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.COMBOBOX", PropertyExpressionOperator.Contains);
            WinComboBox wCombo;

            if (dic["BenefitSet"] != "")
            {
                _gLib._SendKeysUDWin("BenefitSet", this.wRetirementStudio.wDeferreds.gridDeferredspensionsplits, "{Tab}{Home}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("BenefitSet", wCombo, dic["BenefitSet"], 0);
            }

            if (dic["OtherPension1"] != "")
            {
                _gLib._SendKeysUDWin("OtherPension1", this.wRetirementStudio.wDeferreds.gridDeferredspensionsplits, "{Tab}{Home}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("OtherPension1", wCombo, dic["OtherPension1"], 0);
            }

            if (dic["OtherPension2"] != "")
            {
                _gLib._SendKeysUDWin("OtherPension2", this.wRetirementStudio.wDeferreds.gridDeferredspensionsplits, "{Tab}{Home}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("OtherPension2", wCombo, dic["OtherPension2"], 0);
            }

            if (dic["OtherPension3"] != "")
            {
                _gLib._SendKeysUDWin("OtherPension3", this.wRetirementStudio.wDeferreds.gridDeferredspensionsplits, "{Tab}{Home}{Tab}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("OtherPension3", wCombo, dic["OtherPension3"], 0);
            }
        }


        /// <summary>
        /// 2015-Nov-11 
        /// ruiyang.song@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("iRow", "");
        ///    dic.Add("BenefitSet", "");
        ///    dic.Add("OtherPension1", "");
        ///    dic.Add("OtherPension2", "");
        ///    dic.Add("OtherPension3", "");
        ///    pDataSummaryFields._BenefitSplits_PensionersPensionSplits(dic); 
        /// </summary>
        /// <param name="dic"></param>
        /// 

        public void _BenefitSplits_PensionersPensionSplits(MyDictionary dic)
        {

            int iRowNum = Convert.ToInt32(dic["iRow"]);
            String sRowKeys = "";

            for (int i = 1; i < iRowNum; i++)
                sRowKeys = sRowKeys + "{Down}";

            _gLib._SetSyncUDWin("FPGrid", this.wRetirementStudio.wPensioners.gridPensionerspensionsplits, "Click", 0, false, 5, 5);
            _gLib._SendKeysUDWin("RowNum", this.wRetirementStudio.wPensioners.gridPensionerspensionsplits, "{Tab}{PageUp}{Home}" + sRowKeys);


            WinWindow wWin = new WinWindow(this.wRetirementStudio);
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.COMBOBOX", PropertyExpressionOperator.Contains);
            WinComboBox wCombo;

            if (dic["BenefitSet"] != "")
            {
                _gLib._SendKeysUDWin("BenefitSet", this.wRetirementStudio.wPensioners.gridPensionerspensionsplits, "{Tab}{Home}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("BenefitSet", wCombo, dic["BenefitSet"], 0);
            }
            
            if (dic["OtherPension1"] != "")
            {
                _gLib._SendKeysUDWin("OtherPension1", this.wRetirementStudio.wPensioners.gridPensionerspensionsplits, "{Tab}{Home}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("OtherPension1", wCombo, dic["OtherPension1"], 0);
            }

            if (dic["OtherPension2"] != "")
            {
                _gLib._SendKeysUDWin("OtherPension2", this.wRetirementStudio.wPensioners.gridPensionerspensionsplits, "{Tab}{Home}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("OtherPension2", wCombo, dic["OtherPension2"], 0);
            }

            if (dic["OtherPension3"] != "")
            {
                _gLib._SendKeysUDWin("OtherPension3", this.wRetirementStudio.wPensioners.gridPensionerspensionsplits, "{Tab}{Home}{Tab}{Tab}{Tab}{Space}");
                wCombo = new WinComboBox(wWin);
                _gLib._SetSyncUDWin("OtherPension3", wCombo, dic["OtherPension3"], 0);
            }
        }

        
    }
}
