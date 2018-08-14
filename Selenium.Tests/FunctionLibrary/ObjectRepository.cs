using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Tests.FunctionLibrary
{
    public class ObjectRepository
    {
        public ObjectRepository()
        {
        }
        public static By UsernameTxtbox = By.CssSelector("[placeholder='Username']");
        public static By PasswordTxtbox = By.Name("Password");
        public static By BtnLogin = By.XPath("//button[text()='Login']");
        public static By DfrNavLink =By.CssSelector("a[title=\"Daily Field Reports\"]>.font-bold");
        public static By Actions = By.LinkText("Actions");
        public static By CreateNew = By.LinkText("Create New");
        public static By ProjectDropDown = By.CssSelector("[name=\"dfrHeaderCreateForm\"]:nth-child(1) cellodropdown[name='projectId'] .ui-select-match");
        public static By ProjectTextBox =By.CssSelector("cellodropdown[name='projectId'] input[placeholder='Project'][aria-hidden='false']");
        public static By DfrTypeDropDown = By.CssSelector("ng-form[ng-show='projectIsSelected'] cellodropdown[name='dfrTypeId'] .ui-select-match");
        public static By DfrTypeTextBox =By.CssSelector("cellodropdown[name='dfrTypeId'] input[placeholder='DFR Type'][aria-hidden='false']");
        public static By DropDownValue =By.CssSelector(".ui-select-choices-row-inner .ui-select-highlight");
        public static By Subject = By.CssSelector("#subject-TextBox[ng-readonly='false']");
        public static By SummaryTextArea = By.CssSelector("#summary-TextArea[ng-readonly='false']");
        public static By SaveDfrHeader = By.CssSelector("button.btn.btn-success[ng-click*='createDfr']");
        public static By SaveButton = By.CssSelector("#SaveButton");
    }
}
