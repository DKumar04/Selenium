using Selenium.Tests.FunctionLibrary;
using Selenium.Tests.FunctionLibrary.Pages;
using Selenium.Tests.FunctionLibrary.TestMethods;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Selenium.Tests.ExecutionEngine
{
    public class DriverScript
    {
        #region Instance Variables
        public static string keywordFilePath = @"TestFiles\TestCase.xlsx";
        public static string sheetName = "Test Steps";
        #endregion

        public static void Main(string[] args)
        {
            Utilities utils = new Utilities();
            utils
                .OpenBrowser()
                .Run_TestCase(keywordFilePath, sheetName)
                .CloseBrowser();
        }
    }
}
