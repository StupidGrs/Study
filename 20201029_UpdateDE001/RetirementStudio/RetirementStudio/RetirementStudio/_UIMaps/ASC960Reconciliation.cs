namespace RetirementStudio._UIMaps.ASC960ReconciliationClasses
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

    
    public partial class ASC960Reconciliation
    {

        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();

        /// <summary>
        /// 2019-Feb-01
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("Level_1", "ASC 960 Reconciliation Inputs");
        ///    dic.Add("Level_2", "Prior Year");
        ///    pASC960Reconciliation._TreeViewSelect(dic);
        /// 
        /// </summary>
        /// <param name="dic"></param>
        public void _TreeViewSelect(MyDictionary dic)
        {
            string sFunctionName = "_TreeViewSelect";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");


            _gLib._TreeViewSelectWin(0, this.wRetirementStudio.tvNaviTree, dic);

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }


        /// <summary>
        /// 2019-Feb-01
        /// yolanda.zhang@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("MarketValueOfAssets_chk", "");
        ///    dic.Add("MarketValueOfAssets", "");
        ///    pASC960Reconciliation._PopVerify_PY_AssetData(dic);
        ///    
        /// </summary>
        /// <param name="dic"></param>
        public void _PopVerify_PY_AssetData(MyDictionary dic)
        {
            string sFunctionName = "_PopVerify_PY_AssetData";
            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Starts:");

            if (dic["PopVerify"] == "Pop")
            {
                _gLib._SetSyncUDWin("MarketValueOfAssets_chk", this.wRetirementStudio.wMarketValueOfAssets.chk, dic["MarketValueOfAssets_chk"], 0);
                _gLib._SetSyncUDWin_ByClipboard("MarketValueOfAssets", this.wRetirementStudio.wPY_MarketValueofAssetsAvailableforBenefits.txt, dic["MarketValueOfAssets"], 0);
            }
            if (dic["PopVerify"] == "Verify")
            {

                _gLib._VerifySyncUDWin("MarketValueOfAssets", this.wRetirementStudio.wPY_MarketValueofAssetsAvailableforBenefits.txt, dic["MarketValueOfAssets"], 0);
  
            }

            _gLib._Report(_PassFailStep.Step, "Function <" + sFunctionName + "> Ends:");
        }

    }
}
