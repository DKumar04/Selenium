using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Tests.FunctionLibrary.Pages.Dfr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Tests.FunctionLibrary.TestMethods
{
    public class DfrTests:BaseTest
    {
        private DfrListPage dfr;

        public bool CreateDfr()
        {
            try
            {                   
                dfr = new DfrListPage(Utilities);
                dfr
                    .GotoDfr()
                    .CreateDfr();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
