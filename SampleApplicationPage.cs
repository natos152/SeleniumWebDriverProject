using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumWebDriverProject
{
    internal class SampleApplicationPage : BaseClass
    {
        public SampleApplicationPage(IWebDriver driver) : base(driver) { }

        public bool IsVisible
        {
            get { return Driver.Title.Contains(PageTitle); }
        }

        public string PageTitle => "Sample Application Lifecycle - Sprint 3 - Ultimate QA";
        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));
        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));

        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='female']"));

        public void GoTO()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-3");
            Assert.IsTrue(IsVisible,
                $"Sample application page was not visible. Expected=>{PageTitle}." +
                $"Actual=>{Driver.Title}");
        }

        public UltimateQAHomePage FillOutFromAndSubmit(TheTestUser user)
        {
            SetGenderType(user);
            FirstNameField.SendKeys(user.Firstname);
            LastNameField.SendKeys(user.Lastname);
            SubmitButton.Submit();
            return new UltimateQAHomePage(Driver);

        }

        private void SetGenderType(TheTestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    break;
                default:
                    break;
            }
        }
    }
}