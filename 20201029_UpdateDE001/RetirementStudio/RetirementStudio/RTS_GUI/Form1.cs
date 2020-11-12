using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Reflection;
using System.Diagnostics;


namespace RTS_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void loadTestData_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\webber-ling\Desktop\_RTS\RetirementStudio";
                openFileDialog.Filter = "All files (*.*)|*.*|xls files (*.xls)|*.xls|xlsx files (*.xlsx)|*.xlsx";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    filePath = openFileDialog.FileName;

                    //////////Read the contents of the file into a stream
                    ////////var fileStream = openFileDialog.OpenFile();

                    ////////using (StreamReader reader = new StreamReader(fileStream))
                    ////////{
                    ////////    fileContent = reader.ReadToEnd();
                    ////////}

                    MyExcel _testData = new MyExcel(filePath, false);

                    if (!_testData.OpenExcelFile("Sheet1"))
                    {
                        MessageBox.Show("Fail to open excel: " + filePath, "Warning", MessageBoxButtons.OK);
                        return;
                    }


                    int iTotalRow = _testData.getTotalRowCount();

                    listBox1.Items.Add("#NumOfEE  -  ClientShortName  -  RunType");
                    for (int i = 2; i <= iTotalRow; i++)
                    {
                        string sRun = _testData.getOneCellValue(i, 1);
                        string sTotalEE = _testData.getOneCellValue(i, 2);
                        string sRunType = _testData.getOneCellValue(i, 3);
                        string sClientShortName = _testData.getOneCellValue(i, 4);

                        string info = sTotalEE + "          -          " + sClientShortName + "         -         " + sRunType;
                        //////MessageBox.Show(info, "Warning", MessageBoxButtons.OK);

                        if(sRun.ToUpper().Equals("YES"))
                            listBox1.Items.Add(info);
                    }

                    listBox1.Items.Add("-------------------------  Loading Testing Data Compelete -------------------------");
                    listBox1.Items.Add("-------------------------  Click Run Test Button to Start Test-------------------------");

                    



                    _testData.CloseExcelApplication();



                }


                

            }

            //////MessageBox.Show("File Content at path: " + filePath, "Warning", MessageBoxButtons.OK);
        }

        private void runTest_Click(object sender, EventArgs e)
        {
            ///////  MessageBox.Show(sCmd, "Warning", MessageBoxButtons.OK);

            //string sCmd = Directory.GetCurrentDirectory().Replace("RTS_GUI\\bin\\Debug", "autoRun.bat");
            string sCmd = Directory.GetCurrentDirectory() + "\\autoRun.bat";
            ////MessageBox.Show(sCmd, "Warning", MessageBoxButtons.OK);
            System.Diagnostics.Process.Start("CMD.exe", "/C " + sCmd);

            



        }



        public class MyExcel
        {

            public MyExcel()
            {
            }

            public MyExcel(string sFileName, Boolean bExcelVisible)
            {
                excelFileName = sFileName;
                excelApplication = null;
                excelWorkBooks = null;
                excelWorkBook = null;
                excelWorkSheet = null;
                excelActiveWorkSheetIndex = 1;
                excelVisible = bExcelVisible;


            }


            #region Variables
            private Excel.Application excelApplication = null;
            private Excel.Workbooks excelWorkBooks = null;
            private Excel.Workbook excelWorkBook = null;
            private Excel.Worksheet excelWorkSheet = null;
            private Excel.Range excelRange = null;
            private Excel.Range excelCopySourceRange = null;
            private int excelActiveWorkSheetIndex;
            private string excelActiveWorkSheetName;
            private string excelFileName = "";
            private Boolean excelVisible = false;
            #endregion


            /// <summary>
            /// webber
            /// only can be called when excel is opened
            /// </summary>
            /// <returns></returns>
            public int ReturnNumOfSheets()
            {
                int iSheetsNum = 0;
                try
                {
                    iSheetsNum = excelWorkBook.Worksheets.Count;
                }
                catch (Exception ex)
                {
                    //////////////MessageBox.Show("Error happens；\nDetail："
                    //////////////    + e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return iSheetsNum;
            }


            public bool OpenExcelFile(int iSheet)
            {
                if (excelApplication != null) CloseExcelApplication();


                if (!File.Exists(excelFileName))
                {

                    throw new Exception(excelFileName + "File NOT Exist！");
                }
                try
                {
                    excelApplication = new Excel.Application();
                    excelWorkBooks = excelApplication.Workbooks;
                    excelWorkBook = ((Excel.Workbook)excelWorkBooks.Open(excelFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                    excelWorkBook.CheckCompatibility = false;
                    ////excelWorkBook.Unprotect("RTG");
                    excelWorkSheet = ((Excel.Worksheet)excelWorkBook.Worksheets[iSheet]);
                    excelWorkSheet.Unprotect("RTG");
                    excelWorkSheet.Activate();
                    excelApplication.Visible = excelVisible;
                    excelApplication.DisplayAlerts = false;

                    return true;
                }
                catch (Exception e)
                {
                    CloseExcelApplication();
                    MessageBox.Show("Error happens；\nDetail："
                        + e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            /// <summary>
            /// webber
            /// </summary>
            /// <param name="sSheet"></param>
            /// <returns></returns>
            public bool OpenExcelFile(string sSheet)
            {
                if (excelApplication != null) CloseExcelApplication();


                if (!File.Exists(excelFileName))
                {

                    throw new Exception(excelFileName + "File NOT Exist！");
                }
                try
                {
                    excelApplication = new Excel.Application();
                    excelWorkBooks = excelApplication.Workbooks;
                    excelWorkBook = ((Excel.Workbook)excelWorkBooks.Open(excelFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                    ////excelWorkBook.Unprotect("RTG");
                    excelWorkSheet = ((Excel.Worksheet)excelWorkBook.Worksheets[sSheet]);
                    excelWorkSheet.Unprotect("RTG");
                    excelWorkSheet.Activate();
                    excelApplication.Visible = excelVisible;

                    return true;
                }
                catch (Exception e)
                {
                    CloseExcelApplication();
                    MessageBox.Show("Error happens；\nDetail："
                        + e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            public void SaveExcel()
            {
                if (excelFileName == "")
                {
                    throw new Exception("File Name Blank");
                }
                try
                {
                    //excelWorkSheet.SaveAs(excelSaveFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value);
                    //excelWorkSheet.SaveAs(excelFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value);
                    excelWorkBook.Save();

                }
                catch (Exception e)
                {
                    CloseExcelApplication();
                    /////throw new Exception(e.Message);
                }
            }

            /// <summary>
            /// webber
            /// </summary>
            /// <returns></returns>
            public string getActiveSheetName()
            {
                string sActSheetName = "";
                try
                {
                    sActSheetName = excelWorkSheet.Name;
                }
                catch (Exception ex)
                {
                    // do nothing
                }

                return sActSheetName;
            }

            public void CloseExcelApplication()
            {
                try
                {
                    excelWorkBooks = null;
                    excelWorkBook = null;
                    excelWorkSheet = null;
                    excelRange = null;
                    if (excelApplication != null)
                    {
                        ////excelApplication.Workbooks.Close();
                        //Object missing = Type.Missing;
                        excelApplication.Quit();
                        excelApplication = null;
                        //ReleaseAllRef(excelApplication);//Error

                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }

            public string getOneCellValue(int iRow, int icol)
            {
                if (iRow <= 0)
                {
                    throw new Exception("Index out of range！");
                }
                string sValue = "";
                try
                {
                    sValue = ((Excel.Range)excelWorkSheet.Cells[iRow, icol]).Text.ToString();
                }
                catch (Exception e)
                {
                    CloseExcelApplication();
                    throw new Exception(e.Message);
                }
                return (sValue);
            }

            public string[] getCellsValue(string StartCell, string EndCell)
            {
                string[] sValue = null;

                excelRange = (Excel.Range)excelWorkSheet.get_Range(StartCell, EndCell);
                sValue = new string[excelRange.Count];
                int rowStartIndex = ((Excel.Range)excelWorkSheet.get_Range(StartCell, StartCell)).Row;  //起始行号
                int columnStartIndex = ((Excel.Range)excelWorkSheet.get_Range(StartCell, StartCell)).Column; //起始列号
                int rowNum = excelRange.Rows.Count;
                int columnNum = excelRange.Columns.Count;
                int index = 0;
                for (int i = rowStartIndex; i < rowStartIndex + rowNum; i++)
                {
                    for (int j = columnStartIndex; j < columnNum + columnStartIndex; j++)
                    {
                        //读到空值null和读到空串""分别处理
                        sValue[index] = ((Excel.Range)excelWorkSheet.Cells[i, j]).Text.ToString();
                        index++;
                    }
                }
                return (sValue);
            }


            /// <summary>
            /// webber
            /// </summary>
            /// <returns></returns>
            public int getTotalRowCount()
            {

                Excel.Range last = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                Excel.Range range = excelWorkSheet.get_Range("A1", last);

                int lastUsedRow = last.Row;
                //int lastUsedColumn = last.Column;
                return lastUsedRow;
            }

            /// <summary>
            /// webber
            /// </summary>
            /// <returns></returns>
            public int getTotalColumnCount()
            {

                Excel.Range last = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                Excel.Range range = excelWorkSheet.get_Range("A1", last);

                //int lastUsedRow = last.Row;
                int lastUsedColumn = last.Column;
                return lastUsedColumn;
            }



            public int getColumnIndex(string sCol, int iRow = 1)
            {
                int iTotalCol = this.getTotalColumnCount();
                int iCol = -1;
                for (int i = 1; i <= iTotalCol; i++)
                {
                    if (this.getOneCellValue(iRow, i).Equals(sCol))
                    {
                        iCol = i;
                        break;
                    }
                }

                return iCol;
            }

            public Boolean setOneCellValue(int iRow, string sCol, string sValue)
            {

                int iCol = this.getColumnIndex(sCol);

                if (iCol != -1)
                {
                    this.setOneCellValue(iRow, iCol, sValue);
                    return true;
                }
                else
                    return false;

            }

            public void setOneCellValue(int iRow, int iCol, string sValue)
            {
                try
                {
                    excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];
                    excelRange.Value2 = sValue;//Value2?
                    //Gets or sets the value of the NamedRange control.
                    //The only difference between this property and the Value property is that Value2 is not a parameterized property.
                    excelRange = null;
                }
                catch (Exception e)
                {
                    CloseExcelApplication();
                    throw new Exception(e.Message);
                }
            }

            public void setOneCellValueAsText(int iRow, int iCol, string sValue)
            {
                try
                {
                    excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];
                    excelRange.Value2 = "'" + sValue;//Value2?
                    //Gets or sets the value of the NamedRange control.
                    //The only difference between this property and the Value property is that Value2 is not a parameterized property.
                    excelRange = null;
                }
                catch (Exception e)
                {
                    CloseExcelApplication();
                    throw new Exception(e.Message);
                }
            }

            public void setOneRowValues(int iRow, int iCol_Start, int iCol_End, string[] Values)
            {


                if (Values.Length != iCol_End - iCol_Start)
                {
                    throw new Exception("# of Input Values NOT match # of Cell numbers！");
                }
                for (int i = iCol_Start; i <= iCol_End; i++)
                {
                    setOneCellValue(iRow, i, Values[i]);
                }
            }

            public void setCellsBorder(string startCell, string endCell)
            {

                excelRange = excelWorkSheet.get_Range(startCell, endCell);
                excelRange.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                excelRange.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                excelRange.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                excelRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                excelRange.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                //excelRange.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
            }

            public void setOneCellBorder(int iRow, int iCol)
            {
                //
                excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];

                excelRange.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                excelRange.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                excelRange.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                excelRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                //excelRange.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
                //excelRange.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
            }

            public void setColumnWidth(string startCell, string endCell, int size)
            {
                //
                excelRange = excelWorkSheet.get_Range(startCell, endCell);
                excelRange.ColumnWidth = size;
            }

            public void setOneCellFont(int iRow, int iCol, string fontName, int fontSize)
            {
                excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];
                excelRange.Font.Name = fontName;
                excelRange.Font.Size = fontSize;

            }

            public void setOneCellColor_Red(int iRow, int iCol)
            {
                excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];
                excelRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            }

            public void setOneCellColor_Yellow(int iRow, int iCol)
            {
                excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];
                excelRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
            }

            public void setOneCellColor_Green(int iRow, int iCol)
            {
                excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];
                excelRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
            }
            public Boolean expandAllLevels(int iRow, int iCol)
            {
                try
                {
                    excelWorkSheet.Outline.ShowLevels(2, 2);
                    excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];
                    excelRange.Rows.Hidden = false;
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }


            public void setOneCellHorizontalAlignment(int iRow, int iCol, Excel.Constants alignment)
            {
                excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];
                excelRange.HorizontalAlignment = alignment;

            }

            public void SetOneCellColumnWidth(int iRow, int iCol, int size)
            {
                excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];
                excelRange.ColumnWidth = size;

            }

            public void setOneCellNumberFormat(int iRow, int iCol, string numberFormat)
            {
                try
                {
                    excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];
                    excelRange.NumberFormatLocal = numberFormat;

                    excelRange = null;
                }
                catch (Exception e)
                {
                    CloseExcelApplication();
                    throw new Exception(e.Message);
                }
            }

            public void setRowHeight(string startCell, string endCell, int size)
            {
                excelRange = excelWorkSheet.get_Range(startCell, endCell);
                excelRange.RowHeight = size;

            }

            public void setRowHeight(int iRow, int iCol, float size)
            {
                excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];
                excelRange.RowHeight = size;

            }

            public void setOneCellRowHeight(int iRow, int iCol, int size)
            {
                excelRange = (Excel.Range)excelWorkSheet.Cells[iRow, iCol];
                excelRange.RowHeight = size;

            }

            public bool CellValueIsNull(int iRow, int iCol)
            {

                if ((((Excel.Range)excelWorkSheet.Cells[iRow, iCol]).Text.ToString().Trim() != ""))
                    return false;
                return true;
            }

            public void newWorkbook(string fileName)
            {

                excelWorkBook = excelWorkBooks.Add(Missing.Value);
                SaveExcel();
            }

            public void newWorksheet()
            {
                excelWorkBook.Worksheets.Add(Missing.Value, Missing.Value, 1, Missing.Value);
            }

            public void setWorksheetName(int sheetIndex, string worksheetName)
            {
                Excel._Worksheet sheet = (Excel._Worksheet)(excelWorkBook.Worksheets[(object)sheetIndex]);
                sheet.Name = worksheetName;
            }

            public void mergeOneLineCells(string startCell, string endCell)
            {
                excelRange = excelWorkSheet.get_Range(startCell, endCell);
                //excelRange.Merge(true);
                excelRange.MergeCells = true;
            }

            public void HorizontalAlignmentCells(string startCell, string endCell, Excel.Constants alignment)
            {
                excelRange = excelWorkSheet.get_Range(startCell, endCell);
                excelRange.HorizontalAlignment = alignment;
            }

            public void VerticalAlignmentCells(string startCell, string endCell, Excel.Constants alignment)
            {
                excelRange = excelWorkSheet.get_Range(startCell, endCell);
                excelRange.VerticalAlignment = alignment;
            }










        }

    }
}
