using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Reflection;
using Microsoft.CSharp;
using RetirementStudio._Config;
using System.Windows.Automation;


namespace RetirementStudio._Libraries
{

    class CompareReportsLib
    {
        private GenericLib_Win _gLib = new GenericLib_Win();
        private string _sBaselineDir = "";
        private string _sCompareDir = "";
        private string _sClient = "";
        private double _dTolerancePercent = 0.01;

        public CompareReportsLib()
        { }


        public CompareReportsLib(string sClient, string sBaselineDir, string sCompareDir)
        {
            this._sBaselineDir = sBaselineDir;
            this._sCompareDir = sCompareDir;
            this._sClient = sClient;
        }


        /// <summary>
        /// webber 2013-10-09
        /// sample:
        /// 
        /// _compareReportsLib.CompareExcel_Exact("LiabilitySummary.xls", 4, 0, 0, 0);
        /// _compareReportsLib.CompareExcel_Exact("ValuationSummary.xls", 11, 0, 0, 0);
        /// _compareReportsLib.CompareExcel_Exact("IndividualOutput.xls", 7, 0, 0, 0);
        /// _compareReportsLib.CompareExcel_Exact("PayoutProjection.xls", 4, 0, 0, 0);
        /// _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xls", 4, 0, 0, 0);
        /// _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResultsbyPlanDef.xls", 4, 0, 0, 0);
        /// _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaseline_FAS35PVAB.xls", 4, 0, 0, 0);
        /// _compareReportsLib.CompareExcel_Exact("ReconciliationtoBaselinebyPlanDef_FAS35PVAB.xls", 4, 0, 0, 0);
        /// 
        /// </summary>
        /// <param name="sReportName"></param>
        /// <param name="iRowStart"></param>
        /// <param name="iRowEnd"></param>
        /// <param name="iColStart"></param>
        /// <param name="iColEnd"></param>
        public string CompareExcel_Exact(string sReportName, int iRowStart, int iRowEnd, int iColStart, int iColEnd, Boolean bPrintCurrentRpt = false)
        {

            int[,] Cells_Skip = new int[0, 0];
            string[] Sheets_Skip = new string[0];
            string[] Sheets_Compare = new string[0];

            return this.CompareExcel_Exact(sReportName, iRowStart, iRowEnd, iColStart, iColEnd, Cells_Skip, Sheets_Skip, Sheets_Compare, bPrintCurrentRpt);

        }


        /// <summary>
        /// _compareReportsLib.CompareExcel_Exact("A.xlsx", 0, new string[2] {"Sheet2", "Sheet3"});
        /// _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xls", 0, new string[2] { "Sheet1", "Sheet5" });
        /// </summary>
        /// <param name="sReportName"></param>
        /// <param name="iRowStart"></param>
        /// <param name="Sheets_Skip"></param>
        public string CompareExcel_Exact(string sReportName, int iRowStart, string[] Sheets_Skip, Boolean bPrintCurrentRpt = false)
        {
            int[,] Cells_Skip = new int[0, 0];
            string[] Sheets_Compare = new string[0];
            return this.CompareExcel_Exact(sReportName, iRowStart, 0, 0, 0, Cells_Skip, Sheets_Skip, Sheets_Compare, bPrintCurrentRpt);

        }



        /// <summary>
        /// _compareReportsLib.CompareExcel_Exact("A.xlsx", 0, new int[2,2] {{1,0},{5,1}}, new string[1] {"Sheet1"});
        /// _compareReportsLib.CompareExcel_Exact("LiabilitiesDetailedResults.xls", 0, new int[1, 2] { {0, 10} }, new string[1] { "Sheet1" });
        /// </summary>
        /// <param name="sReportName"></param>
        /// <param name="iRowStart"></param>
        /// <param name="Cells_Skip"></param>
        /// <param name="Sheets_Compare"></param>
        public string CompareExcel_Exact(string sReportName, int iRowStart, int[,] Cells_Skip, string[] Sheets_Compare, Boolean bPrintCurrentRpt = false)
        {

            string[] Sheets_Skip = new string[0];
            return this.CompareExcel_Exact(sReportName, iRowStart, 0, 0, 0, Cells_Skip, Sheets_Skip, Sheets_Compare, bPrintCurrentRpt);

        }


