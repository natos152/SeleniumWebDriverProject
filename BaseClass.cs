using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverProject
{
    public class BaseClass
    {
        protected IWebDriver Driver { get; set; }

        public BaseClass(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
