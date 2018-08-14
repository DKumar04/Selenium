using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium.Tests.FunctionLibrary.Pages.Dfr
{
    public class DfrListPage:ListPage
    {
        private DfrDetailsPage detailsPage;
        public DfrListPage(Utilities utils):base(utils)
        {
            detailsPage = new DfrDetailsPage(utils);
        }

        public DfrListPage GotoDfr()
        {
            Utilities.FindElement(DfrNavLink).Click();
            return this;
        }

        public DfrListPage CreateDfr()
        {
            SelectCreateAction();
            detailsPage
                .EnterHeaderDetails("Acme", "EmPWR")
                .SaveHeader()
                .SaveDfr();
            return this;
        }
    }
}
