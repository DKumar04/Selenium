using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Threading;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Selenium.Tests.FunctionLibrary.Pages;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Net;

namespace Selenium.Tests.FunctionLibrary
{
    public class Utilities
    {
        private IWebDriver driver;
        private static ISheet excelWSheet;
        private XSSFWorkbook excelWBook;
        public List<MethodInfo> MethodInfo;
        public static string ActionKeyword;
        public LoginPage LoginPage;
        public readonly string Username = "";
        public readonly string Password = "";
        private WebDriverWait wait;
        public static readonly string KEYWORD_FAIL = "FAIL";
        public static readonly string KEYWORD_PASS = "PASS";
        public const int iResultCol = 4;
        public const int iKeywordCol = 3; 

        #region Public Methods   
        public Utilities OpenBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            options.AddArgument("start-maximized");
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            driver = new ChromeDriver(@"C:\selenium",options);
            return this;
        }

        public void GoToUrl(string linkText)
        {
            driver.Navigate().GoToUrl(linkText);
        }

        public IWebElement FindElement(By statement,bool ignoreSpinnerCheck = false)
        {
            if (!ignoreSpinnerCheck)
            {
                WaitUntilLoadingSpinnerIsGone();
            }
            try
            {
                return driver.FindElement(statement);
            }
            catch (Exception e)
            {
                Assert.Fail("No such element found {0}" + statement, e.Message, e.StackTrace, e.InnerException);
                return null;
            }
        }

        public void WaitUntilLoadingSpinnerIsGone()
        {
           
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.PollingInterval = TimeSpan.FromSeconds(4);
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("loaderDiv")));
            }
            catch (Exception e)
            {
                Assert.Fail("Caught in WaitUntilLoadingSpinnerIsGoneMethod{0}", e.Message, e.StackTrace, e.InnerException);
            }
        }

        public void WaitFor(int milliSeconds)
        {
            Thread.Sleep(milliSeconds);
        }

        public Utilities Run_TestCase(string keywordFilePath, string sheetName)
        {
            LoginPage = new LoginPage();
            GoToUrl("");
            LoginPage.Login(Username,Password);

            Type[] typelist = getTypesInNamespace(
                Assembly.GetExecutingAssembly(), "Selenium.Tests.FunctionLibrary.TestMethods");

            MethodInfo = new List<MethodInfo>();
            foreach (var item in typelist)
            {
                MethodInfo.AddRange(Type.GetType(item.FullName)
                                 .GetMethods());
            }
            FileStream file = new FileStream(
                keywordFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            excelWBook = new XSSFWorkbook(file);
            excelWSheet = excelWBook.GetSheet(sheetName);

            for (int iRow = 1; iRow <=1; iRow++)
            {
                ActionKeyword = excelWSheet.GetRow(iRow).Cells[iKeywordCol].StringCellValue;
                ExecuteKeyWordAndUpdateResult(ActionKeyword,iRow,iResultCol,keywordFilePath,sheetName);
            }
            SendEmail("psdineshkumar04@gmail.com", "dinesh.kumar@psiog.com", keywordFilePath);
            return this;
        }

        private Type[] getTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }

        public void ExecuteKeyWordAndUpdateResult(string keyword,int iRow,int iCol,string filePath,string sheetName)
        {
            foreach (var method in MethodInfo)
            {
                if (method.Name.Equals(keyword))
                {
                    object obj = Activator.CreateInstance(method.DeclaringType);
                    var returnState=method.Invoke(obj, method.GetParameters());
                    if ((bool)returnState)
                    {
                        UpdateCellData(KEYWORD_PASS,iRow,iCol,filePath,sheetName);
                    }
                    else
                    {
                        TakeScreenshot(keyword);
                        UpdateCellData(KEYWORD_FAIL,iRow,iCol,filePath,sheetName);
                        
                    }
                } 
            }
        }

        public void TakeScreenshot(string keyword)
        {
            var screenshot =((ITakesScreenshot) driver).GetScreenshot();
            screenshot.SaveAsFile($"C:/selenium/{keyword}"+".jpeg",ScreenshotImageFormat.Jpeg);
        }

        //++++++++++++++++++++++++++++++++++++++++++++//
        //Not working
        //Needs to revisit
        //++++++++++++++++++++++++++++++++++++++++++++//
        public void UpdateCellData(string keyword,int row,int col,string filePath,string sheetName)
        {
            using (FileStream file = new FileStream(
                filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                excelWBook = new XSSFWorkbook(file);
                excelWSheet = excelWBook.GetSheet(sheetName);
                excelWSheet.GetRow(row).CreateCell(col).SetCellValue(keyword);
                excelWBook.Write(file);
                file.Close();
            }    
        }

        public void SendEmail(string from,string to,string attachmentFilePath)
        {
            try
            {
                var credentials =new NetworkCredential(from,"Gmail2018");
                var fromAddress = new MailAddress(from);
                var toAddress =new MailAddress(to);
                MailMessage mailMsg = new MailMessage(fromAddress, toAddress);
                mailMsg.Subject = "Selenium Automation Test Report";
                mailMsg.Body = "Sent by Selenium";
                Attachment attachFile =new Attachment(attachmentFilePath);
                mailMsg.Attachments.Add(attachFile);
                SmtpClient newEmail =new SmtpClient("smtp.gmail.com",587);
                newEmail.EnableSsl=true;
                newEmail.UseDefaultCredentials = false;
                newEmail.Credentials =credentials;
                newEmail.DeliveryMethod = SmtpDeliveryMethod.Network;
                newEmail.Send(mailMsg);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public Utilities CloseBrowser()
        {
            driver.Quit();
            return this;
        }
        #endregion

        #region Assertions
        public void AssertPageTitle(string str)
        {
            if (driver.Title != str)
            {
                Assert.Fail("Incorrect Page title");
            }
        }
        #endregion
    }
}
