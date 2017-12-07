using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnit_Webdriver.PageBehaviors
{
    class MainPageBehaviors
    {
        IWebDriver webDriver;
        IWebElement signInLink;

        public MainPageBehaviors(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            signInLink = webDriver.FindElement(By.LinkText("Sign in"));
        }

        public void PresentLoginPage()
        {
            signInLink.Click();
        }
    }
}