        public string CompareExcel_Exact(string sReportName, int iRowStart, int iRowEnd, int iColStart, int iColEnd, int[,] Cells_Skip, string[] Sheets_Skip, string[] Sheets_Compare, Boolean bPrintCurrentRpt=false )
        {

            if(bPrintCurrentRpt)
                this._PrintCurrentReport(sReportName);
            

            int iTotalSheets = 0;
            string sCellBaseline = "";
            string sCellCompare = "";
            Boolean bMatch = true;
            string sLogContent = "";
            int iMaxNumOfErrorLogged = 20;


            //// Baseline
            string tempreportname = sReportName;
            if (!_gLib._FileExists(_sBaselineDir + tempreportname, false))
            {
                tempreportname = sReportName.Replace(".xlsx", ".xls");
                if (!_gLib._FileExists(_sBaselineDir + tempreportname, false))
                {
                    sLogContent = "File NOT Exist:   " + _sBaselineDir + tempreportname + Environment.NewLine;
                    this._Report(_PassFailStep.Fail, sReportName, sLogContent);
                    return "File_NOT_Exist";
                }
            }
            MyExcel _excelBaseline = new MyExcel(_sBaselineDir + tempreportname, Config.bExcelVisible);



            //// QA
            tempreportname = sReportName;
            if (!_gLib._FileExists(_sCompareDir + sReportName, false))
            {
                tempreportname = sReportName.Replace(".xlsx", ".xls");
                if (!_gLib._FileExists(_sCompareDir + tempreportname, false))
                {
                    sLogContent = "File NOT Exist:   " + _sCompareDir + tempreportname + Environment.NewLine;
                    this._Report(_PassFailStep.Fail, sReportName, sLogContent);
                    return "File_NOT_Exist";
                }
            }
            MyExcel _excelCompare = new MyExcel(_sCompareDir + tempreportname, Config.bExcelVisible);


            if (!_excelBaseline.OpenExcelFile(1))
            {
                this._Report(_PassFailStep.Fail, sReportName, "Fail to open excel baseline file: " + _sBaselineDir + sReportName);
                return "Fail to open excel baseline file";
            }
            if(!_excelCompare.OpenExcelFile(1))
            {
                this._Report(_PassFailStep.Fail, sReportName, "Fail to open excel compare file: " + _sCompareDir + sReportName);
                return "Fail to open excel compare file";
            }

            if (_excelBaseline.ReturnNumOfSheets() != _excelCompare.ReturnNumOfSheets())
            {
                _excelBaseline.CloseExcelApplication();
                _excelCompare.CloseExcelApplication();
                ////_gLib._MsgBoxYesNo("Error", "Number of Excel sheets NOT match for report <" + sReportName + ">. Please manual check!");
                this._Report(_PassFailStep.Fail, sReportName, "Excel sheet number NOT match");
                return "SheetNum_Not_Match";
            }

            iTotalSheets = _excelCompare.ReturnNumOfSheets();
            if(iTotalSheets==0)
            {
                _excelBaseline.CloseExcelApplication();
                _excelCompare.CloseExcelApplication();
                this._Report(_PassFailStep.Fail, sReportName, "Fail to get excel sheet number from compare rpt");
                return "Fail to get excel sheet number from compare rpt";
            }

            sLogContent = sLogContent + _sBaselineDir + sReportName + Environment.NewLine;
            sLogContent = sLogContent + _sCompareDir + sReportName + Environment.NewLine;

            for (int iSheet = 1; iSheet <= iTotalSheets; iSheet++)
            {

                _excelBaseline.OpenExcelFile(iSheet);
                _excelCompare.OpenExcelFile(iSheet);


                string sSheetName_Baseline = "";
                string sSheetName_Compare = "";

                sSheetName_Baseline = _excelBaseline.getActiveSheetName();
                if (sSheetName_Baseline.Equals(""))
                {
                    _excelBaseline.CloseExcelApplication();
                    _excelCompare.CloseExcelApplication();
                    this._Report(_PassFailStep.Fail, sReportName, "Fail to get ActiveSheetName from: " + _sBaselineDir + sReportName);
                    return "Fail to get ActiveSheetName";
                }

                sSheetName_Compare = _excelCompare.getActiveSheetName();
                if (sSheetName_Compare.Equals(""))
                {
                    _excelBaseline.CloseExcelApplication();
                    _excelCompare.CloseExcelApplication();
                    this._Report(_PassFailStep.Fail, sReportName, "Fail to get ActiveSheetName from: " + _sCompareDir + sReportName);
                    return "Fail to get ActiveSheetName";
                }

                if (sSheetName_Baseline != sSheetName_Compare)
                {
                    ////////_gLib._MsgBoxYesNo("Error", "Sheet Name NOT match for report <" + sReportName + "> => sheet No. <" + iSheet.ToString() + "> Please manual check!");
                    this._Report(_PassFailStep.Fail, sReportName, "Excel sheet name NOT match");
                    _excelBaseline.CloseExcelApplication();
                    _excelCompare.CloseExcelApplication();
                    return "SheetName_Not_Match";
                }
                int iTotalRow = 0;
                int iTotalCol = 0;
                int iRowStart_CurrentSheet = 0;
                int iColStart_CurrentSheet = 0;
                int iRowEND_CurrentSheet = 0;
                int iColEND_CurrentSheet = 0;
                int iTotalRow_Baseline = _excelBaseline.getTotalRowCount();
                int iTotalCol_Baseline = _excelBaseline.getTotalColumnCount();
                int iTotalRow_Compare = _excelCompare.getTotalRowCount();
                int iTotalCol_Compare = _excelCompare.getTotalColumnCount();


                //////if (iTotalRow_Baseline != iTotalRow_Compare)
                //////    _gLib._MsgBoxYesNo("Error", "Total Row number NOT match for report <" + sReportName + "> => sheet <" + sSheetName_Baseline + "> Please manual check!");
                //////if (iTotalCol_Baseline != iTotalCol_Compare)
                //////    _gLib._MsgBoxYesNo("Error", "Total Column number NOT match for report <" + sReportName + "> => sheet <" + sSheetName_Baseline + "> Please manual check!");


                Boolean bSkipThisSheet = false;

                for (int i = 0; i < Sheets_Skip.Length; i++)
                {
                    if(sSheetName_Compare.ToUpper().Equals(Sheets_Skip[i].ToUpper()))
                    {
                        _excelBaseline.CloseExcelApplication();
                        _excelCompare.CloseExcelApplication();
                        sLogContent = sLogContent + "Sheet <" + sSheetName_Compare + "> skipped based on User setting. " + Environment.NewLine;
                        bSkipThisSheet = true;
                        break;
                    }
                }
                if (bSkipThisSheet) continue;

                for (int i = 0; i < Sheets_Compare.Length; i++)
                {
                    if (!sSheetName_Compare.ToUpper().Equals(Sheets_Compare[i].ToUpper()))
                    {
                        _excelBaseline.CloseExcelApplication();
                        _excelCompare.CloseExcelApplication();
                        bSkipThisSheet = true;
                        break;
                    }
                }
                if (bSkipThisSheet) continue;



                if (iTotalRow_Baseline >= iTotalRow_Compare)
                    iTotalRow = iTotalRow_Baseline;
                else
                    iTotalRow = iTotalRow_Compare;

                if (iTotalCol_Baseline >= iTotalCol_Compare)
                    iTotalCol = iTotalCol_Baseline;
                else
                    iTotalCol = iTotalCol_Compare;

                if (iRowStart == 0)
                    iRowStart_CurrentSheet = 1;
                else
                    iRowStart_CurrentSheet = iRowStart;
                if (iColStart == 0)
                    iColStart_CurrentSheet = 1;
                else
                    iColStart_CurrentSheet = iColStart;
                if (iRowEnd == 0)
                    iRowEND_CurrentSheet = iTotalRow;
                else
                    iRowEND_CurrentSheet = iRowEnd;
                if (iColEnd == 0)
                    iColEND_CurrentSheet = iTotalCol;
                else
                    iColEND_CurrentSheet = iColEnd;


                int iTotalErrorCellNumber = 0;


                if (!_excelBaseline.expandAllLevels(iRowEND_CurrentSheet, iColEND_CurrentSheet))
                {
                    _excelBaseline.CloseExcelApplication();
                    _excelCompare.CloseExcelApplication();
                    this._Report(_PassFailStep.Fail, sReportName, "Fail to Expand All Levels from: " + _sBaselineDir + sReportName);
                    return "Fail to Expand All Levels";
                }

                if (!_excelCompare.expandAllLevels(iRowEND_CurrentSheet, iColEND_CurrentSheet))
                {
                    _excelBaseline.CloseExcelApplication();
                    _excelCompare.CloseExcelApplication();
                    this._Report(_PassFailStep.Fail, sReportName, "Fail to Expand All Levels from: " + _sCompareDir + sReportName);
                    return "Fail to Expand All Levels";
                }

                for (int i = iRowStart_CurrentSheet; i <= iRowEND_CurrentSheet; i++)
                {
                    if (sReportName.Contains("LiabilitySetforGlobeExport"))
                        if ((i == 6) || (i == 7) || (i == 8) || (i == 17) || (i == 18))
                            continue;

                    int iSikpAnswer = 100;
                    Boolean bSkip = false;

                    for (int j = iColStart_CurrentSheet; j <= iColEND_CurrentSheet; j++)
                    {
                        bSkip = false;

                        iSikpAnswer = this._SkipAnswer(i, j, Cells_Skip);
                        switch (iSikpAnswer)
                        {
                            case 0://// 0 - Not skip
                                break;
                            case 1://// 1 - skip this row
                                bSkip = true;
                                break;
                            case 2://// 2 - skip this column
                                bSkip = true;
                                break;
                            case 3://// 3 - skip this cell
                                bSkip = true;
                                break;
                            default:
                                break;
                        }
                        if (bSkip) continue;

                        sCellBaseline = _excelBaseline.getOneCellValue(i, j);
                        sCellCompare = _excelCompare.getOneCellValue(i, j);

                        

                        if (!sCellBaseline.Equals(sCellCompare))
                        {
                            iTotalErrorCellNumber++;
                            bMatch = false;

                            double valueBaseline, valueCompare;
                            if (double.TryParse(sCellBaseline, out valueBaseline) && double.TryParse(sCellCompare, out valueCompare) && (!this._dTolerancePercent.Equals(0.0)))
                            {

                                if (Math.Abs((valueBaseline - valueCompare) / valueBaseline) < (this._dTolerancePercent / 100))
                                {
                                    _excelCompare.setOneCellColor_Yellow(i, j);
                                    if (iTotalErrorCellNumber < iMaxNumOfErrorLogged)
                                        sLogContent = sLogContent + "In Tolerance:  " + this._dTolerancePercent + "%  " + sSheetName_Baseline + " => Cell(" + i + " ," + j + ")" + "    Baseline: " + sCellBaseline + " <=> Compare: " + sCellCompare + Environment.NewLine;
                                }
                                else
                                {
                                    _excelCompare.setOneCellColor_Red(i, j);
                                    if (iTotalErrorCellNumber < iMaxNumOfErrorLogged)
                                        sLogContent = sLogContent + "Out Tolerance: " + this._dTolerancePercent + "%  " + sSheetName_Baseline + " => Cell(" + i + " ," + j + ")" + "    Baseline: " + sCellBaseline + " <=> Compare: " + sCellCompare + Environment.NewLine;
                                }
                            }
                            else
                            {
                                _excelCompare.setOneCellColor_Red(i, j);
                                if (iTotalErrorCellNumber < iMaxNumOfErrorLogged)
                                    sLogContent = sLogContent + "Not Match:    " + sSheetName_Baseline + " => Cell(" + i + " ," + j + ")" + "    Baseline: " + sCellBaseline + " <=> Compare: " + sCellCompare + Environment.NewLine;
                            }
                            if (iTotalErrorCellNumber == iMaxNumOfErrorLogged)
                                sLogContent = sLogContent + "**********    More error cells (exceeds  " + iMaxNumOfErrorLogged + " ) are NOT logged here, pleae refer to its Excel file!   ********** " + Environment.NewLine;
                        }
                    }
                }
                _excelBaseline.SaveExcel();
                _excelBaseline.CloseExcelApplication();
                _excelCompare.SaveExcel();
                _excelCompare.CloseExcelApplication();



            }

            _gLib._KillProcessByName("notepad");


            if (!bMatch)
            {
                this._Report(_PassFailStep.Fail, sReportName, sLogContent);
                 return "Rpt_Not_Match";
            }
            else
            {
                this._Report(_PassFailStep.Pass, sReportName, sLogContent);
                return "Rpt_Match";
            }
               



            //////////////////////////////////_excelBaseline.SaveExcel();
            //////////////////////////////////_excelBaseline.CloseExcelApplication();
            //////////////////////////////////_excelCompare.SaveExcel();
            //////////////////////////////////_excelCompare.CloseExcelApplication();

        }

