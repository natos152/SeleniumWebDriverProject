using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace SeleniumWebDriverProject
{
    [TestClass]
    [TestCategory("SampleApplication")]
    public class SampleApplication : BaseClass
    {
        public SampleApplication(IWebDriver driver) : base(driver) { }
        public TheTestUser TheTestUser { get; set; }
        private IWebDriver GetChromeDriver()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(path);
        }

        [TestMethod]
        [Description("Valdiate taht user is able to fill out the form successfully using valid data.")]
        public void Test1()
        {
            SetupForEverySingleTestMethod();
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTO();

            var ultimateQAHomePage = sampleApplicationPage.FillOutFromAndSubmit(TheTestUser);
            Assert.IsFalse(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }

        [TestMethod]
        public void Test2()
        {
            SetupForEverySingleTestMethod();
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTO();

            var ultimateQAHomePage = sampleApplicationPage.FillOutFromAndSubmit(TheTestUser);
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }


        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();
            TheTestUser = new TheTestUser();
            TheTestUser.Firstname = "Netanel";
            TheTestUser.Lastname = "Aknin";
            TheTestUser.GenderType = Gender.Female;
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
