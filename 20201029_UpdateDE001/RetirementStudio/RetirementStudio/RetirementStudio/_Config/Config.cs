using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementStudio._Config
{

    public enum _PassFailStep { Pass, Fail, Warning, Step, Header, Description };

    public enum _SearchType { Button, Edit, CheckBox, RadioButton, Table, ComboBox, List, HyperLink };

    public enum _SearchBy { Name, FriendlyName, LabeledBy, ID, InnerText };

    public enum _TestingEnv { QA1, QA2, QA3, QA4, QA5, Preprod_US, Prod_US, Preprod_CA, Prod_CA, Preprod_EU, Prod_EU, Dev3, Dev2, DevCurrent }

    public enum _Country { US, CA, DE, UK, NL, IR, BR, ANZ }

    public enum _BenchmarkUser { Lori, Cindy, Shane, Webber, Yolanda, Others }



    class Config
    {

        public static _TestingEnv eEnv;
        public static _Country eCountry;
        public static string sTester;
        public static string sStudioLaunchDir;
        public static string sDataCenter;
        public static string sClientName;
        public static string sClientName_F;
        public static string sClientName_D;
        public static string sClientName_B;
        public static string sClientName_E;
        public static string sClientName_US;
        public static string sClientName_CA;
        public static string sClientName_DE;
        public static string sPlanName_B;
        public static string sPlanName_E;
        public static string sPlanName;
        public static string sPlanName_F;
        public static string sPlanName_D;
        public static string sPlanName2;
        public static string sPlanName_US;
        public static string sPlanName_DE;
        public static string sPlanName_CA;
        public static string sService;
        public static string sService_US;
        public static string sService_DE;
        public static string sService_CA;
        public static string sProductionVerison;
        public static int iER_SubmitTime = 300;
        public static int iER_CompleteTime = 3600;
        public static Boolean bCompareReports;
        public static Boolean bDownloadReports_PDF;
        public static Boolean bDownloadReports_EXCEL;
        public static Boolean bReportsStoreLocal = false;
        public static Boolean bBatchRun = false;
        public static Boolean bThreadFinsihed = true;
        public static Boolean bHighlight = false;
        

        #region Common Fields

        public static Boolean bDrawHighlight = false;
        public static int iTimeout = 600;
        public static int iSearchInterval = 15;
        public static int iWaitShort = 3;
        public static int iWaitMedium = 6;
        public static int iWaitLong = 9;
        public static int iClickPos_X = 3;
        public static int iClickPos_Y = 3;
        public static Boolean bGenerateReport = true;
        public static Boolean bGenerateScreenCapture = false;
        public static Boolean bExcelVisible = false;
        public static Boolean bLogTime = true;

        #endregion

        static public string _ReturnProjectName()
        {
            string s = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return s.Substring(0, s.Length - 4);
        }


    }
}
