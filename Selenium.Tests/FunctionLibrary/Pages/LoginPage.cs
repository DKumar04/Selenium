using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Tests.FunctionLibrary.Pages
{
    public class LoginPage:ObjectRepository
    {
        protected Utilities Utilities = new Utilities();
       

        public void Login(string username,string password)
        {
            //Enter Username
            Utilities.FindElement(UsernameTxtbox).Clear();
            Utilities.FindElement(UsernameTxtbox).SendKeys(username);
            //Enter Password
            Utilities.FindElement(PasswordTxtbox).Clear();
            Utilities.FindElement(PasswordTxtbox).SendKeys(password);
            //Hit Login button
            Utilities.FindElement(BtnLogin).Click();
        }

    }
}
