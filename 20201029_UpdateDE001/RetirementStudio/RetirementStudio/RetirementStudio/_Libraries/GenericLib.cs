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


using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using RetirementStudio._Config;


namespace RetirementStudio._Libraries
{


    public class GenericLib
    {

        public void _CheckScreenResolution(int iX, int iY)
        {
            int iX_Act = Screen.PrimaryScreen.Bounds.Width + 2;
            int iY_Act = Screen.PrimaryScreen.Bounds.Height;
            if ((iY_Act != iY) || (iX_Act != iX))
                this._MsgBoxYesNo("Continue Testing?", "Expcected Screen size (" + iX + ", " + iY + "), Actual size (" + iX_Act + ", " + iY_Act + ")");

        }

        public void _KillProcessByName(string sProcess)
        {

            //////////Process[] pro = Process.GetProcesses();

            foreach (Process proc in Process.GetProcessesByName(sProcess))
            {
                try
                {
                    proc.Kill();
                }
                catch (Exception ex)
                {
                    ////////////MessageBox.Show(ex.Message);
                }
            }



        }

        public void _MsgBox(string sTitle, string sMsg)
        {
            for (int i = 0; i <= 3; i++)
            {
                Console.Beep(1000, 200);
                Console.Beep(1500, 200);
            }

            if (!Config.bBatchRun)
                MessageBox.Show(sMsg, sTitle);
        }

        public void _MsgBoxYesNo(string sTitle, string sMsg)
        {
            for (int i = 0; i <= 6; i++)
            {
                Console.Beep(1000, 100);
                Console.Beep(1500, 100);
            }


            if (MessageBox.Show(sMsg, sTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Console.WriteLine("yes");
            }
            else
            {
                //Console.WriteLine("no");
                Environment.Exit(0);
            }

        }

        public void _Report(_PassFailStep eStatus, string sContent)
        {
            if (!Config.bGenerateReport)
                return;

            string sDir = Directory.GetCurrentDirectory();
            for (int i = 0; i < 3; i++)
            {
                DirectoryInfo info = Directory.GetParent(sDir);
                sDir = info.FullName;
            }

            // this is for VS2012 folder sturcture
            sDir = sDir + "\\" + Config._ReturnProjectName() + "\\_TestLog\\";

            ////////sDir = sDir + "\\_TestLog\\";

            if (this._DirExists(sDir))
            {

                switch (eStatus)
                {
                    case _PassFailStep.Step:
                        sContent = "STEP: " + sContent;
                        break;
                    case _PassFailStep.Pass:
                        sContent = "PASS: " + sContent;
                        break;
                    case _PassFailStep.Fail:
                        sContent = "FAIL: " + sContent;
                        break;
                    case _PassFailStep.Header:
                        sContent = "##########\t\t" + sContent + "\t\t##########" + Environment.NewLine;
                        break;
                    case _PassFailStep.Description:
                        sContent = "-------->" + sContent;
                        break;

                }

                if (this._FileExists(sDir + this._ReturnDateStampYYYYMMDD() + ".txt", false) && eStatus == _PassFailStep.Header)
                    return; // log file already created, means Header must be added, no need to add again

                File.AppendAllText(sDir + this._ReturnDateStampYYYYMMDD() + ".txt", sContent + Environment.NewLine);

                // create the directory using datetime stamp if it does not exist or current one size > 500K
                FileInfo fInfo = new FileInfo(sDir + this._ReturnDateStampYYYYMMDD() + ".txt");
                if (Convert.ToInt32(fInfo.Length / 1024) > 500)
                    File.Delete(sDir + this._ReturnDateStampYYYYMMDD() + ".txt");


            }
        }

        public void _PrintReportDirectory(string sReportDirectories)
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

            if (this._FileExists(sDir + "TempReportsDir.txt", false))
                File.Delete(sDir + "TempReportsDir.txt");

            File.AppendAllText(sDir + "TempReportsDir.txt", "### This is the temp file to store reports directory, it is under _Reports folder ###" + Environment.NewLine + Environment.NewLine);
            File.AppendAllText(sDir + "TempReportsDir.txt", sReportDirectories + Environment.NewLine);

            System.Diagnostics.Process.Start(sDir + "TempReportsDir.txt");


        }

        public Boolean _FileExists(string sFile, Boolean bVerify)
        {
            return this._FileExists(sFile, 5, bVerify);
        }