        public void CompareExcel_Exact_BySheetName(string sReportName, string sSheetName, int iRowStart, int iRowEnd, int iColStart, int iColEnd, int[,] Cells_Skip, Boolean bPrintCurrentRpt=false)
        {
            if (bPrintCurrentRpt)
                this._PrintCurrentReport(sReportName);


            int iTotalSheets = 0;
            string sCellBaseline = "";
            string sCellCompare = "";
            Boolean bMatch = true;
            string sLogContent = "";
            int iMaxNumOfErrorLogged = 20;

            

            if (!_gLib._FileExists(_sBaselineDir + sReportName, false))
            {
                sLogContent = "File NOT Exist:   " + _sBaselineDir + sReportName + Environment.NewLine;
                this._Report(_PassFailStep.Fail, sReportName, sLogContent);
                return;
            }

            if (!_gLib._FileExists(_sCompareDir + sReportName, false))
            {
                sLogContent = "File NOT Exist:   " + _sCompareDir + sReportName + Environment.NewLine;
                this._Report(_PassFailStep.Fail, sReportName, sLogContent);
                return;
            }

            MyExcel _excelBaseline = new MyExcel(_sBaselineDir + sReportName, Config.bExcelVisible);
            MyExcel _excelCompare = new MyExcel(_sCompareDir + sReportName, Config.bExcelVisible);


            sLogContent = sLogContent + _sBaselineDir + sReportName + Environment.NewLine;
            sLogContent = sLogContent + _sCompareDir + sReportName + Environment.NewLine;

            _excelBaseline.OpenExcelFile(sSheetName);
            _excelCompare.OpenExcelFile(sSheetName);

            int iTotalRow = 0;
            int iTotalCol = 0;
            int iRowStart_CurrentSheet = 0;
            int iColStart_CurrentSheet = 0;
            int iRowEND_CurrentSheet = 0;
            int iColEND_CurrentSheet = 0;
            int iTotalRow_Baseline = _excelBaseline.getTotalRowCount();
            int iTotalCol_Baseline = _excelBaseline.getTotalColumnCount();
            int iTotalRow_Compare = _excelCompare.getTotalRowCount();
            int iTotalCol_Compare = _excelCompare.getTotalColumnCount();




            if (iTotalRow_Baseline >= iTotalRow_Compare)
                iTotalRow = iTotalRow_Baseline;
            else
                iTotalRow = iTotalRow_Compare;

            if (iTotalCol_Baseline >= iTotalCol_Compare)
                iTotalCol = iTotalCol_Baseline;
            else
                iTotalCol = iTotalCol_Compare;

            if (iRowStart == 0)
                iRowStart_CurrentSheet = 1;
            else
                iRowStart_CurrentSheet = iRowStart;
            if (iColStart == 0)
                iColStart_CurrentSheet = 1;
            else
                iColStart_CurrentSheet = iColStart;
            if (iRowEnd == 0)
                iRowEND_CurrentSheet = iTotalRow;
            else
                iRowEND_CurrentSheet = iRowEnd;
            if (iColEnd == 0)
                iColEND_CurrentSheet = iTotalCol;
            else
                iColEND_CurrentSheet = iColEnd;


            int iTotalErrorCellNumber = 0;


            if(!_excelBaseline.expandAllLevels(iRowEND_CurrentSheet, iColEND_CurrentSheet))
            {
                _excelBaseline.CloseExcelApplication();
                _excelCompare.CloseExcelApplication();
                this._Report(_PassFailStep.Fail, sReportName, "Fail to Expand All Levels from: " + _sBaselineDir + sReportName);
                return;
            }
            
            if(!_excelCompare.expandAllLevels(iRowEND_CurrentSheet, iColEND_CurrentSheet))
            {
                _excelBaseline.CloseExcelApplication();
                _excelCompare.CloseExcelApplication();
                this._Report(_PassFailStep.Fail, sReportName, "Fail to Expand All Levels from: " + _sCompareDir + sReportName);
                return;
            }

            for (int i = iRowStart_CurrentSheet; i <= iRowEND_CurrentSheet; i++)
            {
                if (sReportName.Contains("LiabilitySetforGlobeExport"))
                    if ((i == 6) || (i == 7) || (i == 8) || (i == 17) || (i == 18))
                        continue;

                int iSikpAnswer = 100;
                Boolean bSkip = false;

                for (int j = iColStart_CurrentSheet; j <= iColEND_CurrentSheet; j++)
                {
                    bSkip = false;

                    iSikpAnswer = this._SkipAnswer(i, j, Cells_Skip);
                    switch (iSikpAnswer)
                    {
                        case 0://// 0 - Not skip
                            break;
                        case 1://// 1 - skip this row
                            bSkip = true;
                            break;
                        case 2://// 2 - skip this column
                            bSkip = true;
                            break;
                        case 3://// 3 - skip this cell
                            bSkip = true;
                            break;
                        default:
                            break;
                    }
                    if (bSkip) continue;

                    sCellBaseline = _excelBaseline.getOneCellValue(i, j);
                    sCellCompare = _excelCompare.getOneCellValue(i, j);



                    if (!sCellBaseline.Equals(sCellCompare))
                    {
                        iTotalErrorCellNumber++;
                        bMatch = false;

                        double valueBaseline, valueCompare;
                        if (double.TryParse(sCellBaseline, out valueBaseline) && double.TryParse(sCellCompare, out valueCompare) && (!this._dTolerancePercent.Equals(0.0)))
                        {

                            if (Math.Abs((valueBaseline - valueCompare) / valueBaseline) < (this._dTolerancePercent / 100))
                            {
                                _excelCompare.setOneCellColor_Yellow(i, j);
                                if (iTotalErrorCellNumber < iMaxNumOfErrorLogged)
                                    sLogContent = sLogContent + "In Tolerance:  " + this._dTolerancePercent + "%  " + sSheetName + " => Cell(" + i + " ," + j + ")" + "    Baseline: " + sCellBaseline + " <=> Compare: " + sCellCompare + Environment.NewLine;
                            }
                            else
                            {
                                _excelCompare.setOneCellColor_Red(i, j);
                                if (iTotalErrorCellNumber < iMaxNumOfErrorLogged)
                                    sLogContent = sLogContent + "Out Tolerance: " + this._dTolerancePercent + "%  " + sSheetName + " => Cell(" + i + " ," + j + ")" + "    Baseline: " + sCellBaseline + " <=> Compare: " + sCellCompare + Environment.NewLine;
                            }
                        }
                        else
                        {
                            _excelCompare.setOneCellColor_Red(i, j);
                            if (iTotalErrorCellNumber < iMaxNumOfErrorLogged)
                                sLogContent = sLogContent + "Not Match:    " + sSheetName + " => Cell(" + i + " ," + j + ")" + "    Baseline: " + sCellBaseline + " <=> Compare: " + sCellCompare + Environment.NewLine;
                        }
                        if (iTotalErrorCellNumber == iMaxNumOfErrorLogged)
                            sLogContent = sLogContent + "**********    More error cells (exceeds  " + iMaxNumOfErrorLogged + " ) are NOT logged here, pleae refer to its Excel file!   ********** " + Environment.NewLine;
                    }
                }
            }
            _excelBaseline.SaveExcel();
            _excelBaseline.CloseExcelApplication();
            _excelCompare.SaveExcel();
            _excelCompare.CloseExcelApplication();



            if (!bMatch)
                this._Report(_PassFailStep.Fail, sReportName + " - " + sSheetName, sLogContent);
            else
                this._Report(_PassFailStep.Pass, sReportName + " - " + sSheetName, sLogContent);

            _gLib._KillProcessByName("notepad");


        }



