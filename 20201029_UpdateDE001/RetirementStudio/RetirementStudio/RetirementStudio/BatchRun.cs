using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using RetirementStudio._TestScripts._TestScripts_US;
using RetirementStudio._TestScripts._TestScripts_CA;
using RetirementStudio._TestScripts._TestScripts_DE;
using RetirementStudio._TestScripts._TestScripts_NL;
using RetirementStudio._TestScripts._TestScripts_UK;
using RetirementStudio._TestScripts._TestScripts_IR;
using RetirementStudio._TestScripts._TestScripts_BR;
using RetirementStudio._TestScripts._TestScripts_ANZ;
using RetirementStudio._TestScripts._TestScripts_Data;
using RetirementStudio._Libraries;
using RetirementStudio._UIMaps.MainClasses;


namespace RetirementStudio
{
    /// <summary>
    /// Summary description for BatchRun
    /// </summary>
    [CodedUITest]
    public class BatchRun
    {
        public BatchRun()
        {
            _Config.Config.bBatchRun = true;
        }

        public Main pMain = new Main();
        public GenericLib_Win _gLib = new GenericLib_Win();
        public string sStudioLaunchDir = @"C:\Users\Ruiyang-song\Desktop\QA1_20160929.1\Client\RetirementStudio.exe";
            
        public void _TestSetUp()
        {
            
            pMain._SetLanguageAndRegional();
            //_gLib._KillProcessByName("RetirementStudio");
            //_gLib._Cmd(sStudioLaunchDir);
            //pMain._SelectTab("Home");
            //_gLib._KillProcessByName("Mercer.RetirementStudio.Messaging.MessagingClientApp");

        }


        [TestMethod]
        [Timeout(100 * 60 * 60 * 1000)]
        public void tes_BatchRun()
        {

         
            /////// ####################################    US DNT    #################################### ///////

            //US001_DNT testUS001_DNT = new US001_DNT();
            //this._TestSetUp();
            //testUS001_DNT.test_US001_DNT();


            //US006_DNT testUS006_DNT = new US006_DNT();
            //this._TestSetUp();
            //testUS006_DNT.test_US006_DNT();


            //US007_DNT testUS007_DNT = new US007_DNT();
            //this._TestSetUp();
            //testUS007_DNT.test_US007_DNT();


            //US008_DNT testUS008_DNT = new US008_DNT();
            //this._TestSetUp();
            //testUS008_DNT.test_US008_DNT();

            //US010_DNT testUS010_DNT = new US010_DNT();
            //this._TestSetUp();
            //testUS010_DNT.test_US010_DNT();

            //US011_DNT testUS011_DNT = new US011_DNT();
            //this._TestSetUp();
            //testUS011_DNT.test_US011_DNT();

            //US012_DNT testUS012_DNT = new US012_DNT();
            //this._TestSetUp();
            //testUS012_DNT.test_US012_DNT();

            //US014_DNT testUS014_DNT = new US014_DNT();
            //this._TestSetUp();
            //testUS014_DNT.test_US014_DNT();

            //US015_DNT testUS015_DNT = new US015_DNT();
            //this._TestSetUp();
            //testUS015_DNT.test_US015_DNT();
            
            //US016_DNT testUS016_DNT = new US016_DNT();
            //this._TestSetUp();
            //testUS016_DNT.test_US016_DNT();


            //US017_DNT testUS017_DNT = new US017_DNT();
            //this._TestSetUp();
            //testUS017_DNT.test_US017_DNT();



            /////// ####################################    CA DNT    #################################### ///////

            ////CA001_DNT testCA001_DNT = new CA001_DNT();
            ////this._TestSetUp();
            ////testCA001_DNT.test_CA001_DNT();

            //CA002_DNT testCA002_DNT = new CA002_DNT();
            //this._TestSetUp();
            //testCA002_DNT.test_CA002_DNT();

            //CA003_DNT testCA003_DNT = new CA003_DNT();
            //this._TestSetUp();
            //testCA003_DNT.test_CA003_DNT();


            /////// ####################################    DE DNT    #################################### ///////

            //DE005_DNT testDE005_DNT = new DE005_DNT();
            //this._TestSetUp();
            //testDE005_DNT.test_DE005_DNT();


            //DE007_DNT testDE007_DNT = new DE007_DNT();
            //this._TestSetUp();
            //testDE007_DNT.test_DE007_DNT();




            /////// ####################################    NL DNT    #################################### ///////

            //NL002_DNT testNL002 = new NL002_DNT();
            //this._TestSetUp();
            //testNL002.test_NL002_DNT();


            //NL003_DNT testNL003 = new NL003_DNT();
            //this._TestSetUp();
            //testNL003.test_NL003_DNT();


            //NL004_DNT testNL004 = new NL004_DNT();
            //this._TestSetUp();
            //testNL004.test_NL004_DNT();


            /////// ####################################    BR DNT    #################################### ///////

            //BR001_CN testBR001_CN = new BR001_CN();
            //this._TestSetUp();
            //testBR001_CN.test_BR001_CN();

            //BR002_CN testBR002_CN = new BR002_CN();
            //this._TestSetUp();
            //testBR002_CN.test_BR002_CN();

            //BR003_CN testBR003_CN = new BR003_CN();
            //this._TestSetUp();
            //testBR003_CN.test_BR003_CN();

            //BR004_CN testBR004_CN = new BR004_CN();
            //this._TestSetUp();
            //testBR004_CN.test_BR004_CN();



            _gLib._MsgBoxYesNo("Congratulations!", "Click Yes or No to quit test!");

            Environment.Exit(0);



        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
        }

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }

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
