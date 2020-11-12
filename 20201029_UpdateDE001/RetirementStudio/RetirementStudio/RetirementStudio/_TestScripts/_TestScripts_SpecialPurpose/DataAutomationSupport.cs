using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

using RetirementStudio._Config;
using RetirementStudio._Libraries;
using RetirementStudio._UIMaps;
using RetirementStudio._UIMaps.FarPointClasses;
using RetirementStudio._UIMaps.MainClasses;
using RetirementStudio._UIMaps.DataClasses;
using RetirementStudio._UIMaps.ParticipantDataSetClasses;
using RetirementStudio._UIMaps.AssumptionsClasses;
using RetirementStudio._UIMaps.InterestRateClasses;
using RetirementStudio._UIMaps.PayIncreaseClasses;
using RetirementStudio._UIMaps.OtherDemographicAssumptionsClasses;
using RetirementStudio._UIMaps.MortalityDecrementClasses;
using RetirementStudio._UIMaps.ServiceClasses;
using RetirementStudio._UIMaps.EligibilitiesClasses;
using RetirementStudio._UIMaps.PayoutProjectionClasses;
using RetirementStudio._UIMaps.PayAverageClasses;
using RetirementStudio._UIMaps.VestingClasses;
using RetirementStudio._UIMaps.ActuarialEquivalenceClasses;
using RetirementStudio._UIMaps.ConversionFactorsClasses;
using RetirementStudio._UIMaps.FormOfPaymentClasses;
using RetirementStudio._UIMaps.Item415LimitsClasses;
using RetirementStudio._UIMaps.PlanDefinitionClasses;
using RetirementStudio._UIMaps.MethodsClasses;
using RetirementStudio._UIMaps.TestCaseLibraryClasses;
using RetirementStudio._UIMaps.OutputManagerClasses;
using RetirementStudio._UIMaps.AssetsClasses;
using RetirementStudio._UIMaps.FundingInformationClasses;
using RetirementStudio._UIMaps.FundingInformation_PYR_PreliminaryResultsClasses;
using RetirementStudio._UIMaps.FundingInformation_FTAPsClasses;
using RetirementStudio._UIMaps.FundingInformation_ShortfallClasses;
using RetirementStudio._UIMaps.FundingInformation_ContributionSummaryClasses;
using RetirementStudio._UIMaps.OtherEconomicAssumptionClasses;
using RetirementStudio._UIMaps.FromToAgeClasses;
using RetirementStudio._UIMaps.FAEFormulaClasses;
using RetirementStudio._UIMaps.EarlyRetirementFactorClasses;
using RetirementStudio._UIMaps.BenefitElectionsClasses;
using System.Reflection;