        public Boolean _FileExists(string sFile, int iTimeout, Boolean bVerify)
        {
            Boolean bExists = false;

            for (int i = 0; i <= iTimeout + 3; i++)
            {
                bExists = File.Exists(sFile);
                if (bExists)
                    break;
                else
                    this._Wait(1);
            }

            if (bExists)
                bExists = true;
            else
            {
                if (bVerify)
                {
                    if (MessageBox.Show("File <" + sFile + "> does NOT exist in <" + iTimeout + "> seconds!", "Continue Testing ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        bExists = false;
                    else
                        Environment.Exit(0);
                }
            }
            return bExists;
        }

        public Boolean _DirExists(string sDir)
        {
            Boolean bExists = false;

            bExists = Directory.Exists(sDir);

            if (bExists)
                bExists = true;
            else
            {
                if (MessageBox.Show("Folder <" + sDir + "> does NOT exist!", "Continue Testing ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    bExists = false;
                else
                    Environment.Exit(0);
            }

            return bExists;
        }

        public Boolean _DirExists(string sDir, Boolean bVerify)
        {
            Boolean bExists = false;

            bExists = Directory.Exists(sDir);

            if (bExists)
                bExists = true;
            else
            {
                if (bVerify)
                {
                    if (MessageBox.Show("Folder <" + sDir + "> does NOT exist!", "Continue Testing ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        bExists = false;
                    else
                        Environment.Exit(0);
                }
            }

            return bExists;
        }


        /// 2013-08-01 Webber.ling@mercer.com
        /// To create specified directory, its parent folder must exists
        /// If the directory already exists, warning msgbox will popup with option to quit or replace 
        public string _CreateDirectory(string sDir)
        {

            return this._CreateDirectory(sDir, true);

        }

        public string _CreateDirectory(string sDir, Boolean bWarningIfReplace)
        {

            if (this._DirExists(sDir, false))
            {

                if (bWarningIfReplace)
                {
                    if (MessageBox.Show("Folder <" + sDir + "> already exist!", "Are you going to create new one by deleting current one, Continue ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Directory.Delete(sDir, true);
                    else
                        Environment.Exit(0);
                }
                else
                    Directory.Delete(sDir, true);
            }

            Directory.CreateDirectory(sDir);
            return sDir;

        }

        public string _DeleteDirectory(string sDir)
        {
            if (this._DirExists(sDir, false))
                Directory.Delete(sDir, true);
            return sDir;
        }

        public void _StudioClearCache()
        {
            //string dir_1 = "C:\\Users\\"+ Environment.UserName + "\\AppData\\Local\\IsolatedStorage";
            //string dir_2 = "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Retirement Studio";

            //this._DeleteDirectory(dir_1);
            //this._DeleteDirectory(dir_2);
        }

        public string _ReturnDateStampYYYYMMDD()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        public string _ReturnDateStampYYYYMMDDHHMMSS()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");

        }

        public void _Wait(double iSecond)
        {
            Thread.Sleep(Convert.ToInt32(iSecond * 500));
            ////Playback.Wait(Convert.ToInt32(iSecond * 500));
            Playback.Wait(Convert.ToInt32(iSecond * 500));
        }

        private void _CaptureScreen(string sFileName)
        {
            ScreenCapture sc = new ScreenCapture();
            sc.CaptureScreenToFile(sFileName + ".png", ImageFormat.Png);

        }

        /// <summary>
        /// Sample:
        /// 
        /// _gLib._CaptureScreen(sFunctionName);
        /// 
        /// </summary>
        /// <param name="sFileName"></param>
        public void _CaptureScreen_PopVerify(string sFileName)
        {
            if (!Config.bGenerateScreenCapture)
                return;

            string sDir = Directory.GetCurrentDirectory();
            for (int i = 0; i < 3; i++)
            {
                DirectoryInfo info = Directory.GetParent(sDir);
                sDir = info.FullName;
            }

            this._CaptureScreen(sDir + "\\" + Config._ReturnProjectName() + "\\_ScreenCapture\\" + sFileName);
        }


        public _BenchmarkUser _ReturnCurrentUser()
        {
            switch (Environment.UserName)
            {
                case "cindy-geske":
                    return _BenchmarkUser.Cindy;
                case "webber-ling":
                    return _BenchmarkUser.Webber;
                case "yolanda-zhang":
                    return _BenchmarkUser.Yolanda;
                case "huiqing-zhu":
                    return _BenchmarkUser.Shane;
                case "ruiyang-song":
                    return _BenchmarkUser.Lori;
                default:
                    return _BenchmarkUser.Webber;
            }

        }


        public void _Cmd(string sCommand)
        {
            Process.Start(sCommand);
        }

        public void _CopyFile(string sSourceFile, string sTargetFile)
        {
            string sTargetFolder = Path.GetDirectoryName(sTargetFile);

            if (!this._DirExists(sTargetFolder, false))
                this._CreateDirectory(sTargetFolder);

            File.Copy(sSourceFile, sTargetFile, true);
        }



        /**
         * sample:
         *     _gLib._batchUpdateFilePostfix(@"C:\Users\ruiyang-song\Desktop\New folder", ".xlsx", ".xls");
         */
        public void _batchUpdateFilePostfix(string sfolderPath, string sourcePostFix , string targetPostfix )
        {
            DirectoryInfo folder = new DirectoryInfo(sfolderPath);

            FileInfo[] list = folder.GetFiles("*" + sourcePostFix); 

            foreach (FileInfo file in list)
            {
                file.MoveTo(file.DirectoryName + "\\" + file.Name.Replace(sourcePostFix, targetPostfix));
            }

            this._MsgBoxYesNo("", "bat update file postfix finished, click Yes to continue, click No to stop case");
        }
    }



    public class MyDictionary : Dictionary<string, string>
    {
        public Dictionary<string, string> mydic = new Dictionary<string, string>();


        public string this[string name]
        {
            get
            {
                string sItem;
                if (!mydic.TryGetValue(name, out sItem))
                {
                    sItem = new string("".ToString().ToCharArray());
                    //mydic.Add(name, sItem);
                }
                return sItem;
            }
        }

        public void Add(string sKey, string sValue)
        {
            mydic.Add(sKey, sValue);
        }

        public void Clear()
        {
            mydic.Clear();
        }

        public int Count
        {
            get { return mydic.Count; }
        }

    }


    public class ScreenCapture
    {
        /// <summary>
        /// Creates an Image object containing a screen shot of the entire desktop
        /// </summary>
        /// <returns></returns>
        public Image CaptureScreen()
        {
            return CaptureWindow(User32.GetDesktopWindow());
        }

        /// <summary>
        /// Creates an Image object containing a screen shot of a specific window
        /// </summary>
        /// <param name="handle">The handle to the window. (In windows forms, this is obtained by the Handle property)</param>
        /// <returns></returns>
        public Image CaptureWindow(IntPtr handle)
        {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            // create a device context we can copy to
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            // select the bitmap object
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
            // bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            // restore selection
            GDI32.SelectObject(hdcDest, hOld);
            // clean up 
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);

            // get a .NET image object for it
            Image img = Image.FromHbitmap(hBitmap);
            // free up the Bitmap object
            GDI32.DeleteObject(hBitmap);

            return img;
        }

        /// <summary>
        /// Captures a screen shot of a specific window, and saves it to a file
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
        {
            Image img = CaptureWindow(handle);
            img.Save(filename, format);
        }

        /// <summary>
        /// Captures a screen shot of the entire desktop, and saves it to a file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        public void CaptureScreenToFile(string filename, ImageFormat format)
        {
            Image img = CaptureScreen();
            img.Save(filename, format);
        }

        /// <summary>
        /// Helper class containing Gdi32 API functions
        /// </summary>
        private class GDI32
        {

            public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter

            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        /// <summary>
        /// Helper class containing User32 API functions
        /// </summary>
        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);

        }


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





        ////实现列号-〉字母 (26-〉Z,27->AA)
        //private string ConvertColumnIndexToChar(int columnIndex)
        //{
        //    if (columnIndex < 1 || columnIndex > 256)
        //    {
        //        MessageBox.Show("columnIndex=" + columnIndex + ",out of range（1-256）");
        //        return "A";
        //    }
        //    if (columnIndex >= 1 && columnIndex <= 26)//1--26
        //    {
        //        return "AA";
        //    }
        //    if (columnIndex >= 27 && columnIndex <= 256)//27--256
        //    {
        //        return "AA";
        //    }
        //    return "A";
        //}






    }


    /// example: 
    //////MyTimer mT = new MyTimer("TestCol", @"c:\test\test.xlsx", "TimingSheet");
    //////mT.StartTimer();
    //////_gLib._Wait(5); // timing scenario
    //////mT.StopTimer(2);

    public class MyTimer
    {

        public MyTimer()
        { }

        public MyTimer(string sCol, string sLogFile, string sSheet = "Sheet1")
        {
            this.sLogFile = sLogFile;
            this.sSheet = sSheet;
            this.sCol = sCol;
        }

        private string sLogFile = "";
        private string sSheet = "";
        private string sCol = "";

        private Stopwatch MyStopwatch = new Stopwatch();
        private int iTimeElapsed = 0;

        public void StartTimer()
        {
            MyStopwatch.Restart();
        }

        public void StopTimer(int iRow)
        {
            MyStopwatch.Stop();
            this.iTimeElapsed = (int)((MyStopwatch.ElapsedMilliseconds + 100) / 1000);
            if (this.iTimeElapsed <= 1)
                this.iTimeElapsed = 1;

            this.LogTime(iRow);

        }

        private void LogTime(int iRow)
        {
            MyExcel _excelLog = new MyExcel(sLogFile, Config.bExcelVisible);
            _excelLog.OpenExcelFile(sSheet);

            Boolean bSuccess = _excelLog.setOneCellValue(iRow, sCol, this.iTimeElapsed.ToString());

            _excelLog.SaveExcel();
            _excelLog.CloseExcelApplication();

            if (!bSuccess)
            {
                GenericLib gLib = new GenericLib();
                gLib._MsgBoxYesNo("Continue Testing? ", "Fail to find Column Name: <" + sCol + "> Please Check! ");
            }

        }

    }

    /// <summary>
    ///  example:
    ///         MyLog mLog_Memory = new MyLog("Memory", @"c:\test\test.xlsx", "TimingSheet");
    ///         mLog_Memory.LogInfo(2, MyPerformanceCounter.Memory_Private);
    /// </summary>
    public class MyLog
    {

        public MyLog()
        { }

        public MyLog(int iCol, string sLogFile, string sSheet = "Sheet1")
        {
            this.sLogFile = sLogFile;
            this.sSheet = sSheet;
            this.iCol = iCol;
        }
        public MyLog(string sCol, string sLogFile, string sSheet = "Sheet1")
        {
            this.sLogFile = sLogFile;
            this.sSheet = sSheet;
            this.sCol = sCol;
        }

        private string sLogFile = "";
        private string sSheet = "";
        private string sCol = "";
        private int iCol = 0;

        public void LogInfo(int iRow, string sValue)
        {
            MyExcel _excelLog = new MyExcel(sLogFile, Config.bExcelVisible);
            _excelLog.OpenExcelFile(sSheet);

            Boolean bSuccess = _excelLog.setOneCellValue(iRow, sCol, sValue);

            _excelLog.SaveExcel();
            _excelLog.CloseExcelApplication();

            if (!bSuccess)
            {
                GenericLib gLib = new GenericLib();
                gLib._MsgBoxYesNo("Continue Testing? ", "Fail to find Column Name: <" + sCol + "> Please Check! ");
            }

        }


        public void LogInfo(int iRow, int iCol, string sValue)
        {
            MyExcel _excelLog = new MyExcel(sLogFile, Config.bExcelVisible);
            _excelLog.OpenExcelFile(sSheet);

            _excelLog.setOneCellValue(iRow, iCol, sValue);

            _excelLog.SaveExcel();
            _excelLog.CloseExcelApplication();


        }

        public void LogInfo(int iCol, List<string> lsValue)
        {
            MyExcel _excelLog = new MyExcel(sLogFile, Config.bExcelVisible);
            _excelLog.OpenExcelFile(sSheet);

            for (int i = 0; i < lsValue.Count; i++)
                _excelLog.setOneCellValue(i + 1, iCol, lsValue[i]);

            _excelLog.SaveExcel();
            _excelLog.CloseExcelApplication();


        }

        public void LogPass(int iRow, string sValue = "")
        {
            MyExcel _excelLog = new MyExcel(sLogFile, Config.bExcelVisible);
            _excelLog.OpenExcelFile(sSheet);

            if (sValue != "")
                _excelLog.setOneCellValue(iRow, iCol, sValue);

            _excelLog.setOneCellColor_Green(iRow, this.iCol);

            _excelLog.SaveExcel();
            _excelLog.CloseExcelApplication();

        }

        public void LogFail(int iRow, string sValue = "")
        {
            MyExcel _excelLog = new MyExcel(sLogFile, Config.bExcelVisible);
            _excelLog.OpenExcelFile(sSheet);

            if (sValue != "")
                _excelLog.setOneCellValue(iRow, iCol, sValue);

            _excelLog.setOneCellColor_Yellow(iRow, this.iCol);

            _excelLog.SaveExcel();
            _excelLog.CloseExcelApplication();



        }




    }


    static public class MyPerformanceCounter
    {


        static private string sProcessName = "RetirementStudio";

        static public string Memory_Private
        {
            get
            {
                var counter = new PerformanceCounter("Process", "Working Set - Private", sProcessName);
                string sMem = (counter.RawValue / 1024).ToString();
                counter.Dispose();
                return sMem;
            }
        }



    }




}
