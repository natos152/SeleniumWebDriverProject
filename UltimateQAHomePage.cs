using OpenQA.Selenium;

namespace SeleniumWebDriverProject
{
    public class UltimateQAHomePage : BaseClass
    {
        public UltimateQAHomePage(IWebDriver driver) : base(driver) { }

        internal bool IsVisible => Driver.FindElement(By.ClassName("et_pb_s")).Displayed;
    }
}