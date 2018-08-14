using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Tests.FunctionLibrary.Pages
{
    
    public class ListPage:ObjectRepository
    {
        protected Utilities Utilities;
        public ListPage(Utilities utils)
        {
            Utilities = utils;
        }

        public void SelectCreateAction()
        {
            Utilities.FindElement(Actions).Click();
            Utilities.FindElement(CreateNew).Click();
        }
    }
}