namespace RetirementStudio._TestScripts._TestScripts_SpecialPurpose
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class DataAutomationSupport

    {
        public DataAutomationSupport()
        {

        }

        /// public string sDir = AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.IndexOf("TestResults")) + "output\\";
        public string sDir = "";

        static int iCol_Status = 1;
        static int iCol_Client = 2;
        static int iCol_Plan = 3;
        static int iCol_S1 = 4;
        static int iCol_S1_Rpt = 5;
        static int iCol_S1_Extract_C = 6;
        static int iCol_S1_Extract_P = 7;
        static int iCol_S2 = 8;
        static int iCol_S2_Rpt = 9;
        static int iCol_S2_Extract_C = 10;
        static int iCol_S2_Extract_P = 11;




        string sTestData = AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.IndexOf("TestResults")) + "TestData.xlsx";

        //string sTestData = @"C:\Users\webber-ling\Desktop\RetirementStudio\TestData.xlsx";

        string sClient = "";
        string sPlan = "";
        string sError = "";
        int iMaxLoop = 30;

        #region Fields
        ////private Dictionary<string, string> dic = new Dictionary<string, string>();
        public MyDictionary dic = new MyDictionary();
        public FarPoint _fp = new FarPoint();
        public GenericLib_Win _gLib = new GenericLib_Win();
        public Main pMain = new Main();
        public Data pData = new Data();
        public ParticipantDataSet pParticipantDataSet = new ParticipantDataSet();
        public Assumptions pAssumptions = new Assumptions();
        public InterestRate pInterestRate = new InterestRate();
        public PayIncrease pPayIncrease = new PayIncrease();
        public OtherDemographicAssumptions pOtherDemographicAssumptions = new OtherDemographicAssumptions();
        public MortalityDecrement pMortalityDecrement = new MortalityDecrement();
        public Service pService = new Service();
        public Eligibilities pEligibilities = new Eligibilities();
        public PayoutProjection pPayoutProjection = new PayoutProjection();
        public PayAverage pPayAverage = new PayAverage();
        public Vesting pVesting = new Vesting();
        public ActuarialEquivalence pActuarialEquivalence = new ActuarialEquivalence();
        public ConversionFactors pConversionFactors = new ConversionFactors();
        public FormOfPayment pFormOfPayment = new FormOfPayment();
        public Item415Limits p415Limits = new Item415Limits();
        public PlanDefinition pPlanDefinition = new PlanDefinition();
        public Methods pMethods = new Methods();
        public TestCaseLibrary pTestCaseLibrary = new TestCaseLibrary();
        public OutputManager pOutputManager = new OutputManager();
        public Assets pAssets = new Assets();
        public FundingInformation pFundingInformation = new FundingInformation();
        public FundingInformation_PYR_PreliminaryResults pFundingInformation_PYR_PreliminaryResults = new FundingInformation_PYR_PreliminaryResults();
        public FundingInformation_FTAPs pFundingInformation_FTAPs = new FundingInformation_FTAPs();
        public FundingInformation_Shortfall pFundingInformation_Shortfall = new FundingInformation_Shortfall();
        public FundingInformation_ContributionSummary pFundingInformation_ContributionSummary = new FundingInformation_ContributionSummary();
        public OtherEconomicAssumption pOtherEconomicAssumption = new OtherEconomicAssumption();
        public FromToAge pFromToAge = new FromToAge();
        public FAEFormula pFAEFormula = new FAEFormula();
        public EarlyRetirementFactor pEarlyRetirementFactor = new EarlyRetirementFactor();
        public BenefitElections pBenefitElections = new BenefitElections();


        #endregion



        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void testDownloadReports()
        {
  

            //_gLib._MsgBoxYesNo("Continue Testing?", sTestData);

  


            iMaxLoop = _xls_ReturnServiceMaxCheckNum(sTestData);
            sDir = _xls_ReturnOutputDir(sTestData);

            //_gLib._MsgBoxYesNo(iMaxLoop.ToString(), sDir);

            int iTotalRows = _xls_ReturnTotalRow(sTestData);

            

            for (int i = 0; i < iTotalRows; i++)
            {
                string sPriorService = "None";

                int iRowInTest = _xls_ReturnDataRow2Test(sTestData);

                if (iRowInTest == 0) ///// no row Status is ready, testing completed
                    break;

                //_gLib._MsgBoxYesNo(iRowInTest.ToString(), iRowInTest.ToString());

                _xls_GetClientPlan(sTestData, iRowInTest);

                //_gLib._MsgBoxYesNo(i.ToString(), sClient + sPlan);


                pMain._SelectTab("Home");


                dic.Clear();
                dic.Add("Level_1", sClient);
                dic.Add("Level_2", sPlan);
                dic.Add("Level_3", "ParticipantData");
                sError = pMain._HomeTreeViewSelect_AllServices(0, dic);

                if (sError == "")
                {
                    _xls_LogInfo(sTestData, iRowInTest, iCol_Status, "InProcess");

                    int iServcieFound = 0;

                    for (int j = 0; j < iMaxLoop; j++)
                    {
                        string sServiceToOpen = "";
                        

                        if(j<=24)
                            sServiceToOpen = _OpenServiceWithEffectiveDate(j+1, "2018");
                        else
                        {
                            _gLib._SetSyncUDWin("wHome_TableView_ScrollDwn", pMain.wRetirementStudio.wHome_TableView_ScrollDwn.fp, "click", 0, false, 5, 520);
                            sServiceToOpen = _OpenServiceWithEffectiveDate(25, "2018");
                        }
                        

                        if (sPriorService == sServiceToOpen) // sometimes next row shows same service name as prior one if prior service is the last one
                            continue;

                        if (sServiceToOpen!="")
                            sPriorService = sServiceToOpen;


                        if ((sServiceToOpen != "") && (sServiceToOpen != "END") && (sServiceToOpen != "E_ServiceLocked"))
                        {
                            iServcieFound = iServcieFound + 1;

                            _doTest(sTestData, iRowInTest, sClient, sPlan, sServiceToOpen, sDir, iServcieFound);
                        }
                        else if (sServiceToOpen == "E_ServiceLocked")
                        {

                            _xls_LogInfo(sTestData, iRowInTest, iCol_Status, "E_ServiceLocked");
                            break;
                        }
                        else if (sServiceToOpen == "END")
                        {
                            if (iServcieFound != 0)
                                _xls_LogInfo(sTestData, iRowInTest, iCol_Status, "Completed");
                            else
                                _xls_LogInfo(sTestData, iRowInTest, iCol_Status, "2018_Serv_NOT_Found");
                            break;
                        }
                        else if (sServiceToOpen == "E_Unknown")
                        {
                            _xls_LogInfo(sTestData, iRowInTest, iCol_Status, "E_Unknown");
                            break;
                        }
                        else if ( j == iMaxLoop - 1 )
                        {
                            if (iServcieFound != 0)
                                _xls_LogInfo(sTestData, iRowInTest, iCol_Status, "Completed");
                            else
                                _xls_LogInfo(sTestData, iRowInTest, iCol_Status, "2018_Serv_NOT_Found");
                            break;
                        }
                    }


                }
                else
                {
                    _xls_LogInfo(sTestData, iRowInTest, iCol_Status, sError);
                    continue;
                    ////////_gLib._MsgBoxYesNo("Error occurs - Click No to stop testing", sError);
                }

            }



            _gLib._MsgBox("Completed", "Completed!");


        }


        public string _OpenServiceWithEffectiveDate(int iIndex, string sYear)
        {
            string sFunctionName = "_OpenServiceWithEffectiveDate";

            int ixPos = 80;
            int iyPos = 30;
            int iyStep = 20;


            string sServiceToOpen = "";

            pMain._SelectTab("Home");


            #region check service property to identify the expected service year

            try
            {
                Mouse.Click(pMain.wRetirementStudio.wHome_TableView.cHome_TableView, MouseButtons.Right, ModifierKeys.None, new Point(ixPos, iyPos + iyStep * (iIndex - 1)));
            }
            catch (Exception ex)
            {
                _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to Right click on <Home Service Pane>. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right click on <Home Service Pane>. Because of Exception thrown: " + Environment.NewLine + ex.Message);
            }





            WinWindow wWin = new WinWindow();
            wWin.SearchProperties.Add(WinWindow.PropertyNames.AccessibleName, "DropDown");
            wWin.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains);
            wWin.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            wWin.SearchConfigurations.Add(SearchConfiguration.VisibleOnly);

            if (!_gLib._Exists("DropDown Menu Parent Win", wWin, 1, false))
            {
                try
                {
                    Mouse.Click(pMain.wRetirementStudio.wHome_TableView.cHome_TableView, MouseButtons.Right, ModifierKeys.None, new Point(ixPos, iyPos + iyStep * (iIndex - 1)));
                }
                catch (Exception ex)
                {
                    _gLib._Report(_PassFailStep.Fail, "\t\tFunction <" + sFunctionName + "> fail to Right click on <Home Service Pane>. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                    _gLib._MsgBoxYesNo("Continue Testing?", "Fail: Function <" + sFunctionName + "> fail to Right click on <Home Service Pane>. Because of Exception thrown: " + Environment.NewLine + ex.Message);
                }
            }

            if (_gLib._Exists("DropDown Menu Parent Win", wWin, 0, false))
            {
                WinMenuItem mi = new WinMenuItem((UITestControl)wWin);
                mi.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                mi.SearchProperties.Add(WinMenuItem.PropertyNames.Name, "Properties");

                if(_gLib._Enabled("", mi, 0, false))
                {
                    MyDictionary dicTmp = new MyDictionary();
                    dicTmp.Clear();
                    dicTmp.Add("Level_1", "Properties");
                    _gLib._MenuSelectWin(0, wWin, dicTmp);

                    string sInfo = pMain.wHome_DataServiceProperties.wEffectiveDate.txtEffectiveDate.GetProperty("Value").ToString();
                    sServiceToOpen = pMain.wHome_DataServiceProperties.wName.txtName.GetProperty("Value").ToString();
                    _gLib._SetSyncUDWin("wHome_DataServiceProperties", pMain.wHome_DataServiceProperties.wCancel.btnCancel, "Click", 0);
                    if (sInfo.Contains(sYear)){
                        _gLib._SetSyncUDWin("Home - Right Pane", pMain.wRetirementStudio.wHome_TableView.cHome_TableView, "Click", 0, false, ixPos, iyPos + iyStep * (iIndex - 1));

                        if (_gLib._Exists("wServiceInstanceLocked", pMain.wServiceInstanceLocked, 1, 1, false))
                        {
                            _gLib._SetSyncUDWin("wServiceInstanceLocked", pMain.wServiceInstanceLocked.wTitle, "Click", 0);
                            _gLib._SetSyncUDWin("Cancel", pMain.wServiceInstanceLocked.wCancel.btn, "Click", 0);
                            return "E_ServiceLocked";
                        }
                            

                        return sServiceToOpen;
                    }
                    else
                        return "";
                }
                else
                    return "END";

            }
            else
                return "E_Unknown";

            #endregion




        }

        public void _ExportConsolidatedReport(string sDataService, string sDir, string sFileName)
        {

            pMain._SelectTab(sDataService);

            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Output Manager");
            pData._TreeViewSelect(dic);

            if (_gLib._Exists("Save", pData.wOM_DataService_Popup, 3, 1, false))
                _gLib._SetSyncUDWin("Yes", pData.wOM_DataService_Popup.wYes.btnYes, "Click", 0);

            pMain._SelectTab("Data Output Manager");

            _gLib._SetSyncUDWin("wOM_ExportAll", pData.wRetirementStudio.wOM_ExportAll.btn, "Click", 0);

            pData.pOutputManager._SaveAs(sDir + sFileName);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "Click");
            pData._PopVerify_Complete_Popup(dic);


            pMain._SelectTab(sDataService);

        }

        public void _AddNewSnapshot(string sDataService, string sSnapshotName)
        {
            pMain._SelectTab(sDataService);

            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", sSnapshotName);
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            pMain._SelectTab(sDataService);
        }


        public string _Extract_C(string sDataService, string sDir, string sFileName)
        {
            string res = "";

            pMain._SelectTab(sDataService);

            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Extract_C_" + _gLib._ReturnDateStampYYYYMMDD());
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            pMain._SelectTab(sDataService);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_Snapshots(dic, true);

            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab(sDataService);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            _gLib._Wait(3);

            if (_gLib._Exists("OK", pData.wSP_Snapshot_Popup.wOK.btnOK, 1, 1, false))
                _gLib._SetSyncUDWin("OK", pData.wSP_Snapshot_Popup.wOK.btnOK, "Click", 0);

 

            pMain._SelectTab(sDataService);

            res = pData._ts_SP_CreateExtract_BusinessSupport(sDir + sFileName + ".xlsx");

            return res;
        }

        public string _Extract_P(string sDataService, string sDir, string sFileName)
        {

            string res = "";

            pMain._SelectTab(sDataService);

            dic.Clear();
            dic.Add("Level_1", sDataService);
            dic.Add("Level_2", "Snapshots");
            dic.Add("MenuItem", "Add new snapshot");
            pData._TreeViewRightSelect(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "Extract_P_" + _gLib._ReturnDateStampYYYYMMDD());
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            pMain._SelectTab(sDataService);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "EmployeeIDNumber");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "MemberSystemID");
            pData._TreeViewSelect_Snapshots(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            pData._TreeViewSelect_Snapshots_PriorView(dic, true);

            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Personal Information");
            dic.Add("Level_3", "EmployeeIDNumber");
            pData._TreeViewSelect_Snapshots_PriorView(dic, false);


            ///////////////////////////// does NOT exist in _P ///////////////
            ////////////dic.Clear();
            ////////////dic.Add("Level_1", "Include all");
            ////////////dic.Add("Level_2", "Personal Information");
            ////////////dic.Add("Level_3", "MemberSystemID");
            ////////////pData._TreeViewSelect_Snapshots_PriorView(dic, false);


            dic.Clear();
            dic.Add("Level_1", "Include all");
            dic.Add("Level_2", "Client Data");
            pData._TreeViewSelect_Snapshots_PriorView(dic, false);


            pMain._Home_ToolbarClick_Top(true);
            pMain._SelectTab(sDataService);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("SnapshotName", "");
            dic.Add("UseLatestDate", "");
            dic.Add("Preview", "");
            dic.Add("PublishSnapshot", "Click");
            dic.Add("CreateExtract", "");
            pData._PopVerify_Snapshots(dic);

            dic.Clear();
            dic.Add("PopVerify", "Pop");
            dic.Add("OK", "click");
            pData._PopVerify_SP_Snapshots_Popup(dic);

            _gLib._Wait(3);

            if (_gLib._Exists("OK", pData.wSP_Snapshot_Popup.wOK.btnOK, 1, 1, false))
                _gLib._SetSyncUDWin("OK", pData.wSP_Snapshot_Popup.wOK.btnOK, "Click", 0);


            pMain._SelectTab(sDataService);

            res = pData._ts_SP_CreateExtract_BusinessSupport(sDir + sFileName + ".xlsx");

            return res;


        }

        public void _SaveAndClose(string sDataService)
        {
            pMain._SelectTab(sDataService);
            pMain._Home_ToolbarClick_Top(true);
            pMain._Home_ToolbarClick_Top(false);
        }

        public string _doTest(string sDataFile, int iRow, string sClient, string sPlan, string sService, string sDir, int iServiceInstance)
        {

            string res = "";

            string sGivenName = _xls_ReturnGivenName(iRow, sTestData);
            string sFN_Consolidate, sFN_Extract_C, sFN_Extract_P;

            if (sGivenName != "")
            {
                sFN_Consolidate = sGivenName + "_" + iServiceInstance.ToString();
                sFN_Extract_C = sGivenName + "_C" + iServiceInstance.ToString();
                sFN_Extract_P = sGivenName + "_P" + iServiceInstance.ToString();
            }
            else
            {
                sFN_Consolidate = sClient + "-" + sPlan + "-" + sService + "_ConsolidatedRpt";
                sFN_Extract_C = sClient + "-" + sPlan + "-" + sService + "_SnapshotExtract_C";
                sFN_Extract_P = sClient + "-" + sPlan + "-" + sService + "_SnapshotExtract_P";
            }

            //////////_gLib._MsgBoxYesNo("sGivenName", sGivenName);
            //////////_gLib._MsgBoxYesNo("sFN_Consolidate", sFN_Consolidate);
            //////////_gLib._MsgBoxYesNo("sFN_Extract_C", sFN_Extract_C);
            //////////_gLib._MsgBoxYesNo("sFN_Extract_P", sFN_Extract_P);

            if (iServiceInstance == 1)
                _xls_LogInfo(sTestData, iRow, iCol_S1, sService);
            if (iServiceInstance == 2)
                _xls_LogInfo(sTestData, iRow, iCol_S2, sService);



            //_ExportConsolidatedReport(sService, sDir, sFN_Consolidate);
            //if (iServiceInstance == 1)
            //    _xls_LogInfo(sTestData, iRow, iCol_S1_Rpt, "Yes");
            //if (iServiceInstance == 2)
            //    _xls_LogInfo(sTestData, iRow, iCol_S2_Rpt, "Yes");


            string res_FileSaved_C = _Extract_C(sService, sDir, sFN_Extract_C);

            if (res_FileSaved_C == "") //// if successfully saved the extracted file
            {
                if (iServiceInstance == 1)
                    _xls_LogInfo(sTestData, iRow, iCol_S1_Extract_C, "Yes");

                if (iServiceInstance == 2)
                    _xls_LogInfo(sTestData, iRow, iCol_S2_Extract_C, "Yes");
            }
            else ///// if failed to save the extracted file
            {
                res = res_FileSaved_C;

                if (iServiceInstance == 1)
                    _xls_LogInfo(sTestData, iRow, iCol_S1_Extract_C, res_FileSaved_C);

                if (iServiceInstance == 2)
                    _xls_LogInfo(sTestData, iRow, iCol_S2_Extract_C, res_FileSaved_C);



            }
            
            



            if (_gLib._Exists("", pData.wRetirementStudio.wSP_TreeViewPrior.tvPriorView.tviIncludeAll, 1, false))
            {
                string res_FileSaved_P = _Extract_P(sService, sDir, sFN_Extract_P);

                if (res_FileSaved_P == "") //// if successfully saved the extracted file
                {
                    if (iServiceInstance == 1)
                        _xls_LogInfo(sTestData, iRow, iCol_S1_Extract_P, "Yes");
                    if (iServiceInstance == 2)
                        _xls_LogInfo(sTestData, iRow, iCol_S2_Extract_P, "Yes");
                }
                else ///// if failed to save the extracted file
                {
                    res = res_FileSaved_P;

                    if (iServiceInstance == 1)
                        _xls_LogInfo(sTestData, iRow, iCol_S1_Extract_P, res_FileSaved_P);

                    if (iServiceInstance == 2)
                        _xls_LogInfo(sTestData, iRow, iCol_S2_Extract_P, res_FileSaved_P);


                }

            }
            else
                _xls_LogInfo(sTestData, iRow, iCol_S1_Extract_P, "N/A");



            _SaveAndClose(sService);

            return res;
            
        }


        public int _xls_ReturnDataRow2Test(string sTestData)
        {
            MyExcel _xlsTD = new MyExcel(sTestData, false);

            if (!_xlsTD.OpenExcelFile(1))
            {
                _gLib._Report(_PassFailStep.Fail, "Fail to open excel  file: " + sTestData);
                _xlsTD.CloseExcelApplication();
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail to open excel  file: " + sTestData);
                return 0;
            }


            int iTotalRow = _xlsTD.getTotalRowCount();


            string sStatus = "";
            int iRow_Ready = 0;
            for (int i = 2; i <= iTotalRow; i++)
            {
                sStatus = _xlsTD.getOneCellValue(i, 1);
                if (sStatus.ToLower() == "ready")
                {
                    iRow_Ready = i;
                    break;
                }
            }

            _xlsTD.CloseExcelApplication();
            return iRow_Ready;
        }

        public int _xls_ReturnServiceMaxCheckNum(string sTestData)
        {
            int iMax = 30;
            MyExcel _xlsTD = new MyExcel(sTestData, false);

            if (!_xlsTD.OpenExcelFile(1))
            {
                _gLib._Report(_PassFailStep.Fail, "Fail to open excel  file: " + sTestData);
                _xlsTD.CloseExcelApplication();
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail to open excel  file: " + sTestData);
                return 0;
            }

            string sNum = _xlsTD.getOneCellValue(2, 12);

            iMax = Convert.ToInt32(sNum);

            _xlsTD.CloseExcelApplication();
            return iMax;
        }

        public string _xls_ReturnOutputDir(string sTestData)
        {
            string sDir = "";

            MyExcel _xlsTD = new MyExcel(sTestData, false);

            if (!_xlsTD.OpenExcelFile(1))
            {
                _gLib._Report(_PassFailStep.Fail, "Fail to open excel  file: " + sTestData);
                _xlsTD.CloseExcelApplication();
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail to open excel  file: " + sTestData);
                return "";
            }

            sDir = _xlsTD.getOneCellValue(2, 13);

            _xlsTD.CloseExcelApplication();

            return sDir;
        }

        public string _xls_ReturnGivenName(int iRow, string sTestData)
        {
            string sName = "";

            MyExcel _xlsTD = new MyExcel(sTestData, false);

            if (!_xlsTD.OpenExcelFile(1))
            {
                _gLib._Report(_PassFailStep.Fail, "Fail to open excel  file: " + sTestData);
                _xlsTD.CloseExcelApplication();
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail to open excel  file: " + sTestData);
                return "";
            }

            sName = _xlsTD.getOneCellValue(iRow, 14);

            _xlsTD.CloseExcelApplication();

            return sName;
        }

        public int _xls_GetClientPlan(string sTestData, int iRow)
        {
            MyExcel _xlsTD = new MyExcel(sTestData, false);
            if (!_xlsTD.OpenExcelFile(1))
            {
                _gLib._Report(_PassFailStep.Fail, "Fail to open excel  file: " + sTestData);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail to open excel  file: " + sTestData);
                return 0;
            }

            sClient = _xlsTD.getOneCellValue(iRow, iCol_Client);
            sPlan = _xlsTD.getOneCellValue(iRow, iCol_Plan);

            _xlsTD.CloseExcelApplication();


            if (sClient == "" || sPlan == "")
                return 0;
            else
                return 1;

        }

        public void _xls_LogInfo(string sTestData, int iRow, int iCol, string sInfo)
        {

            MyLog mLog = new MyLog(iCol, sTestData);

            mLog.LogInfo(iRow, iCol, sInfo);

        }

        public int _xls_ReturnTotalRow(string sTestData)
        {
            MyExcel _xlsTD = new MyExcel(sTestData, false);

            if (!_xlsTD.OpenExcelFile(1))
            {
                _gLib._Report(_PassFailStep.Fail, "Fail to open excel  file: " + sTestData);
                _gLib._MsgBoxYesNo("Continue Testing?", "Fail to open excel  file: " + sTestData);
                return 0;
            }


            int totalRow = _xlsTD.getTotalRowCount();

            _xlsTD.CloseExcelApplication();

            return totalRow;
        }



        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _gLib._KillProcessByName("Excel");
        }

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
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
    }
}
