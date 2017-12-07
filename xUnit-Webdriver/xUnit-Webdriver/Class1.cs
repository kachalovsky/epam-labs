using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnit_Webdriver
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void MethodOne()
        {
            IWebDriver webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            string url = "https://github.com";
            webDriver.Navigate().GoToUrl(url);
            webDriver.FindElement(By.LinkText("Sign in")).Click();
            webDriver.FindElement(By.Id("login_field")).SendKeys("testautomationuser");
            webDriver.FindElement(By.Id("password")).SendKeys("Time4Death!");
            webDriver.FindElement(By.Name("commit")).Click();
        }
    }
}
