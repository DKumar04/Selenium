using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Tests.FunctionLibrary.Pages
{
    public class DetailsPage:ObjectRepository
    {
        protected Utilities Utilities;
        public DetailsPage(Utilities utils)
        {
            Utilities =utils;
        }
    }
}