        public void _Report(_PassFailStep eStatus, string sReportName, string sContent)
        {
            if (!Config.bGenerateReport)
                return;


            if (eStatus.Equals(_PassFailStep.Description))
            {
                bool bThreadFinsihed = false;

                while(!bThreadFinsihed)
                {
                    bThreadFinsihed = Config.bThreadFinsihed;
                    _gLib._Wait(1);

                }
                
                ////////////Boolean bReady = false;
                ////////////int iTime = 0;

                ////////////while (!bReady && iTime < 200)
                ////////////{
                ////////////    int iMaxTry = 0;
                ////////////    Process[] lstProcess = Process.GetProcessesByName("EXCEL");

                ////////////    for (int i = 0; i < 20; i++)
                ////////////    {
                ////////////        lstProcess = Process.GetProcessesByName("EXCEL");
                ////////////        Boolean xlsExists = true;
                ////////////        if (lstProcess.Length != 0)
                ////////////            xlsExists = true;
                ////////////        else
                ////////////            xlsExists = false;

                ////////////        if (!xlsExists)
                ////////////            iMaxTry++;

                ////////////        _gLib._Wait(1);
                ////////////    }

                ////////////    if (iMaxTry == 20)
                ////////////        bReady = true;


                ////////////    iTime++;

                ////////////}

                ////////////_gLib._KillProcessByName("EXCEL");

                ////////////////////_gLib._MsgBox("Ready to go", "-------");

            }







            Config.bThreadFinsihed = false;


            string sDir_Local = Directory.GetCurrentDirectory();
            string sDir_NetDrive = @"\\mercer.com\US_Data\Shared\DFL\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK REPORTS\CUIT\";

            for (int i = 0; i < 3; i++)
            {
                DirectoryInfo info = Directory.GetParent(sDir_Local);
                sDir_Local = info.FullName;
            }

            ////// this is for VS2012 folder sturcture
            sDir_Local = sDir_Local + "\\" + Config._ReturnProjectName() + "\\_TestLog\\";

            //////sDir_Local = sDir_Local + "\\_TestLog\\";

            if (_gLib._DirExists(sDir_Local))
            {

                switch (eStatus)
                {
                    case _PassFailStep.Step:
                        sContent = "STEP: " + Environment.NewLine + sContent + Environment.NewLine;
                        break;
                    case _PassFailStep.Pass:
                        sContent = "PASS:   " + sReportName + Environment.NewLine + sContent + Environment.NewLine;
                        break;
                    case _PassFailStep.Fail:
                        sContent = "FAIL:   " + sReportName + Environment.NewLine + sContent + Environment.NewLine;
                        break;
                    case _PassFailStep.Header:
                        sContent = "##########\t\t" + sContent + "\t\t##########" + Environment.NewLine;
                        break;
                    case _PassFailStep.Description:

                        sContent = "----------------->    " + sContent + "    <-----------------" + Environment.NewLine + Environment.NewLine;
                        break;

                }

                if (_gLib._FileExists(sDir_Local + _gLib._ReturnDateStampYYYYMMDD() + "_" + this._sClient + "_Res.txt", false) && eStatus == _PassFailStep.Header)
                    return; // log file already created, means Header must be added, no need to add again
                // create the directory using datetime stamp if it does not exist
                File.AppendAllText(sDir_Local + _gLib._ReturnDateStampYYYYMMDD() + "_" + this._sClient + "_Res.txt", sContent + Environment.NewLine);

                if (_gLib._FileExists(sDir_NetDrive + _gLib._ReturnDateStampYYYYMMDD() + "_" + this._sClient + "_Res.txt", false) && eStatus == _PassFailStep.Header)
                    return; // log file already created, means Header must be added, no need to add again
                File.AppendAllText(sDir_NetDrive + _gLib._ReturnDateStampYYYYMMDD() + "_" + this._sClient + "_Res.txt", sContent + Environment.NewLine);
            
            }
        }


