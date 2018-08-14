using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Tests.FunctionLibrary.Pages.Dfr
{
    public class DfrDetailsPage:DetailsPage
    {
        public DfrDetailsPage(Utilities utils):base(utils)
        {

        }
        public DfrDetailsPage EnterHeaderDetails(string project, string dfrType)
        {
            SelectProject(project);
            SelectDfrType(dfrType);
            EnterSubject("-Created By Selenium");
            EnterSummary("KeyWord Driven Framework");
            return this;
        }

        public DfrDetailsPage SelectProject(string projectName)
        {
            Utilities.FindElement(ProjectDropDown).Click();
            Utilities.FindElement(ProjectTextBox).SendKeys(projectName);
            Utilities.FindElement(DropDownValue).Click();
            return this;
        }

        public DfrDetailsPage SelectDfrType(string dfrTypeName)
        {
            Utilities.FindElement(DfrTypeDropDown).Click();
            Utilities.FindElement(DfrTypeTextBox).SendKeys(dfrTypeName);
            Utilities.FindElement(DropDownValue).Click();
            return this;
        }

        public DfrDetailsPage EnterSubject(string subjectText)
        {
            Utilities.FindElement(Subject).SendKeys(subjectText);
            return this;
        }
       
        public DfrDetailsPage EnterSummary(string summary)
        {
            Utilities.FindElement(SummaryTextArea).SendKeys(summary);
            return this;
        }

        public DfrDetailsPage SaveHeader()
        {
            Utilities.FindElement(SaveDfrHeader).Click();
            return this;
        }

        public DfrDetailsPage SaveDfr()
        {
            Utilities.FindElement(SaveButton).Click();
            return this;
        }

    }
}
