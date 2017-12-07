using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnit_Webdriver.Scenarios;
using xUnit_Webdriver.WebDriverManagers;

namespace xUnit_Webdriver
{
    [TestFixture]
    class GitHubTest
    {
        IWebDriver webDriver;
        LoginScenario loginScenario;
        PageBehaviors.LoginPageBehaviors.LoginCredentials credentials;

        [SetUp]
        public void OnStart()
        {
            webDriver = ChromeWebDriverManager.GetInstance();
            loginScenario = new LoginScenario(webDriver);
            credentials = new PageBehaviors.LoginPageBehaviors.LoginCredentials("testautomationuser", "Time4Death!");
        }

        [Test]
        public void LoginTest()
        {
            loginScenario.NavigateToLoginPage();
            loginScenario.Authorize(credentials);
        }

        [TearDown]
        public void Finish()
        {
            ChromeWebDriverManager.CloseDriver();
        }
    }
}