        public void _SetTolerance(double dPercent)
        {
            this._dTolerancePercent = dPercent;
        }


        public void _ClearTolerance()
        {
            this._dTolerancePercent = 0.0;
        }


        private int _SkipAnswer(int iRow, int iCol, int[,] Cells_Skip)
        {

            //// 0 - Not skip
            //// 1 - skip this row
            //// 2 - skip this column
            //// 3 - skip this cell

            for (int i = 0; i < Cells_Skip.Length / Cells_Skip.Rank; i++)
            {
                if ((Cells_Skip[i, 0] == iRow) && (Cells_Skip[i, 1] == 0))
                    return 1; // skip this row
                if ((Cells_Skip[i, 1] == iCol) && (Cells_Skip[i, 0] == 0))
                    return 2; // skip this column
                if ((Cells_Skip[i, 0] == iRow) && (Cells_Skip[i, 1] == iCol))
                    return 3; // skip this cell
            }

            return 0; // Not skip
            
        }

        private void _CloseMsgBox()
        {

            /////MessageBox.Show(sReportName, "Comparing Reports.......Leaving me alone!", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            // get the main window
            AutomationElement root = AutomationElement.FromHandle(Process.GetCurrentProcess().MainWindowHandle);
            if (root == null)
                return;

            // it should implement the Window pattern
            object pattern;
            if (!root.TryGetCurrentPattern(WindowPattern.Pattern, out pattern))
                return;

            WindowPattern window = (WindowPattern)pattern;
            if (window.Current.WindowInteractionState != WindowInteractionState.ReadyForUserInteraction)
            {
                // get sub windows
                foreach (AutomationElement element in root.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window)))
                {
                    // hmmm... is it really a window?
                    if (element.TryGetCurrentPattern(WindowPattern.Pattern, out pattern))
                    {
                        // if it's ready, try to close it
                        WindowPattern childWindow = (WindowPattern)pattern;
                        if (childWindow.Current.WindowInteractionState == WindowInteractionState.ReadyForUserInteraction)
                        {
                            childWindow.Close();
                        }
                    }
                }
            }
        }



        private void _PrintCurrentReport(string sReportName)
        {

            string sDir = Directory.GetCurrentDirectory();
            for (int i = 0; i < 3; i++)
            {
                DirectoryInfo info = Directory.GetParent(sDir);
                sDir = info.FullName;
            }


            ////sDir = sDir + "\\_Reports\\";

            ///////
            sDir = sDir + "\\" + Config._ReturnProjectName() + "\\_Reports\\";

            if (File.Exists(sDir + "Comparing_Report------.txt"))//////if (_gLib._FileExists(sDir + "Comparing_Report------.txt", false))
                File.Delete(sDir + "Comparing_Report------.txt");

            File.AppendAllText(sDir + "Comparing_Report------.txt",  Environment.NewLine + Environment.NewLine + Environment.NewLine + "            I am comparing below report now......" + Environment.NewLine + Environment.NewLine);

            File.AppendAllText(sDir + "Comparing_Report------.txt", Environment.NewLine + Environment.NewLine + "            " + sReportName + Environment.NewLine);

            string sFile = sDir + "Comparing_Report------.txt";
            ProcessStartInfo startInfo = new ProcessStartInfo(sFile) { WindowStyle = ProcessWindowStyle.Normal };
            System.Diagnostics.Process.Start(startInfo);


        }

    }


}
