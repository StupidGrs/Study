namespace RetirementStudio._UIMaps.OneYearProjectionClasses
{
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;



    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using System.Threading;
    using System.Diagnostics;

    using RetirementStudio._Config;
    using RetirementStudio._Libraries;
    using RetirementStudio._ThridParty;
    using RetirementStudio._UIMaps.FarPointClasses;
    using RetirementStudio._UIMaps.OutputManagerClasses;
    using RetirementStudio._UIMaps.TestCaseLibraryClasses;


    public partial class OneYearProjection
    {
        private MyDictionary dic = new MyDictionary();
        private GenericLib_Win _gLib = new GenericLib_Win();
        private FarPoint _fp = new FarPoint();
        

        /// <summary>
        /// 2013-May-11 
        /// webber.ling@mercer.com
        /// 
        /// sample:
        ///    dic.Clear();
        ///    dic.Add("PopVerify", "Pop");
        ///    dic.Add("Actives_txt", "");
        ///    dic.Add("Pensions_txt", "");
        ///    dic.Add("Deferred_txt", "");
        ///    pOneYearProjection._OneYearProjection(dic); 
        /// </summary>
        /// <param name="dic"></param>
        public void _OneYearProjection(MyDictionary dic)
        {
        
            this.wRetirementStudio.wEdit.SearchProperties.Add( WinEdit.PropertyNames.Instance, "3");
            _gLib._SetSyncUDWin("Actives_txt", this.wRetirementStudio.wEdit.Edit.txt, "click", 0,false,10,3); 
            _gLib._SetSyncUDWin_ByClipboard("Actives_txt", this.wRetirementStudio.wEdit.Edit.txt, dic["Actives_txt"], 0);


            this.wRetirementStudio.wEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "2");
            _gLib._SetSyncUDWin("Actives_txt", this.wRetirementStudio.wEdit.Edit.txt, "click", 0, false, 10, 3);
            _gLib._SetSyncUDWin_ByClipboard("Pensions_txt", this.wRetirementStudio.wEdit.Edit.txt, dic["Pensions_txt"], 0);


            this.wRetirementStudio.wEdit.SearchProperties.Add(WinEdit.PropertyNames.Instance, "1");
            _gLib._SetSyncUDWin("Actives_txt", this.wRetirementStudio.wEdit.Edit.txt, "click", 0, false, 10, 3);
            _gLib._SetSyncUDWin_ByClipboard("Deferred_txt", this.wRetirementStudio.wEdit.Edit.txt, dic["Deferred_txt"], 0);
        }
    }
}
